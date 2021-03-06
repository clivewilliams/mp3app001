﻿namespace mp3app001
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tbInputs = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.tbOutputs = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbStatus = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbStage1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbStage2 = new System.Windows.Forms.TextBox();
            this.btnStage3 = new System.Windows.Forms.Button();
            this.btnStage2 = new System.Windows.Forms.Button();
            this.tbHowmany = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.btnStage4 = new System.Windows.Forms.Button();
            this.btnStage5 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.tbIndexFile = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tbExternalDrive = new System.Windows.Forms.TextBox();
            this.btnOpenIndexFile = new System.Windows.Forms.Button();
            this.btnBuildMP3 = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.tbMP3Dir = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tbVideoDir = new System.Windows.Forms.TextBox();
            this.btnConvertWav = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(770, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.quitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(97, 22);
            this.quitToolStripMenuItem.Text = "Quit";
            this.quitToolStripMenuItem.Click += new System.EventHandler(this.quitToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // tbInputs
            // 
            this.tbInputs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbInputs.Location = new System.Drawing.Point(50, 30);
            this.tbInputs.Name = "tbInputs";
            this.tbInputs.Size = new System.Drawing.Size(378, 20);
            this.tbInputs.TabIndex = 1;
            this.tbInputs.Text = "d:\\music\\importme";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Input";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(544, 28);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(213, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Stage 1: Scan Import Folder >>";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tbOutputs
            // 
            this.tbOutputs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbOutputs.Location = new System.Drawing.Point(50, 108);
            this.tbOutputs.Name = "tbOutputs";
            this.tbOutputs.Size = new System.Drawing.Size(378, 20);
            this.tbOutputs.TabIndex = 4;
            this.tbOutputs.Text = "h:\\plex\\music";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Output";
            // 
            // tbStatus
            // 
            this.tbStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbStatus.Location = new System.Drawing.Point(8, 319);
            this.tbStatus.Multiline = true;
            this.tbStatus.Name = "tbStatus";
            this.tbStatus.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbStatus.Size = new System.Drawing.Size(751, 353);
            this.tbStatus.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(-1, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Stage 1";
            // 
            // tbStage1
            // 
            this.tbStage1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbStage1.Location = new System.Drawing.Point(50, 56);
            this.tbStage1.Name = "tbStage1";
            this.tbStage1.Size = new System.Drawing.Size(378, 20);
            this.tbStage1.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(-1, 85);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Stage 2";
            // 
            // tbStage2
            // 
            this.tbStage2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbStage2.Location = new System.Drawing.Point(50, 82);
            this.tbStage2.Name = "tbStage2";
            this.tbStage2.Size = new System.Drawing.Size(378, 20);
            this.tbStage2.TabIndex = 9;
            // 
            // btnStage3
            // 
            this.btnStage3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStage3.Location = new System.Drawing.Point(545, 80);
            this.btnStage3.Name = "btnStage3";
            this.btnStage3.Size = new System.Drawing.Size(213, 23);
            this.btnStage3.TabIndex = 11;
            this.btnStage3.Text = "Stage 3: Copy To Library >>";
            this.btnStage3.UseVisualStyleBackColor = true;
            this.btnStage3.Click += new System.EventHandler(this.btnStage3_Click);
            // 
            // btnStage2
            // 
            this.btnStage2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStage2.Location = new System.Drawing.Point(545, 54);
            this.btnStage2.Name = "btnStage2";
            this.btnStage2.Size = new System.Drawing.Size(213, 23);
            this.btnStage2.TabIndex = 12;
            this.btnStage2.Text = "Stage 2: Calculate New Filenames  >>";
            this.btnStage2.UseVisualStyleBackColor = true;
            this.btnStage2.Click += new System.EventHandler(this.btnStage2_Click);
            // 
            // tbHowmany
            // 
            this.tbHowmany.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbHowmany.Location = new System.Drawing.Point(683, 108);
            this.tbHowmany.Name = "tbHowmany";
            this.tbHowmany.Size = new System.Drawing.Size(75, 20);
            this.tbHowmany.TabIndex = 13;
            this.tbHowmany.TabStop = false;
            this.tbHowmany.Text = "9999999";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(619, 112);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "How Many";
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(439, 54);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(103, 23);
            this.button2.TabIndex = 15;
            this.button2.Text = "Open Output >>";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.Location = new System.Drawing.Point(439, 80);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(103, 23);
            this.button3.TabIndex = 16;
            this.button3.Text = "Open Output >>";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnStage4
            // 
            this.btnStage4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStage4.Location = new System.Drawing.Point(544, 154);
            this.btnStage4.Name = "btnStage4";
            this.btnStage4.Size = new System.Drawing.Size(213, 23);
            this.btnStage4.TabIndex = 17;
            this.btnStage4.Text = "Stage 4: Index Library >>";
            this.btnStage4.UseVisualStyleBackColor = true;
            this.btnStage4.Click += new System.EventHandler(this.btnStage4_Click);
            // 
            // btnStage5
            // 
            this.btnStage5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStage5.Location = new System.Drawing.Point(544, 181);
            this.btnStage5.Name = "btnStage5";
            this.btnStage5.Size = new System.Drawing.Size(213, 23);
            this.btnStage5.TabIndex = 18;
            this.btnStage5.Text = "Stage 5: Copy to External Drive >> ";
            this.btnStage5.UseVisualStyleBackColor = true;
            this.btnStage5.Click += new System.EventHandler(this.button4_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(5, 186);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(33, 13);
            this.label6.TabIndex = 20;
            this.label6.Text = "Index";
            // 
            // tbIndexFile
            // 
            this.tbIndexFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbIndexFile.Location = new System.Drawing.Point(50, 183);
            this.tbIndexFile.Name = "tbIndexFile";
            this.tbIndexFile.Size = new System.Drawing.Size(378, 20);
            this.tbIndexFile.TabIndex = 19;
            this.tbIndexFile.Text = "h:\\plex\\music\\stage4-2020-08-30-10-55-59.xlsx";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(5, 212);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(45, 13);
            this.label7.TabIndex = 22;
            this.label7.Text = "External";
            // 
            // tbExternalDrive
            // 
            this.tbExternalDrive.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbExternalDrive.Location = new System.Drawing.Point(50, 209);
            this.tbExternalDrive.Name = "tbExternalDrive";
            this.tbExternalDrive.Size = new System.Drawing.Size(378, 20);
            this.tbExternalDrive.TabIndex = 21;
            this.tbExternalDrive.Text = "f:\\";
            // 
            // btnOpenIndexFile
            // 
            this.btnOpenIndexFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpenIndexFile.Location = new System.Drawing.Point(439, 181);
            this.btnOpenIndexFile.Name = "btnOpenIndexFile";
            this.btnOpenIndexFile.Size = new System.Drawing.Size(103, 23);
            this.btnOpenIndexFile.TabIndex = 23;
            this.btnOpenIndexFile.Text = "Open Output >>";
            this.btnOpenIndexFile.UseVisualStyleBackColor = true;
            this.btnOpenIndexFile.Click += new System.EventHandler(this.btnOpenIndexFile_Click);
            // 
            // btnBuildMP3
            // 
            this.btnBuildMP3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBuildMP3.Location = new System.Drawing.Point(439, 255);
            this.btnBuildMP3.Name = "btnBuildMP3";
            this.btnBuildMP3.Size = new System.Drawing.Size(103, 23);
            this.btnBuildMP3.TabIndex = 28;
            this.btnBuildMP3.Text = "Convert MP4 >>";
            this.btnBuildMP3.UseVisualStyleBackColor = true;
            this.btnBuildMP3.Click += new System.EventHandler(this.btnBuildMP3_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(5, 286);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(34, 13);
            this.label8.TabIndex = 27;
            this.label8.Text = "MP3s";
            // 
            // tbMP3Dir
            // 
            this.tbMP3Dir.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbMP3Dir.Location = new System.Drawing.Point(50, 283);
            this.tbMP3Dir.Name = "tbMP3Dir";
            this.tbMP3Dir.Size = new System.Drawing.Size(378, 20);
            this.tbMP3Dir.TabIndex = 26;
            this.tbMP3Dir.Text = "H:\\Plex\\Music Video MP3";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(5, 260);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(34, 13);
            this.label9.TabIndex = 25;
            this.label9.Text = "MP4s";
            // 
            // tbVideoDir
            // 
            this.tbVideoDir.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbVideoDir.Location = new System.Drawing.Point(50, 257);
            this.tbVideoDir.Name = "tbVideoDir";
            this.tbVideoDir.Size = new System.Drawing.Size(378, 20);
            this.tbVideoDir.TabIndex = 24;
            this.tbVideoDir.Text = "H:\\Plex\\Music Video";
            // 
            // btnConvertWav
            // 
            this.btnConvertWav.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConvertWav.Location = new System.Drawing.Point(439, 28);
            this.btnConvertWav.Name = "btnConvertWav";
            this.btnConvertWav.Size = new System.Drawing.Size(103, 23);
            this.btnConvertWav.TabIndex = 29;
            this.btnConvertWav.Text = "Convert WAV >>";
            this.btnConvertWav.UseVisualStyleBackColor = true;
            this.btnConvertWav.Click += new System.EventHandler(this.btnConvertWav_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(770, 685);
            this.Controls.Add(this.btnConvertWav);
            this.Controls.Add(this.btnBuildMP3);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.tbMP3Dir);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.tbVideoDir);
            this.Controls.Add(this.btnOpenIndexFile);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tbExternalDrive);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tbIndexFile);
            this.Controls.Add(this.btnStage5);
            this.Controls.Add(this.btnStage4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbHowmany);
            this.Controls.Add(this.btnStage2);
            this.Controls.Add(this.btnStage3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbStage2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbStage1);
            this.Controls.Add(this.tbStatus);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbOutputs);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbInputs);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "MP3 App";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.TextBox tbInputs;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox tbOutputs;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbStatus;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbStage1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbStage2;
        private System.Windows.Forms.Button btnStage3;
        private System.Windows.Forms.Button btnStage2;
        private System.Windows.Forms.TextBox tbHowmany;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button btnStage4;
        private System.Windows.Forms.Button btnStage5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbIndexFile;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbExternalDrive;
        private System.Windows.Forms.Button btnOpenIndexFile;
        private System.Windows.Forms.Button btnBuildMP3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbMP3Dir;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbVideoDir;
        private System.Windows.Forms.Button btnConvertWav;
    }
}

