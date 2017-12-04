using DevComponents.DotNetBar;
using System.Windows.Forms;
using DevComponents.DotNetBar.Controls;
using System.Threading;
using SchemaExplorer;
using System.Collections.Generic;
using System.Drawing;
namespace CodeGeneration
{
    partial class GeneraterForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        private ButtonX butAddConnection;
        private ButtonX butCode;
        private ButtonX butSelectedAllTable;
        private ButtonX butDeleteConnection;
        private ButtonX butDeleteAllTable;
        private ButtonX butTest;
        private ButtonX butSeleteSavePath;
        private ButtonX butDeleteItemTable;
        private ButtonX butSelectTable;
        private ButtonX butSelectedItemTable;
        private ButtonX butCreateCode;
        private ComboBox cboxConnectionNameColl;
        private CheckBox cboxSaveConfig;
        private GroupPanel groupPanel_Template;
        private GroupPanel groupPanel_DataBase;
        private GroupPanel groupPanel_Config;
        private GroupPanel groupPanel_Tables;
        private LabelX labelX3;
        private LabelX labelX4;
        private LabelX lblConnectionName;
        private LabelX lblConnectionStr;
        private ListBox lboxTable;
        private ListBox lboxTable2;
        private Thread mythread;
        private ProgressBarX prog;
        private TableSchemaCollection tables;
        private ViewSchemaCollection views;
        private TreeView TemplateTreeView;
        private List<string> tempList;
        private TextBoxX txbConnString;
        private TextBoxX txbURL;
        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GeneraterForm));
            this.groupPanel_DataBase = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.txbConnString = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.butDeleteConnection = new DevComponents.DotNetBar.ButtonX();
            this.lblConnectionStr = new DevComponents.DotNetBar.LabelX();
            this.butAddConnection = new DevComponents.DotNetBar.ButtonX();
            this.cboxConnectionNameColl = new System.Windows.Forms.ComboBox();
            this.lblConnectionName = new DevComponents.DotNetBar.LabelX();
            this.butTest = new DevComponents.DotNetBar.ButtonX();
            this.groupPanel_Config = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.txbURL = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.butSeleteSavePath = new DevComponents.DotNetBar.ButtonX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.groupPanel_Template = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.TemplateTreeView = new System.Windows.Forms.TreeView();
            this.lboxTable2 = new System.Windows.Forms.ListBox();
            this.butDeleteAllTable = new DevComponents.DotNetBar.ButtonX();
            this.butSelectedAllTable = new DevComponents.DotNetBar.ButtonX();
            this.butSelectedItemTable = new DevComponents.DotNetBar.ButtonX();
            this.butDeleteItemTable = new DevComponents.DotNetBar.ButtonX();
            this.lboxTable = new System.Windows.Forms.ListBox();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.butSelectTable = new DevComponents.DotNetBar.ButtonX();
            this.groupPanel_Tables = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.txbSelectedTable = new CodeGeneration.UserControls.TextBoxSEO();
            this.cboxSaveConfig = new System.Windows.Forms.CheckBox();
            this.butCreateCode = new DevComponents.DotNetBar.ButtonX();
            this.butCode = new DevComponents.DotNetBar.ButtonX();
            this.prog = new DevComponents.DotNetBar.Controls.ProgressBarX();
            this.groupPanel_DataBase.SuspendLayout();
            this.groupPanel_Config.SuspendLayout();
            this.groupPanel_Template.SuspendLayout();
            this.groupPanel_Tables.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupPanel_DataBase
            // 
            this.groupPanel_DataBase.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel_DataBase.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel_DataBase.Controls.Add(this.txbConnString);
            this.groupPanel_DataBase.Controls.Add(this.butDeleteConnection);
            this.groupPanel_DataBase.Controls.Add(this.lblConnectionStr);
            this.groupPanel_DataBase.Controls.Add(this.butAddConnection);
            this.groupPanel_DataBase.Controls.Add(this.cboxConnectionNameColl);
            this.groupPanel_DataBase.Controls.Add(this.lblConnectionName);
            this.groupPanel_DataBase.Controls.Add(this.butTest);
            this.groupPanel_DataBase.Location = new System.Drawing.Point(12, 12);
            this.groupPanel_DataBase.Name = "groupPanel_DataBase";
            this.groupPanel_DataBase.Size = new System.Drawing.Size(396, 111);
            // 
            // 
            // 
            this.groupPanel_DataBase.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel_DataBase.Style.BackColorGradientAngle = 90;
            this.groupPanel_DataBase.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel_DataBase.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel_DataBase.Style.BorderBottomWidth = 1;
            this.groupPanel_DataBase.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel_DataBase.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel_DataBase.Style.BorderLeftWidth = 1;
            this.groupPanel_DataBase.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel_DataBase.Style.BorderRightWidth = 1;
            this.groupPanel_DataBase.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel_DataBase.Style.BorderTopWidth = 1;
            this.groupPanel_DataBase.Style.CornerDiameter = 4;
            this.groupPanel_DataBase.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel_DataBase.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel_DataBase.TabIndex = 27;
            this.groupPanel_DataBase.Text = "连接数据库";
            // 
            // txbConnString
            // 
            // 
            // 
            // 
            this.txbConnString.Border.Class = "TextBoxBorder";
            this.txbConnString.Location = new System.Drawing.Point(73, 34);
            this.txbConnString.Multiline = true;
            this.txbConnString.Name = "txbConnString";
            this.txbConnString.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txbConnString.Size = new System.Drawing.Size(224, 43);
            this.txbConnString.TabIndex = 42;
            // 
            // butDeleteConnection
            // 
            this.butDeleteConnection.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.butDeleteConnection.ForeColor = System.Drawing.SystemColors.InfoText;
            this.butDeleteConnection.Location = new System.Drawing.Point(303, 9);
            this.butDeleteConnection.Name = "butDeleteConnection";
            this.butDeleteConnection.Size = new System.Drawing.Size(78, 23);
            this.butDeleteConnection.TabIndex = 44;
            this.butDeleteConnection.Text = "删  除";
            this.butDeleteConnection.Click += new System.EventHandler(this.butDeleteConnection_Click);
            // 
            // lblConnectionStr
            // 
            this.lblConnectionStr.BackColor = System.Drawing.Color.Transparent;
            this.lblConnectionStr.Location = new System.Drawing.Point(8, 34);
            this.lblConnectionStr.Name = "lblConnectionStr";
            this.lblConnectionStr.Size = new System.Drawing.Size(75, 23);
            this.lblConnectionStr.TabIndex = 41;
            this.lblConnectionStr.Text = "链接字符：";
            // 
            // butAddConnection
            // 
            this.butAddConnection.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.butAddConnection.ForeColor = System.Drawing.SystemColors.InfoText;
            this.butAddConnection.Location = new System.Drawing.Point(208, 9);
            this.butAddConnection.Name = "butAddConnection";
            this.butAddConnection.Size = new System.Drawing.Size(72, 23);
            this.butAddConnection.TabIndex = 40;
            this.butAddConnection.Text = "添  加";
            this.butAddConnection.Click += new System.EventHandler(this.butAddConnection_Click);
            // 
            // cboxConnectionNameColl
            // 
            this.cboxConnectionNameColl.FormattingEnabled = true;
            this.cboxConnectionNameColl.Location = new System.Drawing.Point(73, 8);
            this.cboxConnectionNameColl.Name = "cboxConnectionNameColl";
            this.cboxConnectionNameColl.Size = new System.Drawing.Size(115, 20);
            this.cboxConnectionNameColl.TabIndex = 39;
            this.cboxConnectionNameColl.SelectedIndexChanged += new System.EventHandler(this.cboxConnectionNameColl_SelectedIndexChanged_1);
            // 
            // lblConnectionName
            // 
            this.lblConnectionName.BackColor = System.Drawing.Color.Transparent;
            this.lblConnectionName.Location = new System.Drawing.Point(9, 9);
            this.lblConnectionName.Name = "lblConnectionName";
            this.lblConnectionName.Size = new System.Drawing.Size(86, 23);
            this.lblConnectionName.TabIndex = 38;
            this.lblConnectionName.Text = "链接命令：";
            // 
            // butTest
            // 
            this.butTest.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.butTest.ForeColor = System.Drawing.SystemColors.InfoText;
            this.butTest.Location = new System.Drawing.Point(303, 34);
            this.butTest.Name = "butTest";
            this.butTest.Size = new System.Drawing.Size(78, 43);
            this.butTest.TabIndex = 3;
            this.butTest.Text = "连接\\测试";
            this.butTest.Click += new System.EventHandler(this.butTest_Click);
            // 
            // groupPanel_Config
            // 
            this.groupPanel_Config.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel_Config.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel_Config.Controls.Add(this.txbURL);
            this.groupPanel_Config.Controls.Add(this.butSeleteSavePath);
            this.groupPanel_Config.Controls.Add(this.labelX4);
            this.groupPanel_Config.Location = new System.Drawing.Point(12, 129);
            this.groupPanel_Config.Name = "groupPanel_Config";
            this.groupPanel_Config.Size = new System.Drawing.Size(396, 57);
            // 
            // 
            // 
            this.groupPanel_Config.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel_Config.Style.BackColorGradientAngle = 90;
            this.groupPanel_Config.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel_Config.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel_Config.Style.BorderBottomWidth = 1;
            this.groupPanel_Config.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel_Config.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel_Config.Style.BorderLeftWidth = 1;
            this.groupPanel_Config.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel_Config.Style.BorderRightWidth = 1;
            this.groupPanel_Config.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel_Config.Style.BorderTopWidth = 1;
            this.groupPanel_Config.Style.CornerDiameter = 4;
            this.groupPanel_Config.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel_Config.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel_Config.TabIndex = 29;
            this.groupPanel_Config.Text = "保存位置";
            // 
            // txbURL
            // 
            this.txbURL.BackColor = System.Drawing.SystemColors.Window;
            // 
            // 
            // 
            this.txbURL.Border.Class = "TextBoxBorder";
            this.txbURL.Font = new System.Drawing.Font("宋体", 10F);
            this.txbURL.ForeColor = System.Drawing.Color.Black;
            this.txbURL.Location = new System.Drawing.Point(74, 0);
            this.txbURL.Name = "txbURL";
            this.txbURL.Size = new System.Drawing.Size(258, 24);
            this.txbURL.TabIndex = 20;
            this.txbURL.Text = "C:\\Users\\fine\\Desktop\\CreateCode";
            this.txbURL.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // butSeleteSavePath
            // 
            this.butSeleteSavePath.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.butSeleteSavePath.ForeColor = System.Drawing.SystemColors.InfoText;
            this.butSeleteSavePath.Location = new System.Drawing.Point(336, 0);
            this.butSeleteSavePath.Name = "butSeleteSavePath";
            this.butSeleteSavePath.Size = new System.Drawing.Size(42, 23);
            this.butSeleteSavePath.TabIndex = 9;
            this.butSeleteSavePath.Text = "浏览";
            this.butSeleteSavePath.Click += new System.EventHandler(this.butSelectFileSavePath_Click);
            // 
            // labelX4
            // 
            this.labelX4.BackColor = System.Drawing.Color.Transparent;
            this.labelX4.Location = new System.Drawing.Point(6, 3);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(75, 23);
            this.labelX4.TabIndex = 8;
            this.labelX4.Text = "保存到(S)：";
            // 
            // groupPanel_Template
            // 
            this.groupPanel_Template.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel_Template.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel_Template.Controls.Add(this.TemplateTreeView);
            this.groupPanel_Template.Location = new System.Drawing.Point(12, 202);
            this.groupPanel_Template.Name = "groupPanel_Template";
            this.groupPanel_Template.Size = new System.Drawing.Size(396, 275);
            // 
            // 
            // 
            this.groupPanel_Template.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel_Template.Style.BackColorGradientAngle = 90;
            this.groupPanel_Template.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel_Template.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel_Template.Style.BorderBottomWidth = 1;
            this.groupPanel_Template.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel_Template.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel_Template.Style.BorderLeftWidth = 1;
            this.groupPanel_Template.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel_Template.Style.BorderRightWidth = 1;
            this.groupPanel_Template.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel_Template.Style.BorderTopWidth = 1;
            this.groupPanel_Template.Style.CornerDiameter = 4;
            this.groupPanel_Template.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel_Template.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel_Template.TabIndex = 30;
            this.groupPanel_Template.Text = "选择模板";
            // 
            // TemplateTreeView
            // 
            this.TemplateTreeView.CheckBoxes = true;
            this.TemplateTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TemplateTreeView.Location = new System.Drawing.Point(0, 0);
            this.TemplateTreeView.Name = "TemplateTreeView";
            this.TemplateTreeView.Size = new System.Drawing.Size(390, 251);
            this.TemplateTreeView.TabIndex = 1;
            this.TemplateTreeView.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.TemplateTreeView_NodeMouseClick);
            // 
            // lboxTable2
            // 
            this.lboxTable2.BackColor = System.Drawing.SystemColors.HighlightText;
            this.lboxTable2.FormattingEnabled = true;
            this.lboxTable2.ItemHeight = 12;
            this.lboxTable2.Location = new System.Drawing.Point(214, 45);
            this.lboxTable2.Name = "lboxTable2";
            this.lboxTable2.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lboxTable2.Size = new System.Drawing.Size(172, 340);
            this.lboxTable2.TabIndex = 1;
            this.lboxTable2.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lboxTable2_DoubleClick);
            // 
            // butDeleteAllTable
            // 
            this.butDeleteAllTable.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.butDeleteAllTable.ForeColor = System.Drawing.SystemColors.InfoText;
            this.butDeleteAllTable.Location = new System.Drawing.Point(162, 223);
            this.butDeleteAllTable.Name = "butDeleteAllTable";
            this.butDeleteAllTable.Size = new System.Drawing.Size(46, 23);
            this.butDeleteAllTable.TabIndex = 10;
            this.butDeleteAllTable.Text = "<<";
            this.butDeleteAllTable.Click += new System.EventHandler(this.butDeleteAllTable_Click);
            // 
            // butSelectedAllTable
            // 
            this.butSelectedAllTable.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.butSelectedAllTable.ForeColor = System.Drawing.SystemColors.InfoText;
            this.butSelectedAllTable.Location = new System.Drawing.Point(162, 152);
            this.butSelectedAllTable.Name = "butSelectedAllTable";
            this.butSelectedAllTable.Size = new System.Drawing.Size(46, 23);
            this.butSelectedAllTable.TabIndex = 11;
            this.butSelectedAllTable.Text = ">>";
            this.butSelectedAllTable.Click += new System.EventHandler(this.butSelectedAllTable_Click);
            // 
            // butSelectedItemTable
            // 
            this.butSelectedItemTable.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.butSelectedItemTable.ForeColor = System.Drawing.SystemColors.InfoText;
            this.butSelectedItemTable.Location = new System.Drawing.Point(162, 107);
            this.butSelectedItemTable.Name = "butSelectedItemTable";
            this.butSelectedItemTable.Size = new System.Drawing.Size(46, 23);
            this.butSelectedItemTable.TabIndex = 12;
            this.butSelectedItemTable.Text = ">";
            this.butSelectedItemTable.Click += new System.EventHandler(this.butSelectedItemTable_Click);
            // 
            // butDeleteItemTable
            // 
            this.butDeleteItemTable.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.butDeleteItemTable.ForeColor = System.Drawing.SystemColors.InfoText;
            this.butDeleteItemTable.Location = new System.Drawing.Point(162, 190);
            this.butDeleteItemTable.Name = "butDeleteItemTable";
            this.butDeleteItemTable.Size = new System.Drawing.Size(46, 23);
            this.butDeleteItemTable.TabIndex = 13;
            this.butDeleteItemTable.Text = "<";
            this.butDeleteItemTable.Click += new System.EventHandler(this.butDeleteItemTable_Click);
            // 
            // lboxTable
            // 
            this.lboxTable.FormattingEnabled = true;
            this.lboxTable.ItemHeight = 12;
            this.lboxTable.Location = new System.Drawing.Point(1, 45);
            this.lboxTable.Name = "lboxTable";
            this.lboxTable.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lboxTable.Size = new System.Drawing.Size(155, 340);
            this.lboxTable.TabIndex = 20;
            this.lboxTable.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lboxTable_DoubleClick);
            // 
            // labelX3
            // 
            this.labelX3.BackColor = System.Drawing.Color.Transparent;
            this.labelX3.Location = new System.Drawing.Point(8, 10);
            this.labelX3.Name = "labelX3";
            this.labelX3.SingleLineColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.labelX3.Size = new System.Drawing.Size(73, 23);
            this.labelX3.TabIndex = 45;
            this.labelX3.Text = "智能筛选：";
            // 
            // butSelectTable
            // 
            this.butSelectTable.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.butSelectTable.ForeColor = System.Drawing.SystemColors.InfoText;
            this.butSelectTable.Location = new System.Drawing.Point(295, 8);
            this.butSelectTable.Name = "butSelectTable";
            this.butSelectTable.Size = new System.Drawing.Size(72, 23);
            this.butSelectTable.TabIndex = 41;
            this.butSelectTable.Text = "筛  选";
            this.butSelectTable.Click += new System.EventHandler(this.butSelectTable_Click);
            // 
            // groupPanel_Tables
            // 
            this.groupPanel_Tables.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel_Tables.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel_Tables.Controls.Add(this.txbSelectedTable);
            this.groupPanel_Tables.Controls.Add(this.butSelectTable);
            this.groupPanel_Tables.Controls.Add(this.lboxTable2);
            this.groupPanel_Tables.Controls.Add(this.butSelectedAllTable);
            this.groupPanel_Tables.Controls.Add(this.butSelectedItemTable);
            this.groupPanel_Tables.Controls.Add(this.butDeleteAllTable);
            this.groupPanel_Tables.Controls.Add(this.butDeleteItemTable);
            this.groupPanel_Tables.Controls.Add(this.cboxSaveConfig);
            this.groupPanel_Tables.Controls.Add(this.butCreateCode);
            this.groupPanel_Tables.Controls.Add(this.labelX3);
            this.groupPanel_Tables.Controls.Add(this.lboxTable);
            this.groupPanel_Tables.Controls.Add(this.butCode);
            this.groupPanel_Tables.Controls.Add(this.prog);
            this.groupPanel_Tables.Location = new System.Drawing.Point(414, 12);
            this.groupPanel_Tables.Name = "groupPanel_Tables";
            this.groupPanel_Tables.Size = new System.Drawing.Size(392, 465);
            // 
            // 
            // 
            this.groupPanel_Tables.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel_Tables.Style.BackColorGradientAngle = 90;
            this.groupPanel_Tables.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel_Tables.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel_Tables.Style.BorderBottomWidth = 1;
            this.groupPanel_Tables.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel_Tables.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel_Tables.Style.BorderLeftWidth = 1;
            this.groupPanel_Tables.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel_Tables.Style.BorderRightWidth = 1;
            this.groupPanel_Tables.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel_Tables.Style.BorderTopWidth = 1;
            this.groupPanel_Tables.Style.CornerDiameter = 4;
            this.groupPanel_Tables.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel_Tables.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel_Tables.TabIndex = 32;
            this.groupPanel_Tables.Text = "选择表";
            // 
            // txbSelectedTable
            // 
            this.txbSelectedTable.AllowSpace = false;
            this.txbSelectedTable.ChoiceArray = ((System.Collections.ArrayList)(resources.GetObject("txbSelectedTable.ChoiceArray")));
            this.txbSelectedTable.ChoicOnly = false;
            this.txbSelectedTable.Location = new System.Drawing.Point(77, 10);
            this.txbSelectedTable.Name = "txbSelectedTable";
            this.txbSelectedTable.PromptBackColor = System.Drawing.SystemColors.InfoText;
            this.txbSelectedTable.PromptForeColor = System.Drawing.SystemColors.InfoText;
            this.txbSelectedTable.Size = new System.Drawing.Size(208, 21);
            this.txbSelectedTable.TabIndex = 59;
            // 
            // cboxSaveConfig
            // 
            this.cboxSaveConfig.AutoSize = true;
            this.cboxSaveConfig.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.cboxSaveConfig.Location = new System.Drawing.Point(22, 419);
            this.cboxSaveConfig.Name = "cboxSaveConfig";
            this.cboxSaveConfig.Size = new System.Drawing.Size(96, 16);
            this.cboxSaveConfig.TabIndex = 46;
            this.cboxSaveConfig.Text = "保存本次配置";
            this.cboxSaveConfig.UseVisualStyleBackColor = false;
            // 
            // butCreateCode
            // 
            this.butCreateCode.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.butCreateCode.ForeColor = System.Drawing.SystemColors.InfoText;
            this.butCreateCode.Location = new System.Drawing.Point(129, 415);
            this.butCreateCode.Name = "butCreateCode";
            this.butCreateCode.Size = new System.Drawing.Size(75, 23);
            this.butCreateCode.TabIndex = 47;
            this.butCreateCode.Text = "生 成";
            this.butCreateCode.Click += new System.EventHandler(this.butCreateCode_Click);
            // 
            // butCode
            // 
            this.butCode.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.butCode.ForeColor = System.Drawing.SystemColors.InfoText;
            this.butCode.Location = new System.Drawing.Point(248, 415);
            this.butCode.Name = "butCode";
            this.butCode.Size = new System.Drawing.Size(75, 23);
            this.butCode.TabIndex = 49;
            this.butCode.Text = "查看代码";
            this.butCode.Click += new System.EventHandler(this.butCode_Click_1);
            // 
            // prog
            // 
            this.prog.Location = new System.Drawing.Point(11, 391);
            this.prog.Name = "prog";
            this.prog.Size = new System.Drawing.Size(367, 18);
            this.prog.Step = 100;
            this.prog.TabIndex = 48;
            this.prog.Text = "progressBarX1";
            // 
            // GeneraterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(812, 483);
            this.Controls.Add(this.groupPanel_Tables);
            this.Controls.Add(this.groupPanel_DataBase);
            this.Controls.Add(this.groupPanel_Config);
            this.Controls.Add(this.groupPanel_Template);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "GeneraterForm";
            this.Text = "生成代码";
            this.groupPanel_DataBase.ResumeLayout(false);
            this.groupPanel_Config.ResumeLayout(false);
            this.groupPanel_Template.ResumeLayout(false);
            this.groupPanel_Tables.ResumeLayout(false);
            this.groupPanel_Tables.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private CodeGeneration.UserControls.TextBoxSEO txbSelectedTable;





    }
}