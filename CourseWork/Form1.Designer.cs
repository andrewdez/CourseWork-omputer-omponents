﻿namespace CourseWork
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Button1 = new Button();
            button3 = new Button();
            button5 = new Button();
            button6 = new Button();
            SuspendLayout();
            // 
            // Button1
            // 
            Button1.Location = new Point(88, 51);
            Button1.Name = "Button1";
            Button1.Size = new Size(125, 114);
            Button1.TabIndex = 0;
            Button1.Text = "Add Order";
            Button1.UseVisualStyleBackColor = true;
            Button1.Click += button1_Click_1;
            // 
            // button3
            // 
            button3.Location = new Point(88, 197);
            button3.Name = "button3";
            button3.Size = new Size(128, 107);
            button3.TabIndex = 2;
            button3.Text = "Order List";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button5
            // 
            button5.Location = new Point(472, 51);
            button5.Name = "button5";
            button5.Size = new Size(128, 107);
            button5.TabIndex = 4;
            button5.Text = "Manage Components";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // button6
            // 
            button6.Location = new Point(472, 207);
            button6.Name = "button6";
            button6.Size = new Size(128, 107);
            button6.TabIndex = 5;
            button6.Text = "Manage Employee";
            button6.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(697, 353);
            Controls.Add(button6);
            Controls.Add(button5);
            Controls.Add(button3);
            Controls.Add(Button1);
            Name = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button Button1;
        private Button button3;
        private Button button5;
        private Button button6;
    }
}