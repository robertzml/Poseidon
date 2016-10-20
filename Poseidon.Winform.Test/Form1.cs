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
    using Poseidon.Base.Framework;
    using Poseidon.Core.BL;
    using Poseidon.Common;
    using Poseidon.Data;

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void TestSome()
        {
            Dictionary<string, string> dd = new Dictionary<string, string>();
            dd.Add("dsf", "dd");
            

            List<string> ds = new List<string>();
            //ds.FindIndex("sd");
        }

        private void SetObject(object i)
        {
            string s = i.ToString();
            Console.WriteLine(s);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PoseidonObject obj = new PoseidonObject();
            obj.SetPropertyValue("name", "jim");
            obj.SetPropertyValue("age", 20);
            

            PoseidonObjectList list = new PoseidonObjectList();
            list.SetColumnPairs("name,age", "姓名,年龄");
            list.AddType(typeof(string));
            list.AddType(typeof(int));

            list.Add(obj);

            this.vGridControl1.DataSource = list;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //var data = BusinessFactory<CustomModelBusiness>.Instance.FindByKey("abc");

            //MessageBox.Show(data.Key);

            var properties = TypeDescriptor.GetProperties(button1);

            PropertyDescriptor pd = properties.Find("Text", false);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            dynamic dc = new DynamicClass();
            dc.SetPropertyValue("name", "Robert");
            dc.SetPropertyValue("age", 20);
            dc.SetPropertyValue("birth", DateTime.Now);
            dc.SetPropertyValue("gender", true);
                   

            //MessageBox.Show(dc.name.ToString());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            List<Person> data = new List<Person>();

            var person = new Person { Name = "Jim", Age = 14, Birth = new DateTime(2014, 4, 5) };
            data.Add(person);

            this.vGridControl1.DataSource = data;

            this.propertyGridControl1.SelectedObject = person;
        }
    }
}
