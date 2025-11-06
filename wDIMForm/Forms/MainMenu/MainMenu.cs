using System.Diagnostics;

namespace wDIMForm
{

    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
            Utilities.CreateStartingDirectories();
            hueBox.Text = hueSlide.Value.ToString();
            satBox.Text = satSlide.Value.ToString();
            lightBox.Text = lightSlide.Value.ToString();

            // Allows the arrow to have proper transparency
            wallpaperDisplay.Controls.Add(arrowDisplay);
            arrowDisplay.Location = new System.Drawing.Point(0, (wallpaperDisplay.Height - arrowDisplay.Height));
            arrowDisplay.BackColor = Color.Transparent;

            // Allows all the label radio buttons to interact with the same change method
            cursiveLightRadio.CheckedChanged += fontRadio_CheckedChanged;
            cursiveBoldRadio.CheckedChanged += fontRadio_CheckedChanged;
            italicLightRadio.CheckedChanged += fontRadio_CheckedChanged;
            italicBoldRadio.CheckedChanged += fontRadio_CheckedChanged;
            serifLightRadio.CheckedChanged += fontRadio_CheckedChanged;
            serifBoldRadio.CheckedChanged += fontRadio_CheckedChanged;
            linedTextRadio.CheckedChanged += fontRadio_CheckedChanged;
            thinTextRadio.CheckedChanged += fontRadio_CheckedChanged;
            medievalTextRadio.CheckedChanged += fontRadio_CheckedChanged;
            circleTextRadio.CheckedChanged += fontRadio_CheckedChanged;
            defaultFontRadio.CheckedChanged += fontRadio_CheckedChanged;

            // Loads from settings
            wallpaperCheck.Checked = Properties.Settings.Default.autoApplyWallpaper;
            defaultWallpaperCheck.Checked = Properties.Settings.Default.applyDefaultWallpaper;
            defaultWallpaperButton.Enabled = Properties.Settings.Default.applyDefaultWallpaper;
            wallpaperPathLabel.Text = Properties.Settings.Default.defaultWallpaper;
            wallpaperPathLabel.Enabled = Properties.Settings.Default.applyDefaultWallpaper;
            /*multiplePaper1.Checked = Properties.Settings.Default.useFirstPaper;
            multiplePaper2.Checked = Properties.Settings.Default.useRandomPaper;
            arrowCheck.Checked = Properties.Settings.Default.autoApplyArrows;*/
            explorerCheck.Checked = Properties.Settings.Default.autoRestartExplorer;

            // Defines event when the form closes
            this.FormClosing += MainMenu_FormClosing;
        }

        // Save settings on close
        private void MainMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.Save();
        }

        private void detailsBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}