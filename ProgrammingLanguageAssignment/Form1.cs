using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProgrammingLanguageAssignment
{
    public partial class Form1 : Form
    {
        public static int xbrush = 100;
        public static int ybrush = 80;

        public static int width = 40;
        public static int height = 40;

        public static int xpen = (Form1.xbrush - (Form1.width / 2)) + 2;
        public static int ypen = (Form1.ybrush - (Form1.height / 2)) + 2;


        public Form1()
        {
            InitializeComponent();
        
        }


    
        public static void drawCircle ()
        {
           //Pen penPointer = Form1.penPointer();
           // Graphics graphics = displayPanel.CreateGraphics();
            //graphics.DrawEllipse(penPointer, 20, 20, 50, 50);
        }

        public static void drawRectangle()
        {
           // Pen penPointer = Form1.penPointer();
            //Graphics graphics = displayPanel.CreateGraphics();
            //graphics.DrawRectangle(penPointer, 20, 20, 50, 50);
        }
        /*
        public void drawTriangle()
        {
            Pen penPointer = Form1.penPointer();
            Graphics graphics = displayPanel.CreateGraphics();
            graphics.Draw(penPointer, 20, 20, 50);
        }
        */
        public static Pen penPointer()
        {
            Pen pen = new Pen(Color.Red);
            return pen;

        }

        private void btnRun_Click(object sender, EventArgs e)
        {

        }

        private void displayPanel_Paint(object sender, PaintEventArgs e)
        {
            Pen penPointer = Form1.penPointer();
            SolidBrush brush = new SolidBrush(Color.Red);
            Graphics graphics = displayPanel.CreateGraphics();
            graphics.FillEllipse(brush, xbrush, ybrush, 4, 4);
            graphics.DrawEllipse(penPointer, xpen, ypen, width, height);
        }
    }
}
