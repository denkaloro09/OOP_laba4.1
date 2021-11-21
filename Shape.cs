using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Laba4_1oop
{
    class Shape
    {
        virtual public void draw(PictureBox sender, MouseEventArgs e) 
        {
        }
        virtual public void draw(PictureBox sender,Bitmap bmp, Graphics g)
        {
        }
        virtual public void excretion()
        {
        }
        virtual public int getX()
        {
            return 0;
        }
        virtual public int getY()
        {
            return 0;
        }
        virtual public int getR()
        {
            return 0;
        }
        virtual public bool getF()
        {
            return false;
        }
        virtual public void slect1()
        {
        }
        virtual public void slect2()
        {
        }
    }

    class CCircle : Shape
    {
        private int x, y, r;
        private bool f;
        public CCircle(int _x, int _y, int _r)
        {
            x = _x;
            y = _y;
            r = _r;
            f = true;
        }
        override public void draw(PictureBox sender, MouseEventArgs e) 
        {
            Rectangle rect = new Rectangle(e.X, e.Y, r * 2, r * 2);
            Bitmap bmp = new Bitmap(300, 300);
            Graphics g = Graphics.FromImage(bmp);
            Pen pen = new Pen(Color.Black);
            g.DrawEllipse(pen, rect);
            sender.Image = bmp;
        }
        override public void draw(PictureBox sender,Bitmap bmp,Graphics g)
        {
            Rectangle rect = new Rectangle(x - r, y - r, r * 2, r * 2);
            Pen pen = new Pen(Color.Black);
            if (f == true) 
            {
                pen.Color = Color.Lime;
            }
            g.DrawEllipse(pen, rect);
            sender.Image = bmp;
        }
        override public int getX() 
        {
            return x;
        }
        override public int getY()
        {
            return y;
        }
        override public int getR()
        {
            return r;
        }
        override public bool getF()
        {
            return f;
        }
        override public void slect1() 
        {
            f = true;
        }
        override public void slect2()
        {
            f = false;
        }
    }
    class Mystorage
    {
        List<Shape> head;
        public Mystorage() 
        {
            head = new List<Shape>(10);
        }
        public Mystorage(Shape obj) 
        {
            head.Add(obj);
        }
        public void addObj(Shape obj) 
        {
            head.Add(obj);
            for (int i = 0; i < getCount() - 1; i++)
            {
                head[i].slect2();
            }

        }
        public void deleteObj(int index) 
        {
            head.RemoveAt(index);
        }
        public void methodObj(PictureBox sender,int index,Bitmap bmp,Graphics g) 
        {
            head[index].draw(sender,bmp,g);
        }
        public int getCount() 
        {
            return head.Count();
        }
        public void allObjFalse() 
        {
            for (int i = head.Count - 1; i >= 0; i--)
            {
                if (head[i].getF() == true)
                {
                    head[i].slect2();
                }

            }
        }
        public void deleteWhenDel() 
        {
            for (int i = head.Count - 1; i >= 0; i--)
            {
                if (head[i].getF() == true) 
                {
                    head.RemoveAt(i);
                }

            }
            
        }        
        public bool checkInfo1(MouseEventArgs e) //проверка того, нажат ли объект на форме
        {
            for (int i = 0; i < getCount(); i++)
            {
                if(((e.X - head[i].getX())* (e.X - head[i].getX()) + (e.Y - head[i].getY())* (e.Y - head[i].getY())) <= (head[i].getR()* head[i].getR())) 
                {
                    allObjFalse(); 
                    head[i].slect1();
                    return true;
                    break;
                }
            }
            return false;
        }
        public bool checkInfo2(MouseEventArgs e) //проверка того, нажат ли объект на форме
        {
            for (int i = 0; i < getCount(); i++)
            {
                if (((e.X - head[i].getX()) * (e.X - head[i].getX()) + (e.Y - head[i].getY()) * (e.Y - head[i].getY())) <= (head[i].getR() * head[i].getR()))
                {                   
                    head[i].slect1();
                    return true;
                    break;
                }
            }
            return false;

        }
    }
}
