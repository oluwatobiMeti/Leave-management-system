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

namespace LeaveManagementSys
{
    public partial class changePassword : Form
    {
        public string Name { get; set; }
        public changePassword()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1 == textBox2)
            {
                string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=LMSystemDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Define the update query
                    string updateQuery = "UPDATE Employee SET Password = @password WHERE Name = @name";

                    // Create a SqlCommand object with the update query and connection
                    using (SqlCommand command = new SqlCommand(updateQuery, connection))
                    {
                        // Set the parameters for the update query
                        command.Parameters.AddWithValue("@NewValue", textBox2.Text);
                        command.Parameters.AddWithValue("@name", Name);

                        // Execute the update query
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            Console.WriteLine("Record updated successfully.");
                        }
                        else
                        {
                            Console.WriteLine("Record not found.");
                        }
                    }
                }

            }
        }
    }
}
