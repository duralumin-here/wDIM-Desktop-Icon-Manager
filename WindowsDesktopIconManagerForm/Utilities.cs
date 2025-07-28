using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;

namespace WindowsDesktopIconManagerForm
{
    public class Utilities
    {
        // Creates and returns a perfect array of all the files on the desktop
        public static string[] CreateDesktopArray()
        {
            // Find desktop locations
            string publicDesk = @"C:\Users\Public\Desktop";
            string userDesk = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            // Create lists of files in each desktop
            string[] publicEntries = Directory.GetFiles(publicDesk);
            string[] userEntries = Directory.GetFiles(userDesk);
            // Combine both desktops into one array
            string[] allEntries = new string[publicEntries.Length + userEntries.Length];
            for (int i = 0; i < publicEntries.Length; ++i)
            {
                allEntries[i] = publicEntries[i];
            }
            for (int i = 0; i < userEntries.Length; ++i)
            {
                allEntries[publicEntries.Length + i] = userEntries[i];
            }
            return allEntries;
        }

        // Allows me to refresh desktop to clear old icons
        // Tweaked from https://stackoverflow.com/a/647286
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
            string appPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "DesktopIconManager");
            Directory.CreateDirectory(Path.Combine(appPath, "Saved-Backups"));
            Directory.CreateDirectory(Path.Combine(appPath, "Current-Icons"));
            Directory.CreateDirectory(Path.Combine(appPath, "Shortcut-Arrows"));
            Directory.CreateDirectory(Path.Combine(appPath, "Icon-Sets"));
            Directory.CreateDirectory(Path.Combine(appPath, "Used-Arrows"));
        }

        // Restarts Windows Explorer
        // https://superuser.com/a/1278476
        public static void RestartExplorer()
        {
            Process.Start("taskkill", "/F /IM sihost.exe");
        }

        // Copies files from one directory to another
        public static void CopyDirectory(string sourceDir, string destinationDir)
        {
            // Create the destination directory
            var directory = new DirectoryInfo(sourceDir);
            Directory.CreateDirectory(destinationDir);
            // Get the files in the source directory and copy to the destination directory
            foreach (FileInfo file in directory.GetFiles())
            {
                string targetFilePath = Path.Combine(destinationDir, file.Name);
                file.CopyTo(targetFilePath);
            }
        }

        // Backs up the files on the desktop
        public static void CreateDesktopBackups(bool printOutput)
        {
            // Create backup directory if it does not exist
            string documentPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            Directory.CreateDirectory(Path.Combine(documentPath, "DesktopIconManager", "Saved-Backups"));

            // Create dated directory for current backup
            string newPath = Path.Combine(documentPath, "DesktopIconManager", "Saved-Backups", DateTime.Now.ToString("yyyy_MM_dd__h-mm-sstt"));
            Directory.CreateDirectory(newPath);

            // Back up public desktop
            string newPublicPath = Path.Combine(newPath, "PublicDesktop");
            Directory.CreateDirectory(newPublicPath);
            Utilities.CopyDirectory(@"C:\Users\Public\Desktop", newPublicPath);

            // Back up user desktop
            string newPrivatePath = Path.Combine(newPath, "PrivateDesktop");
            Directory.CreateDirectory(newPrivatePath);
            Utilities.CopyDirectory(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), newPrivatePath);

            // Copy Current Icons
            string currentIcons = Path.Combine(documentPath, "DesktopIconManager", "Current-Icons");
            Directory.CreateDirectory(currentIcons);
            string newIconPath = Path.Combine(newPath, "CurrentIcons");
            Utilities.CopyDirectory(currentIcons, newIconPath);

            if (printOutput) // Notify user if triggered manually; other activations pass along "false" to do this silently
            {
                string message = "Saved complete desktop backups to \"" + newPath + "\".";
                string caption = "Task Completed";
                System.Windows.Forms.MessageBox.Show(message, caption);
            }
        }

        // Only backs up lnk files on the desktop
        public static void CreateLnkBackups(bool printOutput)
        {
            // Create backup directory if it does not exist
            string documentPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            Directory.CreateDirectory(Path.Combine(documentPath, "DesktopIconManager", "Saved-Backups"));

            // Create dated directory for current backup
            string newPath = Path.Combine(documentPath, "DesktopIconManager", "Saved-Backups", DateTime.Now.ToString("yyyy_MM_dd__h-mm-sstt"));
            Directory.CreateDirectory(newPath);

            // Back up public desktop
            string newPublicPath = Path.Combine(newPath, "PublicDesktop");
            Directory.CreateDirectory(newPublicPath);
            string[] lnkFilesPublic = Directory.GetFiles(@"C:\Users\Public\Desktop", "*.lnk");
            foreach (string file in lnkFilesPublic)
            {
                string fileName = Path.GetFileName(file);
                string destination = Path.Combine(newPublicPath, fileName);
                File.Copy(file, destination);
            }

            // Back up user desktop
            string newPrivatePath = Path.Combine(newPath, "PrivateDesktop");
            Directory.CreateDirectory(newPrivatePath);
            string privateDesktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string[] lnkFilesPrivate = Directory.GetFiles(privateDesktop, "*.lnk");
            foreach (string file in lnkFilesPrivate)
            {
                string fileName = Path.GetFileName(file);
                string destination = Path.Combine(newPrivatePath, fileName);
                File.Copy(file, destination);
            }

            // Copy Current Icons
            string currentIcons = Path.Combine(documentPath, "DesktopIconManager", "Current-Icons");
            Directory.CreateDirectory(currentIcons);
            string newIconPath = Path.Combine(newPath, "CurrentIcons");
            Utilities.CopyDirectory(currentIcons, newIconPath);

            if (printOutput) // Notify user if triggered manually; other activations pass along "false" to do this silently
            {
                string message = "Saved complete desktop backups to \"" + newPath + "\".";
                string caption = "Task Completed";
                System.Windows.Forms.MessageBox.Show(message, caption);
            }
        }
    }
}
