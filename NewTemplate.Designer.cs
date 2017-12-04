namespace CodeGeneration
{
    partial class NewTemplate
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
            this.butFail = new DevComponents.DotNetBar.ButtonX();
            this.butAdd = new DevComponents.DotNetBar.ButtonX();
            this.txbName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblName = new DevComponents.DotNetBar.LabelX();
            this.SuspendLayout();
            // 
            // butFail
            // 
            this.butFail.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.butFail.ForeColor = System.Drawing.SystemColors.InfoText;
            this.butFail.Location = new System.Drawing.Point(214, 46);
            this.butFail.Name = "butFail";
            this.butFail.Size = new System.Drawing.Size(75, 23);
            this.butFail.TabIndex = 20;
            this.butFail.Text = "取  消";
            this.butFail.Click += new System.EventHandler(this.butFail_Click);
            // 
            // butAdd
            // 
            this.butAdd.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.butAdd.ForeColor = System.Drawing.SystemColors.InfoText;
            this.butAdd.Location = new System.Drawing.Point(88, 46);
            this.butAdd.Name = "butAdd";
            this.butAdd.Size = new System.Drawing.Size(75, 23);
            this.butAdd.TabIndex = 19;
            this.butAdd.Text = "添  加";
            this.butAdd.Click += new System.EventHandler(this.butAdd_Click);
            // 
            // txbName
            // 
            this.txbName.Location = new System.Drawing.Point(72, 19);
            this.txbName.Name = "txbName";
            this.txbName.Size = new System.Drawing.Size(306, 21);
            this.txbName.TabIndex = 18;
            this.txbName.Text = "NewTemplate.template";
            // 
            // lblName
            // 
            this.lblName.BackColor = System.Drawing.Color.Transparent;
            this.lblName.Location = new System.Drawing.Point(12, 19);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(78, 23);
            this.lblName.TabIndex = 17;
            this.lblName.Text = "链接名称：";
            // 
            // NewTemplate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(387, 97);
            this.Controls.Add(this.butFail);
            this.Controls.Add(this.butAdd);
            this.Controls.Add(this.txbName);
            this.Controls.Add(this.lblName);
            this.Name = "NewTemplate";
            this.Text = "NewTemplate";
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.ButtonX butFail;
        private DevComponents.DotNetBar.ButtonX butAdd;
        private DevComponents.DotNetBar.Controls.TextBoxX txbName;
        private DevComponents.DotNetBar.LabelX lblName;
    }
}