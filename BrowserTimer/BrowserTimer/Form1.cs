using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BrowserTimer
{
    public partial class Form1 : Form
    {
        public static bool isWorking;      // Checking Button is ON or OFF
        public static int TIME_INTERVAL = 10000;    // 밀리초 기준입니다. 10000밀리초 = 10초 ㅇㅋ?
        public static string REDIRECT_URL = "https://www.naver.com";

        public Form1()
        {
            InitializeComponent();
            isWorking = false;

            this.Load += TrayIcon_Load;
            this.FormClosing += DicForm_FormClosing;

            TrayIcon.MouseDoubleClick += TrayIcon_MouseDoubleClick;
            showToolStripMenuItem.Click += showToolStripMenuItem_Clicked;
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Clicked;
        }

        private void DicForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Visible = false;
        }

        public void TrayIcon_Load(object sender, EventArgs e)
        {
            TrayIcon.ContextMenuStrip = TrayIcon_Context;
        }

        public void TrayIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.ShowInTaskbar = true;
            this.Visible = true;
            this.WindowState = FormWindowState.Normal;
        }

        private void showToolStripMenuItem_Clicked(object sender, EventArgs e)
        {
            this.ShowInTaskbar = true;
            this.Visible = true;
            this.WindowState = FormWindowState.Normal;
        }

        private void exitToolStripMenuItem_Clicked(object sender, EventArgs e)
        {
            MessageBox.Show("완전히 종료합니다.");
            Environment.Exit(0);
        }

        private Timer backgroundTimer;

        private void OnclickedONOFFButton(object sender, EventArgs e)
        {
            isWorking = !isWorking;
            if (isWorking)
            {
                // ON
                onOffButton.BackColor = Color.FromArgb(255, 192, 255, 192);
                onOffButton.Text = "ON";

                // Setting Timer
                backgroundTimer = new Timer();
                backgroundTimer.Tick += new EventHandler(backgroundWork);
                backgroundTimer.Interval = TIME_INTERVAL;
                backgroundTimer.Start();
            }
            else
            {
                // OFF
                onOffButton.BackColor = Color.FromArgb(255, 255, 192, 192);
                onOffButton.Text = "OFF";
                backgroundTimer.Stop();
            }
        }


        private void backgroundWork(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(REDIRECT_URL);
        }
    }
}
