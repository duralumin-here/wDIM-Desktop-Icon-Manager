namespace DesktopIconGUIapp
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
            button1 = new Button();
            button3 = new Button();
            button2 = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            button4 = new Button();
            label5 = new Label();
            label6 = new Label();
            button5 = new Button();
            button6 = new Button();
            button7 = new Button();
            button8 = new Button();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(26, 71);
            button1.Name = "button1";
            button1.Size = new Size(212, 29);
            button1.TabIndex = 0;
            button1.Text = "Validate Desktop";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button3
            // 
            button3.Location = new Point(26, 209);
            button3.Name = "button3";
            button3.Size = new Size(212, 29);
            button3.TabIndex = 2;
            button3.Text = "Back Up Shortcuts";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button2
            // 
            button2.Location = new Point(26, 136);
            button2.Name = "button2";
            button2.Size = new Size(212, 29);
            button2.TabIndex = 1;
            button2.Text = "Set Custom Icon Paths";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(26, 101);
            label1.Name = "label1";
            label1.Size = new Size(847, 20);
            label1.TabIndex = 3;
            label1.Text = "Scans desktop for non-shortcuts and helps you handle them, then makes sure every shortcut is prepared for a custom icon path.";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(26, 166);
            label2.Name = "label2";
            label2.Size = new Size(766, 20);
            label2.TabIndex = 4;
            label2.Text = "Checks all saved icon sets and shows any sets that are missing icons for current shortcuts. (May need admin access.)";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(26, 239);
            label3.Name = "label3";
            label3.Size = new Size(766, 20);
            label3.TabIndex = 5;
            label3.Text = "Saves your desktop shortcuts and the current icon set into a backup folder. (Does NOT save their physical location!)";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(26, 21);
            label4.Name = "label4";
            label4.Size = new Size(427, 31);
            label4.TabIndex = 6;
            label4.Text = "Welcome to the Desktop Icon Manager!";
            // 
            // button4
            // 
            button4.Location = new Point(26, 279);
            button4.Name = "button4";
            button4.Size = new Size(212, 29);
            button4.TabIndex = 7;
            button4.Text = "Change/Remove Arrows";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(26, 309);
            label5.Name = "label5";
            label5.Size = new Size(672, 20);
            label5.TabIndex = 8;
            label5.Text = "Applies an alternate or blank image for the arrows that come out of icons. (May need admin access.)";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(26, 376);
            label6.Name = "label6";
            label6.Size = new Size(408, 20);
            label6.TabIndex = 10;
            label6.Text = "Lets you select a saved icon set and apply it to your desktop.";
            // 
            // button5
            // 
            button5.Location = new Point(26, 344);
            button5.Name = "button5";
            button5.Size = new Size(212, 29);
            button5.TabIndex = 9;
            button5.Text = "Apply Icon Set";
            button5.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            button6.Location = new Point(596, 367);
            button6.Name = "button6";
            button6.Size = new Size(212, 29);
            button6.TabIndex = 11;
            button6.Text = "Refresh Desktop";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // button7
            // 
            button7.Location = new Point(596, 402);
            button7.Name = "button7";
            button7.Size = new Size(212, 29);
            button7.TabIndex = 12;
            button7.Text = "Restart Explorer";
            button7.UseVisualStyleBackColor = true;
            button7.Click += button7_Click;
            // 
            // button8
            // 
            button8.Location = new Point(596, 437);
            button8.Name = "button8";
            button8.Size = new Size(212, 29);
            button8.TabIndex = 13;
            button8.Text = "Restore Shortcut Arrows";
            button8.UseVisualStyleBackColor = true;
            button8.Click += button8_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(895, 489);
            Controls.Add(button8);
            Controls.Add(button7);
            Controls.Add(button6);
            Controls.Add(label6);
            Controls.Add(button5);
            Controls.Add(label5);
            Controls.Add(button4);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "Form1";
            Text = "Desktop Icon Manager";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Button button3;
        private Button button2;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Button button4;
        private Label label5;
        private Label label6;
        private Button button5;
        private Button button6;
        private Button button7;
        private Button button8;
    }
}
