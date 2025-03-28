/*
 * - Check that the only things in the desktop folders are shortcuts
 *  - If not, offer to create shortcut and move original files (if many, make folder to them on desktop?)
 *  - If anything is in the public desktop folder, warn that icons will be changed if other users use the computer
 * - Create backup public and user desktop folders within documents
 * - Extract icons from pub and user desks and put into default icons folder
 * - Copy default icons to in-use icon folder
 * - Edit all desk shortcuts to point to in-use icon folder
 * - Can create icon sets (new folders) and upload icons to match installed shortcuts
 * - Can edit folders manually, but GUI might be easier for people
 * - Can import folders of icons; not in-use ones will be ignored, and default path names means that running the "update icon paths" command could update automatically
 * - Winaerotweaker registry arrow edit (default, alts, remove, upload)
 * - Customize names (blanks, fancy fonts, append symbols, etc)
 * - Easy color changer for monochrome/duochrome icons (GIMP?)

Possible quirks:
- Run as admin (is that added to exe?)

Possible features:
- Right click on desktop to change themes
- Converter to properly size and convert images (may give user option to crop or stretch)
- Ways to automatically color icons (or pixel editor or open in paint to DIY)
- Perhaps include a converter and editor for taking images and making them
- Default icons, maybe
- Maybe a way for shortcuts created on the desktop to automatically have their logo change
	- Based on file extension?
	- Color filter/monochrome?

- Location intriguing, but beyond current scope
    - Ways to arrange icons in predetermined styles
*/
using System;
using System.ComponentModel;
using IWshRuntimeLibrary;
using File = System.IO.File;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Drawing; // had to install a Nuget package for this one; apparently will not need to be named separately on the Windows form app

namespace WindowsDesktopIconManager
{
    internal class Program
    {
        // This is tweaked from https://stackoverflow.com/a/647286 to let me refresh the desktop once the icons are replaced in order to get rid of the old ones.
        [DllImport("Shell32.dll")] // Import function
        private static extern int SHChangeNotify(int eventId, int flags, IntPtr item1, IntPtr item2);
        private const uint SHCNE_ALLEVENTS = 0x80000000; // Set constants
        private const uint SHCNF_FLUSH = 0x1000;

        // This method is my main.
        static void Main(string[] args)
        {
            Boolean isLooping = true;

            // Simple looping menu; will rework into a list of options in a Windows Form later on
            do
            {
                Console.WriteLine("\nMENU\n-----");
                Console.WriteLine("\nType the word for the option you want:\n");
                Console.WriteLine("SCAN: Scan for and handle non-shortcuts\nFOLDERS: Create directories needed for program to run\nBACKUP: Backup current desktops\nICONS: Save current icons\nQUIT: Exit the program\n");
                string userSelection = Console.ReadLine();
                switch (userSelection.ToUpper())
                {
                    case "SCAN": HandleNonShortcuts(); break;
                    case "FOLDERS": CreateProgramFolders(); break;
                    case "BACKUP": CreateDesktopBackups(); break;
                    case "ICONS": CopyIcons(); break;
                    case "QUIT": isLooping = false; break;
                    default: Console.WriteLine("Invalid entry. Please try again."); break;
                }
            }
            while (isLooping);
        } // end method Main()

