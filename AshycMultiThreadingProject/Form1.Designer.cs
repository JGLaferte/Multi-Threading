namespace AshycMultiThreadingProject
{
    partial class Form1
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
            this.buttonSingleTadhr = new System.Windows.Forms.Button();
            this.panelSingleTread = new System.Windows.Forms.Panel();
            this.panelMultithreading = new System.Windows.Forms.Panel();
            this.buttonMultiThread = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonSingleTadhr
            // 
            this.buttonSingleTadhr.Location = new System.Drawing.Point(42, 10);
            this.buttonSingleTadhr.Name = "buttonSingleTadhr";
            this.buttonSingleTadhr.Size = new System.Drawing.Size(200, 20);
            this.buttonSingleTadhr.TabIndex = 1;
            this.buttonSingleTadhr.Text = "Run With Single Thread";
            this.buttonSingleTadhr.UseVisualStyleBackColor = true;
            this.buttonSingleTadhr.Click += new System.EventHandler(this.buttonSingleThread_Click);
            // 
            // panelSingleTread
            // 
            this.panelSingleTread.BackColor = System.Drawing.Color.Black;
            this.panelSingleTread.Location = new System.Drawing.Point(12, 36);
            this.panelSingleTread.Name = "panelSingleTread";
            this.panelSingleTread.Size = new System.Drawing.Size(250, 250);
            this.panelSingleTread.TabIndex = 15;
            // 
            // panelMultithreading
            // 
            this.panelMultithreading.BackColor = System.Drawing.Color.Black;
            this.panelMultithreading.Location = new System.Drawing.Point(268, 36);
            this.panelMultithreading.Name = "panelMultithreading";
            this.panelMultithreading.Size = new System.Drawing.Size(250, 250);
            this.panelMultithreading.TabIndex = 16;
            // 
            // buttonMultiThread
            // 
            this.buttonMultiThread.Location = new System.Drawing.Point(289, 10);
            this.buttonMultiThread.Name = "buttonMultiThread";
            this.buttonMultiThread.Size = new System.Drawing.Size(200, 20);
            this.buttonMultiThread.TabIndex = 17;
            this.buttonMultiThread.Text = "Run With Mulit-Thread";
            this.buttonMultiThread.UseVisualStyleBackColor = true;
            this.buttonMultiThread.Click += new System.EventHandler(this.buttonMultiThread_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 25);
            this.label1.TabIndex = 18;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 25);
            this.label2.TabIndex = 19;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Silver;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 289);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(250, 31);
            this.panel1.TabIndex = 20;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Silver;
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(267, 289);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(250, 31);
            this.panel2.TabIndex = 21;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(529, 327);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.buttonMultiThread);
            this.Controls.Add(this.panelMultithreading);
            this.Controls.Add(this.panelSingleTread);
            this.Controls.Add(this.buttonSingleTadhr);
            this.Name = "Form1";
            this.Text = "Testing Environement";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonSingleTadhr;
        private System.Windows.Forms.Panel panelSingleTread;
        private System.Windows.Forms.Panel panelMultithreading;
        private System.Windows.Forms.Button buttonMultiThread;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
    }
}

