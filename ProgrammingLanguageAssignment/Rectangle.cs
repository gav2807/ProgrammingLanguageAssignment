using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingLanguageAssignment
{
    public class Rectangle
    {
        public int xPos;
        public int yPos;
        public Pen pen;
        public SolidBrush brush;
        public Graphics g;

        public Rectangle(int x, int y, Graphics g, Pen pen, SolidBrush brush) 
        {
            xPos = x;
            yPos = y;
            this.pen = pen;
            this.brush = brush;
            this.g = g;
        }

        /// <summary>
        /// This method draws a rectangle
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public void Draw(int width, int height)
        {
            float xpen = (xPos - (width / 2)) + 2;
            float ypen = (xPos - (height / 2)) + 2;

            g.DrawRectangle(pen, xpen, ypen, width, height);
            g.FillRectangle(brush, xPos, yPos, xPos + width, yPos + height);
        }
    }
}
