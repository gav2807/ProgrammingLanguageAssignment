using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingLanguageAssignment
{
    public class Rectangle : Shapes
    {
        public int width, height;

        public Rectangle() : base()
        {
            width = height = 0;
        }


        public override void set(int x, int y, Pen pen, SolidBrush brush, params int[] list)
        {
            this.width = list[0];
            this.height = list[1];
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
            float xPosition = (x - (width / 2)) + 2;
            float yPosition = (y - (height / 2)) + 2;

            g.DrawRectangle(pen, xPosition, yPosition, width, height);
            g.FillRectangle(brush, xPosition, yPosition, width, height);
        }
    }
}
