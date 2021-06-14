using ELearningPlatform.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using ELearningPlatform.Model;
using System.Linq;

namespace ELearningPlatform.Panels.Creator
{
    public partial class YourData : UserControl
    {
        public YourData()
        {
            InitializeComponent();
            label4.Text = "Name: " + AboutUser.Name;
            label5.Text = "Surname: " + AboutUser.Surname;
            label6.Text = "Login: " + AboutUser.Login;
            label7.Text = "Type account: " + AboutUser.TypeAccoundd();
        }
        public static bool UpdateUser(string name, string surname, string login, string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                password = SecurityPassword.GetHash(sha256Hash, password);
            }
            bool state = false;
            try
            {
                using var db = new ELearningPlatformContext();
                Model.User user = db.Users.First(s => s.Login.Equals(login) && s.Password.Equals(password));

                //uaktualnienie autora w kusach             
                var course = db.Coursess.Where(x => x.Author == AboutUser.FullName()).ToList();
                course.ForEach(x => x.Author = name + " " + surname);
                db.SaveChanges();

                CreateCourse createCourse = new CreateCourse(); //odświerzenie danych
                createCourse.RefreshDataGrid();

                user.Name = name;
                user.Surname = surname;
                
                db.Users.Update(user);
                db.SaveChanges();

                state = true;

                AboutUser.Name = user.Name;
                AboutUser.Surname = user.Surname;
            }
            catch (Exception e)
            {
                state = false;
            }
            return state;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (NameBox.Text == "Name" || NameBox.Equals(" ") || String.IsNullOrWhiteSpace(NameBox.Text) || String.IsNullOrEmpty(NameBox.Text))
            {
                MessageBox.Show("Name is incorrect or empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else if (SurnameBox.Text == "Name" || SurnameBox.Equals(" ") || String.IsNullOrWhiteSpace(SurnameBox.Text) || String.IsNullOrEmpty(SurnameBox.Text))
            {
                MessageBox.Show("Surname is incorrect or empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (PasswordBox.Text == "Password" || PasswordBox.Equals(" ") || String.IsNullOrWhiteSpace(PasswordBox.Text) || String.IsNullOrEmpty(PasswordBox.Text))
            {
                MessageBox.Show("Password is incorrect or empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (UpdateUser(NameBox.Text, SurnameBox.Text, AboutUser.Login, PasswordBox.Text))
                {
                    MessageBox.Show("Success","Your data was updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //Show Update data
                    label4.Text = "Name: " + AboutUser.Name;
                    label5.Text = "Surname: " + AboutUser.Surname;
                }
                else
                {
                    MessageBox.Show("not Success\nTry again", "Your data - Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
