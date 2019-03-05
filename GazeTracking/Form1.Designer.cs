namespace GazeTracking
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
            this.findEyeTracker_button = new System.Windows.Forms.Button();
            this.calibrate_button = new System.Windows.Forms.Button();
            this.collectData_button = new System.Windows.Forms.Button();
            this.info_textBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // findEyeTracker_button
            // 
            this.findEyeTracker_button.Location = new System.Drawing.Point(20, 24);
            this.findEyeTracker_button.Name = "findEyeTracker_button";
            this.findEyeTracker_button.Size = new System.Drawing.Size(100, 25);
            this.findEyeTracker_button.TabIndex = 0;
            this.findEyeTracker_button.Text = "Find Eye Tracker";
            this.findEyeTracker_button.UseVisualStyleBackColor = true;
            this.findEyeTracker_button.Click += new System.EventHandler(this.findEyeTracker_button_Click);
            // 
            // calibrate_button
            // 
            this.calibrate_button.Location = new System.Drawing.Point(160, 24);
            this.calibrate_button.Name = "calibrate_button";
            this.calibrate_button.Size = new System.Drawing.Size(100, 25);
            this.calibrate_button.TabIndex = 1;
            this.calibrate_button.Text = "Calibrate\r\n";
            this.calibrate_button.UseVisualStyleBackColor = true;
            this.calibrate_button.Click += new System.EventHandler(this.calibrate_button_Click);
            // 
            // collectData_button
            // 
            this.collectData_button.Location = new System.Drawing.Point(300, 24);
            this.collectData_button.Name = "collectData_button";
            this.collectData_button.Size = new System.Drawing.Size(100, 25);
            this.collectData_button.TabIndex = 2;
            this.collectData_button.Text = "Collect Data";
            this.collectData_button.UseVisualStyleBackColor = true;
            this.collectData_button.Click += new System.EventHandler(this.collectData_button_Click);
            // 
            // info_textBox
            // 
            this.info_textBox.Location = new System.Drawing.Point(20, 69);
            this.info_textBox.Multiline = true;
            this.info_textBox.Name = "info_textBox";
            this.info_textBox.Size = new System.Drawing.Size(379, 80);
            this.info_textBox.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(418, 161);
            this.Controls.Add(this.info_textBox);
            this.Controls.Add(this.collectData_button);
            this.Controls.Add(this.calibrate_button);
            this.Controls.Add(this.findEyeTracker_button);
            this.Name = "Form1";
            this.Text = "Gaze Tracker";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button findEyeTracker_button;
        private System.Windows.Forms.Button calibrate_button;
        private System.Windows.Forms.Button collectData_button;
        private System.Windows.Forms.TextBox info_textBox;
    }
}

