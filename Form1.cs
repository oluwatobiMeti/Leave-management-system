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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace LeaveManagementSys
{
    public partial class Form1 : Form
    {
        Home home1 = new Home();
        Messages Messages = new Messages();
        ManageLeaves manageLeaves= new ManageLeaves();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            password.PasswordChar = '*';
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            changePassword cpass = new changePassword();
            LeaveHistory leaveHistory = new LeaveHistory();
            // Define connection string and SQL query
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=LMSystemDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;";
            string query = "SELECT * FROM Employee WHERE username=@username AND Password=@Password";

            // Create new SqlConnection object
            SqlConnection connection = new SqlConnection(connectionString);

            // Create new SqlCommand object with query and SqlConnection object
            SqlCommand command = new SqlCommand(query, connection);

            // Add parameters to the SqlCommand object
            command.Parameters.AddWithValue("@username", Username.Text);
            command.Parameters.AddWithValue("@Password", password.Text);

            // Open SqlConnection object
            connection.Open();

            // Execute query and retrieve results using SqlDataReader
            SqlDataReader reader = command.ExecuteReader();

            // Check if a row was returned
            if (reader.HasRows)
            {
                
                while (reader.Read())
                {
                    // Retrieve values from row and store in variables
                    string name = reader.GetString(2);
                    
                    home1.Name = name;
                    cpass.Name = name;
                    Messages.Name= name;
                    manageLeaves.Name = name;
                    leaveHistory.Name = name;
                    if (name == "Admin")
                    {
                        Admin admin= new Admin();
                        admin.Show();
                        //this.Close();
                    } else
                    {
                        home1.Show();
                        //this.Close();
                    }

                   
                  
                }
                
               

            }
            else
            {
                // Authentication failed, display error message
                MessageBox.Show("Invalid username or password.");
            }

            // Close SqlDataReader and SqlConnection objects
            reader.Close();
            connection.Close();
        }

        
    }
}
