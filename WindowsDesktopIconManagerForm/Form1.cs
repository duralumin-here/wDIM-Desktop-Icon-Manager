using IWshRuntimeLibrary;
using Microsoft.Win32;
using Microsoft.WindowsAPICodePack.Dialogs;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using File = System.IO.File;

namespace DesktopIconGUIapp
{ // https://learn.microsoft.com/en-us/dotnet/api/system.windows.forms.messagebox?view=windowsdesktop-9.0
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            string appPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "DesktopIconManager");
            Directory.CreateDirectory(Path.Combine(appPath, "Saved-Backups"));
            Directory.CreateDirectory(Path.Combine(appPath, "Current-Icons"));
            Directory.CreateDirectory(Path.Combine(appPath, "Shortcut-Arrows"));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ShortcutTools.HandleNonShortcuts();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ShortcutTools.CreateDesktopBackups(true);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ShortcutTools.SetShortcutPaths();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            ShortcutTools.SetShortcutPaths();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ShortcutTools.RefreshDesktop();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ShortcutTools.ChangeArrows();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            ShortcutTools.RestartExplorer();
        }
    }
}

// FIXME: Have the desktop backups only back up .lnk files

public class ShortcutTools
{
    // Allows me to refresh desktop to clear old icons
    // Tweaked from https://stackoverflow.com/a/647286
    [DllImport("Shell32.dll")]
    private static extern int SHChangeNotify(int eventId, int flags, IntPtr item1, IntPtr item2);
    private const uint SHCNE_ALLEVENTS = 0x80000000;
    private const uint SHCNF_FLUSH = 0x1000;

