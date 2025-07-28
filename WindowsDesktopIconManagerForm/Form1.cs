using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows;
using System.Windows.Media.Media3D;
using System.Windows.Shapes;
using Path = System.IO.Path;
using Size = System.Drawing.Size;

// To do:
// TODO: Method to restore a selected backup through the app GUI
// TODO: Figure out the workflow for a user to actually set up icon sets
// TODO: Saving and loading icon sets
// TODO: Clean up the new form code with methods; add markers to delineate tabs
// Can just have a menu to copy icons from a set to current icons, or from current icons to a set
// May need a workflow for people to upload specific icons for apps so they can be renamed accordingly
// A way to change the names of shortcuts with fancy text, append symbols/emojis, or change the names to blank altogether

namespace WindowsDesktopIconManagerForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Utilities.CreateStartingDirectories();
            hueBox.Text = hueSlide.Value.ToString();
            satBox.Text = satSlide.Value.ToString();
            lightBox.Text = lightSlide.Value.ToString();
        }

        private void validateButton_Click(object sender, EventArgs e)
        {
            ForNonShortcuts.HandleNonShortcuts();
        }

        private void pathButton_Click(object sender, EventArgs e)
        {
            DesktopPrep.SetShortcutPaths();
        }

        private void backupButton_Click(object sender, EventArgs e)
        {
            Utilities.CreateLnkBackups(true); // true to output result message
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            Utilities.RefreshDesktop();
        }

        private void explorerButton_Click(object sender, EventArgs e)
        {
            Utilities.RestartExplorer();
        }

        private void restoreArrowButton_Click(object sender, EventArgs e)
        {
            Arrow.Restore();
        }

        private void hueSlide_ValueChanged(object sender, EventArgs e)
        {
            hueBox.Text = hueSlide.Value.ToString();
            try
            {
                Bitmap image = new Bitmap(arrowShowBox.BackgroundImage);
                arrowShowBox.BackgroundImage = Coloration.HueShift(image, hueSlide.Value);
            }
            catch
            {
                return;
            }
        }

        private void satSlide_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                satBox.Text = satSlide.Value.ToString();
                Bitmap image = new Bitmap(arrowShowBox.BackgroundImage);
                double sat = (double)satSlide.Value / 100;
                arrowShowBox.BackgroundImage = Coloration.SatShift(image, sat);
            }
            catch
            {
                return;
            }
        }

        private void lightSlide_ValueChanged(object sender, EventArgs e)
        {
            lightBox.Text = lightSlide.Value.ToString();
            try
            {
                Bitmap image = new Bitmap(arrowShowBox.BackgroundImage);
                float bright = (float)lightSlide.Value / 100;
                arrowShowBox.BackgroundImage = Coloration.BrightShift(image, bright);
            }
            catch
            {
                return;
            }
        }

        private void hueBox_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(hueBox.Text, out int value))
            {
                if (value >= hueSlide.Minimum && value <= hueSlide.Maximum)
                {
                    hueSlide.Value = value;
                }
            }
        }

        private void satBox_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(satBox.Text, out int value))
            {
                if (value >= satSlide.Minimum && value <= satSlide.Maximum)
                {
                    satSlide.Value = value;
                }
            }
        }

        private void lightBox_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(lightBox.Text, out int value))
            {
                if (value >= lightSlide.Minimum && value <= lightSlide.Maximum)
                {
                    lightSlide.Value = value;
                }
            }
        }

        private void resetColorButton_Click(object sender, EventArgs e)
        {
            hueSlide.Value = 0;
            satSlide.Value = 100;
            lightSlide.Value = 50;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedItem = comboBox1.SelectedItem as string;
            if (selectedItem == null)
            {
                return;
            }
            // Sets path based on combo box selection
            string iconPath = Coloration.PickArrowType(selectedItem);

            // Bitmap from the path
            Bitmap newArrowMap = Coloration.GetBitmap(iconPath);
            arrowShowBox.BackgroundImage = newArrowMap;
            arrowSaveButton.Enabled = true;

            // Reapply colors on arrow change
            try
            {
                Bitmap image = new Bitmap(arrowShowBox.BackgroundImage);
                arrowShowBox.BackgroundImage = Coloration.HueShift(image, hueSlide.Value);
                float bright = (float)lightSlide.Value / 100;
                arrowShowBox.BackgroundImage = Coloration.BrightShift(image, bright);
                double sat = (double)satSlide.Value / 100;
                arrowShowBox.BackgroundImage = Coloration.SatShift(image, sat);
            }
            catch
            {
                return;
            }
        }

        private void arrowSaveButton_Click(object sender, EventArgs e)
        {
            Bitmap arrowMap;
            try
            {
                if (arrowShowBox.BackgroundImage == null)
                {
                    throw new Exception("No image selected");
                }
                arrowMap = (Bitmap)arrowShowBox.BackgroundImage;
            }
            catch
            {
                System.Media.SystemSounds.Asterisk.Play();
                return;
            }
            Icon myIcon = Arrow.ImageToIcon(arrowMap, 128);

            string newPath = Arrow.WhereToSave(myIcon);
            if (newPath == null)
            {
                System.Windows.Forms.MessageBox.Show("The operation was cancelled. Please try again.", "Windows Desktop Icon Manager");
                return;
            }
            Arrow.SaveIcon(myIcon, newPath);
        }

        private void arrowApplyButton_Click(object sender, EventArgs e)
        {
            Arrow.ChangeArrows();
        }
    }
}