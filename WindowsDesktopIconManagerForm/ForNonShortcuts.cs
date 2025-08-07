using IWshRuntimeLibrary;
using Microsoft.WindowsAPICodePack.Dialogs;
using MS.WindowsAPICodePack.Internal;
using System.IO;
using File = System.IO.File;

namespace WindowsDesktopIconManagerForm
{
    public class ForNonShortcuts
    {

        // ==================== Methods directly accessed through buttons ====================

        // Calls the method to check for non-shortcuts and asks the user what to do about them
        public static void HandleNonShortcuts()
        {
            List<string> notShortcuts = CountNonShortcuts();
            if (notShortcuts.Count() == 0) // If all files are valid, output success message and end
            {
                ValidatedMessage(); return;
            }

            if (!NonShortcutsContinue(notShortcuts)) // If user doesn't want to run the helper
            {
                WarningMessage(); return;
            }

            DialogResult resultMoveAll = PromptMoveAll();
            // If user decides to move them all at once
            if (resultMoveAll == DialogResult.Yes)
            {
                if (CreateShortcutAll(notShortcuts))
                {
                    HelperCompleteMessage(); return;
                }
                else
                {
                    WarningMessage(); return;
                }
            }
            // If user wants to move them individually
            else if (resultMoveAll == DialogResult.No)
            {
                if (MoveIndividually(notShortcuts))
                {
                    HelperCompleteMessage(); return;
                }
                else
                {
                    WarningMessage(); return;
                }
            }
            // If user doesn't want to use the helper
            else WarningMessage(); return;
        }

        // ==================== Methods used within these methods ====================


        // Counts how many files on desktop are not shortcuts and adds them to the array passed along
        // Originally used arrays and had to keep a tally. Using List is easier.
        public static List<string> CountNonShortcuts()
        {
            List<string> allEntries = Utilities.CreateDesktopArray();
            List<string> notShortcuts = [];
            foreach (string fileName in allEntries)
            {
                if (!fileName.Contains(".lnk") && !fileName.Contains("desktop.ini"))
                {
                    notShortcuts.Add(fileName);
                }
            }
            return notShortcuts;
        }

        // Runs the shortcut maker for each file; returns true if all files were properly handled
        public static bool MoveIndividually(List<string> notShortcuts)
        {
            bool allFilesHandled = true;
            foreach (string nonShortcut in notShortcuts)
            {
                int iconResult = CreateShortcutForOneFile(nonShortcut); // Attempt to create shortcut for each file
                if (iconResult != 1) // If a move fails (returns other than 1)
                {
                    allFilesHandled = false;
                    if (iconResult == -1) // If it fails and user asks to exit (-1), then escape and warn
                    {
                        return false;
                    }
                }
            }
            return allFilesHandled;
        }

        // Returns whether user wants to run helper
        public static bool NonShortcutsContinue(List<string> notShortcuts)
        {
            // Create and display message box
            string errorNonshr = "The following files on your desktop are not shortcuts:";
            string promptNonshr = "Would you like this app to help you move these files?";
            string extraNonshr = "(If you want to handle the files manually yourself, you should select No, move these files, and run this checker again when you're done.)";
            string messageNonshr = errorNonshr + "\n\n" + FormatInvalidItems(notShortcuts) + "\n" + promptNonshr + " " + extraNonshr;
            string captionNonshr = "Invalid Entries Detected";
            var result = System.Windows.Forms.MessageBox.Show(messageNonshr, captionNonshr, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes) return true;
            else return false;
        }

        // Returns whether user wants to move all files at once
        public static DialogResult PromptMoveAll()
        {
            string promptMoveAll = "Would you like to select one folder to move all of the non-shortcut files to?";
            string extraMoveAll = "(Select \"No\" to go through them one by one, and select \"Cancel\" to abort this operation and leave the helper instead.)";
            string messageMoveAll = promptMoveAll + " " + extraMoveAll;
            string captionMoveAll = "Desktop Icon Manager";
            var result = System.Windows.Forms.MessageBox.Show(messageMoveAll, captionMoveAll, MessageBoxButtons.YesNoCancel);
            return result;
        }

        // Formats the list of invalid items for message boxes
        public static string FormatInvalidItems(List<string> notShortcuts)
        {
            string invalidItems = "";
            foreach (string invalidItem in notShortcuts)
            {
                string ogName = invalidItem.Substring((invalidItem.LastIndexOf("\\") + 1));
                invalidItems = invalidItems + ogName + "\n";
            }
            return invalidItems;
        }

