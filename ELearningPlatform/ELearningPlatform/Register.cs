using ELearningPlatform.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ELearningPlatform.Data;
using System.Linq;
using System.Security.Cryptography;

namespace ELearningPlatform
{
    public partial class Register : UserControl
    {
        public Register()
        {
            InitializeComponent();
        }

        public static bool CheckLogin(string login)
        {
            using var db = new ELearningPlatformContext();

            bool isNewLogin = true;

            var Query1 = from l in db.Users
                         where l.Login == login
                         select l;

            if (Query1 != null)
            {
                if (Query1.Count() > 0)
                {
                    isNewLogin = false;
                }
            }
            return isNewLogin;
        }
        public static bool InsertUser(string name, string surname, string login, string password, int roleUser) 
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                password = SecurityPassword.GetHash(sha256Hash, password);
            }
            bool state = false;
            try
            {
                using var db = new ELearningPlatformContext();
                User user = new User();
                user.Name = name;
                user.Surname = surname;
                user.Login = login;
                user.Password = password;
                user.RoleID = roleUser;
                db.Users.Add(user);
                db.SaveChanges();

                state = true;
            }
            catch (Exception e)
            {
                state = false;
                MessageBox.Show(e.InnerException.Message, "Error", MessageBoxButtons.OK);
            }
            return state;
        }

        private int userRole;
        private void button1_Click(object sender, EventArgs e)
        {
            if (LoginBox.Text == "Login" || LoginBox.Equals(" ") || String.IsNullOrWhiteSpace(LoginBox.Text) || String.IsNullOrEmpty(LoginBox.Text))
            {
                MessageBox.Show("Login is incorrect or empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (PasswordBox.Text == "Password" || PasswordBox.Equals(" ") || String.IsNullOrWhiteSpace(PasswordBox.Text) || String.IsNullOrEmpty(PasswordBox.Text))
            {
                MessageBox.Show("Login is incorrect or empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (!SecurityPassword.CheckPassword(PasswordBox.Text)) 
            {
                MessageBox.Show(SecurityPassword.ErrorMessage, "Valid Password", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (!CheckLogin(LoginBox.Text))
            {
                MessageBox.Show("Login exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (NameBox.Text == "Name" || NameBox.Equals(" ") || String.IsNullOrWhiteSpace(NameBox.Text) || String.IsNullOrEmpty(NameBox.Text))
            {
                MessageBox.Show("Name is incorrect or empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (SurnameBox.Text == "Surname" || SurnameBox.Equals(" ") || String.IsNullOrWhiteSpace(SurnameBox.Text) || String.IsNullOrEmpty(SurnameBox.Text))
            {
                MessageBox.Show("Surname is incorrect or empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (!radioButtonStudent.Checked && !radioButtonCreator.Checked)
            {
                MessageBox.Show("You must chacked one of radiobutton", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (radioButtonStudent.Checked) { userRole = 2; }
                if (radioButtonCreator.Checked) { userRole = 3; }

                if (InsertUser(NameBox.Text, SurnameBox.Text, LoginBox.Text, PasswordBox.Text, userRole))
                {
                    //
                    panel1.Visible = false;
                    this.Controls.Clear();

                    Login n = new Login();
                    this.Controls.Add(n);
                }
                else
                {
                    MessageBox.Show("Someting wrong with saving data to database", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void NameBox_Enter(object sender, EventArgs e)
        {
            if (NameBox.Text.Equals("Name"))
            {
                NameBox.Text = "";
                NameBox.BorderStyle = BorderStyle.FixedSingle;
            }
        }

        private void NameBox_Leave(object sender, EventArgs e)
        {
            if (NameBox.Text.Equals("") || NameBox.Text.Equals(" "))
            {
                NameBox.Text = "Name";
                NameBox.BorderStyle = BorderStyle.None;
            }
        }

        private void SurnameBox_Enter(object sender, EventArgs e)
        {
            if (SurnameBox.Text.Equals("Surname"))
            {
                SurnameBox.Text = "";
                SurnameBox.BorderStyle = BorderStyle.FixedSingle;
            }
        }

        private void SurnameBox_Leave(object sender, EventArgs e)
        {
            if (SurnameBox.Text.Equals("") || SurnameBox.Text.Equals(" "))
            {
                SurnameBox.Text = "Surname";
                SurnameBox.BorderStyle = BorderStyle.None;
            }
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
    }
}
