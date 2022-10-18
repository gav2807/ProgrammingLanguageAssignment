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
            this.displayPanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(12, 252);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(75, 23);
            this.btnRun.TabIndex = 0;
            this.btnRun.Text = "Run";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // btnSyntax
            // 
            this.btnSyntax.Location = new System.Drawing.Point(130, 252);
            this.btnSyntax.Name = "btnSyntax";
            this.btnSyntax.Size = new System.Drawing.Size(75, 23);
            this.btnSyntax.TabIndex = 1;
            this.btnSyntax.Text = "Syntax";
            this.btnSyntax.UseVisualStyleBackColor = true;
            // 
            // programWindow
            // 
            this.programWindow.Location = new System.Drawing.Point(12, 12);
            this.programWindow.Multiline = true;
            this.programWindow.Name = "programWindow";
            this.programWindow.Size = new System.Drawing.Size(325, 184);
            this.programWindow.TabIndex = 2;
            // 
            // commandLine
            // 
            this.commandLine.Location = new System.Drawing.Point(12, 215);
            this.commandLine.Name = "commandLine";
            this.commandLine.Size = new System.Drawing.Size(325, 22);
            this.commandLine.TabIndex = 3;
            // 
            // displayPanel
            // 
            this.displayPanel.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.displayPanel.Location = new System.Drawing.Point(397, 12);
            this.displayPanel.Name = "displayPanel";
            this.displayPanel.Size = new System.Drawing.Size(391, 184);
            this.displayPanel.TabIndex = 4;
            this.displayPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.displayPanel_Paint);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.displayPanel);
            this.Controls.Add(this.commandLine);
            this.Controls.Add(this.programWindow);
            this.Controls.Add(this.btnSyntax);
            this.Controls.Add(this.btnRun);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.Button btnSyntax;
        private System.Windows.Forms.TextBox programWindow;
        private System.Windows.Forms.TextBox commandLine;
        private System.Windows.Forms.Panel displayPanel;
    }
}

