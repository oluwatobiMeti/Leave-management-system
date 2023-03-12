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
    public partial class managerForm : Form
    {
        public managerForm()
        {
            InitializeComponent();
            
        }

        private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            // Check if the edited cell is in the column you want to edit with the ComboBox
            if (e.ColumnIndex == 1) // Replace with the index of the column you want to edit
            {
                // Get the editing control of the current cell
                DataGridViewComboBoxEditingControl comboBoxEditingControl =
                    dataGridView1.EditingControl as DataGridViewComboBoxEditingControl;

                // Set the DataSource, DisplayMember, and ValueMember properties of the editing control
                comboBoxEditingControl.DataSource = comboBox1.DataSource;
                comboBoxEditingControl.DisplayMember = comboBox1.DisplayMember;
                comboBoxEditingControl.ValueMember = comboBox1.ValueMember;

                // Set the value of the editing control to the value of the current cell
                string currentValue = dataGridView1[e.ColumnIndex, e.RowIndex].Value.ToString();
                comboBoxEditingControl.SelectedValue = currentValue;
            }
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            // Check if the edited cell is in the column you want to edit with the ComboBox
            if (e.ColumnIndex == 3) // Replace with the index of the column you want to edit
            {
                // Get the value of the editing control and set it as the value of the current cell
                DataGridViewComboBoxEditingControl comboBoxEditingControl =
                    dataGridView1.EditingControl as DataGridViewComboBoxEditingControl;
                string newValue = comboBoxEditingControl.SelectedValue.ToString();
                dataGridView1[e.ColumnIndex, e.RowIndex].Value = newValue;
            }
        }

        private void managerForm_Load(object sender, EventArgs e)
        {
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=LMSystemDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Employee";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable table = new DataTable();
                adapter.Fill(table);
                dataGridView1.DataSource = table;
            

            }

        }
    }
}
