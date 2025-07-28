using IWshRuntimeLibrary;
using Microsoft.WindowsAPICodePack.Dialogs;
using System.IO;
using File = System.IO.File;

namespace WindowsDesktopIconManagerForm
{
    public class ForNonShortcuts
    {
        // Counts how many files on desktop are not shortcuts and adds them to the array passed along
        // TODO: Try to redo this all using a List instead of counting an imperfect array
        public static int CountNonShortcuts(string[] notShortcuts)
        {
            // Create array and number to count entries
            int numNonShortcuts = 0;
            string[] allEntries = Utilities.CreateDesktopArray();
            // Iterate through desktop; for each non-shortcut, add files to array and increment count
            foreach (string fileName in allEntries)
            {
                if (!fileName.Contains(".lnk") && !fileName.Contains("desktop.ini"))
                {
                    notShortcuts[numNonShortcuts] = fileName;
                    ++numNonShortcuts;
                }
            }
            return numNonShortcuts;
        }

        // ==================== Methods directly accessed through buttons ====================

        // Calls the method to check for non-shortcuts and asks the user what to do about them
        // TODO: Try to implement List here so I can use it in the other method too
        public static void HandleNonShortcuts()
        {
            string[] notShortcuts = new string[500];
            int invalidFileNum = CountNonShortcuts(notShortcuts);
            if (invalidFileNum != 0) // If invalid files exist, output message, prompt to fix, and run fixer
            {
                bool showWarning = false;
                string invalidItems = FormatInvalidItems(notShortcuts, invalidFileNum);
                var resultNonshr = NonShortcutsContinue(invalidItems);
                if (resultNonshr == DialogResult.Yes) // Proceed to helper if desired
                {
                    var resultMoveAll = PromptMoveAll();
                    if (resultMoveAll == DialogResult.Yes) // If user decides to move them all at once
                    {
                        int iconResult = CreateShortcutAll(notShortcuts, invalidFileNum);
                        if (iconResult == -1) // If it fails, show warning
                        {
                            showWarning = true;
                        }
                    }
                    else if (resultMoveAll == DialogResult.No) // If user wants to move them individually
                    {
                        for (int i = 0; i < invalidFileNum; ++i)
                        {
                            int iconResult = CreateShortcutOneByOne(notShortcuts[i]); // Attempt to create shortcut for each file
                            if (iconResult != 1) // If a move fails (returns other than 1)
                            {
                                showWarning = true;
                                if (iconResult == -1) // If it fails and user asks to exit (-1), then escape loop
                                {
                                    break;
                                }
                            }
                        }
                    }
                    else // If user exits the helper
                    {
                        showWarning = true;
                    }
                }
                else // Warn user if there's non-shortcuts and they skip the helper
                {
                    showWarning = true;
                }

                // Display appropriate message after running helper
                if (showWarning)
                {
                    WarningMessage();
                }
                else
                {
                    HelperCompleteMessage();
                }
            }
            // If all files are valid, output success message
            else
            {
                ValidatedMessage();
            }
        }

        // ==================== Methods used within these methods ====================

