namespace ExerciseOne_Basic_ui
{
    partial class RGB_basic_ui
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbBlue = new System.Windows.Forms.CheckBox();
            this.cbGreen = new System.Windows.Forms.CheckBox();
            this.cbRed = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbBlue);
            this.groupBox1.Controls.Add(this.cbGreen);
            this.groupBox1.Controls.Add(this.cbRed);
            this.groupBox1.Location = new System.Drawing.Point(62, 73);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(160, 165);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Colors";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // cbBlue
            // 
            this.cbBlue.AutoSize = true;
            this.cbBlue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.cbBlue.Location = new System.Drawing.Point(13, 95);
            this.cbBlue.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbBlue.Name = "cbBlue";
            this.cbBlue.Size = new System.Drawing.Size(49, 20);
            this.cbBlue.TabIndex = 2;
            this.cbBlue.Text = "Blue";
            this.cbBlue.UseVisualStyleBackColor = true;
            this.cbBlue.CheckedChanged += new System.EventHandler(this.UpdatePanel1Color);
            // 
            // cbGreen
            // 
            this.cbGreen.AutoSize = true;
            this.cbGreen.ForeColor = System.Drawing.Color.DarkGreen;
            this.cbGreen.Location = new System.Drawing.Point(13, 66);
            this.cbGreen.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbGreen.Name = "cbGreen";
            this.cbGreen.Size = new System.Drawing.Size(61, 20);
            this.cbGreen.TabIndex = 1;
            this.cbGreen.Text = "Green";
            this.cbGreen.UseVisualStyleBackColor = true;
            this.cbGreen.CheckedChanged += new System.EventHandler(this.UpdatePanel1Color);
            // 
            // cbRed
            // 
            this.cbRed.AutoSize = true;
            this.cbRed.Location = new System.Drawing.Point(13, 38);
            this.cbRed.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbRed.Name = "cbRed";
            this.cbRed.Size = new System.Drawing.Size(49, 20);
            this.cbRed.TabIndex = 0;
            this.cbRed.Text = "Red";
            this.cbRed.UseVisualStyleBackColor = true;
            this.cbRed.CheckedChanged += new System.EventHandler(this.UpdatePanel1Color);
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(246, 81);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(146, 155);
            this.panel1.TabIndex = 8;
            // 
            // RGB_basic_ui
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(476, 326);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "RGB_basic_ui";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RGB Color lesson";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox cbBlue;
        private System.Windows.Forms.CheckBox cbGreen;
        private System.Windows.Forms.CheckBox cbRed;
    }
}

