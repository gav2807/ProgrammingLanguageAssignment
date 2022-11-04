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
    public class Canvas
    {
        Graphics g;
        PictureBox outPutBox;

        public Pen pen;
        public SolidBrush brush;

        public int xPos, yPos;
        public int xPen = 0;
        public int yPen = 0;
        public bool fill = false;

        /// <summary>
        /// This method initiates the output window
        /// </summary>
        /// <param name="g"></param>
        /// <param name="outPutBox"></param>
        public Canvas(Graphics g, PictureBox outPutBox)
        {
            this.g = g;
            xPos = 5;
            yPos = 5;
            pen = new Pen(Color.Blue);
            brush = new SolidBrush(Color.Transparent);
            this.outPutBox = outPutBox;
            MoveTo(5, 5);
        }


        /// <summary>
        /// This method moves the pen to a location
        /// </summary>
        public void MoveTo(int x, int y)
        {
            brush.Color = Color.Gray;
            g.FillEllipse(brush, xPos, yPos, 4, 4);

            xPos = x;
            yPos = y;
            brush.Color = Color.Red;
            g.FillEllipse(brush, x, y, 4, 4);
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
        public void DrawTo(int x, int y)
        {
            g.DrawLine(pen, xPos, yPos, x, y); 
            xPos = x;
            yPos = y;
        }


        /// <summary>
        /// This method clears the output window
        /// </summary>
        public void ClearDrawing()
        {
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
        /// Draw rectangle method is used to draw a rectangle on the output window
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public void DrawRectangle(int width, int height)
        {
            Rectangle rectangle = new Rectangle(xPos, yPos, g, pen, brush);
            rectangle.Draw(width, height);
        }


        /// <summary>
        /// This method is called to draw a circle on our output window
        /// </summary>
        /// <param name="radius"></param>
        public void DrawCircle(float radius)
        {
            Circle circle = new Circle(xPos, yPos, g, pen, brush);
            circle.Draw(radius);
        }


        /// <summary>
        /// This method is called to draw the triangle on our output window
        /// </summary>
        /// <param name="pointsToDraw"></param>
        public void DrawTriangle(PointF[] pointsToDraw)
        {
            g.DrawPolygon(pen, pointsToDraw);//Draw shape using a pen instance 
            g.FillPolygon(brush, pointsToDraw);//Draw shape and fill with a solid brush instance 
        }


        /// <summary>
        /// Fill shape method is called to fill any shape on the output window
        /// </summary>
        public void Fill()
        {
            fill = !fill;
        }

    }
}
