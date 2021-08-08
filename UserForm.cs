using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace thecruds
{
    public partial class UserForm : Form
    {
        public UserForm(string username)
        {
            InitializeComponent();
            label1.Text = username;
        }

        private void UserForm_Load(object sender, EventArgs e)
        {
            
        }
    }
}
