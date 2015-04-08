using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace StopWatch
{
    public partial class Form1 : Form
    {
        private DateTime _startTime;
        private Timer _timer;

        public Form1()
        {
            InitializeComponent();
            Reset();
        }

        private void BtnStartStop_Click(object sender, EventArgs e)
        {
            if (BtnStartStop.Text == "Start")
            {
                Reset();
                BtnStartStop.Text = "Stop";
                _startTime = DateTime.Now;
                _timer = new Timer();
                _timer.Tick += Timer_Tick;
                _timer.Interval = 100;
                _timer.Start();
            }
            else
            {
                Stop();
            }
        }

        private void Stop()
        {
            BtnStartStop.Text = "Start";
            if(_timer != null)
                _timer.Stop();
        }

        void Timer_Tick(object sender, EventArgs e)
        {
            TimeSpan diff = _startTime - DateTime.Now;
            SetTime(diff);
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void Reset()
        {
            Stop();
            SetTime(TimeSpan.FromMilliseconds(0));
        }

        private void SetTime(TimeSpan timeSpan)
        {
            LblTime.Text = timeSpan.ToString(@"hh\:mm\:ss\.ffff");
        }
    }
}
