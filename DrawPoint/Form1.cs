using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace DrawPoint
{
    public partial class MainForm : Form
    {
        List<Point> signal = new List<Point>();
       
        public MainForm()
        {
            InitializeComponent();
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void ReadInButton_Click(object sender, EventArgs e)
        {

            string path = "c:\\speech.dat";
            FileStream sr = new FileStream(path, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(sr);



            int a = 0;
            int low = 0;
            int high;
            for (int i = 0; i < 95658; i++)
            {

                if (i % 2 == 0)
                {
                    low = sr.ReadByte();
                }
                else
                {
                    high = sr.ReadByte();
                    a = (int)(high * Math.Pow(2, 8) + low);
                    if (a > 32768)
                    {
                        a -= 65536;
                    }
                    Point p = new Point(i, a);
                    signal.Add(p);
                }
            }

           
        }

        private void ShowButton_Click(object sender, EventArgs e)
        {
            
        }

        private void show(Graphics g,Pen pen,int j)
        {
           
 
        }

        private void panel1_Scroll(object sender, ScrollEventArgs e)
        {
            textBox1.Text = this.panel1.HorizontalScroll.Value.ToString();
            textBox2.Text = signal[this.panel1.HorizontalScroll.Value].X.ToString();
            textBox3.Text = signal[this.panel1.HorizontalScroll.Value].Y.ToString();

            //show(this.panel1.HorizontalScroll.Value);
            Bitmap bm = new Bitmap(7000, 337);
            Graphics g = Graphics.FromImage(bm);
            Pen pen = new Pen(Color.White, 1);
            for (int i = this.panel1.HorizontalScroll.Value; i < this.panel1.HorizontalScroll.Value + 600; i++)
            {
                //g.Clear(pictureBox1.BackColor);
                g.DrawLine(pen, signal[i].X
                    - this.panel1.HorizontalScroll.Value
                    , signal[i].Y + 100,
                   signal[i].X + 1
                   - this.panel1.HorizontalScroll.Value
                   , signal[i].Y + 100);
            }
            pictureBox1.Image = bm;
            pictureBox1.Refresh();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {

            



        }
    }
}
