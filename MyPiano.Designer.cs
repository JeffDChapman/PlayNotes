namespace PlayNotes
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
            ((System.ComponentModel.ISupportInitialize)(this.tbMinFreq)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbMaxFreq)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbNoteDur)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbPhrases)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbDensity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbMinBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbMaxBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbSweep)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.upDownKey)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGo
            // 
            this.btnGo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnGo.Location = new System.Drawing.Point(455, 449);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(121, 52);
            this.btnGo.TabIndex = 0;
            this.btnGo.Text = "Play Phrase";
            this.btnGo.UseVisualStyleBackColor = false;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // cbContinuous
            // 
            this.cbContinuous.AutoSize = true;
            this.cbContinuous.Location = new System.Drawing.Point(457, 520);
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
            this.tbMinFreq.Size = new System.Drawing.Size(442, 69);
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
            this.tbMaxFreq.Size = new System.Drawing.Size(442, 69);
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
            this.lblMinBar.Location = new System.Drawing.Point(21, 285);
            this.lblMinBar.Name = "lblMinBar";
            this.lblMinBar.Size = new System.Drawing.Size(111, 20);
            this.lblMinBar.TabIndex = 13;
            this.lblMinBar.Text = "Min Bar Len: 2";
            // 
            // tbMinBar
            // 
            this.tbMinBar.LargeChange = 4;
            this.tbMinBar.Location = new System.Drawing.Point(150, 277);
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
            this.lblMaxBar.Location = new System.Drawing.Point(21, 337);
            this.lblMaxBar.Name = "lblMaxBar";
            this.lblMaxBar.Size = new System.Drawing.Size(115, 20);
            this.lblMaxBar.TabIndex = 15;
            this.lblMaxBar.Text = "Max Bar Len: 4";
            // 
            // tbMaxBar
            // 
            this.tbMaxBar.LargeChange = 4;
            this.tbMaxBar.Location = new System.Drawing.Point(150, 330);
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
            this.lblSweep.Location = new System.Drawing.Point(21, 390);
            this.lblSweep.Name = "lblSweep";
            this.lblSweep.Size = new System.Drawing.Size(107, 20);
            this.lblSweep.TabIndex = 17;
            this.lblSweep.Text = "Sweep: 103%";
            // 
            // tbSweep
            // 
            this.tbSweep.Location = new System.Drawing.Point(150, 383);
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
            this.lblKey.Location = new System.Drawing.Point(22, 458);
            this.lblKey.Name = "lblKey";
            this.lblKey.Size = new System.Drawing.Size(44, 20);
            this.lblKey.TabIndex = 18;
            this.lblKey.Text = "Gen:";
            // 
            // tbKey
            // 
            this.tbKey.BackColor = System.Drawing.Color.Silver;
            this.tbKey.ForeColor = System.Drawing.Color.Navy;
            this.tbKey.Location = new System.Drawing.Point(69, 456);
            this.tbKey.Name = "tbKey";
            this.tbKey.Size = new System.Drawing.Size(38, 26);
            this.tbKey.TabIndex = 19;
            this.tbKey.Text = "A";
            this.tbKey.TextChanged += new System.EventHandler(this.tbKey_TextChanged);
            // 
            // upDownKey
            // 
            this.upDownKey.Location = new System.Drawing.Point(115, 456);
            this.upDownKey.Name = "upDownKey";
            this.upDownKey.Size = new System.Drawing.Size(26, 26);
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
            this.btnSaveKey.Location = new System.Drawing.Point(160, 452);
            this.btnSaveKey.Name = "btnSaveKey";
            this.btnSaveKey.Size = new System.Drawing.Size(87, 34);
            this.btnSaveKey.TabIndex = 21;
            this.btnSaveKey.Text = "Save";
            this.btnSaveKey.UseVisualStyleBackColor = true;
            this.btnSaveKey.Click += new System.EventHandler(this.btnSaveKey_Click);
            // 
            // MyPiano
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(612, 560);
            this.Controls.Add(this.btnSaveKey);
            this.Controls.Add(this.upDownKey);
            this.Controls.Add(this.tbKey);
            this.Controls.Add(this.lblKey);
            this.Controls.Add(this.lblSweep);
            this.Controls.Add(this.tbSweep);
            this.Controls.Add(this.lblMaxBar);
            this.Controls.Add(this.tbMaxBar);
            this.Controls.Add(this.lblMinBar);
            this.Controls.Add(this.tbMinBar);
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
            this.Name = "MyPiano";
            this.Text = "My Piano";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            ((System.ComponentModel.ISupportInitialize)(this.tbMinFreq)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbMaxFreq)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbNoteDur)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbPhrases)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbDensity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbMinBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbMaxBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbSweep)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.upDownKey)).EndInit();
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
        private System.Windows.Forms.TextBox tbKey;
        private System.Windows.Forms.NumericUpDown upDownKey;
        private System.Windows.Forms.Button btnSaveKey;
    }
}

