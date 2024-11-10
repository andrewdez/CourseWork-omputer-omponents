namespace CourseWork
{
    partial class Form7
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
            addButton = new Button();
            componentNameTextBox = new TextBox();
            componentTypeTextBox = new TextBox();
            stockQuantityTextBox = new TextBox();
            priceTextBox = new TextBox();
            SuspendLayout();
            // 
            // addButton
            // 
            addButton.Location = new Point(433, 251);
            addButton.Name = "addButton";
            addButton.Size = new Size(115, 27);
            addButton.TabIndex = 0;
            addButton.Text = "Add";
            addButton.UseVisualStyleBackColor = true;
            addButton.Click += button1_Click;
            // 
            // componentNameTextBox
            // 
            componentNameTextBox.Location = new Point(185, 118);
            componentNameTextBox.Name = "componentNameTextBox";
            componentNameTextBox.Size = new Size(195, 27);
            componentNameTextBox.TabIndex = 1;
            // 
            // componentTypeTextBox
            // 
            componentTypeTextBox.Location = new Point(185, 163);
            componentTypeTextBox.Name = "componentTypeTextBox";
            componentTypeTextBox.Size = new Size(195, 27);
            componentTypeTextBox.TabIndex = 2;
            // 
            // stockQuantityTextBox
            // 
            stockQuantityTextBox.Location = new Point(185, 205);
            stockQuantityTextBox.Name = "stockQuantityTextBox";
            stockQuantityTextBox.Size = new Size(195, 27);
            stockQuantityTextBox.TabIndex = 3;
            // 
            // priceTextBox
            // 
            priceTextBox.Location = new Point(185, 251);
            priceTextBox.Name = "priceTextBox";
            priceTextBox.Size = new Size(195, 27);
            priceTextBox.TabIndex = 4;
            // 
            // Form7
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(560, 331);
            Controls.Add(priceTextBox);
            Controls.Add(stockQuantityTextBox);
            Controls.Add(componentTypeTextBox);
            Controls.Add(componentNameTextBox);
            Controls.Add(addButton);
            Name = "Form7";
            Text = "Form7";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button addButton;
        private TextBox componentNameTextBox;
        private TextBox componentTypeTextBox;
        private TextBox stockQuantityTextBox;
        private TextBox priceTextBox;
    }
}