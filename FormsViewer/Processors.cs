using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using stej.Tools.UdpLogViewer.Core;
using stej.Tools.UdpLogViewer.CommonRules;

namespace stej.Tools.UdpLogViewer.Forms
{
	public partial class Processors : Form
	{
		HashSet<int> _changedIndices = new HashSet<int>();

		public Processors(IEnumerable<IProcessor> source, UIConfig.ProcessorsForm processorsForm)
		{
			InitializeComponent();
			// fix the designer default value propagated every time :|
			this.ItemName.Width = -1;
			this.ItemDetail.Width = -1;
			this.ItemColor.Width = 35;

			this.FormClosing += (s, a) => { processorsForm.Update(this); };

			Items = source.ToArray();
			AddItems();

			items.ItemChecked += ItemChecked;
			bOk.Click += UpdateItemsState;

			processorsForm.Use(this);
		}

		private void AddItems()
		{
			foreach (IProcessor item in Items)
			{
				ListViewItem s = items.Items.Add(item.Name);
				s.UseItemStyleForSubItems = false;
				s.SubItems.Add(item.DetailsInfo);
				s.SubItems.Add(""); // color info
				s.SubItems.Add(""); // result of the test
				s.Checked = item.Enabled;
				IColoredProcessor p = item as IColoredProcessor;
				if (p != null)
				{
					s.SubItems[2].Text = "Test";
					s.SubItems[2].ForeColor = p.Color ?? Color.Black; ;
					s.SubItems[2].BackColor = p.BackColor ?? Color.White;
				}
			}
		}

		void UpdateItemsState(object sender, EventArgs e)
		{
			foreach (var index in _changedIndices)
			{
				_items[index].Enabled = items.Items[index].Checked;
			}
			DialogResult = System.Windows.Forms.DialogResult.OK;
		}

		void ItemChecked(object sender, ItemCheckedEventArgs e)
		{
			int index = e.Item.Index;
			_changedIndices.Add(index);
		}

		public IEnumerable<IProcessor> Items
		{
			get { return _items; }
			set { _items = value.ToArray(); }
		}
		IProcessor[] _items;

		public void TestLogItem(LogItem item)
		{
			tTestLogger.Text = item.Logger;
			tTestMessage.Text = item.Message;
			HighlightMatchingRules(item);
		}

		void HighlightMatchingRules(LogItem item) 
		{
			for (int i = 0; i < _items.Length; i++)
			{
				ProcessingResult r = _items[i].Process(item, null);
				items.Items[i].SubItems[3].BackColor = r.RuleIsMatching ? Color.Green : Color.Tomato;
			}
		}

		void bTest_Click(object sender, EventArgs e)
		{
			HighlightMatchingRules(new LogItem() { Logger = tTestLogger.Text, Message = tTestMessage.Text});
		}
	}
}
