using Microsoft.Win32;
using Microsoft.WindowsAPICodePack.Dialogs;
using System.Drawing.Imaging;
using System.IO;
using File = System.IO.File;
using Path = System.IO.Path;

namespace wDIMForm
{
    public class Arrow
    {
        // ==================== Methods directly accessed through buttons ====================
        // Allows user to select a custom shortcut arrow icon and change shortcut arrows to it

        // Apply other arrow
        public static void ChangeArrow()
        {
            string iconPath = "";
            iconPath = ChooseArrow();
            if (iconPath.Equals("")) return;

            ChangeArrowPart2(iconPath, false);
        }

        private static void ChangeArrowPart2(string iconPath, bool saved)
        {
            try
            {
                if (!saved)
                {
                    // Attempt to save bitmap to new path for backup
                    string newPath = Path.Combine(Utilities.GetAppFolder(), "Used-Arrows", DateTime.Now.ToString("yyyyMMddhhmmss") + ".ico");
                    File.Copy(iconPath, newPath, overwrite: true);
                }
                File.Copy(iconPath, Utilities.GetCurrentArrowPath(), overwrite: true);
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("Error: Could not copy arrow. Please try again.", "File Copy Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ArrowPathCheck();
        }

        public static void ChangeArrow(Bitmap arrowMap)
        {
            // Bitmap was taken from editor before being passed here
            Icon myIcon = Arrow.ImageToIcon(arrowMap, 128);
            string newPath = Path.Combine(Utilities.GetAppFolder(), "Used-Arrows", DateTime.Now.ToString("yyyyMMddhhmmss") + ".ico");
            SaveIcon(myIcon, newPath);
            ChangeArrowPart2(newPath, true);
            ArrowPathCheck();
        }

        private static void ArrowPathCheck()
        {
            if (!Properties.Settings.Default.arrowPathSet) // Attempt to edit registry if needed
            {
                ArrowPathButton();
                SuccessMessage(); // If it fails, it'll send the failure message within the method
            }

            Utilities.RefreshDesktop();
        }

        public static void ArrowPathButton()
        {
            if (!ConfirmChange())
            {
                return;
            }

            if (SetArrowPath(Utilities.GetCurrentArrowPath()))
            {
                string msg1 = "The shortcut arrow path has been initialized. Custom arrows will show after resetting Windows or Windows Explorer.";
                string msg2 = "Would you like to reset Explorer now?";
                DialogResult result = MessageBox.Show(msg1 + "\n\n" + msg2, "Arrow path set", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    Utilities.RestartExplorer();
                }
            }
        }

        // Allows user to restore original shortcut arrows
        public static void Restore()
        {
            if (!ConfirmChange()) return;
            if (RestoreArrows()) SuccessMessage(); // If it fails, it'll send the failure message within the method
        }

        // Warns user and asks if they want to proceed with arrow change
        private static bool ConfirmChange()
        {
            string regEditWarning = "This feature requires an edit to the Windows registry.";
            string disclaimer1 = "To the best of my knowledge, as of the time I created this app, this method works and is safe. However, it may not work on every computer and could break or stop working at any time.";
            string context = "Additionally, shortcuts link to other files, links, etc. Removing or changing shortcut arrows may cause confusion as to whether something is a shortcut or the file's direct location.";
            string disclaimer2 = "You assume all responsibility for any data loss or damage that may result from using this functionality.";

            var resultWarning = System.Windows.Forms.MessageBox.Show(regEditWarning + " " + disclaimer1 + " " + context + "\n\n" + disclaimer2, "Warning!", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            
            if (resultWarning == DialogResult.Cancel) return false;
            else return true;
        }

        // Gets user to select an arrow icon
        public static string ChooseArrow()
        {
            string iconPath = "";
            bool loopFolder = true;
            do
            {
                CommonOpenFileDialog dialog = new()
                {
                    InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile)
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
                System.Windows.Forms.MessageBox.Show("An error occurred trying to set the shortcut arrow path:" + e.Message + "\n\nTry re-running the application in Admin mode and see if that fixes the issue.", "Error");
                return false;
            }
            Properties.Settings.Default.arrowPathSet = true;
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
                System.Windows.Forms.MessageBox.Show("An error occurred trying to restore the shortcut arrow: " + e.Message + "\n\nTry re-running the application in Admin mode and see if that fixes the issue.", "Error");
                return false;
            }
            Properties.Settings.Default.arrowPathSet = false;
            return true;
        }

        // Notifies user that the arrow change was successful
        public static void SuccessMessage()
        {
            System.Windows.Forms.MessageBox.Show("Shortcut arrow changes have been applied. To see the change, you'll have to restart the Windows Explorer shell or restart your computer.", "Shortcut Arrows Updated");
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
                }
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show("An error occurred while trying to save the file:\n\n" + e.Message + "\n\nPlease try again.", "Windows wDIM");
            }
        }

