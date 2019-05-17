using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YOUFuck
{
    public partial class frmAccess : Form
    {
        public frmAccess()
        {
            InitializeComponent();
        }
        bool trusted = false;

        private void FrmAccess_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = !trusted;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == "superkid200")
            {
                trusted = true;
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("Incorrect password", "Incorrect password", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
