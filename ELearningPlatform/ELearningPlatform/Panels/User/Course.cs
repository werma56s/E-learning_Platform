using ELearningPlatform.Data;
using ELearningPlatform.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ELearningPlatform.Panels.User
{
    public partial class Course : UserControl
    {
        public void ListOfChoiceCourses()
        {
            using (var db = new ELearningPlatformContext())
            {
                List<Courses> courses = db.Coursess.ToList();
                comboBox1.DataSource = courses;
                comboBox1.ValueMember = "Title";
                comboBox1.DisplayMember = "Title of Course";
            }
        }
        public Course()
        {
            InitializeComponent();
        }

        public void ShowDataCourses() 
        {
            using (var db = new ELearningPlatformContext())
            {
                var Query = from userControl in db.UserCoursess
                             join cours in db.Coursess
                                on userControl.CoursesID equals cours.CoursesID into g
                             from d in g.DefaultIfEmpty()
                             select d;



                var Query1 = from l in db.UserCoursess
                            where l.UserID == AboutUser.UserID
                            select new
                            {
                                l.UserCoursesID,
                                l.CoursesID,
                                Title = Query.Where(x => x.CoursesID == l.CoursesID).Select(x => x.Title).First().ToString(), //Query1.First(x => x.CoursesID == l.CoursesID).Title,
                                Description = Query.Where(x => x.CoursesID == l.CoursesID).Select(x => x.Description).First().ToString(),
                                Author = Query.Where(x => x.CoursesID == l.CoursesID).Select(x => x.Author).First().ToString(),
                                l.RescultOfCours
                             };


                if (Query1 != null)
                {
                    if (Query1.Count() > 0)
                    {
                        dataGridView1.DataSource = Query1.ToList();
                    }
                    else
                    {
                        dataGridView1.DataSource = null;
                    }
                }

            }
        }

        private void Course_Load(object sender, EventArgs e)
        {
            ListOfChoiceCourses();
            ShowDataCourses();
        }
        private static int courseID;
        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            using (var db = new ELearningPlatformContext())
            {
                List<Courses> courses = db.Coursess.ToList();
                DescriptionBox.Text = courses.First(x => x.Title == comboBox1.SelectedValue.ToString()).Description;
                label5.Text = "Author of Course: " + courses.First(x => x.Title == comboBox1.SelectedValue.ToString()).Author;
                courseID = courses.First(x => x.Title == comboBox1.SelectedValue.ToString()).CoursesID;
            }
        }
        public static bool CreateCours(int courseId)
        {
            bool state = false;
            try
            {
                using (var db = new ELearningPlatformContext())
                {
                    UserCourses userCourses = new UserCourses();
                    userCourses.UserID = AboutUser.UserID;
                    userCourses.CoursesID = courseId;
                    userCourses.RescultOfCours = 0;
                    userCourses.State = true;
                    db.UserCoursess.Add(userCourses);
                    db.SaveChanges();

                    //view for course
                    var course = db.Coursess.Where(x => x.CoursesID == courseId).First();
                    course.Views++;
                    db.Coursess.Update(course);
                    db.SaveChanges();

                    state = true;
                }
            }
            catch (Exception e)
            {
                state = false;
            }
            return state;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (CreateCours(courseID))
            {
                MessageBox.Show("Success!", "CreateCours", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ShowDataCourses();
            }
            else
            {
                MessageBox.Show("Something wrong with create", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        internal void Refresh()
        {
            if (button1.Enabled == false)
            {
                button1.Enabled = true;
                DeleteButton.Enabled = false;
                button2.Enabled = false;
                button2.Visible = false;
                comboBox1.SelectedIndex = 0;
                ShowDataCourses();
            }
            ShowDataCourses();
        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            Refresh();
        }

        public int userCoursesID = 0, courseIID = 0;
        UserCourses userCourses1 = new UserCourses();
        Model.Courses course1 = new Courses();
        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow.Index != -1)
            {
                userCoursesID = Convert.ToInt32(dataGridView1.CurrentRow.Cells["UserCoursesID"].Value);
                courseIID = Convert.ToInt32(dataGridView1.CurrentRow.Cells["CoursesID"].Value);
                using (var db = new ELearningPlatformContext())
                {
                    userCourses1 = db.UserCoursess.Where(x => x.UserCoursesID == userCoursesID).First();
                    course1 = db.Coursess.Where(x => x.CoursesID == courseIID).First();

                    userCurseData.UserCoursesID = userCourses1.UserCoursesID;
                    userCurseData.CoursesID = userCourses1.CoursesID;
                    userCurseData.RescultOfCours = userCourses1.RescultOfCours;
                    userCurseData.State = userCourses1.State;
                    
                    DescriptionBox.Text = course1.Description;
                    comboBox1.SelectedValue = course1.Title;
                }
                button1.Enabled = false;
                DeleteButton.Enabled = true;
                button2.Enabled = true;
                button2.Visible = true;
            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure to delate this course?", "Inform", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                using var db = new ELearningPlatformContext();
                var entry = db.Entry(userCourses1);
                if (entry.State == Microsoft.EntityFrameworkCore.EntityState.Detached)
                    db.UserCoursess.Attach(userCourses1);
                db.UserCoursess.Remove(userCourses1);
                db.SaveChanges();
                userCurseData.Clear();
                ShowDataCourses();
                MessageBox.Show("Deleted succesfull");
            }
            Refresh();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Quizz quizz = new Quizz();
            quizz.Height = 581;
            quizz.Width = 915;
            quizz.Location = new Point(218, 3);
            this.Controls.Add(quizz);
            quizz.BringToFront();
            quizz.Show();
            //quizz1.Visible = true;
            //quizz1.BringToFront();
        }
    }
}
