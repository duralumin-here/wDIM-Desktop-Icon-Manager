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
        }

        private void validateButton_Click(object sender, EventArgs e)
        {
            ForNonShortcuts.NonShortcutTool();
        }

        private void pathButton_Click(object sender, EventArgs e)
        {
            DesktopPrep.SetIconPaths();
        }

        private void backupButton_Click(object sender, EventArgs e)
        {
            Utilities.CreateDesktopBackups(true, true);
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            Utilities.RefreshDesktop();
        }

        private void explorerButton_Click(object sender, EventArgs e)
        {
            Utilities.RestartExplorer();
        }

        private void restoreArrowButton_Click(object sender, EventArgs e)
        {
            Arrow.Restore();
        }

        private void hueSlide_ValueChanged(object sender, EventArgs e)
        {
            hueBox.Text = hueSlide.Value.ToString();
            try
            {
                Bitmap image = new Bitmap(arrowShowBox.BackgroundImage);
                arrowShowBox.BackgroundImage = Arrow.ColorShift(image, hueSlide.Value, "h");
            }
            catch
            {
                return;
            }
        }

        private void satSlide_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                satBox.Text = satSlide.Value.ToString();
                Bitmap image = new Bitmap(arrowShowBox.BackgroundImage);
                double sat = (double)satSlide.Value / 100;
                arrowShowBox.BackgroundImage = Arrow.ColorShift(image, sat, "s");
            }
            catch
            {
                return;
            }
        }

        private void lightSlide_ValueChanged(object sender, EventArgs e)
        {
            lightBox.Text = lightSlide.Value.ToString();
            try
            {
                Bitmap image = new Bitmap(arrowShowBox.BackgroundImage);
                float bright = (float)lightSlide.Value / 100;
                arrowShowBox.BackgroundImage = Arrow.ColorShift(image, bright, "l");
            }
            catch
            {
                return;
            }
        }

        private void hueBox_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(hueBox.Text, out int value))
            {
                if (value >= hueSlide.Minimum && value <= hueSlide.Maximum)
                {
                    hueSlide.Value = value;
                }
            }
        }

        private void satBox_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(satBox.Text, out int value))
            {
                if (value >= satSlide.Minimum && value <= satSlide.Maximum)
                {
                    satSlide.Value = value;
                }
            }
        }

        private void lightBox_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(lightBox.Text, out int value))
            {
                if (value >= lightSlide.Minimum && value <= lightSlide.Maximum)
                {
                    lightSlide.Value = value;
                }
            }
        }

        private void resetColorButton_Click(object sender, EventArgs e)
        {
            hueSlide.Value = 0;
            satSlide.Value = 100;
            lightSlide.Value = 50;

            try
            {
                Bitmap newArrowMap = Arrow.GetBitmap(Arrow.PickArrowType(comboBox1.SelectedItem as string));
                arrowShowBox.BackgroundImage = newArrowMap;
            }
            catch
            {
                return;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedItem = comboBox1.SelectedItem as string;
            if (selectedItem == null) return;

            // Sets path based on combo box selection
            string iconPath = Arrow.PickArrowType(selectedItem);

            // Bitmap from the path
            // If it fails (eg bitmap is null) it will just end
            try
            {
                Bitmap newArrowMap = Arrow.GetBitmap(iconPath);
                arrowShowBox.BackgroundImage = newArrowMap;
                arrowSaveButton.Enabled = true;
            }
            catch
            {
                return;
            }

            // Reapply colors on arrow change
            try
            {
                Bitmap image = new Bitmap(arrowShowBox.BackgroundImage);
                arrowShowBox.BackgroundImage = Arrow.ColorShift(image, hueSlide.Value, "h");
                double sat = (double)satSlide.Value / 100;
                arrowShowBox.BackgroundImage = Arrow.ColorShift(image, sat, "s");
                float bright = (float)lightSlide.Value / 100;
                arrowShowBox.BackgroundImage = Arrow.ColorShift(image, bright, "l");
            }
            catch
            {
                return;
            }
        }

        private void arrowSaveButton_Click(object sender, EventArgs e)
        {
            Bitmap arrowMap;
            try
            {
                if (arrowShowBox.BackgroundImage == null) { throw new Exception("No image selected"); }
                arrowMap = (Bitmap)arrowShowBox.BackgroundImage;
            }
            catch
            {
                System.Media.SystemSounds.Asterisk.Play();
                return;
            }
            Icon myIcon = Arrow.ImageToIcon(arrowMap, 128);
            string newPath = Arrow.WhereToSave(myIcon);
            if (newPath == null)
            {
                return;
            }
            Arrow.SaveIcon(myIcon, newPath);
        }

        private void arrowApplyButton_Click(object sender, EventArgs e)
        {
            Arrow.ChangeArrows();
        }

        private void cursiveLightRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (cursiveLightRadio.Enabled == true)
            {
                alphabetLabel.Text = "𝒶𝒷𝒸𝒹𝑒𝒻𝑔𝒽𝒾𝒿𝓀𝓁𝓂𝓃𝑜𝓅𝓆𝓇𝓈𝓉𝓊𝓋𝓌𝓍𝓎𝓏𝒜𝐵𝒞𝒟𝐸𝐹𝒢𝐻𝐼𝒥𝒦𝐿𝑀𝒩𝒪𝒫𝒬𝑅𝒮𝒯𝒰𝒱𝒲𝒳𝒴𝒵𝟶𝟷𝟸𝟹𝟺𝟻𝟼𝟽𝟾𝟿";
                alphabetLabel.Tag = "cursive";
            }
        }

        private void cursiveBoldRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (cursiveBoldRadio.Enabled == true)
            {
                alphabetLabel.Text = "𝓪𝓫𝓬𝓭𝓮𝓯𝓰𝓱𝓲𝓳𝓴𝓵𝓶𝓷𝓸𝓹𝓺𝓻𝓼𝓽𝓾𝓿𝔀𝔁𝔂𝔃𝓐𝓑𝓒𝓓𝓔𝓕𝓖𝓗𝓘𝓙𝓚𝓛𝓜𝓝𝓞𝓟𝓠𝓡𝓢𝓣𝓤𝓥𝓦𝓧𝓨𝓩𝟎𝟏𝟐𝟑𝟒𝟓𝟔𝟕𝟖𝟗";
                alphabetLabel.Tag = "cursive-bold";
            }
        }

        private void italicLightRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (italicLightRadio.Enabled == true)
            {
                alphabetLabel.Text = "𝘢𝘣𝘤𝘥𝘦𝘧𝘨𝘩𝘪𝘫𝘬𝘭𝘮𝘯𝘰𝘱𝘲𝘳𝘴𝘵𝘶𝘷𝘸𝘹𝘺𝘻𝘈𝘉𝘊𝘋𝘌𝘍𝘎𝘏𝘐𝘑𝘒𝘓𝘔𝘕𝘖𝘗𝘘𝘙𝘚𝘛𝘜𝘝𝘞𝘟𝘠𝘡𝟶𝟷𝟸𝟹𝟺𝟻𝟼𝟽𝟾𝟿";
                alphabetLabel.Tag = "italic";
            }
        }

        private void italicBoldRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (italicBoldRadio.Enabled == true)
            {
                alphabetLabel.Text = "𝙖𝙗𝙘𝙙𝙚𝙛𝙜𝙝𝙞𝙟𝙠𝙡𝙢𝙣𝙤𝙥𝙦𝙧𝙨𝙩𝙪𝙫𝙬𝙭𝙮𝙯𝘼𝘽𝘾𝘿𝙀𝙁𝙂𝙃𝙄𝙅𝙆𝙇𝙈𝙉𝙊𝙋𝙌𝙍𝙎𝙏𝙐𝙑𝙒𝙓𝙔𝙕𝟎𝟏𝟐𝟑𝟒𝟓𝟔𝟕𝟖𝟗";
                alphabetLabel.Tag = "italic-bold";
            }
        }

        private void serifLightRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (serifLightRadio.Enabled == true)
            {
                alphabetLabel.Text = "𝚊𝚋𝚌𝚍𝚎𝚏𝚐𝚑𝚒𝚓𝚔𝚕𝚖𝚗𝚘𝚙𝚚𝚛𝚜𝚝𝚞𝚟𝚠𝚡𝚢𝚣𝙰𝙱𝙲𝙳𝙴𝙵𝙶𝙷𝙸𝙹𝙺𝙻𝙼𝙽𝙾𝙿𝚀𝚁𝚂𝚃𝚄𝚅𝚆𝚇𝚈𝚉𝟶𝟷𝟸𝟹𝟺𝟻𝟼𝟽𝟾𝟿";
                alphabetLabel.Tag = "serif";
            }
        }

        private void serifBoldVideo_CheckedChanged(object sender, EventArgs e)
        {
            if (serifBoldVideo.Enabled == true)
            {
                alphabetLabel.Text = "𝐚𝐛𝐜𝐝𝐞𝐟𝐠𝐡𝐢𝐣𝐤𝐥𝐦𝐧𝐨𝐩𝐪𝐫𝐬𝐭𝐮𝐯𝐰𝐱𝐲𝐳𝐀𝐁𝐂𝐃𝐄𝐅𝐆𝐇𝐈𝐉𝐊𝐋𝐌𝐍𝐎𝐏𝐐𝐑𝐒𝐓𝐔𝐕𝐖𝐗𝐘𝐙𝟎𝟏𝟐𝟑𝟒𝟓𝟔𝟕𝟖𝟗";
                alphabetLabel.Tag = "serif-bold";
            }
        }

        private void linedTextRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (linedTextRadio.Enabled == true)
            {
                alphabetLabel.Text = "𝕒𝕓𝕔𝕕𝕖𝕗𝕘𝕙𝕚𝕛𝕜𝕝𝕞𝕟𝕠𝕡𝕢𝕣𝕤𝕥𝕦𝕧𝕨𝕩𝕪𝕫𝔸𝔹ℂ𝔻𝔼𝔽𝔾ℍ𝕀𝕁𝕂𝕃𝕄ℕ𝕆ℙℚℝ𝕊𝕋𝕌𝕍𝕎𝕏𝕐ℤ𝟘𝟙𝟚𝟛𝟜𝟝𝟞𝟟𝟠𝟡";
                alphabetLabel.Tag = "lined";
            }
        }

        private void thinTextRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (thinTextRadio.Enabled == true)
            {
                alphabetLabel.Text = "ａｂｃｄｅｆｇｈｉｊｋｌｍｎｏｐｑｒｓｔｕｖｗｘｙｚＡＢＣＤＥＦＧＨＩＪＫＬＭＮＯＰＱＲＳＴＵＶＷＸＹＺ０１２３４５６７８９";
                alphabetLabel.Tag = "thin";
            }
        }

        private void medievalTextRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (medievalTextRadio.Enabled == true)
            {
                alphabetLabel.Text = "𝖆𝖇𝖈𝖉𝖊𝖋𝖌𝖍𝖎𝖏𝖐𝖑𝖒𝖓𝖔𝖕𝖖𝖗𝖘𝖙𝖚𝖛𝖜𝖝𝖞𝖟𝕬𝕭𝕮𝕯𝕰𝕱𝕲𝕳𝕴𝕵𝕶𝕷𝕸𝕹𝕺𝕻𝕼𝕽𝕾𝕿𝖀𝖁𝖂𝖃𝖄𝖅𝟎𝟏𝟐𝟑𝟒𝟓𝟔𝟕𝟖𝟗";
                alphabetLabel.Tag = "medieval";
            }
        }

        private void circleTextRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (circleTextRadio.Enabled == true)
            {
                alphabetLabel.Text = "ⓐⓑⓒⓓⓔⓕⓖⓗⓘⓙⓚⓛⓜⓝⓞⓟⓠⓡⓢⓣⓤⓥⓦⓧⓨⓩⒶⒷⒸⒹⒺⒻⒼⒽⒾⒿⓀⓁⓂⓃⓄⓅⓆⓇⓈⓉⓊⓋⓌⓍⓎⓏ\n⓪①②③④⑤⑥⑦⑧⑨";
                alphabetLabel.Tag = "circle";
            }
        }

        private void defaultFontRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (defaultFontRadio.Enabled == true)
            {
                alphabetLabel.Text = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
                alphabetLabel.Tag = "default";
            }
        }

        private void labelButton_Click(object sender, EventArgs e)
        {
            string startString = null;
            if (charStartCheck.Checked)
            {
                startString = startCharTextBox.Text;
            }

            string endString = null;
            if (charEndCheck.Checked)
            {
                endString = endCharTextBox.Text;
            }

            Labels.ChangeDesktopLabels(alphabetLabel.Tag.ToString(), startString, endString);
        }

        private void tabPageSettings_Click(object sender, EventArgs e)
        {

        }

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

        private void lightDarkCheck_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.enableLightDark = lightDarkCheck.Checked;
        }

        private void validateButton_Click_1(object sender, EventArgs e)
        {

        }


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
                    if (!listBox1.Items.Contains(directory.Name))
                    {
                        listBox1.Items.Add(directory.Name);
                    }
                }
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedSet = Path.Combine(Utilities.GetIconSetsFolder(), listBox1.SelectedItem.ToString());
            string arrowPath = Path.Combine(selectedSet, "arrow.ico");
            string wallpaperPath = Utilities.GetWallpaperPath(selectedSet);

            AddElement(wallpaperPath, wallpaperDisplay);
            AddElement(arrowPath, arrowDisplay);
            listView1.Clear();

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

        private void AddElement(string path, PictureBox display)
        {

            if (File.Exists(path)) display.BackgroundImage = new Bitmap(path);
            else display.BackgroundImage = null;
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void charStartCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (charStartCheck.Checked) startCharTextBox.Enabled = true;
            else startCharTextBox.Enabled = false;
        }

        private void charEndCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (charEndCheck.Checked) endCharTextBox.Enabled = true;
            else endCharTextBox.Enabled = false;
        }

        private void iconsDisplay_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }



        private void arrowDisplay_Click(object sender, EventArgs e)
        {

        }
    }
}