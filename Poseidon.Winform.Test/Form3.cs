using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Poseidon.Winform.Test
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PropertyBagList list = new PropertyBagList();
            list.Columns.Add("Foo");
            list.Columns.Add("Bar");
            list.Add("abc", "def");
            list.Add("ghi", "jkl");
            list.Add("mno", "pqr");

            this.winGrid1.DataSource = list;
            this.winVerticalGrid1.DataSource = list;
        }
    }
}
