using System.IO;
using System;
using Shell32;
using System.ComponentModel;
using IWshRuntimeLibrary;
using File = System.IO.File;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Drawing;
using Microsoft.WindowsAPICodePack.Dialogs;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;
using MS.WindowsAPICodePack.Internal;
using System.Windows.Documents;

namespace DesktopIconGUIapp
{ // https://learn.microsoft.com/en-us/dotnet/api/system.windows.forms.messagebox?view=windowsdesktop-9.0
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
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
    }
}

public class ShortcutTools
{
    static bool isChecked = false;

    // This is tweaked from https://stackoverflow.com/a/647286 to let me refresh the desktop once the icons are replaced in order to get rid of the old ones.
    [DllImport("Shell32.dll")] // Import function
    private static extern int SHChangeNotify(int eventId, int flags, IntPtr item1, IntPtr item2);
    private const uint SHCNE_ALLEVENTS = 0x80000000;
    private const uint SHCNF_FLUSH = 0x1000;

    public static void CreateDesktopBackups(bool printOutput)
    {
        Directory.CreateDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "DesktopIconManager", "Saved-Backups"));
        // Back up public desktop
        Directory.CreateDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "DesktopIconManager", "Saved-Backups", "Public-Desktop"));
        string newPublicPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "DesktopIconManager\\Saved-Backups\\Public-Desktop\\" + DateTime.Now.ToString("yyyy-MM-dd--HH-mm-ss"));
        CopyDirectory(@"C:\Users\Public\Desktop", newPublicPath);

        // Back up user desktop
        Directory.CreateDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "DesktopIconManager", "Saved-Backups", "User-Desktop"));
        string newPrivatePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "DesktopIconManager\\Saved-Backups\\User-Desktop\\" + DateTime.Now.ToString("yyyy-MM-dd--HH-mm-ss"));
        CopyDirectory(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), newPrivatePath);

        // Notify user
        if (printOutput)
        {
            System.Windows.Forms.MessageBox.Show("Saved public desktop shortcuts to: \n\"" + newPublicPath + "\"\n\n" + "Saved private desktop shortcuts to: \n\"" + newPrivatePath + "\".", "Task Completed");
        }
    }

    // This method is based on https://learn.microsoft.com/en-us/dotnet/standard/io/how-to-copy-directories and copies files from one directory into another.
    public static void CopyDirectory(string sourceDir, string destinationDir)
    {
        // Create the destination directory
        var dir = new DirectoryInfo(sourceDir);
        Directory.CreateDirectory(destinationDir);

        // Get the files in the source directory and copy to the destination directory
        foreach (FileInfo file in dir.GetFiles())
        {
            string targetFilePath = Path.Combine(destinationDir, file.Name);
            file.CopyTo(targetFilePath);
        }
    } // end method CopyDirectory

    // This method runs through the desktop files and counts which, if any, are not shortcuts. https://www.csharp.com/article/directories-in-c-sharp/ helped me learn how to do operations with files.
    static int CountNonShortcuts(string[] notShortcuts)
    {
        // Create array and number to count entries
        int numNonShortcuts = 0;
        string[] allEntries = CreateDesktopArray();

        // Iterate through desktop to find non-shortcuts
        foreach (string fileName in allEntries)
        {
            int numCheck = fileName.IndexOf(".lnk"); // Find index of the shortcut file extension
            if ((numCheck == -1) && (fileName.IndexOf("desktop.ini") == -1)) // If the shortcut extension is not present and it's not the desktop file
            {
                notShortcuts[numNonShortcuts] = fileName; // Add file to array of non-shortcuts
                ++numNonShortcuts; // Increment number of non-shortcuts to track oversized array
            }
        }
        return numNonShortcuts; // This originally returned a boolean for whether or not shortcuts were present. I realized I can find this by checking if the number of non-shortcuts > 0, and returning the length of the oversized array is important, so I'm changing it to return that instead.
    }  // end method CountNonShortcuts()
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
    } // end method CreateDesktopArray

    // This method checks for non-shortcuts and then prompts the user to replace them with shortcuts.
    public static void HandleNonShortcuts()
    {
        // String array to hold non-shortcuts
        string[] notShortcuts = new string[500];

        // Add invalid entries to the notShortcuts array and return the count
        int invalidFileNum = CountNonShortcuts(notShortcuts);

        // If invalid files exist, output message, prompt to fix, and run fixer
        if (invalidFileNum != 0)
        {

            // Create string of non-items to show user
            string invalidItems = "";
            for (int i = 0; i < invalidFileNum; ++i)
            {
                string ogName = notShortcuts[i].Substring((notShortcuts[i].LastIndexOf("\\") + 1));
                invalidItems = invalidItems + ogName + "\n";
            }

            string error = "The following files on your desktop are not shortcuts:";
            string prompt = "Would you like this app to help you move these files?";
            string extra = "(If you want to handle the files manually yourself, you should select No, move these files, and run this checker again when you're done.)";
            string message = error + "\n\n" + invalidItems + "\n" + prompt + " " + extra;
            string caption = "Invalid Entries Detected";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;

            var result = System.Windows.Forms.MessageBox.Show(message, caption, buttons, MessageBoxIcon.Warning);
            bool showWarning = false;

            if (result == DialogResult.Yes)
            {
                var result2 = System.Windows.Forms.MessageBox.Show("Would you like to select one folder to move all of the non-shortcut files to? (Select \"No\" to go through them one by one, and select \"Cancel\" to abort this operation and leave the helper instead.)", "Desktop Icon Manager", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                if (result2 == DialogResult.Cancel)
                {
                    System.Windows.Forms.MessageBox.Show("Your desktop contains non-shortcuts. This tool only changes shortcut icons, so these will remain unaffected by custom icons unless you move them off of the desktop and replace them with shortcuts to their file location(s).", "Non-Shortcuts Present", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else if (result2 == DialogResult.No)
                {
                    for (int i = 0; i < invalidFileNum; ++i)
                    {
                        int iconResult = CreateShortcutOneByOne(notShortcuts[i]);
                        if (iconResult == -1)
                        {
                            showWarning = true;
                            break;
                        }
                        if (iconResult == 0)
                        {
                            showWarning = true;
                        }
                    }
                }
                else
                {
                    int iconResult = CreateShortcutAll(notShortcuts, invalidFileNum);
                    if (iconResult == -1)
                    {
                        showWarning = true;
                    }
                }
            }
            else
            {
                showWarning = true;
            }

            if (showWarning)
            {
                System.Windows.Forms.MessageBox.Show("Your desktop contains non-shortcuts. This tool only changes shortcut icons, so these will remain unaffected by custom icons unless you move them off of the desktop and replace them with shortcuts to their file location(s).", "Non-Shortcuts Present", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("The helper is complete. If you created shortcuts, you may have to move them on your desktop back to where you expect them to be.", "Helper Complete", MessageBoxButtons.OK);
            }
            isChecked = true;
        }

        // If all files are valid, output success message
        else
        {
            System.Windows.Forms.MessageBox.Show("All desktop files are shortcuts.", "Desktop Validated");
        }
    } // end method HandleNonShortcuts



    // This method creates a shortcut for a file based on its location. I referenced this example: https://stackoverflow.com/a/4909475
    // I later referenced this https://stackoverflow.com/a/41511598 to convert it to use a GUI file dialog.
    static int CreateShortcutOneByOne(string itemPath)
    {
        int result = -2;
        MessageBoxButtons buttonsCheck = MessageBoxButtons.OKCancel;
        string ogName = itemPath.Substring((itemPath.LastIndexOf("\\") + 1));
        var resultContinue = System.Windows.Forms.MessageBox.Show("Select a folder to store " + ogName + ". (Press Cancel to quit the helper.)", "Windows Desktop Icon Manager", buttonsCheck);
        if (resultContinue == DialogResult.Cancel)
        {
            result = -1;
            return result;
        }

        // Move item and refresh desktop
        string shortcutName;
        string newPath;
        bool loopFolder = true;
        do
        {
            string newFolder = "";
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            dialog.InitialDirectory = "C:\\Users";
            dialog.IsFolderPicker = true;
            dialog.ShowDialog(); // "Select a folder to move the item to."
            try
            {
                newFolder = dialog.FileName;
                loopFolder = false;
            }
            catch (Exception e)
            {
                var folderPickFail = System.Windows.Forms.MessageBox.Show("An error occurred:\n\n" + e.Message + "\n\nWould you like to cancel the helper, try picking another file location, or continue without changing this icon?", "Folder Selection Error", MessageBoxButtons.CancelTryContinue);
                if (folderPickFail == DialogResult.Cancel)
                {
                    result = -1;
                    return result;
                }
                else if (folderPickFail == DialogResult.Continue)
                {
                    result = 0;
                    return result;
                }
            }
            while (loopFolder) ;

            // FIXME: Add text box for name and validate that it doesn't contain illegal characters
            shortcutName = ogName.Substring(0, ogName.IndexOf("."));

            // Create new file path
            newPath = Path.Combine(newFolder, ogName);

            try
            {
                File.Move(itemPath, newPath);
                result = 1;
            }
            catch (Exception e) // try to catch different exceptions at different parts but redo the whole thing each time anyway
            {
                var resultMoveFail = System.Windows.Forms.MessageBox.Show("An error occurred while trying to move the file:\n\n" + e.Message + "\n\nWould you like to cancel the helper, try picking another file location, or continue without changing this icon?", "File Move Error", MessageBoxButtons.CancelTryContinue);
                if (resultMoveFail == DialogResult.Cancel)
                {
                    result = -1;
                    return result;
                }
                else if (resultMoveFail == DialogResult.Continue)
                {
                    result = 0;
                    return result;
                }

            }
        }
        while (result != 1);

        SHChangeNotify(0x8000000, 0x1000, IntPtr.Zero, IntPtr.Zero); // Refresh desktop to remove old icon from screen FIXME: add a way to disable this since it flashes the screen

        // Ask user if they want a desktop shortcut for it; will skip if not
        var resultShcut = System.Windows.Forms.MessageBox.Show("Would you like to create a desktop shortcut for this item?", "Windows Desktop Icon Manager", MessageBoxButtons.YesNo);
        if (resultShcut == DialogResult.Yes) {
            object shDesktop = (object)"Desktop";
            WshShell shell = new WshShell();
            string shortcutAddress = (string)shell.SpecialFolders.Item(ref shDesktop) + @"\" + shortcutName + ".lnk";
            IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(shortcutAddress);
            shortcut.TargetPath = newPath;
            shortcut.Save();
        }

        result = 1;
        return result;
    } // end method CreateShortcut(location)

    static int CreateShortcutAll(string[] allItems, int invalidFileNum)
    {
        int result = -2;
        MessageBoxButtons buttonsCheck = MessageBoxButtons.OKCancel;
        var resultContinue = System.Windows.Forms.MessageBox.Show("Select a folder to store the non-shortcut files on your desktop. (Press Cancel to quit the helper.)", "Windows Desktop Icon Manager", buttonsCheck);
        if (resultContinue == DialogResult.Cancel)
        {
            result = -1;
            return result;
        }
        bool loopFolder = true;
        string newFolder = "";
        do
        {
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            dialog.InitialDirectory = "C:\\Users";
            dialog.IsFolderPicker = true;
            dialog.ShowDialog(); // "Select a folder to move the item to."
            try
            {
                newFolder = dialog.FileName;
                loopFolder = false;
            }
            catch (Exception e)
            {
                var folderPickFail = System.Windows.Forms.MessageBox.Show("An error occurred:\n\n" + e.Message + "\n\nWould you like to cancel the helper, try picking another file location, or continue without changing this icon?", "Folder Selection Error", MessageBoxButtons.CancelTryContinue);
                if (folderPickFail == DialogResult.Cancel)
                {
                    result = -1;
                    return result;
                }
                else if (folderPickFail == DialogResult.Continue)
                {
                    result = 0;
                    return result;
                }
            }
        }
        while (loopFolder);


            for (int i = 0; i < invalidFileNum; ++i)
            {
                string itemPath = allItems[i];
                string ogName = itemPath.Substring((itemPath.LastIndexOf("\\") + 1));
                string shortcutName = ogName.Substring(0, ogName.IndexOf("."));
                string newPath = Path.Combine(newFolder, ogName);
                try
                {
                    File.Move(itemPath, newPath);
                    result = 1;
                }
                catch (Exception e) // try to catch different exceptions at different parts but redo the whole thing each time anyway
                {
                    var resultMoveFail = System.Windows.Forms.MessageBox.Show("An error occurred while trying to move the file:\n\n" + e.Message + "\n\nWould you like to cancel the helper, try picking another file location, or continue without changing this icon?", "File Move Error", MessageBoxButtons.CancelTryContinue);
                    if (resultMoveFail == DialogResult.Cancel)
                    {
                        result = -1;
                        return result;
                    }
                    else if (resultMoveFail == DialogResult.Continue)
                    {
                        result = 0;
                        return result;
                    }

                }
            }
            while (result != 1);
            SHChangeNotify(0x8000000, 0x1000, IntPtr.Zero, IntPtr.Zero); // Refresh desktop to remove old icon from screen FIXME: add a way to disable this since it flashes the screen
        result = 1;
        return result;
    } // end method CreateShortcutOneByOne(array, num)

    public static void SetShortcutPaths()
    {
        MessageBoxButtons buttonsCheck = MessageBoxButtons.OKCancel;
        var resultContinue = System.Windows.Forms.MessageBox.Show("This will back up current desktop icons to a folder before reassigning the desktop shortcuts to custom paths for use with this program. Select OK to proceed.", "Confirmation", buttonsCheck, MessageBoxIcon.Warning);
        if (resultContinue == DialogResult.Cancel)
        {
            return;
        }
        CreateDesktopBackups(false);
        string[] allEntries = CreateDesktopArray();
        int invalidFileNum = CountNonShortcuts(allEntries);
        Directory.CreateDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "DesktopIconManager", "Current-Icons"));
        if (invalidFileNum != 0)
        {
            var result = System.Windows.Forms.MessageBox.Show("Your desktop contains non-shortcuts. These will not be given a custom icon path. Press OK to proceed anyway, or press Cancel and run the Validate Desktop tool for more options.", "Non-Shortcuts Detected", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (result == DialogResult.Cancel)
            {
                return;
            }
        }

        foreach (string Shortcut in allEntries)
        {
            string startFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "DesktopIconManager", "Current-Icons");
            // Change icon path of each one to a custom one; name it after the actual executable NOT the shortcut name
            // https://devblogs.microsoft.com/scripting/how-can-i-change-the-icon-for-an-existing-shortcut/
        }
    }
}




