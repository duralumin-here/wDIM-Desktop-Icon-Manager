using IWshRuntimeLibrary;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;

namespace wDIMForm
{
    internal class IconSets
    {
        // TODO: Add GUI for creating/editing icon sets (may need to allow identical apps to be renamed)
        // FIXME: Add flow for importing icon sets (warn if no .ico files found)
        // FIXME: Rework applying the icon set to handle arrows and wallpaper

        public static void ApplySet(string iconSetPath)
        {
            if (AreDifferent(iconSetPath))
            {
                WhichToKeep();
            }
            else
            {
                // Clear current icon folder and copy icon set to it
            }


            /* Apply icons
                * I think this will make the most sense if it starts by checking all files for matching ones
                * Then, for any ones that don't have a matching icon, apply a random other icon in the file
                */

            Properties.Settings.Default.currentSet = iconSetPath;

            WallpaperHandle(); // Run by default
            ArrowHandle(); // Skipped by default
            ExplorerHandle(); // SKipped by default
        }

        private static void WallpaperHandle()
        {
            if (Properties.Settings.Default.autoApplyWallpaper)
            {
                try
                {
                    Utilities.ChangeWallpaper(Utilities.GetWallpaperPath(Utilities.GetCurrentIconsFolder()));
                }
                catch
                {
                    // May log later
                }
            }
        }

        private static void ArrowHandle()
        {
            if (Properties.Settings.Default.autoApplyArrows)
            {
                try
                {
                    Arrow.SetArrowPath(Utilities.GetCurrentArrowPath());
                }
                catch
                {
                    // May log later
                }
            }
        }

        private static void ExplorerHandle()
        {
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

        private static bool AreDifferent(string iconSetPath)
        {
            // Check if original folder even exists
            if (!Directory.Exists(Properties.Settings.Default.currentSet))
            {
                Directory.CreateDirectory(Properties.Settings.Default.currentSet);
                return false;
            }

            FileInfo[] currentFolder = new DirectoryInfo(Utilities.GetCurrentIconsFolder()).GetFiles();
            FileInfo[] copiedFrom = new DirectoryInfo(Properties.Settings.Default.currentSet).GetFiles();

            // If different numbers of files
            if (currentFolder.Length != copiedFrom.Length)
            {
                return true;
            }
            
            // If one more recently modified than the other
            if (GetMostRecentModified(currentFolder) != GetMostRecentModified(copiedFrom))
            {
                return true;
            }

            // Return false if it passes all checks (could compare the actual files but that seems a little intensive/slow for this)
            return false;            
        }

        private static long GetMostRecentModified(FileInfo[] folder)
        {
            long count = 0;
            foreach (FileInfo file in folder)
            {
                if (file.LastWriteTime.Ticks > count)
                {
                    count = file.LastWriteTime.Ticks;
                }
            }
            return count;
        }
    }
}
