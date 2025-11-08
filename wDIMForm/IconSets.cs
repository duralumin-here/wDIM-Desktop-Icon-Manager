using Microsoft.WindowsAPICodePack.Dialogs;
using System.IO;

namespace wDIMForm
{
    internal class IconSets
    {
        public static void ApplySet(string iconSetPath)
        {
            ManageFolders(iconSetPath);
            ApplyIcons();
            Properties.Settings.Default.currentSet = iconSetPath;

            WallpaperHandle(); // Run by default
            Refresh(); // Normal one by default; also restarts Explorer if set to in settings
        }

        public static void ApplyIcons()
        {
            string[] icons = GetIconNames();
            List<string> shortcuts = GetShortcutTargets();
            List<string> defaults = GetDefaults();

            // Only try to apply default icons if at least one is present
            bool applyDefaults = defaults.Count != 0;

            int count = 0;

            foreach (string shortcut in shortcuts)
            {
                bool matched = false;
                foreach (string icon in icons)
                {
                    // Check if an icon matches the shortcut
                    if (shortcut.Equals(icon))
                    {
                        matched = true;
                        break;
                    }
                }
                // If no match is found, assign it a default icon
                if (!matched && applyDefaults)
                {
                    // Will iterate through defaults predictably; FEATURE could add other ways/randomize it
                    int index = count % defaults.Count;
                    try
                    {
                        // Copies the chosen default icon with the shortcut target's name, thus assigning it the default
                        FileInfo defaultIcon = new FileInfo(System.IO.Path.Combine(Utilities.GetCurrentIconsFolder(), defaults[index]));
                        defaultIcon.CopyTo(System.IO.Path.Combine(Utilities.GetCurrentIconsFolder(), shortcut + ".ico"));
                    }
                    catch { }
                    ++count;
                }
            }
        }

        // Gets all icon files in the current icons folder with "default" in the name
        // FEATURE may want to allow changing the word, or excluding certain files
        private static List<string> GetDefaults()
        {
            // Get all icon files in the current icons folder
            string[] icons = Directory.GetFiles(Utilities.GetCurrentIconsFolder(), "*.ico");
            List<string> defaults = new List<string> {};
            foreach (string icon in icons)
            {
                // Gather the ones that contain the phrase "default"
                if (icon.Contains("default"))
                {
                    defaults.Add(icon);
                }
            }
            return defaults;
        }

        // Gets icon files in current icon folder without extensions
        private static string[] GetIconNames()
        {
            string[] icons = Directory.GetFiles(Utilities.GetCurrentIconsFolder(), "*.ico");
            for (int i = 0; i < icons.Length; ++i)
            {
                icons[i] = icons[i].Substring(0, icons[i].LastIndexOf('.')); // Remove extension
            }
            return icons;
        }

        // Gets target names (without extensions or location) of desktop shortcuts
        private static List<string> GetShortcutTargets()
        {
            List<string> shortcuts = Utilities.CreateLinkArray();
            for (int i = 0; i < shortcuts.Count; ++i)
            {
                string target = Utilities.GetShortcutTarget(shortcuts[i]); // Get target
                target = target.Substring((target.LastIndexOf("\\") + 1)); // Just the file name
                shortcuts[i] = target.Substring(0, target.LastIndexOf('.')); // Remove extension
            }
            return shortcuts;
        }

        // Backs up most recent icons and copies icon set into the current folder
        public static void ManageFolders(string iconSetPath)
        {
            // Stores the just-"deleted" icons in case of a misclick; overwritten after the next swap
            string backupFolder = Utilities.GetRecentIconsFolder();
            string currentIcons = Utilities.GetCurrentIconsFolder();
            Directory.CreateDirectory(backupFolder);
            Utilities.EmptyFolder(backupFolder);
            Utilities.CopyDirectory(currentIcons, backupFolder);
            // Copies the icon set into the currently-used folder (done this way so we don't have to keep manually editing every shortcut's icon path)
            Utilities.EmptyFolder(currentIcons);
            Utilities.CopyDirectory(iconSetPath, currentIcons);
        }

        // Attempts to apply wallpaper from icon set
        private static void WallpaperHandle()
        {
            string wallpaper;
            if (Properties.Settings.Default.autoApplyWallpaper)
            {
                try
                {
                    wallpaper = Utilities.GetWallpaperPath(Utilities.GetCurrentIconsFolder());
                    if (wallpaper.Contains("wallpaper"))
                    {
                        Utilities.ChangeWallpaper(wallpaper);
                    }
                    else if (Properties.Settings.Default.applyDefaultWallpaper)
                    {
                        if (Properties.Settings.Default.defaultWallpaper != "?" && File.Exists(Properties.Settings.Default.defaultWallpaper))
                        {
                            Utilities.ChangeWallpaper(Properties.Settings.Default.defaultWallpaper);
                        }
                    }
                }
                catch {/* May log later*/}
            }
        }

        // Refreshes desktop (and explorer if desired)
        private static void Refresh()
        {
            Utilities.RefreshDesktop();
            if (Properties.Settings.Default.autoRestartExplorer)
            {
                try
                {
                    Utilities.RestartExplorer();
                }
                catch {/* May log later*/}
            }
        }

        // Lets user select and import an icon set by copying it into the icon sets folder
        public static void ImportSet()
        {
            string folder = PickFolder();
            if (folder == null) return;
            string folderName = folder.Substring((folder.LastIndexOf("\\") + 1));
            
            int count = 0;
            while (Directory.Exists(Path.Combine(Utilities.GetIconSetsFolder(), folderName)) && count < 5)
            {
                folderName = folderName + " - Copy";
                ++count;
            }
            if (count >= 5) // Prevents infinite looping and too-long file names
            {
                MessageBox.Show("An error occurred. Try renaming the folder, and then try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string newFolder = Path.Combine(Utilities.GetIconSetsFolder(), folderName);
            Utilities.CopyDirectory(folder, newFolder);
        }


        // Folder picker for importing sets
        private static string PickFolder()
        {
            CommonOpenFileDialog dialog = new()
            {
                InitialDirectory = "C:\\Users",
                IsFolderPicker = true,
                Title = "Select an icon set to import."
            };
            dialog.ShowDialog();
            try
            {
                return dialog.FileName;
            }
            catch (InvalidOperationException)
            {
                return null;
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show("An error occurred: " + e.Message + "\n\nPlease try again.", "wDIM", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
    }
}
