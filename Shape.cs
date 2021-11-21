using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Laba4_1oop
{
    class Shape //базовый класс с виртуальными методами
    {       
        virtual public void draw(PictureBox sender,Bitmap bmp, Graphics g)
        {
        }      
        virtual public bool isChecked(MouseEventArgs e) 
        {
            return false;
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

    class CCircle : Shape //класс окружности, унаследованный от базового класса
    {
        private int x, y, r; //координаты и радиус
        private bool f; //булевая переменная, показывающая, "выделен" объект или нет
        public CCircle(int _x, int _y, int _r) //констурктор с параметрами
        {
            x = _x;
            y = _y;
            r = _r;
            f = true;
        }
        override public void draw(PictureBox sender,Bitmap bmp,Graphics g) //метод для рисования на pictureBox
        {
            Rectangle rect = new Rectangle(x - r, y - r, r * 2, r * 2);
            Pen pen = new Pen(Color.Black);
            if (f == true) //проверка на то, "выделен" ли объект или нет
            {
                pen.Color = Color.Lime; //выделение зеленым цветом
            }
            g.DrawEllipse(pen, rect);
            sender.Image = bmp;
        }
        override public bool isChecked(MouseEventArgs e) //проверка на то, нажат ли объект мышкой
        {
            if (((e.X - x) *(e.X - x) + (e.Y - y) * (e.Y - y)) <= (r * r)) 
            {
                return true;
            }
            else 
            {
                return false;
            }
        }     
        override public bool getF() //получение значения " выделенный/не выделенный" у объекта
        {
            return f;
        }
        override public void slect1() //изменение значения f на true
        {
            f = true;
        }
        override public void slect2() //изменение значения f на false
        {
            f = false;
        }
    }
    class Mystorage //хранилище объектов класса Shape
    {
        List<Shape> head; //список
        public Mystorage() //констуктор
        {
            head = new List<Shape>(10);
        }      
        public void addObj(Shape obj) //создание и добавление объекта в хранилище
        {
            head.Add(obj);
            //при создании объекта, все остальные объекты в хранилище перестают быть выделенными
            for (int i = 0; i < getCount() - 1; i++)
            {
                head[i].slect2();
            }

        }
        public void deleteObj(int index) //удаление объекта их хранилища
        {
            head.RemoveAt(index);
        }
        public void methodObj(PictureBox sender,int index,Bitmap bmp,Graphics g) //вызов draw у объекта по индексу
        {
            head[index].draw(sender,bmp,g);
        }
        public int getCount() //получение количества обхъектов в хранилище (на форме)
        {
            return head.Count();
        }
        public void allObjFalse()  //все объекты перестают быть выделенными
        {
            for (int i = head.Count - 1; i >= 0; i--)
            {
                if (head[i].getF() == true)
                {
                    head[i].slect2();
                }

            }
        }
        public void deleteWhenDel() //удаление выделенных объектов при нажатии кнопки Delete
        {
            for (int i = head.Count - 1; i >= 0; i--)
            {
                if (head[i].getF() == true) 
                {
                    head.RemoveAt(i);
                }

            }
            
        }        
        public bool checkInfo1(MouseEventArgs e) //проверка того, нажат ли объект на форме, если клавиша Ctrl не нажата
        {
            for (int i = 0; i < getCount(); i++)
            {
                if(head[i].isChecked(e) == true) 
                {
                    allObjFalse(); 
                    head[i].slect1();
                    return true;
                    break;
                }
            }
            return false;
        }
        public bool checkInfo2(MouseEventArgs e) //проверка того, нажат ли объект на форме, если клавиша Ctrl нажата
        {
            for (int i = 0; i < getCount(); i++)
            {
                if (head[i].isChecked(e) == true)
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
