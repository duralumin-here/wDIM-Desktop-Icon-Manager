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
            label4 = new Label();
            label6 = new Label();
            button5 = new Button();
            button6 = new Button();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            tabPage2 = new TabPage();
            tabPage3 = new TabPage();
            tabPage4 = new TabPage();
            trackBar3 = new TrackBar();
            label8 = new Label();
            trackBar2 = new TrackBar();
            label5 = new Label();
            trackBar1 = new TrackBar();
            button4 = new Button();
            button8 = new Button();
            button7 = new Button();
            button11 = new Button();
            label7 = new Label();
            button9 = new Button();
            pictureBox1 = new PictureBox();
            tabPage5 = new TabPage();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)trackBar3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBar2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBar1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
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
            // button6
            // 
            button6.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button6.Location = new Point(418, 421);
            button6.Name = "button6";
            button6.Size = new Size(212, 29);
            button6.TabIndex = 11;
            button6.Text = "Refresh Desktop";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // tabControl1
            // 
            tabControl1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Controls.Add(tabPage4);
            tabControl1.Controls.Add(tabPage5);
            tabControl1.Location = new Point(3, 12);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(660, 604);
            tabControl1.TabIndex = 14;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(label4);
            tabPage1.Controls.Add(button6);
            tabPage1.Controls.Add(label6);
            tabPage1.Controls.Add(button5);
            tabPage1.Controls.Add(button1);
            tabPage1.Controls.Add(button2);
            tabPage1.Controls.Add(button3);
            tabPage1.Controls.Add(label1);
            tabPage1.Controls.Add(label2);
            tabPage1.Controls.Add(label3);
            tabPage1.Location = new Point(4, 29);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(652, 571);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Quick Settings";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Location = new Point(6, 62);
            button1.Name = "button1";
            button1.Size = new Size(212, 29);
            button1.TabIndex = 0;
            button1.Text = "Validate Desktop";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(6, 127);
            button2.Name = "button2";
            button2.Size = new Size(212, 29);
            button2.TabIndex = 1;
            button2.Text = "Set Custom Icon Paths";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(6, 200);
            button3.Name = "button3";
            button3.Size = new Size(212, 29);
            button3.TabIndex = 2;
            button3.Text = "Back Up Shortcuts";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
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
            // tabPage2
            // 
            tabPage2.Location = new Point(4, 29);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(652, 571);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Desktop Management";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            tabPage3.Location = new Point(4, 29);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3);
            tabPage3.Size = new Size(652, 571);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Icon Sets";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            tabPage4.BackColor = SystemColors.Control;
            tabPage4.Controls.Add(trackBar3);
            tabPage4.Controls.Add(label8);
            tabPage4.Controls.Add(trackBar2);
            tabPage4.Controls.Add(label5);
            tabPage4.Controls.Add(trackBar1);
            tabPage4.Controls.Add(button4);
            tabPage4.Controls.Add(button8);
            tabPage4.Controls.Add(button7);
            tabPage4.Controls.Add(button11);
            tabPage4.Controls.Add(label7);
            tabPage4.Controls.Add(button9);
            tabPage4.Controls.Add(pictureBox1);
            tabPage4.Location = new Point(4, 29);
            tabPage4.Name = "tabPage4";
            tabPage4.Padding = new Padding(3);
            tabPage4.Size = new Size(652, 571);
            tabPage4.TabIndex = 3;
            tabPage4.Text = "Shortcut Arrows";
            // 
            // trackBar3
            // 
            trackBar3.LargeChange = 10;
            trackBar3.Location = new Point(36, 492);
            trackBar3.Maximum = 100;
            trackBar3.Name = "trackBar3";
            trackBar3.Size = new Size(266, 56);
            trackBar3.TabIndex = 21;
            trackBar3.TickFrequency = 45;
            trackBar3.TickStyle = TickStyle.None;
            trackBar3.Value = 50;
            trackBar3.ValueChanged += trackBar3_ValueChanged;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(36, 472);
            label8.Name = "label8";
            label8.Size = new Size(70, 20);
            label8.TabIndex = 20;
            label8.Text = "Lightness";
            // 
            // trackBar2
            // 
            trackBar2.LargeChange = 10;
            trackBar2.Location = new Point(36, 413);
            trackBar2.Maximum = 100;
            trackBar2.Name = "trackBar2";
            trackBar2.Size = new Size(266, 56);
            trackBar2.TabIndex = 19;
            trackBar2.TickFrequency = 45;
            trackBar2.TickStyle = TickStyle.None;
            trackBar2.Value = 100;
            trackBar2.ValueChanged += trackBar2_ValueChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(36, 390);
            label5.Name = "label5";
            label5.Size = new Size(77, 20);
            label5.TabIndex = 18;
            label5.Text = "Saturation";
            // 
            // trackBar1
            // 
            trackBar1.LargeChange = 10;
            trackBar1.Location = new Point(36, 331);
            trackBar1.Maximum = 360;
            trackBar1.Name = "trackBar1";
            trackBar1.Size = new Size(266, 56);
            trackBar1.TabIndex = 16;
            trackBar1.TickFrequency = 45;
            trackBar1.TickStyle = TickStyle.None;
            trackBar1.ValueChanged += trackBar1_ValueChanged;
            // 
            // button4
            // 
            button4.Location = new Point(347, 89);
            button4.Name = "button4";
            button4.Size = new Size(212, 29);
            button4.TabIndex = 15;
            button4.Text = "Change/Remove Arrows";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click_1;
            // 
            // button8
            // 
            button8.Location = new Point(363, 466);
            button8.Name = "button8";
            button8.Size = new Size(263, 29);
            button8.TabIndex = 14;
            button8.Text = "Restore Shortcut Arrows";
            button8.UseVisualStyleBackColor = true;
            button8.Click += button8_Click_1;
            // 
            // button7
            // 
            button7.Location = new Point(363, 431);
            button7.Name = "button7";
            button7.Size = new Size(263, 29);
            button7.TabIndex = 13;
            button7.Text = "Restart Explorer";
            button7.UseVisualStyleBackColor = true;
            button7.Click += button7_Click_1;
            // 
            // button11
            // 
            button11.Location = new Point(363, 396);
            button11.Name = "button11";
            button11.Size = new Size(263, 29);
            button11.TabIndex = 5;
            button11.Text = "Save Arrow to Current Theme";
            button11.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(36, 308);
            label7.Name = "label7";
            label7.Size = new Size(36, 20);
            label7.TabIndex = 4;
            label7.Text = "Hue";
            // 
            // button9
            // 
            button9.Location = new Point(347, 41);
            button9.Name = "button9";
            button9.Size = new Size(187, 29);
            button9.TabIndex = 1;
            button9.Text = "Select Arrow Style";
            button9.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.BackgroundImage = (Image)resources.GetObject("pictureBox1.BackgroundImage");
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox1.Location = new Point(36, 41);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(266, 257);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // tabPage5
            // 
            tabPage5.Location = new Point(4, 29);
            tabPage5.Name = "tabPage5";
            tabPage5.Padding = new Padding(3);
            tabPage5.Size = new Size(652, 571);
            tabPage5.TabIndex = 4;
            tabPage5.Text = "Customize Labels";
            tabPage5.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(665, 621);
            Controls.Add(tabControl1);
            Name = "Form1";
            Text = "Desktop Icon Manager";
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            tabPage4.ResumeLayout(false);
            tabPage4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)trackBar3).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBar2).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBar1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Label label4;
        private Label label6;
        private Button button5;
        private Button button6;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TabPage tabPage3;
        private Button button1;
        private Button button2;
        private Button button3;
        private Label label1;
        private Label label2;
        private Label label3;
        private TabPage tabPage4;
        private Button button9;
        private PictureBox pictureBox1;
        private Button button11;
        private Label label7;
        private Button button8;
        private Button button7;
        private Button button4;
        private TabPage tabPage5;
        private TrackBar trackBar1;
        private TrackBar trackBar3;
        private Label label8;
        private TrackBar trackBar2;
        private Label label5;
    }
}
