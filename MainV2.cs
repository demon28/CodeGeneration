using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using DevComponents.DotNetBar;
using ICSharpCode.TextEditor;
using CodeGeneration.Entities;
using System.Diagnostics;

namespace CodeGeneration
{
    public partial class MainV2 : Form
    {
        ContextMenuStrip TabMenu;
        public MainV2()
        {
            InitializeComponent();
            BindTemplateList();
            InitTabMenu();
            BindLogHis();
        }

        private void BindLogHis()
        {
            string path = Application.StartupPath + @"\Version_Log.txt";
            if (!File.Exists(path))
                return;
            FileStream fileStream = File.OpenRead(path);
            StreamReader reader = new StreamReader(fileStream, Encoding.GetEncoding("GB2312"));
            logbox.Text = reader.ReadToEnd();
            fileStream.Flush();
            fileStream.Close();
        }

        #region TabItem右键菜单
        //初始化
        private void InitTabMenu()
        {
            TabMenu = new ContextMenuStrip();
            TabMenu.Items.Add("关闭", null, CloseTemp);
            TabMenu.Items.Add("除此之外全部关闭", null, CloseAllTemp);
            TabMenu.Items.Add("打开所在文件夹", null, OpenInFolderPath);
        }

        //关闭单个模板
        private void CloseTemp(object sender, EventArgs e)
        {
            tabControl1.Tabs.Remove(tabControl1.SelectedTab);
            tabControl1.SelectedTabIndex = 0;
        }

        //除此之外全部关闭
        private void CloseAllTemp(object sender, EventArgs e)
        {
            List<TabItem> list = new List<TabItem>();
            foreach (TabItem item in tabControl1.Tabs)
            {
                if (item != tabControl1.SelectedTab && item.Text != "首页")
                    list.Add(item);
            }
            foreach (var item in list)
            {
                tabControl1.Tabs.Remove(item);
            }
            tabControl1.SelectedTabIndex = 0;
            tabControl1.SelectedTabIndex = 1;
        }

        //打开所在文件夹
        private void OpenInFolderPath(object sender, EventArgs e)
        {
            TextEditorControl textEditor = tabControl1.SelectedTab.AttachedControl.Controls[0] as TextEditorControl;
            Process.Start(textEditor.FileName.Substring(0, textEditor.FileName.LastIndexOf(@"\")));
        }
        #endregion

        #region 绑定模板

        private void BindTemplateList()
        {

            TemplateTreeView.ImageList = imageList1;
            TreeNode node = new TreeNode("项目模板");
            node.ImageIndex = 0;
            this.TemplateTreeView.Nodes.Add(node);
            //imageList1
            TreeNodeCollection treeNodeCollection = this.TemplateTreeView.Nodes[0].Nodes;
            string path = Application.StartupPath + @"\CodeTemplate\";
            DirectoryInfo info = new DirectoryInfo(path);
            if (!info.Exists)
            {
                info.Create();
            }
            this.DeleteDirectory(path, treeNodeCollection);
            this.TemplateTreeView.ExpandAll();
            //contextMenuBar1.SetContextMenuEx(TemplateTreeView, textEditorControlMenu);
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
                    node.ImageIndex = 1;
                    node.SelectedImageIndex = 1;
                    treeNodeCollection.Add(node);
                    this.DeleteDirectory(DirectoryPath + @"\" + info2.Name, node.Nodes);
                }
            }
            if (files.Length > 0)
            {
                foreach (FileInfo info3 in files)
                {
                    node = new TreeNode(info3.Name);
                    node.ImageIndex = 3;
                    node.SelectedImageIndex = 3;
                    node.Name = DirectoryPath + @"\" + info3.Name;
                    treeNodeCollection.Add(node);
                }
            }
        }

        #endregion

        #region 打开模板选项卡窗体

        private void TemplateTreeView_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (string.IsNullOrEmpty(e.Node.Name))
                return;
            AddTabItem(e.Node.Name, e.Node.Text.Substring(0, e.Node.Text.LastIndexOf(".")));
        }

        #endregion

        #region 调整内容窗体大小

        private void MainV2_Resize(object sender, EventArgs e)
        {
            splitContent.Height = ribbonPanelContent.Height;
            splitContent.Width = ribbonPanelContent.Width;
            if (splitContent.SplitterDistance < 25)
            {
                splitContent.SplitterDistance = 25;
            }
        }

        int splitContentSplitterDistance = 0;
        private void leftMenu_ExpandedChanged(object sender, DevComponents.DotNetBar.ExpandedChangeEventArgs e)
        {
            if (splitContent.SplitterDistance == 25)
            {
                splitContent.SplitterDistance = splitContentSplitterDistance;
            }
            else
            {
                splitContentSplitterDistance = splitContent.SplitterDistance;
                splitContent.SplitterDistance = 25;
            }
        }
        #endregion

        //代码生成代码窗体
        private void butCreateCodeWin_Click(object sender, EventArgs e)
        {
            new GeneraterForm().Show();
        }

        //代码数据库配置
        private void buttonItem6_Click(object sender, EventArgs e)
        {
            FrmAddConnection connection = new FrmAddConnection();
            connection.ShowDialog();
            if (!string.IsNullOrEmpty(connection.ConnectionString))
            {
                new XmlHelper(Application.StartupPath).AddConnection(connection.ConnectionName, connection.ConnectionString, connection.SelectedDataBase);
            }
        }

        //打开文件
        private void butOpenFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            dialog.Filter = "代码模板(*.template)|*.template|C#代码(*.cs)|*.cs|XML(*.xml)|*.xml|TXT(*.txt)|*.txt";
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                AddTabItem(dialog.FileName, dialog.SafeFileName);
            }
        }

