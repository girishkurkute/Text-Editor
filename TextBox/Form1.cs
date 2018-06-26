using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Collections;
using System.IO;

namespace TextBox
{
    public partial class Form1 : Form
    {
        int i = 0;
        int j = 0;
        int k = 0;
        int y = 0;
        long file_size;
        string infoline = string.Empty;
        public Form1()
        {
            InitializeComponent();
            label2.Text = string.Empty;
            lblPath.Text = string.Empty;
            //richTextBox1.KeyPress += new KeyEventHandler(richTextBox1_KeyPress);
        }

        //private void richTextBox1_TextChanged_1(object sender, EventArgs e)
        //{
        //    //MessageBox.Show("Hi");



        //}
        private void txtCmd_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string selectedCmd = string.Empty;
                selectedCmd = txtCmd.Text;
                if (selectedCmd.Equals("Save"))
                {
                    string temp = string.Empty;
                    int no_lines = richTextBox1.Lines.Length;
                    System.IO.StreamWriter filew = new System.IO.StreamWriter(lblPath.Text);
                    int length = 0;
                    for (j = 0; j < no_lines; j++)
                    {

                        temp = richTextBox1.Lines[j];

                        length = temp.Length;
                        int countEQ = 0;
                        int countSpace = 0;
                        for (i = 0; i < length; i++)
                        {
                            if (countEQ == 4 && countSpace == 1)
                            { break; }
                            if (temp[i] == '=')
                            {
                                temp = temp.Remove(i, 1);
                                i--;
                                countEQ++;

                            }
                            else if (temp[i] == ' ')
                            {
                                temp = temp.Remove(i, 1);
                                i--;
                                countSpace++;
                            }
                            else
                            {
                                temp = temp.Remove(i, 1);
                                i--;
                            }

                        }
                        filew.WriteLine(temp);

                    }

                    filew.Close();
                    txtCmd.Text = string.Empty;
                }
                else if (selectedCmd.Equals("Save as"))
                {
                    SaveFileDialog sfa = new SaveFileDialog();
                    sfa.Filter = "Text Files|*.txt|Rich Text Files|*.rtf";
                    sfa.Title = "Save As";
                    sfa.ShowDialog();

                    string temp = string.Empty;
                    int no_lines = richTextBox1.Lines.Length;
                    System.IO.StreamWriter filew = new System.IO.StreamWriter(sfa.FileName);
                    int length = 0;
                    for (j = 0; j < no_lines; j++)
                    {

                        temp = richTextBox1.Lines[j];

                        length = temp.Length;
                        int countEQ = 0;
                        int countSpace = 0;
                        for (i = 0; i < length; i++)
                        {
                            if (countEQ == 4 && countSpace == 1)
                            { break; }
                            if (temp[i] == '=')
                            {
                                temp = temp.Remove(i, 1);
                                i--;
                                countEQ++;

                            }
                            else if (temp[i] == ' ')
                            {
                                temp = temp.Remove(i, 1);
                                i--;
                                countSpace++;
                            }
                            else
                            {
                                temp = temp.Remove(i, 1);
                                i--;
                            }

                        }
                        filew.WriteLine(temp);

                    }

                    filew.Close();
                    txtCmd.Text = string.Empty;
                }
                else if (Char.IsDigit(selectedCmd[0]))
                {
                    int nofline = Convert.ToInt32(txtCmd.Text);
                    //richTextBox1.SelectionStart = richTextBox1.GetFirstCharIndexFromLine(nofline);
                    //richTextBox1.Focus();
                    richTextBox1.Select(richTextBox1.GetFirstCharIndexFromLine(nofline), richTextBox1.Lines.Count());
                    richTextBox1.ScrollToCaret();
                }
                else if (selectedCmd[0] == 'u')
                {
                    int linecount = 0;
                    string temp = string.Empty;
                    int i;
                    for (i = 1; i < selectedCmd.Length; i++)
                    {
                        temp = temp + selectedCmd[i];
                    }
                    linecount = Convert.ToInt32(temp);
                    int firstVisibleChar = richTextBox1.GetCharIndexFromPosition(new Point(0, 0));
                    int lineIndex = richTextBox1.GetLineFromCharIndex(firstVisibleChar);
                    int updatedlineIndex = lineIndex + 1 - linecount;                    
                    if (updatedlineIndex >= 0)
                    {
                        // string firstVisibleLine = richTextBox1.Lines[updatedlineIndex];
                        //MessageBox.Show(firstVisibleLine);
                        richTextBox1.Select(richTextBox1.GetFirstCharIndexFromLine(updatedlineIndex), richTextBox1.Lines.Count());
                        richTextBox1.ScrollToCaret();
                    }
                    else
                    {
                        MessageBox.Show("Reaching top of view");
                        updatedlineIndex = 0;

                        richTextBox1.Select(richTextBox1.GetFirstCharIndexFromLine(updatedlineIndex), richTextBox1.Lines.Count());
                        richTextBox1.ScrollToCaret();
                    }
                }
                else if (selectedCmd[0] == 'd')
                {
                    int linecount = 0;
                    string temp = string.Empty;
                    int i;
                    for (i = 1; i < selectedCmd.Length; i++)
                    {
                        temp = temp + selectedCmd[i];
                    }
                    linecount = Convert.ToInt32(temp);
                    int firstVisibleChar = richTextBox1.GetCharIndexFromPosition(new Point(richTextBox1.ClientSize.Width, richTextBox1.ClientSize.Height));
                    int lineIndex = richTextBox1.GetLineFromCharIndex(firstVisibleChar);
                    int updatedlineIndex = lineIndex + linecount;
                    //if (updatedlineIndex >= richTextBox1.Lines.Length)
                    if (updatedlineIndex < richTextBox1.Lines.Count())
                    {
                        // string firstVisibleLine = richTextBox1.Lines[updatedlineIndex];
                        //MessageBox.Show(firstVisibleLine);
                        richTextBox1.Select(richTextBox1.GetFirstCharIndexFromLine(updatedlineIndex), richTextBox1.Lines.Count());
                        richTextBox1.ScrollToCaret();
                    }
                    else
                    {
                        MessageBox.Show("Reaching end of view");
                        updatedlineIndex = richTextBox1.Lines.Length - 1;

                        richTextBox1.Select(richTextBox1.GetFirstCharIndexFromLine(updatedlineIndex), richTextBox1.Lines.Count());
                        richTextBox1.ScrollToCaret();
                    }
                }
                else if (selectedCmd[0] == 'f')
                {
                    int firstVisibleChar = richTextBox1.GetCharIndexFromPosition(new Point(0, richTextBox1.ClientSize.Height));
                    int lineIndex = richTextBox1.GetLineFromCharIndex(firstVisibleChar);
                    //richTextBox1.Select(lineIndex, richTextBox1.Lines.Count());
                    int updatedindex = lineIndex;
                    if (updatedindex+2 < richTextBox1.Lines.Count())
                    {
                        updatedindex = lineIndex - 1;
                        richTextBox1.Select(richTextBox1.GetFirstCharIndexFromLine(updatedindex), richTextBox1.Lines.Count());
                        richTextBox1.ScrollToCaret();
                    }
                    else
                    {

                        MessageBox.Show("Reaching end of view");
                        updatedindex = richTextBox1.Lines.Length - 1;
                        richTextBox1.Select(richTextBox1.GetFirstCharIndexFromLine(updatedindex), richTextBox1.Lines.Count());
                        richTextBox1.ScrollToCaret();
                    }
                   
                }
                else if (selectedCmd[0] == 'b')
                {
                    int firstVisibleChar = richTextBox1.GetCharIndexFromPosition(new Point(0, 0));
                    int lineIndex = richTextBox1.GetLineFromCharIndex(firstVisibleChar);
                    int lastVisibleChar = richTextBox1.GetCharIndexFromPosition(new Point(0, richTextBox1.ClientSize.Height));
                    int lastLineIndex= richTextBox1.GetLineFromCharIndex(lastVisibleChar);
                    int diff = (lastLineIndex) - (lineIndex);
                    int updatedlineIndex = (lineIndex - diff) + 2;

                    if (updatedlineIndex >= 0)
                    {
                        //richTextBox1.Select(lineIndex, richTextBox1.Lines.Count());
                        richTextBox1.Select(richTextBox1.GetFirstCharIndexFromLine(updatedlineIndex), richTextBox1.Lines.Count());
                        richTextBox1.ScrollToCaret();
                    }
                    else
                    {
                        MessageBox.Show("Reaching top of view");
                        updatedlineIndex = 0;
                        richTextBox1.Select(richTextBox1.GetFirstCharIndexFromLine(updatedlineIndex), richTextBox1.Lines.Count());
                        richTextBox1.ScrollToCaret();

                    }

                }
                else if (selectedCmd.Contains("Setcl"))
                {
                    int linecount = 0;
                    string temp = string.Empty;
                    int i;
                    for (i = 5; i < selectedCmd.Length; i++)
                    {
                        temp = temp + selectedCmd[i];
                    }
                    linecount = Convert.ToInt32(temp);

                    int firstVisibleChar = richTextBox1.GetCharIndexFromPosition(new Point(0, 0));
                    int startingClientLine = richTextBox1.GetLineFromCharIndex(firstVisibleChar);
                   // string setClCommand = CommandBox.Text;
                    //string[] temp = setClCommand.Split(' ');
                    int linenumber = linecount + startingClientLine;
                    richTextBox1.SelectionStart = richTextBox1.GetFirstCharIndexFromLine(linenumber);
                    richTextBox1.Focus();
                }
                else if (selectedCmd.Equals("h"))
                {
                    Help h = new Help();
                    h.Show();
                }
                else if(selectedCmd[0] == 's')
                {
                    string searchTerm = string.Empty;
                    int no_of_lines;
                    string[] words = selectedCmd.Split('/');
                    selectedCmd = words[0].ToString();
                    searchTerm = words[1].ToString();
                    no_of_lines = Convert.ToInt32(words[2]);


                    int index = 0;
                    string temp = "";
                    ArrayList a = new ArrayList();
                    for (int i = 0; i < no_of_lines; i++)
                    {
                        a.Add(richTextBox1.Lines[i]);
                    }
                    foreach (var item in a)
                    {
                        temp = temp + item.ToString();
                    }


                    while (index < temp.LastIndexOf(searchTerm))
                    {
                        richTextBox1.Find(searchTerm, index, temp.Length, RichTextBoxFinds.None);
                        richTextBox1.SelectionBackColor = Color.Yellow;
                        index = temp.IndexOf(searchTerm, index) + 1;
                    }
                }
                else
                {
                    MessageBox.Show("Invalid command");
                }

