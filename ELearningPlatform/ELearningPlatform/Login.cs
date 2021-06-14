using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using ELearningPlatform.Data;
using System.Linq;
using ELearningPlatform.Panels.Creator;
using ELearningPlatform.Panels.User;

namespace ELearningPlatform
{
    public partial class Login : UserControl
    {
        public Login()
        {
            InitializeComponent();
        }

        public static int GetRole(string login, string password)
        {
            int role = -1;
            using var db = new ELearningPlatformContext();

            SHA256 sha256Hash = SHA256.Create();
            password = SecurityPassword.GetHash(sha256Hash, password);

            AboutUser.Password = password; //add password after hash passwordd to "session" user

            var Query1 = from user in db.Users
                          where user.Login == login && user.Password == password
                          select user;

            if (Query1 != null)
            {
                if (Query1.Count() > 0)
                {
                    foreach (var item in Query1)
                    {

                        role = item.RoleID;
                        //name,surname and login to user
                        AboutUser.UserID = item.UserID;
                        AboutUser.Name = item.Name;
                        AboutUser.Surname = item.Surname;
                        AboutUser.Login = item.Login;
                        AboutUser.TypeAccound = item.RoleID;
                    }
                }
                
            }
            else
            {
                role = -1;
            }

            return role;
        }

        public static bool CheckUser(string login, string password)
        {
            bool state = false;
            using var db = new ELearningPlatformContext();

            SHA256 sha256Hash = SHA256.Create();
            password = SecurityPassword.GetHash(sha256Hash, password);

            var Query1 = from l in db.Users
                         where l.Login == login && l.Password == password
                         select l;

            if (Query1 != null)
            {
                if (Query1.Count() > 0)
                {
                    //dataGridView1.DataSource = Query1.ToList();
                    state = true;
                }
                else
                {
                    state = false;
                    // dataGridView1.DataSource = null;
                }
            }
            return state;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (LoginBox.Text == "Login" || LoginBox.Equals(" ") || String.IsNullOrWhiteSpace(LoginBox.Text) || String.IsNullOrEmpty(LoginBox.Text))
            {
                MessageBox.Show("Login is incorrect or empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (PasswordBox.Text == "Password" || PasswordBox.Equals(" ") || String.IsNullOrWhiteSpace(PasswordBox.Text) || String.IsNullOrEmpty(PasswordBox.Text))
            {
                MessageBox.Show("Password is incorrect or empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {

                if (CheckUser(LoginBox.Text, PasswordBox.Text))
                {
                    int role = GetRole(LoginBox.Text, PasswordBox.Text);
                    if (role == 1)
                    {
                        //MessageBox.Show("You logIN\nAdmin");
                        
                        this.Controls.Clear();
                    }
                    else if (role == 2)
                    {
                        //MessageBox.Show("You logIN\nStudent-NormalUser");
                        
                        this.Controls.Clear();
                        UserPanel userPanel = new UserPanel();
                        userPanel.Show();
                    }
                    else if (role == 3)
                    {
                        //MessageBox.Show("You logIN\nCreator");
                        
                        this.Controls.Clear();
                        CreatorPanel creatorPanel = new CreatorPanel();
                        creatorPanel.Show();
                        
                    }
                    else if (role == -1)
                    {
                        MessageBox.Show("You login but sometgin wrong with your data role");
                    }
                }
                else
                {
                    MessageBox.Show("Wrong data or \nNo records in data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            PasswordBox.UseSystemPasswordChar = false;
            pictureBox2.BringToFront();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            PasswordBox.UseSystemPasswordChar = true;
            pictureBox2.SendToBack();
        }

        private void LoginBox_Enter(object sender, EventArgs e)
        {
            if (LoginBox.Text.Equals("Login"))
            {
                LoginBox.Text = "";
                LoginBox.BorderStyle = BorderStyle.FixedSingle;
            }
        }

        private void LoginBox_Leave(object sender, EventArgs e)
        {
            if (LoginBox.Text.Equals("") || LoginBox.Text.Equals(" "))
            {
                LoginBox.Text = "Login";
                LoginBox.BorderStyle = BorderStyle.None;
            }
        }

        private void PasswordBox_Enter(object sender, EventArgs e)
        {
            if (PasswordBox.Text.Equals("Password"))
            {
                PasswordBox.Text = "";
                PasswordBox.BorderStyle = BorderStyle.FixedSingle;
            }
        }

        private void PasswordBox_Leave(object sender, EventArgs e)
        {
            if (PasswordBox.Text.Equals("") || PasswordBox.Text.Equals(" "))
            {
                PasswordBox.Text = "Password";
                PasswordBox.BorderStyle = BorderStyle.None;
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            register1.Visible = true;
            register1.BringToFront();
        }
    }
}
