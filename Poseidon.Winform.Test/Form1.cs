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
    using Poseidon.Base;
    using Poseidon.Core.BL;
    using Poseidon.Common;
    using Poseidon.Data;

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void SetObject(object i)
        {
            string s = i.ToString();
            Console.WriteLine(s);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //BaseDALSQL sql = new BaseDALSQL();

            //string tableName = "Test";
            //Hashtable ht = new Hashtable();
            //ht.Add("Name", "robert");
            //ht.Add("Type", 2);

            //sql.Insert(tableName, ht);

            //MessageBox.Show("OK");
            SetObject(2);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var data = BusinessFactory<CustomModelBusiness>.Instance.FindByKey("abc");

            MessageBox.Show(data.Key);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dynamic dc = new DynamicClass();
            dc.SetPropertyValue("name", "Robert");
            dc.SetPropertyValue("age", 20);
            dc.SetPropertyValue("birth", DateTime.Now);
            dc.SetPropertyValue("gender", true);

            this.propertyGridControl1.SelectedObject = dc;

            //MessageBox.Show(dc.name.ToString());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            PropertyBagList list = new PropertyBagList();
            list.Columns.Add("Foo");
            list.Columns.Add("Bar");
            list.Add("abc", "def");
            list.Add("ghi", "jkl");
            list.Add("mno", "pqr");

            this.dataGridView1.DataSource = list;
        }
    }
}