        public static DialogResult NonShortcutsContinue(string invalidItems)
        {
            // Create and display message box
            string errorNonshr = "The following files on your desktop are not shortcuts:";
            string promptNonshr = "Would you like this app to help you move these files?";
            string extraNonshr = "(If you want to handle the files manually yourself, you should select No, move these files, and run this checker again when you're done.)";
            string messageNonshr = errorNonshr + "\n\n" + invalidItems + "\n" + promptNonshr + " " + extraNonshr;
            string captionNonshr = "Invalid Entries Detected";
            var result = System.Windows.Forms.MessageBox.Show(messageNonshr, captionNonshr, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            return result;
        }

        public static DialogResult PromptMoveAll()
        {
            // Ask user if they'd like to move all non-shortcuts on the desktop to one folder
            string promptMoveAll = "Would you like to select one folder to move all of the non-shortcut files to?";
            string extraMoveAll = "(Select \"No\" to go through them one by one, and select \"Cancel\" to abort this operation and leave the helper instead.)";
            string messageMoveAll = promptMoveAll + " " + extraMoveAll;
            string captionMoveAll = "Desktop Icon Manager";
            var result = System.Windows.Forms.MessageBox.Show(messageMoveAll, captionMoveAll, MessageBoxButtons.YesNoCancel);
            return result;
        }

        public static string FormatInvalidItems(string[] notShortcuts, int invalidFileNum)
        {
            string invalidItems = "";
            for (int i = 0; i < invalidFileNum; ++i)
            {
                string ogName = notShortcuts[i].Substring((notShortcuts[i].LastIndexOf("\\") + 1));
                invalidItems = invalidItems + ogName + "\n";
            }

            return invalidItems;
        }
        public static void WarningMessage()
        {
            string promptWarning = "This tool only changes shortcut icons, but your desktop still contains non-shortcuts.";
            string extraWarning = "These will remain unaffected by custom icon sets unless you move them off of the desktop and replace them with shortcuts to their file location(s).";
            string messageWarning = promptWarning + " " + extraWarning;
            string captionWarning = "Non-Shortcuts Present";
            System.Windows.Forms.MessageBox.Show(messageWarning, captionWarning, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public static void HelperCompleteMessage()
        {
            string promptSuccess = "The helper is complete.";
            string extraSuccess = "If you created shortcuts, you may have to move them on your desktop back to where you expect them to be.";
            string messageSuccess = promptSuccess + " " + extraSuccess;
            string captionSuccess = "Helper Complete";
            System.Windows.Forms.MessageBox.Show(messageSuccess, captionSuccess, MessageBoxButtons.OK);
        }

        public static void ValidatedMessage()
        {
            string promptValid = "All desktop files are shortcuts.";
            string captionValid = "Desktop Validated";
            System.Windows.Forms.MessageBox.Show(promptValid, captionValid);
        }

        // Creates a shortcut on the desktop for a file given its location.
        // Returns 1 if successful, 0 if unsuccessful, and -1 if unsuccessful and user does not want to continue.
        static int CreateShortcutOneByOne(string itemPath)
        {
            int result = 0;
            string ogName = itemPath.Substring((itemPath.LastIndexOf("\\") + 1));
            // Get new folder from user and loop until valid (or escaped)
            bool loopFolder = true;
            string newFolder = "";
            do
            {
                // Display dialogue
                CommonOpenFileDialog dialog = new()
                {
                    InitialDirectory = "C:\\Users",
                    IsFolderPicker = true
                };
                dialog.Title = "Select a location to move " + ogName;
                dialog.ShowDialog();
                try
                {
                    // If valid folder is found, move on
                    newFolder = dialog.FileName;
                    loopFolder = false;
                }
                catch (Exception e)
                {
                    // If error, loop or continue (returning "1" does nothing, which will loop the helper since loopFolder is still true)
                    loopFolder = true;
                    result = AskToContinue(e);
                    if (result != 1)
                    {
                        return result;
                    }
                }
            }
            while (loopFolder);
            // Find file name without extension to use as name of shortcut
            string shortcutName = ogName.Substring(0, ogName.IndexOf("."));
            // Create new file path to move file to
            string newPath = Path.Combine(newFolder, ogName);
            // Attempt to move file
            try
            {
                File.Move(itemPath, newPath);
                // Return 1 if success
                result = 1;
            }
            catch (Exception e)
            {
                result = AskToContinue(e);
                return result;
            }
            // Continue as long as user hasn't asked to stop
            while (result != 1) ;
            // Refresh desktop to remove old icon from screen
            // FIXME: add a way to disable this since it flashes the screen
            Utilities.RefreshDesktop();
            // Ask user if they want a desktop shortcut for the moved file; skip if not
            string messageShcut = "Would you like to create a desktop shortcut for this item?";
            string captionShcut = "Windows Desktop Icon Manager";
            var resultShcut = System.Windows.Forms.MessageBox.Show(messageShcut, captionShcut, MessageBoxButtons.YesNo);
            // Create a new shortcut on the desktop for the file if desired
            if (resultShcut == DialogResult.Yes)
            {
                object shDesktop = (object)"Desktop";
                WshShell shell = new();
                string shortcutAddress = (string)shell.SpecialFolders.Item(ref shDesktop) + @"\" + shortcutName + ".lnk";
                IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(shortcutAddress);
                shortcut.TargetPath = newPath;
                shortcut.Save();
            }
            // Return 1 to indicate success
            result = 1;
            return result;
        }

        // Get whether or not user would like to retry, exit, or skip when a file move error occurs and returns as int
        static int AskToContinue(Exception e)
        {
            // Construct message
            string promptMoveFail = "An error occurred while trying to move the file:\n\n" + e.Message;
            string extraMoveFail = "Would you like to cancel the helper, try picking another file location, or continue without moving the file(s)?";
            string messageMoveFail = promptMoveFail + "\n\n" + extraMoveFail;
            string captionMoveFail = "File Move Error";
            var resultMoveFail = System.Windows.Forms.MessageBox.Show(messageMoveFail, captionMoveFail, MessageBoxButtons.CancelTryContinue);
            // Defaults to continuing
            int result = 0;
            // Exits if requested
            if (resultMoveFail == DialogResult.Cancel)
            {
                result = -1;
            }
            if (resultMoveFail == DialogResult.TryAgain)
            {
                result = 1;
            }
            return result;
        }

        // Moves all non-shortcuts on the desktop to a user-selected folder
        // Returns whether it was successful
        static int CreateShortcutAll(string[] allItems, int invalidFileNum)
        {
            int result = 0; // Start at zero to show the default behavior should skipping and trying again instead of aborting or looping
            bool loopFolder = true;
            string newFolder = "";
            do
            {
                // Have user select a file
                CommonOpenFileDialog dialog = new()
                {
                    InitialDirectory = "C:\\Users",
                    IsFolderPicker = true
                };
                dialog.ShowDialog();
                try
                {
                    newFolder = dialog.FileName;
                    loopFolder = false;
                }
                catch (Exception e)
                {
                    result = AskToContinue(e); // Prompt for retry and proceed accordingly (0 and -1 will skip, but 1 is ignored)
                    if (result < 1)
                    {
                        return result;
                    }
                }
            }
            while (loopFolder);
            // Attempt to move all items        
            for (int i = 0; i < invalidFileNum; ++i)
            {
                string itemPath = allItems[i];
                string ogName = itemPath.Substring((itemPath.LastIndexOf("\\") + 1));
                string shortcutName = ogName.Substring(0, ogName.IndexOf("."));
                string newPath = Path.Combine(newFolder, ogName);
                try
                {
                    File.Move(itemPath, newPath);
                }
                catch (Exception e)
                {
                    result = AskToContinue(e); // Prompt for retry and proceed accordingly (0 and -1 will skip, but 1 is ignored)
                    if (result < 1)
                    {
                        return result;
                    }
                }
            }
            Utilities.RefreshDesktop(); // to remove icon from screen
            return 1; // indicate success
        }
    }
}
