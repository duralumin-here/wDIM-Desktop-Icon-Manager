namespace WindowsDesktopIconManagerForm
{
    public partial class MainMenu : Form
    {
        private void wallpaperCheck_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.autoApplyWallpaper = wallpaperCheck.Checked;
        }

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

        private void arrowCheck_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.autoApplyArrows = arrowCheck.Checked;
        }

        private void explorerCheck_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.autoRestartExplorer = explorerCheck.Checked;
        }
    }
}
