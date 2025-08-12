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
            tabPage5 = new TabPage();
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
            tabPage4 = new TabPage();
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
            tabPage3 = new TabPage();
            tabPage2 = new TabPage();
            tabPage1 = new TabPage();
            explorerButton = new Button();
            label4 = new Label();
            refreshButton = new Button();
            label6 = new Label();
            button5 = new Button();
            validateButton = new Button();
            pathButton = new Button();
            backupButton = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            tabControl1 = new TabControl();
            tabPage5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)lightSlide).BeginInit();
            ((System.ComponentModel.ISupportInitialize)satSlide).BeginInit();
            ((System.ComponentModel.ISupportInitialize)hueSlide).BeginInit();
            ((System.ComponentModel.ISupportInitialize)arrowShowBox).BeginInit();
            tabPage4.SuspendLayout();
            tabPage1.SuspendLayout();
            tabControl1.SuspendLayout();
            SuspendLayout();
            // 
            // tabPage5
            // 
            tabPage5.BackColor = SystemColors.Control;
            tabPage5.Controls.Add(arrowApplyButton);
            tabPage5.Controls.Add(resetColorButton);
            tabPage5.Controls.Add(lightBox);
            tabPage5.Controls.Add(satBox);
            tabPage5.Controls.Add(hueBox);
            tabPage5.Controls.Add(label9);
            tabPage5.Controls.Add(comboBox1);
            tabPage5.Controls.Add(lightSlide);
            tabPage5.Controls.Add(label8);
            tabPage5.Controls.Add(satSlide);
            tabPage5.Controls.Add(label5);
            tabPage5.Controls.Add(hueSlide);
            tabPage5.Controls.Add(restoreArrowButton);
            tabPage5.Controls.Add(arrowSaveButton);
            tabPage5.Controls.Add(label7);
            tabPage5.Controls.Add(arrowShowBox);
            tabPage5.Location = new Point(4, 29);
            tabPage5.Name = "tabPage5";
            tabPage5.Padding = new Padding(3);
            tabPage5.Size = new Size(770, 346);
            tabPage5.TabIndex = 5;
            tabPage5.Text = "Shortcut Arrows";
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
            // tabPage4
            // 
            tabPage4.BackColor = SystemColors.Control;
            tabPage4.Controls.Add(alphabetLabel);
            tabPage4.Controls.Add(label11);
            tabPage4.Controls.Add(labelButton);
            tabPage4.Controls.Add(label10);
            tabPage4.Controls.Add(endCharTextBox);
            tabPage4.Controls.Add(startCharTextBox);
            tabPage4.Controls.Add(charEndCheck);
            tabPage4.Controls.Add(charStartCheck);
            tabPage4.Controls.Add(defaultFontRadio);
            tabPage4.Controls.Add(serifLightRadio);
            tabPage4.Controls.Add(italicBoldRadio);
            tabPage4.Controls.Add(italicLightRadio);
            tabPage4.Controls.Add(serifBoldVideo);
            tabPage4.Controls.Add(circleTextRadio);
            tabPage4.Controls.Add(medievalTextRadio);
            tabPage4.Controls.Add(thinTextRadio);
            tabPage4.Controls.Add(linedTextRadio);
            tabPage4.Controls.Add(cursiveLightRadio);
            tabPage4.Controls.Add(cursiveBoldRadio);
            tabPage4.Location = new Point(4, 29);
            tabPage4.Name = "tabPage4";
            tabPage4.Padding = new Padding(3);
            tabPage4.Size = new Size(770, 346);
            tabPage4.TabIndex = 4;
            tabPage4.Text = "Customize Labels";
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
            label11.Size = new Size(382, 20);
            label11.TabIndex = 18;
            label11.Text = "All changes will apply to the shortcut set currently in use.";
            // 
            // labelButton
            // 
            labelButton.Location = new Point(588, 301);
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
            label10.Size = new Size(240, 31);
            label10.TabIndex = 15;
            label10.Text = "Stylize shortcut labels";
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
            // tabPage3
            // 
            tabPage3.BackColor = SystemColors.Control;
            tabPage3.Location = new Point(4, 29);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3);
            tabPage3.Size = new Size(770, 346);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Icon Sets";
            // 
            // tabPage2
            // 
            tabPage2.BackColor = SystemColors.Control;
            tabPage2.Location = new Point(4, 29);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(770, 346);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Desktop Management";
            // 
            // tabPage1
            // 
            tabPage1.BackColor = SystemColors.Control;
            tabPage1.Controls.Add(explorerButton);
            tabPage1.Controls.Add(label4);
            tabPage1.Controls.Add(refreshButton);
            tabPage1.Controls.Add(label6);
            tabPage1.Controls.Add(button5);
            tabPage1.Controls.Add(validateButton);
            tabPage1.Controls.Add(pathButton);
            tabPage1.Controls.Add(backupButton);
            tabPage1.Controls.Add(label1);
            tabPage1.Controls.Add(label2);
            tabPage1.Controls.Add(label3);
            tabPage1.Location = new Point(4, 29);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(770, 346);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Quick Settings";
            // 
            // explorerButton
            // 
            explorerButton.Location = new Point(552, 305);
            explorerButton.Name = "explorerButton";
            explorerButton.Size = new Size(212, 29);
            explorerButton.TabIndex = 12;
            explorerButton.Text = "Restart Explorer";
            explorerButton.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(6, 15);
            label4.Name = "label4";
            label4.Size = new Size(427, 31);
            label4.TabIndex = 6;
            label4.Text = "Welcome to the Desktop Icon Manager!";
            // 
            // refreshButton
            // 
            refreshButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            refreshButton.Location = new Point(552, 270);
            refreshButton.Name = "refreshButton";
            refreshButton.Size = new Size(212, 29);
            refreshButton.TabIndex = 11;
            refreshButton.Text = "Refresh Desktop";
            refreshButton.UseVisualStyleBackColor = true;
            refreshButton.Click += refreshButton_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(6, 302);
            label6.Name = "label6";
            label6.Size = new Size(408, 20);
            label6.TabIndex = 10;
            label6.Text = "Lets you select a saved icon set and apply it to your desktop.";
            // 
            // button5
            // 
            button5.Location = new Point(6, 270);
            button5.Name = "button5";
            button5.Size = new Size(212, 29);
            button5.TabIndex = 9;
            button5.Text = "Apply Icon Set";
            button5.UseVisualStyleBackColor = true;
            // 
            // validateButton
            // 
            validateButton.Location = new Point(6, 62);
            validateButton.Name = "validateButton";
            validateButton.Size = new Size(212, 29);
            validateButton.TabIndex = 0;
            validateButton.Text = "Validate Desktop";
            validateButton.UseVisualStyleBackColor = true;
            validateButton.Click += validateButton_Click;
            // 
            // pathButton
            // 
            pathButton.Location = new Point(6, 127);
            pathButton.Name = "pathButton";
            pathButton.Size = new Size(212, 29);
            pathButton.TabIndex = 1;
            pathButton.Text = "Set Custom Icon Paths";
            pathButton.UseVisualStyleBackColor = true;
            pathButton.Click += pathButton_Click;
            // 
            // backupButton
            // 
            backupButton.Location = new Point(6, 200);
            backupButton.Name = "backupButton";
            backupButton.Size = new Size(212, 29);
            backupButton.TabIndex = 2;
            backupButton.Text = "Back Up Shortcuts";
            backupButton.UseVisualStyleBackColor = true;
            backupButton.Click += backupButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 94);
            label1.Name = "label1";
            label1.Size = new Size(459, 20);
            label1.TabIndex = 3;
            label1.Text = "Checks if non-shortcuts exist on desktop and helps you handle them.";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 157);
            label2.Name = "label2";
            label2.Size = new Size(598, 20);
            label2.TabIndex = 4;
            label2.Text = "Automatically applies custom icon paths to shortcuts. (May require Administrator access.)";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 230);
            label3.Name = "label3";
            label3.Size = new Size(512, 20);
            label3.TabIndex = 5;
            label3.Text = "Saves desktop shortcuts and current icon set. (Physical location is not saved.)";
            // 
            // tabControl1
            // 
            tabControl1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Controls.Add(tabPage4);
            tabControl1.Controls.Add(tabPage5);
            tabControl1.Location = new Point(12, 12);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(778, 379);
            tabControl1.TabIndex = 14;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLight;
            ClientSize = new Size(802, 403);
            Controls.Add(tabControl1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            HelpButton = true;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MaximumSize = new Size(820, 450);
            MinimizeBox = false;
            MinimumSize = new Size(820, 450);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Desktop Icon Manager";
            tabPage5.ResumeLayout(false);
            tabPage5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)lightSlide).EndInit();
            ((System.ComponentModel.ISupportInitialize)satSlide).EndInit();
            ((System.ComponentModel.ISupportInitialize)hueSlide).EndInit();
            ((System.ComponentModel.ISupportInitialize)arrowShowBox).EndInit();
            tabPage4.ResumeLayout(false);
            tabPage4.PerformLayout();
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            tabControl1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TabPage tabPage5;
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
        private TabPage tabPage4;
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
        private TabPage tabPage3;
        private TabPage tabPage2;
        private TabPage tabPage1;
        private Label label4;
        private Button refreshButton;
        private Label label6;
        private Button button5;
        private Button validateButton;
        private Button pathButton;
        private Button backupButton;
        private Label label1;
        private Label label2;
        private Label label3;
        private TabControl tabControl1;
        private Label alphabetLabel;
        private Button explorerButton;
    }
}
