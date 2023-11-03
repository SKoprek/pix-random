using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PixRandom
{
    public partial class Form1 : Form
    {
        private int max_size = 50;
        private int pixel_size = 1;
        List<SolidBrush> listBrush = new List<SolidBrush>();
        List<PaintEventArgs> globalPain = new List<PaintEventArgs>();
        int x = 0;
        int y = 0;
        int aindex = 1;
        Random random = new Random();



        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //HIDE BARdx
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Size = new Size((max_size*pixel_size), (max_size*pixel_size));
            this.DoubleBuffered = true;
            this.Paint += new PaintEventHandler(Form_hendl);
        }
        private void Form_hendl(object sender, System.Windows.Forms.PaintEventArgs e) 
        {
            appTimer.Start();
            Graphics g = this.CreateGraphics();
            for (int ay = 0; ay < aindex; ay++)
            {
                for (int ax = 0; ax < aindex; ax++)
                {
                    SolidBrush azBrush = new SolidBrush(Color.FromArgb(255, random.Next(1, 255), random.Next(1, 255), random.Next(1, 255)));
                    e.Graphics.FillRectangle(azBrush, pixel_size * ax, pixel_size * ay, pixel_size, pixel_size);
                    System.Console.WriteLine("index"+aindex+ "coords"+x +" : "+ y);
                }
            }
            this.Update();
            Thread.Sleep(200);
            if (x < max_size && y < max_size) {
                x += 1;
                y += 1;
                aindex++;
            }
        }
        private void Pix(object sender, System.Windows.Forms.PaintEventArgs e) 
        {

        }


        private void appTimer_Tick(object sender, EventArgs e)
        {
            //while (x < max_size && y < max_size) {
                this.Refresh();
            //}
        }

       
    }
}
