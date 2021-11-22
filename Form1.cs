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
        Storage storag = new Storage(100); //создание хранилища
        //Mystorage storage = new Mystorage(); 
        Bitmap bmp = new Bitmap(300, 300); //создание места для рисования

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e) //обработчик нажатия мыши на pictureBox
        {
            if (Control.ModifierKeys == Keys.Control) //если зажат Ctrl
            {
                Graphics g = Graphics.FromImage(bmp);
                PictureBox pb = (PictureBox)sender;
                if (storag.checkInfo2(e) == false) //если мышью нажали на пустое место 
                {
                    storag.addObj(new CCircle(e.X, e.Y, 20));                 
                    lb1.Text = storag.getCount().ToString();
                }
                else //если мышью нажали на объект на форме
                {
                    lb1.Text = storag.getCount().ToString();
                }
                this.Refresh();
            }
            else //если не зажат Ctrl
            {
                Graphics g = Graphics.FromImage(bmp);
                PictureBox pb = (PictureBox)sender;
                if (storag.checkInfo1(e) == false) //если мышью нажали на пустое место 
                {
                    storag.addObj(new CCircle(e.X, e.Y, 20));
                    lb1.Text = storag.getCount().ToString();
                }
                else //если мышью нажали на объект на форме
                {
                    lb1.Text = storag.getCount().ToString();
                }
                this.Refresh();
            }
        }

        private void btd_Click(object sender, EventArgs e) //удаление выделенных объектов при нажатии на кнопку
        {
            Graphics g = Graphics.FromImage(bmp);
            storag.deleteWhenDel();
            g.Clear(Color.White); //очистка рисунка
            this.Invalidate();
            lb1.Text = storag.getCount().ToString();
        }
        

        private void pictureBox1_Paint(object sender, PaintEventArgs e) //рисование объектов на форме
        {
            Graphics g = Graphics.FromImage(bmp);
            for (int i = 0; i < (storag.getCount()); i++)
            {
                storag.methodObj(pictureBox1, i, bmp, g);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true; //для обработки нажатия клавиши
        }            
    }
}
