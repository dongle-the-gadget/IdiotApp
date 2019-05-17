using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YOUFuck
{
    public partial class frmAdmin : Form
    {
        bool isTrusted = false;
        public frmAdmin()
        {
            InitializeComponent();
        }

        private void FrmAdmin_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = !isTrusted;
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            Label label = new Label();
            label.Text = "Label";
            label.Location = new Point(new Random().Next(0, frmEaster.Current.panel1.Width), new Random().Next(0, frmEaster.Current.panel1.Height));
            frmEaster.Current.panel1.Controls.Add(label);
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            Button label = new Button();
            label.Text = "Button";
            label.Location = new Point(new Random().Next(0, frmEaster.Current.panel1.Width), new Random().Next(0, frmEaster.Current.panel1.Height));
            frmEaster.Current.panel1.Controls.Add(label);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "JPEG|*.jpeg|JPG|*.jpg|PNG|*.png|BMP|*.bmp|GIF|*.gif";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    using (Stream stream = dialog.OpenFile())
                    {
                        frmEaster.Current.pictureBox1.Image = Image.FromStream(stream);
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
            }
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            frmEaster.Current.pictureBox1.SizeMode = StringToEnum.Convert<PictureBoxSizeMode>(comboBox1.SelectedItem.ToString());
        }

        private void FrmAdmin_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedItem = frmEaster.Current.pictureBox1.SizeMode.ToString();
            textBox1.Text = frmEaster.Current.label1.Text;
            textBox2.Text = frmEaster.Current.label2.Text;
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            isTrusted = true;
            Close();
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            frmEaster.Current.label1.Text = textBox1.Text;
        }

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {
            frmEaster.Current.label2.Text = textBox2.Text;
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            frmEaster.Current.panel1.Controls.Clear();
        }

        private void Button5_Click_1(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
