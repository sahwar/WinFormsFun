namespace ProsekOcena
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.coursesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statisticToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbTotalECTS = new System.Windows.Forms.TextBox();
            this.tbAverageGrade = new System.Windows.Forms.TextBox();
            this.dgvCourses = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addCourseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteCourseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.percent6 = new System.Windows.Forms.Label();
            this.percent7 = new System.Windows.Forms.Label();
            this.percent8 = new System.Windows.Forms.Label();
            this.percent9 = new System.Windows.Forms.Label();
            this.percent10 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.progress6 = new System.Windows.Forms.ProgressBar();
            this.progress7 = new System.Windows.Forms.ProgressBar();
            this.progress8 = new System.Windows.Forms.ProgressBar();
            this.progress9 = new System.Windows.Forms.ProgressBar();
            this.progress10 = new System.Windows.Forms.ProgressBar();
            this.panelStatistics = new System.Windows.Forms.Panel();
            this.colOrdNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCourse = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colECTS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGrade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPassed = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.menuStrip1.SuspendLayout();
            this.menuStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCourses)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panelStatistics.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.White;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.coursesToolStripMenuItem,
            this.statisticToolStripMenuItem});
            this.menuStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.menuStrip1.Location = new System.Drawing.Point(0, 24);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(489, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // coursesToolStripMenuItem
            // 
            this.coursesToolStripMenuItem.Image = global::ProsekOcena.Properties.Resources.Course_32px;
            this.coursesToolStripMenuItem.Name = "coursesToolStripMenuItem";
            this.coursesToolStripMenuItem.Size = new System.Drawing.Size(77, 20);
            this.coursesToolStripMenuItem.Text = "Courses";
            this.coursesToolStripMenuItem.Click += new System.EventHandler(this.coursesToolStripMenuItem_Click);
            // 
            // statisticToolStripMenuItem
            // 
            this.statisticToolStripMenuItem.Image = global::ProsekOcena.Properties.Resources.Statistics_32px;
            this.statisticToolStripMenuItem.Name = "statisticToolStripMenuItem";
            this.statisticToolStripMenuItem.Size = new System.Drawing.Size(76, 20);
            this.statisticToolStripMenuItem.Text = "Statistic";
            this.statisticToolStripMenuItem.Click += new System.EventHandler(this.statisticToolStripMenuItem_Click);
            // 
            // menuStrip2
            // 
            this.menuStrip2.BackColor = System.Drawing.Color.White;
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(489, 24);
            this.menuStrip2.TabIndex = 1;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.addToolStripMenuItem,
            this.closeToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.CreateNewDataGridView);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.OpenXMLFile);
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.addToolStripMenuItem.Text = "Add";
            this.addToolStripMenuItem.Click += new System.EventHandler(this.AddCourse);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("closeToolStripMenuItem.Image")));
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.ClearDataGridViewer);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Image = global::ProsekOcena.Properties.Resources.Save_32px;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeyDisplayString = "";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.SaveXML);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Image = global::ProsekOcena.Properties.Resources.Save_as_32px;
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.saveAsToolStripMenuItem.Text = "Save As";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.SaveAsXML);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("exitToolStripMenuItem.Image")));
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.Exit);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(64, 350);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Total ECTS:";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(276, 350);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Average grade:";
            // 
            // tbTotalECTS
            // 
            this.tbTotalECTS.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbTotalECTS.BackColor = System.Drawing.Color.White;
            this.tbTotalECTS.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbTotalECTS.Location = new System.Drawing.Point(135, 350);
            this.tbTotalECTS.Name = "tbTotalECTS";
            this.tbTotalECTS.ReadOnly = true;
            this.tbTotalECTS.Size = new System.Drawing.Size(41, 13);
            this.tbTotalECTS.TabIndex = 5;
            this.tbTotalECTS.Text = "0";
            // 
            // tbAverageGrade
            // 
            this.tbAverageGrade.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.tbAverageGrade.BackColor = System.Drawing.Color.White;
            this.tbAverageGrade.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbAverageGrade.Location = new System.Drawing.Point(362, 350);
            this.tbAverageGrade.Name = "tbAverageGrade";
            this.tbAverageGrade.ReadOnly = true;
            this.tbAverageGrade.Size = new System.Drawing.Size(30, 13);
            this.tbAverageGrade.TabIndex = 6;
            this.tbAverageGrade.Text = "0";
            // 
            // dgvCourses
            // 
            this.dgvCourses.AllowUserToAddRows = false;
            this.dgvCourses.AllowUserToResizeColumns = false;
            this.dgvCourses.AllowUserToResizeRows = false;
            this.dgvCourses.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCourses.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvCourses.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvCourses.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvCourses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCourses.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colOrdNum,
            this.colCourse,
            this.colECTS,
            this.colGrade,
            this.colPassed});
            this.dgvCourses.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvCourses.Location = new System.Drawing.Point(0, 51);
            this.dgvCourses.Name = "dgvCourses";
            this.dgvCourses.Size = new System.Drawing.Size(489, 293);
            this.dgvCourses.TabIndex = 7;
            this.dgvCourses.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridViewCellValueChanged);
            this.dgvCourses.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvCourses_DataError);
            this.dgvCourses.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.DataGridViewRowsAdded);
            this.dgvCourses.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.DataGridViewRowsRemoved);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addCourseToolStripMenuItem,
            this.deleteCourseToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(194, 48);
            // 
            // addCourseToolStripMenuItem
            // 
            this.addCourseToolStripMenuItem.Name = "addCourseToolStripMenuItem";
            this.addCourseToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.addCourseToolStripMenuItem.Text = "Add Course(s)...";
            this.addCourseToolStripMenuItem.Click += new System.EventHandler(this.AddCourse);
            // 
            // deleteCourseToolStripMenuItem
            // 
            this.deleteCourseToolStripMenuItem.Name = "deleteCourseToolStripMenuItem";
            this.deleteCourseToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.deleteCourseToolStripMenuItem.Text = "Delete Selected Row(s)";
            this.deleteCourseToolStripMenuItem.Click += new System.EventHandler(this.deleteCourseToolStripMenuItem_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox1.Controls.Add(this.percent6);
            this.groupBox1.Controls.Add(this.percent7);
            this.groupBox1.Controls.Add(this.percent8);
            this.groupBox1.Controls.Add(this.percent9);
            this.groupBox1.Controls.Add(this.percent10);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.progress6);
            this.groupBox1.Controls.Add(this.progress7);
            this.groupBox1.Controls.Add(this.progress8);
            this.groupBox1.Controls.Add(this.progress9);
            this.groupBox1.Controls.Add(this.progress10);
            this.groupBox1.Location = new System.Drawing.Point(12, 15);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(465, 178);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Grade Stats";
            // 
            // percent6
            // 
            this.percent6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.percent6.AutoSize = true;
            this.percent6.Location = new System.Drawing.Point(362, 134);
            this.percent6.Name = "percent6";
            this.percent6.Size = new System.Drawing.Size(21, 13);
            this.percent6.TabIndex = 14;
            this.percent6.Text = "0%";
            // 
            // percent7
            // 
            this.percent7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.percent7.AutoSize = true;
            this.percent7.Location = new System.Drawing.Point(362, 108);
            this.percent7.Name = "percent7";
            this.percent7.Size = new System.Drawing.Size(21, 13);
            this.percent7.TabIndex = 13;
            this.percent7.Text = "0%";
            // 
            // percent8
            // 
            this.percent8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.percent8.AutoSize = true;
            this.percent8.Location = new System.Drawing.Point(362, 82);
            this.percent8.Name = "percent8";
            this.percent8.Size = new System.Drawing.Size(21, 13);
            this.percent8.TabIndex = 12;
            this.percent8.Text = "0%";
            // 
            // percent9
            // 
            this.percent9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.percent9.AutoSize = true;
            this.percent9.Location = new System.Drawing.Point(362, 56);
            this.percent9.Name = "percent9";
            this.percent9.Size = new System.Drawing.Size(21, 13);
            this.percent9.TabIndex = 11;
            this.percent9.Text = "0%";
            // 
            // percent10
            // 
            this.percent10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.percent10.AutoSize = true;
            this.percent10.Location = new System.Drawing.Point(362, 30);
            this.percent10.Name = "percent10";
            this.percent10.Size = new System.Drawing.Size(21, 13);
            this.percent10.TabIndex = 10;
            this.percent10.Text = "0%";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(32, 134);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(13, 13);
            this.label7.TabIndex = 9;
            this.label7.Text = "6";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(32, 108);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(13, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "7";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(32, 82);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(13, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "8";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(32, 56);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(13, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "9";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(19, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "10";
            // 
            // progress6
            // 
            this.progress6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progress6.Location = new System.Drawing.Point(56, 134);
            this.progress6.MarqueeAnimationSpeed = 0;
            this.progress6.Name = "progress6";
            this.progress6.Size = new System.Drawing.Size(300, 13);
            this.progress6.TabIndex = 4;
            // 
            // progress7
            // 
            this.progress7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progress7.Location = new System.Drawing.Point(56, 108);
            this.progress7.Name = "progress7";
            this.progress7.Size = new System.Drawing.Size(300, 13);
            this.progress7.TabIndex = 3;
            // 
            // progress8
            // 
            this.progress8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progress8.Location = new System.Drawing.Point(56, 82);
            this.progress8.Name = "progress8";
            this.progress8.Size = new System.Drawing.Size(300, 13);
            this.progress8.TabIndex = 2;
            // 
            // progress9
            // 
            this.progress9.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progress9.Location = new System.Drawing.Point(56, 56);
            this.progress9.Name = "progress9";
            this.progress9.Size = new System.Drawing.Size(300, 13);
            this.progress9.TabIndex = 1;
            // 
            // progress10
            // 
            this.progress10.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progress10.Location = new System.Drawing.Point(55, 30);
            this.progress10.Name = "progress10";
            this.progress10.Size = new System.Drawing.Size(301, 13);
            this.progress10.TabIndex = 0;
            // 
            // panelStatistics
            // 
            this.panelStatistics.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelStatistics.Controls.Add(this.groupBox1);
            this.panelStatistics.Location = new System.Drawing.Point(0, 51);
            this.panelStatistics.Name = "panelStatistics";
            this.panelStatistics.Size = new System.Drawing.Size(490, 293);
            this.panelStatistics.TabIndex = 8;
            this.panelStatistics.Visible = false;
            // 
            // colOrdNum
            // 
            this.colOrdNum.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colOrdNum.HeaderText = "Ord. num.";
            this.colOrdNum.MaxInputLength = 3;
            this.colOrdNum.Name = "colOrdNum";
            this.colOrdNum.ReadOnly = true;
            this.colOrdNum.Width = 78;
            // 
            // colCourse
            // 
            this.colCourse.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colCourse.HeaderText = "Course name";
            this.colCourse.MaxInputLength = 50;
            this.colCourse.MinimumWidth = 200;
            this.colCourse.Name = "colCourse";
            this.colCourse.Width = 200;
            // 
            // colECTS
            // 
            this.colECTS.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colECTS.HeaderText = "ECTS";
            this.colECTS.MaxInputLength = 2;
            this.colECTS.Name = "colECTS";
            this.colECTS.Width = 60;
            // 
            // colGrade
            // 
            this.colGrade.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colGrade.HeaderText = "Grade";
            this.colGrade.MaxInputLength = 2;
            this.colGrade.Name = "colGrade";
            this.colGrade.Width = 61;
            // 
            // colPassed
            // 
            this.colPassed.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colPassed.HeaderText = "Passed";
            this.colPassed.Name = "colPassed";
            this.colPassed.Width = 48;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(489, 374);
            this.Controls.Add(this.tbAverageGrade);
            this.Controls.Add(this.tbTotalECTS);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.menuStrip2);
            this.Controls.Add(this.dgvCourses);
            this.Controls.Add(this.panelStatistics);
            this.ForeColor = System.Drawing.Color.Black;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(430, 170);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Untitled";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCourses)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panelStatistics.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem coursesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem statisticToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbTotalECTS;
        private System.Windows.Forms.TextBox tbAverageGrade;
        private System.Windows.Forms.DataGridView dgvCourses;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label percent6;
        private System.Windows.Forms.Label percent7;
        private System.Windows.Forms.Label percent8;
        private System.Windows.Forms.Label percent9;
        private System.Windows.Forms.Label percent10;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ProgressBar progress6;
        private System.Windows.Forms.ProgressBar progress7;
        private System.Windows.Forms.ProgressBar progress8;
        private System.Windows.Forms.ProgressBar progress9;
        private System.Windows.Forms.ProgressBar progress10;
        private System.Windows.Forms.Panel panelStatistics;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem addCourseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteCourseToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOrdNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCourse;
        private System.Windows.Forms.DataGridViewTextBoxColumn colECTS;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGrade;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colPassed;
    }
}

