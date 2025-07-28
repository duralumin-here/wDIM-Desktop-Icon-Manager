using System;

namespace WindowsDesktopIconManagerForm
{
    public class Arrow
    {
        // ==================== Methods directly accessed through buttons ====================
        // Allows user to select a custom shortcut arrow icon and change shortcut arrows to it
        // General implementation https://stackoverflow.com/a/24031611
        // Specific help with shortcut arrows https://www.elevenforum.com/t/remove-shortcut-arrow-icon-in-windows-11.3814/

        public static void ChangeArrows()
        {
            if (ConfirmChange() == false)
            {
                return;
            }
            string iconPath = ChooseArrow();
            if (iconPath.Equals(""))
            {
                return;
            }
            SaveNewArrow(iconPath);     // Copies to Current-Icons, but arrow path will not point there
                                        // Updating the arrow in the same location doesn't update the arrow icon on the desktop
                                        // even after restarting explorer, so the arrow path just points directly to the original file
            if (SetArrowPath(iconPath)) // Will return true if the operation succeeds
            {
                SuccessMessage();
            }
            // If it fails, it'll send the failure message within the method
        }

        // Allows user to restore original shortcut arrows
        public static void Restore()
        {
            if (ConfirmRestore() == false)
            {
                return;
            }
            if (RestoreArrows())
            {
                SuccessMessage();
            }
            // If it fails, it'll send the failure message within the method
        }

        // ==================== Methods used within these methods ====================

        // Warns user and asks if they want to proceed with arrow change
        public static bool ConfirmChange()
        {
            string regEditWarning = "This feature uses an edit to the Windows registry in order to change or remove arrows from shortcut links on the desktop.";
            string disclaimer1 = "To the best of my knowledge, as of the time I created this app, this method works and is safe. However, it may not work on every computer and could break or stop working at any time.";
            string context = "Additionally, shortcuts on the desktop link to other files, links, etc. Removing shortcut arrows may cause confusion as to whether something on the desktop is a shortcut or the file's direct location.";
            string disclaimer2 = "You assume all responsibility for any data loss or damage that may result from using this functionality.";

            var resultWarning = System.Windows.Forms.MessageBox.Show(regEditWarning + " " + disclaimer1 + " " + context + "\n\n" + disclaimer2, "Warning!", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (resultWarning == DialogResult.Cancel)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        // Warns user and asks if they want to proceed with arrow restore
        public static bool ConfirmRestore()
        {
            string regEditWarning = "This feature uses an edit to the Windows registry in order to restore arrows to shortcut links on the desktop.";
            string disclaimer1 = "To the best of my knowledge, as of the time I created this app, this method works and is safe. However, it may not work on every computer and could break or stop working at any time.";
            string context = "If you've never made any changes to the Windows shortcut arrows, there's no need to use this feature.";
            string disclaimer2 = "You assume all responsibility for any data loss or damage that may result from using this functionality.";
            var resultWarning = System.Windows.Forms.MessageBox.Show(regEditWarning + " " + disclaimer1 + " " + context + "\n\n" + disclaimer2, "Warning!", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (resultWarning == DialogResult.Cancel)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        // Gets user to select an arrow icon
        public static string ChooseArrow()
        {
            string iconPath = "";
            string arrowDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "DesktopIconManager", "Shortcut-Arrows");
            bool loopFolder = true;
            do
            {
                CommonOpenFileDialog dialog = new()
                {
                    InitialDirectory = arrowDir
                };
                dialog.Title = "Select an icon to use as the shortcut arrow. (Only .ico files can be used.)";
                dialog.Filters.Add(new CommonFileDialogFilter("Icon Files", "*.ico"));
                dialog.ShowDialog();
                try
                {
                    iconPath = dialog.FileName;
                    loopFolder = false;
                }
                catch (Exception e)
                {
                    var resultNonshr = System.Windows.Forms.MessageBox.Show("Error: " + e.Message + "\n\nWould you like to try again?", "Error", MessageBoxButtons.YesNo);
                    if (resultNonshr == DialogResult.No)
                    {
                        return "";
                    }
                }
            }
            while (loopFolder);
            return iconPath;
        }

        // Sets a registry key to set shortcut arrow path to whatever is provided
        public static bool SetArrowPath(string iconPath)
        {
            string registryPath = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Shell Icons";
            try
            {
                using (RegistryKey key = Registry.LocalMachine.CreateSubKey(registryPath))
                {
                    if (key != null)
                    {
                        // This part points directly to the icon because it seems like
                        // just swapping out the files doesn't work when just resetting explorer.
                        // Icon is still copied into current icons in case I find a fix,
                        // and for the sake of the user knowing what arrow goes with what set.
                        key.SetValue("29", iconPath, RegistryValueKind.String);
                    }
                    else
                    {
                        throw new Exception("Null registry key.");
                    }
                }
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show("An error occurred:" + e.Message + "\n\nTry re-running the application in Admin mode and see if that fixes the issue.", "Error");
                return false;
            }
            return true;
        }

        // Restores shortcut arrows to defaults by removing registry edit
        public static bool RestoreArrows()
        {
            string registryPath = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Shell Icons";
            try
            {
                using (RegistryKey key = Registry.LocalMachine.OpenSubKey(registryPath, writable: true))
                {
                    if (key != null)
                    {
                        key.DeleteValue("29", throwOnMissingValue: false);
                    }
                    else
                    {
                        throw new Exception("Null registry key.");
                    }
                }
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show("An error occurred: " + e.Message + "\n\nTry re-running the application in Admin mode and see if that fixes the issue.", "Error");
                return false;
            }
            return true;
        }

        // Notifies user that the arrow change was successful
        public static void SuccessMessage()
        {
            System.Windows.Forms.MessageBox.Show("Shortcut arrow changes have been applied. To see the change, you'll have to restart the Windows Explorer shell or restart your computer.", "Shortcut Arrows Updated");
        }

        // Attempts to save the new shortcut arrow to the current icon folder
        public static void SaveNewArrow(string iconPath)
        {
            try
            {
                string targetFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "DesktopIconManager", "Current-Icons", "current-arrow.ico");
                File.Copy(iconPath, targetFilePath, overwrite: true);
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("Note: Could not copy arrow to current icon folder for back-up. Functionality shouldn't be affected as long as the registry edit succeeds.", "Notice");

            }
        }
    }
}