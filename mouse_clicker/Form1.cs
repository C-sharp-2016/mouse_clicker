using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;
using System.IO;



namespace mouse_clicker
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent(); 
        }

        [DllImport("user32.dll", EntryPoint = "SetCursorPos")]
        private static extern bool SetCursorPos(int X, int Y);

        [DllImport("user32.dll")]
        public static extern void mouse_event(int dwFlags, int dx, int dy, int cButtons, int dwExtraInfo);

        private const int MOUSEEVENTF_LEFTDOWN = 0x0002;
        private const int MOUSEEVENTF_LEFTUP = 0x0004;

        private const int MOUSEEVENTF_RIGHTUP = 0x0010;
        private const int MOUSEEVENTF_RIGHTDOWN = 0x0008;



        public void Clicker(int x, int y)
        {
            SetCursorPos(x, y);
            this.Refresh();
            Application.DoEvents();
            mouse_event(MOUSEEVENTF_LEFTDOWN, x, y, 0, 0);
            mouse_event(MOUSEEVENTF_LEFTUP, x, y, 0, 0);
        }

          
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        { 
            timer1.Start(); 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            int x = Cursor.Position.X;
            int y = Cursor.Position.Y;

            Clicker(x, y);

        }

    }
}
