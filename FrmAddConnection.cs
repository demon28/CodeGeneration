using CodeGeneration.Entities;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using Microsoft.Data.ConnectionUI;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
namespace CodeGeneration
{
    public partial class FrmAddConnection : FormBase
    {
        private string _connectionString;
        private string _selecteddb;
        private ButtonX butAdd;
        private ButtonX butFail;
        private LabelX lblName;

        public FrmAddConnection()
        {
            this.InitializeComponent();
        }

        private void butAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txbName.Text.Trim()))
            {
                base.Alert("请先输入数据库连接的别名", "系统提示", MessageBoxButtons.OK);
            }
            else
            {
                //Microsoft.Data.ConnectionUI.DataConnectionDialog dlg = new Microsoft.Data.ConnectionUI.DataConnectionDialog();
                //DataSource.AddStandardDataSources(dlg);
                //if (DataConnectionDialog.Show(dlg) == System.Windows.Forms.DialogResult.OK)
                //{
                //    this._connectionString = dlg.ConnectionString;
                //    this._selecteddb = dlg.SelectedDataSource.DefaultProvider.Name;
                //    base.Close();
                //}
                //return;
                DataConnectionDialog dialog = new DataConnectionDialog();
                dialog.DataSources.Add(DataSource.SqlDataSource);
                dialog.DataSources.Add(DataSource.OracleDataSource);
                dialog.DataSources.Add(DataSource.AccessDataSource);
                dialog.DataSources.Add(DataSource.OdbcDataSource);
                dialog.DataSources.Add(DataSource.SqlFileDataSource);
                dialog.SelectedDataSource = DataSource.OracleDataSource;
                dialog.SelectedDataProvider = DataProvider.OracleDataProvider;
                if (DataConnectionDialog.Show(dialog, this) == DialogResult.OK)
                {
                    this._connectionString = dialog.ConnectionString;
                    this._selecteddb = dialog.SelectedDataSource.Name;
                    base.Close();
                }
            }
        }

        private void butFail_Click(object sender, EventArgs e)
        {
            base.Close();
        }



        public string ConnectionName
        {
            get
            {
                return this.txbName.Text;
            }
        }

        public string ConnectionString
        {
            get
            {
                return this._connectionString;
            }
        }

        public DataBaseType SelectedDataBase
        {
            get
            {
                return (DataBaseType)Enum.Parse(typeof(DataBaseType), this._selecteddb);
            }
        }
    }
}

