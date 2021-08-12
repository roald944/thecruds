
namespace thecruds
{
    partial class UserForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblLoggedUser = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.mystats = new System.Windows.Forms.Label();
            this.logged_user = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.txtsearch = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.set_mystatus = new System.Windows.Forms.Button();
            this.txtChoose_status = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // lblLoggedUser
            // 
            this.lblLoggedUser.AutoSize = true;
            this.lblLoggedUser.Location = new System.Drawing.Point(-6, 29);
            this.lblLoggedUser.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLoggedUser.Name = "lblLoggedUser";
            this.lblLoggedUser.Size = new System.Drawing.Size(132, 19);
            this.lblLoggedUser.TabIndex = 0;
            this.lblLoggedUser.Text = "Logged User : None";
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(531, 401);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(120, 33);
            this.button1.TabIndex = 1;
            this.button1.Text = "Exit | Logout";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Orange;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(666, 71);
            this.label1.TabIndex = 2;
            this.label1.Text = "Welcome! You are now Logged In";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.label1_MouseMove);
            // 
            // button2
            // 
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.button2.Location = new System.Drawing.Point(12, 401);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(120, 33);
            this.button2.TabIndex = 3;
            this.button2.Text = "Signout";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // mystats
            // 
            this.mystats.AutoSize = true;
            this.mystats.Location = new System.Drawing.Point(8, 107);
            this.mystats.Name = "mystats";
            this.mystats.Size = new System.Drawing.Size(125, 19);
            this.mystats.TabIndex = 4;
            this.mystats.Text = "User Status : None";
            // 
            // logged_user
            // 
            this.logged_user.AutoSize = true;
            this.logged_user.Location = new System.Drawing.Point(1, 88);
            this.logged_user.Name = "logged_user";
            this.logged_user.Size = new System.Drawing.Size(132, 19);
            this.logged_user.TabIndex = 5;
            this.logged_user.Text = "Logged User : None";
            // 
            // listView1
            // 
            this.listView1.BackColor = System.Drawing.Color.White;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.listView1.ForeColor = System.Drawing.Color.Black;
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(12, 171);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(639, 224);
            this.listView1.TabIndex = 6;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "USER ID";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Name";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Email";
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Contact #";
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Status";
            // 
            // txtsearch
            // 
            this.txtsearch.Location = new System.Drawing.Point(453, 140);
            this.txtsearch.Name = "txtsearch";
            this.txtsearch.Size = new System.Drawing.Size(198, 25);
            this.txtsearch.TabIndex = 7;
            this.txtsearch.TextChanged += new System.EventHandler(this.txtsearch_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(389, 146);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 19);
            this.label2.TabIndex = 8;
            this.label2.Text = "Search :";
            // 
            // set_mystatus
            // 
            this.set_mystatus.Location = new System.Drawing.Point(139, 140);
            this.set_mystatus.Name = "set_mystatus";
            this.set_mystatus.Size = new System.Drawing.Size(91, 25);
            this.set_mystatus.TabIndex = 9;
            this.set_mystatus.Text = "Set Status";
            this.set_mystatus.UseVisualStyleBackColor = true;
            this.set_mystatus.Click += new System.EventHandler(this.set_mystatus_Click);
            // 
            // txtChoose_status
            // 
            this.txtChoose_status.FormattingEnabled = true;
            this.txtChoose_status.Items.AddRange(new object[] {
            "Online",
            "Offline",
            "Away",
            "Busy"});
            this.txtChoose_status.Location = new System.Drawing.Point(12, 140);
            this.txtChoose_status.Name = "txtChoose_status";
            this.txtChoose_status.Size = new System.Drawing.Size(121, 25);
            this.txtChoose_status.TabIndex = 10;
            this.txtChoose_status.Text = "Select Status";
            // 
            // UserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(663, 446);
            this.Controls.Add(this.txtChoose_status);
            this.Controls.Add(this.set_mystatus);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtsearch);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.logged_user);
            this.Controls.Add(this.mystats);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblLoggedUser);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UserForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UserForm";
            this.Load += new System.EventHandler(this.UserForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblLoggedUser;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label mystats;
        private System.Windows.Forms.Label logged_user;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.TextBox txtsearch;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button set_mystatus;
        private System.Windows.Forms.ComboBox txtChoose_status;
    }
}