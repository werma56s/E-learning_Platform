using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace ELearningPlatform.Panels.Creator
{
    public partial class CreatorPanel : Form
    {
        public CreatorPanel()
        {
            InitializeComponent();
            label1.Text = "Welcome " + AboutUser.FullName() + " to ouer e-learning pratform!";
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            //Sprawdza czy kontrolka uzytownika (yourData1 lub quiz1) są "włączone" aby je wyłączyć i przenieść do przodu kotrolke z tworzenieum kursów (+ widoczność na true)
            if (yourData1.Visible == true)
            {
                yourData1.Visible = false;
                label1.Visible = false;
                label6.Visible = false;
                button1.Visible = false;
                createCourse2.Visible = true;
                createCourse2.BringToFront();
            }
            else if(quiz1.Visible == true)
            {
                quiz1.Visible = false;

                label1.Visible = false;
                label6.Visible = false;
                button1.Visible = false;
                createCourse2.Visible = true;
                createCourse2.BringToFront();
            }
            else 
            {
                label1.Visible = false;
                label6.Visible = false;
                button1.Visible = false;
                createCourse2.Visible = true;
                createCourse2.BringToFront();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label1.Visible = false;
            label6.Visible = false;
            button1.Visible = false;
            createCourse2.Visible = true;
            createCourse2.BringToFront();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            if (createCourse2.Visible == true)
            {
                createCourse2.Visible = false;
                
                label1.Visible = false;
                label6.Visible = false;
                button1.Visible = false;

                yourData1.Visible = true;
                yourData1.BringToFront();
            }
            else if (quiz1.Visible == true)
            {
                quiz1.Visible = false;
                label1.Visible = false;
                label6.Visible = false;
                button1.Visible = false;

                yourData1.Visible = true;
                yourData1.BringToFront();
            }
            else
            {
                label1.Visible = false;
                label6.Visible = false;
                button1.Visible = false;

                yourData1.Visible = true;
                yourData1.BringToFront();
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            //strona startowa
        }

        private void label3_Click(object sender, EventArgs e)
        {
            if (createCourse2.Visible == true)
            {
                createCourse2.Visible = false;

                label1.Visible = false;
                label6.Visible = false;
                button1.Visible = false;

                quiz1.Visible = true;
                quiz1.BringToFront();
            }
            else if (yourData1.Visible == true)
            {
                yourData1.Visible = false;

                label1.Visible = false;
                label6.Visible = false;
                button1.Visible = false;

                quiz1.Visible = true;
                quiz1.BringToFront();
            }
            else
            {
                label1.Visible = false;
                label6.Visible = false;
                button1.Visible = false;

                quiz1.Visible = true;
                quiz1.BringToFront();
            }
        }
    }
}
