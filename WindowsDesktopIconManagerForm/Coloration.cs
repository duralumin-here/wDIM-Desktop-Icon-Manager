using SystemMath = System.Math;
using System.IO;
using System.Windows.Media.Media3D;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WindowsDesktopIconManagerForm
{
    // Contains methods that deal with the Picture Box on the tab for changing the arrow.
    public class Coloration
    {
        // Shifts hue of image
        // From what I've read this isn't too efficient, but that hopefully won't matter for our purposes as the icons are small
        public static Bitmap HueShift(Bitmap bm, int hueChange)
        {
            // Iterate through each pixel
            for (int x = 0; x < bm.Width; x++)
            {
                for (int y = 0; y < bm.Height; y++)
                {
                    // Skip if white, black or transparent
                    System.Drawing.Color pixelColor = bm.GetPixel(x, y);
                    if (pixelColor.Equals(System.Drawing.Color.Black) || pixelColor.Equals(System.Drawing.Color.White) || pixelColor.A == 0)
                    {

                        continue;
                    }
                    float oldHue = pixelColor.GetHue();
                    float newHue = oldHue + hueChange;
                    System.Drawing.Color newColor = HsLtoRgb(hueChange, pixelColor.GetSaturation(), pixelColor.GetBrightness(), pixelColor.A);
                    bm.SetPixel(x, y, newColor);
                }
            }
            return bm;
        }

        // Shifts saturation
        public static Bitmap SatShift(Bitmap bm, double satChange)
        {
            for (int x = 0; x < bm.Width; x++)
            {
                for (int y = 0; y < bm.Height; y++)
                {
                    System.Drawing.Color pixelColor = bm.GetPixel(x, y);
                    // Skip if white, black or transparent
                    if (pixelColor.Equals(System.Drawing.Color.Black) || pixelColor.Equals(System.Drawing.Color.White) || pixelColor.A == 0)
                    {
                        continue;
                    }
                    else
                    {
                        System.Drawing.Color newColor = HsLtoRgb(pixelColor.GetHue(), satChange, pixelColor.GetBrightness(), pixelColor.A);
                        bm.SetPixel(x, y, newColor);
                    }
                }
            }
            return bm;
        }

        public static Bitmap BrightShift(Bitmap bm, double brightChange)
        {
            for (int x = 0; x < bm.Width; x++)
            {
                for (int y = 0; y < bm.Height; y++)
                {
                    System.Drawing.Color pixelColor = bm.GetPixel(x, y);
                    // Skip if white, black or transparent
                    if (IsSimilarColorTo(pixelColor, System.Drawing.Color.Black) || IsSimilarColorTo(pixelColor, System.Drawing.Color.White) || pixelColor.A == 0)
                    {
                        continue;
                    }
                    System.Drawing.Color newColor = HsLtoRgb(pixelColor.GetHue(), pixelColor.GetSaturation(), brightChange, pixelColor.A);
                    bm.SetPixel(x, y, newColor);
                }
            }
            return bm;
        }

        // Finds if a color is close enough to another one
        // Checks if red, green, and blue components are similar enough
        public static bool IsSimilarColorTo(System.Drawing.Color checkedColor, System.Drawing.Color target)
        {
            if (Math.Abs(checkedColor.R - target.R) < 5 && Math.Abs(checkedColor.G - target.G) < 5 && Math.Abs(checkedColor.B - target.B) < 5)
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
            int r = (int) (rgbToAdjust[0] * 255D);
            int g = (int) (rgbToAdjust[1] * 255D);
            int b = (int) (rgbToAdjust[2] * 255D);
            return System.Drawing.Color.FromArgb(alpha, r, g, b);         
        }

        // Sets the appropriate icon path based on the choice in the box
        public static string PickArrowType(string selectedItem)
        {
            string iconPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "DesktopIconManager", "Shortcut-Arrows");
            switch (selectedItem)
            {
                case "Blank/No Arrow":
                    iconPath = Path.Combine(iconPath, "empty.ico");
                    break;
                case "Transparent (Curved)":
                    iconPath = Path.Combine(iconPath, "transparent-arrow-curved.ico");
                    break;
                case "Transparent (Straight)":
                    iconPath = Path.Combine(iconPath, "transparent-arrow.ico");
                    break;
                case "Filled Black (Curved)":
                    iconPath = Path.Combine(iconPath, "filled-arrow-black.ico");
                    break;
                case "Filled Black (Straight)":
                    iconPath = Path.Combine(iconPath, "filled-arrow-black-straight.ico");
                    break;
                case "Filled White (Curved)":
                    iconPath = Path.Combine(iconPath, "filled-arrow-white.ico");
                    break;
                case "Filled White (Straight)":
                    iconPath = Path.Combine(iconPath, "filled-arrow-white-straight.ico");
                    break;
                case "Custom...":
                // TODO: add functionality
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
