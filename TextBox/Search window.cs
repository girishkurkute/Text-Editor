using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextBox
{

    
    public partial class Search_window : Form
    {
        string tempBuffer = string.Empty;
        public Search_window()
        {
            InitializeComponent();
            Form1 frm = new Form1();
            frm = (Form1)Application.OpenForms["Form1"];
            tempBuffer = frm.richTextBox1.Text;
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm = (Form1)Application.OpenForms["Form1"];
            tempBuffer = frm.richTextBox1.Text;
            int index = 0;
            string temp = frm.richTextBox1.Text;
            frm.richTextBox1.Text = "";
            frm.richTextBox1.Text = temp;
           // int lineNo = Convert.ToInt32(txtLine.Text);
            //int lineIndex = 0;


            //lineIndex = frm.richTextBox1.GetLineFromCharIndex(frm.richTextBox1.GetCharIndexFromPosition(new Point(0, 0)));
            //index = frm.richTextBox1.GetCharIndexFromPosition(new Point(0, 0));

            //int firstcharindex = frm.richTextBox1.GetFirstCharIndexFromLine(lineIndex);
            ////index = firstVisibleChar;
            //int endlineIndex = lineIndex + lineNo;

            //int lastcharindex = frm.richTextBox1.GetFirstCharIndexFromLine(endlineIndex);

            //int lastLineLength = frm.richTextBox1.Lines[endlineIndex].Length;
            //lastcharindex = lastcharindex+lastLineLength;

            while (index < frm.richTextBox1.Text.LastIndexOf(txtSearch.Text))
            {
                frm.richTextBox1.Find(txtSearch.Text, index, frm.richTextBox1.TextLength, RichTextBoxFinds.None);
                frm.richTextBox1.SelectionBackColor = Color.Yellow;
                index = frm.richTextBox1.Text.IndexOf(txtSearch.Text, index) + 1;
            }



            //this.Close();
            frm.Show();
        }

        private void btnReplace_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm = (Form1)Application.OpenForms["Form1"];

            int i;
            for ( i = 0; i < frm.richTextBox1.Lines.Count(); i++)
            {
                while (frm.richTextBox1.Text.Contains(txtSearch.Text))
                    frm.richTextBox1.Text = frm.richTextBox1.Text.Replace(txtSearch.Text, txtReplace.Text);
            }
            tempBuffer = frm.richTextBox1.Text;
            frm.Show();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void Search_window_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form1 fm = new Form1();
            fm = (Form1)Application.OpenForms["Form1"];
            fm.richTextBox1.Text = tempBuffer;
            fm.Show();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
