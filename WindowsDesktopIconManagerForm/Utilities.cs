using IWshRuntimeLibrary;
using Microsoft.WindowsAPICodePack.Dialogs;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;

namespace WindowsDesktopIconManagerForm
{
    public class Utilities
    {
        // Creates and returns a List of all the files on the desktop
        public static List<string> CreateDesktopArray()
        {
            List<string> allEntries = [];
            allEntries.AddRange(GetPublicDesktopEntries());
            allEntries.AddRange(GetPrivateDesktopEntries());
            return allEntries;
        }

        // Gets the folder the app is located in
        public static string GetAppFolder()
        {
            return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "DesktopIconManager");
        }

        // Gets folder where backups are stored
        public static string GetBackupsFolder()
        {
            return Path.Combine(GetAppFolder(), "Saved-Backups");
        }

        public static string GetCurrentIconsFolder()
        {
            return Path.Combine(GetAppFolder(), "Current-Icons");
        }

        public static string GetCurrentArrowPath()
        {
            return Path.Combine(GetCurrentIconsFolder(), "arrow.ico");
        }

        public static string GetIconSetsFolder()
        {
            return Path.Combine(GetAppFolder(), "Icon-Sets");
        }

        public static string GetWallpaperPath(string folder)
        {
            string wallpaperName = "";
            string[] potentialNames = {"wallpaper.png", "wallpaper.jpeg", "wallpaper.jpg", "wallpaper.bmp", "wallpaper.gif"};
            foreach (string format in potentialNames)
            {
                string filePath = Path.Combine(folder, format);
                if (System.IO.File.Exists(filePath))
                {
                    wallpaperName = filePath;
                    break;
                }
            }
            return Path.Combine(GetCurrentIconsFolder(), wallpaperName);
        }

        // Creates and returns list on lnk files on the desktop
        public static List<string> CreateLinkArray()
        {
            List<string> allEntries = [];
            allEntries.AddRange(Directory.GetFiles(@"C:\Users\Public\Desktop", "*.lnk")); // private shortcuts
            allEntries.AddRange(Directory.GetFiles(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "*.lnk")); // public shortcuts
            return allEntries;
        }

        public static List<string> GetPublicDesktopEntries()
        {
            string publicDesk = @"C:\Users\Public\Desktop";
            List<string> publicEntries = new(Directory.GetFiles(publicDesk));
            return publicEntries;
        }

        public static List<string> GetPrivateDesktopEntries()
        {
            string userDesk = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            List<string> userEntries = new(Directory.GetFiles(userDesk));
            return userEntries;
        }

        // Allows me to refresh desktop to clear old icons
        [DllImport("Shell32.dll")]
        private static extern int SHChangeNotify(int eventId, int flags, IntPtr item1, IntPtr item2);
        public static void RefreshDesktop()
        {
            SHChangeNotify(0x8000000, 0x1000, IntPtr.Zero, IntPtr.Zero);
        }

        // Changes the wallpaper and refreshes the screen
        [DllImport("user32.dll")]
        public static extern int SystemParametersInfo(int uAction, int uParam, string lpvParam, int fuWinIni);
        public static void ChangeWallpaper(string wallpaperPath)
        {
            // Roughly (Change Wallpaper, [Required Variable], path, Persist Change | Refresh)
            SystemParametersInfo(20, 0, wallpaperPath, 0x01 | 0x02);
        }

        // Creates the folders this app expects to see
        public static void CreateStartingDirectories()
        {
            string appPath = GetAppFolder();
            Directory.CreateDirectory(GetBackupsFolder());
            Directory.CreateDirectory(GetCurrentIconsFolder());
            Directory.CreateDirectory(Path.Combine(appPath, "Shortcut-Arrows"));
            Directory.CreateDirectory(Path.Combine(appPath, "Icon-Sets"));
            Directory.CreateDirectory(Path.Combine(appPath, "Used-Arrows"));
        }

        // Restarts Windows Explorer using batch script (has to be a better way)

