namespace CourseWork
{
    partial class Form5
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
            dataGridView1 = new DataGridView();
            searchButton = new Button();
            searchTextBox = new TextBox();
            insertButton = new Button();
            orderIDTextBox = new TextBox();
            componentIDTextBox = new TextBox();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 53);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 29;
            dataGridView1.Size = new Size(1050, 314);
            dataGridView1.TabIndex = 0;
            // 
            // searchButton
            // 
            searchButton.Location = new Point(968, 392);
            searchButton.Name = "searchButton";
            searchButton.Size = new Size(94, 29);
            searchButton.TabIndex = 1;
            searchButton.Text = "Search";
            searchButton.UseVisualStyleBackColor = true;
            // 
            // searchTextBox
            // 
            searchTextBox.Location = new Point(799, 395);
            searchTextBox.Name = "searchTextBox";
            searchTextBox.PlaceholderText = "Enter component info";
            searchTextBox.Size = new Size(163, 27);
            searchTextBox.TabIndex = 2;
            // 
            // insertButton
            // 
            insertButton.Location = new Point(161, 394);
            insertButton.Name = "insertButton";
            insertButton.Size = new Size(94, 29);
            insertButton.TabIndex = 3;
            insertButton.Text = "Insert";
            insertButton.UseVisualStyleBackColor = true;
            // 
            // orderIDTextBox
            // 
            orderIDTextBox.Location = new Point(12, 378);
            orderIDTextBox.Name = "orderIDTextBox";
            orderIDTextBox.PlaceholderText = "Enter order ID";
            orderIDTextBox.Size = new Size(143, 27);
            orderIDTextBox.TabIndex = 4;
            // 
            // componentIDTextBox
            // 
            componentIDTextBox.Location = new Point(12, 411);
            componentIDTextBox.Name = "componentIDTextBox";
            componentIDTextBox.PlaceholderText = "Enter component ID";
            componentIDTextBox.Size = new Size(143, 27);
            componentIDTextBox.TabIndex = 5;
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI", 20F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(12, 4);
            label1.Name = "label1";
            label1.Size = new Size(455, 46);
            label1.TabIndex = 6;
            label1.Text = "Components usage menu";
            label1.Click += label1_Click;
            // 
            // Form5
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1076, 450);
            Controls.Add(label1);
            Controls.Add(componentIDTextBox);
            Controls.Add(orderIDTextBox);
            Controls.Add(insertButton);
            Controls.Add(searchTextBox);
            Controls.Add(searchButton);
            Controls.Add(dataGridView1);
            Name = "Form5";
            Text = "Components usage";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private Button searchButton;
        private TextBox searchTextBox;
        private Button insertButton;
        private TextBox orderIDTextBox;
        private TextBox componentIDTextBox;
        private Label label1;
    }
}