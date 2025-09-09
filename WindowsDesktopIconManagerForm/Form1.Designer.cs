namespace WindowsDesktopIconManagerForm
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            tabPageSettings = new TabPage();
            lightDarkCheck = new CheckBox();
            defaultWallpaperCheck = new CheckBox();
            defaultWallpaperButton = new Button();
            wallpaperPathLabel = new Label();
            label12 = new Label();
            explorerCheck = new CheckBox();
            arrowCheck = new CheckBox();
            wallpaperCheck = new CheckBox();
            tabPageArrows = new TabPage();
            arrowApplyButton = new Button();
            resetColorButton = new Button();
            lightBox = new TextBox();
            satBox = new TextBox();
            hueBox = new TextBox();
            label9 = new Label();
            comboBox1 = new ComboBox();
            lightSlide = new TrackBar();
            label8 = new Label();
            satSlide = new TrackBar();
            label5 = new Label();
            hueSlide = new TrackBar();
            restoreArrowButton = new Button();
            arrowSaveButton = new Button();
            label7 = new Label();
            arrowShowBox = new PictureBox();
            tabPageLabels = new TabPage();
            labelRestoreButton = new Button();
            alphabetLabel = new Label();
            label11 = new Label();
            labelButton = new Button();
            label10 = new Label();
            endCharTextBox = new TextBox();
            startCharTextBox = new TextBox();
            charEndCheck = new CheckBox();
            charStartCheck = new CheckBox();
            defaultFontRadio = new RadioButton();
            serifLightRadio = new RadioButton();
            italicBoldRadio = new RadioButton();
            italicLightRadio = new RadioButton();
            serifBoldVideo = new RadioButton();
            circleTextRadio = new RadioButton();
            medievalTextRadio = new RadioButton();
            thinTextRadio = new RadioButton();
            linedTextRadio = new RadioButton();
            cursiveLightRadio = new RadioButton();
            cursiveBoldRadio = new RadioButton();
            tabPageIcons = new TabPage();
            label6 = new Label();
            button5 = new Button();
            tabPageManage = new TabPage();
            label4 = new Label();
            backupButton = new Button();
            label3 = new Label();
            explorerButton = new Button();
            refreshButton = new Button();
            validateButton = new Button();
            pathButton = new Button();
            label1 = new Label();
            label2 = new Label();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            label14 = new Label();
            button3 = new Button();
            label13 = new Label();
            checkBox2 = new CheckBox();
            button2 = new Button();
            shortcutToPersonalButton = new Button();
            tabPageSettings.SuspendLayout();
            tabPageArrows.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)lightSlide).BeginInit();
            ((System.ComponentModel.ISupportInitialize)satSlide).BeginInit();
            ((System.ComponentModel.ISupportInitialize)hueSlide).BeginInit();
            ((System.ComponentModel.ISupportInitialize)arrowShowBox).BeginInit();
            tabPageLabels.SuspendLayout();
            tabPageIcons.SuspendLayout();
            tabPageManage.SuspendLayout();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            SuspendLayout();
            // 
            // tabPageSettings
            // 
            tabPageSettings.BackColor = Color.WhiteSmoke;
            tabPageSettings.Controls.Add(lightDarkCheck);
            tabPageSettings.Controls.Add(defaultWallpaperCheck);
            tabPageSettings.Controls.Add(defaultWallpaperButton);
            tabPageSettings.Controls.Add(wallpaperPathLabel);
            tabPageSettings.Controls.Add(label12);
            tabPageSettings.Controls.Add(explorerCheck);
            tabPageSettings.Controls.Add(arrowCheck);
            tabPageSettings.Controls.Add(wallpaperCheck);
            tabPageSettings.Location = new Point(4, 29);
            tabPageSettings.Name = "tabPageSettings";
            tabPageSettings.Padding = new Padding(3);
            tabPageSettings.Size = new Size(770, 346);
            tabPageSettings.TabIndex = 6;
            tabPageSettings.Text = "Settings";
            tabPageSettings.Click += tabPageSettings_Click;
            // 
            // lightDarkCheck
            // 
            lightDarkCheck.AutoSize = true;
            lightDarkCheck.Location = new Point(16, 210);
            lightDarkCheck.Name = "lightDarkCheck";
            lightDarkCheck.Size = new Size(318, 24);
            lightDarkCheck.TabIndex = 21;
            lightDarkCheck.Text = "Enable light/dark mode sets (experimental)";
            lightDarkCheck.UseVisualStyleBackColor = true;
            // 
            // defaultWallpaperCheck
            // 
            defaultWallpaperCheck.AutoSize = true;
            defaultWallpaperCheck.Location = new Point(39, 88);
            defaultWallpaperCheck.Name = "defaultWallpaperCheck";
            defaultWallpaperCheck.Size = new Size(438, 24);
            defaultWallpaperCheck.TabIndex = 20;
            defaultWallpaperCheck.Text = "Apply default wallpaper when set does not contain wallpaper";
            defaultWallpaperCheck.UseVisualStyleBackColor = true;
            defaultWallpaperCheck.CheckedChanged += defaultWallpaperCheck_CheckedChanged;
            // 
            // defaultWallpaperButton
            // 
            defaultWallpaperButton.Enabled = false;
            defaultWallpaperButton.Location = new Point(38, 115);
            defaultWallpaperButton.Name = "defaultWallpaperButton";
            defaultWallpaperButton.Size = new Size(201, 29);
            defaultWallpaperButton.TabIndex = 19;
            defaultWallpaperButton.Text = "Select Default Wallpaper...";
            defaultWallpaperButton.UseVisualStyleBackColor = true;
            // 
            // wallpaperPathLabel
            // 
            wallpaperPathLabel.AutoSize = true;
            wallpaperPathLabel.Enabled = false;
            wallpaperPathLabel.Location = new Point(245, 120);
            wallpaperPathLabel.Name = "wallpaperPathLabel";
            wallpaperPathLabel.Size = new Size(86, 20);
            wallpaperPathLabel.TabIndex = 18;
            wallpaperPathLabel.Text = "No path set";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label12.Location = new Point(11, 17);
            label12.Name = "label12";
            label12.Size = new Size(98, 31);
            label12.TabIndex = 16;
            label12.Text = "Settings";
            // 
            // explorerCheck
            // 
            explorerCheck.AutoSize = true;
            explorerCheck.Location = new Point(37, 180);
            explorerCheck.Name = "explorerCheck";
            explorerCheck.Size = new Size(731, 24);
            explorerCheck.TabIndex = 2;
            explorerCheck.Text = "Restart Windows Explorer when applying icon set (may be disruptive; required for arrow changes to show)";
            explorerCheck.UseVisualStyleBackColor = true;
            // 
            // arrowCheck
            // 
            arrowCheck.AutoSize = true;
            arrowCheck.Location = new Point(16, 150);
            arrowCheck.Name = "arrowCheck";
            arrowCheck.Size = new Size(604, 24);
            arrowCheck.TabIndex = 1;
            arrowCheck.Text = "Automatically apply shortcut arrows included in icon sets (requires Admin permissions)";
            arrowCheck.UseVisualStyleBackColor = true;
            arrowCheck.CheckedChanged += arrowCheck_CheckedChanged;
            // 
            // wallpaperCheck
            // 
            wallpaperCheck.AutoSize = true;
            wallpaperCheck.Checked = true;
            wallpaperCheck.CheckState = CheckState.Checked;
            wallpaperCheck.Location = new Point(16, 59);
            wallpaperCheck.Name = "wallpaperCheck";
            wallpaperCheck.Size = new Size(378, 24);
            wallpaperCheck.TabIndex = 0;
            wallpaperCheck.Text = "Automatically apply wallpapers included in icon sets";
            wallpaperCheck.UseVisualStyleBackColor = true;
            // 
            // tabPageArrows
            // 
            tabPageArrows.BackColor = Color.WhiteSmoke;
            tabPageArrows.Controls.Add(arrowApplyButton);
            tabPageArrows.Controls.Add(resetColorButton);
            tabPageArrows.Controls.Add(lightBox);
            tabPageArrows.Controls.Add(satBox);
            tabPageArrows.Controls.Add(hueBox);
            tabPageArrows.Controls.Add(label9);
            tabPageArrows.Controls.Add(comboBox1);
            tabPageArrows.Controls.Add(lightSlide);
            tabPageArrows.Controls.Add(label8);
            tabPageArrows.Controls.Add(satSlide);
            tabPageArrows.Controls.Add(label5);
            tabPageArrows.Controls.Add(hueSlide);
            tabPageArrows.Controls.Add(restoreArrowButton);
            tabPageArrows.Controls.Add(arrowSaveButton);
            tabPageArrows.Controls.Add(label7);
            tabPageArrows.Controls.Add(arrowShowBox);
            tabPageArrows.Location = new Point(4, 29);
            tabPageArrows.Name = "tabPageArrows";
            tabPageArrows.Padding = new Padding(3);
            tabPageArrows.Size = new Size(770, 346);
            tabPageArrows.TabIndex = 5;
            tabPageArrows.Text = "Shortcut Arrows";
            // 
            // arrowApplyButton
            // 
            arrowApplyButton.Location = new Point(27, 300);
            arrowApplyButton.Name = "arrowApplyButton";
            arrowApplyButton.Size = new Size(152, 29);
            arrowApplyButton.TabIndex = 9;
            arrowApplyButton.Text = "Apply Arrows";
            arrowApplyButton.UseVisualStyleBackColor = true;
            arrowApplyButton.Click += arrowApplyButton_Click;
            // 
            // resetColorButton
            // 
            resetColorButton.Location = new Point(628, 90);
            resetColorButton.Name = "resetColorButton";
            resetColorButton.Size = new Size(126, 29);
            resetColorButton.TabIndex = 7;
            resetColorButton.Text = "Reset Editor";
            resetColorButton.UseVisualStyleBackColor = true;
            resetColorButton.Click += resetColorButton_Click;
            // 
            // lightBox
            // 
            lightBox.Location = new Point(541, 228);
            lightBox.Name = "lightBox";
            lightBox.Size = new Size(64, 27);
            lightBox.TabIndex = 6;
            lightBox.TextChanged += lightBox_TextChanged;
            // 
            // satBox
            // 
            satBox.Location = new Point(541, 140);
            satBox.Name = "satBox";
            satBox.Size = new Size(64, 27);
            satBox.TabIndex = 4;
            satBox.TextChanged += satBox_TextChanged;
            // 
            // hueBox
            // 
            hueBox.Location = new Point(541, 54);
            hueBox.Name = "hueBox";
            hueBox.Size = new Size(64, 27);
            hueBox.TabIndex = 2;
            hueBox.TextChanged += hueBox_TextChanged;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(29, 216);
            label9.Name = "label9";
            label9.Size = new Size(148, 20);
            label9.TabIndex = 41;
            label9.Text = "Select an arrow style:";
            // 
            // comboBox1
            // 
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Blank/No Arrow", "Curved (Transparent)", "Curved (Black)", "Curved (White)", "Straight (Transparent)", "Straight (Black)", "Straight (White)" });
            comboBox1.Location = new Point(27, 239);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(190, 28);
            comboBox1.TabIndex = 0;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // lightSlide
            // 
            lightSlide.LargeChange = 10;
            lightSlide.Location = new Point(248, 219);
            lightSlide.Maximum = 98;
            lightSlide.Minimum = 2;
            lightSlide.Name = "lightSlide";
            lightSlide.Size = new Size(276, 56);
            lightSlide.TabIndex = 5;
            lightSlide.TickFrequency = 0;
            lightSlide.TickStyle = TickStyle.Both;
            lightSlide.Value = 50;
            lightSlide.ValueChanged += lightSlide_ValueChanged;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(248, 196);
            label8.Name = "label8";
            label8.Size = new Size(70, 20);
            label8.TabIndex = 38;
            label8.Text = "Lightness";
            // 
            // satSlide
            // 
            satSlide.LargeChange = 10;
            satSlide.Location = new Point(248, 132);
            satSlide.Maximum = 100;
            satSlide.Minimum = 1;
            satSlide.Name = "satSlide";
            satSlide.Size = new Size(276, 56);
            satSlide.TabIndex = 3;
            satSlide.TickFrequency = 0;
            satSlide.TickStyle = TickStyle.Both;
            satSlide.Value = 100;
            satSlide.ValueChanged += satSlide_ValueChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(248, 110);
            label5.Name = "label5";
            label5.Size = new Size(77, 20);
            label5.TabIndex = 36;
            label5.Text = "Saturation";
            // 
            // hueSlide
            // 
            hueSlide.BackColor = SystemColors.Control;
            hueSlide.LargeChange = 10;
            hueSlide.Location = new Point(248, 45);
            hueSlide.Maximum = 360;
            hueSlide.Name = "hueSlide";
            hueSlide.Size = new Size(276, 56);
            hueSlide.TabIndex = 1;
            hueSlide.TickFrequency = 0;
            hueSlide.TickStyle = TickStyle.Both;
            hueSlide.ValueChanged += hueSlide_ValueChanged;
            // 
            // restoreArrowButton
            // 
            restoreArrowButton.Location = new Point(185, 300);
            restoreArrowButton.Name = "restoreArrowButton";
            restoreArrowButton.Size = new Size(152, 29);
            restoreArrowButton.TabIndex = 10;
            restoreArrowButton.Text = "Restore Defaults";
            restoreArrowButton.UseVisualStyleBackColor = true;
            restoreArrowButton.Click += restoreArrowButton_Click;
            // 
            // arrowSaveButton
            // 
            arrowSaveButton.Enabled = false;
            arrowSaveButton.Location = new Point(628, 54);
            arrowSaveButton.Name = "arrowSaveButton";
            arrowSaveButton.Size = new Size(126, 29);
            arrowSaveButton.TabIndex = 8;
            arrowSaveButton.Text = "Save Arrow";
            arrowSaveButton.UseVisualStyleBackColor = true;
            arrowSaveButton.Click += arrowSaveButton_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(248, 26);
            label7.Name = "label7";
            label7.Size = new Size(36, 20);
            label7.TabIndex = 31;
            label7.Text = "Hue";
            // 
            // arrowShowBox
            // 
            arrowShowBox.BackColor = Color.LightGray;
            arrowShowBox.BackgroundImageLayout = ImageLayout.Stretch;
            arrowShowBox.BorderStyle = BorderStyle.Fixed3D;
            arrowShowBox.Location = new Point(29, 35);
            arrowShowBox.Name = "arrowShowBox";
            arrowShowBox.Size = new Size(150, 150);
            arrowShowBox.TabIndex = 30;
            arrowShowBox.TabStop = false;
            // 
            // tabPageLabels
            // 
            tabPageLabels.BackColor = Color.WhiteSmoke;
            tabPageLabels.Controls.Add(labelRestoreButton);
            tabPageLabels.Controls.Add(alphabetLabel);
            tabPageLabels.Controls.Add(label11);
            tabPageLabels.Controls.Add(labelButton);
            tabPageLabels.Controls.Add(label10);
            tabPageLabels.Controls.Add(endCharTextBox);
            tabPageLabels.Controls.Add(startCharTextBox);
            tabPageLabels.Controls.Add(charEndCheck);
            tabPageLabels.Controls.Add(charStartCheck);
            tabPageLabels.Controls.Add(defaultFontRadio);
            tabPageLabels.Controls.Add(serifLightRadio);
            tabPageLabels.Controls.Add(italicBoldRadio);
            tabPageLabels.Controls.Add(italicLightRadio);
            tabPageLabels.Controls.Add(serifBoldVideo);
            tabPageLabels.Controls.Add(circleTextRadio);
            tabPageLabels.Controls.Add(medievalTextRadio);
            tabPageLabels.Controls.Add(thinTextRadio);
            tabPageLabels.Controls.Add(linedTextRadio);
            tabPageLabels.Controls.Add(cursiveLightRadio);
            tabPageLabels.Controls.Add(cursiveBoldRadio);
            tabPageLabels.Location = new Point(4, 29);
            tabPageLabels.Name = "tabPageLabels";
            tabPageLabels.Padding = new Padding(3);
            tabPageLabels.Size = new Size(770, 346);
            tabPageLabels.TabIndex = 4;
            tabPageLabels.Text = "Customize Labels";
            // 
            // labelRestoreButton
            // 
            labelRestoreButton.Location = new Point(590, 300);
            labelRestoreButton.Name = "labelRestoreButton";
            labelRestoreButton.Size = new Size(163, 29);
            labelRestoreButton.TabIndex = 20;
            labelRestoreButton.Text = "Restore Labels";
            labelRestoreButton.UseVisualStyleBackColor = true;
            // 
            // alphabetLabel
            // 
            alphabetLabel.AutoSize = true;
            alphabetLabel.Location = new Point(13, 189);
            alphabetLabel.Name = "alphabetLabel";
            alphabetLabel.Size = new Size(628, 20);
            alphabetLabel.TabIndex = 19;
            alphabetLabel.Tag = "cursive";
            alphabetLabel.Text = "𝒶𝒷𝒸𝒹𝑒𝒻𝑔𝒽𝒾𝒿𝓀𝓁𝓂𝓃𝑜𝓅𝓆𝓇𝓈𝓉𝓊𝓋𝓌𝓍𝓎𝓏𝒜𝐵𝒞𝒟𝐸𝐹𝒢𝐻𝐼𝒥𝒦𝐿𝑀𝒩𝒪𝒫𝒬𝑅𝒮𝒯𝒰𝒱𝒲𝒳𝒴𝒵𝟶𝟷𝟸𝟹𝟺𝟻𝟼𝟽𝟾𝟿";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(14, 47);
            label11.Name = "label11";
            label11.Size = new Size(736, 20);
            label11.TabIndex = 18;
            label11.Text = "May require Admin permissions. Changes will persist across icon changes unless an old shortcut set is restored.";
            // 
            // labelButton
            // 
            labelButton.Location = new Point(590, 265);
            labelButton.Name = "labelButton";
            labelButton.Size = new Size(163, 29);
            labelButton.TabIndex = 15;
            labelButton.Text = "Convert Labels";
            labelButton.UseVisualStyleBackColor = true;
            labelButton.Click += labelButton_Click;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label10.Location = new Point(11, 12);
            label10.Name = "label10";
            label10.Size = new Size(223, 31);
            label10.TabIndex = 15;
            label10.Text = "Style shortcut labels";
            // 
            // endCharTextBox
            // 
            endCharTextBox.Location = new Point(590, 146);
            endCharTextBox.Name = "endCharTextBox";
            endCharTextBox.Size = new Size(130, 27);
            endCharTextBox.TabIndex = 14;
            // 
            // startCharTextBox
            // 
            startCharTextBox.Location = new Point(228, 147);
            startCharTextBox.Name = "startCharTextBox";
            startCharTextBox.Size = new Size(130, 27);
            startCharTextBox.TabIndex = 12;
            // 
            // charEndCheck
            // 
            charEndCheck.AutoSize = true;
            charEndCheck.Location = new Point(379, 149);
            charEndCheck.Name = "charEndCheck";
            charEndCheck.Size = new Size(205, 24);
            charEndCheck.TabIndex = 13;
            charEndCheck.Text = "Append characters to end:";
            charEndCheck.UseVisualStyleBackColor = true;
            // 
            // charStartCheck
            // 
            charStartCheck.AutoSize = true;
            charStartCheck.Location = new Point(17, 149);
            charStartCheck.Name = "charStartCheck";
            charStartCheck.Size = new Size(209, 24);
            charStartCheck.TabIndex = 11;
            charStartCheck.Text = "Append characters to start:";
            charStartCheck.UseVisualStyleBackColor = true;
            // 
            // defaultFontRadio
            // 
            defaultFontRadio.AutoSize = true;
            defaultFontRadio.Location = new Point(632, 80);
            defaultFontRadio.Name = "defaultFontRadio";
            defaultFontRadio.Size = new Size(79, 24);
            defaultFontRadio.TabIndex = 10;
            defaultFontRadio.Text = "Default";
            defaultFontRadio.UseVisualStyleBackColor = true;
            defaultFontRadio.CheckedChanged += defaultFontRadio_CheckedChanged;
            // 
            // serifLightRadio
            // 
            serifLightRadio.AutoSize = true;
            serifLightRadio.Location = new Point(265, 80);
            serifLightRadio.Name = "serifLightRadio";
            serifLightRadio.Size = new Size(60, 24);
            serifLightRadio.TabIndex = 4;
            serifLightRadio.Text = "Serif";
            serifLightRadio.UseVisualStyleBackColor = true;
            serifLightRadio.CheckedChanged += serifLightRadio_CheckedChanged;
            // 
            // italicBoldRadio
            // 
            italicBoldRadio.AutoSize = true;
            italicBoldRadio.Location = new Point(144, 110);
            italicBoldRadio.Name = "italicBoldRadio";
            italicBoldRadio.Size = new Size(113, 24);
            italicBoldRadio.TabIndex = 3;
            italicBoldRadio.Text = "Italics (bold)";
            italicBoldRadio.UseVisualStyleBackColor = true;
            italicBoldRadio.CheckedChanged += italicBoldRadio_CheckedChanged;
            // 
            // italicLightRadio
            // 
            italicLightRadio.AutoSize = true;
            italicLightRadio.Location = new Point(144, 80);
            italicLightRadio.Name = "italicLightRadio";
            italicLightRadio.Size = new Size(68, 24);
            italicLightRadio.TabIndex = 2;
            italicLightRadio.Text = "Italics";
            italicLightRadio.UseVisualStyleBackColor = true;
            italicLightRadio.CheckedChanged += italicLightRadio_CheckedChanged;
            // 
            // serifBoldVideo
            // 
            serifBoldVideo.AutoSize = true;
            serifBoldVideo.Location = new Point(265, 110);
            serifBoldVideo.Name = "serifBoldVideo";
            serifBoldVideo.Size = new Size(105, 24);
            serifBoldVideo.TabIndex = 5;
            serifBoldVideo.Text = "Serif (bold)";
            serifBoldVideo.UseVisualStyleBackColor = true;
            serifBoldVideo.CheckedChanged += serifBoldVideo_CheckedChanged;
            // 
            // circleTextRadio
            // 
            circleTextRadio.AutoSize = true;
            circleTextRadio.Location = new Point(511, 110);
            circleTextRadio.Name = "circleTextRadio";
            circleTextRadio.Size = new Size(73, 24);
            circleTextRadio.TabIndex = 9;
            circleTextRadio.Text = "Circles";
            circleTextRadio.UseVisualStyleBackColor = true;
            circleTextRadio.CheckedChanged += circleTextRadio_CheckedChanged;
            // 
            // medievalTextRadio
            // 
            medievalTextRadio.AutoSize = true;
            medievalTextRadio.Location = new Point(511, 80);
            medievalTextRadio.Name = "medievalTextRadio";
            medievalTextRadio.Size = new Size(91, 24);
            medievalTextRadio.TabIndex = 8;
            medievalTextRadio.Text = "Medieval";
            medievalTextRadio.UseVisualStyleBackColor = true;
            medievalTextRadio.CheckedChanged += medievalTextRadio_CheckedChanged;
            // 
            // thinTextRadio
            // 
            thinTextRadio.AutoSize = true;
            thinTextRadio.Location = new Point(379, 110);
            thinTextRadio.Name = "thinTextRadio";
            thinTextRadio.Size = new Size(58, 24);
            thinTextRadio.TabIndex = 7;
            thinTextRadio.Text = "Thin";
            thinTextRadio.UseVisualStyleBackColor = true;
            thinTextRadio.CheckedChanged += thinTextRadio_CheckedChanged;
            // 
            // linedTextRadio
            // 
            linedTextRadio.AutoSize = true;
            linedTextRadio.Location = new Point(379, 80);
            linedTextRadio.Name = "linedTextRadio";
            linedTextRadio.Size = new Size(116, 24);
            linedTextRadio.TabIndex = 6;
            linedTextRadio.Text = "Double lined";
            linedTextRadio.UseVisualStyleBackColor = true;
            linedTextRadio.CheckedChanged += linedTextRadio_CheckedChanged;
            // 
            // cursiveLightRadio
            // 
            cursiveLightRadio.AutoSize = true;
            cursiveLightRadio.Checked = true;
            cursiveLightRadio.Location = new Point(17, 80);
            cursiveLightRadio.Name = "cursiveLightRadio";
            cursiveLightRadio.Size = new Size(77, 24);
            cursiveLightRadio.TabIndex = 0;
            cursiveLightRadio.TabStop = true;
            cursiveLightRadio.Text = "Cursive";
            cursiveLightRadio.UseVisualStyleBackColor = true;
            cursiveLightRadio.CheckedChanged += cursiveLightRadio_CheckedChanged;
            // 
            // cursiveBoldRadio
            // 
            cursiveBoldRadio.AutoSize = true;
            cursiveBoldRadio.Location = new Point(17, 110);
            cursiveBoldRadio.Name = "cursiveBoldRadio";
            cursiveBoldRadio.Size = new Size(122, 24);
            cursiveBoldRadio.TabIndex = 1;
            cursiveBoldRadio.Text = "Cursive (bold)";
            cursiveBoldRadio.UseVisualStyleBackColor = true;
            cursiveBoldRadio.CheckedChanged += cursiveBoldRadio_CheckedChanged;
            // 
            // tabPageIcons
            // 
            tabPageIcons.BackColor = Color.WhiteSmoke;
            tabPageIcons.Controls.Add(label6);
            tabPageIcons.Controls.Add(button5);
            tabPageIcons.Location = new Point(4, 29);
            tabPageIcons.Name = "tabPageIcons";
            tabPageIcons.Padding = new Padding(3);
            tabPageIcons.Size = new Size(770, 346);
            tabPageIcons.TabIndex = 2;
            tabPageIcons.Text = "Icon Sets";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(15, 71);
            label6.Name = "label6";
            label6.Size = new Size(408, 20);
            label6.TabIndex = 12;
            label6.Text = "Lets you select a saved icon set and apply it to your desktop.";
            // 
            // button5
            // 
            button5.Location = new Point(15, 39);
            button5.Name = "button5";
            button5.Size = new Size(212, 29);
            button5.TabIndex = 11;
            button5.Text = "Apply Icon Set";
            button5.UseVisualStyleBackColor = true;
            // 
            // tabPageManage
            // 
            tabPageManage.BackColor = Color.WhiteSmoke;
            tabPageManage.Controls.Add(label4);
            tabPageManage.Controls.Add(backupButton);
            tabPageManage.Controls.Add(label3);
            tabPageManage.Controls.Add(explorerButton);
            tabPageManage.Controls.Add(refreshButton);
            tabPageManage.Controls.Add(validateButton);
            tabPageManage.Controls.Add(pathButton);
            tabPageManage.Controls.Add(label1);
            tabPageManage.Controls.Add(label2);
            tabPageManage.Location = new Point(4, 29);
            tabPageManage.Name = "tabPageManage";
            tabPageManage.Padding = new Padding(3);
            tabPageManage.Size = new Size(770, 346);
            tabPageManage.TabIndex = 1;
            tabPageManage.Text = "Desktop Management";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(17, 14);
            label4.Name = "label4";
            label4.Size = new Size(427, 31);
            label4.TabIndex = 17;
            label4.Text = "Welcome to the Desktop Icon Manager!";
            // 
            // backupButton
            // 
            backupButton.Location = new Point(17, 182);
            backupButton.Name = "backupButton";
            backupButton.Size = new Size(212, 29);
            backupButton.TabIndex = 15;
            backupButton.Text = "Back Up Shortcuts";
            backupButton.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(17, 214);
            label3.Name = "label3";
            label3.Size = new Size(512, 20);
            label3.TabIndex = 16;
            label3.Text = "Saves desktop shortcuts and current icon set. (Physical location is not saved.)";
            // 
            // explorerButton
            // 
            explorerButton.Location = new Point(542, 298);
            explorerButton.Name = "explorerButton";
            explorerButton.Size = new Size(212, 29);
            explorerButton.TabIndex = 14;
            explorerButton.Text = "Restart Explorer";
            explorerButton.UseVisualStyleBackColor = true;
            // 
            // refreshButton
            // 
            refreshButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            refreshButton.Location = new Point(324, 298);
            refreshButton.Name = "refreshButton";
            refreshButton.Size = new Size(212, 29);
            refreshButton.TabIndex = 13;
            refreshButton.Text = "Refresh Desktop";
            refreshButton.UseVisualStyleBackColor = true;
            // 
            // validateButton
            // 
            validateButton.Location = new Point(17, 56);
            validateButton.Name = "validateButton";
            validateButton.Size = new Size(212, 29);
            validateButton.TabIndex = 5;
            validateButton.Text = "Validate Desktop";
            validateButton.UseVisualStyleBackColor = true;
            // 
            // pathButton
            // 
            pathButton.Location = new Point(17, 119);
            pathButton.Name = "pathButton";
            pathButton.Size = new Size(212, 29);
            pathButton.TabIndex = 6;
            pathButton.Text = "Set Custom Icon Paths";
            pathButton.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(17, 86);
            label1.Name = "label1";
            label1.Size = new Size(459, 20);
            label1.TabIndex = 7;
            label1.Text = "Checks if non-shortcuts exist on desktop and helps you handle them.";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(17, 148);
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
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Location = new Point(12, 12);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(778, 379);
            tabControl1.TabIndex = 14;
            // 
            // tabPage1
            // 
            tabPage1.BackColor = Color.WhiteSmoke;
            tabPage1.Controls.Add(label14);
            tabPage1.Controls.Add(button3);
            tabPage1.Controls.Add(label13);
            tabPage1.Controls.Add(checkBox2);
            tabPage1.Controls.Add(button2);
            tabPage1.Controls.Add(shortcutToPersonalButton);
            tabPage1.Location = new Point(4, 29);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(770, 346);
            tabPage1.TabIndex = 7;
            tabPage1.Text = "Advanced";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label14.Location = new Point(15, 20);
            label14.Name = "label14";
            label14.Size = new Size(514, 31);
            label14.TabIndex = 22;
            label14.Text = "Advanced Settings (be careful, here be dragons)";
            // 
            // button3
            // 
            button3.Enabled = false;
            button3.Location = new Point(35, 94);
            button3.Name = "button3";
            button3.Size = new Size(201, 29);
            button3.TabIndex = 21;
            button3.Text = "Select Automation Config";
            button3.UseVisualStyleBackColor = true;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Enabled = false;
            label13.Location = new Point(242, 99);
            label13.Name = "label13";
            label13.Size = new Size(86, 20);
            label13.TabIndex = 20;
            label13.Text = "No path set";
            // 
            // checkBox2
            // 
            checkBox2.AutoSize = true;
            checkBox2.Location = new Point(15, 64);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new Size(310, 24);
            checkBox2.TabIndex = 2;
            checkBox2.Text = "Enable custom automation (experimental)";
            checkBox2.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(574, 297);
            button2.Name = "button2";
            button2.Size = new Size(175, 29);
            button2.TabIndex = 1;
            button2.Text = "Open App Folder";
            button2.UseVisualStyleBackColor = true;
            // 
            // shortcutToPersonalButton
            // 
            shortcutToPersonalButton.Location = new Point(15, 145);
            shortcutToPersonalButton.Name = "shortcutToPersonalButton";
            shortcutToPersonalButton.Size = new Size(289, 29);
            shortcutToPersonalButton.TabIndex = 0;
            shortcutToPersonalButton.Text = "Move all shortcuts to personal desktop";
            shortcutToPersonalButton.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLight;
            ClientSize = new Size(802, 403);
            Controls.Add(tabControl1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MaximumSize = new Size(820, 450);
            MinimumSize = new Size(820, 450);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Desktop Icon Manager";
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
            tabPageIcons.PerformLayout();
            tabPageManage.ResumeLayout(false);
            tabPageManage.PerformLayout();
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TabPage tabPageSettings;
        private CheckBox defaultWallpaperCheck;
        private Button defaultWallpaperButton;
        private Label wallpaperPathLabel;
        private Label label12;
        private CheckBox explorerCheck;
        private CheckBox arrowCheck;
        private CheckBox wallpaperCheck;
        private TabPage tabPageArrows;
        private Button arrowApplyButton;
        private Button resetColorButton;
        private TextBox lightBox;
        private TextBox satBox;
        private TextBox hueBox;
        private Label label9;
        private ComboBox comboBox1;
        private TrackBar lightSlide;
        private Label label8;
        private TrackBar satSlide;
        private Label label5;
        private TrackBar hueSlide;
        private Button restoreArrowButton;
        private Button arrowSaveButton;
        private Label label7;
        private PictureBox arrowShowBox;
        private TabPage tabPageLabels;
        private Button labelRestoreButton;
        private Label alphabetLabel;
        private Label label11;
        private Button labelButton;
        private Label label10;
        private TextBox endCharTextBox;
        private TextBox startCharTextBox;
        private CheckBox charEndCheck;
        private CheckBox charStartCheck;
        private RadioButton defaultFontRadio;
        private RadioButton serifLightRadio;
        private RadioButton italicBoldRadio;
        private RadioButton italicLightRadio;
        private RadioButton serifBoldVideo;
        private RadioButton circleTextRadio;
        private RadioButton medievalTextRadio;
        private RadioButton thinTextRadio;
        private RadioButton linedTextRadio;
        private RadioButton cursiveLightRadio;
        private RadioButton cursiveBoldRadio;
        private TabPage tabPageIcons;
        private Label label6;
        private Button button5;
        private TabPage tabPageManage;
        private Label label4;
        private Button backupButton;
        private Label label3;
        private Button explorerButton;
        private Button refreshButton;
        private Button validateButton;
        private Button pathButton;
        private Label label1;
        private Label label2;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private Button button2;
        private Button shortcutToPersonalButton;
        private Button button3;
        private Label label13;
        private CheckBox checkBox2;
        private Label label14;
        private CheckBox lightDarkCheck;
    }
}
