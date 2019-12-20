namespace MultiThreadTest
{
    partial class ThreadTest
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnStart = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.spinConcurrentThreads = new System.Windows.Forms.NumericUpDown();
            this.spinMaxSleep = new System.Windows.Forms.NumericUpDown();
            this.spinTotalThreads = new System.Windows.Forms.NumericUpDown();
            this.threadContainer1 = new MultiThreadControl.ThreadContainer();
            ((System.ComponentModel.ISupportInitialize)(this.spinConcurrentThreads)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinMaxSleep)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinTotalThreads)).BeginInit();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(309, 28);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(87, 21);
            this.btnStart.TabIndex = 4;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "Total Threads";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(147, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "Max Concurrent Threads";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "Max Sleep Time";
            // 
            // spinConcurrentThreads
            // 
            this.spinConcurrentThreads.Location = new System.Drawing.Point(166, 30);
            this.spinConcurrentThreads.Name = "spinConcurrentThreads";
            this.spinConcurrentThreads.Size = new System.Drawing.Size(90, 21);
            this.spinConcurrentThreads.TabIndex = 9;
            this.spinConcurrentThreads.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // spinMaxSleep
            // 
            this.spinMaxSleep.Location = new System.Drawing.Point(166, 54);
            this.spinMaxSleep.Name = "spinMaxSleep";
            this.spinMaxSleep.Size = new System.Drawing.Size(90, 21);
            this.spinMaxSleep.TabIndex = 10;
            this.spinMaxSleep.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // spinTotalThreads
            // 
            this.spinTotalThreads.Location = new System.Drawing.Point(166, 6);
            this.spinTotalThreads.Name = "spinTotalThreads";
            this.spinTotalThreads.Size = new System.Drawing.Size(90, 21);
            this.spinTotalThreads.TabIndex = 11;
            this.spinTotalThreads.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // threadContainer1
            // 
            this.threadContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.threadContainer1.Location = new System.Drawing.Point(-1, 78);
            this.threadContainer1.Name = "threadContainer1";
            this.threadContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.threadContainer1.Size = new System.Drawing.Size(799, 304);
            this.threadContainer1.TabIndex = 3;
            this.threadContainer1.DoWork += new MultiThreadControl.ThreadContainer.DoWorkHandler(this.threadContainer1_DoWork);
            // 
            // ThreadTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(245)))), ((int)(((byte)(241)))));
            this.ClientSize = new System.Drawing.Size(799, 385);
            this.Controls.Add(this.spinTotalThreads);
            this.Controls.Add(this.spinMaxSleep);
            this.Controls.Add(this.spinConcurrentThreads);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.threadContainer1);
            this.Name = "ThreadTest";
            this.Text = "Multi Thread Control Test";
            ((System.ComponentModel.ISupportInitialize)(this.spinConcurrentThreads)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinMaxSleep)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinTotalThreads)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MultiThreadControl.ThreadContainer threadContainer1;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown spinConcurrentThreads;
        private System.Windows.Forms.NumericUpDown spinMaxSleep;
        private System.Windows.Forms.NumericUpDown spinTotalThreads;
    }
}