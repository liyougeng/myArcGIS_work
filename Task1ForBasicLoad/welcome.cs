using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Timers;

namespace Task1ForBasicLoad
{
    public partial class welcome : Form
    {
        private int progress = 0;
        public welcome()
        {
            InitializeComponent(); this.Opacity = 1;
        }

        private void welcome_Load(object sender, EventArgs e)
        {
            this.StateProgressBar.Maximum = 100;
            MyTimer.Enabled = true;
            MyTimer.Interval = 600;
        }

        private void MyTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                this.StateProgressBar.Value = progress * 10;
                this.Opacity -= 0.05;
            }
            catch (Exception ex)
            {
                Console.WriteLine("exception occur in splash:" + ex.ToString());
            }
            if (progress > 10)
            {
                MyTimer.Enabled = false;
                //this.Dispose();
                Close();
                return;
            }
            progress++;
        }
        
    }
}
