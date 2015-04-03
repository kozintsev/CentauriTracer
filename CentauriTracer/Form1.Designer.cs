namespace WindowsFormsApplication1
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
            this.mkStartButt = new System.Windows.Forms.Button();
            this.FrontWaveButt = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // mkStartButt
            // 
            this.mkStartButt.Location = new System.Drawing.Point(445, 454);
            this.mkStartButt.Name = "mkStartButt";
            this.mkStartButt.Size = new System.Drawing.Size(75, 23);
            this.mkStartButt.TabIndex = 0;
            this.mkStartButt.Text = "Make start";
            this.mkStartButt.UseVisualStyleBackColor = true;
            this.mkStartButt.Click += new System.EventHandler(this.mkStartButt_Click);
            // 
            // FrontWaveButt
            // 
            this.FrontWaveButt.Location = new System.Drawing.Point(445, 423);
            this.FrontWaveButt.Name = "FrontWaveButt";
            this.FrontWaveButt.Size = new System.Drawing.Size(75, 23);
            this.FrontWaveButt.TabIndex = 1;
            this.FrontWaveButt.Text = "Front Wave";
            this.FrontWaveButt.UseVisualStyleBackColor = true;
            this.FrontWaveButt.Click += new System.EventHandler(this.FrontWaveButt_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(532, 489);
            this.Controls.Add(this.FrontWaveButt);
            this.Controls.Add(this.mkStartButt);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.Resize += new System.EventHandler(this.Form_Resize);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button mkStartButt;
        private System.Windows.Forms.Button FrontWaveButt;
    }
}

