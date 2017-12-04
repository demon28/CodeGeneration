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
    partial class FrmAddConnection
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAddConnection));
            this.lblName = new DevComponents.DotNetBar.LabelX();
            this.butAdd = new DevComponents.DotNetBar.ButtonX();
            this.butFail = new DevComponents.DotNetBar.ButtonX();
            this.txbName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.BackColor = System.Drawing.Color.Transparent;
            this.lblName.Location = new System.Drawing.Point(12, 21);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(78, 23);
            this.lblName.TabIndex = 13;
            this.lblName.Text = "链接名称：";
            // 
            // butAdd
            // 
            this.butAdd.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.butAdd.ForeColor = System.Drawing.SystemColors.InfoText;
            this.butAdd.Location = new System.Drawing.Point(15, 56);
            this.butAdd.Name = "butAdd";
            this.butAdd.Size = new System.Drawing.Size(75, 23);
            this.butAdd.TabIndex = 15;
            this.butAdd.Text = "添  加";
            this.butAdd.Click += new System.EventHandler(this.butAdd_Click);
            // 
            // butFail
            // 
            this.butFail.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.butFail.ForeColor = System.Drawing.SystemColors.InfoText;
            this.butFail.Location = new System.Drawing.Point(141, 56);
            this.butFail.Name = "butFail";
            this.butFail.Size = new System.Drawing.Size(75, 23);
            this.butFail.TabIndex = 16;
            this.butFail.Text = "取  消";
            this.butFail.Click += new System.EventHandler(this.butFail_Click);
            // 
            // txbName
            // 
            this.txbName.Location = new System.Drawing.Point(72, 22);
            this.txbName.Name = "txbName";
            this.txbName.Size = new System.Drawing.Size(100, 21);
            this.txbName.TabIndex = 17;
            // 
            // FrmAddConnection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(251, 93);
            this.Controls.Add(this.txbName);
            this.Controls.Add(this.butFail);
            this.Controls.Add(this.butAdd);
            this.Controls.Add(this.lblName);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmAddConnection";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "添加数据库连接";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox txbName;
    }
}