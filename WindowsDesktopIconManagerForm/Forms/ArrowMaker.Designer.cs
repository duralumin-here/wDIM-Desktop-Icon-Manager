namespace WindowsDesktopIconManagerForm
{
    partial class ArrowMaker
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
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
            arrowSaveButton = new Button();
            label7 = new Label();
            arrowShowBox = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)lightSlide).BeginInit();
            ((System.ComponentModel.ISupportInitialize)satSlide).BeginInit();
            ((System.ComponentModel.ISupportInitialize)hueSlide).BeginInit();
            ((System.ComponentModel.ISupportInitialize)arrowShowBox).BeginInit();
            SuspendLayout();
            // 
            // resetColorButton
            // 
            resetColorButton.Location = new Point(30, 287);
            resetColorButton.Name = "resetColorButton";
            resetColorButton.Size = new Size(126, 29);
            resetColorButton.TabIndex = 49;
            resetColorButton.Text = "Reset Editor";
            resetColorButton.UseVisualStyleBackColor = true;
            resetColorButton.Click += resetColorButton_Click;
            // 
            // lightBox
            // 
            lightBox.Location = new Point(544, 234);
            lightBox.Name = "lightBox";
            lightBox.Size = new Size(64, 27);
            lightBox.TabIndex = 48;
            lightBox.TextChanged += lightBox_TextChanged;
            // 
            // satBox
            // 
            satBox.Location = new Point(544, 146);
            satBox.Name = "satBox";
            satBox.Size = new Size(64, 27);
            satBox.TabIndex = 46;
            satBox.TextChanged += satBox_TextChanged;
            // 
            // hueBox
            // 
            hueBox.Location = new Point(544, 60);
            hueBox.Name = "hueBox";
            hueBox.Size = new Size(64, 27);
            hueBox.TabIndex = 44;
            hueBox.TextChanged += hueBox_TextChanged;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(32, 222);
            label9.Name = "label9";
            label9.Size = new Size(148, 20);
            label9.TabIndex = 57;
            label9.Text = "Select an arrow style:";
            // 
            // comboBox1
            // 
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Blank/No Arrow", "Curved (Transparent)", "Curved (Black)", "Curved (White)", "Straight (Transparent)", "Straight (Black)", "Straight (White)" });
            comboBox1.Location = new Point(30, 245);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(190, 28);
            comboBox1.TabIndex = 42;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // lightSlide
            // 
            lightSlide.LargeChange = 10;
            lightSlide.Location = new Point(251, 225);
            lightSlide.Maximum = 98;
            lightSlide.Minimum = 2;
            lightSlide.Name = "lightSlide";
            lightSlide.Size = new Size(276, 56);
            lightSlide.TabIndex = 47;
            lightSlide.TickFrequency = 0;
            lightSlide.TickStyle = TickStyle.Both;
            lightSlide.Value = 50;
            lightSlide.ValueChanged += lightSlide_ValueChanged;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(251, 202);
            label8.Name = "label8";
            label8.Size = new Size(70, 20);
            label8.TabIndex = 56;
            label8.Text = "Lightness";
            // 
            // satSlide
            // 
            satSlide.LargeChange = 10;
            satSlide.Location = new Point(251, 138);
            satSlide.Maximum = 100;
            satSlide.Minimum = 1;
            satSlide.Name = "satSlide";
            satSlide.Size = new Size(276, 56);
            satSlide.TabIndex = 45;
            satSlide.TickFrequency = 0;
            satSlide.TickStyle = TickStyle.Both;
            satSlide.Value = 100;
            satSlide.ValueChanged += satSlide_ValueChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(251, 116);
            label5.Name = "label5";
            label5.Size = new Size(77, 20);
            label5.TabIndex = 55;
            label5.Text = "Saturation";
            // 
            // hueSlide
            // 
            hueSlide.BackColor = SystemColors.Control;
            hueSlide.LargeChange = 10;
            hueSlide.Location = new Point(251, 51);
            hueSlide.Maximum = 360;
            hueSlide.Name = "hueSlide";
            hueSlide.Size = new Size(276, 56);
            hueSlide.TabIndex = 43;
            hueSlide.TickFrequency = 0;
            hueSlide.TickStyle = TickStyle.Both;
            hueSlide.ValueChanged += hueSlide_ValueChanged;
            // 
            // arrowSaveButton
            // 
            arrowSaveButton.Enabled = false;
            arrowSaveButton.Location = new Point(456, 287);
            arrowSaveButton.Name = "arrowSaveButton";
            arrowSaveButton.Size = new Size(152, 29);
            arrowSaveButton.TabIndex = 50;
            arrowSaveButton.Text = "Save arrow to set";
            arrowSaveButton.UseVisualStyleBackColor = true;
            arrowSaveButton.Click += arrowSaveButton_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(251, 32);
            label7.Name = "label7";
            label7.Size = new Size(36, 20);
            label7.TabIndex = 54;
            label7.Text = "Hue";
            // 
            // arrowShowBox
            // 
            arrowShowBox.BackColor = Color.LightGray;
            arrowShowBox.BackgroundImageLayout = ImageLayout.Stretch;
            arrowShowBox.BorderStyle = BorderStyle.Fixed3D;
            arrowShowBox.Location = new Point(32, 41);
            arrowShowBox.Name = "arrowShowBox";
            arrowShowBox.Size = new Size(150, 150);
            arrowShowBox.TabIndex = 53;
            arrowShowBox.TabStop = false;
            // 
            // ArrowMaker
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(642, 353);
            Controls.Add(resetColorButton);
            Controls.Add(lightBox);
            Controls.Add(satBox);
            Controls.Add(hueBox);
            Controls.Add(label9);
            Controls.Add(comboBox1);
            Controls.Add(lightSlide);
            Controls.Add(label8);
            Controls.Add(satSlide);
            Controls.Add(label5);
            Controls.Add(hueSlide);
            Controls.Add(arrowSaveButton);
            Controls.Add(label7);
            Controls.Add(arrowShowBox);
            MaximizeBox = false;
            MaximumSize = new Size(660, 400);
            MinimizeBox = false;
            MinimumSize = new Size(660, 400);
            Name = "ArrowMaker";
            Text = "Create an arrow";
            ((System.ComponentModel.ISupportInitialize)lightSlide).EndInit();
            ((System.ComponentModel.ISupportInitialize)satSlide).EndInit();
            ((System.ComponentModel.ISupportInitialize)hueSlide).EndInit();
            ((System.ComponentModel.ISupportInitialize)arrowShowBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

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
        private Button arrowSaveButton;
        private Label label7;
        private PictureBox arrowShowBox;


    }
}