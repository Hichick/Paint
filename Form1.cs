using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Serialization;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.RegularExpressions;

namespace paint
{
    public partial class Form1 : Form
    {
        List<item> collection = new List<item>(); //главная коллекция
        List<int> mark = new List<int>(); //номера выделенных


        //---------------------------------------------

        static int Cadr_id = 1; // Текущий кадр
        static int All_cadr = 1; // Всего кадров

        Dictionary<int, List<item>> Animation = new Dictionary<int, List<item>>(); // Коллекция для хранения кадров

        //---------------------------------------------

        string FileName = ""; // Переменная хранит название файла

        static bool OnLoading = false; // Переменная для проверки загружен ли файл

        static bool OnSaving = false; // Переменная для проверки сохранен ли файл

        static bool OnChange = false; // переменная для проверки изменения файла 

        
        bool line_mv = false; //флаг перемещения линии
        bool point_mv = false; //флаг перемещения точки
        bool animac = false; //флаг анимации точки
        bool mark_flag = false; //флаг выделения прямоугольника

        int number_point = 0;//номер выделенной точки

        Point pp;//точка для запоминания координаты положения мыши (в момент нажатия) (нужно для перемещения объекта)
        Point first_mark;//начальная точка для выделяемой области
        Point end_mark;//конечная точка выделяемой области
        //Point temp_mark;//вспомогательная переменная(если последняя точка выделяемой области выше или левее первой)

        Random rand = new Random();

        Timer blinkTimer = new Timer();//создание таймера
        int blinksRemain = 0;//количество вызовов события по таймеру


        //границы локальной системы координат
        int max_x;
        int max_y;
        int min_x;
        int min_y;
        //-------------------------

        public Form1()
        {
            InitializeComponent();
            blinkTimer.Tick += blinkTimer_Tick;//определение слушателя
            radioButton_global.Checked = true;
            checkBox_x.Checked = true;

            Animation.Add(Cadr_id, new List<item>(collection));
            //Animation_List.Add(new List<item>()); // Добавляем первый кадр

            All_cadr = Animation.Count();

            max_x = 0;
            max_y = 0;
            min_x = pictureBox1.Width;
            min_y = pictureBox1.Height;

            //menuStrip1.Size.Height = 20;
        }

        void blinkTimer_Tick(object sender, EventArgs e)
        {
            animac = !animac;

            pictureBox1.Refresh();

            blinksRemain--;
            if (blinksRemain <= 0)
            {
                blinkTimer.Stop();
                animac = false;
            }
        }

        private void button_add2_Click(object sender, EventArgs e)
        {
            collection.Add(new item(new Point(rand.Next(pictureBox1.Width), rand.Next(pictureBox1.Height)), new Point(rand.Next(pictureBox1.Width), rand.Next(pictureBox1.Height))));
            pictureBox1.Refresh();

            OnChange = true; // Изменения в файле
        }

        private void button_add3_Click(object sender, EventArgs e)
        {
            collection.Add(new item(new Point(rand.Next(pictureBox1.Width), rand.Next(pictureBox1.Height)), new Point(rand.Next(pictureBox1.Width), rand.Next(pictureBox1.Height)), new Point(rand.Next(pictureBox1.Width), rand.Next(pictureBox1.Height))));
            pictureBox1.Refresh();

            OnChange = true; // Изменения в файле
        }