                txtCmd.Text = string.Empty;
            }
        }

        private void richTextBox1_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            int currLine;
            //string command = string.Empty;
            int position = (richTextBox1.SelectionStart);
            int column = (richTextBox1.GetFirstCharIndexOfCurrentLine());
            int column_number = (position - column);
            int line_number = richTextBox1.GetLineFromCharIndex(richTextBox1.SelectionStart);
            label2.Text = infoline + "  Line = " + (line_number ) + "    " + "Column = " + column_number + "    ";

            if (e.KeyCode == Keys.Enter)
            {
                //MessageBox.Show("Hi");
                currLine = richTextBox1.GetLineFromCharIndex(richTextBox1.SelectionStart);
                ArrayList arrList2 = new ArrayList();
                ArrayList copyList = new ArrayList();
                ArrayList tempremaincopyList = new ArrayList();

                int no_lines = richTextBox1.Lines.Length;

                int count = 0;
                string temp;
                char c = '\0', c2 = '\0';
                int length;
                string parm2 = string.Empty;
                string tempStr = string.Empty;
                //temp = richTextBox1.Lines[currLine];
                string[,] Command = new string[2, 4];
                y = 0;
                //reading text editor and extracting commands
                for (j = 0; j < no_lines; j++)
                {
                    string temps;
                    temp = richTextBox1.Lines[j];
                    int flag = 0;
                    for (i = 0; i < temp.Length; i++)
                    {
                        if (temp[i] == ' ')
                        {
                            if (flag == 1)
                            {
                                Command[y, 1] = j.ToString();
                                y++;
                            }
                            break;
                        }
                        else if (temp[i] == '=')
                        {
                            continue;
                        }
                        else
                        {
                            Command[y, 0] = Command[y, 0] + temp[i];

                            flag = 1;

                        }


                    }
                }

                if (string.IsNullOrEmpty(Command[0, 0]))
                {

                    MessageBox.Show("Invalid command");

                }
                else
                {
                    //    MessageBox.Show("Invalid 2nd command");
                    //}

                    y = 0;
                    //removing command from prefix
                    for (j = 0; j < no_lines; j++)
                    {
                        string temps;
                        //    string append;
                        temps = richTextBox1.Lines[j];

                        //    char c = temp[0];
                        //    //if(temp[0]=='='&& temp[1] == '=' && temp[2] == '=' && temp[3] == '=')
                        //    //{
                        //    //    MessageBox.Show(c.ToString());
                        if (j == Convert.ToInt32(Command[y, 1]))
                        {
                            length = temps.Length;
                            int countEQ = 0;
                            for (i = 0; i < length; i++)
                            {
                                if (temps[i] == '=')
                                {
                                    countEQ++;

                                }
                                else
                                {
                                    temps = temps.Remove(i, 1);
                                    i--;
                                }
                                if (countEQ == 3)
                                { break; }
                            }
                            arrList2.Add(temps);
                            y++;
                            if (y == 2)
                            { y = 1; }
                        }
                        else { arrList2.Add(temps); }

                        //    //}
                        //    //else
                        //    //{
                        //    //    append = "==== " + temp;
                        //    //    arrList2.Add(append);
                        //    //}

                    }
                    //c = Command[1,2];

                    for (j = 0; j < 2; j++)
                    {
                        string tempf = string.Empty;
                        tempf = Command[j, 0];
                        if (!string.IsNullOrEmpty(tempf))
                        {
                            Command[j, 2] = tempf[0].ToString();
                            length = tempf.Length;
                            for (i = 1; i < length; i++)
                            {
                                Command[j, 3] = Command[j, 3] + tempf[i];
                            }
                        }
                    }
                    if (!string.IsNullOrEmpty(parm2))
                    { count = Convert.ToInt32(parm2); }
                    string cmd = Command[0, 2];
                    c = cmd[0];
                    string cmd2 = Command[1, 2];
                    if (!string.IsNullOrEmpty(cmd2))
                    { c2 = cmd2[0]; }
                    if ((c == 'c' && (c2 == 'a' || c2 == 'b')) || ((c == 'a' || c == 'b') && c2 == 'c'))
                    {
                        //adding no of lines 
                        int cmdlinec = 0, cmdlinea = 0, nolinestocopy = 0;
                        if (c == 'c')
                        {

                            cmdlinec = Convert.ToInt32(Command[0, 1]);
                            cmdlinea = Convert.ToInt32(Command[1, 1]);
                            nolinestocopy = Convert.ToInt32(Command[0, 3]);
                        }
                        else if (c == 'a' || c == 'b')
                        {
                            //string cmd2 = Command[1, 2];
                            //c2 = cmd2[0];
                            cmdlinec = Convert.ToInt32(Command[1, 1]);
                            cmdlinea = Convert.ToInt32(Command[0, 1]);
                            nolinestocopy = Convert.ToInt32(Command[1, 3]);
                        }
                        int counter = 0;
                        int flag = 0;
                        int flagc = 0;
                        int copyListCount = 0;
                        foreach (var item in arrList2)
                        {
                            if (counter == cmdlinec)
                            { flag = 1; }
                            if (flag == 1 && copyList.Count < nolinestocopy)
                            {
                                copyList.Add(item);
                            }
                            if (copyList.Count == nolinestocopy)
                            { flag = 0; }
                            //    if(counter == cmdlinea+1)
                            //    { flagc = 1; }
                            //    if(flagc==1)
                            //    { tempremaincopyList.Add(item); }
                            counter++;
                        }
                        if (c == 'a' || c2 == 'a')
                            i = 1;
                        else if (c == 'b' || c2 == 'b')
                            i = 0;

                        foreach (var item in copyList)
                        {
                            arrList2.Insert(cmdlinea + i, item);
                            i++;
                        }

                    }
                    else if (c == 'i')
                    {
                        for (k = 1; k <= Convert.ToInt32(Command[0, 3]); k++)
                        { arrList2.Insert(currLine + k, "==== "); }

                    }
                    else if ((c == 'm' && (c2 == 'a' || c2 == 'b')) || ((c == 'a' || c == 'b') && c2 == 'm'))
                    {
                        int cmdlinem = 0, cmdlinea = 0, nolinestocopy = 0;
                        if (c == 'm')
                        {
                            //string cmd2 = Command[1, 2];
                            //c2 = cmd2[0];
                            cmdlinem = Convert.ToInt32(Command[0, 1]);
                            cmdlinea = Convert.ToInt32(Command[1, 1]);
                            nolinestocopy = Convert.ToInt32(Command[0, 3]);
                        }
                        else if (c == 'a' || c == 'b')
                        {
                            //string cmd2 = Command[1, 2];
                            //c2 = cmd2[0];
                            cmdlinem = Convert.ToInt32(Command[1, 1]);
                            cmdlinea = Convert.ToInt32(Command[0, 1]);
                            nolinestocopy = Convert.ToInt32(Command[1, 3]);
                        }
                        int counter = 0;
                        int flag = 0;
                        int flagc = 0;
                        int copyListCount = 0;
                        foreach (var item in arrList2)
                        {
                            if (counter == cmdlinem)
                            { flag = 1; }
                            if (flag == 1 && copyList.Count < nolinestocopy)
                            {
                                copyList.Add(item);
                            }
                            if (copyList.Count == nolinestocopy)
                            { flag = 0; }
                            //    if(counter == cmdlinea+1)
                            //    { flagc = 1; }
                            //    if(flagc==1)
                            //    { tempremaincopyList.Add(item); }
                            counter++;
                        }
                        if (c == 'a' || c2 == 'a')
                            i = 1;
                        else if (c == 'b' || c2 == 'b')
                            i = 0;

                        foreach (var item in copyList)
                        {
                            arrList2.Insert(cmdlinea + i, item);
                            i++;
                        }
                        //removing lines
                        if (cmdlinem < cmdlinea)
                        { arrList2.RemoveRange(cmdlinem, nolinestocopy); }
                        else if (cmdlinem > cmdlinea)
                        {
                            arrList2.RemoveRange(cmdlinem + nolinestocopy, nolinestocopy);
                        }


                    }
                    else if (c == '"')
                    {
                        int p = 0;
                        string dummy = string.Empty;
                        foreach (var item in arrList2)
                        {

                            if (p == currLine)
                            {
                                dummy = item.ToString();
                            }
                            p++;
                        }
                        arrList2.Insert(currLine + 1, dummy);

                    }

                    richTextBox1.Clear();
                    foreach (var item in arrList2)
                    {

                        richTextBox1.AppendText(item.ToString());
                        richTextBox1.AppendText("\n");
                    }

                }

            }

        }
        private void button1_Click(object sender, EventArgs e)
        {
            

        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.AppendText("==== Start of File\n");
            richTextBox1.AppendText("==== \n");
            richTextBox1.AppendText("==== End of File");
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            label2.Text = string.Empty;
            lblPath.Text = string.Empty;
            OpenFileDialog FD = new OpenFileDialog();
            FD.DefaultExt = ".txt";
            FD.Filter = "Text Document (.txt)|*.txt| Rich Text Document (.rtf)|*.rtf";
            if (FD.ShowDialog() == DialogResult.OK)
            {
                String FileName = FD.FileName;
                // textBox1.Text = FileName;
                FileInfo FI = new FileInfo(FileName);
                file_size = FI.Length;
                infoline = FileName + "  Size =" + file_size.ToString();
                string line;
                string number;
                int count = 0;
                int linecount = 0;
                string append;
                System.IO.StreamReader file = new System.IO.StreamReader(FileName.ToString());
                ArrayList arrList = new ArrayList();
                while ((line = file.ReadLine()) != null)
                {

                    count++;
                    //ArrayList tempNumSplit = new ArrayList();                    
                    arrList.Add(line);
                }
                //richTextBox1.Lines = arrList.ToArray();
                richTextBox1.Clear();

                foreach (var item in arrList)
                {
                    richTextBox1.AppendText("==== ");
                    richTextBox1.AppendText(item.ToString());
                    richTextBox1.AppendText("\n");
                }

                //  label2.Text="File:"+
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string temp = string.Empty;
            int no_lines = richTextBox1.Lines.Length;
            System.IO.StreamWriter filew = new System.IO.StreamWriter(lblPath.Text);
            int length = 0;
            for (j = 0; j < no_lines; j++)
            {
                
                temp = richTextBox1.Lines[j];

                length = temp.Length;
                int countEQ = 0;
                int countSpace = 0;
                for (i = 0; i < length; i++)
                {
                    if (countEQ == 4 && countSpace==1)
                    { break; }
                    if (temp[i] == '=')
                    {
                        temp = temp.Remove(i, 1);
                        i--;
                        countEQ++;

                    }
                    else if(temp[i] == ' ')
                    {
                        temp = temp.Remove(i, 1);
                        i--;
                        countSpace++;
                    }
                    else
                    {
                        temp = temp.Remove(i, 1);
                        i--;
                    }
                   
                }
                filew.WriteLine(temp);

            }
               
            filew.Close();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfa = new SaveFileDialog();
            sfa.Filter = "Text Files|*.txt|Rich Text Files|*.rtf";
            sfa.Title = "Save As";
            sfa.ShowDialog();

            string temp = string.Empty;
            int no_lines = richTextBox1.Lines.Length;
            System.IO.StreamWriter filew = new System.IO.StreamWriter(sfa.FileName);
            int length = 0;
            for (j = 0; j < no_lines; j++)
            {

                temp = richTextBox1.Lines[j];

                length = temp.Length;
                int countEQ = 0;
                int countSpace = 0;
                for (i = 0; i < length; i++)
                {
                    if (countEQ == 4 && countSpace == 1)
                    { break; }
                    if (temp[i] == '=')
                    {
                        temp = temp.Remove(i, 1);
                        i--;
                        countEQ++;

                    }
                    else if (temp[i] == ' ')
                    {
                        temp = temp.Remove(i, 1);
                        i--;
                        countSpace++;
                    }
                    else
                    {
                        temp = temp.Remove(i, 1);
                        i--;
                    }

                }
                filew.WriteLine(temp);

            }

            filew.Close();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void openToolStripButton_Click(object sender, EventArgs e)
        {
            label2.Text = string.Empty;
            lblPath.Text = string.Empty;
            OpenFileDialog FD = new OpenFileDialog();
            FD.DefaultExt = ".txt";
            FD.Filter = "Text Document (.txt)|*.txt| Rich Text Document (.rtf)|*.rtf";
            if (FD.ShowDialog() == DialogResult.OK)
            {
                String FileName = FD.FileName;
                // textBox1.Text = FileName;
                FileInfo FI = new FileInfo(FileName);
                file_size = FI.Length;
                infoline = FileName + "  Size =" + file_size.ToString();
                string line;
                string number;
                int count = 0;
                int linecount = 0;
                string append;
                System.IO.StreamReader file = new System.IO.StreamReader(FileName.ToString());
                ArrayList arrList = new ArrayList();
                while ((line = file.ReadLine()) != null)
                {

                    count++;
                    //ArrayList tempNumSplit = new ArrayList();                    
                    arrList.Add(line);
                }
                //richTextBox1.Lines = arrList.ToArray();
                richTextBox1.Clear();

                foreach (var item in arrList)
                {
                    richTextBox1.AppendText("==== ");
                    richTextBox1.AppendText(item.ToString());
                    richTextBox1.AppendText("\n");
                }

              //  label2.Text="File:"+
            }
        }

    

        private void searchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Search_window sw = new Search_window();
            sw.Show();
        }

        private void richTextBox1_Click(object sender, EventArgs e)
        {
            int position = (richTextBox1.SelectionStart);
            int column = (richTextBox1.GetFirstCharIndexOfCurrentLine());
            int column_number = (position - column);
            int line_number = richTextBox1.GetLineFromCharIndex(richTextBox1.SelectionStart);
            label2.Text =infoline + "  Line = " + (line_number+1) + "    " + "Column = " + column_number + "    " ;
        }

        private void newToolStripButton_Click(object sender, EventArgs e)
        {
            richTextBox1.AppendText("==== Start of File\n");
            richTextBox1.AppendText("==== \n");
            richTextBox1.AppendText("==== End of File");
        }

        private void helpToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Help h = new Help();
            h.Show();
        }
    }
}
