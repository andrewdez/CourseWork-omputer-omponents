using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CourseWork
{
    public partial class Form5 : Form
    {
        private string connectionString = "Server=DESKTOP-K2ID4TF;Database=ServiceCenter;User Id=user1;Password=user1;";
        private SqlDataAdapter dataAdapter;
        private DataTable dataTable;

        public Form5()
        {
            InitializeComponent();
            LoadComponentUsage();
            // Подія для кнопки пошуку
            searchButton.Click += SearchButton_Click;
            insertButton.Click += InsertButton_Click;
        }

        private void LoadComponentUsage()
        {
            try
            {
                dataTable = new DataTable();

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT * FROM ComponentUsage";

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

                if (!dataGridView1.Columns.Contains("DeleteButton"))
                {
                    DataGridViewButtonColumn deleteButtonColumn = new DataGridViewButtonColumn
                    {
                        Name = "DeleteButton",
                        HeaderText = "Delete",
                        Text = "Delete",
                        UseColumnTextForButtonValue = true
                    };
                    dataGridView1.Columns.Add(deleteButtonColumn);
                }

                dataGridView1.ReadOnly = false;
                dataGridView1.AllowUserToAddRows = false;
                dataGridView1.CellClick += dataGridView1_CellClick;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading component expenses: " + ex.Message);
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
                LoadComponentUsage();
                return;
            }

            try
            {
                // Фільтруємо дані за UsageID, ComponentName або ComponentType
                dataTable.DefaultView.RowFilter = $"Convert(UsageID, 'System.String') LIKE '%{searchText}%' OR " +
                                                  $"ComponentName LIKE '%{searchText}%' OR " +
                                                  $"ComponentType LIKE '%{searchText}%'";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error during search: " + ex.Message);
            }
        }



        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (e.ColumnIndex == dataGridView1.Columns["UpdateButton"].Index)
                {
                    UpdateRow(e.RowIndex);
                }
                else if (e.ColumnIndex == dataGridView1.Columns["DeleteButton"].Index)
                {
                    DeleteRow(e.RowIndex);
                }
            }
        }

        private void UpdateRow(int rowIndex)
        {
            try
            {
                int usageID = Convert.ToInt32(dataGridView1.Rows[rowIndex].Cells["UsageID"].Value);
                int orderID = Convert.ToInt32(dataGridView1.Rows[rowIndex].Cells["OrderID"].Value);
                int? componentID = dataGridView1.Rows[rowIndex].Cells["ComponentID"].Value != DBNull.Value ? (int?)Convert.ToInt32(dataGridView1.Rows[rowIndex].Cells["ComponentID"].Value) : null;
                string componentName = dataGridView1.Rows[rowIndex].Cells["ComponentName"].Value?.ToString();
                string componentType = dataGridView1.Rows[rowIndex].Cells["ComponentType"].Value?.ToString();
                decimal? price = dataGridView1.Rows[rowIndex].Cells["Price"].Value != DBNull.Value ? (decimal?)Convert.ToDecimal(dataGridView1.Rows[rowIndex].Cells["Price"].Value) : null;

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string query = "UPDATE ComponentUsage SET OrderID = @OrderID, ComponentID = @ComponentID, ComponentName = @ComponentName, " +
                                   "ComponentType = @ComponentType, Price = @Price WHERE UsageID = @UsageID";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@UsageID", usageID);
                        cmd.Parameters.AddWithValue("@OrderID", orderID);
                        cmd.Parameters.AddWithValue("@ComponentID", componentID.HasValue ? (object)componentID.Value : DBNull.Value);
                        cmd.Parameters.AddWithValue("@ComponentName", componentName ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@ComponentType", componentType ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@Price", price.HasValue ? (object)price.Value : DBNull.Value);

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


        private void DeleteRow(int rowIndex)
        {
            try
            {
                int usageID = Convert.ToInt32(dataGridView1.Rows[rowIndex].Cells["UsageID"].Value);

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string query = "DELETE FROM ComponentUsage WHERE UsageID = @UsageID";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@UsageID", usageID);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Row deleted successfully!");
                            LoadComponentUsage(); // Оновлення даних після видалення
                        }
                        else
                        {
                            MessageBox.Show("No rows deleted. Please check the data.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting row: " + ex.Message);
            }
        }
        private void InsertButton_Click(object sender, EventArgs e)
        {
            int orderID;
            int componentID;

            if (int.TryParse(orderIDTextBox.Text, out orderID) && int.TryParse(componentIDTextBox.Text, out componentID))
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();

                        // Отримуємо значення ComponentName, ComponentType, Price з таблиці Components
                        string query = "SELECT ComponentName, ComponentType, Price FROM Components WHERE ComponentID = @ComponentID";
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@ComponentID", componentID);

                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    string componentName = reader["ComponentName"].ToString();
                                    string componentType = reader["ComponentType"].ToString();
                                    decimal price = (decimal)reader["Price"];

                                    reader.Close(); // Закриваємо SqlDataReader перед виконанням наступного запиту

                                    // Додаємо новий рядок до таблиці ComponentUsage
                                    string insertQuery = "INSERT INTO ComponentUsage (OrderID, ComponentID, ComponentName, ComponentType, Price) " +
                                                         "VALUES (@OrderID, @ComponentID, @ComponentName, @ComponentType, @Price)";
                                    using (SqlCommand insertCmd = new SqlCommand(insertQuery, conn))
                                    {
                                        insertCmd.Parameters.AddWithValue("@OrderID", orderID);
                                        insertCmd.Parameters.AddWithValue("@ComponentID", componentID);
                                        insertCmd.Parameters.AddWithValue("@ComponentName", componentName);
                                        insertCmd.Parameters.AddWithValue("@ComponentType", componentType);
                                        insertCmd.Parameters.AddWithValue("@Price", price);

                                        int rowsAffected = insertCmd.ExecuteNonQuery();

                                        if (rowsAffected > 0)
                                        {
                                            MessageBox.Show("Row inserted successfully!");
                                            LoadComponentUsage(); // Оновлення даних після вставки
                                        }
                                        else
                                        {
                                            MessageBox.Show("No rows inserted. Please check the data.");
                                        }
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Component not found. Please check the ComponentID.");
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error inserting row: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Please enter valid OrderID and ComponentID.");
            }
        }

    }
}
