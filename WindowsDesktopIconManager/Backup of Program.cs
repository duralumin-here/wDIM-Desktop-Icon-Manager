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
using Shell32;
using System.ComponentModel;
using IWshRuntimeLibrary;
using File = System.IO.File;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Drawing;
using System.IO.Enumeration; // had to install a Nuget package for this one; apparently will not need to be named separately on the Windows form app

namespace WindowsDesktopIconManager
{
    internal class Program
    {
        // This is tweaked from https://stackoverflow.com/a/647286 to let me refresh the desktop once the icons are replaced in order to get rid of the old ones.
        [DllImport("Shell32.dll")] // Import function
        private static extern int SHChangeNotify(int eventId, int flags, IntPtr item1, IntPtr item2);
        private const uint SHCNE_ALLEVENTS = 0x80000000;
        private const uint SHCNF_FLUSH = 0x1000;

        // This method is my main.
        static void Main(string[] args)
        {
            Boolean isLooping = true;

            // Simple looping menu; will rework into a list of options in a Windows Form or other GUI later on
            do
            {
                // Create folders if they do not exist
                Directory.CreateDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "DesktopIconManager"));
                Directory.CreateDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "DesktopIconManager", "Current-Icons"));

                // Print menu
                Console.WriteLine("\nMENU\n-----");
                Console.WriteLine("\nType the word for the option you want:\n");
                Console.WriteLine("SCAN: Scan for and handle non-shortcuts\nBACKUP: Backup current desktops\nICONS: Save current icons\nQUIT: Exit the program\n");
                string userSelection = Console.ReadLine();
                switch (userSelection.ToUpper())
                {
                    case "SCAN": HandleNonShortcuts(); break;
                    case "BACKUP": CreateDesktopBackups(); break;
                    case "ICONS": CopyIcons(); break;
                    case "QUIT": isLooping = false; break;
                    default: Console.WriteLine("Invalid entry. Please try again."); break;
                }
            }
            while (isLooping);
        } // end method Main()

        // This method creates backups of the shortcuts on the public and user desktops.
        static void CreateDesktopBackups()
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
            Console.WriteLine("Created backups.");
        } // end method CreateDesktopBackups

        // This method is based on https://learn.microsoft.com/en-us/dotnet/standard/io/how-to-copy-directories and copies files from one directory into another.
        static void CopyDirectory(string sourceDir, string destinationDir)
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

        // This method checks for non-shortcuts and then prompts the user to replace them with shortcuts.
        static void HandleNonShortcuts()
        {
            // String array to hold non-shortcuts
            string[] notShortcuts = new string[500];

            // Add invalid entries to the notShortcuts array and return the count
            int invalidFileNum = ValidateDesktopFiles(notShortcuts);

            // If invalid files exist, output message, prompt to fix, and run fixer
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
            // If all files are valid, output success message
            else
            {
                Console.WriteLine("All desktop files are shortcuts.\n");
            }
        } // end method HandleNonShortcuts

        // This method runs through the desktop files and finds which, if any, are not shortcuts. https://www.csharp.com/article/directories-in-c-sharp/ helped me learn how to do operations with files.
        static int ValidateDesktopFiles(string[] notShortcuts)
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
        }  // end method ValidateDesktopFiles()

        // This method creates a shortcut for a file based on its location. I referenced this example: https://stackoverflow.com/a/4909475
        static void CreateShortcut(string itemPath)
        {

            Console.WriteLine("Please enter the path to the folder you would like to move " + itemPath + " to."); // FIXME: use FolderBrowserDialog once this is converted to a Windows Form
            string newFolder = Console.ReadLine();

            Console.WriteLine("Please enter a name for the shortcut (no extension needed; the original file name will remain unchanged):");
            string shortcutName = Console.ReadLine(); // FIXME: will need to validate that it doesn't contain illegal characters

            // Create new file path
            string ogName = itemPath.Substring((itemPath.LastIndexOf("\\") + 1));
            string newPath = newFolder + ogName;

            File.Move(itemPath, newPath); // Move it to a new location
            SHChangeNotify(0x8000000, 0x1000, IntPtr.Zero, IntPtr.Zero); // Refresh desktop to remove old icon from screen

            object shDesktop = (object)"Desktop";
            WshShell shell = new WshShell();
            string shortcutAddress = (string)shell.SpecialFolders.Item(ref shDesktop) + @"\" + shortcutName + ".lnk";
            IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(shortcutAddress);
            // shortcut.Description = shortcutDesc; <- may implement desc and hotkey later but not needed at this point
            // shortcut.Hotkey = "Ctrl+Shift+N";
            shortcut.TargetPath = newPath;
            shortcut.Save();
        } // end method CreateShortcut(location)

        // This method copys the icons of all the shortcuts on the desktop and saves them to a new folder.
        static void CopyIcons()
        {
            // Create directory if it doesn't exist yet
            Directory.CreateDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "DesktopIconManager", "Saved-Icon-Sets"));

            // Create folder for icon backup
            string outputPath = (Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "DesktopIconManager", "Saved-Icon-Sets", DateTime.Now.ToString("yyyy-MM-dd--HH-mm-ss"))); // Format output path
            Directory.CreateDirectory(outputPath);
            string[] allEntries = CreateDesktopArray(); // Array to hold entries
            foreach (string shortcut in allEntries)
            {
                string fileName = shortcut.Substring((shortcut.LastIndexOf("\\") + 1));
                string specificOutputPath = (Path.Combine(outputPath, fileName.Substring(0, (fileName.Length - 4)) + ".ico")); // this is probably not the best way to do it since it only works with files that have three-character-long extensions. I'm just trying to get the overall concept to work for now.
                SaveAssociatedIcon(shortcut, specificOutputPath);
            }
            Console.WriteLine("Icons have been saved to " + outputPath + ".");
        } // end method CopyIcons

        // This method helps the user choose an icon to associate with a file.

        public static void SaveAssociatedIcon(string lnkPath, string outputPath)
        {
            /*  - Check if icon already exists for that executable; if so ask user if they want to replace (if no then skip the rest, if yes then continue)
             *      - Give user the option to click a checkbox and automatically skip all pre-existing ones if wanted
             *  - Ask user if they already have an icon
             *      - If so, File dialog -> pick file -> confirm file -> if check fails then error message and back to picker, otherwise skip to copy / rename
             *  - Look in the folder in which the executable is placed
             *  - Search for every single icon in the folder(7Zip may be used for rsrc; recursively look for all icons everywhere and move them) and executable and transfer it to a temp folder(maybe./ temporary)
             *  - If none found then suggest user find one themselves and upload it manually(GIMP can convert)
             *  - Show the User the folder and have them pick an icon
             *  - For commandline proof of concept I frankly don't yet know what I'll do
             *  - Copy that icon file to the icons folder with the name of the program
             *  - Profit */

        } // end method SaveAssociatedIcon

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