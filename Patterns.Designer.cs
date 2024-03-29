﻿namespace PlayNotes
{
    partial class Patterns
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
            this.gbPatternOptions = new System.Windows.Forms.GroupBox();
            this.tbCustomPattern = new System.Windows.Forms.TextBox();
            this.cbMRU = new System.Windows.Forms.ComboBox();
            this.rbYourOwn = new System.Windows.Forms.RadioButton();
            this.rbA1B1A2B2 = new System.Windows.Forms.RadioButton();
            this.rbA1A1A2 = new System.Windows.Forms.RadioButton();
            this.rbA1A1 = new System.Windows.Forms.RadioButton();
            this.btnPlayPattern = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.gbPatternOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbPatternOptions
            // 
            this.gbPatternOptions.Controls.Add(this.tbCustomPattern);
            this.gbPatternOptions.Controls.Add(this.cbMRU);
            this.gbPatternOptions.Controls.Add(this.rbYourOwn);
            this.gbPatternOptions.Controls.Add(this.rbA1B1A2B2);
            this.gbPatternOptions.Controls.Add(this.rbA1A1A2);
            this.gbPatternOptions.Controls.Add(this.rbA1A1);
            this.gbPatternOptions.Location = new System.Drawing.Point(15, 20);
            this.gbPatternOptions.Name = "gbPatternOptions";
            this.gbPatternOptions.Size = new System.Drawing.Size(340, 240);
            this.gbPatternOptions.TabIndex = 0;
            this.gbPatternOptions.TabStop = false;
            // 
            // tbCustomPattern
            // 
            this.tbCustomPattern.Location = new System.Drawing.Point(21, 187);
            this.tbCustomPattern.Name = "tbCustomPattern";
            this.tbCustomPattern.Size = new System.Drawing.Size(274, 26);
            this.tbCustomPattern.TabIndex = 4;
            this.tbCustomPattern.TextChanged += new System.EventHandler(this.tbCustomPattern_TextChanged);
            // 
            // cbMRU
            // 
            this.cbMRU.FormattingEnabled = true;
            this.cbMRU.Location = new System.Drawing.Point(20, 185);
            this.cbMRU.Name = "cbMRU";
            this.cbMRU.Size = new System.Drawing.Size(299, 28);
            this.cbMRU.TabIndex = 5;
            this.cbMRU.SelectedIndexChanged += new System.EventHandler(this.cbMRU_SelectedIndexChanged);
            // 
            // rbYourOwn
            // 
            this.rbYourOwn.AutoSize = true;
            this.rbYourOwn.Location = new System.Drawing.Point(21, 149);
            this.rbYourOwn.Name = "rbYourOwn";
            this.rbYourOwn.Size = new System.Drawing.Size(118, 24);
            this.rbYourOwn.TabIndex = 3;
            this.rbYourOwn.Text = "(Your Own):";
            this.rbYourOwn.UseVisualStyleBackColor = true;
            // 
            // rbA1B1A2B2
            // 
            this.rbA1B1A2B2.AutoSize = true;
            this.rbA1B1A2B2.Enabled = false;
            this.rbA1B1A2B2.Location = new System.Drawing.Point(21, 108);
            this.rbA1B1A2B2.Name = "rbA1B1A2B2";
            this.rbA1B1A2B2.Size = new System.Drawing.Size(114, 24);
            this.rbA1B1A2B2.TabIndex = 2;
            this.rbA1B1A2B2.Text = "A1B1A2B2";
            this.rbA1B1A2B2.UseVisualStyleBackColor = true;
            // 
            // rbA1A1A2
            // 
            this.rbA1A1A2.AutoSize = true;
            this.rbA1A1A2.Location = new System.Drawing.Point(21, 67);
            this.rbA1A1A2.Name = "rbA1A1A2";
            this.rbA1A1A2.Size = new System.Drawing.Size(154, 24);
            this.rbA1A1A2.TabIndex = 1;
            this.rbA1A1A2.Text = "A1A1A2A1A1A2";
            this.rbA1A1A2.UseVisualStyleBackColor = true;
            // 
            // rbA1A1
            // 
            this.rbA1A1.AutoSize = true;
            this.rbA1A1.Checked = true;
            this.rbA1A1.Location = new System.Drawing.Point(21, 26);
            this.rbA1A1.Name = "rbA1A1";
            this.rbA1A1.Size = new System.Drawing.Size(154, 24);
            this.rbA1A1.TabIndex = 0;
            this.rbA1A1.TabStop = true;
            this.rbA1A1.Text = "A1A1A2A2A3A3";
            this.rbA1A1.UseVisualStyleBackColor = true;
            // 
            // btnPlayPattern
            // 
            this.btnPlayPattern.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPlayPattern.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnPlayPattern.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnPlayPattern.Location = new System.Drawing.Point(263, 275);
            this.btnPlayPattern.Name = "btnPlayPattern";
            this.btnPlayPattern.Size = new System.Drawing.Size(92, 41);
            this.btnPlayPattern.TabIndex = 1;
            this.btnPlayPattern.Text = "Play";
            this.btnPlayPattern.UseVisualStyleBackColor = false;
            this.btnPlayPattern.Click += new System.EventHandler(this.btnPlayPattern_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.BackColor = System.Drawing.Color.Maroon;
            this.btnRefresh.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnRefresh.Location = new System.Drawing.Point(156, 275);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(92, 41);
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // Patterns
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(369, 330);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnPlayPattern);
            this.Controls.Add(this.gbPatternOptions);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Patterns";
            this.Text = "Patterns";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Patterns_FormClosing);
            this.gbPatternOptions.ResumeLayout(false);
            this.gbPatternOptions.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbPatternOptions;
        private System.Windows.Forms.TextBox tbCustomPattern;
        private System.Windows.Forms.RadioButton rbYourOwn;
        private System.Windows.Forms.RadioButton rbA1B1A2B2;
        private System.Windows.Forms.RadioButton rbA1A1A2;
        private System.Windows.Forms.RadioButton rbA1A1;
        private System.Windows.Forms.Button btnPlayPattern;
        private System.Windows.Forms.ComboBox cbMRU;
        private System.Windows.Forms.Button btnRefresh;
    }
}