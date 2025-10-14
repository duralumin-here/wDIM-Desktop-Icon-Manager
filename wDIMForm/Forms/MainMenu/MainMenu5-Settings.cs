using Microsoft.WindowsAPICodePack.Dialogs;
using System.Diagnostics;
using System.IO;

namespace wDIMForm
{
    public partial class MainMenu : Form
    {
        // Checkbox for whether wallpapers from sets should be applied automatically
        private void wallpaperCheck_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.autoApplyWallpaper = wallpaperCheck.Checked;
        }

        // Checkbox for whether a default wallpaper is set
        private void defaultWallpaperCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (defaultWallpaperCheck.Checked == false)
            {
                defaultWallpaperButton.Enabled = false;
                wallpaperPathLabel.Enabled = false;
                Properties.Settings.Default.applyDefaultWallpaper = false;
            }
            else
            {
                defaultWallpaperButton.Enabled = true;
                wallpaperPathLabel.Enabled = true;
                Properties.Settings.Default.applyDefaultWallpaper = true;
            }
        }

        // Button to select default wallpaper
        private void defaultWallpaperButton_Click(object sender, EventArgs e)
        {
            string path = ImageDialogPath("Select your default wallpaper");
            if (path == null) return;
            {
                    try
                    {
                        // "Using" statement used to check that the user has permission to open the file
                        using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.ReadWrite))
                        {
                            if (!path.Contains(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile)))
                            {
                                DialogResult result = MessageBox.Show("This file doesn't seem to be in your user folder. This may cause access issues later. You can proceed if you want, but it's recommended that you select a different file.", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                                if (result == DialogResult.Cancel) return;
                            }
                            wallpaperPathLabel.Text = Properties.Settings.Default.defaultWallpaper = path;
                        }
                    }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message + "\n\nPlease try again.", "wDIM", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private string ImageDialogPath(string title)
        {
            CommonOpenFileDialog dialog = new()
            {
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile),
                Title = title,
                Filters =
                {
                    new CommonFileDialogFilter("Image Files", "*.png; *.jpeg; *.jpg; *.gif; *.bmp")
                }
            };
            dialog.ShowDialog();
            try
            {
                return dialog.FileName;
            }
            catch
            {
                return null;
            }
        }

        // Checkbox to automatically apply set arrows when sets are applied
        private void arrowCheck_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.autoApplyArrows = arrowCheck.Checked;
        }

        // Checkbox to reset explorer when sets are applied
        private void explorerCheck_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.autoRestartExplorer = explorerCheck.Checked;
        }

        // Radio buttons
        /*private void multiplePaper1_CheckedChanged(object sender, EventArgs e)
        {
            if (multiplePaper1.Checked) Properties.Settings.Default.useFirstPaper = true;
            else Properties.Settings.Default.useFirstPaper = false;
        }
        private void multiplePaper2_CheckedChanged(object sender, EventArgs e)
        {
            if (multiplePaper2.Checked) Properties.Settings.Default.useRandomPaper = true;
            else Properties.Settings.Default.useRandomPaper = false;
        }*/

        // Restores settings to default
        private void restoreSettingsButton_Click(object sender, EventArgs e)
        {
            DialogResult result = System.Windows.Forms.MessageBox.Show("This operation will clear your preferences. They cannot be restored.", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (result == DialogResult.Cancel) return;

            // Apparently writing it like this is bad, but I think it's great.
            wallpaperCheck.Checked          = Properties.Settings.Default.autoApplyWallpaper = true;
            defaultWallpaperCheck.Checked   = Properties.Settings.Default.applyDefaultWallpaper = false;
            defaultWallpaperButton.Enabled  = Properties.Settings.Default.applyDefaultWallpaper = false;
            wallpaperPathLabel.Text         = Properties.Settings.Default.defaultWallpaper = "No path set";
            wallpaperPathLabel.Enabled      = Properties.Settings.Default.applyDefaultWallpaper = false;
            /*multiplePaper1.Checked          = */Properties.Settings.Default.useFirstPaper = true;
            /*multiplePaper2.Checked          = */Properties.Settings.Default.useRandomPaper = false;
            arrowCheck.Checked              = Properties.Settings.Default.autoApplyArrows = false;
            explorerCheck.Checked           = Properties.Settings.Default.autoRestartExplorer = false;
        }

        // View app folder button
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start("explorer.exe", Utilities.GetAppFolder());
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("An error occurred: " + ex.Message);
            }
        }
    }
}