        public static void RestartExplorer()
        {
            // FIXME: string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "restart_explorer.bat");
            string filePath = @"C:\Users\User\Documents\DesktopIconManager\RestartExplorer.bat";

            try
            {
                Process runBatchFile = new Process();
                runBatchFile.StartInfo.FileName = filePath;
                runBatchFile.StartInfo.UseShellExecute = false; // Don't open a new window
                runBatchFile.StartInfo.RedirectStandardOutput = true; // Redirect output
                runBatchFile.StartInfo.RedirectStandardError = true; // Redirect error output

                // Start the process
                runBatchFile.Start();
            }
            catch (Exception e)
            {
                // Handle any exceptions that occur during the process
                MessageBox.Show("An error occurred: " + e.Message, "Desktop Icon Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Copies files from one directory to another
        public static void CopyDirectory(string sourceLocation, string destinationLocation)
        {
            DirectoryInfo sourceDirectory = new DirectoryInfo(sourceLocation);
            Directory.CreateDirectory(destinationLocation);
            foreach (FileInfo file in sourceDirectory.GetFiles())
            {
                try
                {
                    string targetFilePath = Path.Combine(destinationLocation, file.Name);
                    file.CopyTo(targetFilePath);
                }
                catch
                {
                    // TODO: add dialog
                }
            }
        }

        // Backs up links on desktop, or all files, depending on bool
        public static void CreateDesktopBackups(bool printOutput, bool isJustLinks)
        {
            string newPath = NewBackupsFolder(isJustLinks);
            BackupPublicDesktop(newPath, isJustLinks);
            BackupUserDesktop(newPath, isJustLinks);
            BackupCurrentIcons(newPath);
            if (printOutput) BackupSuccessMessage(newPath);
        }

        // Creates a new folder for the desktop backup
        private static string NewBackupsFolder(bool isJustLinks)
        {
            Directory.CreateDirectory(GetBackupsFolder());

            string description = "";
            if (isJustLinks) description = "-Shortcuts";
            else description = "-All";

            string newPath = Path.Combine(GetBackupsFolder(), DateTime.Now.ToString("yyyy_MM_dd__h-mm-sstt") + description);
            Directory.CreateDirectory(newPath);
            return newPath;
        }

        // Backs up files on public desktop to specified path (just shortcuts if bool = true)
        private static void BackupPublicDesktop(string backupPath, bool isJustLinks)
        {

            string newPublicPath = Path.Combine(backupPath, "PublicDesktop");
            Directory.CreateDirectory(newPublicPath);
            if (isJustLinks)
            {
                string[] lnkFilesPublic = Directory.GetFiles(@"C:\Users\Public\Desktop", "*.lnk");
                foreach (string file in lnkFilesPublic)
                {
                    string fileName = Path.GetFileName(file);
                    string destination = Path.Combine(newPublicPath, fileName);
                    System.IO.File.Copy(file, destination);
                }
            }
            else Utilities.CopyDirectory(@"C:\Users\Public\Desktop", newPublicPath);
        }

        // Backs up files on private desktop to specified path (just shortcuts if bool = true)
        private static void BackupUserDesktop(string backupPath, bool isJustLinks)
        {
            string newPrivatePath = Path.Combine(backupPath, "PrivateDesktop");
            Directory.CreateDirectory(newPrivatePath);
            if (isJustLinks)
            {
                string privateDesktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                string[] lnkFilesPrivate = Directory.GetFiles(privateDesktop, "*.lnk");
                foreach (string file in lnkFilesPrivate)
                {
                    string fileName = Path.GetFileName(file);
                    string destination = Path.Combine(newPrivatePath, fileName);
                    System.IO.File.Copy(file, destination);
                }
            }
            else Utilities.CopyDirectory(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), newPrivatePath);
        }

        // Backs up the Current Icons folder to the specified path
        private static void BackupCurrentIcons(string backupPath)
        {
            string currentIcons = GetCurrentIconsFolder();
            Directory.CreateDirectory(currentIcons);
            string newIconPath = Path.Combine(backupPath, "CurrentIcons");
            Utilities.CopyDirectory(currentIcons, newIconPath);
        }

        // Informs user that desktop files have been backed up to specified location
        private static void BackupSuccessMessage(string backupPath)
        {
            string message = "Saved backups to \"" + backupPath + "\".";
            string caption = "Task Completed";
            System.Windows.Forms.MessageBox.Show(message, caption);
        }

        // Folder picker
        public static string FolderSelector(string title, bool canSkip)
        {
            do
            {
                // Display dialogue
                CommonOpenFileDialog dialog = new()
                {
                    InitialDirectory = "C:\\Users",
                    IsFolderPicker = true,
                    Title = title
                };
                dialog.ShowDialog();
                try
                {
                    return dialog.FileName;
                }
                catch (Exception e)
                {
                    if (canSkip)
                    {
                        DialogResult result = PickerContinueAlt(e);
                        if (result == DialogResult.Abort) return "quit";
                        if (result == DialogResult.Continue) return "skip";
                    }
                    else if (!PickerContinueNormal(e)) return null;
                }
            }
            while (1 == 1);
        }

        private static bool PickerContinueNormal(Exception e)
        {
            string message = "An error occurred: " + e.Message + "\n\n" + "Would you like to try again?";
            DialogResult result = System.Windows.Forms.MessageBox.Show(message, "Desktop Icon Manager", MessageBoxButtons.RetryCancel);
            if (result == DialogResult.Retry)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static DialogResult PickerContinueAlt(Exception e)
        {
            string message = "An error occurred: " + e.Message + "\n\n" + "Would you like to abort (end the helper), try again, or ignore this file and continue?";
            return System.Windows.Forms.MessageBox.Show(message, "Desktop Icon Manager", MessageBoxButtons.AbortRetryIgnore);
        }

        public static bool ConfirmContinue(string message)
        {
            var result = System.Windows.Forms.MessageBox.Show(message, "Desktop Icon Manager", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (result == DialogResult.Cancel)
            {
                return false;
            }
            return true;
        }

        // Counts how many files on desktop are not shortcuts and adds them to the array passed along
        // Originally used arrays and had to keep a tally. Using List is easier.
        public static List<string> CountNonShortcuts()
        {
            List<string> allEntries = Utilities.CreateDesktopArray();
            List<string> nonShortcuts = [];
            foreach (string fileName in allEntries)
            {
                if (!fileName.Contains(".lnk") && !fileName.Contains("desktop.ini"))
                {
                    nonShortcuts.Add(fileName);
                }
            }
            return nonShortcuts;
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
                catch { target = ""; }
            }
            return target;
        }
    }
}
