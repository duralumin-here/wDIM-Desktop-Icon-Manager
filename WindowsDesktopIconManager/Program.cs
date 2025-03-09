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


 * */
using System;
using System.ComponentModel;
using IWshRuntimeLibrary;

namespace WindowsDesktopIconManager
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("What would you like to do?\n-----\n1: Create a shortcut\n2: Validate desktop files\nOther: Leave program");
            string userInput = Console.ReadLine();
            if (int.TryParse(userInput, out int userEntry))
            {
                switch (userEntry)
                {
                    case 1:
                        CreateShortcut();
                        break;
                    case 2:
                        ValidateDesktopFiles();
                        break;
                    default:
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number.");
            }

        }

        static void CreateShortcut() // shoutout to Rustam Irzaev for the example I referenced https://stackoverflow.com/a/4909475
        {
            Console.WriteLine("Please enter the name for the shortcut.");
            string shortcutName = Console.ReadLine(); // will need to validate that it doesn't contain illegal characters
            Console.WriteLine("Please enter the description you want to have.");
            string shortcutDesc = Console.ReadLine();
            Console.WriteLine("Please enter the file path for the shortcut.");
            string shortcutPathTo = Console.ReadLine();

            object shDesktop = (object)"Desktop";
            WshShell shell = new WshShell();
            string shortcutAddress = (string)shell.SpecialFolders.Item(ref shDesktop) + @"\" + shortcutName + ".lnk";
            IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(shortcutAddress);
            shortcut.Description = shortcutDesc;
            // shortcut.Hotkey = "Ctrl+Shift+N";
            shortcut.TargetPath = shortcutPathTo;
            shortcut.Save();
        }

        static string CheckForQuotes(string checkedString) // doesn't seem needed anymore, but keeping for later formatting
        {
            int quoteCheck = checkedString.IndexOf("\"");
            while (quoteCheck != -1)
            {
                checkedString = checkedString.Remove(quoteCheck, 1);
                quoteCheck = checkedString.IndexOf("\"");
            }
            return checkedString;
        }

        static void ValidateDesktopFiles() // shoutout to https://www.csharp.com/article/directories-in-c-sharp/ for helping me learn how to do operations with files
        {
            string publicDesk = @"C:\Users\Public\Desktop";
            string userDesk = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            Boolean containsNonShortcuts = false;

            string[] publicEntries = Directory.GetFiles(publicDesk);
            string[] userEntries = Directory.GetFiles(userDesk);
            string[] notShortcuts = new string[500];
            int numNonShortcuts = 0;

            foreach (string fileName in publicEntries)
            {
                int numCheck = fileName.IndexOf(".lnk");
                if ((numCheck == -1) && (fileName.IndexOf("desktop.ini") == -1))
                {
                    containsNonShortcuts = true;
                    notShortcuts[numNonShortcuts] = fileName;
                    ++numNonShortcuts;
                }
            }
            foreach (string fileName in userEntries)
            {
                int numCheck = fileName.IndexOf(".lnk");
                if ((numCheck == -1) && (fileName.IndexOf("desktop.ini") == -1))
                {
                    containsNonShortcuts = true;
                    Console.WriteLine(fileName);
                }
            }

            if (!containsNonShortcuts)
            {
                Console.WriteLine("All desktop files are shortcuts.");
            }
        }
    }
}
