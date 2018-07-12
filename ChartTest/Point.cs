using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChartTest
{
    public class Point
    {
        public double X { get; set; }
        public double Y { get; set; }

        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }

        public static Point Parse(string text)
        {
            //PointFormat: ??
            double x = 1.0;
            double y = 1.0;
            return new Point(x, y);
        }
    }
}
