using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Poseidon.Winform.Client
{
    using Poseidon.Base;
    using Poseidon.Core.BL;
    using Poseidon.Core.DL;
    using Poseidon.Winform.Base;

    /// <summary>
    /// 组织对象添加
    /// </summary>
    public partial class FrmOrganizationObjectAdd : BaseSingleForm
    {
        #region Field
        private string id;
        #endregion //Field

        #region Constructor
        public FrmOrganizationObjectAdd(string id)
        {
            InitializeComponent();
            this.id = id;
        }
        #endregion //Constructor

        #region Function
        private void InitGrid()
        {
            var model = BusinessFactory<OrganizationModelBusiness>.Instance.FindById(this.id);

            DataTable dt = new DataTable();

            foreach (var item in model.Properties)
            {
                dt.Columns.Add(item.Name, PoseidonUtil.GetTypeFromString(item.Type.ToString()));
            }

            DataRow row = dt.NewRow();
            foreach (var item in model.Properties)
            {
                Type type = PoseidonUtil.GetTypeFromString(item.Type.ToString());
                if (type == typeof(string))
                    row[item.Name] = "";
                else
                    row[item.Name] = Activator.CreateInstance(type);
            }
            dt.Rows.Add(row);

            this.dvgObject.DataSource = dt;
        }
        #endregion //Function

        private void FrmOrganizationObjectAdd_Load(object sender, EventArgs e)
        {
            InitGrid();
            
            //PoseidonObjectList list = new PoseidonObjectList();

            //PoseidonObject obj = new PoseidonObject();
            //foreach (var item in model.Properties )
            //{
            //    list.AddColumn(item.Name, item.Remark);

            //    obj.SetPropertyValue(item.Name, DateTime.Now);
            //}

            //list.Add(obj);

            //this.dvgObject.DataSource = list;



            //dt.Columns.Add("name", typeof(string));
            //dt.Columns.Add("birth", typeof(DateTime));
            //dt.Columns.Add("age", typeof(int));

            //DataRow row = dt.NewRow();
            //row["name"] = default(string);
            //row["birth"] = default(DateTime);
            //row["age"] = default(int);

            //dt.Rows.Add(row);

            //this.dvgObject.DataSource = dt;
            //dt.Rows.Add()
        }
    }
}
