namespace GazeTracking
{
    partial class Form2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.calibrationPoint = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.calibrationPoint)).BeginInit();
            this.SuspendLayout();
            // 
            // calibrationPoint
            // 
            this.calibrationPoint.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.calibrationPoint.Image = ((System.Drawing.Image)(resources.GetObject("calibrationPoint.Image")));
            this.calibrationPoint.InitialImage = null;
            this.calibrationPoint.Location = new System.Drawing.Point(649, 262);
            this.calibrationPoint.Margin = new System.Windows.Forms.Padding(0);
            this.calibrationPoint.Name = "calibrationPoint";
            this.calibrationPoint.Size = new System.Drawing.Size(30, 30);
            this.calibrationPoint.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.calibrationPoint.TabIndex = 0;
            this.calibrationPoint.TabStop = false;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1904, 1064);
            this.ControlBox = false;
            this.Controls.Add(this.calibrationPoint);
            this.Name = "Form2";
            this.TransparencyKey = System.Drawing.Color.White;
            ((System.ComponentModel.ISupportInitialize)(this.calibrationPoint)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox calibrationPoint;
    }
}