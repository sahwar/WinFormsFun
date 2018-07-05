namespace ExerciseOne_Basic_ui
{
    partial class MainForm
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
            this.programsToRunCheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnChoice = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // programsToRunCheckedListBox
            // 
            this.programsToRunCheckedListBox.FormattingEnabled = true;
            this.programsToRunCheckedListBox.Items.AddRange(new object[] {
            "EtchASketch",
            "RGB_Basic"});
            this.programsToRunCheckedListBox.Location = new System.Drawing.Point(50, 49);
            this.programsToRunCheckedListBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.programsToRunCheckedListBox.Name = "programsToRunCheckedListBox";
            this.programsToRunCheckedListBox.Size = new System.Drawing.Size(235, 52);
            this.programsToRunCheckedListBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(47, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(185, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Select program/s you wish to run:";
            // 
            // btnChoice
            // 
            this.btnChoice.Location = new System.Drawing.Point(271, 197);
            this.btnChoice.Name = "btnChoice";
            this.btnChoice.Size = new System.Drawing.Size(75, 23);
            this.btnChoice.TabIndex = 2;
            this.btnChoice.Text = "Start";
            this.btnChoice.UseVisualStyleBackColor = true;
            this.btnChoice.Click += new System.EventHandler(this.btnChoice_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(370, 242);
            this.Controls.Add(this.btnChoice);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.programsToRunCheckedListBox);
            this.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MainForm";
            this.Text = "WinForms Exercise";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox programsToRunCheckedListBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnChoice;
    }
}