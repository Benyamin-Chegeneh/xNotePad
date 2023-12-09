using System;
using System.IO;
using System.Windows.Forms;

namespace xNotePad
{
    public partial class frm_Main : Form
    {
        public frm_Main()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void newFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(txt_note.Text != "")
            {
                if(MessageBox.Show("Do you want to create a new page ?","New File",MessageBoxButtons.YesNo,MessageBoxIcon.Warning,MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    txt_note.Text = null;
                }
                else {}
            }
        }

        private void openFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (OFD.ShowDialog() != DialogResult.Cancel)
            {
                StreamReader SR = File.OpenText(OFD.FileName);
                txt_note.Text = SR.ReadToEnd();
                SR.Close();
            }
        }

        private void saveFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SFD.ShowDialog() != DialogResult.Cancel)
            {
                StreamWriter SW = File.CreateText(SFD.FileName);
                SW.Write(txt_note.Text);
                SW.Close();
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (txt_note.Text != "")
            {
                if (MessageBox.Show("Do you want to exit ?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    Application.Exit();
                }
                else { }
            }
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txt_note.Undo();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txt_note.Cut();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txt_note.Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txt_note.Paste();
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(fontDialog1.ShowDialog() != DialogResult.Cancel)
            {
                txt_note.Font = fontDialog1.Font;
            }
        }
        private void wordWrapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (wordWrapToolStripMenuItem.Checked)
            {
                txt_note.WordWrap = true;
            }
            else
            {
                txt_note.WordWrap = false;
                txt_note.ScrollBars = ScrollBars.Both;
            }
        }

        private void checkForUpdateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/Benyamin-Chegeneh/xNotePad");
        }
    }
}