using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ELearningPlatform.Panels.User
{
    public partial class UserPanel : Form
    {
        public UserPanel()
        {
            InitializeComponent();
            label5.Text = "Welcome "+AboutUser.FullName()+" to ouer e-learning pratform!";
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            if (history1.Visible == true)
            {
                history1.Visible = false;
                label5.Visible = false;
                label6.Visible = false;
                yourData1.Visible = true;
                yourData1.BringToFront();
            }
            else if (course1.Visible == true)
            {
                course1.Visible = false;
                label5.Visible = false;
                label6.Visible = false;
                yourData1.Visible = true;
                yourData1.BringToFront();
            }
            else
            {
                label5.Visible = false;
                label6.Visible = false;

                yourData1.Visible = true;
                yourData1.BringToFront();
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            if(yourData1.Visible == true)
            {
                yourData1.Visible = false;
                label5.Visible = false;
                label6.Visible = false;
                history1.Visible = true;
                history1.BringToFront();
            }
            else if (course1.Visible == true)
            {
                course1.Visible = false;
                history1.Visible = true;
                history1.BringToFront();
            }
            else
            {
                history1.Visible = true;
                history1.BringToFront();
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            if (yourData1.Visible == true)
            {
                yourData1.Visible = false;
                label5.Visible = false;
                label6.Visible = false;
                course1.Visible = true;
                course1.BringToFront();
            }
            else if (history1.Visible == true)
            {
                history1.Visible = false;
                course1.Visible = true;
                course1.BringToFront();
            }
            else
            {
                course1.Visible = true;
                course1.BringToFront();
            }
        }
    }
}
