using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProgrammingLanguageAssignment
{
    public partial class Form1 : Form
    { 
        private Commands commandInstance;
        private Bitmap bitmap = new Bitmap(650, 450);
        public Pen pen;
        public SolidBrush brush;


        public Form1()
        {
            InitializeComponent();
            pen = new Pen(Color.Black);
            brush = new SolidBrush(Color.Transparent);
            commandInstance = new Commands(commandLine, bitmap, 0, 0, pen, brush);
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
        }


        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog file = new SaveFileDialog();        
            file.DefaultExt = "*.txt";
            file.Filter = "Text Files (*.txt)|*.txt|RTF Files (*.rtf)|*.rtf";        
            if (file.ShowDialog() == System.Windows.Forms.DialogResult.OK && file.FileName.Length > 0)
            {
                programWindow.SaveFile(file.FileName, RichTextBoxStreamType.PlainText); 
                MessageBox.Show("File saved successfully");
            }
        }


        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stream stream;
            OpenFileDialog openFileDialog = new OpenFileDialog();

            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if ((stream = openFileDialog.OpenFile()) != null)
                {
                    programWindow.Text = File.ReadAllText(openFileDialog.FileName);
                }
            }
        }
    }
}
