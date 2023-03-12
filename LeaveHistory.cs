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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace LeaveManagementSys
{
    public partial class LeaveHistory : Form
    {
        public string Name { get; set; }
        public LeaveHistory()
        {
            InitializeComponent();
            
        }
        private void showPending()
        {
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=LMSystemDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT * FROM Leave WHERE Employeename = @name AND LeaveId = (SELECT MAX(LeaveId) FROM Leave WHERE Employeename = @name)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@name", Name);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable table = new DataTable();
                adapter.Fill(table);
                dataGridView2.DataSource = table;

                if (dataGridView1.Rows.Count > 0 && dataGridView1.Rows[0].Cells["Status"].Value.ToString() == "Approved")
                {
                    button3.Visible = false;
                    button2.Visible = true;
                }else
                {
                    button3.Visible = true;
                    button2.Visible = false;
                }
            }



        }
        public void showLeave(String con)
        {
            string query = "SELECT * FROM Leave";

            using (SqlConnection connection = new SqlConnection(con))
            {
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                dataGridView1.DataSource = dataTable;
            }
        }
        public void showApprovedLeave(String con)
        {
            string query = "SELECT * FROM Leave WHERE status = @status";

            using (SqlConnection connection = new SqlConnection(con))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@status", "approved");
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                dataGridView1.DataSource = dataTable;
            }
        }
        private void LeaveHistory_Load(object sender, EventArgs e)
        {

            button3.Visible = false;
            button2.Visible = false;
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=LMSystemDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;";
            showPending();
            showApprovedLeave(connectionString);


        }
       
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=LMSystemDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;";
            SqlConnection connection = new SqlConnection(connectionString);
            // Get the selected value from the ComboBox control
            string selectedValue = comboBox1.SelectedValue.ToString();

            // Define a SQL query to select values from a database table based on the selected value
            string query = "SELECT * FROM Leave WHERE MyColumn = @SelectedValue";

            // Create a new SqlCommand object with the query and the SqlConnection object
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                // Add a parameter to the command to pass the selected value to the query
                command.Parameters.AddWithValue("@SelectedValue", selectedValue);

                // Create a new SqlDataAdapter object with the command
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    // Create a new DataTable object to store the results
                    DataTable table = new DataTable();

                    // Fill the DataTable object with the results of the query
                    adapter.Fill(table);

                    // Bind the DataTable object to the DataGridView control
                    dataGridView1.DataSource = table;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
        }

        private void label10_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Close();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Messages message = new Messages();
            message.Show();
            this.Close();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            Messages message = new Messages();
            message.Show();
            this.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            LeaveHistory leaveHistory = new LeaveHistory();
            leaveHistory.Show();
            this.Close();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            LeaveHistory leaveHistory = new LeaveHistory();
            leaveHistory.Show();
            this.Close();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            ManageLeaves manageLeaves= new ManageLeaves();
            manageLeaves.Show();
            this.Close();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            ManageLeaves manageLeaves = new ManageLeaves();
            manageLeaves.Show();
            this.Close();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            ApplyForLeave applyForLeave = new ApplyForLeave();
            applyForLeave.Show();
            this.Close();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            ApplyForLeave applyForLeave = new ApplyForLeave();
            applyForLeave.Show();
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
    }
}
