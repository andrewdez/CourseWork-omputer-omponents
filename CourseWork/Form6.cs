using ServiceCenterApp;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CourseWork
{
    public partial class Form6 : Form
    {
        private string connectionString = DatabaseConnection.GetConnection();
        private SqlDataAdapter dataAdapter;
        private DataTable dataTable;

        public Form6()
        {
            InitializeComponent();
            LoadForm6();
            // Подія для кнопки пошуку
            searchButton.Click += SearchButton_Click;
        }

        private void LoadForm6()
        {
            try
            {
                dataTable = new DataTable();

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT * FROM Components";

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
                MessageBox.Show("Error loading components: " + ex.Message);
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
                LoadForm6();
                return;
            }

            try
            {
                // Фільтруємо дані за ComponentID, ComponentName або ComponentType
                dataTable.DefaultView.RowFilter = $"Convert(ComponentID, 'System.String') LIKE '%{searchText}%' OR " +
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
                int componentID = Convert.ToInt32(dataGridView1.Rows[rowIndex].Cells["ComponentID"].Value);
                string componentName = dataGridView1.Rows[rowIndex].Cells["ComponentName"].Value.ToString();
                string componentType = dataGridView1.Rows[rowIndex].Cells["ComponentType"].Value.ToString();
                int stockQuantity = Convert.ToInt32(dataGridView1.Rows[rowIndex].Cells["StockQuantity"].Value);
                decimal price = Convert.ToDecimal(dataGridView1.Rows[rowIndex].Cells["Price"].Value);

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string query = "UPDATE Components SET ComponentName = @ComponentName, ComponentType = @ComponentType, " +
                                   "StockQuantity = @StockQuantity, Price = @Price WHERE ComponentID = @ComponentID";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@ComponentID", componentID);
                        cmd.Parameters.AddWithValue("@ComponentName", componentName);
                        cmd.Parameters.AddWithValue("@ComponentType", componentType);
                        cmd.Parameters.AddWithValue("@StockQuantity", stockQuantity);
                        cmd.Parameters.AddWithValue("@Price", price);

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
                int componentID = Convert.ToInt32(dataGridView1.Rows[rowIndex].Cells["ComponentID"].Value);

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string query = "DELETE FROM Components WHERE ComponentID = @ComponentID";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@ComponentID", componentID);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Row deleted successfully!");
                            LoadForm6(); // Оновлення даних після видалення
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
