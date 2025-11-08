using IWshRuntimeLibrary;
using System.IO;
using File = System.IO.File;

namespace wDIMForm
{
    // IMPORTANT NOTE: This was some of the earliest code I wrote, and it shows. I plan to improve it.

    public class ForNonShortcuts
    {
        // Calls the method to check for non-shortcuts and asks the user what to do about them
        public static void NonShortcutTool()
        {
            List<string> nonShortcuts = Utilities.CountNonShortcuts();
            if (!ShouldHelperContinue(nonShortcuts)) return;

            bool allAtOnce;
            DialogResult result = MoveFilesPrompt();
            if (result == DialogResult.Cancel)
            {
                WarningMessage();
                return; // If user doesn't want to use the helper
            }

            if (result == DialogResult.Yes) allAtOnce = true; // If user decides to move them all at once
            else allAtOnce = false;

            if (MoveShortcutFiles(nonShortcuts, allAtOnce)) HelperCompleteMessage(); // If it works
            else WarningMessage();

            PublicToPrivateCheck(); // Check for public shortcuts on desktop
            return;
        }

        private static bool ShouldHelperContinue(List<string> nonShortcuts)
        {
            if (nonShortcuts.Count() == 0) // If all files are shortcuts
            {
                ValidatedMessage();
                PublicToPrivateCheck();
                return false;
            }
            if (!NonShortcutsContinue(nonShortcuts)) // If user doesn't want to run the helper
            {
                WarningMessage();
                return false;
            }
            else return true;
        }

        public static bool MoveShortcutFiles(List<string> nonShortcuts, bool allAtOnce)
        {
            if (allAtOnce)
            {
                bool loopFolder = true;
                string newFolder = "";
                do
                {
                    try
                    {
                        newFolder = Utilities.FolderSelector("Select a folder.", false);
                        if (newFolder == null) throw new Exception("No folder selected.");
                        loopFolder = false;
                    }
                    catch (Exception e)
                    {
                        if (AskToContinue(e) < 1) return false; // If the user quit the helper (0 or -1)
                    }
                }
                while (loopFolder);

                bool moveSuccess = MoveAll(nonShortcuts, newFolder); // Attempt to move all items
                Utilities.RefreshDesktop(); // Remove icon(s) from screen
                return moveSuccess; // Indicate success
            }
            else
            {
                bool allFilesHandled = true;
                foreach (string nonShortcut in nonShortcuts)
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
        }

        // Returns whether user wants to run helper
        private static bool NonShortcutsContinue(List<string> nonShortcuts)
        {
            // Create and display message box
            string errorNonshr = "The following files on your desktop are not shortcuts:";
            string promptNonshr = "Would you like this app to help you move these files?";
            string extraNonshr = "(If you want to handle the files manually yourself, you should select No, move these files, and run this checker again when you're done.)";
            string messageNonshr = errorNonshr + "\n\n" + FormatInvalidItems(nonShortcuts) + "\n" + promptNonshr + " " + extraNonshr;
            string captionNonshr = "Invalid Entries Detected";
            var result = System.Windows.Forms.MessageBox.Show(messageNonshr, captionNonshr, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes) return true;
            else return false;
        }

        // Returns whether user wants to move all files at once
        private static DialogResult MoveFilesPrompt()
        {
            string MoveFilesPrompt = "Would you like to select one folder to move all of the non-shortcut files to?";
            string extraMoveAll = "(Select \"No\" to go through them one by one, and select \"Cancel\" to abort this operation and leave the helper instead.)";
            string messageMoveAll = MoveFilesPrompt + " " + extraMoveAll;
            string captionMoveAll = "wDIM";
            var result = System.Windows.Forms.MessageBox.Show(messageMoveAll, captionMoveAll, MessageBoxButtons.YesNoCancel);
            return result;
        }

        // Formats the list of invalid items for message boxes
        private static string FormatInvalidItems(List<string> nonShortcuts)
        {
            string invalidItems = "";
            foreach (string invalidItem in nonShortcuts)
            {
                string ogName = invalidItem.Substring((invalidItem.LastIndexOf("\\") + 1));
                invalidItems = invalidItems + ogName + "\n";
            }
            return invalidItems;
        }

        // Warns user if non-shortcuts remain on desktop
        private static void WarningMessage()
        {
            string promptWarning = "This tool only changes shortcut icons, but your desktop still contains non-shortcuts.";
            string extraWarning = "These will remain unaffected by custom icon sets unless you move them off of the desktop and replace them with shortcuts to their file location(s).";
            string messageWarning = promptWarning + " " + extraWarning;
            string captionWarning = "Non-Shortcuts Present";
            System.Windows.Forms.MessageBox.Show(messageWarning, captionWarning, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        // Tells user that helper succeeded
        private static void HelperCompleteMessage()
        {
            string promptSuccess = "The helper is complete.";
            string extraSuccess = "If you created shortcuts, you may have to move them on your desktop back to where you expect them to be.";
            string messageSuccess = promptSuccess + " " + extraSuccess;
            string captionSuccess = "Helper Complete";
            System.Windows.Forms.MessageBox.Show(messageSuccess, captionSuccess, MessageBoxButtons.OK);
        }

        // Tells user all files are already shortcuts; no helper needed
        private static void ValidatedMessage()
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

            string newFolder = Utilities.FolderSelector("Select a location to move " + ogName, true);
            if (newFolder.Equals("exit")) return -1;
            if (newFolder.Equals("skip")) return 0;

            string shortcutName = ogName.Substring(0, ogName.LastIndexOf('.'));
            // Attempt to move file
            string newPath = Path.Combine(newFolder, ogName);
            try
            {
                File.Move(itemPath, newPath);
                result = 1; // indicate success
            }
            catch (Exception e)
            {
                result = AskToContinue(e);
                return result;
            }
            while (result != 1) ; // Continue as long as user hasn't asked to stop


            Utilities.RefreshDesktop(); // Remove old icon from screen; FIXME may need flash warning
            // Ask user if they want a desktop shortcut for the moved file; skip if not
            string messageShcut = "Would you like to create a desktop shortcut for this item?";
            string captionShcut = "Windows wDIM";
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
        public static int AskToContinue(Exception e)
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

        public static void PublicToPrivateCheck()
        {
            List<string> shortcuts = [];
            shortcuts.AddRange(Directory.GetFiles(@"C:\Users\Public\Desktop", "*.lnk"));
            if (shortcuts.Count == 0) return;
            PublicToPrivate(shortcuts);
        }

        public static void PublicToPrivate(List<string> shortcuts)
        {
            string message1 = "Some shortcuts are on the public desktop. You may need administrator access every time you try to modify these files. Would you like to move them to your private desktop?";
            string message2 = "(This will let you modify them without administrator access, but it will hide those shortcuts from other users. This option is not recommended if multiple people use your computer.)";
            DialogResult result = System.Windows.Forms.MessageBox.Show(message1 + " " + message2, "wDIM", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                try
                {
                    string privateDesktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                    foreach (string shortcut in shortcuts)
                    {
                        string ogName = shortcut.Substring((shortcut.LastIndexOf("\\") + 1));
                        if (ogName == "desktop.ini") continue;
                        File.Move(shortcut, Path.Combine(privateDesktop, ogName));
                    }
                    Utilities.RefreshDesktop();
                    System.Windows.Forms.MessageBox.Show("Public shortcuts have been moved to private desktop.", "wDIM");
                }
                catch (Exception e)
                {
                    System.Windows.Forms.MessageBox.Show("An error occurred: " + e.Message + "\n\nYou may need to rerun the program in admin mode.", "wDIM", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
