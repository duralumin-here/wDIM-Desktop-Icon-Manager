namespace WindowsDesktopIconManagerForm
{
    public partial class MainMenu : Form
    {
        private void lightDarkCheck_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.enableLightDark = lightDarkCheck.Checked;
        }
    }
}
