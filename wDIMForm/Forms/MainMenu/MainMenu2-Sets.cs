using Microsoft.WindowsAPICodePack.Dialogs;
using System.IO;

namespace wDIMForm
{
    public partial class MainMenu : Form
    {
        // Load icon set list whenever this tab is selected
        private void TabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Check if the selected tab is tabPageIcons
            if (tabControl1.SelectedTab == tabPageIcons)
            {
                DirectoryInfo dinfo = new DirectoryInfo(Utilities.GetIconSetsFolder());
                DirectoryInfo[] directories = dinfo.GetDirectories();
                if (directories.Length == 0)
                {
                    return;
                }

                foreach (DirectoryInfo directory in directories)
                {
                    if (!iconSetListBox.Items.Contains(directory.Name))
                    {
                        iconSetListBox.Items.Add(directory.Name);
                    }
                }
            }
        }

        // Display selected icon set
        private void iconSetListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            applyIconSetButton.Enabled = true;
            string selectedSet = Path.Combine(Utilities.GetIconSetsFolder(), iconSetListBox.SelectedItem.ToString());
            string arrowPath = Path.Combine(selectedSet, "arrow.ico");
            string detailsPath = Path.Combine(selectedSet, "details.txt");
            string wallpaperPath = Utilities.GetWallpaperPath(selectedSet);

            // Fill display boxes if possible
            AddElement(wallpaperPath, wallpaperDisplay);
            AddElement(arrowPath, arrowDisplay);
            AddElement(detailsPath, detailsBox);

            listView1.Clear();

            // Fill icon list with any icons in the set
            string[] icons = Directory.GetFiles(selectedSet, "*.ico");
            foreach (string icon in icons)
            {
                if (!icon.Equals(arrowPath))
                {
                    imageList1.Images.Add(System.Drawing.Image.FromFile(icon));

                    System.Windows.Forms.ListViewItem item = new System.Windows.Forms.ListViewItem
                    {
                        ImageIndex = imageList1.Images.Count - 1,
                    };

                    listView1.Items.Add(item);
                }
            }
        }

        // Apply icon set button
        private void applyIconSetButton_Click(object sender, EventArgs e)
        {
            // Button isn't activated until something is selected so this function won't run with a null parameter
            IconSets.ApplySet(Path.Combine(Utilities.GetIconSetsFolder(), iconSetListBox.SelectedItem.ToString()));
        }

        // Adds image at the given path to the given PictureBox if the image exists
        private void AddElement(string path, PictureBox display)
        {
            if (File.Exists(path)) display.BackgroundImage = new Bitmap(path);
            else display.BackgroundImage = null;
        }

        // Adds text at the given path to the given RichTextBox if the text file exists
        private void AddElement(string path, RichTextBox display)
        {
            if (File.Exists(path)) display.Text = File.ReadAllText(path);
            else display.Text = "No details found for this set.";
        }

        // Turns arrow background grey on hover (for visibility)
        private void ArrowDisplay_MouseEnter(object sender, EventArgs e)
        {
            if (arrowDisplay.BackgroundImage != null) arrowDisplay.BackColor = Color.Gray;
        }

        // Reverts arrow background to transparent when no longer hovered
        private void ArrowDisplay_MouseLeave(object sender, EventArgs e)
        {
            arrowDisplay.BackColor = Color.Transparent;
        }

        // Imports a set and refreshes the list
        private void importIconSetButton_Click(object sender, EventArgs e)
        {
            IconSets.ImportSet();
            TabControl1_SelectedIndexChanged(sender, e);
        }
    }
}