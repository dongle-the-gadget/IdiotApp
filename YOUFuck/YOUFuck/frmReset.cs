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
    public partial class frmReset : Form
    {
        public frmReset()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if(!(textBox1.Text == Form1.Current.ResetCode))
            {
                Form1.Current.Tries--;
#pragma warning disable CS1690 // Accessing a member on a field of a marshal-by-reference class may cause a runtime exception
                label3.Text = Form1.Current.Tries > 1 ||
                    Form1.Current.Tries == 0 ? Form1.Current.Tries.ToString() + " tries left" :
                    Form1.Current.Tries.ToString() + " try left";
                if(Form1.Current.Tries > 1)
                {
                    MessageBox.Show("You have entered the incorrect code.",
                        "Incorrect code",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
                else if(Form1.Current.Tries > 0)
                {
                    MessageBox.Show("You have 1 try left, please close this tool if you don't know or remember the code.",
                        "Incorrect code",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
                else
                {
                    Form1.Current.resetTimeButton.Enabled = false;
                    MessageBox.Show("No tries left, I'm closing.",
                        "Incorrect code",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    Close();
                }
#pragma warning restore CS1690 // Accessing a member on a field of a marshal-by-reference class may cause a runtime exception
            }
            else
            {
                Form1.Current.timeLeft = 60 * 5;
                Form1.Current.progressBar1.Value = 0;
                Form1.Current.label3.Text = "5:00";
                Form1.Current.resetTimeButton.Enabled = false;
                Close();
            }
        }

        private void FrmReset_Load(object sender, EventArgs e)
        {
#pragma warning disable CS1690 // Accessing a member on a field of a marshal-by-reference class may cause a runtime exception
            label3.Text = Form1.Current.Tries > 1 ||
                Form1.Current.Tries == 0 ? Form1.Current.Tries.ToString() + " tries left" :
                Form1.Current.Tries.ToString() + " try left";
        }
    }
}
