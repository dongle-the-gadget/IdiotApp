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
    public partial class FuckingCake : Form
    {
        Random random = new Random();
        public FuckingCake()
        {
            InitializeComponent();
        }
        int x = 0;
        int y = 0;

        int xloc = 0;
        int yloc = 0;

        private void Timer1_Tick(object sender, EventArgs e)
        {
            int picked = random.Next(10, 50);
            if (xloc == 0)
            {
                x += picked;
            }
            else
            {
                x -= picked;
            }
            if (yloc == 0)
            {
                y += picked;
            }
            else
            {
                y -= picked;
            }
            Location = new Point(x, y);
            if(x >= Screen.PrimaryScreen.Bounds.Width - Width)
            {
                xloc = 1;
            }
            if(x <= 0)
            {
                xloc = 0;
            }
            if (y >= Screen.PrimaryScreen.Bounds.Height - Height)
            {
                yloc = 1;
            }
            if (y <= 0)
            {
                yloc = 0;
            }
        }
    }
}
