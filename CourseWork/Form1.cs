using System.Data.SqlClient;

namespace CourseWork
{
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
            // SQL-����� ��� ������ ������� ����� � ������� (���������, "Customers")
            string query = "SELECT TOP 1 order_date FROM Orders"; // ������ "Customers" �� "Name" �� ���� ������� � �������

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // ��������� ������ � ������� �����
                        object result = command.ExecuteScalar();

                        if (result != null)
                        {
                            // ��������� ���������� � Label ��� TextBox
                            labelResult.Text = result.ToString();
                        }
                        else
                        {
                            labelResult.Text = "��� �� ��������.";
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"������� �'������� ��� ������: {ex.Message}");
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FetchData();
        }
    }
}