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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == "superkid200" && textBox2.Text == "youareanidiot.org")
            {
                frmEaster.Tries = 10;
                new frmAdmin().Show();
                Close();
            }
            else
            {
                frmEaster.Tries--;
                if(frmEaster.Tries == 1)
                {
                    MessageBox.Show("There is only one try left.", "Incorrect username or password", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if(frmEaster.Tries == 0)
                {
                    MessageBox.Show("No tries left.", "Incorrect username or password", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Close();
                }
                else
                {
                    MessageBox.Show("Incorrect username or password", "Incorrect username or password", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            if (frmEaster.Tries == 0)
            {
                MessageBox.Show("You have entered the incorrect username or password too many times. Admin panel is blocked.", "Admin panel is locked", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }
    }
}
