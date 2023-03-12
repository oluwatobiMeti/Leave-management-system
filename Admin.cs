using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Common;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Net;

namespace LeaveManagementSys
{
    public partial class Admin : Form
    {
        SqlDataAdapter sda;
        DataTable dt;

         
        public Admin()
        {
            InitializeComponent();
        }
        private void ShowEmployees()
        {
            // Define connection string
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=LMSystemDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;";
            SqlConnection con = new SqlConnection(connectionString);
            sda = new SqlDataAdapter("select * from Employee", con);
            dt = new DataTable();
            sda.Fill(dt);
            EmployeeList.DataSource = dt;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click_1(object sender, EventArgs e)
        {

        }
        
        private void EmployeeList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            String[] textBoxes = { textBox1.Text, textBox2.Text , textBox3.Text, textBox4.Text , textBox5.Text , textBox6.Text , textBox7.Text , textBox8.Text, textBox9.Text, textBox10.Text, textBox11.Text, textBox12.Text };
            if (EmployeeList.SelectedRows.Count > 0)
            {
                DataGridViewRow row = EmployeeList.SelectedRows[0];

                // Get the column names from the DataGridView
                List<string> columnNames = new List<string>();
                foreach (DataGridViewColumn column in EmployeeList.Columns)
                {
                    columnNames.Add(column.Name);
                }

                // Update the values in the DataGridView and the corresponding row in the database
                for (int i = 0; i < columnNames.Count; i++)
                {
                    string columnName = columnNames[i];
                    if (row.Cells[columnName].Value != null)
                    {
                        row.Cells[columnName].Value = textBoxes[i];
                        // Update the corresponding column in the database using an UPDATE statement
                    }
                }
            }

        }


        private void Admin_Load(object sender, EventArgs e)
        { 
           ShowEmployees();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int eligibleLeaveDays = 0;
            string Phone = textBox3.Text;
            string Password = textBox2.Text;
            string Name = textBox1.Text;
            string email = textBox4.Text;
            string address = textBox5.Text;
            string userType = textBox8.Text;
            string username = textBox12.Text;
            if (textBox7.Text == "")
            {
                MessageBox.Show("you have not fill all inputs");
            }
            else
            {
                eligibleLeaveDays = int.Parse(textBox7.Text);
            }
            string status = textBox9.Text;
            DateTime dateJoin = DateTime.Parse(textBox10.Text);

            if (!(Phone == "" && Password == "" && Name == "" && email == "" && address == "" && userType == "" && status == "" && username == ""))
            {
                // Perform insert query using the values from the textboxes

                // Define connection string
                string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=LMSystemDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;";

                // Create new SqlConnection object
                SqlConnection connection = new SqlConnection(connectionString);

                // Define insert query
                string insertQuery = "INSERT INTO Employee (Phone, Password, Name, Email, Address, UserType, EligibleLeaveDays, Status, DateJoin, username) VALUES (@Phone, @Password, @Name, @Email, @Address, @UserType, @EligibleLeaveDays, @Status, @DateJoin, @username)";

                // Create new SqlCommand object with insert query and SqlConnection object
                SqlCommand command = new SqlCommand(insertQuery, connection);

                // Add parameters to the SqlCommand object
                command.Parameters.AddWithValue("@Phone", Phone);
                command.Parameters.AddWithValue("@Password", Password);
                command.Parameters.AddWithValue("@Name", Name);
                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@Address", address);
                command.Parameters.AddWithValue("@UserType", userType);
                command.Parameters.AddWithValue("@EligibleLeaveDays", eligibleLeaveDays);
                command.Parameters.AddWithValue("@Status", status);
                command.Parameters.AddWithValue("@DateJoin", dateJoin);
                command.Parameters.AddWithValue("@username", username);

                // Open SqlConnection object
                connection.Open();

                // Execute insert query
                int rowsAffected = command.ExecuteNonQuery();

                // Close SqlConnection object
                connection.Close();
                ShowEmployees();

            }
            else
            {
                MessageBox.Show("Please fill in all required fields.");
            }


           

        }

        private void EditBtn_Click(object sender, EventArgs e)
        {
            int eligibleLeaveDays = 0;
            string Phone = textBox3.Text;
            string Password = textBox2.Text;
            string Name = textBox1.Text;
            string email = textBox4.Text;
            string address = textBox5.Text;
            string userType = textBox8.Text;
            string username = textBox12.Text;
            string status = textBox9.Text;
            string dateJoin = textBox3.Text;
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=LMSystemDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;";

            // Create new SqlConnection object
            SqlConnection connection = new SqlConnection(connectionString);

            // Define insert query
            string insertQuery = "UPDATE Employee SET (Phone = @Phone, password = @Password, Name = @Name, Email = @Email,Address = @Address, UserType = @UserType, EligibleLeaveDays = @EligibleLeaveDays, Status = @Status, DateJoin = @DateJoin, username = @username)";

            // Create new SqlCommand object with insert query and SqlConnection object
            SqlCommand command = new SqlCommand(insertQuery, connection);

            // Add parameters to the SqlCommand object
            command.Parameters.AddWithValue("@Phone", Phone);
            command.Parameters.AddWithValue("@Password", Password);
            command.Parameters.AddWithValue("@Name", Name);
            command.Parameters.AddWithValue("@Email", email);
            command.Parameters.AddWithValue("@Address", address);
            command.Parameters.AddWithValue("@UserType", userType);
            command.Parameters.AddWithValue("@EligibleLeaveDays", eligibleLeaveDays);
            command.Parameters.AddWithValue("@Status", status);
            command.Parameters.AddWithValue("@DateJoin", dateJoin);
            command.Parameters.AddWithValue("@username", username);

            // Open SqlConnection object
            connection.Open();

            // Execute insert query
            int rowsAffected = command.ExecuteNonQuery();

            // Close SqlConnection object
            connection.Close();
            ShowEmployees();

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void DelectBtn_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=LMSystemDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;";

            // Create new SqlConnection object
            SqlConnection connection = new SqlConnection(connectionString);

            // Define insert query
            string insertQuery = "DELETE FROM Employee WHERE username = @username";
            // Create new SqlCommand object with insert query and SqlConnection object
            SqlCommand command = new SqlCommand(insertQuery, connection);
            command.Parameters.AddWithValue("@username", textBox12.Text);

        }

        private void name_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void phone_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
