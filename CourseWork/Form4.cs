﻿using ServiceCenterApp;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CourseWork
{
    public partial class Form4 : Form
    {
        private string connectionString = DatabaseConnection.GetConnection();
        private SqlDataAdapter dataAdapter;
        private DataTable dataTable;

        public Form4()
        {
            InitializeComponent();
            LoadEmployees();
            // Подія для кнопки пошуку
            searchButton.Click += SearchButton_Click;
        }

        private void LoadEmployees()
        {
            try
            {
                dataTable = new DataTable();

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT * FROM Employee";

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
                MessageBox.Show("Error loading employees: " + ex.Message);
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
                LoadEmployees();
                return;
            }

            try
            {
                // Фільтруємо дані за EmployeeID, EmployeeName, Position або Status
                dataTable.DefaultView.RowFilter = $"Convert(EmployeeID, 'System.String') LIKE '%{searchText}%' OR " +
                                                  $"EmployeeName LIKE '%{searchText}%' OR " +
                                                  $"Position LIKE '%{searchText}%' OR " +
                                                  $"Status LIKE '%{searchText}%'";
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
                int employeeID = Convert.ToInt32(dataGridView1.Rows[rowIndex].Cells["EmployeeID"].Value);
                string employeeName = dataGridView1.Rows[rowIndex].Cells["EmployeeName"].Value.ToString();
                string position = dataGridView1.Rows[rowIndex].Cells["Position"].Value.ToString();
                string status = dataGridView1.Rows[rowIndex].Cells["Status"].Value.ToString();

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string query = "UPDATE Employee SET EmployeeName = @EmployeeName, Position = @Position, Status = @Status " +
                                   "WHERE EmployeeID = @EmployeeID";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@EmployeeID", employeeID);
                        cmd.Parameters.AddWithValue("@EmployeeName", employeeName);
                        cmd.Parameters.AddWithValue("@Position", position);
                        cmd.Parameters.AddWithValue("@Status", status);

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
                int employeeID = Convert.ToInt32(dataGridView1.Rows[rowIndex].Cells["EmployeeID"].Value);

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string query = "DELETE FROM Employee WHERE EmployeeID = @EmployeeID";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@EmployeeID", employeeID);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Row deleted successfully!");
                            LoadEmployees(); // Оновлення даних після видалення
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
    }
}
