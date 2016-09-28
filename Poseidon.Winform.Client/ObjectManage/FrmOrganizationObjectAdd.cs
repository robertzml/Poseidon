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
    using Poseidon.Common;
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

        private OrganizationModel model;
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
            model = BusinessFactory<OrganizationModelBusiness>.Instance.FindById(this.id);

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

        #region Event
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

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            this.dvgObject.CloseEditor();
            var data = this.dvgObject.DataSource as DataTable;
            DataRow row = data.Rows[0];

            Organization obj = new Organization();
            foreach (var item in model.Properties)
            {
                obj.SetPropertyValue(item.Name, row[item.Name]);
            }

            var result = BusinessFactory<OrganizationBusiness>.Instance.Create(obj);
            if (result == ErrorCode.Success)
            {
                MessageUtil.ShowInfo("添加对象成功");
                this.Close();
            }
            else
            {
                MessageUtil.ShowError("添加对象失败，" + result.DisplayName());
            }

        }
        #endregion //Event
    }
}
