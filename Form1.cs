using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laba4_1oop
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Mystorage storage = new Mystorage();       
        Bitmap bmp = new Bitmap(300, 300);

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (Control.ModifierKeys == Keys.Control)
            {
                Graphics g = Graphics.FromImage(bmp);
                PictureBox pb = (PictureBox)sender;
                if (storage.checkInfo2(e) == false)
                {
                    storage.addObj(new CCircle(e.X, e.Y, 20));
                    int d = storage.getCount();
                    lb1.Text = d.ToString();
                }
                else
                {
                    int d = storage.getCount();
                    lb1.Text = d.ToString();
                }
                this.Refresh();
            }
            else 
            {
                Graphics g = Graphics.FromImage(bmp);
                PictureBox pb = (PictureBox)sender;
                if (storage.checkInfo1(e) == false)
                {
                    storage.addObj(new CCircle(e.X, e.Y, 20));
                    int d = storage.getCount();
                    lb1.Text = d.ToString();
                }
                else
                {
                    int d = storage.getCount();
                    lb1.Text = d.ToString();
                }
                this.Refresh();
            }
        }

        private void btd_Click(object sender, EventArgs e)
        {
            Graphics g = Graphics.FromImage(bmp);
            storage.deleteWhenDel();
            g.Clear(Color.White);
            this.Invalidate();
            int d = storage.getCount();
            lb1.Text = d.ToString();
        }
        

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = Graphics.FromImage(bmp);
            for (int i = 0; i < (storage.getCount()); i++)
            {
                storage.methodObj(pictureBox1, i, bmp, g);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
        }    
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control)
            {
               
            }
        }
    }
}
