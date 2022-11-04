using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingLanguageAssignment
{
    public class Circle
    {
        public int xPos;
        public int yPos;
        public int radius;
        public Pen pen;
        public SolidBrush brush;
        public Graphics g;

        public Circle(int x, int y, Graphics g, Pen pen, SolidBrush brush)
        {
            xPos = x;
            yPos = y;
            this.pen = pen;
            this.brush = brush;
            this.g = g;
        }

        /// <summary>
        /// This method draws a circle
        /// </summary>
        /// <param name="radius"></param>
        public void Draw(float radius)
        {
            float xpen = (xPos - (radius / 2)) + 2;
            float ypen = (yPos - (radius / 2)) + 2;

            g.DrawEllipse(pen, xpen, ypen, radius, radius);
            g.FillEllipse(brush, xpen, ypen, radius, radius);
        }

        // public static int xpen = (Form1.xbrush - (Form1.width / 2)) + 2;
        // public static int ypen = (Form1.ybrush - (Form1.height / 2)) + 2;
    }
}
