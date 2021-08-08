//! mysql reference
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Linq;

//! grab login label and move entire form
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace thecruds
{
    public partial class Login : Form
    {
        //! grab login label and move entire form
        public const int WM_NCLBUTTONDOWN = 0xA1;

        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        private class DBConnect
        {
            public MySqlConnection connection;

            public DBConnect()
            {
                Initialize();
            }

            public void Initialize()
            {
                string dbconn = "server=localhost;port=3306;username=root;password=;database=mydatabase;";
                connection = new MySqlConnection(dbconn);
            }

            public Boolean OpenConnection()
            {
                try
                {
                    connection.Open();
                    return true;
                }
                catch (MySqlException ex)
                {
                    switch (ex.Number)
                    {
                        case 0:
                            MessageBox.Show("Cannot connect to server.  Contact administrator");
                            break;

                        case 1045:
                            MessageBox.Show("Invalid username/password, please try again");
                            break;
                    }
                    return false;
                }
            }

            public Boolean CloseConnection()
            {
                try
                {
                    connection.Close();
                    return true;
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.Message);
                    return false;
                }
            }
        }

        public Login()
        {
            InitializeComponent();
            DBConnect db = new DBConnect();
            db.Initialize();
        }

        private void showpassword_CheckedChanged(object sender, EventArgs e)
        {
            if (showpassword.Checked == true)
            {
                txtpass.UseSystemPasswordChar = false;
            }
            else
            {
                txtpass.UseSystemPasswordChar = true;
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        //! Function For Loggin in
        public Boolean userLogin()
        {
            DBConnect db = new DBConnect();
            string username = txtuser.Text;
            string password = txtpass.Text;
            string login_query = "SELECT * FROM login_users WHERE my_username = @username AND my_password = @password";
            db.OpenConnection();
            MySqlCommand cmd_login = new MySqlCommand(login_query, db.connection);
            cmd_login.Parameters.Add("@username", MySqlDbType.VarChar).Value = username;
            cmd_login.Parameters.Add("@password", MySqlDbType.VarChar).Value = password;
            MySqlDataReader reader;
            reader = cmd_login.ExecuteReader();
            if (reader.Read() == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void user_online()
        {
            DBConnect db = new DBConnect();
            string username = txtuser.Text;
            string update_online = "UPDATE login_users SET my_status = @mystatus WHERE my_username = @username";
            MySqlCommand cmd_update = new MySqlCommand(update_online,db.connection);
            cmd_update.Parameters.Add("@mystatus", MySqlDbType.VarChar).Value = "Online";
            cmd_update.Parameters.Add("@username",MySqlDbType.VarChar).Value = username;
            db.OpenConnection();
            cmd_update.ExecuteNonQuery();
            db.CloseConnection();
        }
        //! Function for Ceating account
        public void createuser()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            int length = 6;
            var random = new Random();
            string randomString = new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
            string date_id = DateTime.Now.ToString("ddMMyyyyhhmmss");
            //! input variables
            string myid = date_id + randomString;
            string username = txtuser.Text;
            string password = txtuser.Text;
            string user_status = "Offline";
            string lastname = txtlname.Text;
            string firstname = txtfname.Text;
            string middlename = txtmname.Text;
            string email = txtemail.Text;
            string contact = txtcontact.Text;
            DBConnect db = new DBConnect();
            string create_q = "INSERT INTO login_users (my_id,my_username,my_password,my_status) VALUES (@myid,@myusername,@mypassword,@mystatus);" +
            "INSERT INTO info_users (my_id,lastname,firstname,middlename,email,contact) VALUES (@myid,@lastname,@firstname,@middlename,@email,@contact);";
            db.OpenConnection();
            MySqlCommand createcmd = new MySqlCommand(create_q, db.connection);
            createcmd.Parameters.Add("@myid", MySqlDbType.VarChar).Value = myid;
            createcmd.Parameters.Add("@myusername", MySqlDbType.VarChar).Value = username;
            createcmd.Parameters.Add("@mypassword", MySqlDbType.VarChar).Value = password;
            createcmd.Parameters.Add("@mystatus", MySqlDbType.VarChar).Value = user_status;
            createcmd.Parameters.Add("@lastname", MySqlDbType.VarChar).Value = lastname;
            createcmd.Parameters.Add("@firstname", MySqlDbType.VarChar).Value = firstname;
            createcmd.Parameters.Add("@middlename", MySqlDbType.VarChar).Value = middlename;
            createcmd.Parameters.Add("@email", MySqlDbType.VarChar).Value = email;
            createcmd.Parameters.Add("@contact", MySqlDbType.VarChar).Value = contact;
            if (createcmd.ExecuteNonQuery() == 1)
            {
                string msg = "User " + txtuser.Text + ", has been created succesfully!";
                string msgTitle = "Create Account Success";
                MessageBox.Show(msg, msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            db.CloseConnection();
        }

        public Boolean clarify()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            int length = 6;
            var random = new Random();
            string randomString = new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
            string date_id = DateTime.Now.ToString("ddMMyyyyhhmmss");
            //! input variables
            string myid = date_id + randomString;
            string username = txtuser.Text;
            //! if user exist returns false
            string getuser = "SELECT my_id,my_username FROM login_users WHERE my_id = @myid OR my_username = @username";
            DBConnect db = new DBConnect();
            db.OpenConnection();
            MySqlCommand cmd_clarify = new MySqlCommand(getuser, db.connection);
            cmd_clarify.Parameters.Add("@myid", MySqlDbType.VarChar).Value = myid;
            cmd_clarify.Parameters.Add("@username", MySqlDbType.VarChar).Value = username;
            MySqlDataReader reader;
            reader = cmd_clarify.ExecuteReader();
            if (reader.Read() == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Boolean empty_short()
        {
            int charlength = 8;
            if (txtuser.Text.Length < charlength || txtpass.Text.Length < charlength)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //! Login User
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (empty_short())
            {
                string msg = "Username / Password cannot be < 8 characters.";
                string msgTitle = "Input Fields too short";
                MessageBox.Show(msg, msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (userLogin())
                {
                    string username = txtuser.Text;
                    user_online();
                    string msg = "User Found";
                    string msgTitle = "Login Success!";
                    MessageBox.Show(msg, msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    UserForm toUserForm = new UserForm(username);
                    toUserForm.ShowDialog();
                }
                else
                {
                    string msg = "User NOT Found";
                    string msgTitle = "Login Failed!";
                    MessageBox.Show(msg, msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        //! Create User
        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (empty_short())
            {
                string msg = "Username / Password cannot be < 8 characters.";
                string msgTitle = "Input Fields too short";
                MessageBox.Show(msg, msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (clarify())
                {
                    string msg = "Username taken, try another";
                    string msgTitle = "Create Account Failed";
                    MessageBox.Show(msg, msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    createuser();
                }
            }
        }

        //!Close Application
        private void lblClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void lblClose_MouseHover(object sender, EventArgs e)
        {
            System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();
            ToolTip1.SetToolTip(this.lblClose, "Close Application");
        }

        //! Minimize Application
        private void lblMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void lblMinimize_MouseHover(object sender, EventArgs e)
        {
            System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();
            ToolTip1.SetToolTip(this.lblMinimize, "Minimize Application");
        }

        //! Drag Form
        private void label4_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
    }
}