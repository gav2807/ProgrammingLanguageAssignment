using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingLanguageAssignment
{
    public class Triangle : Shapes
    {
        public PointF[] points;

        public Triangle(PointF[] pointsToDraw, int x, int y, Pen pen, SolidBrush brush) : base(x, y, pen, brush)
        {
            this.points = pointsToDraw;
        }


        /// <summary>
        /// This method draws a circle
        /// </summary>
        /// <param name="g"></param>
        public void Draw(Graphics g)
        {
            g.DrawPolygon(pen, points);
            g.FillPolygon(brush, points);
        }
    }
}
