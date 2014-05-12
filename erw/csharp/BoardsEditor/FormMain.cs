using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BoardsEditor
{
    public partial class FormMain : Form
    {
        private BoardsContainer _boards;
        public FormMain()
        {
            InitializeComponent();

            backgroundWorkerLoad.RunWorkerAsync(Environment.GetCommandLineArgs()[1]);
        }

        private void backgroundWorkerLoad_DoWork(object sender, DoWorkEventArgs e)
        {
            _boards = new BoardsContainer((string)e.Argument);
        }

        private void backgroundWorkerLoad_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            RebuildGui();
        }

        private void RebuildGui()
        {
            comboBoxBoards.Items.Clear();

            foreach (var b in _boards.Boards)
                comboBoxBoards.Items.Add(b.Name);
        }

        private void comboBoxBoards_SelectedIndexChanged(object sender, EventArgs e)
        {
            flowLayoutPanelProperties.Controls.Clear();
            var boardName = _boards.Boards[comboBoxBoards.SelectedIndex].Token;
            var tooltip = new ToolTip();

            foreach(var p in _boards.Boards[comboBoxBoards.SelectedIndex].Properties)
            {
                var label = new Control();

                var text = new TextBox { Text = p.Value, Width = 200, Tag = boardName + "." + p.Name };
                if(p.Name.ToLower().Equals("name"))
                    label = new Label {Text = p.Name, Width = 200};
                else
                {
                    label = new LinkLabel { Text = p.Name, Width = 200 };
                    label.Click += (o, args) => { new ContextMenu(GetMenuItems(_boards.GetPropertiesValues(p.Name), text)).Show((Control) o, ((Control) o).PointToClient(Cursor.Position)); };
                }
                
                tooltip.SetToolTip(label, (String)text.Tag);

                flowLayoutPanelProperties.Controls.Add(label);
                flowLayoutPanelProperties.Controls.Add(text);
            }
        }

        private static MenuItem[] GetMenuItems(IEnumerable<string> strings, TextBox text)
        {
            var m = new List<MenuItem>();

            foreach (var s in strings)
            {
                var item = new MenuItem(s);
                item.Click += (o, args) => { text.Text = ((MenuItem) o).Text; };
                m.Add(item);
            }

            return m.ToArray();
        }
    }
}
