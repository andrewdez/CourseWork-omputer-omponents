namespace CourseWork
{
    partial class AddOrder
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
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            dateTimePicker1 = new DateTimePicker();
            textBox4 = new TextBox();
            button1 = new Button();
            employeeComboBox = new ComboBox();
            label1 = new Label();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(25, 71);
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = "Enter client name";
            textBox1.Size = new Size(250, 27);
            textBox1.TabIndex = 0;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(26, 120);
            textBox2.Name = "textBox2";
            textBox2.PlaceholderText = "Enter client phone number";
            textBox2.Size = new Size(249, 27);
            textBox2.TabIndex = 1;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(25, 170);
            textBox3.Name = "textBox3";
            textBox3.PlaceholderText = "Enter description of problem";
            textBox3.Size = new Size(250, 27);
            textBox3.TabIndex = 2;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(25, 224);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(250, 27);
            dateTimePicker1.TabIndex = 3;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(25, 273);
            textBox4.Name = "textBox4";
            textBox4.PlaceholderText = "Enter total price";
            textBox4.Size = new Size(250, 27);
            textBox4.TabIndex = 4;
            // 
            // button1
            // 
            button1.Location = new Point(383, 334);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 5;
            button1.Text = "Save";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // employeeComboBox
            // 
            employeeComboBox.FormattingEnabled = true;
            employeeComboBox.Location = new Point(25, 335);
            employeeComboBox.Name = "employeeComboBox";
            employeeComboBox.Size = new Size(250, 28);
            employeeComboBox.TabIndex = 6;
            employeeComboBox.Tag = "";
            employeeComboBox.Text = "Chose employee";
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI", 20F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(26, 9);
            label1.Name = "label1";
            label1.Size = new Size(464, 48);
            label1.TabIndex = 7;
            label1.Text = "Add order menu ";
            // 
            // AddOrder
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(519, 375);
            Controls.Add(label1);
            Controls.Add(employeeComboBox);
            Controls.Add(button1);
            Controls.Add(textBox4);
            Controls.Add(dateTimePicker1);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Name = "AddOrder";
            Text = "Add Order";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private DateTimePicker dateTimePicker1;
        private TextBox textBox4;
        private Button button1;
        private ComboBox employeeComboBox;
        private Label label1;
    }
}