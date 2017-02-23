using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Poseidon.Winform.Base
{
    /// <summary>
    /// 字窗体管理类
    /// </summary>
    public class ChildFormManage
    {
        #region Method
        /// <summary>
        /// 唯一加载某个类型的窗体，如果存在则显示，否则创建。
        /// </summary>
        /// <param name="mainDialog">主窗体对象</param>
        /// <param name="formType">待显示的窗体类型</param>
        /// <returns></returns>
        public static Form LoadMdiForm(Form mainDialog, Type formType)
        {
            bool bFound = false;
            Form tableForm = null;
            foreach (Form form in mainDialog.MdiChildren)
            {
                if (form.GetType() == formType)
                {
                    bFound = true;
                    tableForm = form;
                    break;
                }
            }
            if (!bFound)
            {
                tableForm = (Form)Activator.CreateInstance(formType);
                tableForm.MdiParent = mainDialog;
                tableForm.Show();
            }

            tableForm.BringToFront();
            tableForm.Activate();

            return tableForm;
        }

        /// <summary>
        /// 根据指定程序集唯一加载某个类型的窗体，如果存在则显示，否则创建。
        /// </summary>
        /// <param name="mainDialog">主窗体对象</param>
        /// <param name="assemblyName">窗体程序集名称</param>
        /// <param name="typeName">窗体类型名称</param>
        /// <returns></returns>
        public static Form LoadMdiForm(Form mainDialog, string assemblyName, string typeName)
        {
            bool bFound = false;
            Form tableForm = null;
            foreach (Form form in mainDialog.MdiChildren)
            {
                if (form.GetType().FullName == typeName)
                {
                    bFound = true;
                    tableForm = form;
                    break;
                }
            }
            if (!bFound)
            {
                var ob = Activator.CreateInstance(assemblyName, typeName);
                tableForm = (Form)ob.Unwrap();
                tableForm.MdiParent = mainDialog;
                tableForm.Show();
            }

            tableForm.BringToFront();
            tableForm.Activate();

            return tableForm;
        }

        /// <summary>
        /// 弹出对话框窗体
        /// </summary>
        /// <param name="formType">待显示的窗体类型</param>
        public static void ShowDialogForm(Type formType)
        {
            Form dialogForm = (Form)Activator.CreateInstance(formType);
            dialogForm.ShowDialog();
        }

        /// <summary>
        /// 弹出对话框窗体
        /// </summary>
        /// <param name="formType">待显示的窗体类型</param>
        /// <param name="args">构造函数参数列表</param>
        public static void ShowDialogForm(Type formType, object[] args)
        {
            Form dialogForm = (Form)Activator.CreateInstance(formType, args);
            dialogForm.ShowDialog();
        }
        #endregion //Method
    }
}
