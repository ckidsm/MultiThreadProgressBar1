using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MultiThreadTest
{
    public partial class ThreadTest : Form
    {
        public ThreadTest()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            threadContainer1.MaxSleepTime = decimal.ToInt32(spinMaxSleep.Value);
            threadContainer1.Start(decimal.ToInt32(spinTotalThreads.Value), 
                decimal.ToInt32(this.spinConcurrentThreads.Value));
        }

        private void threadContainer1_DoWork(object sender, EventArgs e)
        {

        }
    }
}