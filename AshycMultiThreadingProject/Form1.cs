using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AshycMultiThreadingProject
{
    public partial class Form1 : Form
    {
        Stopwatch watchSingle = new Stopwatch();
        Stopwatch watchMulti = new Stopwatch();
        CancellationTokenSource ctsSingle = new CancellationTokenSource();// act like an event to notice the cancelation
        CancellationTokenSource ctsMulti = new CancellationTokenSource();// act like an event to notice the cancelation
        Task singleTask = new Task(() => { });// task use for the single task
        List<Task> tasks = new List<Task>();// collection of task that represent the multitask we gonna do
        public Form1()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Reset le grid system to gray
        /// </summary>
        /// <param name="panel"></param>
        public void resetGrid(Panel panel)
        {
            foreach (Panel p in panel.Controls)
            {

                if (p is Panel)
                {

                    p.BackColor = Color.Gray;

                    if (!this.InvokeRequired)
                    {
                        p.Update();
                    }

                }

            }
        }
        /// <summary>
        /// Simulate a heavy process 
        /// </summary>
        /// <param name="op"></param>
        public void prossess(object op)
        {

            Panel p = (Panel)op;
            p.BackColor = Color.Green;
            int a = 0 ;

            for (int i = 0; i < 10000000; i++)
            {
                a++;
            }

            if (!this.InvokeRequired)// Enshure to not making some cross-threading error
            {

                p.Update();// update de ui

            }
        }
        /// <summary>
        /// Preload when the program start
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            separatePanel(panelSingleTread, 10, 10);
            separatePanel(panelMultithreading, 10, 10);

            // Separate thread that run asynchronously for making the timer update on the UI
            ThreadPool.QueueUserWorkItem(new WaitCallback(p =>
            {
                while (true)
                {
                    Thread.Sleep(200);
                    label1.Invoke((Action)delegate { label1.Text = watchSingle.Elapsed.ToString(); });

                }
            }));
            // Separate thread that run asynchronously for making the timer update on the UI
            ThreadPool.QueueUserWorkItem(new WaitCallback(p =>
            {
                while (true)
                {
                    Thread.Sleep(100);
                    label2.Invoke((Action)delegate { label2.Text = watchMulti.Elapsed.ToString(); });

                }
            }));
        }
        /// <summary>
        /// Generate all square in the grid
        /// </summary>
        /// <param name="p"></param>
        /// <param name="horSepa"></param>
        /// <param name="vertSepa"></param>
        public void separatePanel(Panel p, int horSepa, int vertSepa)
        {
            Size separationSize = new Size(p.Size.Width / horSepa, p.Size.Height / vertSepa);
            for (int i = 0; i < horSepa; i++)
            {
                for (int j = 0; j < vertSepa; j++)
                {
                    p.Controls.Add(new Panel() { Size = new Size(separationSize.Width - 2, separationSize.Height - 2), BackColor = Color.Gray, Location = new Point((separationSize.Width * i) + 1, (separationSize.Height * j) + 1) });
                }
            }

        }

        /// <summary>
        /// Run the single thread grid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void buttonSingleThread_Click(object sender, EventArgs e)
        {

            switch (singleTask.Status)
            {

                case TaskStatus.Running:
                    {
                        ctsSingle.Cancel();
                        await singleTask;//wait the process is done before continuing
                        ctsSingle = new CancellationTokenSource();
                        singleTask = new Task(() => { });
                        buttonSingleThread_Click(sender, e);//retry the function afther cancelation

                        break;
                    }
                case TaskStatus.Created:
                    {
                        watchSingle.Reset();
                        watchSingle.Start();


                        singleTask = new Task(() =>
                        {



                            resetGrid(panelSingleTread);
                            foreach (Panel p in panelSingleTread.Controls)
                            {
                                if (ctsSingle.IsCancellationRequested)//Stop processing if canceled
                                {
                                    break;
                                }
                                if (p is Panel)
                                {
                                    prossess(p);
                                }
                            }

                        }, ctsSingle.Token);

                        singleTask.Start();


                        await singleTask;//wait the process is done before continuing


                        watchSingle.Stop();
                        singleTask = new Task(() => { });//reset task if done
                        break;
                    }
            }

        }

        /// <summary>
        /// Run the multithread grid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void buttonMultiThread_Click(object sender, EventArgs e)
        {
            switch (tasks.Count)
            {
                case 0: // 0 when task created
                    {
                        watchMulti.Reset();
                        watchMulti.Start();
                        resetGrid(panelMultithreading);

                        foreach (Panel p in panelMultithreading.Controls)
                        {
                            if (ctsMulti.IsCancellationRequested)//Stop processing if canceled
                            {
                                break;
                            }
                            if (p is Panel)
                            {
                                tasks.Add(new Task(() => { prossess(p); },ctsMulti.Token)) ;
                            }
                        }
                        foreach (Task t in tasks)
                        {
                            if (t.Status == TaskStatus.Created)
                            {
                                if (ctsMulti.IsCancellationRequested)
                                {
                                    break;
                                }
                                t.Start();
                            }
                        }
                        try
                        {
                            await Task.WhenAll(tasks);//wait the process is done before continuing
                            watchMulti.Stop();
                            tasks = new List<Task>();
                        }
                        catch (OperationCanceledException)//catch exeption and let program running
                        {

                        }
                      
                        break;
                    }
                default: // when task canceled
                    {
                        ctsMulti.Cancel();                       
                        await Task.WhenAll(tasks.FindAll(s => s.Status == TaskStatus.Running));//wait only the running task note : we are doing that cause a started task cant be stop
                        tasks = new List<Task>();
                        ctsMulti = new CancellationTokenSource();
                        buttonMultiThread_Click(sender, e);//retry the function afther cancelation
                        break;
                    }

            }

        }
    }
}
