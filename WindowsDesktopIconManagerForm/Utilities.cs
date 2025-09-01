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
            return Path.Combine(GetCurrentIconsFolder(), "current-arrow.ico");
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
        private const uint SHCNE_ALLEVENTS = 0x80000000;
        private const uint SHCNF_FLUSH = 0x1000;
        public static void RefreshDesktop()
        {
            SHChangeNotify(0x8000000, 0x1000, IntPtr.Zero, IntPtr.Zero);
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

        // Restarts Windows Explorer
        // SLOW. MIGHT NOT INCLUDE.
        // However this application is meant for people who may not be comfortable opening
        // Task Manager and this is the most reliable method to restart explorer with C# I've tried yet.
        public static void RestartExplorer()
        {
            Process.Start("taskkill", "/F /IM sihost.exe");
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
                    File.Copy(file, destination);
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
                    File.Copy(file, destination);
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
    }
}
