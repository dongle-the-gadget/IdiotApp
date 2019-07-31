using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YOUFuck
{
    public partial class Form1 : Form
    {
        public static Form1 Current;
        public int timeLeft = 60 * 5;
        bool isUnsafe = false;
        List<string> added = new List<string>();
        public Form1(bool startUnsafe)
        {
            isUnsafe = startUnsafe;
            InitializeComponent();
            Current = this;
        }

        private void Request()
        {
            try
            {
                Process proc = new Process();
                proc.StartInfo.FileName = Application.ExecutablePath;
                proc.StartInfo.Arguments = "/fuck";
                proc.StartInfo.Verb = "runas";
                proc.Start();
                proc.WaitForExit();
            }
            catch
            {
                Request();
            }
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            timeLeft--;
            int secondsLeft = timeLeft % 60;
            int minutesLeft = timeLeft / 60;
            label3.Text = string.Format("{0}:{1}", minutesLeft, secondsLeft);
            progressBar1.Value = 60 * 5 - timeLeft;
            if(progressBar1.Value == 60 && resetTimeButton.Enabled)
            {
                int code = new Random().Next(1000, 9999);
                ResetCode = code.ToString();
                MessageBox.Show("Reset code is " + ResetCode + ". Use it wisely!",
    "Remember I will not say again!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            if (progressBar1.Value == 300)
            {
                timer1.Stop();
                if (MessageBox.Show("Activate REGFuck?" +
                    Environment.NewLine + 
                    Environment.NewLine + 
                    "This will harm your computer!", 
                    "REGFuck or not?",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question)
                    == DialogResult.Yes)
                {
                    if (MessageBox.Show("REGFuck is malware, running it will harm your computer, are you really sure?" +
                                        Environment.NewLine +
                                        Environment.NewLine +
                                        "THE CREATOR WILL NOT BE RESPONSIBLE FOR ANY DAMAGE CAUSED BY THE PAYLOAD. WE RECOMMEND YOU CLICK NO!",
                                        "REGFuck or not?",
                                        MessageBoxButtons.YesNo,
                                        MessageBoxIcon.Question)
                                        == DialogResult.Yes)
                    {
                        Request();
                        new frmRegFuck().Show();
                    }
                    else
                    {
                        new FuckingCake().Show();
                        isTrusted = true;
                        Close();
                    }
                }
                else
                {
                    new FuckingCake().Show();
                    isTrusted = true;
                    Close();
                }

            }
        }

        string correct;

        private async void Form1_Load(object sender, EventArgs e)
        {
                Random random = new Random();
                await Task.Delay(2000);

                string[] words = { "Winodsw Cihcgoa", "Widoswn Mempish", "Widnwso Whtsiler", "Wdniosw Loonghrn", "Wondisw Vienan" };

                string[] correctWords = { "Windows Chicago", "Windows Memphis", "Windows Whistler", "Windows Longhorn", "Windows Vienna" };

                int picked = random.Next(words.Length - 1);

                string ended = words[picked];
                correct = correctWords[picked];

                label2.Text = "Unscramble: " + ended;
                label2.Visible = true;
                textBox1.Visible = true;
                button3.Visible = true;
        }

        private async void Button3_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == correct)
            {
                MessageBox.Show("Good job! Move on to Challenge 2!",
                    "Good job!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await Task.Delay(2000);
                MessageBox.Show("Red Green Blue",
                    "Remember I will not say again!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                groupBox2.Visible = true;
            }
        }

        private async void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                MessageBox.Show("Good job! Move on to Challenge 3!",
    "Good job!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await Task.Delay(2000);
                groupBox3.Visible = true;
            }
        }

        private void RadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                MessageBox.Show("Sorry, choose again!",
    "Nice try!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void RadioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked)
            {
                MessageBox.Show("Sorry, choose again!",
    "Nice try!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private async void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.SelectedItem.ToString() == "Dark")
            {
                groupBox4.BackColor = Color.Black;
                label4.ForeColor = Color.White;
                label4.Text = "Game or joke?";
            }
            else
            {
                groupBox4.BackColor = Color.White;
                label4.ForeColor = Color.Black ;
                label4.Text = "Good job!";
                await Task.Delay(2000);
                label5.Visible = button4.Visible = textBox2.Visible = true;
            }
        }

        public string ResetCode;

        public int Tries = 3;

        private async void Button4_Click(object sender, EventArgs e)
        {
            if(textBox2.Text == "youareanidiot.org")
            {
                MessageBox.Show("Good job! Move on to the last challenge!",
"Good job!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await Task.Delay(2000);
                groupBox5.Visible = true;
            }
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            button1.Enabled = true;
            timer1.Stop();
            resetTimeButton.Enabled = false;
            button2.Enabled = true;
            button7.Enabled = false;
            MessageBox.Show("Good job! Click on the Unfuck button to exit or discover Easter Eggs in this app!",
"Good job!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            MessageBox.Show("LIAR!",
"LIAR!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Process.Start("http://youareanidiot.org");
        }

        private void ResetTimeButton_Click(object sender, EventArgs e)
        {
            new frmReset().ShowDialog(this);
        }

        bool isTrusted = false;

        private void Button1_Click(object sender, EventArgs e)
        {
            isTrusted = true;
            Close();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = !isTrusted;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            isTrusted = true;
            new frmEaster().Show();
            Close();
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            if (MessageBox.Show("Activate REGFuck?" +
                Environment.NewLine +
                Environment.NewLine +
                "This will harm your computer!",
                "REGFuck or not?",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question)
                == DialogResult.Yes)
            {
                if (MessageBox.Show("REGFuck is malware, running it will harm your computer, are you really sure?" +
                                    Environment.NewLine +
                                    Environment.NewLine +
                                    "THE CREATOR WILL NOT BE RESPONSIBLE FOR ANY DAMAGE CAUSED BY THE PAYLOAD. WE RECOMMEND YOU CLICK NO!",
                                    "REGFuck or not?",
                                    MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Question)
                                    == DialogResult.Yes)
                {
                    Request();
                    new frmRegFuck().Show();
                }
                else
                {
                    new FuckingCake().Show();
                    isTrusted = true;
                    Close();
                }
            }
            else
            {
                new FuckingCake().Show();
                isTrusted = true;
                Close();
            }
        }
    }
}
