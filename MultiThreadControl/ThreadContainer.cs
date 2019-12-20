using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace MultiThreadControl
{
    [DefaultEvent("DoWork"),
    DefaultProperty("Concurrent")]
    public partial class ThreadContainer : UserControl
    {
        #region Public Events
        public delegate void DoWorkHandler(object sender, EventArgs e);
        public event DoWorkHandler DoWork;

        protected virtual void OnDoWork(EventArgs e)
        {
            if (DoWork != null)
                DoWork(this, e);
        }
        #endregion
        public int TotalThreads = 0;
        public int Concurrent = 0;
        public int MaxSleepTime = 100;
        public Orientation Orientation
        {
            get { return splitContainer1.Orientation; }
            set{splitContainer1.Orientation = value;}
        }

        private int Current = 0;
        private bool Cancel = false;
        private int errorID = 1;

        //Constructor
        public ThreadContainer()
        {
            InitializeComponent();
        }

        private void ThreadContainer_Load(object sender, EventArgs e)
        {
            
        }

        private void btnDetails_Click(object sender, EventArgs e)
        {
            //Change the name on the button
            if (btnDetails.Text == "More Info >>")
                btnDetails.Text = "<< Less Info";
            else
                btnDetails.Text = "More Info >>";

            //Change the panel visibility
            splitContainer1.Panel2Collapsed = !splitContainer1.Panel2Collapsed;
        }
        public void Start(int total, int concurrent)
        {
            //Clear out the previous Results
            dsErrors1.Errors.Clear();

            //Set the Overall Progress bar up
            barProgress.Maximum = total;
            barProgress.Visible = true;

            //setup the run
            Concurrent = concurrent;
            TotalThreads = total;
            Cancel = false;
            Current = 0;
            pnlThreads.Controls.Clear();

            //Start the first set of threads
            for (int i = 0; i < Concurrent; i++)
            {
                CreateJob(i.ToString());
            }
        }
        private void CreateJob(string name)
        {
            //Create the thread
            ThreadView j = new ThreadView("Thread " + name);
            
            //Make sure it will resize to the container whatever the size
            j.Dock = DockStyle.Top;
            
            //Tell it how much to sleep so it will look like it is doing something
            j.MaxSleepTime = MaxSleepTime;
            
            //Consume the Job Completed event so that we can know when the thread is done 
            j.JobCompleted += new ThreadView.JobCompletedHandler(this.ThreadViewer1_JobCompleted);
            //Consume the Job Event event so that we can know when the thread has a message
            j.JobEvent += new ThreadView.JobEventHandler(this.ThreadViewer1_JobEvent);
            
            //add the thread to the panel so it can be viewed
            pnlThreads.Controls.Add(j);
            
            //Start the thread
            j.Start();

            //Adjust the counters
            TotalThreads--;
            Current++;
        }

        private void ThreadViewer1_JobCompleted(object sender, EventArgs e)
        {
            //Are we not on the UI thread
            if (InvokeRequired)
            {
                //Change to the UI thread
                Invoke(new ThreadView.JobCompletedHandler(this.ThreadViewer1_JobCompleted), new object[] { sender, e });
            }
            else
            {
                //Find out who we are
                ThreadView j = (ThreadView)sender;
                //Take the thread off
                pnlThreads.Controls.Remove(j);

                //if i am the last one and the user hadn't pressed cancel then start another thread
                if (TotalThreads > 0 && !Cancel)
                    CreateJob(Current.ToString());

                //Show the data
                dataGridView1.Refresh();
                //Increment the overall progress bar
                barProgress.Value++;
            }
        }

        private void ThreadViewer1_JobEvent(object sender, JobEventEventArgs e)
        {
            //Are we not on the UI thread
            if (InvokeRequired)
                Invoke(new ThreadView.JobEventHandler(this.ThreadViewer1_JobEvent),new object[] { sender, e });
            else
            {
                //add the message to the list
                errorID++;
                dsErrors1.Errors.AddErrorsRow(e.Msg, errorID, e.ThreadName);
            }
            
        }

        private void btnCancelAll_Click(object sender, EventArgs e)
        {
            //tell the control that we are stopping and don't start any new threads
            Cancel = true;

            //Stop all of the currently running threads
            foreach (Control ctl in pnlThreads.Controls)
            {
                ((ThreadView)ctl).Cancel();
            }

            //Clear the progress bar
            barProgress.Value = 0;
            barProgress.Visible = false;
        }
    }
}
