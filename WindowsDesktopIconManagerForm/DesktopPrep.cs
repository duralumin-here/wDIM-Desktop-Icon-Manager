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
            if (AreThereInvalidFiles())
            {
                string message = "Your desktop contains non-shortcuts. These will not be given a custom icon path. Press OK to proceed anyway, or press Cancel and run the Validate Desktop tool for more options.";
                if (!Utilities.ConfirmContinue(message)) return; // ask user to confirm continuing if invalid files are detected
            }

            Prepare(); // back up desktop and create directory
            string targetPath = "", targetFile = "", targetName = "";

            List<string> allEntries = Utilities.CreateDesktopArray(); // get list of all files on the desktop
            foreach (string shortcut in allEntries)
            {
                string startFolder = Utilities.GetCurrentIconsFolder();
                try
                {
                    targetPath = Utilities.GetShortcutTarget(shortcut);
                    targetFile = Path.GetFileName(targetPath);
                    targetName = targetFile.Substring(0, targetFile.LastIndexOf('.'));
                    ChangeIcon(shortcut, startFolder, targetName, targetPath);
                }
                catch
                {
                    // I don't currently feel the need to do anything if an attempt fails.
                }
            }
            Utilities.RefreshDesktop(); // refresh icons
        }

        // Technically creates a replacement shortcut with a new icon path, but effectively works as "changing the icon"
        private static void ChangeIcon(string shortcut, string startFolder, string targetName, string targetPath)
        {
            WshShell shell = new();
            IWshShortcut shortcut2 = (IWshShortcut)shell.CreateShortcut(shortcut);
            // Can use .Description and .Hotkey
            // TODO: Support for different icons even if target is the same (ie: chrome web apps)
            shortcut2.IconLocation = GetIconLocation();
            shortcut2.TargetPath = targetPath;
            shortcut2.Save();
        }

        public static string GetIconLocation(/*TODO: string startFolder, string targetName*/)
        {
            string iconLocation;
            string startFolder = Utilities.GetCurrentIconsFolder();
            // Get target name
            // iconLocation = Path.Combine(startFolder, targetName) + ".ico"; // Named after target path so names can be later changed if desired
            iconLocation = Path.Combine(startFolder, "Off") + ".ico";
            return iconLocation;
        }

        // Housekeeping before actually changing the icon paths
        private static void Prepare()
        {
            bool printOutput = false;
            bool justLinks = true;
            Utilities.CreateDesktopBackups(printOutput, justLinks); // Silent backup
            Directory.CreateDirectory(Utilities.GetCurrentIconsFolder()); // Create folder
        }

        // Checks for invalid (non-lnk) files
        private static bool AreThereInvalidFiles()
        {
            int invalidFileNum = Utilities.CountNonShortcuts().Count;
            if (invalidFileNum != 0)
            {
                return true;
            }
            return false;
        }
    }
}
