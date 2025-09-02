using IWshRuntimeLibrary;
using System.IO;

namespace WindowsDesktopIconManagerForm
{
    public class DesktopPrep
    {
        // Changes the shortcut icon paths to point to a new custom file based on the executable/file name being pointed to
        // References https://bytescout.com/blog/create-shortcuts-in-c-and-vbnet.html
        public static void SetIconPaths()
        {
            Prepare(); // back up desktop and create directory
            List<string> allEntries = Utilities.CreateDesktopArray(); // get list of all files on the desktop
            if (AreThereInvalidFiles())
            {
                if (ConfirmContinue() == false) // ask user to confirm continuing if invalid files are detected
                {
                    return;
                }
            }
            string targetPath = "", targetFile = "", targetName = "";
            bool success = true;
            foreach (string shortcut in allEntries)
            {
                string startFolder = Utilities.GetCurrentIconsFolder();
                try
                {
                    targetPath = GetShortcutTarget(shortcut);
                    targetFile = Path.GetFileName(targetPath);
                    targetName = targetFile.Substring(0, targetFile.LastIndexOf('.'));
                    ChangeIcon(shortcut, startFolder, targetName, targetPath);
                }
                catch
                {
                    success = false;
                }
                // I don't currently feel the need to do anything if an attempt fails,
                // but I can use the "success" variable for that if I change my mind.
            }
            Utilities.RefreshDesktop(); // refresh icons
            System.Windows.Forms.MessageBox.Show("Icon paths should be set. If some shortcuts didn't work, try re-running this program in Admin mode.", "Desktop Icon Manager");
        }

        // Technically creates a replacement shortcut with a new icon path, but effectively works as "changing the icon"
        private static void ChangeIcon(string shortcut, string startFolder, string targetName, string targetPath)
        {
            WshShell shell = new();
            IWshShortcut shortcut2 = (IWshShortcut)shell.CreateShortcut(shortcut);
            // shortcut2.Description = "Title text here";
            // shortcut2.Hotkey = "Ctrl+Shift+N";
            // TODO: Support for different icons even if target is the same (ie: chrome web apps)
            shortcut2.IconLocation = GetNewIconLocation();
            shortcut2.TargetPath = targetPath;
            shortcut2.Save();
        }

        public static string GetNewIconLocation(/*TODO: string startFolder, string targetName*/)
        {
            string iconLocation;
            string startFolder = Utilities.GetCurrentIconsFolder();
            // Get target name
            // iconLocation = Path.Combine(startFolder, targetName) + ".ico"; // Named after target path so names can be later changed if desired
            iconLocation = Path.Combine(startFolder, "Baba") + ".ico";
            return iconLocation;
        }

        // Returns the target than an .lnk file points to
        // Back-up way from https://learn.microsoft.com/en-us/dotnet/api/system.io.filesysteminfo.linktarget
        public static string GetShortcutTarget(string shortcutPath)
        {
            string target = "";
            try // Primary method
            {
                WshShell shell = new();
                IWshShortcut linkAlt = (IWshShortcut)shell.CreateShortcut(shortcutPath);

                target = linkAlt.TargetPath;
                if (target == "")
                {
                    throw new Exception("Empty target");
                }
            }
            catch
            {
                try // Secondary method
                {
                    FileInfo fileInfo = new FileInfo(shortcutPath);
                    target = fileInfo.LinkTarget;
                    if (target == "" || target == null) throw new Exception("Empty target");
                }
                catch {target = "";}
            }
            return target;
        }

        // Housekeeping before actually changing the icon paths
        public static void Prepare()
        {
            bool printOutput = false;
            bool justLinks = true;
            Utilities.CreateDesktopBackups(printOutput, justLinks); // Silent backup
            Directory.CreateDirectory(Utilities.GetCurrentIconsFolder()); // Create folder
        }

        // Checks for invalid (non-lnk) files
        public static bool AreThereInvalidFiles()
        {
            int invalidFileNum = ForNonShortcuts.CountNonShortcuts().Count;
            if (invalidFileNum != 0)
            {
                return true;
            }
            return false;
        }

        // If non-shortcuts are detected, have user decide whether or not to proceed anyway
        public static bool ConfirmContinue()
        {
            var result = System.Windows.Forms.MessageBox.Show("Your desktop contains non-shortcuts. These will not be given a custom icon path. Press OK to proceed anyway, or press Cancel and run the Validate Desktop tool for more options.", "Non-Shortcuts Detected", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (result == DialogResult.Cancel)
            {
                return false;
            }
            return true;
        }
    }
}
