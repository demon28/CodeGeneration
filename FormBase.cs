namespace CodeGeneration
{
    using DevComponents.DotNetBar;
    using System;
    using System.ComponentModel;
    using System.Windows.Forms;

    public partial class FormBase : Office2007Form
    {
        public FormBase()
        {
            this.InitializeComponent();
        }

        public DialogResult Alert(string text)
        {
            return MessageBoxEx.Show(text);
        }

        public DialogResult Alert(string text, string caption)
        {
            return MessageBoxEx.Show(text, caption);
        }

        public DialogResult Alert(string text, string caption, MessageBoxButtons buttons)
        {
            return MessageBoxEx.Show(text, caption, buttons);
        }

        public DialogResult Alert(string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon)
        {
            return MessageBoxEx.Show(text, caption, buttons, icon);
        }

        public DialogResult Alert(string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defaultButton)
        {
            return MessageBoxEx.Show(text, caption, buttons, icon, defaultButton);
        }

    }
}

