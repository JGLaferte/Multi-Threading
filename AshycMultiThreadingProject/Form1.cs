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
        CancellationTokenSource ctsSingle = new CancellationTokenSource();
        CancellationTokenSource ctsMulti = new CancellationTokenSource();
        Task singleTask = new Task(() => { });
        List<Task> tasks = new List<Task>();
        public Form1()
        {
            InitializeComponent();
        }
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
        public void prossess(object op)
        {

            Panel p = (Panel)op;
            p.BackColor = Color.Green;
            int a = 0 ;

            for (int i = 0; i < 10000000; i++)
            {
                a++;
            }

            if (!this.InvokeRequired)
            {

                p.Update();

            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            separatePanel(panelSingleTread, 10, 10);
            separatePanel(panelMultithreading, 10, 10);


            ThreadPool.QueueUserWorkItem(new WaitCallback(p =>
            {
                while (true)
                {
                    Thread.Sleep(200);
                    label1.Invoke((Action)delegate { label1.Text = watchSingle.Elapsed.ToString(); });

                }
            }));
            ThreadPool.QueueUserWorkItem(new WaitCallback(p =>
            {
                while (true)
                {
                    Thread.Sleep(100);
                    label2.Invoke((Action)delegate { label2.Text = watchMulti.Elapsed.ToString(); });

                }
            }));
        }
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
        private async void buttonSingleThread_Click(object sender, EventArgs e)
        {

            switch (singleTask.Status)
            {

                case TaskStatus.Running:
                    {
                        ctsSingle.Cancel();
                        await singleTask;
                        ctsSingle = new CancellationTokenSource();
                        singleTask = new Task(() => { });
                        buttonSingleThread_Click(sender, e);

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
                                if (ctsSingle.IsCancellationRequested)
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


                        await singleTask;


                        watchSingle.Stop();
                        singleTask = new Task(() => { });
                        break;
                    }
            }

        }
        private async void buttonMultiThread_Click(object sender, EventArgs e)
        {
            switch (tasks.Count)
            {
                case 0:
                    {
                        watchMulti.Reset();
                        watchMulti.Start();
                        resetGrid(panelMultithreading);

                        foreach (Panel p in panelMultithreading.Controls)
                        {
                            if (ctsMulti.IsCancellationRequested)
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
                            await Task.WhenAll(tasks);
                            watchMulti.Stop();
                            tasks = new List<Task>();
                        }
                        catch (OperationCanceledException)
                        {

                        }
                      
                        break;
                    }
                default:
                    {
                        ctsMulti.Cancel();                       
                        await Task.WhenAll(tasks.FindAll(s => s.Status == TaskStatus.Running));
                        tasks = new List<Task>();
                        ctsMulti = new CancellationTokenSource();
                        buttonMultiThread_Click(sender, e);
                        break;
                    }

            }

        }
    }
}
