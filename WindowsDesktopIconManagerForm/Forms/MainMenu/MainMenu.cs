using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Media.Media3D;
using System.Windows.Shapes;
using WindowsDesktopIconManagerForm.Properties;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;
using Path = System.IO.Path;
using Size = System.Drawing.Size;

// To do:
// TODO: Improve icon saving? At least recommend Photopea as the default icon editor
// TODO: Method to restore a selected backup through the app GUI
// TODO: Figure out the workflow for a user to actually set up icon sets
// TODO: Saving and loading icon sets
// TODO: Implement wallpaper workflow
// Can just have a menu to copy icons from a set to current icons, or from current icons to a set
// May need a workflow for people to upload specific icons for apps so they can be renamed accordingly
// A way to blank out shortcut names?

namespace WindowsDesktopIconManagerForm
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

            arrowCheck.Checked = Properties.Settings.Default.autoApplyArrows;
            explorerCheck.Checked = Properties.Settings.Default.autoRestartExplorer;
            lightDarkCheck.Checked = Properties.Settings.Default.enableLightDark;
            wallpaperCheck.Checked = Properties.Settings.Default.autoApplyWallpaper;
            defaultWallpaperCheck.Checked = Properties.Settings.Default.applyDefaultWallpaper;
            defaultWallpaperButton.Enabled = Properties.Settings.Default.applyDefaultWallpaper;
            wallpaperPathLabel.Enabled = Properties.Settings.Default.applyDefaultWallpaper;

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
        }
    }
}