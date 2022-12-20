using System;
using System.Collections;
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
        private TextBox commandLine;
        Graphics g;
        Pen pen;
        SolidBrush brush;
        int x, y;
        public bool fill = false;
        ShapesFactory factory;
        Shapes s;


        /// <summary>
        /// Commands Constructor
        /// </summary>
        /// <param name="CommandLine"></param>
        /// <param name="bitmap"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="pen"></param>
        /// <param name="brush"></param>
        public Commands(TextBox CommandLine, Bitmap bitmap, int x, int y, Pen pen, SolidBrush brush)
        {
            // canvasInstance = canvas;
            factory = new ShapesFactory();
            commandLine = CommandLine;
            g = Graphics.FromImage(bitmap);
            this.pen = pen;
            this.brush = brush;
            this.x = x;
            this.y = y;



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
                    Clear();
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

                case "var":
                    Variable variable = new Variable();
                    variable.set(CommandStr);
                    break;


                default:
                    MessageBox.Show(CommandStr[0] + " is not a valid command.");
                    break;
            }

        }


        /// <summary>
        /// Method to handle programming window
        /// </summary>
        /// <param name="ProgramStr"></param>
        private void ProgramWindowCommand(string ProgramStr)
        {
            String[] Commander = ProgramStr.Split(Environment.NewLine.ToCharArray());
            int Loop = 0;

            while (Loop < Commander.Length)
            {
                String[] SingleCommands = Commander[Loop].Split(' ');
                if (SingleCommands[0] == "pen" ||
                    SingleCommands[0] == "rect" ||
                    SingleCommands[0] == "circle" ||
                    SingleCommands[0] == "triangle" ||
                    SingleCommands[0] == "moveto" ||
                    SingleCommands[0] == "drawto" ||
                    SingleCommands[0] == "fill" ||
                    SingleCommands[0] == "clear" ||
                    SingleCommands[0] == "var" ||
                    SingleCommands[0] == "reset")
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


                int[] list = new int[] { x, y };
                s = factory.getShape("drawto");
                s.set(this.x, this.y, pen, brush, list);
                s.draw(g);

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

                int[] list = new int[] { x, y };
                s = factory.getShape("moveto");
                s.set(this.x, this.y, pen, brush, list);
                s.draw(g);
                this.x = x;
                this.y = y;
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
                int w, h = 0;

                try
                {
                    w = Int32.Parse(arguments[0]);
                }
                catch (FormatException)
                {
                    MessageBox.Show("Unable to parse width " + arguments[0] + " as an integer.");
                    commandLine.Text = "";
                    return;
                }

                try
                {
                    h = Int32.Parse(arguments[1]);
                }
                catch (FormatException)
                {
                    MessageBox.Show("Unable to parse height " + arguments[1] + " as an integer.");
                    commandLine.Text = "";
                    return;
                }

                int[] list = new int[] { w, h };
                s = factory.getShape("rect");
                s.set(this.x, this.y, pen, brush, list);
                s.draw(g);

                //canvasInstance.DrawRectangle(x, y);
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

                int[] list = new int[] { radius };
                s = factory.getShape("circle");
                s.set(this.x, this.y, pen, brush, list);
                s.draw(g);
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

                int[] list = new int[] { sides };
                s = factory.getShape("triangle");
                s.set(this.x, this.y, pen, brush, list);
                s.draw(g);

                //canvasInstance.DrawTriangle(trianglePoints);
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
            int[] list = new int[] { 5, 5 };
            s = factory.getShape("moveto");
            s.set(this.x, this.y, pen, brush, list);
            s.draw(g);
        }


        /// <summary>
        /// Fill command process handler. 
        /// </summary>
        /// <param name="ParamList"></param>
        private void FillShape(string[] ParamList)
        {
            this.fill = !this.fill;

            if (ParamList.Length == 2)
            {
                string c = ParamList[1];

                switch (c)
                {
                    case "on":
                        this.brush.Color = this.pen.Color;
                        break;

                    case "off":
                        this.brush.Color = Color.Transparent;
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
                        this.pen.Color = Color.Blue;
                        break;

                    case "black":
                        this.pen.Color = Color.Black;
                        break;

                    case "green":
                        this.pen.Color = Color.Green;
                        break;

                    case "red":
                        this.pen.Color = Color.Red;
                        break;
                }
            }
            else
            {
                MessageBox.Show("Please select from (blue, green, red, black.");
                commandLine.Text = "";
            }

        }


        /// <summary>
        /// Clear command process handler. 
        /// </summary>
        public void Clear()
        {
            this.pen.Color = Color.Black;
            this.g.Clear(Color.Gray);
        }

    }
}
