using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CourseWork
{
    public partial class Form3 : Form
    {
        private string connectionString = "Server=DESKTOP-K2ID4TF;Database=ServiceCenter;User Id=user1;Password=user1;";
        private SqlDataAdapter dataAdapter;
        private DataTable dataTable;

        public Form3()
        {
            InitializeComponent();
            LoadOrders();
        }

        private void LoadOrders()
        {
            try
            {
                // Ініціалізація DataTable та SqlDataAdapter
                dataTable = new DataTable();

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT * FROM Order1";

                    dataAdapter = new SqlDataAdapter(query, conn);
                    dataAdapter.Fill(dataTable);
                }

                dataGridView1.DataSource = dataTable;

                // Додаємо кнопку "Update" у кожний рядок
                DataGridViewButtonColumn updateButtonColumn = new DataGridViewButtonColumn
                {
                    Name = "UpdateButton",
                    HeaderText = "Update",
                    Text = "Update",
                    UseColumnTextForButtonValue = true
                };
                dataGridView1.Columns.Add(updateButtonColumn);

                dataGridView1.ReadOnly = false;
                dataGridView1.AllowUserToAddRows = false;
                dataGridView1.CellClick += dataGridView1_CellClick;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading orders: " + ex.Message);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Перевіряємо, чи натиснута кнопка "Update"
            if (e.ColumnIndex == dataGridView1.Columns["UpdateButton"].Index && e.RowIndex >= 0)
            {
                UpdateRow(e.RowIndex);
            }
        }

        private void UpdateRow(int rowIndex)
        {
            try
            {
                // Отримуємо значення з вибраного рядка
                int orderID = Convert.ToInt32(dataGridView1.Rows[rowIndex].Cells["OrderID"].Value);
                string clientName = dataGridView1.Rows[rowIndex].Cells["ClientName"].Value.ToString();
                string clientPhone = dataGridView1.Rows[rowIndex].Cells["ClientPhone"].Value.ToString();
                string description = dataGridView1.Rows[rowIndex].Cells["Description"].Value.ToString();
                string status = dataGridView1.Rows[rowIndex].Cells["Status"].Value.ToString();
                DateTime estimatedCompletionTime = Convert.ToDateTime(dataGridView1.Rows[rowIndex].Cells["EstimatedCompletionTime"].Value);
                decimal totalCost = Convert.ToDecimal(dataGridView1.Rows[rowIndex].Cells["TotalCost"].Value);

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Запит на оновлення даних
                    string query = "UPDATE Order1 SET ClientName = @ClientName, ClientPhone = @ClientPhone, Description = @Description, " +
                                   "Status = @Status, EstimatedCompletionTime = @EstimatedCompletionTime, TotalCost = @TotalCost " +
                                   "WHERE OrderID = @OrderID";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@OrderID", orderID);
                        cmd.Parameters.AddWithValue("@ClientName", clientName);
                        cmd.Parameters.AddWithValue("@ClientPhone", clientPhone);
                        cmd.Parameters.AddWithValue("@Description", description);
                        cmd.Parameters.AddWithValue("@Status", status);
                        cmd.Parameters.AddWithValue("@EstimatedCompletionTime", estimatedCompletionTime);
                        cmd.Parameters.AddWithValue("@TotalCost", totalCost);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Row updated successfully!");
                        }
                        else
                        {
                            MessageBox.Show("No rows updated. Please check the data.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating row: " + ex.Message);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
    }
}
