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
        PointF[] points;
        public int sides;

        public Triangle() : base()
        {
            this.sides = 0;
        }


        public override void set(int x, int y, Pen pen, SolidBrush brush, params int[] list)
        {

            this.sides = list[0];
            this.x = x;
            this.y = y;
            this.pen = pen;
            this.brush = brush;

            PointF firstSide = new PointF((x - (sides / 2)) + 2, sides + (y - (sides / 2) + 2));
            PointF secondSide = new PointF(sides + (x - (sides / 2) + 2), sides + (y - (sides / 2) + 2));
            PointF thirdSide = new PointF((sides / 2) + (x - (sides / 2) + 2), (y - (sides / 2) + 2));
            PointF[] trianglePoints = { firstSide, secondSide, thirdSide };
            this.points = trianglePoints;
        }


        /// <summary>
        /// This method draws a rectangle
        /// </summary>
        /// <param name="g"></param>
        public override void draw(Graphics g)
        {
            g.DrawPolygon(pen, points);
            g.FillPolygon(brush, points);
        }

    }
}
