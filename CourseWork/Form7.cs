using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CourseWork
{
    public partial class Form7 : Form
    {
        private string connectionString = "Server=DESKTOP-K2ID4TF;Database=ServiceCenter;User Id=user1;Password=user1;";

        public Form7()
        {
            InitializeComponent();
            addButton.Click += addButton_Click;
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            string componentName = componentNameTextBox.Text;
            string componentType = componentTypeTextBox.Text;
            int stockQuantity;
            decimal price;

            if (string.IsNullOrWhiteSpace(componentName) || string.IsNullOrWhiteSpace(componentType) ||
                !int.TryParse(stockQuantityTextBox.Text, out stockQuantity) ||
                !decimal.TryParse(priceTextBox.Text, out price))
            {
                MessageBox.Show("Please enter valid data for all fields.");
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string query = "INSERT INTO Components (ComponentName, ComponentType, StockQuantity, Price) " +
                                   "VALUES (@ComponentName, @ComponentType, @StockQuantity, @Price)";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@ComponentName", componentName);
                        cmd.Parameters.AddWithValue("@ComponentType", componentType);
                        cmd.Parameters.AddWithValue("@StockQuantity", stockQuantity);
                        cmd.Parameters.AddWithValue("@Price", price);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Component added successfully!");
                            this.Close(); // Закриває форму після додавання компонента
                        }
                        else
                        {
                            MessageBox.Show("Failed to add component. Please check the data.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding component: " + ex.Message);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