        public static string WhereToSave(Icon myIcon)
        {
            do
            {
                CommonOpenFileDialog dialog = new()
                {
                    InitialDirectory = Utilities.GetIconSetsFolder(),
                    IsFolderPicker = true,
                    Title = "Select a location to save the shortcut arrow."
                };
                dialog.ShowDialog();
                try
                {
                    return Path.Combine(dialog.FileName, "arrow.ico");
                }
                catch (InvalidOperationException)
                { // If the dialog is closed, cancel operation
                    return null;
                }
                catch (Exception e)
                { // Prompt for retry on other errors
                    if (!WillTryAgain(e))
                    {
                        return null;
                    }
                }
            }
            while (true);
        }

        public static bool WillTryAgain (Exception e) {
            var resultFolder = System.Windows.Forms.MessageBox.Show("An error occurred:\n\n" + e.Message + "\n\nWould you like to try again?", "Windows wDIM", MessageBoxButtons.YesNo);
            if (resultFolder == DialogResult.No) return false;
            else return true;
        }

        // Changes a color in the specified manner
        // From what I've read this isn't the most efficient way to change pixels, but that hopefully won't matter for our purposes as the icons are small
        public static Bitmap ColorShift(Bitmap bm, double amountToChange, string typeOfChange)
        {
            if (typeOfChange == "h")
            {
                for (int x = 0; x < bm.Width; x++)
                {
                    for (int y = 0; y < bm.Height; y++)
                    {
                        System.Drawing.Color pixelColor = bm.GetPixel(x, y);
                        if (IsSkippedPixel(pixelColor)) continue;
                        bm.SetPixel(x, y, HsLtoRgb(amountToChange, pixelColor.GetSaturation(), pixelColor.GetBrightness(), pixelColor.A));
                    }
                }
            }
            if (typeOfChange == "s")
            {
                for (int x = 0; x < bm.Width; x++)
                {
                    for (int y = 0; y < bm.Height; y++)
                    {
                        System.Drawing.Color pixelColor = bm.GetPixel(x, y);
                        if (IsSkippedPixel(pixelColor)) continue;
                        bm.SetPixel(x, y, HsLtoRgb(pixelColor.GetHue(), (double) amountToChange / 100, pixelColor.GetBrightness(), pixelColor.A));
                    }
                }
            }
            if (typeOfChange == "l")
            {
                for (int x = 0; x < bm.Width; x++)
                {
                    for (int y = 0; y < bm.Height; y++)
                    {
                        System.Drawing.Color pixelColor = bm.GetPixel(x, y);
                        if (IsSkippedPixel(pixelColor)) continue;
                        bm.SetPixel(x, y, HsLtoRgb(pixelColor.GetHue(), pixelColor.GetSaturation(), (float) amountToChange / 100, pixelColor.A));
                    }
                }
            }
            return bm;
        }

        // Checks if a pixel is close enough to black, white, or transparent to skip
        public static bool IsSkippedPixel(Color pixelColor)
        {
            if (pixelColor.A == 0 || IsSimilarColorTo(pixelColor, System.Drawing.Color.Black) || IsSimilarColorTo(pixelColor, System.Drawing.Color.White))
            {
                return true;
            }
            else return false;
        }

        // Finds if a color is close enough to another one
        public static bool IsSimilarColorTo(System.Drawing.Color myColor, System.Drawing.Color testColor)
        {
            // Checks if red, green, and blue components are similar enough
            if (Math.Abs(myColor.R - testColor.R) < 5 && Math.Abs(myColor.G - testColor.G) < 5 && Math.Abs(myColor.B - testColor.B) < 5)
            {
                return true;
            }
            else return false;
        }

        // Produces a Color from HSL values (math based on research online)
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
        public static string GetArrowTemplatePath(string selectedItem)
        {
            string path = Path.Combine(Utilities.GetAppFolder(), "Shortcut-Arrows");
            switch (selectedItem)
            {
                case "Blank/No Arrow":
                    path = Path.Combine(path, "emptyArrow.ico");
                    break;
                case "Curved (Transparent)":
                    path = Path.Combine(path, "curvedTransparentArrow.ico");
                    break;
                case "Straight (Transparent)":
                    path = Path.Combine(path, "straightTransparentArrow.ico");
                    break;
                case "Curved (Black)":
                    path = Path.Combine(path, "curvedBlackArrow.ico");
                    break;
                case "Straight (Black)":
                    path = Path.Combine(path, "straightBlackArrow.ico");
                    break;
                case "Curved (White)":
                    path = Path.Combine(path, "curvedWhiteArrow.ico");
                    break;
                case "Straight (White)":
                    path = Path.Combine(path, "straightWhiteArrow.ico");
                    break;
                case "Heart":
                    path = Path.Combine(path, "heartArrow.ico");
                    break;
                case "Star":
                    path = Path.Combine(path, "starArrow.ico");
                    break;
                case "Custom...":
                // FEATURE add custom functionality
                default:
                    return null;
            }
            return path;
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
            catch
            {
                bm = null;
            }
            return bm;
        }
    }
}