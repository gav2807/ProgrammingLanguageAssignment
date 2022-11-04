using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingLanguageAssignment
{
    public class Triangle
    {

        public int xPos;
        public int yPos;
        public Pen pen;
        public SolidBrush brush;
        public Graphics g;

        public Triangle(int x, int y, Graphics g, Pen pen, SolidBrush brush)
        {
            xPos = x;
            yPos = y;
            this.pen = pen;
            this.brush = brush;
            this.g = g;
        }

        /// <summary>
        /// This method draws a triangle
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public void Draw(PointF[] pointsToDraw)
        {
            // float xpen = (xPos - (width / 2)) + 2;
            // float ypen = (xPos - (height / 2)) + 2;

            g.DrawPolygon(pen, pointsToDraw); 
            g.FillPolygon(brush, pointsToDraw); 

        }
    }
}
