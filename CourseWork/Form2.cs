using ServiceCenterApp;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CourseWork
{
    public partial class AddOrder : Form
    {
        public AddOrder()
        {
            InitializeComponent();
            LoadEmployeeNames();
        }

        private string connectionString = DatabaseConnection.GetConnection();

        private void LoadEmployeeNames()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT EmployeeName FROM Employee";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                employeeComboBox.Items.Add(reader["EmployeeName"].ToString());
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading employee names: " + ex.Message);
                }
            }
        }

        // Логіка кнопки Save
        private void button1_Click(object sender, EventArgs e)
        {
            if (employeeComboBox.SelectedItem == null)
            {
                MessageBox.Show("Please select an employee.");
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    // SQL-запит на вставку даних у таблицю Order1
                    string query = "INSERT INTO Order1 (ClientName, ClientPhone, Description, EmployeeName, Status, EstimatedCompletionTime, TotalCost) " +
                                   "VALUES (@ClientName, @ClientPhone, @Description, @EmployeeName, 'in progress', @EstimatedCompletionTime, @TotalCost)";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // Передача значень з форми у запит
                        cmd.Parameters.AddWithValue("@ClientName", textBox1.Text);
                        cmd.Parameters.AddWithValue("@ClientPhone", textBox2.Text);
                        cmd.Parameters.AddWithValue("@Description", textBox3.Text);
                        cmd.Parameters.AddWithValue("@EmployeeName", employeeComboBox.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@EstimatedCompletionTime", dateTimePicker1.Value);
                        cmd.Parameters.AddWithValue("@TotalCost", Convert.ToDecimal(textBox4.Text));

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Order added successfully!");
                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }
    }
}
