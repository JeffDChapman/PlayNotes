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
            ((System.ComponentModel.ISupportInitialize)(this.tbMinFreq)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbMaxFreq)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbNoteDur)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGo
            // 
            this.btnGo.Location = new System.Drawing.Point(475, 404);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(100, 52);
            this.btnGo.TabIndex = 0;
            this.btnGo.Text = "Go";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // cbContinuous
            // 
            this.cbContinuous.AutoSize = true;
            this.cbContinuous.Location = new System.Drawing.Point(467, 480);
            this.cbContinuous.Name = "cbContinuous";
            this.cbContinuous.Size = new System.Drawing.Size(116, 24);
            this.cbContinuous.TabIndex = 1;
            this.cbContinuous.Text = "Continuous";
            this.cbContinuous.UseVisualStyleBackColor = true;
            // 
            // tbMinFreq
            // 
            this.tbMinFreq.LargeChange = 100;
            this.tbMinFreq.Location = new System.Drawing.Point(142, 12);
            this.tbMinFreq.Maximum = 600;
            this.tbMinFreq.Minimum = 300;
            this.tbMinFreq.Name = "tbMinFreq";
            this.tbMinFreq.Size = new System.Drawing.Size(442, 69);
            this.tbMinFreq.SmallChange = 10;
            this.tbMinFreq.TabIndex = 2;
            this.tbMinFreq.TickFrequency = 20;
            this.tbMinFreq.Value = 300;
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
            this.tbMaxFreq.Location = new System.Drawing.Point(142, 60);
            this.tbMaxFreq.Maximum = 2000;
            this.tbMaxFreq.Minimum = 1200;
            this.tbMaxFreq.Name = "tbMaxFreq";
            this.tbMaxFreq.Size = new System.Drawing.Size(442, 69);
            this.tbMaxFreq.SmallChange = 10;
            this.tbMaxFreq.TabIndex = 4;
            this.tbMaxFreq.TickFrequency = 40;
            this.tbMaxFreq.Value = 1200;
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
            this.tbNoteDur.Location = new System.Drawing.Point(142, 114);
            this.tbNoteDur.Maximum = 2000;
            this.tbNoteDur.Minimum = 125;
            this.tbNoteDur.Name = "tbNoteDur";
            this.tbNoteDur.Size = new System.Drawing.Size(442, 69);
            this.tbNoteDur.SmallChange = 10;
            this.tbNoteDur.TabIndex = 6;
            this.tbNoteDur.TickFrequency = 100;
            this.tbNoteDur.Value = 500;
            // 
            // MyPiano
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(612, 528);
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
    }
}

