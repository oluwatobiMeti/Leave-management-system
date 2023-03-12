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
using System.Xml.Linq;

namespace LeaveManagementSys
{
    public partial class ApplyForLeave : Form
    {
        public ApplyForLeave()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // All fields are not empty, do something here
            if (!(Employee.Text == "" && Phone.Text == "" && Email.Text == "" && Reason.Text == "" && dateStart.Text == "" && dateEnd.Text == "" && category.Text == ""))
            {

                // Define connection string and SQL query
                string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=LMSystemDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;";
                // SQL query to insert data into the Leave table
                string insertQuery = "INSERT INTO [dbo].[Leave] ([reason], [phone], [Email], [Start Date], [End Date], [categories]) VALUES (@reason, @phone, @Email, @startDate, @endDate, @categories)";

                // Create a new SqlConnection object
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // Open the connection
                    connection.Open();

                    // Create a new SqlCommand object
                    using (SqlCommand command = new SqlCommand(insertQuery, connection))
                    {
                        // Set the parameter values for the query
                        command.Parameters.AddWithValue("@reason", Reason.Text);
                        command.Parameters.AddWithValue("@phone", Phone.Text);
                        command.Parameters.AddWithValue("@Email", Email.Text);
                        command.Parameters.AddWithValue("@startDate", DateTime.Parse(dateStart.Text));
                        command.Parameters.AddWithValue("@endDate", DateTime.Parse(dateEnd.Text));
                        command.Parameters.AddWithValue("@categories", category.Text);

                        // Execute the query
                        //int rowsAffected = command.ExecuteNonQuery();

                        // Check if any rows were affected by the query
                        //if (rowsAffected > 0)
                        //{
                            //Console.WriteLine("Data inserted successfully!");
                        ////}
                        //else
                       // {
                            //Console.WriteLine("Data insertion failed!");
                       // }
                        Home home = new Home();
                        home.Show();
                        this.Close();
                    }

                }
            } else {
                MessageBox.Show("Please fill in all fields.");
            }

        }
    }
}
