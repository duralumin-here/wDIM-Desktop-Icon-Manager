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

namespace WindowsDesktopIconManagerForm
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
                System.Windows.Forms.MessageBox.Show("Icon paths should be set. If some shortcuts didn't work, try re-running this program in Admin mode.", "Desktop Icon Manager");
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