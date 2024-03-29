﻿namespace PlayNotes
{
    partial class MyPiano
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
            this.btnGo = new System.Windows.Forms.Button();
            this.cbContinuous = new System.Windows.Forms.CheckBox();
            this.tbMinFreq = new System.Windows.Forms.TrackBar();
            this.lblMinFreq = new System.Windows.Forms.Label();
            this.lblMaxFreq = new System.Windows.Forms.Label();
            this.tbMaxFreq = new System.Windows.Forms.TrackBar();
            this.lblNoteDur = new System.Windows.Forms.Label();
            this.tbNoteDur = new System.Windows.Forms.TrackBar();
            this.lblPhrases = new System.Windows.Forms.Label();
            this.tbPhrases = new System.Windows.Forms.TrackBar();
            this.lblNoteDensity = new System.Windows.Forms.Label();
            this.tbDensity = new System.Windows.Forms.TrackBar();
            this.lblMinBar = new System.Windows.Forms.Label();
            this.tbMinBar = new System.Windows.Forms.TrackBar();
            this.lblMaxBar = new System.Windows.Forms.Label();
            this.tbMaxBar = new System.Windows.Forms.TrackBar();
            this.lblSweep = new System.Windows.Forms.Label();
            this.tbSweep = new System.Windows.Forms.TrackBar();
            this.lblKey = new System.Windows.Forms.Label();
            this.tbKey = new System.Windows.Forms.TextBox();
            this.upDownKey = new System.Windows.Forms.NumericUpDown();
            this.btnSaveKey = new System.Windows.Forms.Button();
            this.btnNewKey = new System.Windows.Forms.Button();
            this.btnPatterns = new System.Windows.Forms.Button();
            this.lblMaxJump = new System.Windows.Forms.Label();
            this.tbMaxJump = new System.Windows.Forms.TrackBar();
            this.btnSaveOverlay = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.tbMinFreq)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbMaxFreq)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbNoteDur)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbPhrases)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbDensity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbMinBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbMaxBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbSweep)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.upDownKey)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbMaxJump)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGo
            // 
            this.btnGo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnGo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnGo.Location = new System.Drawing.Point(69, 543);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(121, 40);
            this.btnGo.TabIndex = 0;
            this.btnGo.Text = "Play Phrase";
            this.btnGo.UseVisualStyleBackColor = false;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // cbContinuous
            // 
            this.cbContinuous.AutoSize = true;
            this.cbContinuous.Location = new System.Drawing.Point(206, 552);
            this.cbContinuous.Name = "cbContinuous";
            this.cbContinuous.Size = new System.Drawing.Size(116, 24);
            this.cbContinuous.TabIndex = 1;
            this.cbContinuous.Text = "Continuous";
            this.cbContinuous.UseVisualStyleBackColor = true;
            // 
            // tbMinFreq
            // 
            this.tbMinFreq.LargeChange = 25;
            this.tbMinFreq.Location = new System.Drawing.Point(150, 12);
            this.tbMinFreq.Maximum = 600;
            this.tbMinFreq.Minimum = 300;
            this.tbMinFreq.Name = "tbMinFreq";
            this.tbMinFreq.Size = new System.Drawing.Size(391, 69);
            this.tbMinFreq.SmallChange = 2;
            this.tbMinFreq.TabIndex = 2;
            this.tbMinFreq.TickFrequency = 20;
            this.tbMinFreq.Value = 300;
            this.tbMinFreq.ValueChanged += new System.EventHandler(this.tbMinFreq_ValueChanged);
            // 
            // lblMinFreq
            // 
            this.lblMinFreq.AutoSize = true;
            this.lblMinFreq.Location = new System.Drawing.Point(21, 18);
            this.lblMinFreq.Name = "lblMinFreq";
            this.lblMinFreq.Size = new System.Drawing.Size(106, 20);
            this.lblMinFreq.TabIndex = 3;
            this.lblMinFreq.Text = "Min Freq: 300";
            // 
            // lblMaxFreq
            // 
            this.lblMaxFreq.AutoSize = true;
            this.lblMaxFreq.Location = new System.Drawing.Point(22, 66);
            this.lblMaxFreq.Name = "lblMaxFreq";
            this.lblMaxFreq.Size = new System.Drawing.Size(119, 20);
            this.lblMaxFreq.TabIndex = 5;
            this.lblMaxFreq.Text = "Max Freq: 1200";
            // 
            // tbMaxFreq
            // 
            this.tbMaxFreq.LargeChange = 100;
            this.tbMaxFreq.Location = new System.Drawing.Point(150, 65);
            this.tbMaxFreq.Maximum = 1600;
            this.tbMaxFreq.Minimum = 600;
            this.tbMaxFreq.Name = "tbMaxFreq";
            this.tbMaxFreq.Size = new System.Drawing.Size(391, 69);
            this.tbMaxFreq.SmallChange = 10;
            this.tbMaxFreq.TabIndex = 4;
            this.tbMaxFreq.TickFrequency = 40;
            this.tbMaxFreq.Value = 1200;
            this.tbMaxFreq.ValueChanged += new System.EventHandler(this.tbMaxFreq_ValueChanged);
            // 
            // lblNoteDur
            // 
            this.lblNoteDur.AutoSize = true;
            this.lblNoteDur.Location = new System.Drawing.Point(22, 120);
            this.lblNoteDur.Name = "lblNoteDur";
            this.lblNoteDur.Size = new System.Drawing.Size(108, 20);
            this.lblNoteDur.TabIndex = 7;
            this.lblNoteDur.Text = "Note Dur: 500";
            // 
            // tbNoteDur
            // 
            this.tbNoteDur.LargeChange = 100;
            this.tbNoteDur.Location = new System.Drawing.Point(150, 118);
            this.tbNoteDur.Maximum = 2000;
            this.tbNoteDur.Minimum = 125;
            this.tbNoteDur.Name = "tbNoteDur";
            this.tbNoteDur.Size = new System.Drawing.Size(442, 69);
            this.tbNoteDur.SmallChange = 10;
            this.tbNoteDur.TabIndex = 6;
            this.tbNoteDur.TickFrequency = 100;
            this.tbNoteDur.Value = 500;
            this.tbNoteDur.ValueChanged += new System.EventHandler(this.tbNoteDur_ValueChanged);
            // 
            // lblPhrases
            // 
            this.lblPhrases.AutoSize = true;
            this.lblPhrases.Location = new System.Drawing.Point(21, 173);
            this.lblPhrases.Name = "lblPhrases";
            this.lblPhrases.Size = new System.Drawing.Size(84, 20);
            this.lblPhrases.TabIndex = 9;
            this.lblPhrases.Text = "Phrases: 6";
            // 
            // tbPhrases
            // 
            this.tbPhrases.LargeChange = 6;
            this.tbPhrases.Location = new System.Drawing.Point(150, 171);
            this.tbPhrases.Maximum = 32;
            this.tbPhrases.Minimum = 3;
            this.tbPhrases.Name = "tbPhrases";
            this.tbPhrases.Size = new System.Drawing.Size(442, 69);
            this.tbPhrases.TabIndex = 8;
            this.tbPhrases.Value = 6;
            this.tbPhrases.ValueChanged += new System.EventHandler(this.tbPhrases_ValueChanged);
            // 
            // lblNoteDensity
            // 
            this.lblNoteDensity.AutoSize = true;
            this.lblNoteDensity.Location = new System.Drawing.Point(21, 231);
            this.lblNoteDensity.Name = "lblNoteDensity";
            this.lblNoteDensity.Size = new System.Drawing.Size(126, 20);
            this.lblNoteDensity.TabIndex = 11;
            this.lblNoteDensity.Text = "Note Density: 16";
            // 
            // tbDensity
            // 
            this.tbDensity.LargeChange = 4;
            this.tbDensity.Location = new System.Drawing.Point(150, 224);
            this.tbDensity.Maximum = 32;
            this.tbDensity.Minimum = 4;
            this.tbDensity.Name = "tbDensity";
            this.tbDensity.Size = new System.Drawing.Size(442, 69);
            this.tbDensity.SmallChange = 2;
            this.tbDensity.TabIndex = 10;
            this.tbDensity.Value = 16;
            this.tbDensity.ValueChanged += new System.EventHandler(this.tbDensity_ValueChanged);
            // 
            // lblMinBar
            // 
            this.lblMinBar.AutoSize = true;
            this.lblMinBar.Location = new System.Drawing.Point(21, 336);
            this.lblMinBar.Name = "lblMinBar";
            this.lblMinBar.Size = new System.Drawing.Size(111, 20);
            this.lblMinBar.TabIndex = 13;
            this.lblMinBar.Text = "Min Bar Len: 2";
            // 
            // tbMinBar
            // 
            this.tbMinBar.LargeChange = 4;
            this.tbMinBar.Location = new System.Drawing.Point(150, 330);
            this.tbMinBar.Maximum = 16;
            this.tbMinBar.Minimum = 1;
            this.tbMinBar.Name = "tbMinBar";
            this.tbMinBar.Size = new System.Drawing.Size(442, 69);
            this.tbMinBar.TabIndex = 12;
            this.tbMinBar.Value = 2;
            this.tbMinBar.ValueChanged += new System.EventHandler(this.tbMinBar_ValueChanged);
            // 
            // lblMaxBar
            // 
            this.lblMaxBar.AutoSize = true;
            this.lblMaxBar.Location = new System.Drawing.Point(21, 389);
            this.lblMaxBar.Name = "lblMaxBar";
            this.lblMaxBar.Size = new System.Drawing.Size(115, 20);
            this.lblMaxBar.TabIndex = 15;
            this.lblMaxBar.Text = "Max Bar Len: 4";
            // 
            // tbMaxBar
            // 
            this.tbMaxBar.LargeChange = 4;
            this.tbMaxBar.Location = new System.Drawing.Point(150, 383);
            this.tbMaxBar.Maximum = 16;
            this.tbMaxBar.Minimum = 1;
            this.tbMaxBar.Name = "tbMaxBar";
            this.tbMaxBar.Size = new System.Drawing.Size(442, 69);
            this.tbMaxBar.TabIndex = 14;
            this.tbMaxBar.Value = 4;
            this.tbMaxBar.ValueChanged += new System.EventHandler(this.tbMaxBar_ValueChanged);
            // 
            // lblSweep
            // 
            this.lblSweep.AutoSize = true;
            this.lblSweep.Location = new System.Drawing.Point(21, 442);
            this.lblSweep.Name = "lblSweep";
            this.lblSweep.Size = new System.Drawing.Size(107, 20);
            this.lblSweep.TabIndex = 17;
            this.lblSweep.Text = "Sweep: 103%";
            // 
            // tbSweep
            // 
            this.tbSweep.Location = new System.Drawing.Point(150, 436);
            this.tbSweep.Maximum = 120;
            this.tbSweep.Minimum = 100;
            this.tbSweep.Name = "tbSweep";
            this.tbSweep.Size = new System.Drawing.Size(442, 69);
            this.tbSweep.SmallChange = 2;
            this.tbSweep.TabIndex = 16;
            this.tbSweep.TickFrequency = 2;
            this.tbSweep.Value = 103;
            this.tbSweep.ValueChanged += new System.EventHandler(this.tbSweep_ValueChanged);
            // 
            // lblKey
            // 
            this.lblKey.AutoSize = true;
            this.lblKey.Location = new System.Drawing.Point(22, 496);
            this.lblKey.Name = "lblKey";
            this.lblKey.Size = new System.Drawing.Size(44, 20);
            this.lblKey.TabIndex = 18;
            this.lblKey.Text = "Gen:";
            // 
            // tbKey
            // 
            this.tbKey.BackColor = System.Drawing.Color.Silver;
            this.tbKey.ForeColor = System.Drawing.Color.Navy;
            this.tbKey.Location = new System.Drawing.Point(69, 494);
            this.tbKey.Name = "tbKey";
            this.tbKey.Size = new System.Drawing.Size(38, 26);
            this.tbKey.TabIndex = 19;
            this.tbKey.Text = "A";
            this.tbKey.TextChanged += new System.EventHandler(this.tbKey_TextChanged);
            // 
            // upDownKey
            // 
            this.upDownKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.upDownKey.Location = new System.Drawing.Point(552, 28);
            this.upDownKey.Name = "upDownKey";
            this.upDownKey.Size = new System.Drawing.Size(26, 53);
            this.upDownKey.TabIndex = 20;
            this.upDownKey.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.upDownKey.ValueChanged += new System.EventHandler(this.upDownKey_ValueChanged);
            // 
            // btnSaveKey
            // 
            this.btnSaveKey.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnSaveKey.Location = new System.Drawing.Point(122, 491);
            this.btnSaveKey.Name = "btnSaveKey";
            this.btnSaveKey.Size = new System.Drawing.Size(87, 34);
            this.btnSaveKey.TabIndex = 21;
            this.btnSaveKey.Text = "Save";
            this.btnSaveKey.UseVisualStyleBackColor = true;
            this.btnSaveKey.Click += new System.EventHandler(this.btnSaveKey_Click);
            // 
            // btnNewKey
            // 
            this.btnNewKey.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnNewKey.Location = new System.Drawing.Point(222, 491);
            this.btnNewKey.Name = "btnNewKey";
            this.btnNewKey.Size = new System.Drawing.Size(87, 34);
            this.btnNewKey.TabIndex = 22;
            this.btnNewKey.Text = "New";
            this.btnNewKey.UseVisualStyleBackColor = true;
            this.btnNewKey.Visible = false;
            this.btnNewKey.Click += new System.EventHandler(this.btnNewKey_Click);
            // 
            // btnPatterns
            // 
            this.btnPatterns.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btnPatterns.ForeColor = System.Drawing.Color.Maroon;
            this.btnPatterns.Location = new System.Drawing.Point(460, 543);
            this.btnPatterns.Name = "btnPatterns";
            this.btnPatterns.Size = new System.Drawing.Size(132, 40);
            this.btnPatterns.TabIndex = 23;
            this.btnPatterns.Text = "Patterns...";
            this.btnPatterns.UseVisualStyleBackColor = false;
            this.btnPatterns.Click += new System.EventHandler(this.btnPatterns_Click);
            // 
            // lblMaxJump
            // 
            this.lblMaxJump.AutoSize = true;
            this.lblMaxJump.Location = new System.Drawing.Point(21, 285);
            this.lblMaxJump.Name = "lblMaxJump";
            this.lblMaxJump.Size = new System.Drawing.Size(98, 20);
            this.lblMaxJump.TabIndex = 25;
            this.lblMaxJump.Text = "Max Jump: 6";
            // 
            // tbMaxJump
            // 
            this.tbMaxJump.LargeChange = 4;
            this.tbMaxJump.Location = new System.Drawing.Point(150, 277);
            this.tbMaxJump.Maximum = 30;
            this.tbMaxJump.Minimum = 2;
            this.tbMaxJump.Name = "tbMaxJump";
            this.tbMaxJump.Size = new System.Drawing.Size(442, 69);
            this.tbMaxJump.SmallChange = 2;
            this.tbMaxJump.TabIndex = 24;
            this.tbMaxJump.Value = 6;
            this.tbMaxJump.ValueChanged += new System.EventHandler(this.tbMaxJump_ValueChanged);
            // 
            // btnSaveOverlay
            // 
            this.btnSaveOverlay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnSaveOverlay.ForeColor = System.Drawing.Color.Black;
            this.btnSaveOverlay.Location = new System.Drawing.Point(122, 491);
            this.btnSaveOverlay.Name = "btnSaveOverlay";
            this.btnSaveOverlay.Size = new System.Drawing.Size(87, 34);
            this.btnSaveOverlay.TabIndex = 26;
            this.btnSaveOverlay.Text = "Save";
            this.btnSaveOverlay.UseVisualStyleBackColor = false;
            this.btnSaveOverlay.Visible = false;
            // 
            // MyPiano
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(612, 606);
            this.Controls.Add(this.btnNewKey);
            this.Controls.Add(this.btnSaveKey);
            this.Controls.Add(this.tbSweep);
            this.Controls.Add(this.tbMaxBar);
            this.Controls.Add(this.tbMinBar);
            this.Controls.Add(this.lblMaxJump);
            this.Controls.Add(this.tbMaxJump);
            this.Controls.Add(this.btnPatterns);
            this.Controls.Add(this.upDownKey);
            this.Controls.Add(this.tbKey);
            this.Controls.Add(this.lblKey);
            this.Controls.Add(this.lblSweep);
            this.Controls.Add(this.lblMaxBar);
            this.Controls.Add(this.lblMinBar);
            this.Controls.Add(this.lblNoteDensity);
            this.Controls.Add(this.tbDensity);
            this.Controls.Add(this.lblPhrases);
            this.Controls.Add(this.tbPhrases);
            this.Controls.Add(this.lblNoteDur);
            this.Controls.Add(this.tbNoteDur);
            this.Controls.Add(this.lblMaxFreq);
            this.Controls.Add(this.tbMaxFreq);
            this.Controls.Add(this.lblMinFreq);
            this.Controls.Add(this.tbMinFreq);
            this.Controls.Add(this.cbContinuous);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.btnSaveOverlay);
            this.Name = "MyPiano";
            this.Text = "My Piano";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MyPiano_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.tbMinFreq)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbMaxFreq)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbNoteDur)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbPhrases)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbDensity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbMinBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbMaxBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbSweep)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.upDownKey)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbMaxJump)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.CheckBox cbContinuous;
        private System.Windows.Forms.TrackBar tbMinFreq;
        private System.Windows.Forms.Label lblMinFreq;
        private System.Windows.Forms.Label lblMaxFreq;
        private System.Windows.Forms.TrackBar tbMaxFreq;
        private System.Windows.Forms.Label lblNoteDur;
        private System.Windows.Forms.TrackBar tbNoteDur;
        private System.Windows.Forms.Label lblPhrases;
        private System.Windows.Forms.TrackBar tbPhrases;
        private System.Windows.Forms.Label lblNoteDensity;
        private System.Windows.Forms.TrackBar tbDensity;
        private System.Windows.Forms.Label lblMinBar;
        private System.Windows.Forms.TrackBar tbMinBar;
        private System.Windows.Forms.Label lblMaxBar;
        private System.Windows.Forms.TrackBar tbMaxBar;
        private System.Windows.Forms.Label lblSweep;
        private System.Windows.Forms.TrackBar tbSweep;
        private System.Windows.Forms.Label lblKey;
        private System.Windows.Forms.NumericUpDown upDownKey;
        private System.Windows.Forms.Button btnSaveKey;
        private System.Windows.Forms.Button btnNewKey;
        private System.Windows.Forms.Button btnPatterns;
        public System.Windows.Forms.TextBox tbKey;
        private System.Windows.Forms.Label lblMaxJump;
        private System.Windows.Forms.TrackBar tbMaxJump;
        private System.Windows.Forms.Button btnSaveOverlay;
    }
}

