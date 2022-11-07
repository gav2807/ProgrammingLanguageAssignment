using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingLanguageAssignment
{
    public class Shapes
    {
        protected int x, y = 10;
        protected Pen pen;
        protected SolidBrush brush;
        public Shapes (int x, int y, Pen pen, SolidBrush brush)
        {
            this.x = x;
            this.y = y;
            this.pen = pen;
            this.brush = brush;
        }

    }
}
