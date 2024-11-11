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
            label1 = new Label();
            SuspendLayout();
            // 
            // addButton
            // 
            addButton.Location = new Point(251, 211);
            addButton.Name = "addButton";
            addButton.Size = new Size(115, 27);
            addButton.TabIndex = 0;
            addButton.Text = "Add";
            addButton.UseVisualStyleBackColor = true;
            addButton.Click += button1_Click;
            // 
            // componentNameTextBox
            // 
            componentNameTextBox.Location = new Point(12, 78);
            componentNameTextBox.Name = "componentNameTextBox";
            componentNameTextBox.PlaceholderText = "Enter component name";
            componentNameTextBox.Size = new Size(195, 27);
            componentNameTextBox.TabIndex = 1;
            // 
            // componentTypeTextBox
            // 
            componentTypeTextBox.Location = new Point(12, 123);
            componentTypeTextBox.Name = "componentTypeTextBox";
            componentTypeTextBox.PlaceholderText = "Enter component type";
            componentTypeTextBox.Size = new Size(195, 27);
            componentTypeTextBox.TabIndex = 2;
            // 
            // stockQuantityTextBox
            // 
            stockQuantityTextBox.Location = new Point(12, 165);
            stockQuantityTextBox.Name = "stockQuantityTextBox";
            stockQuantityTextBox.PlaceholderText = "Enter stock quantity";
            stockQuantityTextBox.Size = new Size(195, 27);
            stockQuantityTextBox.TabIndex = 3;
            // 
            // priceTextBox
            // 
            priceTextBox.Location = new Point(12, 211);
            priceTextBox.Name = "priceTextBox";
            priceTextBox.PlaceholderText = "Enter price";
            priceTextBox.Size = new Size(195, 27);
            priceTextBox.TabIndex = 4;
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI", 20F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(391, 66);
            label1.TabIndex = 5;
            label1.Text = "Add components menu";
            label1.Click += label1_Click;
            // 
            // Form7
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(389, 252);
            Controls.Add(label1);
            Controls.Add(priceTextBox);
            Controls.Add(stockQuantityTextBox);
            Controls.Add(componentTypeTextBox);
            Controls.Add(componentNameTextBox);
            Controls.Add(addButton);
            Name = "Form7";
            Text = "Add components";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button addButton;
        private TextBox componentNameTextBox;
        private TextBox componentTypeTextBox;
        private TextBox stockQuantityTextBox;
        private TextBox priceTextBox;
        private Label label1;
    }
}