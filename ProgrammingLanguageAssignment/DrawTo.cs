using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingLanguageAssignment
{
    public class DrawTo : Shapes
    {
        public int start, end;

        public DrawTo(int start, int end, int x, int y, Pen pen, SolidBrush brush) : base(x, y, pen, brush)
        {
            this.start = start;
            this.end = end;
        }

        /// <summary>
        /// This method draws a rectangle
        /// </summary>
        /// <param name="g"></param>
        public void Draw(Graphics g)
        {
            g.DrawLine(pen, x, y, start, end);
            this.x = start;
            this.y = end;
        }


    }
}
