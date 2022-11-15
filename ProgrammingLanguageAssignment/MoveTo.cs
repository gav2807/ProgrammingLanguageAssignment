using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingLanguageAssignment
{
    public class MoveTo : Shapes
    {
        public int start, end;
        public MoveTo() : base()
        {
            start = end = 0;
        }


        public override void set(int x, int y, Pen pen, SolidBrush brush, params int[] list)
        {
            this.start = list[0];
            this.end = list[1];
            this.x = x;
            this.y = y;
            this.pen = pen;
            this.brush = brush;
        }

        /// <summary>
        /// This method draws a rectangle
        /// </summary>
        /// <param name="g"></param>
        public override void draw(Graphics g)
        {
            this.brush.Color = Color.Gray;
            g.FillEllipse(brush, x, y, 4, 4);

            x = start;
            y = end;
            brush.Color = Color.Red;
            g.FillEllipse(brush, start, end, 4, 4);
            brush.Color = Color.Transparent;
        }

    }
}