        // Warns user if non-shortcuts remain on desktop
        public static void WarningMessage()
        {
            string promptWarning = "This tool only changes shortcut icons, but your desktop still contains non-shortcuts.";
            string extraWarning = "These will remain unaffected by custom icon sets unless you move them off of the desktop and replace them with shortcuts to their file location(s).";
            string messageWarning = promptWarning + " " + extraWarning;
            string captionWarning = "Non-Shortcuts Present";
            System.Windows.Forms.MessageBox.Show(messageWarning, captionWarning, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        // Tells user that helper succeeded
        public static void HelperCompleteMessage()
        {
            string promptSuccess = "The helper is complete.";
            string extraSuccess = "If you created shortcuts, you may have to move them on your desktop back to where you expect them to be.";
            string messageSuccess = promptSuccess + " " + extraSuccess;
            string captionSuccess = "Helper Complete";
            System.Windows.Forms.MessageBox.Show(messageSuccess, captionSuccess, MessageBoxButtons.OK);
        }

        // Tells user all files are already shortcuts; no helper needed
        public static void ValidatedMessage()
        {
            string promptValid = "All desktop files are shortcuts.";
            string captionValid = "Desktop Validated";
            System.Windows.Forms.MessageBox.Show(promptValid, captionValid);
        }

        // Creates a shortcut on the desktop for a file given its location.
        // Returns 1 if successful, 0 if unsuccessful, and -1 if unsuccessful and user does not want to continue.
        static int CreateShortcutForOneFile(string itemPath)
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
            
            while (result != 1); // Continue as long as user hasn't asked to stop
            Utilities.RefreshDesktop(); // Remove old icon from screen; FIXME may need flash warning
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
            DialogResult resultMoveFail = FileMoveError(e);
            if (resultMoveFail == DialogResult.Cancel) return -1; // Exit helper
            if (resultMoveFail == DialogResult.TryAgain) return 1; // Pick another location
            return 0; // Skip
        }

        public static DialogResult FileMoveError(Exception e)
        {
            string promptMoveFail = "An error occurred while trying to move the file:\n\n" + e.Message;
            string extraMoveFail = "Would you like to cancel the helper, try picking another file location, or continue without moving the file(s)?";
            string messageMoveFail = promptMoveFail + "\n\n" + extraMoveFail;
            string captionMoveFail = "File Move Error";
            return System.Windows.Forms.MessageBox.Show(messageMoveFail, captionMoveFail, MessageBoxButtons.CancelTryContinue);
        }

        // Moves all non-shortcuts on the desktop to a user-selected folder
        // Returns whether it was successful
        static bool CreateShortcutAll(List<string> allItems)
        {
            bool loopFolder = true;
            string newFolder = "";
            do
            {
                try
                {
                    newFolder = GetFolder();
                    loopFolder = false;
                }
                catch (Exception e)
                {
                    if (AskToContinue(e) < 1) // If the user quit the helper (0 or -1)
                    {
                        return false;
                    }
                }
            }
            while (loopFolder);

            bool didItWork = MoveAll(allItems, newFolder); // Attempt to move all items
            Utilities.RefreshDesktop(); // Remove icon(s) from screen
            return didItWork; // Indicate success
        }

        // Has user select a folder
        public static string GetFolder()
        {
            string newFolder;
            CommonOpenFileDialog dialog = new()
            {
                InitialDirectory = "C:\\Users",
                IsFolderPicker = true
            };
            dialog.ShowDialog();
            newFolder = GetFolder();
            newFolder = dialog.FileName;
            return newFolder;
        }

        // Moves the items in the list to the specified folder
        // Returns whether all items were successfully moved
        public static bool MoveAll(List<string> allItems, string newFolder)
        {
            foreach (string item in allItems)
            {
                string itemPath = item;
                string ogName = itemPath.Substring((itemPath.LastIndexOf("\\") + 1));
                string newPath = Path.Combine(newFolder, ogName);
                try
                {
                    File.Move(itemPath, newPath);
                }
                catch (Exception e)
                {
                    if (AskToContinue(e) < 1)
                    {
                        return false; // Return that it didn't work if the user stops it partway through
                    }
                }
            }
            return true; // If it makes it to the end, it worked
        }
    }
}
