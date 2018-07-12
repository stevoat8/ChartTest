using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChartTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public double Wert1 { get; set; }
        public double Wert2 { get; set; }

        private void DrawPoint(int series, Point point)
        {
            chart1.Series[series - 1].Points.Add(point.X, point.Y);
        }

        private void AddPointBtn_Click(object sender, EventArgs e)
        {
            double xCoord = Convert.ToDouble(inputWert1.Value);
            double yCoord = Convert.ToDouble(inputWert2.Value);
            Point point = new Point(xCoord, yCoord);
            DrawPoint(1, point);
        }

        private void OpenFileBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog()
            {
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
            };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                ImportGraph(dialog.FileName);
            }
        }

        private void ImportGraph(string fileName)
        {
            List<Point> points = new List<Point>();
            string[] lines = File.ReadAllLines(fileName);
            foreach (string line in lines)
            {
                string[] pointStrings = line.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string pointString in pointStrings)
                {
                    Point point = Point.Parse(pointString);
                    points.Add(point);
                }
            }
            CreateChart(points);
        }

        private void CreateChart(IEnumerable<Point> points)
        {
            foreach (Point point in points)
            {
                DrawPoint(1, point);
            }
        }
    }
}
