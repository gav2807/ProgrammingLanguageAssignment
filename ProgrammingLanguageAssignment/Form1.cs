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
        private Canvas canvas;
        private Commands commandInstance;
        private Bitmap bitmap = new Bitmap(650, 450);
        public Pen pen;
        public SolidBrush brush;


        public Form1()
        {
            InitializeComponent();
            pen = new Pen(Color.Black);
            brush = new SolidBrush(Color.Transparent);
            canvas = new Canvas(Graphics.FromImage(bitmap), 0, 0, pen, brush);
            commandInstance = new Commands(canvas, commandLine);
            outPutBox.Image = bitmap;
        }


        private void btnRun_Click(object sender, EventArgs e)
        {
            string inputArray = commandLine.Text.Trim().ToLower();
            string programInput = programWindow.Text.ToLower();
            string[] ParamList = new string[0];
            
            commandInstance.HandleCommand(inputArray, programInput); 
            commandLine.Text = "";
            outPutBox.Refresh();
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private void outPutBox_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawImageUnscaled(bitmap, 0, 0);
        }


        private void commandLine_KeyDown(object sender, KeyEventArgs e)
        {
            string inputArray = commandLine.Text.Trim().ToLower();
            string programInput = programWindow.Text.ToLower();
            string[] ParamList = new string[0];
           
            if (e.KeyCode == Keys.Enter)
            {
                commandInstance.HandleCommand(inputArray, programInput);
                commandLine.Text = "";
                outPutBox.Refresh();
            }
        }

        private void btnSyntax_Click(object sender, EventArgs e)
        {
            string inputArray = commandLine.Text.Trim().ToLower();
            string programInput = programWindow.Text.ToLower();
            commandInstance.HandleCommand(inputArray, programInput);
            //MessageBox.Show("Check Syntax");
        }
    }
}
