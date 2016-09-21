using System;
using System.Collections;
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
    using Poseidon.Common;
    using Poseidon.Data;

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BaseDALSQL sql = new BaseDALSQL();

            string tableName = "Test";
            Hashtable ht = new Hashtable();
            ht.Add("Name", "robert");
            ht.Add("Type", 2);

            sql.Insert(tableName, ht);

            MessageBox.Show("OK");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AppConfig config = new AppConfig();
            MessageBox.Show(config.DbType);
        }
    }
}
