using IWshRuntimeLibrary;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Shapes;

namespace wDIMForm
{
    internal class IconSets
    {

        // TODO: Add GUI for creating/editing icon sets (may need to allow identical apps to be renamed)
        // FIXME: Add flow for importing icon sets (warn if no .ico files found)

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
            bool applyDefaults;
            if (defaults.Count == 0) applyDefaults = false; else applyDefaults = true;
            int count = 0;

            foreach (string shortcut in shortcuts)
            {
                bool matched = false;
                foreach (string icon in icons)
                {
                    if (shortcut.Equals(icon))
                    {
                        matched = true;
                        break;
                    }
                }
                if (!matched && applyDefaults)
                {
                    int index = count % defaults.Count;
                    try
                    {
                        FileInfo defaultIcon = new FileInfo(System.IO.Path.Combine(Utilities.GetCurrentIconsFolder(), defaults[index]));
                        defaultIcon.CopyTo(System.IO.Path.Combine(Utilities.GetCurrentIconsFolder(), shortcut + ".ico"));
                    }
                    catch // (Exception e)
                    {
                        // MessageBox.Show(e.Message);
                    }
                    // Dupicate defaults[index] to ;
                    ++count;
                }
            }
        }

        public static List<string> GetDefaults()
        {
            string[] icons = Directory.GetFiles(Utilities.GetCurrentIconsFolder(), "*.ico");
            List<string> defaults = new List<string> {};
            foreach (string icon in icons)
            {
                if (icon.Contains("default"))
                {
                    defaults.Add(icon);
                }
            }
            return defaults;
        }

        public static string[] GetIconNames()
        {
            string[] icons = Directory.GetFiles(Utilities.GetCurrentIconsFolder(), "*.ico");
            for (int i = 0; i < icons.Length; ++i)
            {
                icons[i] = icons[i].Substring(0, icons[i].LastIndexOf('.')); // Remove extension
            }
            return icons;
        }

        public static List<string> GetShortcutTargets()
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
                        if (Properties.Settings.Default.defaultWallpaper != "?")
                        {
                            Utilities.ChangeWallpaper(Properties.Settings.Default.defaultWallpaper);
                        }
                    }
                }
                catch
                {
                    // May log later
                }
            }
        }

        private static void Refresh()
        {
            Utilities.RefreshDesktop();
            if (Properties.Settings.Default.autoRestartExplorer)
            {
                try
                {
                    Utilities.RestartExplorer();
                }
                catch
                {
                    // May log later
                }
            }
        }
    }
}
