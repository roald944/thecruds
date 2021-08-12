using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Runtime.InteropServices;
namespace thecruds
{
    public partial class UserForm : Form
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
        public UserForm(string username)
        {
            InitializeComponent();
            lblLoggedUser.Text = username;

        }
        public void color_rows()
        {
            listView1.ForeColor = Color.White;
            foreach (ListViewItem item in listView1.Items)
            {
                if (item.SubItems[4].Text == "Online")
                {
                    item.BackColor = Color.Lime;
                }
                else if (item.SubItems[4].Text == "Offline")
                {
                    item.BackColor = Color.Red;
                }
            }
        }
        //! Display Current User's Status
        public void read_user_status()
        {
            DBConnect db = new DBConnect();
            string username = lblLoggedUser.Text;
            string read_status = "SELECT my_status FROM login_users WHERE my_username = @username";
            db.OpenConnection();
            MySqlCommand cmd_status = new MySqlCommand(read_status, db.connection);
            cmd_status.Parameters.Add("@username", MySqlDbType.VarChar).Value = username;
            MySqlDataReader reader = cmd_status.ExecuteReader(); ;
            while (reader.Read())
            {
                mystats.Text = "User Status : " + (string)reader["my_status"];
            }
            reader.Close();
            cmd_status.Dispose();
            db.CloseConnection();
        }

        //! Load data into listiew from database
        public void load_data()
        {
            DBConnect db = new DBConnect();
            string read_users = "SELECT * FROM user_view";
            db.OpenConnection();
            MySqlCommand cmd_users = new MySqlCommand(read_users, db.connection);
            MySqlDataReader reader = cmd_users.ExecuteReader();
            listView1.Items.Clear();
            while (reader.Read())
            {
                ListViewItem lv = new ListViewItem(reader["MYID"].ToString());
                lv.SubItems.Add(reader["FullName"].ToString());
                lv.SubItems.Add(reader["EMAIL"].ToString());
                lv.SubItems.Add(reader["CONTACT"].ToString());
                lv.SubItems.Add(reader["STATUS"].ToString());
                listView1.Items.Add(lv);
                listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
                color_rows();
            }
            //reader.Close();
            //cmd_users.Dispose();
            db.CloseConnection();
        }
       
        private void button2_Click(object sender, EventArgs e)
        {
            DBConnect db = new DBConnect();
            string username_logout = lblLoggedUser.Text;
            string offline_txt = "Offline";
            string logout_q = "UPDATE login_users SET my_status = @offline WHERE my_username = @username";
            db.OpenConnection();
            MySqlCommand cmd_logout = new MySqlCommand(logout_q, db.connection);
            cmd_logout.Parameters.Add("@offline", MySqlDbType.VarChar).Value = offline_txt;
            cmd_logout.Parameters.Add("@username", MySqlDbType.VarChar).Value = username_logout;
            cmd_logout.ExecuteNonQuery();
            db.CloseConnection();
            cmd_logout.Dispose();
            Login toLogin = new Login();
            toLogin.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DBConnect db = new DBConnect();
            string username_logout = lblLoggedUser.Text;
            string offline_txt = "Offline";
            string logout_q = "UPDATE login_users SET my_status = @offline WHERE my_username = @username";
            db.OpenConnection();
            MySqlCommand cmd_logout = new MySqlCommand(logout_q, db.connection);
            cmd_logout.Parameters.Add("@offline", MySqlDbType.VarChar).Value = offline_txt;
            cmd_logout.Parameters.Add("@username", MySqlDbType.VarChar).Value = username_logout;
            cmd_logout.ExecuteNonQuery();
            db.CloseConnection();
            cmd_logout.Dispose();
            button2.PerformClick();
            Application.Exit();
        }
        private void label1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        //! Load By Search
        //TODO FIX CONCATENATE WHEN SEARCHING
        #region    
        /*
        public void load_search()
        {
            DBConnect db = new DBConnect();
            string sbox = txtsearch.Text;
            string read_users = "SELECT * FROM user_view WHERE MYID LIKE @sbox OR FullName LIKE @sbox";
            db.OpenConnection();
            MySqlCommand cmd_users = new MySqlCommand(read_users, db.connection);
            cmd_users.Parameters.Add("@sbox", MySqlDbType.VarChar).Value = sbox;
            MySqlDataReader reader = cmd_users.ExecuteReader();
            listView1.Items.Clear();
            while (reader.Read())
            {
                ListViewItem lv = new ListViewItem(reader["MYID"].ToString());
                lv.SubItems.Add(reader["FullName"].ToString());
                lv.SubItems.Add(reader["EMAIL"].ToString());
                lv.SubItems.Add(reader["CONTACT"].ToString());
                lv.SubItems.Add(reader["STATUS"].ToString());
                listView1.Items.Add(lv);
                color_rows();
            }
            //reader.Close();
            //cmd_users.Dispose();
            db.CloseConnection();
        }
        */
        #endregion
        private void UserForm_Load(object sender, EventArgs e)
        {
            load_data();
            logged_user.Text = "Logged User : " + lblLoggedUser.Text;
            read_user_status();
            load_data();
            color_rows();
            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }
        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            /*
            if (txtsearch.Text.Length <= 1 || txtsearch.Text == "")
            {
                load_data();
                color_rows();
            }
            else
            {
                load_search();
            }
            */
        }
        public void update_status()
        {
            DBConnect db = new DBConnect();
            string username = lblLoggedUser.Text;
            string txtstatus = txtChoose_status.Text;
            string update_status = "UPDATE login_users SET my_status = @c_status WHERE my_username = @username";
            db.OpenConnection();
            MySqlCommand cmd_update_status = new MySqlCommand(update_status,db.connection);
            cmd_update_status.Parameters.Add("@c_status", MySqlDbType.VarChar).Value = txtstatus;
            cmd_update_status.Parameters.Add("@username",MySqlDbType.VarChar).Value = username;
            if (cmd_update_status.ExecuteNonQuery() == 1)
            {
                string msg = "User Status Updated [ "+txtstatus+" ]";
                string msgtitle = "Status Update [ "+ txtstatus +" ]";
                MessageBox.Show(msg,msgtitle,MessageBoxButtons.OK,MessageBoxIcon.Information);
                load_data();
            }
            db.CloseConnection();
        }
        private void set_mystatus_Click(object sender, EventArgs e)
        {
            update_status();
        }
    }
}
