using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

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
            explorerCheck.Checked = Properties.Settings.Default.autoRestartExplorer;

            // Defines event when the form closes
            this.FormClosing += MainMenu_FormClosing;
        }

        // Save settings on close
        private void MainMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.Save();
        }

        // Handles tab changes (needs to be in one method)
        private void TabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Sets public desktop status on settings page
            if (tabControl1.SelectedTab == tabPageSettings)
            {
                List<string> shortcuts = [];
                shortcuts.AddRange(Directory.GetFiles(@"C:\Users\Public\Desktop", "*.lnk"));
                if (shortcuts.Count == 0)
                {
                    publicPrivateLabel.Text = "✔ All shortcuts are on the private desktop.";
                }
                else
                {
                    string pluralize, verb;
                    if (shortcuts.Count == 1)
                    {
                        pluralize = "";
                        verb = " is";
                    }
                    else
                    {
                        pluralize = "s";
                        verb = " are";
                    }
                    publicPrivateLabel.Text = "⚠ " + shortcuts.Count + " shortcut" + pluralize + verb + " on the public desktop.";
                    movePublicButton.Enabled = true;
                }
            }
            // Populates icon set list on icon set page
            else if (tabControl1.SelectedTab == tabPageIcons)
            {
                DirectoryInfo dinfo = new DirectoryInfo(Utilities.GetIconSetsFolder());
                DirectoryInfo[] directories = dinfo.GetDirectories();
                if (directories.Length == 0) return;
                foreach (DirectoryInfo directory in directories)
                {
                    if (!iconSetListBox.Items.Contains(directory.Name)) iconSetListBox.Items.Add(directory.Name);
                }
            }
        }
    }
}