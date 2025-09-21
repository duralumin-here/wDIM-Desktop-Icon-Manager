using Microsoft.Win32;
using Microsoft.WindowsAPICodePack.Dialogs;
using System.IO;
using File = System.IO.File;
using Path = System.IO.Path;
using System.Drawing.Imaging;

namespace WindowsDesktopIconManagerForm
{
    public class Arrow
    {
        // ==================== Methods directly accessed through buttons ====================
        // Allows user to select a custom shortcut arrow icon and change shortcut arrows to it

        public static void ChangeArrows()
        {
            if (!ConfirmChange()) return;

            string appPath = Utilities.GetAppFolder();
            string iconPath = "";

            if (!UseIncluded())
            {
                iconPath = ChooseArrow();
                if (iconPath.Equals("")) return;
            }
            else iconPath = Utilities.GetCurrentArrowPath();

                // TODO: Maybe ask user if they want to save the arrow to the current set if it wasn't already taken from it
                string newPath = Path.Combine(appPath, "Used-Arrows", DateTime.Now.ToString("yyyyMMddhhmmss") + ".ico");

            try {File.Copy(iconPath, newPath, overwrite: true);}
            catch
            {
                System.Windows.Forms.MessageBox.Show("Error: Could not copy arrow to Current-Arrow folder. Please try again.", "File Copy Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (SetArrowPath(newPath)) SuccessMessage(); // If it fails, it'll send the failure message within the method
        }

        // Allows user to restore original shortcut arrows
        public static void Restore()
        {
            if (ConfirmRestore() == false) return;
            if (RestoreArrows()) SuccessMessage(); // If it fails, it'll send the failure message within the method
        }

        // ==================== Methods used within these methods ====================

        // Warns user and asks if they want to proceed with arrow change
        public static bool ConfirmChange()
        {
            string regEditWarning = "This feature uses an edit to the Windows registry in order to change or remove arrows from shortcut links on the desktop.";
            string disclaimer1 = "To the best of my knowledge, as of the time I created this app, this method works and is safe. However, it may not work on every computer and could break or stop working at any time.";
            string context = "Additionally, shortcuts on the desktop link to other files, links, etc. Removing shortcut arrows may cause confusion as to whether something on the desktop is a shortcut or the file's direct location.";
            string disclaimer2 = "You assume all responsibility for any data loss or damage that may result from using this functionality.";

            var resultWarning = System.Windows.Forms.MessageBox.Show(regEditWarning + " " + disclaimer1 + " " + context + "\n\n" + disclaimer2, "Warning!", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            
            if (resultWarning == DialogResult.Cancel) return false;
            else return true;
        }

        // Warns user and asks if they want to proceed with arrow restore
        public static bool ConfirmRestore()
        {
            string regEditWarning = "This feature uses an edit to the Windows registry in order to restore arrows to shortcut links on the desktop.";
            string disclaimer1 = "To the best of my knowledge, as of the time I created this app, this method works and is safe. However, it may not work on every computer and could break or stop working at any time.";
            string context = "If you've never made any changes to the Windows shortcut arrows, there's no need to use this feature.";
            string disclaimer2 = "You assume all responsibility for any data loss or damage that may result from using this functionality.";
            var resultWarning = System.Windows.Forms.MessageBox.Show(regEditWarning + " " + disclaimer1 + " " + context + "\n\n" + disclaimer2, "Warning!", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

            if (resultWarning == DialogResult.Cancel) return false;
            else return true;
        }

        // Returns bool for if arrow exists and user wants to use it
        public static bool UseIncluded()
        {
            if (CheckIncluded())
            {
                string message = "A \"arrow.ico\" file has been detected in the current icon set. Would you like to skip the file picker and just apply it automatically?";
                string title = "Arrow Detected";
                var resultWarning = System.Windows.Forms.MessageBox.Show(message, title, MessageBoxButtons.YesNo);

                if (resultWarning == DialogResult.Yes) return true;
            }
            return false;
        }

        // Checks if there is a "arrow" icon in the icon set
        public static bool CheckIncluded()
        {
            string checkedPath = Utilities.GetCurrentArrowPath();
            if (File.Exists(checkedPath)) return true;
            else return false;
        }

        // Gets user to select an arrow icon
        public static string ChooseArrow()
        {
            string iconPath = "";
            string arrowDir = Path.Combine(Utilities.GetAppFolder(), "Shortcut-Arrows");
            bool loopFolder = true;
            do
            {
                CommonOpenFileDialog dialog = new()
                {
                    InitialDirectory = arrowDir
                };
                dialog.Title = "Select an icon to use as the shortcut arrow. (Only .ico files can be used.)";
                dialog.Filters.Add(new CommonFileDialogFilter("Icon Files", "*.ico"));
                dialog.ShowDialog();
                try
                {
                    iconPath = dialog.FileName;
                    loopFolder = false;
                }
                catch (Exception e)
                {
                    var resultNonshr = System.Windows.Forms.MessageBox.Show("Error: " + e.Message + "\n\nWould you like to try again?", "Error", MessageBoxButtons.YesNo);
                    if (resultNonshr == DialogResult.No)
                    {
                        return "";
                    }
                }
            }
            while (loopFolder);
            return iconPath;
        }

        // Sets a registry key to set shortcut arrow path to whatever is provided
        public static bool SetArrowPath(string iconPath)
        {
            string registryPath = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Shell Icons";
            try
            {
                using (RegistryKey key = Registry.LocalMachine.CreateSubKey(registryPath))
                {
                    if (key != null)
                    {
                        key.SetValue("29", iconPath, RegistryValueKind.String);
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
                return false;
            }
            return true;
        }

        // Restores shortcut arrows to defaults by removing registry edit
        public static bool RestoreArrows()
        {
            string registryPath = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Shell Icons";
            try
            {
                using (RegistryKey key = Registry.LocalMachine.OpenSubKey(registryPath, writable: true))
                {
                    if (key != null)
                    {
                        key.DeleteValue("29", throwOnMissingValue: false); // If there already isn't a custom arrow set, nothing will happen
                    }
                    else
                    {
                        throw new Exception("Null registry key.");
                    }
                }
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show("An error occurred: " + e.Message + "\n\nTry re-running the application in Admin mode and see if that fixes the issue.", "Error");
                return false;
            }
            return true;
        }

        // Notifies user that the arrow change was successful
        public static void SuccessMessage()
        {
            System.Windows.Forms.MessageBox.Show("Shortcut arrow changes have been applied. To see the change, you'll have to restart the Windows Explorer shell or restart your computer.", "Shortcut Arrows Updated");
        }

        // Attempts to save the new shortcut arrow to the current icon folder
        public static void SaveNewArrow(string iconPath)
        {
            try
            {
                string targetFilePath = Utilities.GetCurrentArrowPath();
                File.Copy(iconPath, targetFilePath, overwrite: true);
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("Note: Could not copy arrow to current icon folder for back-up. Functionality shouldn't be affected as long as the registry edit succeeds.", "Notice");

            }
        }

        // Feeds an image into a newly created icon file
        public static Icon ImageToIcon(Image img, byte size)
        {
            Icon myIcon;
            
            using (MemoryStream imageStream = new MemoryStream()) // Hold picture data
            using (MemoryStream iconStream = new MemoryStream()) // Hold icon data
            {
                
                img.Save(imageStream, ImageFormat.Png); // Put the picture into the stream to write it to the icon
                
                using (BinaryWriter writer = new BinaryWriter(iconStream)) // Write the information directly into the icon stream to save it later
                {
                    // Lots of info on the icon format can be found in its Wikipedia page and Microsoft's materials
                    // Each value is a set of two numbers (two bytes make a "short") but I like having it written out in bytes

                    // Indicates it's icon format, an icon (not cursor), and number of images (0,1,1)
                    byte[] iconNums = new byte[] { 0, 0, 1, 0, 1, 0 };
                    writer.Write(iconNums, 0, iconNums.Length);
                    // Width and height
                    byte[] dimensions = new byte[] { size, size };
                    writer.Write(dimensions, 0, dimensions.Length);
                    // Num of colors (largely unused), reserved, color planes, pixel bits
                    byte[] moreIconNums = new byte[] { 3, 0, 0, 0, 32, 0 };
                    writer.Write(moreIconNums, 0, moreIconNums.Length);
                    // Image length and offset
                    writer.Write((int)imageStream.Length);
                    writer.Write(22);
                    // The image itself
                    writer.Write(imageStream.ToArray());
                    // Go back to data start to save icon
                    writer.Flush();
                    writer.Seek(0, SeekOrigin.Begin);
                    myIcon = new Icon(iconStream);
                }
            }
            return myIcon;
        }

        // Saves a given icon to the specified path
        public static void SaveIcon(Icon myIcon, string savePath)
        {
            try
            {
                using (FileStream stream = new FileStream(savePath, FileMode.Create, FileAccess.Write))
                {
                    myIcon.Save(stream);
                    System.Windows.Forms.MessageBox.Show("Icon saved.", "Windows Desktop Icon Manager");
                }
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show("An error occurred while trying to save the file:\n\n" + e.Message + "\n\nPlease try again.", "Windows Desktop Icon Manager");
            }
        }

        public static string WhereToSave(Icon myIcon)
        {
            string path = "";

            if (BoolSaveArrowToCurrent())
            {
                path = Utilities.GetCurrentArrowPath();
            }
            else
            {
                bool loopFolder = true;

                do
                {
                    CommonOpenFileDialog dialog = new()
                    {
                        InitialDirectory = "C:\\Users",
                        IsFolderPicker = true,
                        Title = "Select a location to save the shortcut arrow."
                    };
                    dialog.ShowDialog();
                    try
                    {
                        path = dialog.FileName;
                        loopFolder = false;
                    }
                    catch (InvalidOperationException e) {return null;} // if the dialog is closed, cancel operation
                    catch (Exception e) {if (!BoolPickAnotherArrowFolder(e)) return null;} // Otherwise, prompt for retry
                }
                while (loopFolder);
                path = Path.Combine(path, "arrow.ico");
            }
            return path;
        }

        public static bool BoolSaveArrowToCurrent()
        {
            var resultWarning = System.Windows.Forms.MessageBox.Show("Would you like to save the arrow to the current icon set? The current arrow will be overwritten.\n\nPress No to select a different folder to save it to.", "Windows Desktop Icon Manager", MessageBoxButtons.YesNo);
            if (resultWarning == DialogResult.Yes) return true;
            else return false;
        }

        public static bool BoolPickAnotherArrowFolder (Exception e) {
            var resultFolder = System.Windows.Forms.MessageBox.Show("An error occurred:\n\n" + e.Message + "\n\nWould you like to try again?", "Windows Desktop Icon Manager", MessageBoxButtons.YesNo);
            if (resultFolder == DialogResult.No) return false;
            else return true;
        }

        // Changes a color in the specified manner
        // From what I've read this isn't the most efficient way to change pixels, but that hopefully won't matter for our purposes as the icons are small
        public static Bitmap ColorShift(Bitmap bm, double amountToChange, string typeOfChange)
        {
            for (int x = 0; x < bm.Width; x++)
            {
                for (int y = 0; y < bm.Height; y++)
                {
                    System.Drawing.Color pixelColor = bm.GetPixel(x, y);
                    if (IsSkippedPixel(pixelColor))
                    {
                        continue;
                    }

                    // Used to be three separate methods, then I realized combining them made way more sense
                    if (typeOfChange == "h")
                    {
                        bm.SetPixel(x, y, HsLtoRgb(amountToChange, pixelColor.GetSaturation(), pixelColor.GetBrightness(), pixelColor.A));
                        continue; // no need to go through the next checks
                    }
                    if (typeOfChange == "s")
                    {
                        bm.SetPixel(x, y, HsLtoRgb(pixelColor.GetHue(), amountToChange, pixelColor.GetBrightness(), pixelColor.A));
                        continue; // again, no need to waste time on the next check
                    }
                    if (typeOfChange == "l")
                    {
                        bm.SetPixel(x, y, HsLtoRgb(pixelColor.GetHue(), pixelColor.GetSaturation(), amountToChange, pixelColor.A));
                    }
                    // Image will remain unchanged if the parameter isn't right
                }
            }
            return bm;
        }

        // Checks if a pixel is close enough to black, white, or transparent to skip
        public static bool IsSkippedPixel(Color pixelColor)
        {
            if (IsSimilarColorTo(pixelColor, System.Drawing.Color.Black) || IsSimilarColorTo(pixelColor, System.Drawing.Color.White) || pixelColor.A == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // Finds if a color is close enough to another one
        // Checks if red, green, and blue components are similar enough
        public static bool IsSimilarColorTo(System.Drawing.Color myColor, System.Drawing.Color testColor)
        {
            if (Math.Abs(myColor.R - testColor.R) < 5 && Math.Abs(myColor.G - testColor.G) < 5 && Math.Abs(myColor.B - testColor.B) < 5)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // Produces a Color from HSL values
        public static System.Drawing.Color HsLtoRgb(double hue, double sat, double light, int alpha)
        {
            double maxRGBcomponent;
            if (light < 0.5D)
            {
                maxRGBcomponent = light * (1D + sat);
            }
            else
            {
                maxRGBcomponent = (light + sat) - (light * sat);
            }

            double minRGBcomponent;
            minRGBcomponent = (2D * light) - maxRGBcomponent;

            double adjustedHue = hue / 360D;
            double[] rgbToAdjust = [adjustedHue + (1D / 3D), adjustedHue, adjustedHue - (1D / 3D)]; // R,G,B

            // Adjust each part of the color
            for (int i = 0; i < 3; i++)
            {
                // Get number between 0 and 1 if it isn't already
                if (rgbToAdjust[i] < 0D)
                {
                    rgbToAdjust[i] += 1D;
                }
                else if (rgbToAdjust[i] > 1D)
                {
                    rgbToAdjust[i] -= 1D;
                }

                // Adjust based on each other
                if ((rgbToAdjust[i] * 6D) < 1D)
                {
                    rgbToAdjust[i] = minRGBcomponent + ((maxRGBcomponent - minRGBcomponent) * 6D * rgbToAdjust[i]);
                }
                else if ((rgbToAdjust[i] * 2D) < 1)
                {
                    rgbToAdjust[i] = maxRGBcomponent;
                }
                else if ((rgbToAdjust[i] * 3D) < 2)
                {
                    rgbToAdjust[i] = minRGBcomponent + ((maxRGBcomponent - minRGBcomponent) * ((2D / 3D) - rgbToAdjust[i]) * 6D);
                }
                else
                {
                    rgbToAdjust[i] = minRGBcomponent;
                }
            }

            // Multiply values by 255 and create a color out of them
            int r = (int)(rgbToAdjust[0] * 255D);
            int g = (int)(rgbToAdjust[1] * 255D);
            int b = (int)(rgbToAdjust[2] * 255D);
            return System.Drawing.Color.FromArgb(alpha, r, g, b);
        }

        // Sets the appropriate icon path based on the choice in the box
        public static string PickArrowType(string selectedItem)
        {
            string iconPath = Path.Combine(Utilities.GetAppFolder(), "Shortcut-Arrows");
            switch (selectedItem)
            {
                case "Blank/No Arrow":
                    iconPath = Path.Combine(iconPath, "empty.ico");
                    break;
                case "Curved (Transparent)":
                    iconPath = Path.Combine(iconPath, "transparent-arrow-curved.ico");
                    break;
                case "Straight (Transparent)":
                    iconPath = Path.Combine(iconPath, "transparent-arrow.ico");
                    break;
                case "Curved (Black)":
                    iconPath = Path.Combine(iconPath, "filled-arrow-black.ico");
                    break;
                case "Straight (Black)":
                    iconPath = Path.Combine(iconPath, "filled-arrow-black-straight.ico");
                    break;
                case "Curved (White)":
                    iconPath = Path.Combine(iconPath, "filled-arrow-white.ico");
                    break;
                case "Straight (White)":
                    iconPath = Path.Combine(iconPath, "filled-arrow-white-straight.ico");
                    break;
                case "Custom...":
                // TODO: add custom functionality
                default:
                    return null;
            }
            return iconPath;
        }

        // Gets the bitmap for an icon path
        public static Bitmap GetBitmap(string iconPath)
        {
            Bitmap bm;
            try
            {
                bm = new Icon(iconPath, 48, 48).ToBitmap();
            }
            catch (ArgumentOutOfRangeException)
            {
                bm = Bitmap.FromHicon(new Icon(iconPath, new Size(48, 48)).Handle);
            }
            return bm;
        }
    }
}