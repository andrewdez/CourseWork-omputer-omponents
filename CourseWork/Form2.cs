using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CourseWork
{
    public partial class AddOrder : Form
    {
        public AddOrder()
        {
            InitializeComponent();
        }
        private string connectionString = "Server=DESKTOP-K2ID4TF;Database=ServiceCenter;User Id=user1;Password=user1;";
        // Логіка кнопки Save
        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    // SQL-запит на вставку даних у таблицю Order1
                    string query = "INSERT INTO Order1 (ClientName, ClientPhone, Description, Status, EstimatedCompletionTime, TotalCost) " +
                                   "VALUES (@ClientName, @ClientPhone, @Description, 'in progress', @EstimatedCompletionTime, @TotalCost)";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // Передача значень з форми у запит
                        cmd.Parameters.AddWithValue("@ClientName", textBox1.Text);
                        cmd.Parameters.AddWithValue("@ClientPhone", textBox2.Text);
                        cmd.Parameters.AddWithValue("@Description", textBox3.Text);
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