        //添加选项卡
        private void AddTabItem(string filePath, string name)
        {
            if (!File.Exists(filePath))
            {
                return;
            }
            foreach (TabItem item in tabControl1.Tabs)
            {
                if (item.Text != name)
                    continue;
                TextEditorControl textEditor = item.AttachedControl.Controls[0] as TextEditorControl;
                if (textEditor == null)
                    continue;
                if (textEditor.FileName == filePath)
                {
                    tabControl1.SelectedTab = item;
                    return;
                }
            }
            DevComponents.DotNetBar.TabControlPanel tabControlPanel = new TabControlPanel();
            DevComponents.DotNetBar.TabItem tabItem = new TabItem();
            ICSharpCode.TextEditor.TextEditorControl textEditorControl = new TextEditorControl();
            // tabControl1
            tabControl1.CanReorderTabs = true;
            tabControl1.Controls.Add(tabControlPanel);
            tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            tabControl1.Location = new System.Drawing.Point(0, 0);
            tabControl1.Name = "tabControl" + name;
            tabControl1.SelectedTabFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold);
            tabControl1.SelectedTabIndex = 0;
            tabControl1.Size = new System.Drawing.Size(805, 438);
            tabControl1.TabIndex = 0;
            tabControl1.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox;
            tabControl1.Tabs.Add(tabItem);
            tabControl1.SelectedTab = tabItem;
            // tabItem1
            tabItem.AttachedControl = tabControlPanel;
            tabItem.Name = "tabItem" + tabControl1.Tabs.Count + 1;
            tabItem.Text = name;
            tabItem.MouseDown += new MouseEventHandler(tabItem_MouseDown);
            // tabControlPanel1
            tabControlPanel.Controls.Add(textEditorControl);
            tabControlPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            tabControlPanel.Location = new System.Drawing.Point(0, 26);
            tabControlPanel.Name = "tabControlPanel" + tabControl1.Tabs.Count + 1;
            tabControlPanel.Padding = new System.Windows.Forms.Padding(1);
            tabControlPanel.Size = new System.Drawing.Size(805, 412);
            tabControlPanel.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(179)))), ((int)(((byte)(231)))));
            tabControlPanel.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            tabControlPanel.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            tabControlPanel.Style.BorderColor.Color = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(97)))), ((int)(((byte)(156)))));
            tabControlPanel.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right)
                        | DevComponents.DotNetBar.eBorderSide.Bottom)));
            tabControlPanel.Style.GradientAngle = 90;
            tabControlPanel.TabItem = tabItem;
            // textEditorControl1
            textEditorControl.Dock = System.Windows.Forms.DockStyle.Fill;
            textEditorControl.IsReadOnly = false;
            textEditorControl.Location = new System.Drawing.Point(1, 1);
            textEditorControl.Name = "textEditorControl" + tabControl1.Tabs.Count + 1;
            textEditorControl.Size = new System.Drawing.Size(803, 410);
            textEditorControl.LoadFile(filePath);

            //contextMenuBar1.SetContextMenuEx(textEditorControl, textEditorControlMenu);
        }

        //显示tab菜单
        void tabItem_MouseDown(object sender, MouseEventArgs e)
        {
            tabControl1.SelectedTab = ((TabItem)sender);
            if (tabControl1.Tabs.Count > 1 && e.Button == MouseButtons.Right)
            {
                this.TabMenu.Show(Control.MousePosition.X, Control.MousePosition.Y);
            }
        }

        //保存当前修改的文件
        private void butSave_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab.Text == "首页")
            {
                return;
            }
            TextEditorControl textEditor = tabControl1.SelectedTab.AttachedControl.Controls[0] as TextEditorControl;
            StreamWriter writer = new StreamWriter(textEditor.FileName, false, Encoding.UTF8);
            writer.Write(textEditor.Text);
            writer.Flush();
            writer.Close();
        }

        //退出
        private void butClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

}
