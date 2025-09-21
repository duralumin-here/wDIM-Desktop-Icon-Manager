using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsDesktopIconManagerForm
{
    public partial class ArrowMaker : Form
    {
        public ArrowMaker()
        {
            InitializeComponent();
        }

        private void hueSlide_ValueChanged(object sender, EventArgs e)
        {
            hueBox.Text = hueSlide.Value.ToString();
            try
            {
                Bitmap image = new Bitmap(arrowShowBox.BackgroundImage);
                arrowShowBox.BackgroundImage = Arrow.ColorShift(image, hueSlide.Value, "h");
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
                arrowShowBox.BackgroundImage = Arrow.ColorShift(image, sat, "s");
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
                arrowShowBox.BackgroundImage = Arrow.ColorShift(image, bright, "l");
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
            string iconPath = Arrow.PickArrowType(selectedItem);

            // Bitmap from the path
            // If it fails (eg bitmap is null) it will just end
            try
            {
                Bitmap newArrowMap = Arrow.GetBitmap(iconPath);
                arrowShowBox.BackgroundImage = newArrowMap;
                arrowSaveButton.Enabled = true;
            }
            catch
            {
                return;
            }

            // Reapply colors on arrow change
            try
            {
                Bitmap image = new Bitmap(arrowShowBox.BackgroundImage);
                arrowShowBox.BackgroundImage = Arrow.ColorShift(image, hueSlide.Value, "h");
                double sat = (double)satSlide.Value / 100;
                arrowShowBox.BackgroundImage = Arrow.ColorShift(image, sat, "s");
                float bright = (float)lightSlide.Value / 100;
                arrowShowBox.BackgroundImage = Arrow.ColorShift(image, bright, "l");
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
                if (arrowShowBox.BackgroundImage == null) { throw new Exception("No image selected"); }
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
                return;
            }
            Arrow.SaveIcon(myIcon, newPath);
        }
    }
}
