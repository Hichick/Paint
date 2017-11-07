using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace paint
{
    [Serializable]
    public class item
    {
        public List<Point> list = new List<Point>();

        public item()
        { }

        public item(Point A, Point B)
        {
            list.Add(A); list.Add(B);
        }

        public item(Point A, Point B, Point C)
        {
            list.Add(A); list.Add(B); list.Add(C);
        }

        public item(Point A, Point B, Point C, Point D)
        {
            list.Add(A); list.Add(B); list.Add(C); list.Add(D);
        }

        public int max_x()
        {
            int max = Math.Max(list[0].X, list[1].X);
            for (int i = 2; i < list.Count; i++)
            {
                max = Math.Max(max, list[i].X);
            }
            return max;
        }

        public int max_y()
        {
            int max = Math.Max(list[0].Y, list[1].Y);
            for (int i = 2; i < list.Count; i++)
            {
                max = Math.Max(max, list[i].Y);
            }
            return max;
        }

        public int min_x()
        {
            int min = Math.Min(list[0].X, list[1].X);
            for (int i = 2; i < list.Count; i++)
            {
                min = Math.Min(min, list[i].X);
            }
            return min;
        }

        public int min_y()
        {
            int min = Math.Min(list[0].Y, list[1].Y);
            for (int i = 2; i < list.Count; i++)
            {
                min = Math.Min(min, list[i].Y);
            }
            return min;
        }

        public int max(int a, int b)
        {
            return Math.Max(a, b);
        }
        
        public int max(int a, int b, int c)
        {
            return Math.Max(a, Math.Max(b, c));
        }

        public int max(int a, int b, int c, int d)
        {
            return Math.Max(Math.Max(a, b), Math.Max(c, d));
        }

        public int min(int a, int b)
        {
            return Math.Min(a, b);
        }

        public int min(int a, int b, int c)
        {
            return Math.Min(a, Math.Min(b, c));
        }

        public int min(int a, int b, int c, int d)
        {
            return Math.Min(Math.Min(a, b), Math.Min(b, c));
        }
        
    }
}
