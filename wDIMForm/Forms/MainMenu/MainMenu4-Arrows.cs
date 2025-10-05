using System.Windows.Forms;

namespace wDIMForm
{
    public partial class MainMenu : Form
    {
        // Hue, saturation, and lightness sliders/trackbars
        private void hueSlide_ValueChanged(object sender, EventArgs e) {ColorSlider(hueBox, hueSlide);}
        private void satSlide_ValueChanged(object sender, EventArgs e) {ColorSlider(satBox, satSlide);}
        private void lightSlide_ValueChanged(object sender, EventArgs e) {ColorSlider(lightBox, lightSlide);}

        // Method to set box text to slider value and updates arrow image
        private void ColorSlider(TextBox box, TrackBar bar)
        {
            box.Text = bar.Value.ToString();
            try
            {
                Bitmap image = new Bitmap(arrowShowBox.BackgroundImage);
                // The box is either hueBox, satBox, or lightBox, so the first character gives the needed "h", "s", or "l"
                arrowShowBox.BackgroundImage = Arrow.ColorShift(image, bar.Value, box.Name.Substring(0, 1));
            }
            catch
            {
                return;
            }
        }

        // Hue, saturation, and lightness text boxes
        private void hueBox_TextChanged(object sender, EventArgs e) {TextboxToTrackbar(hueBox, hueSlide);}
        private void satBox_TextChanged(object sender, EventArgs e) {TextboxToTrackbar(satBox, satSlide);}
        private void lightBox_TextChanged(object sender, EventArgs e) {TextboxToTrackbar(lightBox, lightSlide);}

        // Method to set bar value to box value if it's an integer and within range; otherwise do nothing
        private void TextboxToTrackbar(TextBox box, TrackBar bar)
        {
            if (int.TryParse(box.Text, out int value))
            {
                if (value >= bar.Minimum && value <= bar.Maximum)
                {
                    bar.Value = value;
                }
            }
        }

        // "Select an arrow style:" ComboBox
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                // Apply new arrow
                string selectedItem = comboBox1.SelectedItem as string;
                arrowShowBox.BackgroundImage = Arrow.GetBitmap(Arrow.GetArrowTemplatePath(selectedItem));
                // Enable buttons if not enabled
                arrowSaveButton.Enabled = true;
                ArrowApplyMainMenuButton.Enabled = true;
                // Reapply colors
                Bitmap image = new Bitmap(arrowShowBox.BackgroundImage);
                arrowShowBox.BackgroundImage = Arrow.ColorShift(image, hueSlide.Value, "h");
                arrowShowBox.BackgroundImage = Arrow.ColorShift(image, satSlide.Value, "s");
                arrowShowBox.BackgroundImage = Arrow.ColorShift(image, lightSlide.Value, "l");
            }
            catch
            {
                return; // If any part fails (eg bitmap is null) it will just end
            }
        }

        // "Reset Editor" button
        private void resetColorButton_Click(object sender, EventArgs e)
        {
            hueSlide.Value = 0;
            satSlide.Value = 100;
            lightSlide.Value = 50;

            try
            {
                arrowShowBox.BackgroundImage = Arrow.GetBitmap(Arrow.GetArrowTemplatePath(comboBox1.SelectedItem as string));
            }
            catch
            {
                return;
            }
        }

        // "Save Arrow" button
        private void arrowSaveButton_Click(object sender, EventArgs e)
        {
            if (!(arrowShowBox.BackgroundImage == null))
            {
                Bitmap arrowMap = (Bitmap) arrowShowBox.BackgroundImage;
                Icon myIcon = Arrow.ImageToIcon(arrowMap, 128);
                string newPath = Arrow.WhereToSave(myIcon);
                if (!(newPath == null))
                {
                    Arrow.SaveIcon(myIcon, newPath);
                }
            }
        }

        // "Apply This Arrow" button
        private void ArrowApplyMainMenuButton_Click(object sender, EventArgs e)
        {
            if (arrowShowBox.BackgroundImage != null)
            {
                Bitmap arrowMap = (Bitmap) arrowShowBox.BackgroundImage;
                Arrow.ChangeArrow(arrowMap);
            }
        }

        // "Apply Other Arrow" button
        private void arrowApplyButton_Click(object sender, EventArgs e)
        {
            Arrow.ChangeArrow();
        }

        // "Restore Default Arrows" button
        private void restoreArrowButton_Click(object sender, EventArgs e)
        {
            Arrow.Restore();
        }
    }
}
