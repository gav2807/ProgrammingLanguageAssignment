namespace ProgrammingLanguageAssignment
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnRun = new System.Windows.Forms.Button();
            this.btnSyntax = new System.Windows.Forms.Button();
            this.programWindow = new System.Windows.Forms.TextBox();
            this.commandLine = new System.Windows.Forms.TextBox();
            this.outPutBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.outPutBox)).BeginInit();
            this.SuspendLayout();
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(9, 205);
            this.btnRun.Margin = new System.Windows.Forms.Padding(2);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(56, 19);
            this.btnRun.TabIndex = 0;
            this.btnRun.Text = "Run";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // btnSyntax
            // 
            this.btnSyntax.Location = new System.Drawing.Point(98, 205);
            this.btnSyntax.Margin = new System.Windows.Forms.Padding(2);
            this.btnSyntax.Name = "btnSyntax";
            this.btnSyntax.Size = new System.Drawing.Size(56, 19);
            this.btnSyntax.TabIndex = 1;
            this.btnSyntax.Text = "Syntax";
            this.btnSyntax.UseVisualStyleBackColor = true;
            this.btnSyntax.Click += new System.EventHandler(this.btnSyntax_Click);
            // 
            // programWindow
            // 
            this.programWindow.Location = new System.Drawing.Point(9, 10);
            this.programWindow.Margin = new System.Windows.Forms.Padding(2);
            this.programWindow.Multiline = true;
            this.programWindow.Name = "programWindow";
            this.programWindow.Size = new System.Drawing.Size(245, 150);
            this.programWindow.TabIndex = 2;
            // 
            // commandLine
            // 
            this.commandLine.Location = new System.Drawing.Point(9, 175);
            this.commandLine.Margin = new System.Windows.Forms.Padding(2);
            this.commandLine.Name = "commandLine";
            this.commandLine.Size = new System.Drawing.Size(245, 20);
            this.commandLine.TabIndex = 3;
            this.commandLine.KeyDown += new System.Windows.Forms.KeyEventHandler(this.commandLine_KeyDown);
            // 
            // outPutBox
            // 
            this.outPutBox.BackColor = System.Drawing.Color.Gray;
            this.outPutBox.Location = new System.Drawing.Point(291, 10);
            this.outPutBox.Name = "outPutBox";
            this.outPutBox.Size = new System.Drawing.Size(287, 185);
            this.outPutBox.TabIndex = 5;
            this.outPutBox.TabStop = false;
            this.outPutBox.Paint += new System.Windows.Forms.PaintEventHandler(this.outPutBox_Paint);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.outPutBox);
            this.Controls.Add(this.commandLine);
            this.Controls.Add(this.programWindow);
            this.Controls.Add(this.btnSyntax);
            this.Controls.Add(this.btnRun);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.outPutBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.Button btnSyntax;
        private System.Windows.Forms.TextBox programWindow;
        private System.Windows.Forms.TextBox commandLine;
        private System.Windows.Forms.PictureBox outPutBox;
    }
}

