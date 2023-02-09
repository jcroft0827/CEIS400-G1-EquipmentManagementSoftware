using MySql.Data;
using MySql.Data.MySqlClient;

namespace CEIS400_G1_EquipmentManagementSoftware
{
    public partial class Form1 : Form
    {
        string connectionString = "server=sql9.freesqldatabase.com;user=sql9596728;database=sql9596728;password=SQtBTCU8A2;";
        MySqlConnection connection = null; MySqlDataReader Reader = null;
        // Use the below code to open a connection to the database
        //MySqlConnection mySqlConnection = new MySqlConnection(connectionString);
        //mySqlConnection.Open();

        public Form1()
        {
            InitializeComponent();
        }

        public struct User // This will store the user information
        {
            int userID;
            string userName;
            string userAdmin; // This will be Y for yes and N for no
        };

        private void loginBtn_Click(object sender, EventArgs e)
        {
            // This button will allow the user to login to the system

            // If statement to make sure the login text box (loginTxtBox) is not empty
            if (loginTxtBox.Text == "")
            {
                MessageBox.Show("Enter a work id number to login!", "Enter Work ID Number", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                loginTxtBox.Clear();
                loginTxtBox.Focus();
            } else
            {
            // Variables
            string fName = "";   // User's First Name
            string lName = "";   // User's Last Name
            string workID = loginTxtBox.Text;  // Work ID - Badge Number
            string dbID = "";    // Database ID - Primary Key
            try {

                    // Code to open a connection to the database
                    connection = new MySqlConnection(connectionString);
                    connection.Open();
                    MySqlCommand cmd = connection.CreateCommand();
                    string query = "SELECT * FROM `users` WHERE `workID` = '" + workID + "';";
                    cmd.CommandText = query;
                    Reader = cmd.ExecuteReader();
                    while (Reader.Read())
                    {
                        dbID = Reader.GetString("ID");
                        fName = Reader.GetString("fName");
                        lName = Reader.GetString("lName");
                    }
                    if (dbID == "")
                    {
                        // The code entered doesn't match a user in the database
                        // User doesn't exist
                        MessageBox.Show("User Doesn't Exist, Try Again!", "User Doesn't Exist", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        loginTxtBox.Clear();
                        loginTxtBox.Focus();
                    } else
                    {
                        // User Does Exist
                        idLabel.Text = workID;
                        greetingLabel.Text = "Welcome, " + fName + "!";
                        loginPanel.Visible = false;
                        searchTxtBox.Clear();
                    }
                } catch { MessageBox.Show("Error!"); 
                } finally
                {
                    connection.Close();
                    connection.Dispose();
                };
            // Code to allow the user in (IfStatement)
            }
        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            // This button will allow the user to search for inventory
            
            // Variables

            // Code to query the database

            // Code to fill datagridview

        }

        private void adminBtn_Click(object sender, EventArgs e)
        {
            // This button will allow the user to enter the admin screen

            // Code to allow user into the admin screen
        }

        private void inventoryDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // This will allow the user to interact with the datagridview

            /* When a button is clicked the system will log whether the user
               is checking in that item or checking out that item, update the
               database and log the user out afterward */
        }
    }
}