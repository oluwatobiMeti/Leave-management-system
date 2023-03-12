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
    public partial class ManageLeaves : Form
    {
        public string Name { get; set; }
        public ManageLeaves()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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
        private void ManageLeaves_Load(object sender, EventArgs e)
        {
            showLeave();
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
            Messages messages = new Messages();
            messages.Show();
            this.Close();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Messages messages = new Messages();
            messages.Show();
            this.Close();

        }
        private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            // Check if the edited cell is in the column you want to edit with the ComboBox
            if (e.ColumnIndex == e.ColumnIndex)
            {
                // Get the editing control of the current cell
                DataGridViewComboBoxEditingControl comboBoxEditingControl =
                    dataGridView1.EditingControl as DataGridViewComboBoxEditingControl;

                // Set the DataSource, DisplayMember, and ValueMember properties of the editing control
                comboBoxEditingControl.DataSource = comboBox2.DataSource;
                comboBoxEditingControl.DisplayMember = comboBox2.DisplayMember;
                comboBoxEditingControl.ValueMember = comboBox2.ValueMember;

                // Set the value of the editing control to the value of the current cell
                string currentValue = dataGridView1[e.ColumnIndex, e.RowIndex].Value.ToString();
                comboBoxEditingControl.SelectedValue = currentValue;
            }
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            // Check if the edited cell is in the column you want to edit with the ComboBox
            if (e.ColumnIndex == e.ColumnIndex)
            {
                // Get the value of the editing control and set it as the value of the current cell
                DataGridViewComboBoxEditingControl comboBoxEditingControl =
                    dataGridView1.EditingControl as DataGridViewComboBoxEditingControl;
                string newValue = comboBoxEditingControl.SelectedValue.ToString();
                dataGridView1[e.ColumnIndex, e.RowIndex].Value = newValue;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=LMSystemDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM leave ORDER BY @value";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@value", comboBox2.Text);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable table = new DataTable();
                adapter.Fill(table);
                dataGridView1.DataSource = table;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {
            LeaveHistory leaveHistory= new LeaveHistory();
            leaveHistory.Show();
            this.Close();
        }

        private void label8_Click_1(object sender, EventArgs e)
        {
            Messages messages = new Messages();
            messages.Show();
            this.Close();
        }

        private void pictureBox5_Click_1(object sender, EventArgs e)
        {
            ApplyForLeave apply = new ApplyForLeave();
            apply.Show();
            this.Close();
        }

        private void pictureBox3_Click_1(object sender, EventArgs e)
        {
            ManageLeaves manageLeaves = new ManageLeaves();
            manageLeaves.Show();
            this.Close();
        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            LeaveHistory leaveHistory = new LeaveHistory();
            leaveHistory.Show();
            this.Close();
        }

        private void label4_Click_1(object sender, EventArgs e)
        {
            ApplyForLeave apply = new ApplyForLeave();
            apply.Show(); this.Close();
        }

        private void label3_Click_1(object sender, EventArgs e)
        {
            ManageLeaves manageLeaves = new ManageLeaves();
            manageLeaves.Show();
            this.Close();
        }

        private void pictureBox6_Click_1(object sender, EventArgs e)
        {
            Messages messages = new Messages();
            messages.Show();
            this.Close();
        }

        private void pictureBox4_Click_1(object sender, EventArgs e)
        {
            Calendar calendar= new Calendar();
            calendar.Show();
            this.Close();
        }

        private void label5_Click_1(object sender, EventArgs e)
        {
            Calendar calendar = new Calendar();
            calendar.Show();
            this.Close();
        }
    }
}
