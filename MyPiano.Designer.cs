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
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.tbMinFreq)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGo
            // 
            this.btnGo.Location = new System.Drawing.Point(599, 404);
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
            this.cbContinuous.Location = new System.Drawing.Point(591, 480);
            this.cbContinuous.Name = "cbContinuous";
            this.cbContinuous.Size = new System.Drawing.Size(116, 24);
            this.cbContinuous.TabIndex = 1;
            this.cbContinuous.Text = "Continuous";
            this.cbContinuous.UseVisualStyleBackColor = true;
            // 
            // tbMinFreq
            // 
            this.tbMinFreq.LargeChange = 100;
            this.tbMinFreq.Location = new System.Drawing.Point(199, 12);
            this.tbMinFreq.Maximum = 600;
            this.tbMinFreq.Minimum = 300;
            this.tbMinFreq.Name = "tbMinFreq";
            this.tbMinFreq.Size = new System.Drawing.Size(442, 69);
            this.tbMinFreq.SmallChange = 10;
            this.tbMinFreq.TabIndex = 2;
            this.tbMinFreq.TickFrequency = 20;
            this.tbMinFreq.Value = 300;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Min Freq:";
            // 
            // MyPiano
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(746, 528);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbMinFreq);
            this.Controls.Add(this.cbContinuous);
            this.Controls.Add(this.btnGo);
            this.Name = "MyPiano";
            this.Text = "My Piano";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            ((System.ComponentModel.ISupportInitialize)(this.tbMinFreq)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.CheckBox cbContinuous;
        private System.Windows.Forms.TrackBar tbMinFreq;
        private System.Windows.Forms.Label label1;
    }
}

