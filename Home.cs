using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LeaveManagementSys
{
    public partial class Home : Form
    {
        public string Name { get; set; }
        public Home()
        {
            InitializeComponent();
        }

        private void showPending()
        {
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=LMSystemDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT Employeename, status, [Start Date], [End date], reason, categories FROM Leave WHERE Employeename = @name AND LeaveId = (SELECT MAX(LeaveId) FROM Leave WHERE Employeename = @name)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@name", Name);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable table = new DataTable();
                adapter.Fill(table);
                dataGridView2.DataSource = table;
            }



        }
        public void showEligiblity()
        {
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=LMSystemDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Define the select query
                string selectQuery = "SELECT EligibleLeaveDays FROM Employee WHERE name = @name";

                // Create a SqlCommand object with the select query and connection
                using (SqlCommand command = new SqlCommand(selectQuery, connection))
                {
                    // Set the parameter for the select query
                    command.Parameters.AddWithValue("@Name", Name);

                    // Execute the select query and retrieve the result
                    object result = command.ExecuteScalar();

                    // Check if a result was returned
                    if (result != null)
                    {
                        // Convert the result to a string and assign it to the label
                        label10.Text = Name + " you have " + result.ToString() + " days";
                    }
                    else
                    {
                        label10.Text = "No result found.";
                    }
                    
                }
            }

        }

        private void showLeave()
        {
           
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=LMSystemDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Leave where Employeename = @name";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@name", Name);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable table = new DataTable();
                adapter.Fill(table);
                dataGridView1.DataSource = table;
            }

        }
       
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
            Home home = new Home();
            home.Show();
            this.Close();


        }

        private void label1_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Close();

        }

        private void label2_Click(object sender, EventArgs e)
        {
            LeaveHistory lh = new LeaveHistory();
            lh.Show();
            this.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            LeaveHistory lh = new LeaveHistory();
            lh.Show();
            this.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {
             ManageLeaves mL = new ManageLeaves();
             mL.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            ManageLeaves mL = new ManageLeaves();
            mL.Show();
            this.Close();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            ApplyForLeave apply = new ApplyForLeave();
            apply.Show();
            this.Close();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            ApplyForLeave apply = new ApplyForLeave();
            apply.Show();
            this.DialogResult = DialogResult.OK;
            this.Close();

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Calendar calendar = new Calendar();
            calendar.Show();
            this.Close();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Calendar calendar = new Calendar();
            calendar.Show();
            this.Close();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            Messages messages= new Messages();
            messages.Show();
            this.Close();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Messages messages = new Messages();
            messages.Show();
            this.Close();

        }

        private void Home_Load(object sender, EventArgs e)
        {
            showLeave();
            showPending();
            showEligiblity();
            
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
