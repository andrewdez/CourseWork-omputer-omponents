﻿using System;
using System.Data;
using System.Data.SqlClient; 

namespace CourseWork
{
    public class DataBase
    {
        private string connectionString = "DESKTOP-K2ID4TF;Database=ComputerPartsServiceCenter;User Id=user1;Password=user1;";

        public void TestConnection()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    Console.WriteLine("Connection successful!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Connection failed: {ex.Message}");
                }
            }
        }
    }
}
/*
public partial class Form1 : Form
    {
        private string connectionString = "Server=DESKTOP-K2ID4TF;Database=ComputerPartsServiceCenter;User Id=user1;Password=user1;";

        public Form1()
        {
            InitializeComponent();
        }

        private void buttonFetchData_Click(object sender, EventArgs e)
        {
            FetchData();
        }

        private void FetchData()
        {
            // SQL-запит для вибору першого рядка з таблиці (наприклад, "Customers")
            string query = "SELECT TOP 1 Name FROM Customers"; // Замініть "Customers" та "Name" на ваші таблицю і колонку

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Виконання запиту і читання даних
                        object result = command.ExecuteScalar();

                        if (result != null)
                        {
                            // Виведення результату у Label або TextBox
                            labelResult.Text = result.ToString();
                        }
                        else 
                        {
                            labelResult.Text = "Дані не знайдено.";
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Помилка з'єднання або запиту: {ex.Message}");
                }
            }
        }
    }
}*/