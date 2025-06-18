/*
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * OLD!!!!!!!!!!!!!!!!!!!
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
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

    } // end class Program
} // end namespace WindowsDesktopIconManager