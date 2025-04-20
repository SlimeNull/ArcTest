namespace ArcTest
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
            arcRenderer1 = new ArcRenderer();
            trackBar1 = new TrackBar();
            ((System.ComponentModel.ISupportInitialize)trackBar1).BeginInit();
            SuspendLayout();
            // 
            // arcRenderer1
            // 
            arcRenderer1.CircleThickness = 0F;
            arcRenderer1.End = 0F;
            arcRenderer1.Location = new Point(227, 63);
            arcRenderer1.Name = "arcRenderer1";
            arcRenderer1.Size = new Size(334, 178);
            arcRenderer1.Start = 0F;
            arcRenderer1.TabIndex = 0;
            arcRenderer1.Text = "arcRenderer1";
            // 
            // trackBar1
            // 
            trackBar1.Location = new Point(242, 339);
            trackBar1.Maximum = 360;
            trackBar1.Name = "trackBar1";
            trackBar1.Size = new Size(342, 56);
            trackBar1.TabIndex = 1;
            trackBar1.Scroll += trackBar1_Scroll;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(trackBar1);
            Controls.Add(arcRenderer1);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)trackBar1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ArcRenderer arcRenderer1;
        private TrackBar trackBar1;
    }
}
