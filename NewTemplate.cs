using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace CodeGeneration
{
    public partial class NewTemplate : Form
    {
        public NewTemplate()
        {
            InitializeComponent();
        }
        public bool IsSccess;
        private void butFail_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void butAdd_Click(object sender, EventArgs e)
        {
            string path = Application.StartupPath + @"\CodeTemplate\";
            File.Copy(path + "template.template", path + txbName.Text);
            IsSccess = true;
        }
    }
}