        private void button_add4_Click(object sender, EventArgs e)
        {
            collection.Add(new item(new Point(rand.Next(pictureBox1.Width), rand.Next(pictureBox1.Height)), new Point(rand.Next(pictureBox1.Width), rand.Next(pictureBox1.Height)), new Point(rand.Next(pictureBox1.Width), rand.Next(pictureBox1.Height)), new Point(rand.Next(pictureBox1.Width), rand.Next(pictureBox1.Height))));
            pictureBox1.Refresh();

            OnChange = true; // Изменения в файле
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Pen pen_line = new Pen(Color.Black,1); //цвет обычной линии
            SolidBrush brush_point = new SolidBrush(Color.Black);//кисть(цвет) для закраски обычной точки
            Pen pen_line_mark = new Pen(Color.Red,1);//цвет выделенной линии
            SolidBrush brush_point_mark = new SolidBrush(Color.Red);//кисть(цвет) для закраски выделенной точки


      
            //прорисовка осей
            Point[] os_x = { new Point(0, pictureBox1.Height / 2), new Point(pictureBox1.Width, pictureBox1.Height / 2),
                             
                             new Point(pictureBox1.Width, pictureBox1.Height / 2) };
            e.Graphics.DrawLines(new Pen(Color.Brown, 1), os_x);
            Point[] os_y = { new Point(pictureBox1.Width/2, pictureBox1.Height), new Point(pictureBox1.Width/2, 0),
                            
                             new Point(pictureBox1.Width/2, 0)};
            e.Graphics.DrawLines(new Pen(Color.Brown,1), os_y);
            //----------------------------------------

            foreach (var p in collection)
            {
                //прорисовка линий элементов
                e.Graphics.DrawLines(pen_line, p.list.ToArray());
                e.Graphics.DrawLine(pen_line, p.list.Last(), p.list.First());
                //--------------------------------------

                //прорисовка точек элементов
                foreach (var q in p.list)
                {
                    //e.Graphics.FillEllipse(brush_point, q.X - 5, q.Y - 5, 10, 10);//
                }
                //---------------------------------------
            }
            
            foreach (var p in mark)
            {
                //прорисовка линий выделенных элементов
                
                e.Graphics.DrawLines(pen_line_mark, collection[p].list.ToArray());
                e.Graphics.DrawLine(pen_line_mark, collection[p].list.Last(), collection[p].list.First());

                //--------------------------------------

                //прорисовка точек выделенных элементов

                foreach (var q in collection[p].list)
                {
                    e.Graphics.FillEllipse(brush_point_mark, q.X - 3, q.Y - 3, 6, 6);
                }
                
                //---------------------------------------
            }

            if (animac && mark.Count == 1)
            {
                Point temp = collection[mark[0]].list[number_point]; // анимируемая точка
                e.Graphics.FillEllipse(new SolidBrush(Color.Red), temp.X - 5, temp.Y - 5, 10, 10); //во что превращается точка во время анимации
            }

            Pen Pen_for_mark = new Pen(Color.Black); // Для области выделения
            Pen_for_mark.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash; 

            if (mark_flag)
            {
                if (end_mark.X > first_mark.X && end_mark.Y > first_mark.Y)
                    e.Graphics.DrawRectangle(Pen_for_mark, first_mark.X, first_mark.Y, end_mark.X - first_mark.X, end_mark.Y - first_mark.Y);
                if (end_mark.X > first_mark.X && end_mark.Y < first_mark.Y)
                    e.Graphics.DrawRectangle(Pen_for_mark, first_mark.X, end_mark.Y, end_mark.X - first_mark.X, first_mark.Y - end_mark.Y);
                if (end_mark.X < first_mark.X && end_mark.Y > first_mark.Y)
                    e.Graphics.DrawRectangle(Pen_for_mark, end_mark.X, first_mark.Y, first_mark.X - end_mark.X, end_mark.Y - first_mark.Y);
                if (end_mark.X < first_mark.X && end_mark.Y < first_mark.Y)
                    e.Graphics.DrawRectangle(Pen_for_mark, end_mark.X, end_mark.Y, first_mark.X - end_mark.X, first_mark.Y - end_mark.Y);

            }

            Animation.Remove(Cadr_id);
            Animation.Add(Cadr_id, new List<item>(collection));
              
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (mark.Count > 1)
            {
                foreach (var q in mark)
                {
                    int i = -1;
                    var p = collection[q];

                    i++;
                    int k;
                    int temp;
                    for (k = 0; k < p.list.Count - 1; k++)
                    {
                        temp = (p.list[k].Y - p.list[k + 1].Y) * e.X + (p.list[k + 1].X - p.list[k].X) * e.Y + (p.list[k].X * p.list[k + 1].Y - p.list[k].Y * p.list[k + 1].X);
                        if (
                            temp < 500 && temp > -500 &&
                            e.X <= p.max(p.list[k].X, p.list[k + 1].X) && e.X >= p.min(p.list[k].X, p.list[k + 1].X) &&
                            e.Y <= p.max(p.list[k].Y, p.list[k + 1].Y) && e.Y >= p.min(p.list[k].Y, p.list[k + 1].Y)
                            )
                        {
                            line_mv = true;
                            //mark.Add(i);
                            pp = e.Location;
                            OnChange = true; // Изменения в файле
                            pictureBox1.Refresh();
                            //определение границ локальной области
                            // max_x = p.max_x();
                            // max_y = p.max_y();
                            // min_x = p.min_x();
                            // min_y = p.min_y();
                            //-----------------------------
                            return;
                        }
                    }
                    k++;
                    temp = (p.list.First().Y - p.list.Last().Y) * e.X + (p.list.Last().X - p.list.First().X) * e.Y + (p.list.First().X * p.list.Last().Y - p.list.First().Y * p.list.Last().X);
                    if (
                        temp < 500 && temp > -500 &&
                        e.X <= p.max(p.list.First().X, p.list.Last().X) && e.X >= p.min(p.list.First().X, p.list.Last().X) &&
                        e.Y <= p.max(p.list.First().Y, p.list.Last().Y) && e.Y >= p.min(p.list.First().Y, p.list.Last().Y)
                        )
                    {
                        line_mv = true;
                        // mark.Add(i);
                        pp = e.Location;
                        OnChange = true; // Изменения в файле
                        pictureBox1.Refresh();
                        //определение границ локальной области
                        // max_x = p.max_x();
                        // max_y = p.max_y();
                        // min_x = p.min_x();
                        // min_y = p.min_y();
                        //-----------------------------
                        return;
                    }

                }
            }

            mark.Clear();//очищение массива выделенных

            if (collection.Count > 0)
            {
                int i = -1;
                foreach (var p in collection)
                {
                    i++;
                    int j = -1;
                    foreach (var q in p.list)
                    {
                        j++;
                        if (e.X < q.X + 5 && e.X > q.X - 5 && e.Y < q.Y + 5 && e.Y > q.Y - 5)
                        {
                            point_mv = true;
                            number_point = j;
                            mark.Add(i);
                            OnChange = true; // Изменения в файле
                            pictureBox1.Refresh();
                            //определение границ локальной области
                            max_x = p.max_x();
                            max_y = p.max_y();
                            min_x = p.min_x();
                            min_y = p.min_y();
                            //-----------------------------
                            return;
                        }

                    }
                    int k;
                    int temp;
                    for (k = 0; k < p.list.Count - 1; k++)
                    {
                        temp = (p.list[k].Y - p.list[k + 1].Y) * e.X + (p.list[k + 1].X - p.list[k].X) * e.Y + (p.list[k].X * p.list[k + 1].Y - p.list[k].Y * p.list[k + 1].X);
                        if (
                            temp < 500 && temp > -500 &&
                            e.X <= p.max(p.list[k].X, p.list[k + 1].X) && e.X >= p.min(p.list[k].X, p.list[k + 1].X) &&
                            e.Y <= p.max(p.list[k].Y, p.list[k + 1].Y) && e.Y >= p.min(p.list[k].Y, p.list[k + 1].Y)
                            )
                        {
                            line_mv = true;
                            mark.Add(i);
                            pp = e.Location;
                            OnChange = true; // Изменения в файле
                            pictureBox1.Refresh();
                            //определение границ локальной области
                            max_x = p.max_x();
                            max_y = p.max_y();
                            min_x = p.min_x();
                            min_y = p.min_y();
                            //-----------------------------
                            return;
                        }
                    }
                    k++;
                    temp = (p.list.First().Y - p.list.Last().Y) * e.X + (p.list.Last().X - p.list.First().X) * e.Y + (p.list.First().X * p.list.Last().Y - p.list.First().Y * p.list.Last().X);
                    if (
                        temp < 500 && temp > -500 &&
                        e.X <= p.max(p.list.First().X, p.list.Last().X) && e.X >= p.min(p.list.First().X, p.list.Last().X) &&
                        e.Y <= p.max(p.list.First().Y, p.list.Last().Y) && e.Y >= p.min(p.list.First().Y, p.list.Last().Y)
                        )
                    {
                        line_mv = true;
                        mark.Add(i);
                        pp = e.Location;
                        OnChange = true; // Изменения в файле
                        pictureBox1.Refresh();
                        //определение границ локальной области
                        max_x = p.max_x();
                        max_y = p.max_y();
                        min_x = p.min_x();
                        min_y = p.min_y();
                        //-----------------------------
                        return;
                    }

                }
            }
            mark_flag = true;
            first_mark = e.Location;
            end_mark = e.Location;

            mark.Clear();//очищение массива выделенных
            max_x = 0;
            max_y = 0;
            min_x = pictureBox1.Width;
            min_y = pictureBox1.Height;
            OnChange = true; // Изменения в файле
            pictureBox1.Refresh();
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (point_mv)
            {
                animac = true;
                if (e.X > 0 && e.X < pictureBox1.Width &&
                    e.Y > 0 && e.Y < pictureBox1.Height)
                {
                    collection[mark[0]].list[number_point] = e.Location;
                }
            }

            if (line_mv)
            {
                Point temp = new Point();

                int sdvig_x = e.Location.X - pp.X;
                int sdvig_y = e.Location.Y - pp.Y;

                int max_xt = 0;
                int max_yt = 0;
                int min_xt = pictureBox1.Width;
                int min_yt = pictureBox1.Height;
                foreach (var p in mark)
                {
                    if (collection[p].max_x() > max_xt)
                        max_xt = collection[p].max_x();
                    if (collection[p].max_y() > max_yt)
                        max_yt = collection[p].max_y();
                    if (collection[p].min_x() < min_xt)
                        min_xt = collection[p].min_x();
                    if (collection[p].min_y() < min_yt)
                        min_yt = collection[p].min_y();
                }
                max_x = max_xt; min_x = min_xt;
                max_y = max_yt; min_y = min_yt;
                
                List<item> temp_list = new List<item>();

                foreach (var p in mark)
                {
                    temp_list.Add(new item());
                    for (int i = 0; i < collection[p].list.Count; i++)
                    {
                        temp = collection[p].list[i];
                        temp.X = collection[p].list[i].X + sdvig_x;
                        temp.Y = collection[p].list[i].Y + sdvig_y;
                        temp_list.Last().list.Add(temp);
                    }
                }

                bool f = true;
                foreach (var p in temp_list)
                {
                    if (p.max_x() > pictureBox1.Width || p.max_y() > pictureBox1.Height ||
                        p.min_x() < 0 || p.min_y() < 0)
                    {
                        f = false;
                        break;
                    }
                }

                if (f)
                {
                    for (int i = 0; i < mark.Count; i++)
                    {
                        collection[mark[i]] = temp_list[i];
                    }

                    max_x = max_x + sdvig_x;
                    min_x = min_x + sdvig_x;
                    max_y = max_y + sdvig_y;
                    min_y = min_y + sdvig_y;
                }

                
                pictureBox1.Refresh();

                pp = e.Location;
            }

            if (mark_flag)
            {
                end_mark = e.Location;
            }

            pictureBox1.Refresh();
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (point_mv && animac)
            {
                blinksRemain = 3;

                blinkTimer.Interval = 200;
                blinkTimer.Start();
            }

            if (mark_flag)
            {
                Point t1 = first_mark; //точка начала выделяемой области (прямоугольника)
                Point t2 = end_mark; //точка конца выделяемой области (прямоугольника)

                //--------------------------------------------------------------
                // Определение реальных левой верхней точки и правой нижней точки

                if (end_mark.X > first_mark.X && end_mark.Y > first_mark.Y)
                { t1 = first_mark; t2 = end_mark; }
                if (end_mark.X > first_mark.X && end_mark.Y < first_mark.Y)
                { t1.Y = end_mark.Y; t2.Y = first_mark.Y; }
                if (end_mark.X < first_mark.X && end_mark.Y > first_mark.Y)
                { t1.X = end_mark.X; t2.X = first_mark.X; }
                if (end_mark.X < first_mark.X && end_mark.Y < first_mark.Y)
                { t1 = end_mark; t2 = first_mark; }

                //----------------------------------------------------------

                int i = -1;
                foreach (var p in collection)
                {
                    i++;

                    if (p.max_x() < t2.X && p.min_x() > t1.X &&
                      p.max_y() < t2.Y && p.min_y() > t1.Y)
                    {
                        mark.Add(i);
                        continue;
                    }

                    if ((p.list.First().Y - p.list.Last().Y) != 0)
                    {
                        int temp1 = (-1) * ((p.list.Last().X - p.list.First().X) * t1.Y + (p.list.First().X * p.list.Last().Y - p.list.First().Y * p.list.Last().X)) / (p.list.First().Y - p.list.Last().Y);
                        int temp2 = (-1) * ((p.list.Last().X - p.list.First().X) * t2.Y + (p.list.First().X * p.list.Last().Y - p.list.First().Y * p.list.Last().X)) / (p.list.First().Y - p.list.Last().Y);

                        if (Math.Max(p.list.First().Y, p.list.Last().Y) > t1.Y &&
                            Math.Min(p.list.First().Y, p.list.Last().Y) < t2.Y &&
                            Math.Max(p.list.First().X, p.list.Last().X) > t1.X &&
                            Math.Min(p.list.First().X, p.list.Last().X) < t2.X &&
                            ((temp1 >= t1.X && temp1 <= t2.X) ||
                            (temp2 >= t1.X && temp2 <= t2.X))
                            )
                        {
                            mark.Add(i);
                            continue;
                        }
                    }

                    if (p.list.First().X - p.list.Last().X != 0)
                    {
                        int temp1 = (-1) * ((p.list.First().Y - p.list.Last().Y) * t1.X + (p.list.First().X * p.list.Last().Y - p.list.First().Y * p.list.Last().X)) / (p.list.Last().X - p.list.First().X);
                        int temp2 = (-1) * ((p.list.First().Y - p.list.Last().Y) * t2.X + (p.list.First().X * p.list.Last().Y - p.list.First().Y * p.list.Last().X)) / (p.list.Last().X - p.list.First().X);

                        if (Math.Max(p.list.First().Y, p.list.Last().Y) > t1.Y &&
                            Math.Min(p.list.First().Y, p.list.Last().Y) < t2.Y &&
                            Math.Max(p.list.First().X, p.list.Last().X) > t1.X &&
                            Math.Min(p.list.First().X, p.list.Last().X) < t2.X &&
                            ((temp1 >= t1.Y && temp1 <= t2.Y) ||
                            (temp2 >= t1.Y && temp2 <= t2.Y))
                            )
                        {
                            mark.Add(i);
                            continue;
                        }
                    }

                    for (int j = 0; j < p.list.Count() - 1; j++)
                    {
                        if ((p.list[j].Y - p.list[j + 1].Y) != 0)
                        {
                            int temp1 = (-1) * ((p.list[j + 1].X - p.list[j].X) * t1.Y + (p.list[j].X * p.list[j + 1].Y - p.list[j].Y * p.list[j + 1].X)) / (p.list[j].Y - p.list[j + 1].Y);
                            int temp2 = (-1) * ((p.list[j + 1].X - p.list[j].X) * t2.Y + (p.list[j].X * p.list[j + 1].Y - p.list[j].Y * p.list[j + 1].X)) / (p.list[j].Y - p.list[j + 1].Y);

                            if (Math.Max(p.list[j].Y, p.list[j + 1].Y) > t1.Y &&
                                Math.Min(p.list[j].Y, p.list[j + 1].Y) < t2.Y &&
                                Math.Max(p.list[j].X, p.list[j + 1].X) > t1.X &&
                                Math.Min(p.list[j].X, p.list[j + 1].X) < t2.X &&
                                ((temp1 >= t1.X && temp1 <= t2.X) ||
                                (temp2 >= t1.X && temp2 <= t2.X))
                                )
                            {
                                mark.Add(i);
                                continue;
                            }
                        }

                        if (p.list[j].X - p.list[j + 1].X != 0)
                        {
                            int temp1 = (-1) * ((p.list[j].Y - p.list[j + 1].Y) * t1.X + (p.list[j].X * p.list[j + 1].Y - p.list[j].Y * p.list[j + 1].X)) / (p.list[j + 1].X - p.list[j].X);
                            int temp2 = (-1) * ((p.list[j].Y - p.list[j + 1].Y) * t2.X + (p.list[j].X * p.list[j + 1].Y - p.list[j].Y * p.list[j + 1].X)) / (p.list[j + 1].X - p.list[j].X);

                            if (Math.Max(p.list[j].Y, p.list[j + 1].Y) > t1.Y &&
                                Math.Min(p.list[j].Y, p.list[j + 1].Y) < t2.Y &&
                                Math.Max(p.list[j].X, p.list[j + 1].X) > t1.X &&
                                Math.Min(p.list[j].X, p.list[j + 1].X) < t2.X &&
                                ((temp1 >= t1.Y && temp1 <= t2.Y) ||
                                (temp2 >= t1.Y && temp2 <= t2.Y))
                                )
                            {
                                mark.Add(i);
                                continue;
                            }
                        }

                    }
                }

                //-----------------------------------
                //определение границ локальной области
                foreach (var p in mark)
                {
                    if (collection[p].max_x() > max_x)
                        max_x = collection[p].max_x();
                    if (collection[p].max_y() > max_y)
                        max_y = collection[p].max_y();
                    if (collection[p].min_x() < min_x)
                        min_x = collection[p].min_x();
                    if (collection[p].min_y() < min_y)
                        min_y = collection[p].min_y();
                }
                //----------------------------------

            }

            mark_flag = false;
            line_mv = false;
            point_mv = false;

            OnChange = true; // Изменения в файле
            pictureBox1.Refresh();
        }

