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
    public partial class frmEaster : Form
    {
        public static int Tries = 10;

        public static frmEaster Current;
        public frmEaster()
        {
            InitializeComponent();
            Current = this;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("\"If you insist?\" What a silly question!", "Useless!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        int index = 0;

        private void Image_DoubleClick(object sender, EventArgs e)
        {
            foreach(var form in Application.OpenForms)
            {
                if(form is frmAdmin || form is frmLogin)
                {
                    MessageBox.Show("Why do you want more easter eggs?", "No more easter eggs!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            new frmLogin().Show();
        }

        private void Easter()
        {
            string[] text = {"Don't you remember that this button is called \"Useless button\"?", "Stop it!", "WTF?", "You are gay!", "Don't try clicking me again!"
            ,"\"superkid200\" will be angry!!!", "My job is to annoy people. Now, stop clicking me please!", "Password is not superkid200", "Stop clicking!", "THAT'S TOO MUCH FOR ME!!!"};
            MessageBox.Show(text[index], "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            index++;
            if (index == text.Length)
            {
                new frmAccess().ShowDialog();
                button1.Enabled = false;
                MessageBox.Show("Easter egg 2 (last easter egg): Double click on the 'Idiot' image.", "Easter egg is near you!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                pictureBox1.DoubleClick += Image_DoubleClick;
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Easter();
        }
        private void FrmEaster_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
        }

        private async void FrmEaster_Load(object sender, EventArgs e)
        {
            await Task.Delay(10000);
            MessageBox.Show("Easter egg 1: Strike 10 times.", "Easter egg is near you!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            button1.Click += Button1_Click;
        }
    }
}
