using System.Windows.Forms;

namespace wDIMForm
{
    partial class MainMenu
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainMenu));
            imageList1 = new ImageList(components);
            tabPageSettings = new TabPage();
            button3 = new Button();
            restoreSettingsButton = new Button();
            button2 = new Button();
            shortcutToPersonalButton = new Button();
            defaultWallpaperCheck = new CheckBox();
            defaultWallpaperButton = new Button();
            wallpaperPathLabel = new Label();
            explorerCheck = new CheckBox();
            wallpaperCheck = new CheckBox();
            tabPageArrows = new TabPage();
            arrowPathButton = new Button();
            restoreArrowButton = new Button();
            resetColorButton = new Button();
            arrowSaveButton = new Button();
            label8 = new Label();
            label5 = new Label();
            label7 = new Label();
            arrowApplyButton = new Button();
            ArrowApplyMainMenuButton = new Button();
            lightBox = new TextBox();
            satBox = new TextBox();
            hueBox = new TextBox();
            label9 = new Label();
            comboBox1 = new ComboBox();
            lightSlide = new TrackBar();
            satSlide = new TrackBar();
            hueSlide = new TrackBar();
            arrowShowBox = new PictureBox();
            tabPageLabels = new TabPage();
            label6 = new Label();
            labelRestoreButton = new Button();
            alphabetLabel = new Label();
            label11 = new Label();
            labelButton = new Button();
            endCharTextBox = new TextBox();
            startCharTextBox = new TextBox();
            charEndCheck = new CheckBox();
            charStartCheck = new CheckBox();
            defaultFontRadio = new RadioButton();
            serifLightRadio = new RadioButton();
            italicBoldRadio = new RadioButton();
            italicLightRadio = new RadioButton();
            serifBoldRadio = new RadioButton();
            circleTextRadio = new RadioButton();
            medievalTextRadio = new RadioButton();
            thinTextRadio = new RadioButton();
            linedTextRadio = new RadioButton();
            cursiveLightRadio = new RadioButton();
            cursiveBoldRadio = new RadioButton();
            tabPageIcons = new TabPage();
            arrowDisplay = new PictureBox();
            importIconSetButton = new Button();
            listView1 = new ListView();
            detailsBox = new RichTextBox();
            wallpaperDisplay = new PictureBox();
            iconSetListBox = new ListBox();
            applyIconSetButton = new Button();
            tabPageManage = new TabPage();
            label10 = new Label();
            linkLabel1 = new LinkLabel();
            refreshButton = new Button();
            label4 = new Label();
            backupButton = new Button();
            label3 = new Label();
            explorerButton = new Button();
            validateButton = new Button();
            pathButton = new Button();
            label1 = new Label();
            label2 = new Label();
            tabControl1 = new TabControl();
            tabPageSettings.SuspendLayout();
            tabPageArrows.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)lightSlide).BeginInit();
            ((System.ComponentModel.ISupportInitialize)satSlide).BeginInit();
            ((System.ComponentModel.ISupportInitialize)hueSlide).BeginInit();
            ((System.ComponentModel.ISupportInitialize)arrowShowBox).BeginInit();
            tabPageLabels.SuspendLayout();
            tabPageIcons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)arrowDisplay).BeginInit();
            ((System.ComponentModel.ISupportInitialize)wallpaperDisplay).BeginInit();
            tabPageManage.SuspendLayout();
            tabControl1.SuspendLayout();
            SuspendLayout();
            // 
            // imageList1
            // 
            imageList1.ColorDepth = ColorDepth.Depth32Bit;
            imageList1.ImageSize = new Size(75, 75);
            imageList1.TransparentColor = Color.Transparent;
            // 
            // tabPageSettings
            // 
            tabPageSettings.BackColor = Color.WhiteSmoke;
            tabPageSettings.Controls.Add(button3);
            tabPageSettings.Controls.Add(restoreSettingsButton);
            tabPageSettings.Controls.Add(button2);
            tabPageSettings.Controls.Add(shortcutToPersonalButton);
            tabPageSettings.Controls.Add(defaultWallpaperCheck);
            tabPageSettings.Controls.Add(defaultWallpaperButton);
            tabPageSettings.Controls.Add(wallpaperPathLabel);
            tabPageSettings.Controls.Add(explorerCheck);
            tabPageSettings.Controls.Add(wallpaperCheck);
            tabPageSettings.Location = new Point(4, 29);
            tabPageSettings.Name = "tabPageSettings";
            tabPageSettings.Padding = new Padding(3);
            tabPageSettings.Size = new Size(770, 296);
            tabPageSettings.TabIndex = 6;
            tabPageSettings.Text = "Settings";
            // 
            // button3
            // 
            button3.Location = new Point(581, 215);
            button3.Name = "button3";
            button3.Size = new Size(173, 29);
            button3.TabIndex = 29;
            button3.Text = "View App Folder";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // restoreSettingsButton
            // 
            restoreSettingsButton.Location = new Point(581, 250);
            restoreSettingsButton.Name = "restoreSettingsButton";
            restoreSettingsButton.Size = new Size(173, 29);
            restoreSettingsButton.TabIndex = 28;
            restoreSettingsButton.Text = "Restore Defaults";
            restoreSettingsButton.UseVisualStyleBackColor = true;
            restoreSettingsButton.Click += restoreSettingsButton_Click;
            // 
            // button2
            // 
            button2.Location = new Point(570, 297);
            button2.Name = "button2";
            button2.Size = new Size(175, 29);
            button2.TabIndex = 27;
            button2.Text = "Open App Folder";
            button2.UseVisualStyleBackColor = true;
            // 
            // shortcutToPersonalButton
            // 
            shortcutToPersonalButton.Location = new Point(16, 297);
            shortcutToPersonalButton.Name = "shortcutToPersonalButton";
            shortcutToPersonalButton.Size = new Size(289, 29);
            shortcutToPersonalButton.TabIndex = 26;
            shortcutToPersonalButton.Text = "Move all shortcuts to personal desktop";
            shortcutToPersonalButton.UseVisualStyleBackColor = true;
            // 
            // defaultWallpaperCheck
            // 
            defaultWallpaperCheck.AutoSize = true;
            defaultWallpaperCheck.Location = new Point(37, 57);
            defaultWallpaperCheck.Name = "defaultWallpaperCheck";
            defaultWallpaperCheck.Size = new Size(438, 24);
            defaultWallpaperCheck.TabIndex = 1;
            defaultWallpaperCheck.Text = "Apply default wallpaper when set does not contain wallpaper";
            defaultWallpaperCheck.UseVisualStyleBackColor = true;
            defaultWallpaperCheck.CheckedChanged += defaultWallpaperCheck_CheckedChanged;
            // 
            // defaultWallpaperButton
            // 
            defaultWallpaperButton.Enabled = false;
            defaultWallpaperButton.Location = new Point(37, 87);
            defaultWallpaperButton.Name = "defaultWallpaperButton";
            defaultWallpaperButton.Size = new Size(201, 29);
            defaultWallpaperButton.TabIndex = 2;
            defaultWallpaperButton.Text = "Select Default Wallpaper...";
            defaultWallpaperButton.UseVisualStyleBackColor = true;
            defaultWallpaperButton.Click += defaultWallpaperButton_Click;
            // 
            // wallpaperPathLabel
            // 
            wallpaperPathLabel.AutoSize = true;
            wallpaperPathLabel.Enabled = false;
            wallpaperPathLabel.Location = new Point(245, 91);
            wallpaperPathLabel.Name = "wallpaperPathLabel";
            wallpaperPathLabel.Size = new Size(86, 20);
            wallpaperPathLabel.TabIndex = 18;
            wallpaperPathLabel.Text = "No path set";
            // 
            // explorerCheck
            // 
            explorerCheck.AutoSize = true;
            explorerCheck.Location = new Point(16, 122);
            explorerCheck.Name = "explorerCheck";
            explorerCheck.Size = new Size(729, 24);
            explorerCheck.TabIndex = 5;
            explorerCheck.Text = "Restart Windows Explorer when applying icon set (may be disruptive; may fix arrow changes not showing)";
            explorerCheck.UseVisualStyleBackColor = true;
            explorerCheck.CheckedChanged += explorerCheck_CheckedChanged;
            // 
            // wallpaperCheck
            // 
            wallpaperCheck.AutoSize = true;
            wallpaperCheck.Checked = true;
            wallpaperCheck.CheckState = CheckState.Checked;
            wallpaperCheck.Location = new Point(16, 27);
            wallpaperCheck.Name = "wallpaperCheck";
            wallpaperCheck.Size = new Size(378, 24);
            wallpaperCheck.TabIndex = 0;
            wallpaperCheck.Text = "Automatically apply wallpapers included in icon sets";
            wallpaperCheck.UseVisualStyleBackColor = true;
            wallpaperCheck.CheckedChanged += wallpaperCheck_CheckedChanged;
            // 
            // tabPageArrows
            // 
            tabPageArrows.BackColor = Color.WhiteSmoke;
            tabPageArrows.Controls.Add(arrowPathButton);
            tabPageArrows.Controls.Add(restoreArrowButton);
            tabPageArrows.Controls.Add(resetColorButton);
            tabPageArrows.Controls.Add(arrowSaveButton);
            tabPageArrows.Controls.Add(label8);
            tabPageArrows.Controls.Add(label5);
            tabPageArrows.Controls.Add(label7);
            tabPageArrows.Controls.Add(arrowApplyButton);
            tabPageArrows.Controls.Add(ArrowApplyMainMenuButton);
            tabPageArrows.Controls.Add(lightBox);
            tabPageArrows.Controls.Add(satBox);
            tabPageArrows.Controls.Add(hueBox);
            tabPageArrows.Controls.Add(label9);
            tabPageArrows.Controls.Add(comboBox1);
            tabPageArrows.Controls.Add(lightSlide);
            tabPageArrows.Controls.Add(satSlide);
            tabPageArrows.Controls.Add(hueSlide);
            tabPageArrows.Controls.Add(arrowShowBox);
            tabPageArrows.Location = new Point(4, 29);
            tabPageArrows.Name = "tabPageArrows";
            tabPageArrows.Padding = new Padding(3);
            tabPageArrows.Size = new Size(770, 296);
            tabPageArrows.TabIndex = 5;
            tabPageArrows.Text = "Shortcut Arrows";
            // 
            // arrowPathButton
            // 
            arrowPathButton.Location = new Point(568, 205);
            arrowPathButton.Name = "arrowPathButton";
            arrowPathButton.Size = new Size(175, 29);
            arrowPathButton.TabIndex = 42;
            arrowPathButton.Text = "Initialize arrow path";
            arrowPathButton.UseVisualStyleBackColor = true;
            arrowPathButton.Click += arrowPathButton_Click;
            // 
            // restoreArrowButton
            // 
            restoreArrowButton.Location = new Point(568, 240);
            restoreArrowButton.Name = "restoreArrowButton";
            restoreArrowButton.Size = new Size(175, 30);
            restoreArrowButton.TabIndex = 11;
            restoreArrowButton.Text = "Restore default arrows";
            restoreArrowButton.UseVisualStyleBackColor = true;
            restoreArrowButton.Click += restoreArrowButton_Click;
            // 
            // resetColorButton
            // 
            resetColorButton.Location = new Point(258, 242);
            resetColorButton.Name = "resetColorButton";
            resetColorButton.Size = new Size(126, 29);
            resetColorButton.TabIndex = 7;
            resetColorButton.Text = "Reset editor";
            resetColorButton.UseVisualStyleBackColor = true;
            resetColorButton.Click += resetColorButton_Click;
            // 
            // arrowSaveButton
            // 
            arrowSaveButton.Enabled = false;
            arrowSaveButton.Location = new Point(390, 242);
            arrowSaveButton.Name = "arrowSaveButton";
            arrowSaveButton.Size = new Size(126, 29);
            arrowSaveButton.TabIndex = 8;
            arrowSaveButton.Text = "Save arrow";
            arrowSaveButton.UseVisualStyleBackColor = true;
            arrowSaveButton.Click += arrowSaveButton_Click;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(230, 169);
            label8.Name = "label8";
            label8.Size = new Size(70, 20);
            label8.TabIndex = 38;
            label8.Text = "Lightness";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(230, 100);
            label5.Name = "label5";
            label5.Size = new Size(77, 20);
            label5.TabIndex = 36;
            label5.Text = "Saturation";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(230, 34);
            label7.Name = "label7";
            label7.Size = new Size(36, 20);
            label7.TabIndex = 31;
            label7.Text = "Hue";
            // 
            // arrowApplyButton
            // 
            arrowApplyButton.Location = new Point(568, 86);
            arrowApplyButton.Name = "arrowApplyButton";
            arrowApplyButton.Size = new Size(175, 30);
            arrowApplyButton.TabIndex = 10;
            arrowApplyButton.Text = "Apply other arrow...";
            arrowApplyButton.UseVisualStyleBackColor = true;
            arrowApplyButton.Click += arrowApplyButton_Click;
            // 
            // ArrowApplyMainMenuButton
            // 
            ArrowApplyMainMenuButton.Enabled = false;
            ArrowApplyMainMenuButton.Location = new Point(568, 51);
            ArrowApplyMainMenuButton.Name = "ArrowApplyMainMenuButton";
            ArrowApplyMainMenuButton.Size = new Size(175, 30);
            ArrowApplyMainMenuButton.TabIndex = 9;
            ArrowApplyMainMenuButton.Text = "Apply this arrow";
            ArrowApplyMainMenuButton.UseVisualStyleBackColor = true;
            ArrowApplyMainMenuButton.Click += ArrowApplyMainMenuButton_Click;
            // 
            // lightBox
            // 
            lightBox.Location = new Point(480, 190);
            lightBox.Name = "lightBox";
            lightBox.Size = new Size(64, 27);
            lightBox.TabIndex = 6;
            lightBox.TextChanged += lightBox_TextChanged;
            // 
            // satBox
            // 
            satBox.Location = new Point(480, 121);
            satBox.Name = "satBox";
            satBox.Size = new Size(64, 27);
            satBox.TabIndex = 4;
            satBox.TextChanged += satBox_TextChanged;
            // 
            // hueBox
            // 
            hueBox.Location = new Point(480, 53);
            hueBox.Name = "hueBox";
            hueBox.Size = new Size(64, 27);
            hueBox.TabIndex = 2;
            hueBox.TextChanged += hueBox_TextChanged;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(27, 219);
            label9.Name = "label9";
            label9.Size = new Size(148, 20);
            label9.TabIndex = 41;
            label9.Text = "Select an arrow style:";
            // 
            // comboBox1
            // 
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Blank/No Arrow", "Curved (Transparent)", "Curved (Black)", "Curved (White)", "Straight (Transparent)", "Straight (Black)", "Straight (White)", "Heart", "Star" });
            comboBox1.Location = new Point(27, 242);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(152, 28);
            comboBox1.TabIndex = 0;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // lightSlide
            // 
            lightSlide.LargeChange = 10;
            lightSlide.Location = new Point(224, 181);
            lightSlide.Maximum = 98;
            lightSlide.Minimum = 2;
            lightSlide.Name = "lightSlide";
            lightSlide.Size = new Size(240, 56);
            lightSlide.TabIndex = 5;
            lightSlide.TickFrequency = 0;
            lightSlide.TickStyle = TickStyle.Both;
            lightSlide.Value = 50;
            lightSlide.ValueChanged += lightSlide_ValueChanged;
            // 
            // satSlide
            // 
            satSlide.LargeChange = 10;
            satSlide.Location = new Point(224, 111);
            satSlide.Maximum = 100;
            satSlide.Minimum = 2;
            satSlide.Name = "satSlide";
            satSlide.Size = new Size(240, 56);
            satSlide.TabIndex = 3;
            satSlide.TickFrequency = 0;
            satSlide.TickStyle = TickStyle.Both;
            satSlide.Value = 100;
            satSlide.ValueChanged += satSlide_ValueChanged;
            // 
            // hueSlide
            // 
            hueSlide.BackColor = Color.WhiteSmoke;
            hueSlide.LargeChange = 10;
            hueSlide.Location = new Point(224, 42);
            hueSlide.Maximum = 360;
            hueSlide.Name = "hueSlide";
            hueSlide.Size = new Size(240, 56);
            hueSlide.TabIndex = 1;
            hueSlide.TickFrequency = 0;
            hueSlide.TickStyle = TickStyle.Both;
            hueSlide.ValueChanged += hueSlide_ValueChanged;
            // 
            // arrowShowBox
            // 
            arrowShowBox.BackColor = Color.LightGray;
            arrowShowBox.BackgroundImageLayout = ImageLayout.Stretch;
            arrowShowBox.BorderStyle = BorderStyle.Fixed3D;
            arrowShowBox.Location = new Point(29, 43);
            arrowShowBox.Name = "arrowShowBox";
            arrowShowBox.Size = new Size(150, 150);
            arrowShowBox.TabIndex = 30;
            arrowShowBox.TabStop = false;
            // 
            // tabPageLabels
            // 
            tabPageLabels.BackColor = Color.WhiteSmoke;
            tabPageLabels.Controls.Add(label6);
            tabPageLabels.Controls.Add(labelRestoreButton);
            tabPageLabels.Controls.Add(alphabetLabel);
            tabPageLabels.Controls.Add(label11);
            tabPageLabels.Controls.Add(labelButton);
            tabPageLabels.Controls.Add(endCharTextBox);
            tabPageLabels.Controls.Add(startCharTextBox);
            tabPageLabels.Controls.Add(charEndCheck);
            tabPageLabels.Controls.Add(charStartCheck);
            tabPageLabels.Controls.Add(defaultFontRadio);
            tabPageLabels.Controls.Add(serifLightRadio);
            tabPageLabels.Controls.Add(italicBoldRadio);
            tabPageLabels.Controls.Add(italicLightRadio);
            tabPageLabels.Controls.Add(serifBoldRadio);
            tabPageLabels.Controls.Add(circleTextRadio);
            tabPageLabels.Controls.Add(medievalTextRadio);
            tabPageLabels.Controls.Add(thinTextRadio);
            tabPageLabels.Controls.Add(linedTextRadio);
            tabPageLabels.Controls.Add(cursiveLightRadio);
            tabPageLabels.Controls.Add(cursiveBoldRadio);
            tabPageLabels.Location = new Point(4, 29);
            tabPageLabels.Name = "tabPageLabels";
            tabPageLabels.Padding = new Padding(3);
            tabPageLabels.Size = new Size(770, 296);
            tabPageLabels.TabIndex = 4;
            tabPageLabels.Text = "Customize Labels";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(13, 196);
            label6.Name = "label6";
            label6.Size = new Size(735, 20);
            label6.TabIndex = 21;
            label6.Text = "Modified shortcuts will move over to the side of the screen, alphabetized, so you may have to rearrange them.";
            // 
            // labelRestoreButton
            // 
            labelRestoreButton.Location = new Point(550, 254);
            labelRestoreButton.Name = "labelRestoreButton";
            labelRestoreButton.Size = new Size(203, 29);
            labelRestoreButton.TabIndex = 20;
            labelRestoreButton.Text = "Restore original labels";
            labelRestoreButton.UseVisualStyleBackColor = true;
            labelRestoreButton.Click += labelRestoreButton_Click;
            // 
            // alphabetLabel
            // 
            alphabetLabel.AutoSize = true;
            alphabetLabel.Location = new Point(13, 136);
            alphabetLabel.Name = "alphabetLabel";
            alphabetLabel.Size = new Size(628, 20);
            alphabetLabel.TabIndex = 19;
            alphabetLabel.Tag = "cursive";
            alphabetLabel.Text = "𝒶𝒷𝒸𝒹𝑒𝒻𝑔𝒽𝒾𝒿𝓀𝓁𝓂𝓃𝑜𝓅𝓆𝓇𝓈𝓉𝓊𝓋𝓌𝓍𝓎𝓏𝒜𝐵𝒞𝒟𝐸𝐹𝒢𝐻𝐼𝒥𝒦𝐿𝑀𝒩𝒪𝒫𝒬𝑅𝒮𝒯𝒰𝒱𝒲𝒳𝒴𝒵𝟶𝟷𝟸𝟹𝟺𝟻𝟼𝟽𝟾𝟿";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(13, 176);
            label11.Name = "label11";
            label11.Size = new Size(736, 20);
            label11.TabIndex = 18;
            label11.Text = "May require Admin permissions. Changes will persist across icon changes unless an old shortcut set is restored.";
            // 
            // labelButton
            // 
            labelButton.Location = new Point(550, 223);
            labelButton.Name = "labelButton";
            labelButton.Size = new Size(203, 29);
            labelButton.TabIndex = 19;
            labelButton.Text = "Apply new labels";
            labelButton.UseVisualStyleBackColor = true;
            labelButton.Click += labelButton_Click;
            // 
            // endCharTextBox
            // 
            endCharTextBox.Enabled = false;
            endCharTextBox.Location = new Point(590, 93);
            endCharTextBox.Name = "endCharTextBox";
            endCharTextBox.PlaceholderText = "Text goes here...";
            endCharTextBox.Size = new Size(130, 27);
            endCharTextBox.TabIndex = 18;
            // 
            // startCharTextBox
            // 
            startCharTextBox.Enabled = false;
            startCharTextBox.Location = new Point(228, 94);
            startCharTextBox.Name = "startCharTextBox";
            startCharTextBox.PlaceholderText = "Text goes here...";
            startCharTextBox.Size = new Size(130, 27);
            startCharTextBox.TabIndex = 16;
            // 
            // charEndCheck
            // 
            charEndCheck.AutoSize = true;
            charEndCheck.Location = new Point(379, 96);
            charEndCheck.Name = "charEndCheck";
            charEndCheck.Size = new Size(205, 24);
            charEndCheck.TabIndex = 17;
            charEndCheck.Text = "Append characters to end:";
            charEndCheck.UseVisualStyleBackColor = true;
            charEndCheck.CheckedChanged += charEndCheck_CheckedChanged;
            // 
            // charStartCheck
            // 
            charStartCheck.AutoSize = true;
            charStartCheck.Location = new Point(17, 96);
            charStartCheck.Name = "charStartCheck";
            charStartCheck.Size = new Size(209, 24);
            charStartCheck.TabIndex = 15;
            charStartCheck.Text = "Append characters to start:";
            charStartCheck.UseVisualStyleBackColor = true;
            charStartCheck.CheckedChanged += charStartCheck_CheckedChanged;
            // 
            // defaultFontRadio
            // 
            defaultFontRadio.AutoSize = true;
            defaultFontRadio.Location = new Point(632, 27);
            defaultFontRadio.Name = "defaultFontRadio";
            defaultFontRadio.Size = new Size(79, 24);
            defaultFontRadio.TabIndex = 10;
            defaultFontRadio.Text = "Default";
            defaultFontRadio.UseVisualStyleBackColor = true;
            // 
            // serifLightRadio
            // 
            serifLightRadio.AutoSize = true;
            serifLightRadio.Location = new Point(265, 27);
            serifLightRadio.Name = "serifLightRadio";
            serifLightRadio.Size = new Size(60, 24);
            serifLightRadio.TabIndex = 4;
            serifLightRadio.Text = "Serif";
            serifLightRadio.UseVisualStyleBackColor = true;
            // 
            // italicBoldRadio
            // 
            italicBoldRadio.AutoSize = true;
            italicBoldRadio.Location = new Point(144, 57);
            italicBoldRadio.Name = "italicBoldRadio";
            italicBoldRadio.Size = new Size(113, 24);
            italicBoldRadio.TabIndex = 3;
            italicBoldRadio.Text = "Italics (bold)";
            italicBoldRadio.UseVisualStyleBackColor = true;
            // 
            // italicLightRadio
            // 
            italicLightRadio.AutoSize = true;
            italicLightRadio.Location = new Point(144, 27);
            italicLightRadio.Name = "italicLightRadio";
            italicLightRadio.Size = new Size(68, 24);
            italicLightRadio.TabIndex = 2;
            italicLightRadio.Text = "Italics";
            italicLightRadio.UseVisualStyleBackColor = true;
            // 
            // serifBoldRadio
            // 
            serifBoldRadio.AutoSize = true;
            serifBoldRadio.Location = new Point(265, 57);
            serifBoldRadio.Name = "serifBoldRadio";
            serifBoldRadio.Size = new Size(105, 24);
            serifBoldRadio.TabIndex = 5;
            serifBoldRadio.Text = "Serif (bold)";
            serifBoldRadio.UseVisualStyleBackColor = true;
            // 
            // circleTextRadio
            // 
            circleTextRadio.AutoSize = true;
            circleTextRadio.Location = new Point(511, 57);
            circleTextRadio.Name = "circleTextRadio";
            circleTextRadio.Size = new Size(73, 24);
            circleTextRadio.TabIndex = 9;
            circleTextRadio.Text = "Circles";
            circleTextRadio.UseVisualStyleBackColor = true;
            // 
            // medievalTextRadio
            // 
            medievalTextRadio.AutoSize = true;
            medievalTextRadio.Location = new Point(511, 27);
            medievalTextRadio.Name = "medievalTextRadio";
            medievalTextRadio.Size = new Size(91, 24);
            medievalTextRadio.TabIndex = 8;
            medievalTextRadio.Text = "Medieval";
            medievalTextRadio.UseVisualStyleBackColor = true;
            // 
            // thinTextRadio
            // 
            thinTextRadio.AutoSize = true;
            thinTextRadio.Location = new Point(379, 57);
            thinTextRadio.Name = "thinTextRadio";
            thinTextRadio.Size = new Size(58, 24);
            thinTextRadio.TabIndex = 7;
            thinTextRadio.Text = "Thin";
            thinTextRadio.UseVisualStyleBackColor = true;
            // 
            // linedTextRadio
            // 
            linedTextRadio.AutoSize = true;
            linedTextRadio.Location = new Point(379, 27);
            linedTextRadio.Name = "linedTextRadio";
            linedTextRadio.Size = new Size(116, 24);
            linedTextRadio.TabIndex = 6;
            linedTextRadio.Text = "Double lined";
            linedTextRadio.UseVisualStyleBackColor = true;
            // 
            // cursiveLightRadio
            // 
            cursiveLightRadio.AutoSize = true;
            cursiveLightRadio.Checked = true;
            cursiveLightRadio.Location = new Point(17, 27);
            cursiveLightRadio.Name = "cursiveLightRadio";
            cursiveLightRadio.Size = new Size(77, 24);
            cursiveLightRadio.TabIndex = 0;
            cursiveLightRadio.TabStop = true;
            cursiveLightRadio.Text = "Cursive";
            cursiveLightRadio.UseVisualStyleBackColor = true;
            // 
            // cursiveBoldRadio
            // 
            cursiveBoldRadio.AutoSize = true;
            cursiveBoldRadio.Location = new Point(17, 57);
            cursiveBoldRadio.Name = "cursiveBoldRadio";
            cursiveBoldRadio.Size = new Size(122, 24);
            cursiveBoldRadio.TabIndex = 1;
            cursiveBoldRadio.Text = "Cursive (bold)";
            cursiveBoldRadio.UseVisualStyleBackColor = true;
            // 
            // tabPageIcons
            // 
            tabPageIcons.BackColor = Color.WhiteSmoke;
            tabPageIcons.Controls.Add(arrowDisplay);
            tabPageIcons.Controls.Add(importIconSetButton);
            tabPageIcons.Controls.Add(listView1);
            tabPageIcons.Controls.Add(detailsBox);
            tabPageIcons.Controls.Add(wallpaperDisplay);
            tabPageIcons.Controls.Add(iconSetListBox);
            tabPageIcons.Controls.Add(applyIconSetButton);
            tabPageIcons.Location = new Point(4, 29);
            tabPageIcons.Name = "tabPageIcons";
            tabPageIcons.Padding = new Padding(3);
            tabPageIcons.Size = new Size(770, 296);
            tabPageIcons.TabIndex = 2;
            tabPageIcons.Text = "Icon Sets";
            // 
            // arrowDisplay
            // 
            arrowDisplay.BackColor = Color.Gainsboro;
            arrowDisplay.BackgroundImageLayout = ImageLayout.Stretch;
            arrowDisplay.Location = new Point(411, 69);
            arrowDisplay.Name = "arrowDisplay";
            arrowDisplay.Size = new Size(75, 75);
            arrowDisplay.TabIndex = 33;
            arrowDisplay.TabStop = false;
            arrowDisplay.MouseEnter += ArrowDisplay_MouseEnter;
            arrowDisplay.MouseLeave += ArrowDisplay_MouseLeave;
            // 
            // importIconSetButton
            // 
            importIconSetButton.Location = new Point(16, 249);
            importIconSetButton.Name = "importIconSetButton";
            importIconSetButton.Size = new Size(191, 29);
            importIconSetButton.TabIndex = 2;
            importIconSetButton.Text = "Import icon set";
            importIconSetButton.UseVisualStyleBackColor = true;
            importIconSetButton.Click += importIconSetButton_Click;
            // 
            // listView1
            // 
            listView1.BackColor = Color.Gainsboro;
            listView1.BorderStyle = BorderStyle.FixedSingle;
            listView1.GridLines = true;
            listView1.HideSelection = true;
            listView1.LargeImageList = imageList1;
            listView1.Location = new Point(213, 19);
            listView1.MultiSelect = false;
            listView1.Name = "listView1";
            listView1.Size = new Size(192, 259);
            listView1.SmallImageList = imageList1;
            listView1.TabIndex = 3;
            listView1.TileSize = new Size(80, 80);
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.Tile;
            // 
            // detailsBox
            // 
            detailsBox.BackColor = SystemColors.Info;
            detailsBox.BorderStyle = BorderStyle.FixedSingle;
            detailsBox.Location = new Point(411, 151);
            detailsBox.Name = "detailsBox";
            detailsBox.ReadOnly = true;
            detailsBox.ScrollBars = RichTextBoxScrollBars.Vertical;
            detailsBox.Size = new Size(348, 127);
            detailsBox.TabIndex = 4;
            detailsBox.Text = "If the icon set has details, they'll show up here.\n\nNote: Custom arrows won't show until you initialize the custom arrow path with the button on the next page. Try hovering the arrow in the preview!";
            // 
            // wallpaperDisplay
            // 
            wallpaperDisplay.BackColor = Color.Gainsboro;
            wallpaperDisplay.BackgroundImageLayout = ImageLayout.Stretch;
            wallpaperDisplay.BorderStyle = BorderStyle.FixedSingle;
            wallpaperDisplay.Location = new Point(411, 19);
            wallpaperDisplay.Name = "wallpaperDisplay";
            wallpaperDisplay.Size = new Size(212, 125);
            wallpaperDisplay.TabIndex = 28;
            wallpaperDisplay.TabStop = false;
            // 
            // iconSetListBox
            // 
            iconSetListBox.BackColor = SystemColors.Window;
            iconSetListBox.FormattingEnabled = true;
            iconSetListBox.Location = new Point(16, 19);
            iconSetListBox.Name = "iconSetListBox";
            iconSetListBox.Size = new Size(191, 224);
            iconSetListBox.Sorted = true;
            iconSetListBox.TabIndex = 0;
            iconSetListBox.SelectedIndexChanged += iconSetListBox_SelectedIndexChanged;
            // 
            // applyIconSetButton
            // 
            applyIconSetButton.Enabled = false;
            applyIconSetButton.Location = new Point(631, 19);
            applyIconSetButton.Name = "applyIconSetButton";
            applyIconSetButton.Size = new Size(128, 29);
            applyIconSetButton.TabIndex = 5;
            applyIconSetButton.Text = "Apply icon set";
            applyIconSetButton.UseVisualStyleBackColor = true;
            applyIconSetButton.Click += applyIconSetButton_Click;
            // 
            // tabPageManage
            // 
            tabPageManage.BackColor = Color.WhiteSmoke;
            tabPageManage.Controls.Add(label10);
            tabPageManage.Controls.Add(linkLabel1);
            tabPageManage.Controls.Add(refreshButton);
            tabPageManage.Controls.Add(label4);
            tabPageManage.Controls.Add(backupButton);
            tabPageManage.Controls.Add(label3);
            tabPageManage.Controls.Add(explorerButton);
            tabPageManage.Controls.Add(validateButton);
            tabPageManage.Controls.Add(pathButton);
            tabPageManage.Controls.Add(label1);
            tabPageManage.Controls.Add(label2);
            tabPageManage.Location = new Point(4, 29);
            tabPageManage.Name = "tabPageManage";
            tabPageManage.Padding = new Padding(3);
            tabPageManage.Size = new Size(770, 296);
            tabPageManage.TabIndex = 1;
            tabPageManage.Text = "Desktop Management";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 10.2F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label10.Location = new Point(226, 21);
            label10.Name = "label10";
            label10.Size = new Size(277, 23);
            label10.TabIndex = 21;
            label10.Text = "An icon manager by duralumin-here";
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.Location = new Point(466, 251);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(288, 20);
            linkLabel1.TabIndex = 19;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "Need help? Check out the documentation!";
            linkLabel1.TextAlign = ContentAlignment.TopRight;
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            // 
            // refreshButton
            // 
            refreshButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            refreshButton.Location = new Point(581, 21);
            refreshButton.Name = "refreshButton";
            refreshButton.Size = new Size(173, 29);
            refreshButton.TabIndex = 18;
            refreshButton.Text = "Refresh desktop";
            refreshButton.UseVisualStyleBackColor = true;
            refreshButton.Click += refreshButton_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(17, 14);
            label4.Name = "label4";
            label4.Size = new Size(213, 31);
            label4.TabIndex = 17;
            label4.Text = "Welcome to wDIM!";
            // 
            // backupButton
            // 
            backupButton.Location = new Point(17, 183);
            backupButton.Name = "backupButton";
            backupButton.Size = new Size(212, 29);
            backupButton.TabIndex = 15;
            backupButton.Text = "Back up shortcuts";
            backupButton.UseVisualStyleBackColor = true;
            backupButton.Click += backupButton_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(17, 212);
            label3.Name = "label3";
            label3.Size = new Size(512, 20);
            label3.TabIndex = 16;
            label3.Text = "Saves desktop shortcuts and current icon set. (Physical location is not saved.)";
            // 
            // explorerButton
            // 
            explorerButton.Location = new Point(581, 56);
            explorerButton.Name = "explorerButton";
            explorerButton.Size = new Size(173, 29);
            explorerButton.TabIndex = 14;
            explorerButton.Text = "Restart Explorer";
            explorerButton.UseVisualStyleBackColor = true;
            explorerButton.Click += explorerButton_Click;
            // 
            // validateButton
            // 
            validateButton.Location = new Point(17, 63);
            validateButton.Name = "validateButton";
            validateButton.Size = new Size(212, 29);
            validateButton.TabIndex = 5;
            validateButton.Text = "Validate desktop";
            validateButton.UseVisualStyleBackColor = true;
            validateButton.Click += validateButton_Click;
            // 
            // pathButton
            // 
            pathButton.Location = new Point(17, 122);
            pathButton.Name = "pathButton";
            pathButton.Size = new Size(212, 29);
            pathButton.TabIndex = 6;
            pathButton.Text = "Initialize icon paths";
            pathButton.UseVisualStyleBackColor = true;
            pathButton.Click += pathButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(17, 93);
            label1.Name = "label1";
            label1.Size = new Size(459, 20);
            label1.TabIndex = 7;
            label1.Text = "Checks if non-shortcuts exist on desktop and helps you handle them.";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(17, 152);
            label2.Name = "label2";
            label2.Size = new Size(737, 20);
            label2.TabIndex = 8;
            label2.Text = "Automatically applies custom icon paths to shortcuts. (May take a moment. May require Administrator access.)";
            // 
            // tabControl1
            // 
            tabControl1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabControl1.Controls.Add(tabPageManage);
            tabControl1.Controls.Add(tabPageIcons);
            tabControl1.Controls.Add(tabPageLabels);
            tabControl1.Controls.Add(tabPageArrows);
            tabControl1.Controls.Add(tabPageSettings);
            tabControl1.Location = new Point(12, 12);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(778, 329);
            tabControl1.TabIndex = 14;
            tabControl1.SelectedIndexChanged += TabControl1_SelectedIndexChanged;
            // 
            // MainMenu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLight;
            ClientSize = new Size(802, 353);
            Controls.Add(tabControl1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "MainMenu";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "wDIM";
            tabPageSettings.ResumeLayout(false);
            tabPageSettings.PerformLayout();
            tabPageArrows.ResumeLayout(false);
            tabPageArrows.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)lightSlide).EndInit();
            ((System.ComponentModel.ISupportInitialize)satSlide).EndInit();
            ((System.ComponentModel.ISupportInitialize)hueSlide).EndInit();
            ((System.ComponentModel.ISupportInitialize)arrowShowBox).EndInit();
            tabPageLabels.ResumeLayout(false);
            tabPageLabels.PerformLayout();
            tabPageIcons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)arrowDisplay).EndInit();
            ((System.ComponentModel.ISupportInitialize)wallpaperDisplay).EndInit();
            tabPageManage.ResumeLayout(false);
            tabPageManage.PerformLayout();
            tabControl1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private ImageList imageList1;
        private TabPage tabPageSettings;
        private Button button3;
        private Button restoreSettingsButton;
        private Button button2;
        private Button shortcutToPersonalButton;
        private CheckBox defaultWallpaperCheck;
        private Button defaultWallpaperButton;
        private Label wallpaperPathLabel;
        private CheckBox explorerCheck;
        private CheckBox wallpaperCheck;
        private TabPage tabPageArrows;
        private Button restoreArrowButton;
        private Button resetColorButton;
        private Button arrowSaveButton;
        private Label label8;
        private Label label5;
        private Label label7;
        private Button arrowApplyButton;
        private Button ArrowApplyMainMenuButton;
        private TextBox lightBox;
        private TextBox satBox;
        private TextBox hueBox;
        private Label label9;
        private ComboBox comboBox1;
        private TrackBar lightSlide;
        private TrackBar satSlide;
        private TrackBar hueSlide;
        private PictureBox arrowShowBox;
        private TabPage tabPageLabels;
        private Label label6;
        private Button labelRestoreButton;
        private Label alphabetLabel;
        private Label label11;
        private Button labelButton;
        private TextBox endCharTextBox;
        private TextBox startCharTextBox;
        private CheckBox charEndCheck;
        private CheckBox charStartCheck;
        private RadioButton defaultFontRadio;
        private RadioButton serifLightRadio;
        private RadioButton italicBoldRadio;
        private RadioButton italicLightRadio;
        private RadioButton serifBoldRadio;
        private RadioButton circleTextRadio;
        private RadioButton medievalTextRadio;
        private RadioButton thinTextRadio;
        private RadioButton linedTextRadio;
        private RadioButton cursiveLightRadio;
        private RadioButton cursiveBoldRadio;
        private TabPage tabPageIcons;
        private PictureBox arrowDisplay;
        private Button importIconSetButton;
        private ListView listView1;
        private RichTextBox detailsBox;
        private PictureBox wallpaperDisplay;
        private ListBox iconSetListBox;
        private Button applyIconSetButton;
        private TabPage tabPageManage;
        private Button refreshButton;
        private Label label4;
        private Button backupButton;
        private Label label3;
        private Button explorerButton;
        private Button validateButton;
        private Button pathButton;
        private Label label1;
        private Label label2;
        private TabControl tabControl1;
        private LinkLabel linkLabel1;
        private Label label10;
        private Button arrowPathButton;
    }
}
