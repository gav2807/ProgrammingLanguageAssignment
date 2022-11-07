using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProgrammingLanguageAssignment
{
    public class Canvas : Shapes
    {
        Graphics g;
        public Pen pen;
        public SolidBrush brush;
        public int xPosition, yPosition;
        public bool fill = false;


        /// <summary>
        /// This method initiates the output window
        /// </summary>
        /// <param name="g"></param>
        /// <param name="outPutBox"></param>
        public Canvas(Graphics g, int x, int y, Pen pen, SolidBrush brush) : base(x, y, pen, brush)
        {
            this.g = g;
            this.pen = new Pen(Color.Black);
            this.brush = new SolidBrush(Color.Transparent);
            this.xPosition = x;
            this.yPosition = y;
            MoveTo(5, 5);
        }


        /// <summary>
        /// This method moves the pen to a location
        /// </summary>
        public void MoveTo(int start, int end)
        {
            brush.Color = Color.Gray;
            g.FillEllipse(brush, xPosition, yPosition, 4, 4);

            xPosition = start;
            yPosition = end;
            brush.Color = Color.Red;
            g.FillEllipse(brush, start, end, 4, 4);
            brush.Color = Color.Transparent;
        }


        /// <summary>
        /// This method draws lines to specified co-ordinates
        /// </summary>
        public void PenColor(string color)
        {
            pen.Color = Color.FromName(color);
        }


        /// <summary>
        /// This method draws lines to specified co-ordinates
        /// </summary>
        public void DrawTo(int start, int end)
        {
            DrawTo drawTo = new DrawTo(start, end, xPosition, yPosition, pen, brush);
            drawTo.Draw(g);
        }


        /// <summary>
        /// This method clears the output window
        /// </summary>
        public void ClearDrawing()
        {
            PenColor("Black");
            g.Clear(Color.Gray);
        }


        /// <summary>
        /// This method clears and resets pen's position 
        /// </summary>
        public void ResetPosition()
        {
            MoveTo(10, 10);
        }


        /// <summary>
        /// Draw rectangle method is used to draw a rectangle.
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public void DrawRectangle(int width, int height)
        {
            Rectangle rectangle = new Rectangle(width, height, xPosition, yPosition, pen, brush);
            rectangle.Draw(g);
        }


        /// <summary>
        /// This method is called to draw a circle.
        /// </summary>
        /// <param name="radius"></param>
        public void DrawCircle(int radius)
        {
            Circle circle = new Circle(radius, xPosition, yPosition, pen, brush);
            circle.Draw(g);
        }


        /// <summary>
        /// This method is called to draw the triangle.
        /// </summary>
        /// <param name="pointsToDraw"></param>
        public void DrawTriangle(PointF[] pointsToDraw)
        {
            Triangle triangle = new Triangle(pointsToDraw, xPosition, yPosition, pen, brush);
            triangle.Draw(g); 
        }


        /// <summary>
        /// This method is called to fill any shape.
        /// </summary>
        public void Fill()
        {
            fill = !fill;
        }

    }
}
