using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace CodeGeneration.UserControls
{
    public partial class TextBoxSEO : TextBox
    {

        //private System.ComponentModel.Container components = null;
        private System.Windows.Forms.ListBox m_lstShowChoice = null;
        public delegate void EnterKey();
        public event EnterKey EnterKeyEvent;
        public TextBoxSEO()
        {
            this.Leave += new EventHandler(TextBoxExt_Leave);
            this.KeyDown += new KeyEventHandler(TextBoxExt_KeyDown);
            this.KeyUp += new KeyEventHandler(TextBoxExt_KeyUp);
            this.DoubleClick += new EventHandler(TextBoxExt_DoubleClick);
        }
        private void lstBox_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            ListBox box = (ListBox)sender;
            if ((box.SelectedIndex > -1) && !this.ReadOnly)
            {

                this.Text = box.SelectedItem.ToString();
                //选择后文本框失去了焦点，这里移回来
                this.Focus();
            }
        }
        private void lstBox_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {

            ListBox box = (ListBox)sender;
            Point pt = new Point(e.X, e.Y);
            int n = box.IndexFromPoint(pt);
            if (n >= 0)
                box.SelectedIndex = n;

        }

        #region 设置提示框的背景

        private Color m_lstForColor = System.Drawing.SystemColors.InfoText;
        private Color m_lstBackColor = System.Drawing.SystemColors.InfoText;

        /// <summary>

        /// 设置/获取提示的背景色

        /// </summary>

        public Color PromptForeColor
        {

            get
            {

                return m_lstForColor;

            }

            set
            {

                m_lstForColor = value;

                //lstPrompt的创建见下面的代码

                ListBox box = this.lstPrompt;

                if (box != null)

                    box.BackColor = m_lstForColor;

            }

        }
        public Color PromptBackColor
        {

            get
            {

                return m_lstBackColor;

            }

            set
            {

                m_lstBackColor = value;

                //lstPrompt的创建见下面的代码

                ListBox box = this.lstPrompt;

                if (box != null)

                    box.BackColor = m_lstBackColor;

            }

        }
        #endregion
        public System.Windows.Forms.ListBox lstPrompt
        {
            get
            {
                //如果没有列表用于显示提示的列表框，则创建一个

                if ((m_lstShowChoice == null) && this.Parent != null && this.Location.X > 0)
                {
                    m_lstShowChoice = new ListBox();
                    m_lstShowChoice.Visible = false;
                    //m_lstShowChoice.Left = this.Left;
                    //m_lstShowChoice.Top = this.Bottom;
                    m_lstShowChoice.Location = new Point(this.Location.X, this.Location.Y + this.Height);
                    m_lstShowChoice.Width = this.Width;
                    m_lstShowChoice.TabStop = false;
                    m_lstShowChoice.Sorted = true;
                    m_lstShowChoice.ForeColor = this.m_lstForColor; //前景
                    m_lstShowChoice.BackColor = this.m_lstBackColor; //背景（参见m_lstForColor的创建
                    m_lstShowChoice.BorderStyle = BorderStyle.FixedSingle;

                    //如果提示框过低，则显示到上面
                    if (m_lstShowChoice.Bottom > this.Parent.Height)
                        m_lstShowChoice.Top = this.Top - m_lstShowChoice.Height + 8;
                    m_lstShowChoice.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lstBox_MouseUp);
                    m_lstShowChoice.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lstBox_MouseMove);

                    this.Parent.Controls.Add(m_lstShowChoice);
                    this.Parent.ResumeLayout(false);
                    m_lstShowChoice.BringToFront();

                }
                return m_lstShowChoice;
            }
        }
        private ArrayList m_ForChoice = new ArrayList();
        public ArrayList ChoiceArray
        {
            get
            {
                return m_ForChoice;
            }
            set
            {
                m_ForChoice = (ArrayList)(value.Clone());
                ListBox box = this.lstPrompt;
                if (box != null)
                {
                    box.Items.Clear();
                    box.Items.AddRange(m_ForChoice.ToArray());
                }
            }
        }
        private bool m_AllowSpace = false;

        public bool AllowSpace
        {
            get
            {
                return m_AllowSpace;
            }
            set
            {
                m_AllowSpace = value;
            }

        }
        private bool m_bChoiceOnly = false;
        public bool ChoicOnly
        {
            get
            {
                return this.m_bChoiceOnly;
            }
            set
            {
                this.m_bChoiceOnly = value;
            }
        }
        private int m_nOldPos = 0;

        private bool bKeyDown = false;

        private string m_strOldText = "";
        private void TextBoxExt_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            m_nOldPos = this.SelectionStart;
            bKeyDown = true;
            m_strOldText = this.Text;
        }

        private void FillPrompt(string p_strText)
        {
            ListBox box = this.lstPrompt;
            if (box != null)
            {
                box.Items.Clear();
                if (p_strText.Length == 0)//没有内容，显示全部
                    box.Items.AddRange(this.ChoiceArray.ToArray());
                else
                {
                    foreach (string s in this.ChoiceArray)
                    {
                        if (s.ToLower().IndexOf(p_strText.ToLower()) >= 0)
                            box.Items.Add(s);

                    }
                }
            }
        }
        private void TextBoxExt_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {

            if (!bKeyDown)//忽略掉多余的KeyUp事件
                return;
            if (ChoiceArray == null || ChoiceArray.Count <= 0)
                return;
            bKeyDown = false;
            ListBox box = this.lstPrompt;
            switch (e.KeyCode)
            {
                //通过上下箭头在待选框中移动
                case System.Windows.Forms.Keys.Up:
                case System.Windows.Forms.Keys.Down:
                    if ((box != null) && !this.Multiline)//多行文本通过上下箭头在两行之间移动
                    {
                        if ((e.KeyCode == System.Windows.Forms.Keys.Up) && (box.SelectedIndex > -1))//↑
                            box.SelectedIndex--;
                        else if ((e.KeyCode == System.Windows.Forms.Keys.Down) && (box.SelectedIndex < box.Items.Count - 1))//↑
                            box.SelectedIndex++;

                        //上下箭头不能移动当前光标，因此，还原原来位置
                        this.SelectionStart = m_nOldPos;
                        //显示提示框
                        if (!box.Visible)
                        {
                            if (box.Width != this.Width)
                                box.Width = this.Width;
                            box.Visible = true;
                        }
                    }
                    return;
                case System.Windows.Forms.Keys.Escape://ESC隐藏提示
                    if ((box != null) && box.Visible)
                        box.Hide();
                    break;

                case System.Windows.Forms.Keys.Return://回车选择一个或跳到下一控件
                    if ((box == null) || this.Multiline)
                        break;
                    //没有显示提示框时，移动到下一控件
                    if (!box.Visible)
                    {
                        SendKeys.Send("{TAB}");
                    }
                    else
                    { //有提示，关闭提示{
                        if (box.SelectedIndex > -1)//有选择，使用当前选择的内容
                            this.Text = box.SelectedItem.ToString();
                        this.SelectionStart = this.Text.Length;
                        this.SelectAll();
                        box.Hide();
                        if (EnterKeyEvent != null)
                            EnterKeyEvent();
                    }
                    break;
                default: //判断文本是否改变
                    string strText = this.Text;
                    //不允许产生空格，去掉文本中的空格
                    if (!this.AllowSpace)
                        strText = this.Text.Replace(" ", "");
                    int nStart = this.SelectionStart;

                    if (strText != m_strOldText)//文本有改变
                    {

                        //设置当前文本和键盘光标位置
                        this.Text = strText;
                        if (nStart > this.Text.Length)
                            nStart = this.Text.Length;
                        this.SelectionStart = nStart;

                        //修改可供选择的内容,并显示供选择的列表框
                        if (box != null)
                        {
                            FillPrompt(strText);
                            if (!box.Visible)
                            {
                                if (box.Width != this.Width)
                                    box.Width = this.Width;
                                box.Visible = true;

                            }
                        }
                    }
                    break;
            }
            if (box.Items.Count > 0)
                box.SelectedIndex = 0;
        }
        private void TextBoxExt_Leave(object sender, EventArgs e)
        {

            //对于只选字段,必须输入同待选相匹配的值
            if (this.ChoicOnly)
            {
                int nIndex = this.ChoiceArray.IndexOf(this.Text);
                if (nIndex < 0)
                    this.Text = "";
            }
            //失去焦点后，必须隐藏提示
            ListBox box = this.lstPrompt;
            if (box != null)
                box.Visible = false;
        }

        private void TextBoxExt_DoubleClick(object sender, EventArgs e)
        {
            if (this.ReadOnly)
                return;
            if (ChoiceArray == null || ChoiceArray.Count <= 0)
                return;
            ListBox box = this.lstPrompt;
            if ((box != null) && (!box.Visible))
            {
                if (box.Width != this.Width)
                    box.Width = this.Width;
                box.Visible = true;
            }
        }
    }
}
