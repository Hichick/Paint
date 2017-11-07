using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace paint
{
    public partial class Player : Form
    {
        public Dictionary<int, List<item>> Animation = new Dictionary<int, List<item>>(); // Коллекция для хранения кадров

        static int Cadr_id = 1; // Текущий кадр
        static int All_Cadr = 1; // Всего кадров

        Timer blinkTimer = new Timer(); //создание таймера

        public Player()
        {
            InitializeComponent();
            blinkTimer.Tick += blinkTimer_Tick; //определение слушателя
            blinkTimer.Interval = (int)numericUpDown_timer.Value;
        }

        void blinkTimer_Tick(object sender, EventArgs e)
        {
            if (Cadr_id == All_Cadr)
            {
                Cadr_id = 1;
            }       
            else
            {
                Cadr_id++;
            }

            pictureBox1.Refresh();
        }

        public void GetData(Dictionary<int, List<item>> First) // Метод для считывания данных и занесение их в форму
        {
            Animation = First;
            All_Cadr = Animation.Count;
            trackBar.Maximum = All_Cadr;

        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Progress_cadr.Text = Cadr_id + "/" + All_Cadr;
            trackBar.Value = Cadr_id;
                             
            Pen pen_line = new Pen(Color.Black);//цвет обычной линии
            SolidBrush brush_point = new SolidBrush(Color.Black);//кисть(цвет) для закраски обычной точки
            Pen pen_line_mark = new Pen(Color.Red);//цвет выделенной линии
            SolidBrush brush_point_mark = new SolidBrush(Color.Red);//кисть(цвет) для закраски выделенной точки

            List<item> collection = Animation[Cadr_id];

            foreach (var p in collection)
            {
                //прорисовка линий элементов
                e.Graphics.DrawLines(pen_line, p.list.ToArray());
                e.Graphics.DrawLine(pen_line, p.list.Last(), p.list.First());
                //--------------------------------------

                //прорисовка точек элементов
                foreach (var q in p.list)
                {
                   // e.Graphics.FillEllipse(brush_point, q.X - 5, q.Y - 5, 10, 10);//
                }
                //---------------------------------------
            }
        }

        private void trackBar_ValueChanged(object sender, EventArgs e)
        {
            Cadr_id = trackBar.Value;
            pictureBox1.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            blinkTimer.Start();
        }

        private void button_stop_Click(object sender, EventArgs e)
        {
            blinkTimer.Stop();
            Cadr_id = 1;
            pictureBox1.Refresh();
        }

        private void button_pause_Click(object sender, EventArgs e)
        {
            blinkTimer.Stop();
        }

        private void numericUpDown_timer_ValueChanged(object sender, EventArgs e)
        {
            blinkTimer.Interval = (int)numericUpDown_timer.Value;
        }




    }
}