    // Backs up the shortcuts on the desktop
    public static void CreateDesktopBackups(bool printOutput)
    {
        // Create backup directory if it does not exist
        string documentPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        Directory.CreateDirectory(Path.Combine(documentPath, "DesktopIconManager", "Saved-Backups"));
        // Create dated directory for current backup
        string newPath = Path.Combine(documentPath, "DesktopIconManager", "Saved-Backups", DateTime.Now.ToString("MMMM_d_yyyy_h-mm-sstt"));
        Directory.CreateDirectory(newPath);
        // Back up public desktop
        string newPublicPath = Path.Combine(newPath, "PublicDesktop");
        Directory.CreateDirectory(newPublicPath);
        CopyDirectory(@"C:\Users\Public\Desktop", newPublicPath);
        // Back up user desktop
        string newPrivatePath = Path.Combine(newPath, "PrivateDesktop");
        Directory.CreateDirectory(newPrivatePath);
        CopyDirectory(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), newPrivatePath);
        // Copy Current Icons
        string currentIcons = Path.Combine(documentPath, "DesktopIconManager", "Current-Icons");
        Directory.CreateDirectory(currentIcons);
        string newIconPath = Path.Combine(newPath, "CurrentIcons");
        CopyDirectory(currentIcons, newIconPath);
        // Notify user if triggered manually; other activations pass along "false" to do this silently
        if (printOutput)
        {
            string message = "Saved backups to \"" + newPath + "\".";
            string caption = "Task Completed";
            System.Windows.Forms.MessageBox.Show(message, caption);
        }
    }

    // Copies files from one directory to another
    // Based on https://learn.microsoft.com/en-us/dotnet/standard/io/how-to-copy-directories
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

    // Counts how many files on desktop are not shortcuts and adds them to the array passed along
    // Referenced https://www.csharp.com/article/directories-in-c-sharp/ for basic file operations
    // TODO: Try to redo this all using a List instead of counting an imperfect array
    static int CountNonShortcuts(string[] notShortcuts)
    {
        // Create array and number to count entries
        int numNonShortcuts = 0;
        string[] allEntries = CreateDesktopArray();
        // Iterate through desktop; for each non-shortcut, add files to array and increment count
        foreach (string fileName in allEntries)
        {
            if (!fileName.Contains(".lnk") && !fileName.Contains("desktop.ini"))
            {
                notShortcuts[numNonShortcuts] = fileName;
                ++numNonShortcuts;
            }
        }
        return numNonShortcuts;
    }

    // Creates and returns a perfect array of all the files on the desktop
    static string[] CreateDesktopArray()
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

    // Calls the method to check for non-shortcuts and asks the user what to do about them
    // TODO: Try to implement List here so I can use it in the other method too
    public static void HandleNonShortcuts()
    {
        // String array to hold non-shortcuts
        string[] notShortcuts = new string[500];
        // Add invalid entries to the notShortcuts array and return the count
        int invalidFileNum = CountNonShortcuts(notShortcuts);
        // If invalid files exist, output message, prompt to fix, and run fixer
        if (invalidFileNum != 0)
        {
            // TODO: Create method that makes the message box and returns the result instead of doing it here

            // Create string of non-items to show user
            string invalidItems = "";
            for (int i = 0; i < invalidFileNum; ++i)
            {
                string ogName = notShortcuts[i].Substring((notShortcuts[i].LastIndexOf("\\") + 1));
                invalidItems = invalidItems + ogName + "\n";
            }
            // Create and display message box
            string errorNonshr = "The following files on your desktop are not shortcuts:";
            string promptNonshr = "Would you like this app to help you move these files?";
            string extraNonshr = "(If you want to handle the files manually yourself, you should select No, move these files, and run this checker again when you're done.)";
            string messageNonshr = errorNonshr + "\n\n" + invalidItems + "\n" + promptNonshr + " " + extraNonshr;
            string captionNonshr = "Invalid Entries Detected";
            var resultNonshr = System.Windows.Forms.MessageBox.Show(messageNonshr, captionNonshr, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            bool showWarning = false;
            // Proceed to helper if desired
            if (resultNonshr == DialogResult.Yes)
            {
                // Ask user if they'd like to move all non-shortcuts on the desktop to one folder
                string promptMoveAll = "Would you like to select one folder to move all of the non-shortcut files to?";
                string extraMoveAll = "(Select \"No\" to go through them one by one, and select \"Cancel\" to abort this operation and leave the helper instead.)";
                string messageMoveAll = promptMoveAll + " " + extraMoveAll;
                string captionMoveAll = "Desktop Icon Manager";
                var resultMoveAll = System.Windows.Forms.MessageBox.Show(messageMoveAll, captionMoveAll, MessageBoxButtons.YesNoCancel);
                // If user exits the helper
                if (resultMoveAll == DialogResult.Cancel)
                {
                    showWarning = true;
                }
                // If user does not want to move them all at once
                else if (resultMoveAll == DialogResult.No)
                {
                    for (int i = 0; i < invalidFileNum; ++i)
                    {
                        // Attempt to create shortcut for each file
                        int iconResult = CreateShortcutOneByOne(notShortcuts[i]);
                        // If a move fails
                        if (iconResult != 1)
                        {
                            showWarning = true;
                            // If it fails and user asks to exit, then escape loop
                            if (iconResult == -1)
                            {
                                break;
                            }
                        }
                    }
                }
                // If user decides to move them all at once
                else
                {
                    int iconResult = CreateShortcutAll(notShortcuts, invalidFileNum);
                    // If it fails, show warning (no need to break since not in loop)
                    if (iconResult == -1)
                    {
                        showWarning = true;
                    }
                }
            }
            // Warn user if there's non-shortcuts and they skip the helper
            else
            {
                showWarning = true;
            }
            // Display success message or warning message
            if (showWarning)
            {
                string promptWarning = "This tool only changes shortcut icons, but your desktop still contains non-shortcuts.";
                string extraWarning = "These will remain unaffected by custom icon sets unless you move them off of the desktop and replace them with shortcuts to their file location(s).";
                string messageWarning = promptWarning + " " + extraWarning;
                string captionWarning = "Non-Shortcuts Present";
                System.Windows.Forms.MessageBox.Show(messageWarning, captionWarning, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                string promptSuccess = "The helper is complete.";
                string extraSuccess = "If you created shortcuts, you may have to move them on your desktop back to where you expect them to be.";
                string messageSuccess = promptSuccess + " " + extraSuccess;
                string captionSuccess = "Helper Complete";
                System.Windows.Forms.MessageBox.Show(messageSuccess, captionSuccess, MessageBoxButtons.OK);
            }
        }
        // If all files are valid, output success message
        else
        {
            string promptValid = "All desktop files are shortcuts.";
            string captionValid = "Desktop Validated";
            System.Windows.Forms.MessageBox.Show(promptValid, captionValid);
        }
    }

    // Creates a shortcut on the desktop for a file given its location.
    // Returns 1 if successful, 0 if unsuccessful, and -1 if unsuccessful and user does not want to continue.
    // References https://stackoverflow.com/a/4909475 and https://stackoverflow.com/a/41511598
    static int CreateShortcutOneByOne(string itemPath)
    {
        int result = 0;
        string ogName = itemPath.Substring((itemPath.LastIndexOf("\\") + 1));
        // Get new folder from user and loop until valid (or escaped)
        bool loopFolder = true;
        string newFolder = "";
        do
        {
            // Display dialogue
            CommonOpenFileDialog dialog = new()
            {
                InitialDirectory = "C:\\Users",
                IsFolderPicker = true
            };
            dialog.Title = "Select a location to move " + ogName;
            dialog.ShowDialog();
            try
            {
                // If valid folder is found, move on
                newFolder = dialog.FileName;
                loopFolder = false;
            }
            catch (Exception e)
            {
                // If error, loop or continue (returning "1" does nothing, which will loop the helper since loopFolder is still true)
                loopFolder = true;
                result = AskToContinue(e);
                if (result != 1)
                {
                    return result;
                }
            }
        }
        while (loopFolder);
        // Find file name without extension to use as name of shortcut
        string shortcutName = ogName.Substring(0, ogName.IndexOf("."));
        // Create new file path to move file to
        string newPath = Path.Combine(newFolder, ogName);
        // Attempt to move file
        try
        {
            File.Move(itemPath, newPath);
            // Return 1 if success
            result = 1;
        }
        catch (Exception e)
        {
            result = AskToContinue(e);
            return result;
        }
        // Continue as long as user hasn't asked to stop
        while (result != 1) ;
        // Refresh desktop to remove old icon from screen
        // FIXME: add a way to disable this since it flashes the screen
        SHChangeNotify(0x8000000, 0x1000, IntPtr.Zero, IntPtr.Zero);
        // Ask user if they want a desktop shortcut for the moved file; skip if not
        string messageShcut = "Would you like to create a desktop shortcut for this item?";
        string captionShcut = "Windows Desktop Icon Manager";
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
    static int AskToContinue(Exception e)
    {
        // Construct message
        string promptMoveFail = "An error occurred while trying to move the file:\n\n" + e.Message;
        string extraMoveFail = "Would you like to cancel the helper, try picking another file location, or continue without moving the file(s)?";
        string messageMoveFail = promptMoveFail + "\n\n" + extraMoveFail;
        string captionMoveFail = "File Move Error";
        var resultMoveFail = System.Windows.Forms.MessageBox.Show(messageMoveFail, captionMoveFail, MessageBoxButtons.CancelTryContinue);
        // Defaults to continuing
        int result = 0;
        // Exits if requested
        if (resultMoveFail == DialogResult.Cancel)
        {
            result = -1;
        }
        if (resultMoveFail == DialogResult.TryAgain)
        {
            result = 1;
        }
        return result;
    }

    // Moves all non-shortcuts on the desktop to a user-selected folder
    // Returns whether it was successful
    static int CreateShortcutAll(string[] allItems, int invalidFileNum)
    {
        // Start at zero to show the default behavior should skipping and trying again instead of aborting or looping
        int result = 0;
        bool loopFolder = true;
        string newFolder = "";
        do
        {
            // Have user select a file
            CommonOpenFileDialog dialog = new()
            {
                InitialDirectory = "C:\\Users",
                IsFolderPicker = true
            };
            dialog.ShowDialog();
            try
            {
                newFolder = dialog.FileName;
                loopFolder = false;
            }
            catch (Exception e)
            {
                // Prompt for retry and proceed accordingly (0 and -1 will skip, but 1 is ignored)
                result = AskToContinue(e);
                if (result < 1)
                {
                    return result;
                }
            }
        }
        while (loopFolder);
        // Attempt to move all items        
        for (int i = 0; i < invalidFileNum; ++i)
        {
            string itemPath = allItems[i];
            string ogName = itemPath.Substring((itemPath.LastIndexOf("\\") + 1));
            string shortcutName = ogName.Substring(0, ogName.IndexOf("."));
            string newPath = Path.Combine(newFolder, ogName);
            try
            {
                File.Move(itemPath, newPath);
            }
            catch (Exception e)
            {
                // Prompt for retry and proceed accordingly (0 and -1 will skip, but 1 is ignored)
                result = AskToContinue(e);
                if (result < 1)
                {
                    return result;
                }
            }
        }
        // Refresh desktop to remove old icon from screen
        // FIXME: add a way to disable this since it flashes the screen
        SHChangeNotify(0x8000000, 0x1000, IntPtr.Zero, IntPtr.Zero);
        // Return 1 to indicate success
        result = 1;
        return result;
    }

    // WIP
    // Changes the shortcut icon paths to point to a new custom file based on the executable/file name being pointed to
    // References https://bytescout.com/blog/create-shortcuts-in-c-and-vbnet.html
    public static void SetShortcutPaths()
    {
        // Silently back up current desktop icons
        CreateDesktopBackups(false);
        // Gather current desktop entries
        string[] allEntries = CreateDesktopArray();
        int invalidFileNum = CountNonShortcuts(allEntries);
        Directory.CreateDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "DesktopIconManager", "Current-Icons"));
        // Warn user if non-shortcuts are present but allow to proceed anyway
        if (invalidFileNum != 0)
        {
            var result = System.Windows.Forms.MessageBox.Show("Your desktop contains non-shortcuts. These will not be given a custom icon path. Press OK to proceed anyway, or press Cancel and run the Validate Desktop tool for more options.", "Non-Shortcuts Detected", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (result == DialogResult.Cancel)
            {
                return;
            }
        }

        string targetPath, targetFile, targetName;

        bool error = false;
        foreach (string shortcut in allEntries)
        {
            string startFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "DesktopIconManager", "Current-Icons");
            try
            {
                targetPath = GetShortcutTarget(shortcut);
            }
            catch
            {
                targetPath = "";
                error = true;
            }
            try
            {
                targetFile = Path.GetFileName(targetPath);
            }
            catch
            {
                targetFile = "";
                error = true;
            }
            try
            {
                targetName = targetFile.Substring(0, targetFile.IndexOf("."));
            }
            catch
            {
                targetName = "";
                error = true;
            }
            try
            {
                WshShell shell = new();
                IWshShortcut shortcut2 = (IWshShortcut)shell.CreateShortcut(shortcut);
                // shortcut2.Description = "Title text here";
                // shortcut2.Hotkey = "Ctrl+Shift+N";
                // shortcut2.IconLocation = Path.Combine(startFolder, targetName) + ".ico";
                shortcut2.IconLocation = Path.Combine(startFolder, "Baba") + ".ico";
                shortcut2.TargetPath = targetPath;
                shortcut2.Save();
            }
            catch
            {
                error = true;
            }
            // Refresh desktop to update icons
            // FIXME: add a way to disable this since it flashes the screen
        }
        SHChangeNotify(0x8000000, 0x1000, IntPtr.Zero, IntPtr.Zero);
        if (error)
        {
            System.Windows.Forms.MessageBox.Show("Hopefully the paths have been set now. If some programs have had their icons cleared and others haven't, try running this program in Admin mode and trying again. If the recycle bin didn't change, you can change it [link to instructions]. There are other reasons this could have happened, stay tuned for more insight.", "Desktop Icon Manager");
        }
    }

    // Returns the target than an .lnk file points to
    // Returns the target than an .lnk file points to
    // Primary way from https://forums.overclockers.co.uk/threads/c-accessing-the-target-path-of-a-shortcut-lnk.17966879/post-13328225
    // Back-up way from https://learn.microsoft.com/en-us/dotnet/api/system.io.filesysteminfo.linktarget
    static private string GetShortcutTarget(string shortcutPath)
    {
        string target = "";
        try // Primary method
        {
            WshShell shell = new WshShell();
            IWshShortcut linkAlt = (IWshShortcut)shell.CreateShortcut(shortcutPath);

            target = linkAlt.TargetPath;
            if (target == "")
            {
                throw new Exception("Null target");
            }
        }
        catch
        {
            try // Secondary method
            {
                FileInfo fileInfo = new FileInfo(shortcutPath);
                target = fileInfo.LinkTarget;
                if (target == "" || target == null)
                {
                    throw new Exception("Null target");
                }
            }
            catch
            {
                target = "";
            }
        }
        return target;
    }

    public static void RefreshDesktop()
    {
        SHChangeNotify(0x8000000, 0x1000, IntPtr.Zero, IntPtr.Zero);
    }

    // Changes the shortcut arrow icon used on the Windows desktop.
    // General implementation https://stackoverflow.com/a/24031611
    // Specific help with shortcut arrows https://www.elevenforum.com/t/remove-shortcut-arrow-icon-in-windows-11.3814/
    public static void ChangeArrows()
    {
        string regEditWarning = "This feature uses an edit to the Windows registry in order to change or remove arrows from shortcut links on the desktop.";
        string disclaimer1 = "To the best of my knowledge, as of the time I created this app, this method works and is safe. However, it may not work on every computer and could break or stop working at any time.";
        string shortcutConfusion = "Additionally, shortcuts on the desktop link to other files, links, etc. Removing shortcut arrows may cause confusion as to whether something on the desktop is a shortcut or the file's direct location.";
        string disclaimer2 = "You assume all responsibility for any data loss or damage that may result from using this functionality.";

        var resultWarning = System.Windows.Forms.MessageBox.Show(regEditWarning + " " + disclaimer1 + " " + shortcutConfusion + "\n\n" + disclaimer2, "Warning!", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
        if (resultWarning == DialogResult.Cancel)
        {
            return;
        }


        // Do you want to set custom or restore
        // If custom,

        // Copy resource arrows to container at some point
        // open folder of icons, ideally in icon view and alphabetical order
        // Copy to current arrow
        string iconPath = "";
        string arrowDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "DesktopIconManager", "Shortcut-Arrows");
        bool loopFolder = true;
        do
        {
            CommonOpenFileDialog dialog = new()
            {
                InitialDirectory = arrowDir
            };
            dialog.Title = "Select an icon to use as the shortcut arrow.";
            dialog.ShowDialog();
            try
            {
                iconPath = dialog.FileName;
                loopFolder = false;
            }
            catch (Exception e)
            {
                var resultNonshr = System.Windows.Forms.MessageBox.Show("Error: " + e.Message + "\n\nTry again?", "Error", MessageBoxButtons.YesNo);
                if (resultNonshr == DialogResult.No)
                {
                    return;
                }
            }
        }
        while (loopFolder);

        string targetFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "DesktopIconManager", "Current-Icons", "current-arrow.ico");
        File.Copy(iconPath, targetFilePath, overwrite: true);

        string registryPath = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Shell Icons";
        try
        {
            using (RegistryKey key = Registry.LocalMachine.CreateSubKey(registryPath))
            {
                if (key != null)
                    {
                        key.SetValue("29", iconPath, RegistryValueKind.String); // This part points directly to the icon because it seems like just swapping out the files doesn't work when just resetting explorer. Icon is still copied into current icons in case I find a fix, and for the sake of the user knowing what arrow goes with what set.
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
            return;
        }
        
        // If restore,
        // Applicable code here
        System.Windows.Forms.MessageBox.Show("Shortcut arrows have been applied. To see the change, you'll have to restart the Windows Explorer shell or restart your computer.", "Shortcut Arrows Updated");
    }

    // Restarts Windows Explorer
    // https://superuser.com/a/1278476
    public static void RestartExplorer()
    {
        Process.Start("taskkill", "/F /IM sihost.exe");
        // Process.Start(@"C:\Windows\explorer.exe");
    }
}




