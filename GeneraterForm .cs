using CodeGeneration.Entities;
using CodeGeneration.Facade;
using CodeGeneration.Interface;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using SchemaExplorer;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace CodeGeneration
{

    public partial class GeneraterForm : FormBase
    {
        private List<string> DataAccessList;
        private List<string> FacadeList;
        public GeneraterForm()
        {
            this.InitializeComponent();
            this.BindDefaultValue();
            this.BindTemplateList();
        }

        private void BindConnection()
        {
            this.ListConnection = new XmlHelper(Application.StartupPath).ListConnection();
            this.cboxConnectionNameColl.DataSource = this.ListConnection;
            this.cboxConnectionNameColl.DisplayMember = "ConnectionName";
            this.cboxConnectionNameColl.ValueMember = "ConnectionString";
            this.cboxConnectionNameColl.DropDownStyle = ComboBoxStyle.DropDownList;
            if (ListConnection.Count > 0)
            {
                txbConnString.Text = ListConnection[0].ConnectionString;
            }
        }

        private void BindDefaultValue()
        {
            XmlHelper helper = new XmlHelper(Application.StartupPath);
            this.txbURL.Text = helper.GetValueByName("Save_Path");
            this.ListConnection = helper.ListConnection();
            this.cboxConnectionNameColl.DataSource = this.ListConnection;
            this.cboxConnectionNameColl.DisplayMember = "ConnectionName";
            this.cboxConnectionNameColl.ValueMember = "ConnectionString";
            if (this.ListConnection.Count > 0)
            {
                this.txbConnString.Text = this.ListConnection[0].ConnectionString;
            }
        }

        private void BindTemplateList()
        {
            this.TemplateTreeView.Nodes.Add("项目模板");
            TreeNodeCollection treeNodeCollection = this.TemplateTreeView.Nodes[0].Nodes;
            string path = Application.StartupPath + @"\CodeTemplate\";
            DirectoryInfo info = new DirectoryInfo(path);
            if (!info.Exists)
            {
                info.Create();
            }
            this.DeleteDirectory(path, treeNodeCollection);
            this.TemplateTreeView.ExpandAll();
        }

        private void butAddConnection_Click(object sender, EventArgs e)
        {
            FrmAddConnection connection = new FrmAddConnection();
            connection.ShowDialog();
            if (!string.IsNullOrEmpty(connection.ConnectionString))
            {
                new XmlHelper(Application.StartupPath).AddConnection(connection.ConnectionName, connection.ConnectionString, connection.SelectedDataBase);
                this.BindConnection();
                this.cboxConnectionNameColl.SelectedIndex = this.cboxConnectionNameColl.Items.Count - 1;
                this.butTest_Click(null, null);
            }
        }

        private void butCode_Click_1(object sender, EventArgs e)
        {
        }

        private void butSelectedAllTable_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.lboxTable.Items.Count; i++)
            {
                if (!this.lboxTable2.Items.Contains(this.lboxTable.Items[i]))
                {
                    this.lboxTable2.Items.Add(this.lboxTable.Items[i]);
                }
            }
            this.lboxTable.Items.Clear();
        }

        private void butDeleteConnection_Click(object sender, EventArgs e)
        {
            new XmlHelper(Application.StartupPath).DeleteConnection(this.cboxConnectionNameColl.Text);
            this.BindConnection();
            if (this.cboxConnectionNameColl.Items.Count <= 0)
            {
                this.txbConnString.Text = string.Empty;
            }
        }

        private void butDeleteAllTable_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.lboxTable2.Items.Count; i++)
            {
                if (!this.lboxTable.Items.Contains(this.lboxTable2.Items[i]))
                {
                    this.lboxTable.Items.Add(this.lboxTable2.Items[i]);
                }
            }
            this.lboxTable2.Items.Clear();
        }

        private void butTest_Click(object sender, EventArgs e)
        {
            IDataBase base2 = new DataBase();
            try
            {
                if ((this.cboxConnectionNameColl.SelectedValue == null) || (this.cboxConnectionNameColl.SelectedValue.ToString().Length <= 0))
                {
                    base.Alert("请输入连接字符串", "连接失败", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return;
                }
                var db = base2.GetDataBase(this.ReturnType(), this.cboxConnectionNameColl.SelectedValue.ToString());
                this.tables = db.Tables;
                this.views = db.Views;
                lboxTable.Items.Clear();
                lboxTable2.Items.Clear();
                ArrayList list = new ArrayList();

                foreach (TableSchema schema in this.tables)
                {
                    this.lboxTable.Items.Add(schema.Name);
                    list.Add(schema.Name);
                }
                foreach (var item in this.views)
                {
                    this.lboxTable.Items.Add(item.Name);
                    list.Add(item.Name);
                }
                txbSelectedTable.PromptForeColor = Color.Gray;
                txbSelectedTable.PromptBackColor = Color.Snow;
                txbSelectedTable.EnterKeyEvent += new CodeGeneration.UserControls.TextBoxSEO.EnterKey(txbSelectedTable_EnterKeyEvent);
                txbSelectedTable.ChoiceArray = list;
                this.num++;
            }
            catch (Exception exception)
            {
                base.Alert(exception.Message, "连接失败", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }
        }
        //在智能输入框敲回车键时引发
        void txbSelectedTable_EnterKeyEvent()
        {
            butSelectTable_Click(null, null);
        }

        private void butSelectFileSavePath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.SelectedPath = this.txbURL.Text;
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                this.txbURL.Text = dialog.SelectedPath;
            }
        }

        private void butSelectedItemTable_Click(object sender, EventArgs e)
        {
            int count = this.lboxTable.SelectedItems.Count;
            ListBox.SelectedObjectCollection selectedItems = this.lboxTable.SelectedItems;
            for (int i = 0; i < count; i++)
            {
                this.lboxTable2.Items.Add(this.lboxTable.SelectedItems[i]);
            }
            for (int j = 0; j < count; j++)
            {
                if (this.lboxTable.SelectedItems.Count > 0)
                {
                    this.lboxTable.Items.Remove(this.lboxTable.SelectedItems[0]);
                }
            }
        }

        private void butDeleteItemTable_Click(object sender, EventArgs e)
        {
            int count = this.lboxTable2.SelectedItems.Count;
            ListBox.SelectedObjectCollection selectedItems = this.lboxTable2.SelectedItems;
            for (int i = 0; i < count; i++)
            {
                this.lboxTable.Items.Add(this.lboxTable2.SelectedItems[i]);
            }
            for (int j = 0; j < count; j++)
            {
                if (this.lboxTable2.SelectedItems.Count > 0)
                {
                    this.lboxTable2.Items.Remove(this.lboxTable2.SelectedItems[0]);
                }
            }
        }

        private void butSelectTable_Click(object sender, EventArgs e)
        {
            string str = this.txbSelectedTable.Text.Trim();
            if (str != "")
            {
                str = str.ToUpper();
                List<string> list = new List<string>();
                foreach (string str2 in this.lboxTable.Items)
                {
                    if (str2.ToUpper() == str)
                    {
                        list.Add(str2);
                        break;
                    }
                }
                foreach (string str3 in list)
                {
                    this.lboxTable.Items.Remove(str3);
                    this.lboxTable2.Items.Add(str3);
                }
            }
        }

        private void butCreateCode_Click(object sender, EventArgs e)
        {
            string err = string.Empty;
            if (!this.CheckData(ref err))
            {
                base.Alert(err, "生成失败", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else
            {
                this.FolderCheck(this.txbURL.Text);
                //Thread therad = new Thread(GeneraterCodes);
                //therad.Start();
                this.CreateCode(this.txbURL.Text);
                if (this.cboxSaveConfig.Checked)
                {
                    this.SetDefaultValue();
                }
            }
        }
        public void GeneraterCodes()
        {
            this.CreateCode(this.txbURL.Text);
        }
        private void cboxConnectionNameColl_SelectedIndexChanged(object sender, EventArgs e)
        {
            string connectionString = this.cboxConnectionNameColl.SelectedValue.ToString();
            Connection selectedValue = this.cboxConnectionNameColl.SelectedValue as Connection;
            if (selectedValue != null)
            {
                connectionString = selectedValue.ConnectionString;
            }
            this.txbConnString.Text = connectionString;
        }

        private bool CheckData(ref string Err)
        {
            if (txbURL.Text.Length <= 0)
            {
                Alert("请选择需要将文件保持的目录");
                return false;
            }
            return true;
        }

        private bool CreateCode(string savePath)
        {
            string listTable = string.Empty;
            string str2 = string.Empty;
            this.DataAccessList = new List<string>();
            this.FacadeList = new List<string>();
            this.MyClassList = new List<string>();
            tempList = new List<string>();
            this.GetTempList(this.TemplateTreeView.Nodes);
            foreach (var item in lboxTable2.Items)
            {
                TableSchema table = this.tables.FirstOrDefault(s => s.Name == item.ToString());
                ViewSchema view = this.views.FirstOrDefault(s => s.Name == item.ToString());
                foreach (string tempPath in this.tempList)
                {
                    try
                    {
                        CodeFile file = null;
                        if (table != null)
                        {
                            file = TemplateFactory.BuilderCodes(tempPath, table);
                        }
                        else
                        {
                            file = TemplateFactory.BuilderCodes(tempPath, view);
                        }
                        this.GernalFile(file.Codes, string.Format(@"{0}\{1}", savePath, file.FileName));
                        this.DataAccessList.Add(file.FileName + "#" + file.Codes);
                        continue;
                    }
                    catch (Exception exception)
                    {
                        if (exception.Message.IndexOf("未设置主键") > 0)
                        {
                            listTable = listTable + "|" + str2;
                            base.DialogResult = base.Alert(exception.Message + ",是否终止生成！", "生成失败", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                            if (base.DialogResult == DialogResult.Yes)
                            {
                                base.Alert("取消成功", "生成失败！", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                return false;
                            }
                            this.lboxTable.Items.Add(item);
                        }
                        else
                        {
                            base.Alert(exception.Message, "生成失败！", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                        break;
                    }
                }

            }
            if (!string.IsNullOrEmpty(listTable.Trim()))
            {
                this.DelItem(listTable);

            }
            base.Alert("生成完成！", "生成完成", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            return true;
        }

        public void DeleteDirectory(string DirectoryPath, TreeNodeCollection treeNodeCollection)
        {
            TreeNode node = null;
            DirectoryInfo info = new DirectoryInfo(DirectoryPath);
            DirectoryInfo[] directories = info.GetDirectories();
            FileInfo[] files = info.GetFiles();
            if (directories.Length > 0)
            {
                foreach (DirectoryInfo info2 in directories)
                {
                    node = new TreeNode(info2.Name);
                    treeNodeCollection.Add(node);
                    this.DeleteDirectory(DirectoryPath + @"\" + info2.Name, node.Nodes);
                }
            }
            if (files.Length > 0)
            {
                foreach (FileInfo info3 in files)
                {
                    node = new TreeNode(info3.Name);
                    node.Name = DirectoryPath + @"\" + info3.Name;
                    treeNodeCollection.Add(node);
                }
            }
        }

        private void DelItem(string listTable)
        {
            foreach (string str in listTable.Substring(1).Split(new char[] { '|' }))
            {
                this.lboxTable2.Items.Remove(str);
            }
        }

        private void FolderCheck(string Folder)
        {
            DirectoryInfo info = new DirectoryInfo(Folder);
            if (!info.Exists)
            {
                info.Create();
            }
        }

        private void GernalFile(string content, string path)
        {
            StreamWriter writer = new StreamWriter(path, false, Encoding.UTF8);
            writer.Write(content);
            writer.Flush();
            writer.Close();
        }

        private void GetTempList(TreeNodeCollection nodeColl)
        {
            foreach (TreeNode node in nodeColl)
            {
                if (node.Nodes.Count > 0)
                {
                    this.GetTempList(node.Nodes);
                }
                else if (node.Checked)
                {
                    this.tempList.Add(node.Name);
                }
            }
        }

        private void lboxTable_DoubleClick(object sender, MouseEventArgs e)
        {
            if (this.lboxTable.SelectedItem != null)
            {
                this.lboxTable2.Items.Add(this.lboxTable.SelectedItem);
                this.lboxTable.Items.Remove(this.lboxTable.SelectedItem);
            }
        }

        private void lboxTable2_DoubleClick(object sender, MouseEventArgs e)
        {
            if (this.lboxTable2.SelectedItem != null)
            {
                this.lboxTable.Items.Add(this.lboxTable2.SelectedItem);
                this.lboxTable2.Items.Remove(this.lboxTable2.SelectedItem);
            }
        }

        private string NameingClass(string item)
        {
            string str = string.Empty;
            int num = 0;
            for (int i = 0; i < item.Length; i++)
            {
                if (item[i] == '_')
                {
                    num = i + 1;
                }
                if ((str == string.Empty) || (num == i))
                {
                    char ch = item[i];
                    str = str + ch.ToString().ToUpper();
                }
                else
                {
                    char ch2 = item[i];
                    str = str + ch2.ToString().ToLower();
                }
            }
            return str;
        }

        private DataBaseType ReturnType()
        {
            return this.ListConnection.Find(delegate(Connection c)
            {
                return c.ConnectionName == this.cboxConnectionNameColl.Text;
            }).DBType;
        }

        private void SetDefaultValue()
        {
            XmlHelper helper = new XmlHelper(Application.StartupPath);
            helper.SetDefaultValue("Save_Path", this.txbURL.Text);
            helper.SetDefaultValue("CodeTemplate_Path", this.TemplateTreeView.SelectedNode.Name);
        }

        private void TemplateTreeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            e.Node.Checked = !e.Node.Checked;
            foreach (TreeNode node in e.Node.Nodes)
            {
                node.Checked = e.Node.Checked;
                if (node.Nodes.Count > 0)
                    SelectedTemplateNodes(node.Nodes, e.Node.Checked);
            }
        }
        private void SelectedTemplateNodes(TreeNodeCollection nodeColl, bool selectedStatus)
        {
            foreach (TreeNode item in nodeColl)
            {
                item.Checked = selectedStatus;
                if (item.Nodes.Count > 0)
                    SelectedTemplateNodes(item.Nodes, selectedStatus);
            }
        }
        private List<Connection> ListConnection
        {
            get;
            set;
        }

        private List<string> MyClassList
        {
            get;
            set;
        }

        private int num
        {
            get;
            set;
        }

        public delegate void CreateDataAccessAndFacadeCode(string savePath);

        private void cboxConnectionNameColl_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            txbConnString.Text = cboxConnectionNameColl.SelectedValue.ToString();
        }
    }
}