        // This method creates the folders this program needs if they do not exist.
        static void CreateProgramFolders()
        {
            // Create folders
            Directory.CreateDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "DesktopIconManager"));
            Directory.CreateDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "DesktopIconManager", "Current-Icons"));
            Directory.CreateDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "DesktopIconManager", "More-Icons"));
            Directory.CreateDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "DesktopIconManager", "Saved-Backups"));

            Directory.CreateDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "DesktopIconManager", "Saved-Backups", "Public-Desktop"));
            Directory.CreateDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "DesktopIconManager", "Saved-Backups", "User-Desktop"));
            Directory.CreateDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "DesktopIconManager", "Internal", "Scripts"));

            Console.WriteLine("Created new folders.");
        } // end method CreateProgramFolders

        // This method creates backups of the shortcuts on the public and user desktops.
        static void CreateDesktopBackups()
        {
            // Back up public desktop
            CopyDirectory(@"C:\Users\Public\Desktop", Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "DesktopIconManager\\Saved-Backups\\Public-Desktop\\" + DateTime.Now.ToString("yyyy-MM-dd--HH-mm-ss")));
            // Back up user desktop
            CopyDirectory(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "DesktopIconManager\\Saved-Backups\\User-Desktop\\" + DateTime.Now.ToString("yyyy-MM-dd--HH-mm-ss")));
        } // end method CreateDesktopBackups

                // This method is based on https://learn.microsoft.com/en-us/dotnet/standard/io/how-to-copy-directories and copies files from one directory into another.
                static void CopyDirectory(string sourceDir, string destinationDir)
                {
                    // Get information about the source directory
                    var dir = new DirectoryInfo(sourceDir);

                    // Check if the source directory exists
                    if (!dir.Exists)
                        throw new DirectoryNotFoundException($"Source directory not found: {dir.FullName}");

                    // Cache directories before we start copying
                    DirectoryInfo[] dirs = dir.GetDirectories();

                    // Create the destination directory
                    Directory.CreateDirectory(destinationDir);

                    // Get the files in the source directory and copy to the destination directory
                    foreach (FileInfo file in dir.GetFiles())
                    {
                        string targetFilePath = Path.Combine(destinationDir, file.Name);
                        file.CopyTo(targetFilePath);
                    }
                } // end method CopyDirectory

        // This method checks for non-shortcuts and then prompts the user to replace them with shortcuts.
        static void HandleNonShortcuts()
        {
            // String array to hold non-shortcuts
            string[] notShortcuts = new string[500];

            // Add invalid entries to the notShortcuts array and return the count
            int invalidFileNum = ValidateDesktopFiles(notShortcuts);

            if (invalidFileNum != 0)
            {
                Console.WriteLine("The following files on your desktop are not shortcuts. Please follow the prompts to fix this.\n");
                for (int i = 0; i < invalidFileNum; ++i)
                {
                    Console.WriteLine(notShortcuts[i]);
                }
                Console.WriteLine("");
                for (int i = 0; i < invalidFileNum; ++i)
                {
                    CreateShortcut(notShortcuts[i]);
                    Console.WriteLine("");
                }
            }
            else
            {
                Console.WriteLine("All desktop files are shortcuts.\n");
            }
        } // end method HandleNonShortcuts

                // This method runs through the desktop files and finds which, if any, are not shortcuts. https://www.csharp.com/article/directories-in-c-sharp/ helped me learn how to do operations with files.
                static int ValidateDesktopFiles(string[] notShortcuts)
                {
                    int numNonShortcuts = 0; // Creating it here; importing from Main doesn't help as that creates a copy of the variable and doesn't update the original address
                    string[] allEntries = CreateDesktopArray();

                    // Iterate through desktop to find non-shortcuts
                    foreach (string fileName in allEntries)
                    {
                        int numCheck = fileName.IndexOf(".lnk"); // Find index of the shortcut file extension
                        if ((numCheck == -1) && (fileName.IndexOf("desktop.ini") == -1)) // If the shortcut extension is not present and it's not desktop.lnk
                        {
                            notShortcuts[numNonShortcuts] = fileName; // Add file to array of non-shortcuts
                            ++numNonShortcuts; // Increment number of non-shortcuts to track oversized array
                        }
                    }
                    return numNonShortcuts; // This originally returned a boolean for whether or not shortcuts were present. I realized I can find this by checking if the number of non-shortcuts > 0, and returning the length of the oversized array is important, so I'm changing it to return that instead.
                }  // end method ValidateDesktopFiles()

                // This method creates a shortcut for a file based on its location. I referenced this example: https://stackoverflow.com/a/4909475
                static void CreateShortcut(string itemPath)
                {
                    Console.WriteLine("Please enter the path to the folder you would like to move " + itemPath + " to."); // FIXME: use FolderBrowserDialog once this is converted to a Windows Form
                    string newFolder = Console.ReadLine();

                    Console.WriteLine("Please enter a name for the shortcut (no extension needed; the original file name will remain unchanged):");
                    string shortcutName = Console.ReadLine(); // FIXME: will need to validate that it doesn't contain illegal characters

                    string ogName = itemPath.Substring((itemPath.LastIndexOf("\\") + 1));
                    string newPath = newFolder + ogName;

                    File.Move(itemPath, newPath); // Move it to a new location
                    SHChangeNotify(0x8000000, 0x1000, IntPtr.Zero, IntPtr.Zero); // Refresh desktop to remove old icon from screen

                    object shDesktop = (object)"Desktop";
                    WshShell shell = new WshShell();
                    string shortcutAddress = (string)shell.SpecialFolders.Item(ref shDesktop) + @"\" + shortcutName + ".lnk";
                    IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(shortcutAddress);
                    // shortcut.Description = shortcutDesc;
                    // shortcut.Hotkey = "Ctrl+Shift+N";
                    shortcut.TargetPath = newPath;
                    shortcut.Save();
                } // end method CreateShortcut(location)
        
        // This method copys the icons of all the shortcuts on the desktop and saves them to a new folder.
        static void CopyIcons()
        {
            Directory.CreateDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "DesktopIconManager", "More-Icons")); // only will be created if it doesn't exist yet
            string[] allEntries = CreateDesktopArray();
            string outputPath = (Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "DesktopIconManager", "More-Icons", DateTime.Now.ToString("yyyy-MM-dd--HH-mm-ss")));
            foreach (string shortcut in allEntries)
            {
                string fileName = shortcut.Substring((shortcut.LastIndexOf("\\") + 1));
                string specificOutputPath = (Path.Combine(outputPath, fileName.Substring(0, (fileName.Length - 4)) + ".ico")); // this is probably not the best way to do it since it only works with files that have three-character-long extensions. I'm just trying to get the overall concept to work for now.
                SaveAssociatedIcon(shortcut, specificOutputPath);
            }
            Console.WriteLine("Icons have been saved to " + outputPath + ".");
        } // end method CopyIcons

            // This method is based off of https://learn.microsoft.com/en-us/dotnet/api/system.drawing.icon.extractassociatedicon to save the icon associated with a file.
            static void SaveAssociatedIcon(string shortcutPath, string outputPath)
            {
                Icon ico = Icon.ExtractAssociatedIcon(shortcutPath);
                using (Bitmap bitmap = ico.ToBitmap())
                {
                        string directoryPath = Path.GetDirectoryName(outputPath);
                        Directory.CreateDirectory(directoryPath);
                        bitmap.Save(outputPath);
                }
            }

        // This creates a combined array of icons on both desktops.
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
        } // end method CreateDesktopArrays
    } // end class Program
} // end namespace WindowsDesktopIconManager