        private void button_del_Click(object sender, EventArgs e)
        {
            List<item> temp = new List<item>();
 
            foreach (var p in mark)
            {
                temp.Add(collection[p]);
            }

            max_x = 0;
            max_y = 0;
            min_x = pictureBox1.Width;
            min_y = pictureBox1.Height;
            mark.Clear();

            foreach (var p in temp)
            {
                collection.Remove(p);
            }

            pictureBox1.Refresh();
        }


        private void Move_Element(object sender, EventArgs e)
        {
            Point temp;

            /*
            if (textBox_sdvig_x.Text == "" || textBox_sdvig_x.Text == "-" || textBox_sdvig_y.Text == "" || textBox_sdvig_y.Text == "-")
            {
                MessageBox.Show(" Введите смещение по Х и по У в px ", "Предупреждение", MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }*/


            int move_x = Convert.ToInt32(textBox_Move_x.Text);

            int move_y = Convert.ToInt32(textBox_Move_y.Text);

            if (    (max_x + move_x)<pictureBox1.Width && (min_x + move_x)>0 && (max_y - move_y)<pictureBox1.Height && (min_y - move_y)>0)
            //max_y + sdvig < pictureBox1.Height && min_y + sdvig > 0
            {
                foreach (var p in mark)
                {

                    for (int i = 0; i < collection[p].list.Count; i++ )
                    {
                        temp = collection[p].list[i];
                        temp.X = collection[p].list[i].X + move_x;
                        temp.Y = collection[p].list[i].Y - move_y;

                        if (temp.X < pictureBox1.Width && temp.Y < pictureBox1.Height)
                        {
                            collection[p].list[i] = temp;
                        }
                        else
                        {
                            MessageBox.Show(" Элементы не должны выходить за границы! ", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                    }
                }
                max_x = max_x + move_x;
                min_x = min_x + move_x;
                max_y = max_y - move_y;
                min_y = min_y - move_y;

                OnChange = true; // Изменения в файле

                pictureBox1.Refresh();
            }
            else
            {
                MessageBox.Show(" Элементы не должны выходить за границы! ", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void button_mirror_Click(object sender, EventArgs e)
        {
            if (checkBox_x.Checked == false && checkBox_y.Checked == false && checkBox_O.Checked == false)
            {
                MessageBox.Show(" Выберете ось! ", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (radioButton_global.Checked)
            {
                Point centr = new Point(pictureBox1.Width / 2, pictureBox1.Height / 2);

                if (checkBox_x.Checked)
                {
                    foreach (var p in mark)
                    {
                        for (int i = 0; i < collection[p].list.Count; i++)
                        {
                            // masiv[index_vid].A.Y = masiv[index_vid].A.Y + 2 * (pictureBox1.Height / 2 - masiv[index_vid].A.Y);
                            Point temp = collection[p].list[i];
                            temp.Y = temp.Y + 2 * (centr.Y - temp.Y);
                            collection[p].list[i] = temp;
                        }
                    }
                }

                if (checkBox_y.Checked)
                {
                    foreach (var p in mark)
                    {
                        for (int i = 0; i < collection[p].list.Count; i++)
                        {
                            Point temp = collection[p].list[i];
                            temp.X = temp.X + 2 * (centr.X - temp.X);
                            collection[p].list[i] = temp;
                        }
                    }
                }

                if (checkBox_O.Checked)
                {
                    foreach (var p in mark)
                    {
                        for (int i = 0; i < collection[p].list.Count; i++)
                        {
                            Point temp = collection[p].list[i];
                            temp.X = temp.X + 2 * (centr.X - temp.X);
                            temp.Y = temp.Y + 2 * (centr.Y - temp.Y);
                            collection[p].list[i] = temp;
                        }
                    }
                }
            }

            if (radioButton_local.Checked)
            {
                Point centr = new Point(min_x + (max_x - min_x) / 2, min_y + (max_y - min_y) / 2);

                if (checkBox_x.Checked)
                {
                    foreach (var p in mark)
                    {
                        for (int i = 0; i < collection[p].list.Count; i++)
                        {
                            // masiv[index_vid].A.Y = masiv[index_vid].A.Y + 2 * (pictureBox1.Height / 2 - masiv[index_vid].A.Y);
                            Point temp = collection[p].list[i];
                            temp.Y = temp.Y + 2 * (centr.Y - temp.Y);
                            collection[p].list[i] = temp;
                        }
                    }
                }

                if (checkBox_y.Checked)
                {
                    foreach (var p in mark)
                    {
                        for (int i = 0; i < collection[p].list.Count; i++)
                        {
                            Point temp = collection[p].list[i];
                            temp.X = temp.X + 2 * (centr.X - temp.X);
                            collection[p].list[i] = temp;
                        }
                    }
                }

                if (checkBox_O.Checked)
                {
                    foreach (var p in mark)
                    {
                        for (int i = 0; i < collection[p].list.Count; i++)
                        {
                            Point temp = collection[p].list[i];
                            temp.X = temp.X + 2 * (centr.X - temp.X);
                            temp.Y = temp.Y + 2 * (centr.Y - temp.Y);
                            collection[p].list[i] = temp;
                        }
                    }
                }
            }

            OnChange = true; // Изменения в файле
            pictureBox1.Refresh();
        }

        private void checkBox_x_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_x.Checked == true)
            {
                checkBox_y.Checked = false;
                checkBox_O.Checked = false;
            }
        }

        private void checkBox_y_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_y.Checked == true)
            {
                checkBox_x.Checked = false;
                checkBox_O.Checked = false;
            }
        }

        private void checkBox_O_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_O.Checked == true)
            {
                checkBox_x.Checked = false;
                checkBox_y.Checked = false;
            }
        }

        private void button_povorot_Click(object sender, EventArgs e)
        {
            /*
            if (textBox_pov.Text == "")
            {
                MessageBox.Show(" Введите угол повортоа в градусах. ", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }*/

            double gg = 180.0 * 1.0 / (355.0 / 113.0) * 1.0;//вспомогательная переменная
            double gradus = Convert.ToDouble(textBox_Gradus.Text) / (gg);//перевод градосов в радианов
            //MessageBox.Show(Convert.ToString( gradus));
            int max_xt, max_yt, min_xt, min_yt;

            if (radioButton_global.Checked)
            {
                Point centr = new Point(pictureBox1.Width / 2, pictureBox1.Height / 2);
                List<item> temp = new List<item>();

                Point a = new Point();

                foreach (var p in mark)
                {
                    temp.Add(new item());

                    for (int i = 0; i < collection[p].list.Count; i++)
                    {
                        Point A = new Point(collection[p].list[i].X - centr.X, centr.Y - collection[p].list[i].Y);

                        a.X = Convert.ToInt32(A.X * Math.Cos(gradus) - A.Y * Math.Sin(gradus)) + centr.X;
                        //MessageBox.Show(Convert.ToString(a.X));
                        a.Y = centr.Y - Convert.ToInt32(A.X * Math.Sin(gradus) + A.Y * Math.Cos(gradus));

                        temp.Last().list.Add(a);
                        OnChange = true; // Изменения в файле
                        pictureBox1.Refresh();
                    }
                }

                if (temp.Count > 0)
                {
                    max_xt = temp[0].max_x();
                    max_yt = temp[0].max_y();
                    min_xt = temp[0].min_x();
                    min_yt = temp[0].min_y();

                    foreach (var p in temp)
                    {
                        if (p.max_x() > max_xt)
                            max_xt = p.max_x();
                        if (p.max_y() > max_yt)
                            max_yt = p.max_y();
                        if (p.min_x() < min_xt)
                            min_xt = p.min_x();
                        if (p.min_y() < min_yt)
                            min_yt = p.min_y();
                    }

                    if (max_xt < pictureBox1.Width && min_xt > 0 &&
                        max_yt < pictureBox1.Height && min_yt > 0)
                    {
                        max_x = max_xt;
                        min_x = min_xt;
                        max_y = max_yt;
                        min_y = min_yt;

                        for (int i = 0; i < mark.Count; i++)
                        {
                            collection[mark[i]] = temp[i];
                        }
                    }
                    else
                        MessageBox.Show(" Элементы не должны выходить за границы! ", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

            if (radioButton_local.Checked)
            {
                Point centr = new Point(min_x + (max_x - min_x) / 2, min_y + (max_y - min_y) / 2);
                List<item> temp = new List<item>();

                Point a = new Point();

                foreach (var p in mark)
                {
                    temp.Add(new item());

                    for (int i = 0; i < collection[p].list.Count; i++)
                    {
                        Point A = new Point(collection[p].list[i].X - centr.X, centr.Y - collection[p].list[i].Y);

                        a.X = Convert.ToInt32(A.X * Math.Cos(gradus) - A.Y * Math.Sin(gradus)) + centr.X;
                        //MessageBox.Show(Convert.ToString(a.X));
                        a.Y = centr.Y - Convert.ToInt32(A.X * Math.Sin(gradus) + A.Y * Math.Cos(gradus));

                        temp.Last().list.Add(a);
                        OnChange = true; // Изменения в файле
                        pictureBox1.Refresh();
                    }
                }

                if (temp.Count > 0)
                {
                    max_xt = temp[0].max_x();
                    max_yt = temp[0].max_y();
                    min_xt = temp[0].min_x();
                    min_yt = temp[0].min_y();

                    foreach (var p in temp)
                    {
                        if (p.max_x() > max_xt)
                            max_xt = p.max_x();
                        if (p.max_y() > max_yt)
                            max_yt = p.max_y();
                        if (p.min_x() < min_xt)
                            min_xt = p.min_x();
                        if (p.min_y() < min_yt)
                            min_yt = p.min_y();
                    }

                    if (max_xt < pictureBox1.Width && min_xt > 0 &&
                        max_yt < pictureBox1.Height && min_yt > 0)
                    {
                        max_x = max_xt;
                        min_x = min_xt;
                        max_y = max_yt;
                        min_y = min_yt;

                        for (int i = 0; i < mark.Count; i++)
                        {
                            collection[mark[i]] = temp[i];
                        }
                    }
                    else
                        MessageBox.Show(" Элементы не должны выходить за границу! ", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            
            }


            pictureBox1.Refresh();
        }

        private void button_zoom(object sender, EventArgs e)
        {
            /*if (textBox_razmer_x.Text == "" || textBox_razmer_x.Text == "-" || textBox_razmer_y.Text == "" || textBox_razmer_y.Text == "-")
            {
                MessageBox.Show(" Введите коофициенты масштабирования по Х и по У! ", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }*/

            double zoom_x = Convert.ToDouble(textBox_Zoom_x.Text);
            double zoom_y = Convert.ToDouble(textBox_Zoom_y.Text);
            int max_xt, max_yt, min_xt, min_yt;  

            if (radioButton_global.Checked)
            {
                
                Point centr = new Point(pictureBox1.Width / 2, pictureBox1.Height / 2);
                List<item> temp = new List<item>();

                Point a = new Point();

                foreach (var p in mark)
                {
                    temp.Add(new item());

                    for (int i = 0; i < collection[p].list.Count; i++)
                    {
                        a = collection[p].list[i];

                        a.X = Convert.ToInt32((a.X - centr.X) * zoom_x) + centr.X;
                        a.Y = Convert.ToInt32((a.Y - centr.Y) * zoom_y) + centr.Y;

                        temp.Last().list.Add(a);
                    }
                }

                if (temp.Count > 0)
                {
                    max_xt = temp[0].max_x();
                    min_xt = temp[0].min_x();
                    max_yt = temp[0].max_y();
                    min_yt = temp[0].min_y();

                    foreach (var p in temp)
                    {
                        if (p.max_x() > max_xt)
                            max_xt = p.max_x();
                        
                        if (p.min_x() < min_xt)
                            min_xt = p.min_x();

                        if (p.max_y() > max_yt)
                            max_yt = p.max_y();

                        if (p.min_y() < min_yt)
                            min_yt = p.min_y();
                        
                    }

                    if (max_xt < pictureBox1.Width && min_xt > 0 && max_yt < pictureBox1.Height && min_yt > 0)
                    {
                        max_y = max_yt;
                        min_y = min_yt;

                        max_x = max_xt;
                        min_x = min_xt;
                        
                        for (int i = 0; i < mark.Count; i++)
                        {
                            collection[mark[i]] = temp[i];
                        }
                    }
                    else
                        MessageBox.Show(" Элементы не должны выходить за границу! ", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }

            if (radioButton_local.Checked)
            {
                Point centr = new Point(min_x + (max_x - min_x) / 2, min_y + (max_y - min_y) / 2);
                List<item> temp = new List<item>();
                Point a = new Point();

                foreach (var p in mark)
                {
                    temp.Add(new item());
                    for (int i = 0; i < collection[p].list.Count; i++)
                    {
                        a = collection[p].list[i];
                        a.X = Convert.ToInt32((a.X - centr.X) * zoom_x) + centr.X;
                        a.Y = Convert.ToInt32((a.Y - centr.Y) * zoom_y) + centr.Y;
                        temp.Last().list.Add(a);
                    }
                }

                if (temp.Count > 0)
                {
                    max_xt = temp[0].max_x();
                    min_xt = temp[0].min_x();

                    max_yt = temp[0].max_y();
                    min_yt = temp[0].min_y();

                    foreach (var p in temp)
                    {
                        if (p.max_x() > max_xt)
                            max_xt = p.max_x();
                        if (p.min_x() < min_xt)
                            min_xt = p.min_x();
                        if (p.max_y() > max_yt)
                            max_yt = p.max_y();
                        if (p.min_y() < min_yt)
                            min_yt = p.min_y();
                    }

                    if (max_xt < pictureBox1.Width && min_xt > 0 && max_yt < pictureBox1.Width && min_yt > 0)
                    {
                        max_x = max_xt;
                        min_x = min_xt;

                        max_y = max_yt;
                        min_y = min_yt;

                        for (int i = 0; i < mark.Count; i++)
                        {
                            collection[mark[i]] = temp[i];
                        }
                    }
                    else
                        MessageBox.Show(" Элементы не должны выходить за границу! ", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            OnChange = true; // Изменения в файле
            pictureBox1.Refresh();
        }


        private void сохранитьКакToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (collection.Count == 0)
            {
                MessageBox.Show(" Вы ничего не создали... ", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Stream myStream;
            SaveFileDialog sfd = new SaveFileDialog();

            sfd.Filter = "sin file (*.sin)|*.sin|All files (*.*)|*.*";
            sfd.FilterIndex = 1;
            sfd.RestoreDirectory = true;

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                if ((myStream = sfd.OpenFile()) != null)
                {
                    BinaryFormatter bf = new BinaryFormatter();

                    bf.Serialize(myStream, collection);
                    bf.Serialize(myStream, mark);
                    bf.Serialize(myStream, Animation);
                    bf.Serialize(myStream, Cadr_id);
                    //bf.Serialize(myStream, Animation);

                    //this.richTextBox1.Text += "Сохранено\n";

                    myStream.Close();
                    OnSaving = true; // Файл Сохранен
                    OnChange = false; // Сохранены изменения
                }
            }
            FileName = sfd.FileName;

        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (collection.Count == 0)
            {
                MessageBox.Show(" Вы ничего не создали... ", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (FileName == "")
            {
                Stream myStream;
                SaveFileDialog sfd = new SaveFileDialog();

                sfd.Filter = "sin file (*.sin)|*.sin|All files (*.*)|*.*";
                sfd.FilterIndex = 1;
                sfd.RestoreDirectory = true;

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    if ((myStream = sfd.OpenFile()) != null)
                    {
                        BinaryFormatter bf = new BinaryFormatter();

                        bf.Serialize(myStream, collection);
                        bf.Serialize(myStream, mark);
                        bf.Serialize(myStream, Animation);
                        bf.Serialize(myStream, Cadr_id);
                        //bf.Serialize(myStream, Animation);
                        //this.richTextBox1.Text += "Сохранено\n";

                        myStream.Close();

                        OnChange = false; // Сохранены изменения
                        OnSaving = true; // Файл Сохранен
                    }
                }
                FileName = sfd.FileName;

            }
            else
            {
                FileStream fs2 = new FileStream(FileName, FileMode.Create);

                BinaryFormatter bf = new BinaryFormatter();

                bf.Serialize(fs2, collection);
                bf.Serialize(fs2, mark);
                bf.Serialize(fs2, Animation);
                bf.Serialize(fs2, Cadr_id);
                //this.richTextBox1.Text += "Сохранено\n";

                fs2.Flush();
                fs2.Close();

                OnSaving = true; // Файл Сохранен
                OnChange = false; // Сохранены изменения
            }
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            collection.Clear();
            mark.Clear();

            Stream myStream = null;
            OpenFileDialog ofd = new OpenFileDialog();

            ofd.InitialDirectory = "C:\\Users\\Hichas\\Desktop";
            ofd.Filter = "sin file (*.sin)|*.sin|All files (*.*)|*.*";

            ofd.FilterIndex = 1;
            ofd.RestoreDirectory = true;

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                if ((myStream = ofd.OpenFile()) != null)
                {
                    using (myStream)
                    {
                        BinaryFormatter bf = new BinaryFormatter();
                        collection = (List<item>)bf.Deserialize(myStream);
                        mark = (List<int>)bf.Deserialize(myStream);
                        Animation = (Dictionary<int,List<item>>)bf.Deserialize(myStream);
                        Cadr_id = (int)bf.Deserialize(myStream);
                        All_cadr = Animation.Count;

                        // Меняем надписи на лейблах
                        Cadr_Text.Text = "Текщий кадр: " + Cadr_id;
                        All_cadr_text.Text = "Всего кадров: " + All_cadr;
                       
                        //Animation = (Dictionary<int,List<item>>)bf.Deserialize(myStream);
                    }
                    
                }
                FileName = ofd.FileName;

            }

            OnLoading = true;
        }

        private void оПрограмеToolStripMenuItem_Click(object sender, EventArgs e)
        {
                   MessageBox.Show(" Предмет: Компьютерная графика \n Выполнил: Калин Глеб ЭВТ-12 \n Проверяет: Олег Сергеевич", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void выйтиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }  

        private void Exit_program_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (OnLoading == false && OnSaving == false || OnChange == true)
            {
                DialogResult Result = new DialogResult();
                Result = MessageBox.Show("Вы хотите перед выходом сохранить файл?", "Подтверждение", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Asterisk);

                if (DialogResult.Yes == Result)
                {
                    сохранитьКакToolStripMenuItem_Click(sender, e);
                }
                if (DialogResult.Cancel == Result)
                {
                    e.Cancel = true;
                }


            }
            else
            {
                if (DialogResult.OK != MessageBox.Show("Вы действительно хотите выйти?", "Подтверждение", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk))
                    e.Cancel = true;
            }
        }

        private void отрезокToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button_add2_Click(sender, e);
        }

        private void треугольникToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button_add3_Click(sender, e);
        }

        private void четырехугольникToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button_add4_Click(sender, e);
        }

        private void очиститьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mark.Clear();
            collection.Clear();
            pictureBox1.Refresh();
        }


        static double k_w = 0; // Кофф. по ширине
        static double k_h = 0; // Кофф. по высоте


        private void Resize_all()
        {

            k_w = this.Width / pictureBox1.Width;
            k_h = this.Height / pictureBox1.Height;

                int new_w = Convert.ToInt32(pictureBox1.Width * k_w);
                int new_h = Convert.ToInt32(pictureBox1.Height * k_h);

                this.pictureBox1.Size = new System.Drawing.Size(new_w, new_h); 
        }

        private void button_Add_Cadr_Click(object sender, EventArgs e)
        {
            mark.Clear();

            if (Cadr_id == Animation.Count)
            {
                Animation.Remove(Cadr_id);
                Animation.Add(Cadr_id, new List<item>(collection));

                collection.Clear(); // Очищаем коллецию, так как новый кадр     

                // Увеличиваем счетчики кадров
                Cadr_id++;
                All_cadr++;

                Cadr_Text.Text = "Текщий кадр: " + Cadr_id;
                All_cadr_text.Text = "Всего кадров: " + All_cadr;

                pictureBox1.Refresh(); // Очищаем пикчер

                //Animation.Add(Cadr_id, new List<item>(collection));  // Записываем текуий кадр в коллекцию
            }
            else
            {

                // обновляем кадр
                Animation.Remove(Cadr_id);
                Animation.Add(Cadr_id, new List<item>(collection));
                //----------------------------------

                collection.Clear(); // Очищаем коллецию, так как новый кадр 

                // Создаем времменую коллекцию для хранения кадров
                Dictionary<int, List<item>> Temp_Animation = new Dictionary<int, List<item>>();

                // Цикл перезаписи коллекции после удаления кадра
                foreach (KeyValuePair<int, List<item>> kvp in Animation)
                {
                    int Key = kvp.Key;


                    if (Key > Cadr_id)
                    {
                        if (Key == (Cadr_id+1))
                        {
                            Temp_Animation.Add(Key, new List<item>());
                        }
                        
                        Key++;
                        Temp_Animation.Add(Key, new List<item>(kvp.Value));
                    }
                    else
                    {
                        Temp_Animation.Add(Key, new List<item>(kvp.Value));
                    }

                }

                Animation.Clear();

                foreach (KeyValuePair<int, List<item>> kvp in Temp_Animation)
                {
                    int Key = kvp.Key;

                    Animation.Add(Key, new List<item>(kvp.Value));
                }

                // Увеличиваем счетчики кадров
                Cadr_id++;
                All_cadr++;

                Cadr_Text.Text = "Текщий кадр: " + Cadr_id;
                All_cadr_text.Text = "Всего кадров: " + All_cadr;

                pictureBox1.Refresh(); // Очищаем пикчер

            }
                

        }

        private void button_Delete_card_Click(object sender, EventArgs e) // Кнопка удаления кадра
        {
            mark.Clear();

            if (All_cadr > 1) // Для удаления нужно больше 1 кадра
            {
                Animation.Remove(Cadr_id); // Удаляем текущий кадр

                // Создаем времменую коллекцию для хранения кадров
                Dictionary<int, List<item>> Temp_Animation = new Dictionary<int, List<item>>(Animation);

                Animation.Clear();

                // Цикл перезаписи коллекции после удаления кадра
                foreach (KeyValuePair<int, List<item>> kvp in Temp_Animation)
                {
                    int Key = kvp.Key;

                    if (Key > Cadr_id)
                    {
                        Key--;
                        Animation.Add(Key, new List<item>(kvp.Value));
                    }
                    else
                    {
                        Animation.Add(Key, new List<item>(kvp.Value));
                    }

                }

                Temp_Animation.Clear();

                collection.Clear(); // Очищаем коллецию, так как новый кадр

                if (Cadr_id > 1) // Если кадрне не первый, то уменьшаем номер кадра
                {
                    // Убираем кадр
                    Cadr_id--;
                }

                All_cadr--; // Кол-во кадров

                collection = Animation[Cadr_id]; // Запихиваем элементы для отображения в коллекцию
                pictureBox1.Refresh(); // Обновляем пикчер


                // Меняем надписи на лейблах
                Cadr_Text.Text = "Текщий кадр: " + Cadr_id;
                All_cadr_text.Text = "Всего кадров: " + All_cadr;
            }
            else
            {
                MessageBox.Show(" У вас один кадр, удаление невозможно! ", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

                
              
        }

        private void button_Next_cadr_Click(object sender, EventArgs e)
        {
            if (Cadr_id != All_cadr)
            {
                collection.Clear();
                mark.Clear();

                Cadr_id++;

                collection = Animation[Cadr_id];

                Cadr_Text.Text = "Текщий кадр: " + Cadr_id;

                pictureBox1.Refresh();
            }
           
        }

        private void button_Prev_cadr_Click(object sender, EventArgs e)
        {
            if (Cadr_id != 1)
            {
                collection.Clear();
                mark.Clear();

                Cadr_id--;

                collection = Animation[Cadr_id];
                pictureBox1.Refresh();

                Cadr_Text.Text = "Текщий кадр: " + Cadr_id;
            }
            
        }
  


        private void numericUpDown_Move_y_KeyPress(object sender, KeyPressEventArgs e)
        {
            /*
            string input = Convert.ToString(numericUpDown_Move_y.Value);


            if (!Regex.IsMatch(input, "^([-]?[0-9]+[.]?[0-9]*)$"))
            {
                MessageBox.Show(" Вам нельзя вводить такое! ", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Handled = true;
            }*/
        }

        private void numericUpDown_Move_y_KeyDown(object sender, KeyEventArgs e)
        {
            /*
            var regex = new Regex("^-?\\d*(\\.\\d+)?$");

            string input = Convert.ToString(numericUpDown_Move_y.Value);

            if (!regex.IsMatch(input))
            {
                MessageBox.Show(" Вам нельзя вводить такое! ", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Handled = true;
            }*/

        }



        public bool isValidNumber(string exp)
        {
            //string expr = "^([-]?[0-9]+[^-]?[0-9]*)$";

            /*
            if (!Regex.IsMatch(exp, "^(-?[0-9]+[.]?[0-9]*)$"))
            {
                //MessageBox.Show(" Вам нельзя вводить такое! ", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
             */
            return true;
        }


        

        private void textBox_Move_y_TextChanged(object sender, EventArgs e)
        {
            string temp = textBox_Move_y.Text;

            for (int i = 0; i < temp.Length; i++)
            {
                if (!(temp[i] >= '0' && temp[i] <= '9') && temp[i] != '-')
                    temp = temp.Remove(i, 1);
            }

            for (int i = 0; i < temp.Length; i++)
            {
                if (temp[i] == '-' && i != 0)
                    temp = temp.Remove(i, 1);
            }

            textBox_Move_y.Text = temp;
            textBox_Move_y.Select(textBox_Move_y.Text.Length, textBox_Move_y.Text.Length);

        }

        private void textBox_Move_x_TextChanged(object sender, EventArgs e)
        {
            string temp = textBox_Move_x.Text;

            for (int i = 0; i < temp.Length; i++)
            {
                if (!(temp[i] >= '0' && temp[i] <= '9') && temp[i] != '-')
                    temp = temp.Remove(i, 1);
            }

            for (int i = 0; i < temp.Length; i++)
            {
                if (temp[i] == '-' && i != 0)
                    temp = temp.Remove(i, 1);
            }

            textBox_Move_x.Text = temp;
            textBox_Move_x.Select(textBox_Move_x.Text.Length, textBox_Move_x.Text.Length);
        }

        private void textBox_Gradus_TextChanged(object sender, EventArgs e)
        {
            string temp = textBox_Gradus.Text;
            int zpt = -1;
            for (int i = 0; i < temp.Length; i++)
            {
                if (!(temp[i] >= '0' && temp[i] <= '9') && temp[i] != '-' && temp[i] != ',')
                    temp = temp.Remove(i, 1);
            }

            for (int i = 0; i < temp.Length; i++)
            {
                if ((temp[i] == '-' && i != 0) || (temp[i] == ',' && i == 0))
                    temp = temp.Remove(i, 1);
            }

            for (int i = 0; i < temp.Length; i++)
            {
                if (temp[i] == ',')
                {
                    zpt = i;
                    break;
                }
            }

            for (int i = 0; i < temp.Length; i++)
            {
                if (temp[i] == ',' && zpt > 0 && i != zpt)
                    temp = temp.Remove(i, 1);
            }

            for (int i = 0; i < temp.Length; i++)
            {
                if ((temp[i] == ',' && i == 1) && temp[0] == '-')
                    temp = temp.Remove(i, 1);
            }

            textBox_Gradus.Select(textBox_Gradus.Text.Length, textBox_Gradus.Text.Length);
            textBox_Gradus.Text = temp;
        }

        private void textBox_Zoom_x_TextChanged(object sender, EventArgs e)
        {
            string temp = textBox_Zoom_x.Text;

            int zpt = -1;
            for (int i = 0; i < temp.Length; i++)
            {
                if (!(temp[i] >= '0' && temp[i] <= '9') && temp[i] != ',')
                    temp = temp.Remove(i, 1);
            }

            for (int i = 0; i < temp.Length; i++)
            {
                if (temp[i] == ',' && i == 0)
                    temp = temp.Remove(i, 1);
            }

            for (int i = 0; i < temp.Length; i++)
            {
                if (temp[i] == ',')
                {
                    zpt = i;
                    break;
                }
            }

            for (int i = 0; i < temp.Length; i++)
            {
                if (temp[i] == ',' && zpt > 0 && i != zpt)
                    temp = temp.Remove(i, 1);
            }

            textBox_Zoom_x.Text = temp;
            textBox_Zoom_x.Select(textBox_Zoom_x.Text.Length, textBox_Zoom_x.Text.Length);
        }

        private void textBox_Zoom_y_TextChanged(object sender, EventArgs e)
        {
            string temp = textBox_Zoom_y.Text;

            int zpt = -1;
            for (int i = 0; i < temp.Length; i++)
            {
                if (!(temp[i] >= '0' && temp[i] <= '9') && temp[i] != ',')
                    temp = temp.Remove(i, 1);
            }

            for (int i = 0; i < temp.Length; i++)
            {
                if (temp[i] == ',' && i == 0)
                    temp = temp.Remove(i, 1);
            }

            for (int i = 0; i < temp.Length; i++)
            {
                if (temp[i] == ',')
                {
                    zpt = i;
                    break;
                }
            }

            for (int i = 0; i < temp.Length; i++)
            {
                if (temp[i] == ',' && zpt > 0 && i != zpt)
                    temp = temp.Remove(i, 1);
            }

            textBox_Zoom_y.Text = temp;
            textBox_Zoom_y.Select(textBox_Zoom_y.Text.Length, textBox_Zoom_y.Text.Length);
        }

        private void button_move_cadr_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(textBox_Cadr.Text) <= All_cadr)
            {
                Cadr_id = Convert.ToInt32(textBox_Cadr.Text);
                collection.Clear();
                mark.Clear();

                collection = Animation[Cadr_id];

                Cadr_Text.Text = "Текщий кадр: " + Cadr_id;

                pictureBox1.Refresh();
            }
            else
            {
                MessageBox.Show(" Такого кадра нет! ", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void textBox_Cadr_TextChanged(object sender, EventArgs e)
        {
            string temp = textBox_Cadr.Text;

            for (int i = 0; i < temp.Length; i++)
            {
                if (!(temp[i] >= '0' && temp[i] <= '9') && temp[i] != '-')
                    temp = temp.Remove(i, 1);
            }

            for (int i = 0; i < temp.Length; i++)
            {
                if (temp[i] == '-')
                    temp = temp.Remove(i, 1);
            }

            textBox_Cadr.Text = temp;
            textBox_Cadr.Select(textBox_Move_x.Text.Length, textBox_Move_x.Text.Length);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Player player_animetion = new Player();

            player_animetion.Show();

            player_animetion.GetData(Animation);
        }

        

  

    }
}
