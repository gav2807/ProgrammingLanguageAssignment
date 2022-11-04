using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingLanguageAssignment
{
    public class Commands
    {
        private Canvas canvasInstance;
        private RichTextBox commandLine;

        /// <summary>
        /// This method is where the canvas instance and the command line is initiated to take commands and draw on to the outputwindow
        /// </summary>
        /// <param name="canvas"></param>
        /// <param name="CommandLine"></param>
        public Commands(Canvas canvas, RichTextBox CommandLine)
        {
            canvasInstance = canvas;
            commandLine = CommandLine;
        }

        /// <summary>
        /// This method is where commands from the commandline are processed to go through exception handling
        /// Also if the command matches an argument the relevant method is called
        /// </summary>
        /// <param name="canvas"></param>
        /// <param name="Command"></param>
        public void HandleCommand(Canvas canvas, String Command)
        {
                String[] CommandStr = Command.Split(' ');
            
            switch (CommandStr[0])
            {
                case "drawto":DrawTo(CommandStr);
                    break;

                case "moveto": MoveTo(CommandStr);
                    break;

                case "rect": DrawRect(CommandStr);
                    break;

                case "circle":DrawCircle(CommandStr);
                    break;

                case "triangle": DrawTriangle();
                    break;

                case "clear":
                    canvasInstance.ClearDrawing(); 
                    break;

                case "reset": ResetPenPosition();
                    break;

                case "fill": FillShape(CommandStr);
                    break;

                // If none of the cases are met then show this error 
                default:
                    MessageBox.Show(CommandStr + " is invalid.");
                    break;
            }
                
        }

        /// <summary>
        /// Check we have been given the x and y
        /// </summary>
        /// <param name="ParamList"></param>
        private void DrawTo(string[] ParamList)
        {
           
            if (ParamList.Length == 3)
            {
                int x, y = 0;

                try
                {
                    x = Int32.Parse(ParamList[1]);
                }
                catch (FormatException)
                {
                    MessageBox.Show("Unable to parse the parameter " + ParamList[1] + " as an int.");
                    commandLine.Text = "";
                    return;
                }

                try
                {
                    y = Int32.Parse(ParamList[2]);
                }
                catch (FormatException)
                {
                    MessageBox.Show("Unable to parse parameter " + ParamList[2] + " as an int.");
                    commandLine.Text = "";
                    return;
                }

                canvasInstance.DrawTo(x, y);
            }
            else
            {
                MessageBox.Show("Not enough parameters given for DrawTo, please use format of DrawTo 100,200");
                commandLine.Text = "";
            }
        }

        /// <summary>
        /// Check we have been given the x and y parameters
        /// </summary>
        /// <param name="CommandStr"></param>
        private void MoveTo(string[] CommandStr)
        {
            
            if (CommandStr.Length == 3)
            {
                int x, y = 0;

                try
                {
                    x = Int32.Parse(CommandStr[1]);
                }
                catch (FormatException)
                {
                    MessageBox.Show("Unable to parse parameter " + CommandStr[1] + " as an int.");
                    commandLine.Text = "";
                    return;
                }

                try
                {
                    y = Int32.Parse(CommandStr[2]);
                }
                catch (FormatException)
                {
                    MessageBox.Show("Unable to parse parameter " + CommandStr[2] + " as an int.");
                    commandLine.Text = "";
                    return;
                }

                canvasInstance.MoveTo(x, y);
            }
            else
            {
                MessageBox.Show("Not enough parameters given for MoveTo, please use format of MoveTo 100,200");
                commandLine.Text = "";
            }
        }
        /// <summary>
        /// Check we have been given the x and y parameters
        /// </summary>
        /// <param name="ParamList"></param>
        private void DrawRect(string[] ParamList)
        {
            
            if (ParamList.Length == 3)
            {
                int x, y = 0;

                try
                {
                    x = Int32.Parse(ParamList[1]);
                }
                catch (FormatException)
                {
                    MessageBox.Show("Unable to parse parameter " + ParamList[1] + " as an int.");
                    commandLine.Text = "";
                    return;
                }

                try
                {
                    y = Int32.Parse(ParamList[2]);
                }
                catch (FormatException)
                {
                    MessageBox.Show("Unable to parse parameter " + ParamList[2] + " as an int.");
                    commandLine.Text = "";
                    return;
                }

                canvasInstance.DrawRectangle(x, y);
            }
            else
            {
                MessageBox.Show("Not enough parameters given for Rect, please use format of Rect 100,200");
                commandLine.Text = "";
            }
        }
        /// <summary>
        /// Check we have been given the x and y parameters
        /// </summary>
        /// <param name="ParamList"></param>
        private void DrawCircle(string[] ParamList)
        {
            
            if (ParamList.Length == 2)
            {
                int r = 0;

                try
                {
                    r = Int32.Parse(ParamList[1]);
                }
                catch (FormatException)
                {
                    MessageBox.Show("Unable to parse parameter " + ParamList[1] + " as an int.");
                    commandLine.Text = "";
                    return;
                }



                canvasInstance.DrawCircle(r);
            }
            else
            {
                MessageBox.Show("Not enough parameters given for Circle, please use format of circle 100");
                commandLine.Text = "";
            }
        }
        /// <summary>
        /// Create the points that define a triangle.
        /// </summary>
        private void DrawTriangle()
        {
            
            PointF point1 = new PointF(25.0f+canvasInstance.xPosition-25, 0.0f + canvasInstance.yPosition - 25);
            PointF point2 = new PointF(50.0F + canvasInstance.xPosition-25, 50.0F + canvasInstance.yPosition- 25);
            PointF point3 = new PointF(0 +canvasInstance.xPosition- 25, 50.0f +canvasInstance.yPosition- 25);

            PointF[] trianglePoints =
            {
                    point1,
                    point2,
                    point3,
                     };

            canvasInstance.DrawTriangle(trianglePoints);
        }

        /// <summary>
        /// This method is used to reset the pen position on the outputwindow 
        /// </summary>
        private void ResetPenPosition()
        {
            canvasInstance.MoveTo(0, 0);
        }

        /// <summary>
        /// This method is used to fill shapes with the colors the user has defined 
        /// </summary>
        /// <param name="ParamList"></param>
        private void FillShape(string [] ParamList)
        {
            canvasInstance.FillShape();

            if (ParamList.Length == 2)
            {
                string c = ParamList[1];

                switch (c)
                {
                    case "black":
                        canvasInstance.solidBrush.Color = Color.Black;
                        break;

                    case "blue":
                        canvasInstance.solidBrush.Color = Color.Blue;
                        break;

                    case "red":
                        canvasInstance.solidBrush.Color = Color.Red;
                        break;


                }
            }
            else
            {
                MessageBox.Show("Not enough parameters given for fill shape, please use format of fillshape, black");
                commandLine.Text = "";
            }

        }
    }
}
