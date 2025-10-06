namespace wDIMForm
{
    public partial class MainMenu : Form
    {

        // "Validate Desktop" button
        private void validateButton_Click(object sender, EventArgs e)
        {
            ForNonShortcuts.NonShortcutTool();
        }

        // "Initialize Icon Paths" button
        private void pathButton_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                DesktopPrep.SetIconPaths();
            }
            finally
            {
                this.Cursor = Cursors.Default;
                System.Windows.Forms.MessageBox.Show("Icon paths should be set. If some shortcuts didn't work, try re-running this program in Admin mode.", "wDIM");
            }
        }

        // "Back Up Shortcuts" button
        private void backupButton_Click(object sender, EventArgs e)
        {
            Utilities.CreateDesktopBackups(true, true);
        }

        // "Refresh Desktop" button
        private void refreshButton_Click(object sender, EventArgs e)
        {
            Utilities.RefreshDesktop();
        }

        // "Restart Explorer" button
        private void explorerButton_Click(object sender, EventArgs e)
        {
            Utilities.RestartExplorer();
        }
    }
}