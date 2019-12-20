using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace MultiThreadControl
{
    [DefaultEvent("JobCompleted"),
    DefaultProperty("MaxSleepTime")]
    public partial class ThreadView : UserControl
    {
        private Random r = new Random();
        private string ThreadName = "";
        private int _maxSleep = 100;
        #region public events
        //Declares and handles the Job Completed Event
        public delegate void JobCompletedHandler(object sender, EventArgs e);
        public event JobCompletedHandler JobCompleted;
        protected virtual void OnJobCompleted(EventArgs e)
        {
            if (JobCompleted != null)
                JobCompleted(this, e);
        }

        //Declares and handles the Job Event Event
        public delegate void JobEventHandler(object sender, JobEventEventArgs e);
        public event JobEventHandler JobEvent;
        protected virtual void OnJobEvent(JobEventEventArgs e)
        {
            if (JobEvent != null)
                JobEvent(this, e);
        }        
        #endregion
        
        //Constructor
        public ThreadView(string name)
        {
            InitializeComponent();
            ThreadName = name;
        }

        private void ThreadViewer_Load(object sender, EventArgs e)
        {
            
        }
        public void Start()
        {
            //Starts the background process
            worker.RunWorkerAsync();
        }
        public void Cancel()
        {
            //Cancels the background process
            worker.CancelAsync();
        }

        #region Properties Add your own
        public bool ShowCancel
        {
            get { return btnCancel.Visible; }
            set { btnCancel.Visible = value; }
        }
        [DefaultValue(100)]
        public int MaxSleepTime
        {
            get { return _maxSleep; }
            set { _maxSleep = value; }
        }
        #endregion

        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            //This is where everything is done
            //TODO: Add your code here            
            for (int i = 0; i < 100; i++)
            {
                //this checks to see if the user pressed the cancel button
                if (worker.CancellationPending)
                    break;
                //Whenever you want the progress bar to change use this line.  
                //i is an integer from 0 to 100 that is the percentage completed
                worker.ReportProgress(i, "Progress: " + i.ToString());
                
                try
                {
                    Thread.Sleep(r.Next(0, _maxSleep));
                }
                catch 
                {
                }

                //Whenever you want to send a message out use this line
                //this signals the container that we have a message to show
                OnJobEvent(new JobEventEventArgs(ThreadName, "Progress: " + i.ToString()));
            }
        }

        private void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //Change the progress bar
            barProgress.Value = e.ProgressPercentage;
            //Change the title
            lblTitle.Text = ThreadName + "-" + e.UserState.ToString();
            //Repaint the control
            this.Refresh();
        }

        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //reset the values
            barProgress.Value = 0;
            lblTitle.Text = "";
            //signal the container that we are done
            this.OnJobCompleted(new EventArgs());
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            //signal this control that we want to be done
            Cancel();
        }
    }
    //this class handles the job events
    public class JobEventEventArgs : EventArgs
    {
        public string ThreadName = "";
        public string Msg = "";

        public JobEventEventArgs(string threadName, string message)
        {
            ThreadName = threadName;
            Msg = message;
        }
    }
}
