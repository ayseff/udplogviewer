namespace stej.Tools.UdpLogViewer.Forms
{
	partial class Processors
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
			this.items = new System.Windows.Forms.ListView();
			this.ItemName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.ItemDetail = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.ItemColor = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.bOk = new System.Windows.Forms.Button();
			this.tTestLogger = new System.Windows.Forms.TextBox();
			this.bTest = new System.Windows.Forms.Button();
			this.tTestMessage = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.ItemMatch = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.SuspendLayout();
			// 
			// items
			// 
			this.items.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.items.CheckBoxes = true;
			this.items.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ItemName,
            this.ItemDetail,
            this.ItemColor,
            this.ItemMatch});
			this.items.FullRowSelect = true;
			this.items.Location = new System.Drawing.Point(0, 0);
			this.items.Name = "items";
			this.items.Size = new System.Drawing.Size(392, 468);
			this.items.TabIndex = 0;
			this.items.UseCompatibleStateImageBehavior = false;
			this.items.View = System.Windows.Forms.View.Details;
			// 
			// ItemName
			// 
			this.ItemName.Text = "Name";
			this.ItemName.Width = 25;
			// 
			// ItemDetail
			// 
			this.ItemDetail.Text = "ItemDetail";
			this.ItemDetail.Width = 25;
			// 
			// ItemColor
			// 
			this.ItemColor.Text = "Color";
			this.ItemColor.Width = 20;
			// 
			// bOk
			// 
			this.bOk.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.bOk.Location = new System.Drawing.Point(0, 549);
			this.bOk.Name = "bOk";
			this.bOk.Size = new System.Drawing.Size(392, 23);
			this.bOk.TabIndex = 1;
			this.bOk.Text = "Save&&Close";
			this.bOk.UseVisualStyleBackColor = true;
			// 
			// tTestLogger
			// 
			this.tTestLogger.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.tTestLogger.Location = new System.Drawing.Point(56, 494);
			this.tTestLogger.Name = "tTestLogger";
			this.tTestLogger.Size = new System.Drawing.Size(264, 20);
			this.tTestLogger.TabIndex = 2;
			// 
			// bTest
			// 
			this.bTest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.bTest.Location = new System.Drawing.Point(322, 494);
			this.bTest.Name = "bTest";
			this.bTest.Size = new System.Drawing.Size(70, 42);
			this.bTest.TabIndex = 3;
			this.bTest.Text = "Test";
			this.bTest.UseVisualStyleBackColor = true;
			this.bTest.Click += new System.EventHandler(this.bTest_Click);
			// 
			// tTestMessage
			// 
			this.tTestMessage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.tTestMessage.Location = new System.Drawing.Point(56, 516);
			this.tTestMessage.Name = "tTestMessage";
			this.tTestMessage.Size = new System.Drawing.Size(264, 20);
			this.tTestMessage.TabIndex = 3;
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(3, 497);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(43, 13);
			this.label1.TabIndex = 5;
			this.label1.Text = "Logger:";
			// 
			// label2
			// 
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(3, 517);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(53, 13);
			this.label2.TabIndex = 6;
			this.label2.Text = "Message:";
			// 
			// label3
			// 
			this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(3, 475);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(291, 13);
			this.label3.TabIndex = 7;
			this.label3.Text = "Test what message processor matches the logger/message.";
			// 
			// ItemMatch
			// 
			this.ItemMatch.Text = "Match";
			this.ItemMatch.Width = 20;
			// 
			// Processors
			// 
			this.AcceptButton = this.bOk;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(392, 573);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.tTestMessage);
			this.Controls.Add(this.bTest);
			this.Controls.Add(this.tTestLogger);
			this.Controls.Add(this.bOk);
			this.Controls.Add(this.items);
			this.Name = "Processors";
			this.Text = "Processors";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ListView items;
		private System.Windows.Forms.Button bOk;
		private System.Windows.Forms.ColumnHeader ItemName;
		private System.Windows.Forms.ColumnHeader ItemDetail;
		private System.Windows.Forms.ColumnHeader ItemColor;
		private System.Windows.Forms.TextBox tTestLogger;
		private System.Windows.Forms.Button bTest;
		private System.Windows.Forms.TextBox tTestMessage;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ColumnHeader ItemMatch;
	}
}