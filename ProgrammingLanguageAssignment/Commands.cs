using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProgrammingLanguageAssignment
{
    public class Commands
    {
        private Canvas canvasInstance;
        private TextBox commandLine;


        /// <summary>
        /// Method for canvas and the command line instance
        /// </summary>
        /// <param name="canvas"></param>
        /// <param name="CommandLine"></param>
        public Commands(Canvas canvas, TextBox CommandLine)
        {
            canvasInstance = canvas;
            commandLine = CommandLine;
        }


        /// <summary>
        /// Method to handle commands from the commandline
        /// </summary>
        /// <param name="Command"></param>
        /// <param name="ProgramStr"></param>
        public void HandleCommand(String Command, String ProgramStr)
        {
            String[] CommandStr = Command.Split(' ');

            switch (CommandStr[0])
            {
                case "moveto":
                    MoveTo(CommandStr);
                    break;

                case "drawto":
                    DrawTo(CommandStr);
                    break;

                case "clear":
                    canvasInstance.ClearDrawing();
                    break;

                case "reset":
                    ResetPenPosition();
                    break;

                case "rect":
                    DrawRectangle(CommandStr);
                    break;

                case "circle":
                    DrawCircle(CommandStr);
                    break;

                case "triangle":
                    DrawTriangle(CommandStr);
                    break;

                case "fill":
                    FillShape(CommandStr);
                    break;

                case "pen":
                    PenColor(CommandStr);
                    break;

                case "run":
                    ProgramWindowCommand(ProgramStr);
                    break;

                default:
                    MessageBox.Show(CommandStr[0] + " is not a valid command.");
                    break;
            }

        }

        private void ProgramWindowCommand(string ProgramStr)
        {
            String[] Commander = ProgramStr.Split(Environment.NewLine.ToCharArray());
            int Loop = 0;

            while (Loop < Commander.Length)
            {
                String[] SingleCommands = Commander[Loop].Split(' ');
                if (SingleCommands[0] == "pen" || SingleCommands[0] == "rect" || SingleCommands[0] == "circle" || SingleCommands[0] == "triangle" || SingleCommands[0] == "moveto" || SingleCommands[0] == "drawto" || SingleCommands[0] == "fill" || SingleCommands[0] == "clear" || SingleCommands[0] == "reset")
                {
                    HandleCommand(Commander[Loop], null);
                }
                Loop++;
            }
        }

        
        /// <summary>
        /// DrawTo command process handler.
        /// </summary>
        /// <param name="Params"></param>
        private void DrawTo(string[] ParamList)
        {
            string[] arguments = ParamList[1].Split(',');

            if (arguments.Length == 2)
            {
                int x, y = 0;

                try
                {
                    x = Int32.Parse(arguments[0]);
                }
                catch (FormatException)
                {
                    MessageBox.Show("Unable to parse X position " + arguments[0] + " as an integer.");
                    commandLine.Text = "";
                    return;
                }

                try
                {
                    y = Int32.Parse(arguments[1]);
                }
                catch (FormatException)
                {
                    MessageBox.Show("Unable to parse Y position " + arguments[1] + " as an integer.");
                    commandLine.Text = "";
                    return;
                }

                canvasInstance.DrawTo(x, y);
            }
            else
            {
                MessageBox.Show("Invalid input. Please use the format: DrawTo 10,20");
                commandLine.Text = "";
            }
        }


        /// <summary>
        /// MoveTo command process handler
        /// </summary>
        /// <param name="ParamList"></param>
        private void MoveTo(string[] ParamList)
        {
            string[] arguments = ParamList[1].Split(',');

            if (arguments.Length == 2)
            {
                int x, y = 0;

                try
                {
                    x = Int32.Parse(arguments[0]);
                }
                catch (FormatException)
                {
                    MessageBox.Show("Unable to parse X axis " + arguments[0] + " as an integer.");
                    commandLine.Text = "";
                    return;
                }

                try
                {
                    y = Int32.Parse(arguments[1]);
                }
                catch (FormatException)
                {
                    MessageBox.Show("Unable to parse Y axis " + arguments[1] + " as an integer.");
                    commandLine.Text = "";
                    return;
                }

                canvasInstance.MoveTo(x, y);
            }
            else
            {
                MessageBox.Show("Invalid input. Please use the format: MoveTo 20,20");
                commandLine.Text = "";
            }
        }
         

        /// <summary>
        /// Rectangle command process handler.
        /// </summary>
        /// <param name="ParamList"></param>
        private void DrawRectangle(string[] ParamList)
        {
            string[] arguments = ParamList[1].Split(',');

            if (arguments.Length == 2)
            {
                int x, y = 0;

                try
                {
                    x = Int32.Parse(arguments[0]);
                }
                catch (FormatException)
                {
                    MessageBox.Show("Unable to parse width " + arguments[0] + " as an integer.");
                    commandLine.Text = "";
                    return;
                }

                try
                {
                    y = Int32.Parse(arguments[1]);
                }
                catch (FormatException)
                {
                    MessageBox.Show("Unable to parse height " + arguments[1] + " as an integer.");
                    commandLine.Text = "";
                    return;
                }

                canvasInstance.DrawRectangle(x, y);
            }
            else
            {
                MessageBox.Show("Invalid Input. Kindly input a valid width and height, e.g: rect 10,10.");
                commandLine.Text = "";
            }
        }


        /// <summary>
        /// Circle command process handler.
        /// </summary>
        /// <param name="ParamList"></param>
        private void DrawCircle(string[] ParamList)
        {

            if (ParamList.Length == 2)
            {
                int radius = 0;

                try
                {
                    radius = Int32.Parse(ParamList[1]);
                }
                catch (FormatException)
                {
                    MessageBox.Show("Unable to parse radius " + ParamList[1] + " as an integer.");
                    commandLine.Text = "";
                    return;
                }

                canvasInstance.DrawCircle(radius);
            }
            else
            {
                MessageBox.Show("Invalid Input. Kindly input a valid circle radius, e.g: circle 30");
                commandLine.Text = "";
            }
        }


        /// <summary>
        /// Triangle command process handler.
        /// </summary>
        /// <param name="ParamList"></param>
        private void DrawTriangle(string[] ParamList)
        {
            if (ParamList.Length == 2)
            {

                int sides = 0;

                try
                {
                    sides = Int32.Parse(ParamList[1]);
                }
                catch (FormatException)
                {
                    MessageBox.Show("Unable to parse side " + ParamList[1] + " as an integer.");
                    commandLine.Text = "";
                    return;
                }

                PointF firstSide = new PointF(((canvasInstance.xPosition / 2) + 2), (sides + (canvasInstance.yPosition/2) + 2 ));
                PointF secondSide = new PointF(sides + ((canvasInstance.xPosition / 2) + 2), sides + ((canvasInstance.yPosition / 2) + 2));
                PointF thirdSide = new PointF((sides/2) + ((canvasInstance.xPosition /2) + 2), 0.0f + ((canvasInstance.yPosition / 2) + 2));

                PointF[] trianglePoints = { firstSide, secondSide, thirdSide };
                canvasInstance.DrawTriangle(trianglePoints);
            }
            else
            {
                MessageBox.Show("Invalid Input. Kindly input a valid triangle side length, e.g: triangle 30");
                commandLine.Text = "";
            }
            
        }


        /// <summary>
        /// Reset pen position command handler 
        /// </summary>
        private void ResetPenPosition()
        {
            canvasInstance.ResetPosition();
        }


        /// <summary>
        /// Fill command process handler. 
        /// </summary>
        /// <param name="ParamList"></param>
        private void FillShape(string[] ParamList)
        {
            canvasInstance.Fill();

            if (ParamList.Length == 2)
            {
                string c = ParamList[1];

                switch (c)
                {
                    case "on":
                        canvasInstance.brush.Color = canvasInstance.pen.Color;
                        break;

                    case "off":
                        canvasInstance.brush.Color = Color.Transparent;
                        break;
                }
            }
            else
            {
                MessageBox.Show("Please select either on or off.");
                commandLine.Text = "";
            }

        }


        /// <summary>
        /// Fill command process handler. 
        /// </summary>
        /// <param name="ParamList"></param>
        private void PenColor(string[] ParamList)
        {
            if (ParamList.Length == 2)
            {
                string c = ParamList[1];
                switch (c)
                {
                    case "blue":
                        canvasInstance.pen.Color = Color.Blue;
                        break;

                    case "black":
                        canvasInstance.pen.Color = Color.Black;
                        break;

                    case "green":
                        canvasInstance.pen.Color = Color.Green;
                        break;

                    case "red":
                        canvasInstance.pen.Color = Color.Red;
                        break;
                }
            }
            else
            {
                MessageBox.Show("Please select from (blue, green, red, black.");
                commandLine.Text = "";
            }

        }

    }
}
