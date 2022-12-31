using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

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
        Variable variableInstance;
        Conditional conditionalInstance;
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
            variableInstance = new Variable();
            conditionalInstance = new Conditional();
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
            int varLoop = 0;

            while (Loop < Commander.Length)
            {
                String[] SingleCommands = Commander[Loop].Split(' ');

                if ((SingleCommands.Count() == 3) && (SingleCommands[1] == "="))
                {
                    string variableName = SingleCommands[0];
                    int variableIndex = varLoop;
                    int variableValue = Int32.Parse(SingleCommands[2]);
                    variableInstance.set(variableValue, variableName, variableIndex);
                    varLoop++;
                }

                // check if the IfVariable exists in the variable array
                else if (SingleCommands[0] == "if")
                {
                    int variable;
                    int value = Int32.Parse(SingleCommands[3]);
                    bool If = true;
                    string condition = SingleCommands[2];
                    if (variableInstance.getVariableName().Contains(SingleCommands[1]))
                    {
                        int index = Array.IndexOf(variableInstance.getVariableName(), SingleCommands[1]);
                        variable = variableInstance.getVariableValue()[index];
                    }
                    else
                    {
                        variable = Int32.Parse(SingleCommands[1]);
                    }

                    // check the whole logic to see if it's true or false then set the If to true or false
                    conditionalInstance.set(If, variable, value, condition);
                    conditionalInstance.IfLogic = conditionalInstance.checkIfLogic();

                }
                else if ((conditionalInstance.If == true) && (conditionalInstance.IfLogic == true) && (SingleCommands[0] != "endif"))
                {
                    HandleCommand(Commander[Loop], null);
                }
                else if ((conditionalInstance.If == true) && (conditionalInstance.IfLogic == false) && (SingleCommands[0] != "endif"))
                { }
                else if (SingleCommands[0] == "endif")
                {
                    conditionalInstance.If = false;
                    conditionalInstance.IfLogic = false;
                }
                else if (SingleCommands[0] == "pen" ||
                    SingleCommands[0] == "rect" ||
                    SingleCommands[0] == "circle" ||
                    SingleCommands[0] == "triangle" ||
                    SingleCommands[0] == "moveto" ||
                    SingleCommands[0] == "drawto" ||
                    SingleCommands[0] == "fill" ||
                    SingleCommands[0] == "clear" ||
                    SingleCommands[0] == "reset")
                {
                    HandleCommand(Commander[Loop], null);
                }
                else
                {
                    MessageBox.Show(SingleCommands[0] + " is not a command.");
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
                    if (variableInstance.getVariableName().Contains(arguments[0]))
                    {
                        int index = Array.IndexOf(variableInstance.getVariableName(), arguments[0]);
                        x = variableInstance.getVariableValue()[index];
                    }
                    else
                    {
                        x = Int32.Parse(arguments[0]);
                    }

                }
                catch (FormatException)
                {
                    MessageBox.Show("Unable to parse X position " + arguments[0] + " as an integer.");
                    commandLine.Text = "";
                    return;
                }

                try
                {
                    if (variableInstance.getVariableName().Contains(arguments[1]))
                    {
                        int index = Array.IndexOf(variableInstance.getVariableName(), arguments[1]);
                        y = variableInstance.getVariableValue()[index];
                    }
                    else
                    {
                        y = Int32.Parse(arguments[0]);
                    }
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
                    if (variableInstance.getVariableName().Contains(arguments[0]))
                    {
                        int index = Array.IndexOf(variableInstance.getVariableName(), arguments[0]);
                        x = variableInstance.getVariableValue()[index];
                    }
                    else
                    {
                        x = Int32.Parse(arguments[0]);
                    }
                }
                catch (FormatException)
                {
                    MessageBox.Show("Unable to parse X axis " + arguments[0] + " as an integer.");
                    commandLine.Text = "";
                    return;
                }

                try
                {
                    if (variableInstance.getVariableName().Contains(arguments[0]))
                    {
                        int index = Array.IndexOf(variableInstance.getVariableName(), arguments[1]);
                        y = variableInstance.getVariableValue()[index];
                    }
                    else
                    {
                        y = Int32.Parse(arguments[1]);
                    }
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
                    if (variableInstance.getVariableName().Contains(arguments[0]))
                    {
                        int index = Array.IndexOf(variableInstance.getVariableName(), arguments[0]);
                        w = variableInstance.getVariableValue()[index];
                    }
                    else
                    {
                        w = Int32.Parse(arguments[0]);
                    }
                }
                catch (FormatException)
                {
                    MessageBox.Show("Unable to parse width " + arguments[0] + " as an integer.");
                    commandLine.Text = "";
                    return;
                }

                try
                {
                    if (variableInstance.getVariableName().Contains(arguments[1]))
                    {
                        int index = Array.IndexOf(variableInstance.getVariableName(), arguments[1]);
                        h = variableInstance.getVariableValue()[index];
                    }
                    else
                    {
                        h = Int32.Parse(arguments[1]);
                    }

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

                    if (variableInstance.getVariableName().Contains(ParamList[1]))
                    {
                        int index = Array.IndexOf(variableInstance.getVariableName(), ParamList[1]);
                        radius = variableInstance.getVariableValue()[index];
                    }
                    else
                    {
                        radius = Int32.Parse(ParamList[1]);
                    }
                }
                catch (FormatException)
                {
                    MessageBox.Show("Unable to parse radius " + variableInstance.getVariableName()[0] + " as an integer.");
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
                    if (variableInstance.getVariableName().Contains(ParamList[1]))
                    {
                        int index = Array.IndexOf(variableInstance.getVariableName(), ParamList[1]);
                        sides = variableInstance.getVariableValue()[index];
                    }
                    else
                    {
                        sides = Int32.Parse(ParamList[1]);
                    }
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
