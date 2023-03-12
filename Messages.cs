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
    public partial class Messages : Form
    {
        
        public Messages()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Messages_Load(object sender, EventArgs e)
        {
            // Retrieve the leave details from the updated record in the Leave table
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=LMSystemDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;";
            string query = "SELECT [reason], [status], [Start Date], [End Date] FROM [dbo].[Leave] WHERE [LeaveId] = @LeaveId";
            int leaveId = 1; // the ID of the updated leave record
            string message;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@LeaveId", leaveId);
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        // Format the leave details into a message string
                        string reason = reader.GetString(0);
                        string status = reader.GetString(1);
                        DateTime startDate = reader.GetDateTime(2);
                        DateTime endDate = reader.GetDateTime(3);
                        message = string.Format("Leave taken for {0} from {1} to {2}. Reason: {3}. Status: {4}.",
                            startDate.ToShortDateString(), endDate.ToShortDateString(), reason, status);
                    }
                    else
                    {
                        message = "Leave record not found.";
                    }
                    reader.Close();
                }
                connection.Close();
            }

            // Insert the message into a label
            this.message.Text = message;

        }
    }
}
