using ServiceCenterApp;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CourseWork
{
    public partial class Form3 : Form
    {
        private string connectionString = DatabaseConnection.GetConnection();
        private SqlDataAdapter dataAdapter;
        private DataTable dataTable;

        public Form3()
        {
            InitializeComponent();
            LoadOrders();
            // Подія для кнопки пошуку
            searchButton.Click += SearchButton_Click;
        }

        private void LoadOrders()
        {
            try
            {
                dataTable = new DataTable();

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT * FROM Order1";

                    dataAdapter = new SqlDataAdapter(query, conn);
                    dataAdapter.Fill(dataTable);
                }

                dataGridView1.DataSource = dataTable;

                if (!dataGridView1.Columns.Contains("UpdateButton"))
                {
                    DataGridViewButtonColumn updateButtonColumn = new DataGridViewButtonColumn
                    {
                        Name = "UpdateButton",
                        HeaderText = "Update",
                        Text = "Update",
                        UseColumnTextForButtonValue = true
                    };
                    dataGridView1.Columns.Add(updateButtonColumn);
                }

                dataGridView1.ReadOnly = false;
                dataGridView1.AllowUserToAddRows = false;
                dataGridView1.CellClick += dataGridView1_CellClick;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading orders: " + ex.Message);
            }
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            PerformSearch(searchTextBox.Text);
        }

        private void PerformSearch(string searchText)
        {
            if (string.IsNullOrWhiteSpace(searchText))
            {
                // Якщо поле пошуку порожнє, завантажуємо всі дані
                LoadOrders();
                return;
            }

            try
            {
                // Фільтруємо дані за OrderID, ClientName, ClientPhone або Status
                dataTable.DefaultView.RowFilter =
                                                  $"ClientName LIKE '%{searchText}%' OR " +
                                                  $"ClientPhone LIKE '%{searchText}%' OR " +
                                                  $"Status LIKE '%{searchText}%'";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error during search: " + ex.Message);
            }
        }


        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["UpdateButton"].Index && e.RowIndex >= 0)
            {
                UpdateRow(e.RowIndex);
            }
        }

        private void UpdateRow(int rowIndex)
        {
            try
            {
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
