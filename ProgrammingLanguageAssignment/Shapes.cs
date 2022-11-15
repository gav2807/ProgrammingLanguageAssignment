using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingLanguageAssignment
{
    public abstract class Shapes 
    {
        protected int x, y;
        protected Pen pen;
        protected SolidBrush brush;

        public Shapes()
        {
            x = y = 10;
        }
        public Shapes (int x, int y, Pen pen, SolidBrush brush)
        {
            this.x = x;
            this.y = y;
            this.pen = pen;
            this.brush = brush;
        }

        public virtual void set(int x, int y, Pen pen, SolidBrush brush, params int[] list)
        {
            this.x = x;
            this.y = y;
            this.pen = pen;
            this.brush = brush;
        }

        public virtual void draw(Graphics g)
        {
            
        }



    }
}
