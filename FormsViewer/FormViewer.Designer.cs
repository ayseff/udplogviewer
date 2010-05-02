namespace stej.Tools.UdpLogViewer.Forms
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
			this.sleepCheck = new System.Windows.Forms.CheckBox();
			this.scrollCheck = new System.Windows.Forms.CheckBox();
			this.delAllBttn = new System.Windows.Forms.Button();
			this.concreteItemTB = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.rowsCountLab = new System.Windows.Forms.Label();
			this.levelsLB = new System.Windows.Forms.ListBox();
			this.fontBttn = new System.Windows.Forms.Button();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.logGrid = new stej.Tools.UdpLogViewer.Forms.LogGrid();
			this.loggerTypeCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dateCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.timeCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.excColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.msgCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.bRules = new System.Windows.Forms.Button();
			this.bReload = new System.Windows.Forms.Button();
			this.bShowMatches = new System.Windows.Forms.Button();
			this.lbProcessors = new System.Windows.Forms.ListBox();
			this.label2 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.logGrid)).BeginInit();
			this.SuspendLayout();
			// 
			// sleepCheck
			// 
			this.sleepCheck.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.sleepCheck.AutoSize = true;
			this.sleepCheck.Location = new System.Drawing.Point(746, 22);
			this.sleepCheck.Name = "sleepCheck";
			this.sleepCheck.Size = new System.Drawing.Size(53, 17);
			this.sleepCheck.TabIndex = 1;
			this.sleepCheck.Text = "Sleep";
			this.sleepCheck.UseVisualStyleBackColor = true;
			// 
			// scrollCheck
			// 
			this.scrollCheck.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.scrollCheck.AutoSize = true;
			this.scrollCheck.Checked = true;
			this.scrollCheck.CheckState = System.Windows.Forms.CheckState.Checked;
			this.scrollCheck.Location = new System.Drawing.Point(745, 7);
			this.scrollCheck.Name = "scrollCheck";
			this.scrollCheck.Size = new System.Drawing.Size(83, 17);
			this.scrollCheck.TabIndex = 2;
			this.scrollCheck.Text = "Scroll to last";
			this.scrollCheck.UseVisualStyleBackColor = true;
			// 
			// delAllBttn
			// 
			this.delAllBttn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.delAllBttn.Location = new System.Drawing.Point(744, 492);
			this.delAllBttn.Name = "delAllBttn";
			this.delAllBttn.Size = new System.Drawing.Size(93, 23);
			this.delAllBttn.TabIndex = 3;
			this.delAllBttn.Text = "Clear";
			this.delAllBttn.UseVisualStyleBackColor = true;
			this.delAllBttn.Click += new System.EventHandler(this.ClearClick);
			// 
			// concreteItemTB
			// 
			this.concreteItemTB.Dock = System.Windows.Forms.DockStyle.Fill;
			this.concreteItemTB.Location = new System.Drawing.Point(0, 0);
			this.concreteItemTB.Multiline = true;
			this.concreteItemTB.Name = "concreteItemTB";
			this.concreteItemTB.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.concreteItemTB.Size = new System.Drawing.Size(739, 87);
			this.concreteItemTB.TabIndex = 6;
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(744, 333);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(37, 13);
			this.label1.TabIndex = 7;
			this.label1.Text = "Rows:";
			// 
			// rowsCountLab
			// 
			this.rowsCountLab.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.rowsCountLab.AutoSize = true;
			this.rowsCountLab.Location = new System.Drawing.Point(784, 334);
			this.rowsCountLab.Name = "rowsCountLab";
			this.rowsCountLab.Size = new System.Drawing.Size(13, 13);
			this.rowsCountLab.TabIndex = 8;
			this.rowsCountLab.Text = "0";
			// 
			// levelsLB
			// 
			this.levelsLB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.levelsLB.FormattingEnabled = true;
			this.levelsLB.Items.AddRange(new object[] {
            "DEBUG",
            "INFO",
            "WARN",
            "ERROR",
            "FATAL"});
			this.levelsLB.Location = new System.Drawing.Point(746, 40);
			this.levelsLB.Name = "levelsLB";
			this.levelsLB.Size = new System.Drawing.Size(92, 69);
			this.levelsLB.TabIndex = 10;
			this.levelsLB.SelectedValueChanged += new System.EventHandler(this.SelectedLevelChanged);
			// 
			// fontBttn
			// 
			this.fontBttn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.fontBttn.Location = new System.Drawing.Point(746, 111);
			this.fontBttn.Name = "fontBttn";
			this.fontBttn.Size = new System.Drawing.Size(93, 23);
			this.fontBttn.TabIndex = 14;
			this.fontBttn.Text = "Font";
			this.fontBttn.UseVisualStyleBackColor = true;
			this.fontBttn.Click += new System.EventHandler(this.FontClick);
			// 
			// splitContainer1
			// 
			this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.splitContainer1.Location = new System.Drawing.Point(2, 1);
			this.splitContainer1.Name = "splitContainer1";
			this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.logGrid);
			this.splitContainer1.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.concreteItemTB);
			this.splitContainer1.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.splitContainer1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.splitContainer1.Size = new System.Drawing.Size(739, 514);
			this.splitContainer1.SplitterDistance = 423;
			this.splitContainer1.TabIndex = 17;
			// 
			// logGrid
			// 
			this.logGrid.AllowUserToAddRows = false;
			this.logGrid.AllowUserToResizeRows = false;
			this.logGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.logGrid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
			this.logGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.logGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.loggerTypeCol,
            this.dateCol,
            this.timeCol,
            this.excColumn,
            this.msgCol});
			this.logGrid.Dock = System.Windows.Forms.DockStyle.Fill;
			this.logGrid.Location = new System.Drawing.Point(0, 0);
			this.logGrid.MaxRows = 0;
			this.logGrid.Name = "logGrid";
			this.logGrid.ReadOnly = true;
			this.logGrid.RowTemplate.Height = 18;
			this.logGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.logGrid.Size = new System.Drawing.Size(739, 423);
			this.logGrid.TabIndex = 0;
			this.logGrid.SelectionChanged += new System.EventHandler(this.RowSelectedHandler);
			// 
			// loggerTypeCol
			// 
			this.loggerTypeCol.HeaderText = "Logger";
			this.loggerTypeCol.Name = "loggerTypeCol";
			this.loggerTypeCol.ReadOnly = true;
			// 
			// dateCol
			// 
			this.dateCol.HeaderText = "Date";
			this.dateCol.Name = "dateCol";
			this.dateCol.ReadOnly = true;
			// 
			// timeCol
			// 
			this.timeCol.HeaderText = "Time";
			this.timeCol.Name = "timeCol";
			this.timeCol.ReadOnly = true;
			// 
			// excColumn
			// 
			this.excColumn.HeaderText = "Exc";
			this.excColumn.Name = "excColumn";
			this.excColumn.ReadOnly = true;
			this.excColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.excColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			// 
			// msgCol
			// 
			this.msgCol.HeaderText = "Message";
			this.msgCol.Name = "msgCol";
			this.msgCol.ReadOnly = true;
			// 
			// bRules
			// 
			this.bRules.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.bRules.Location = new System.Drawing.Point(746, 140);
			this.bRules.Name = "bRules";
			this.bRules.Size = new System.Drawing.Size(93, 23);
			this.bRules.TabIndex = 18;
			this.bRules.Text = "Rules";
			this.bRules.UseVisualStyleBackColor = true;
			this.bRules.Click += new System.EventHandler(this.bRules_Click);
			// 
			// bReload
			// 
			this.bReload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.bReload.Location = new System.Drawing.Point(746, 165);
			this.bReload.Name = "bReload";
			this.bReload.Size = new System.Drawing.Size(93, 23);
			this.bReload.TabIndex = 19;
			this.bReload.Text = "Reload";
			this.bReload.UseVisualStyleBackColor = true;
			this.bReload.Click += new System.EventHandler(this.bReload_Click);
			// 
			// bShowMatches
			// 
			this.bShowMatches.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.bShowMatches.Location = new System.Drawing.Point(744, 465);
			this.bShowMatches.Name = "bShowMatches";
			this.bShowMatches.Size = new System.Drawing.Size(93, 23);
			this.bShowMatches.TabIndex = 22;
			this.bShowMatches.Text = "Matching rules";
			this.bShowMatches.UseVisualStyleBackColor = true;
			this.bShowMatches.Click += new System.EventHandler(this.bShowMatches_Click);
			// 
			// lbProcessors
			// 
			this.lbProcessors.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lbProcessors.FormattingEnabled = true;
			this.lbProcessors.Location = new System.Drawing.Point(746, 207);
			this.lbProcessors.Name = "lbProcessors";
			this.lbProcessors.Size = new System.Drawing.Size(91, 121);
			this.lbProcessors.TabIndex = 23;
			// 
			// label2
			// 
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(744, 191);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(65, 13);
			this.label2.TabIndex = 24;
			this.label2.Text = "Select rules:";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(840, 519);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.lbProcessors);
			this.Controls.Add(this.bShowMatches);
			this.Controls.Add(this.bReload);
			this.Controls.Add(this.bRules);
			this.Controls.Add(this.delAllBttn);
			this.Controls.Add(this.fontBttn);
			this.Controls.Add(this.splitContainer1);
			this.Controls.Add(this.levelsLB);
			this.Controls.Add(this.scrollCheck);
			this.Controls.Add(this.sleepCheck);
			this.Controls.Add(this.rowsCountLab);
			this.Controls.Add(this.label1);
			this.MinimumSize = new System.Drawing.Size(470, 315);
			this.Name = "Form1";
			this.Text = "Udp log viewer";
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			this.splitContainer1.Panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.logGrid)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private LogGrid logGrid;
		private System.Windows.Forms.CheckBox sleepCheck;
		private System.Windows.Forms.CheckBox scrollCheck;
		private System.Windows.Forms.Button delAllBttn;
		private System.Windows.Forms.TextBox concreteItemTB;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label rowsCountLab;
		private System.Windows.Forms.ListBox levelsLB;
		private System.Windows.Forms.Button fontBttn;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.Button bRules;
		private System.Windows.Forms.Button bReload;
		private System.Windows.Forms.Button bShowMatches;
		private System.Windows.Forms.DataGridViewTextBoxColumn loggerTypeCol;
		private System.Windows.Forms.DataGridViewTextBoxColumn dateCol;
		private System.Windows.Forms.DataGridViewTextBoxColumn timeCol;
		private System.Windows.Forms.DataGridViewTextBoxColumn excColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn msgCol;
		private System.Windows.Forms.ListBox lbProcessors;
		private System.Windows.Forms.Label label2;

	}
}

