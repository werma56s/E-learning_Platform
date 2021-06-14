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

namespace ELearningPlatform.Panels.Creator
{
    public partial class CreateCourse : UserControl
    {
        public void ListOfChoiceCategory()
        {
            using (var db = new ELearningPlatformContext())
            {
                List<Category> category = db.Categories.ToList();
                comboBox1.DataSource = category;
                comboBox1.ValueMember = "CategoryName";
                comboBox1.DisplayMember = "Category of Course";
            }
        }
        public CreateCourse()
        {
            InitializeComponent();

            label5.Text = "Author of Course: " + AboutUser.FullName();
        }

        public static bool CreateCours(string title, string description, int category, string autor)
        {
            bool state = false;
            try
            {
                using (var db = new ELearningPlatformContext())
                {
                    Courses cours = new Courses();
                    cours.Title = title;
                    cours.Description = description;
                    cours.CategoryID = category;
                    cours.Author = autor;
                    db.Coursess.Add(cours);
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
        public static bool UpdateCours(int courseID, string title, string description, int category)
        {
            bool state = false;
            try
            {
                var db = new ELearningPlatformContext();
                Model.Courses cours = db.Coursess.First(s => s.CoursesID.Equals(courseID));
                cours.Title = title;
                cours.Description = description;
                cours.CategoryID = category;
                db.Coursess.Update(cours);
                db.SaveChanges();

                state = true;
            }
            catch (Exception e)
            {
                state = false;
            }
            return state;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (TitleBox.Text == "Title" || TitleBox.Equals(" ") || String.IsNullOrWhiteSpace(TitleBox.Text) || String.IsNullOrEmpty(TitleBox.Text))
            {
                MessageBox.Show("Title is incorrect or empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (DescriptionBox.Text == "Description" || DescriptionBox.Equals(" ") || String.IsNullOrWhiteSpace(DescriptionBox.Text) || String.IsNullOrEmpty(DescriptionBox.Text))
            {
                MessageBox.Show("Description is incorrect or empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (CreateCours(TitleBox.Text, DescriptionBox.Text, comboBox1.SelectedIndex + 1, AboutUser.FullName())) //zrboić unit test
                {

                    MessageBox.Show("Success!", "CreateCours", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ShowDataCourse();
                    TitleBox.Text = "Title";
                    DescriptionBox.Text = "Description";

                }
            }
        }
        public void ShowDataCourse()
        {
            using (var db = new ELearningPlatformContext())
            {
                var Query = from cours in db.Coursess
                            join cat in db.Categories
                               on cours.CategoryID equals cat.CategoryID into g
                            from d in g.DefaultIfEmpty()
                            select d;

                var Query1 = from l in db.Coursess
                             where l.Author == AboutUser.FullName()
                             select new
                             {
                                 l.CoursesID,
                                 l.Title,
                                 l.Description,
                                 l.Author,
                                 l.Views,
                                 list2 = Query.Where(x => x.CategoryID == l.CategoryID).Select(x => x.CategoryName).First().ToString()
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
        public void RefreshDataGrid()
        {
            dataGridView1.Refresh();
        }
        private void TitleBox_Enter(object sender, EventArgs e)
        {
            if (TitleBox.Text.Equals("Title"))
            {
                TitleBox.Text = "";
                TitleBox.BorderStyle = BorderStyle.FixedSingle;
            }
        }

        private void TitleBox_Leave(object sender, EventArgs e)
        {
            if (TitleBox.Text.Equals("") || TitleBox.Text.Equals(" "))
            {
                TitleBox.Text = "Title";
                TitleBox.BorderStyle = BorderStyle.None;
            }
        }

        private void DescriptionBox_Enter(object sender, EventArgs e)
        {
            if (DescriptionBox.Text.Equals("Description"))
            {
                DescriptionBox.Text = "";
                DescriptionBox.BorderStyle = BorderStyle.FixedSingle;
            }
        }

        private void DescriptionBox_Leave(object sender, EventArgs e)
        {
            if (DescriptionBox.Text.Equals("") || DescriptionBox.Text.Equals(" "))
            {
                DescriptionBox.Text = "Description";
                DescriptionBox.BorderStyle = BorderStyle.None;
            }
        }

        private void CreateCourse_Load(object sender, EventArgs e)
        {
            ListOfChoiceCategory();
            ShowDataCourse();
        }

        public int couseID = 0;
        Courses cours = new Courses();
        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow.Index != -1)
            {
                couseID = Convert.ToInt32(dataGridView1.CurrentRow.Cells["CoursesID"].Value);
                using (var db = new ELearningPlatformContext())
                {
                    cours = db.Coursess.Where(x => x.CoursesID == couseID).First();
                    TitleBox.Text = cours.Title;
                    DescriptionBox.Text = cours.Description;
                    comboBox1.SelectedValue = db.Coursess.Where(x => x.CoursesID == couseID).Select(x => x.Category.CategoryName).First();//Seleteditem=cours.CategoryID - 1;
                }

                button1.Enabled = false;
                UpdataButton.Enabled = true;
                DeleteButton.Enabled = true;
            }
        }

        private void UpdataButton_Click(object sender, EventArgs e)
        {
            if (TitleBox.Text == "Title" || TitleBox.Equals(" ") || String.IsNullOrWhiteSpace(TitleBox.Text) || String.IsNullOrEmpty(TitleBox.Text))
            {
                MessageBox.Show("Title is incorrect or empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (DescriptionBox.Text == "Description" || DescriptionBox.Equals(" ") || String.IsNullOrWhiteSpace(DescriptionBox.Text) || String.IsNullOrEmpty(DescriptionBox.Text))
            {
                MessageBox.Show("Description is incorrect or empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (UpdateCours(couseID, TitleBox.Text, DescriptionBox.Text, comboBox1.SelectedIndex + 1)) //zrboić unit test
                {

                    MessageBox.Show("Success!", "CreateCours", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ShowDataCourse();
                }
            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure to delate this course?", "Inform", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                using var db = new ELearningPlatformContext();
                var entry = db.Entry(cours);
                if (entry.State == Microsoft.EntityFrameworkCore.EntityState.Detached)
                    db.Coursess.Attach(cours);
                try
                {
                    //delete quiz and questions
                    var qquiz = db.Quizzes.Where(x => x.CoursesID == cours.CoursesID).ToList().FirstOrDefault();
                    var quiz = db.Quizzes.Where(x => x.CoursesID == cours.CoursesID).ToList();
                    if (qquiz != null)
                    {
                        var qusetions = db.Questionss.Where(x => x.QuestionsID == qquiz.QuestionsID).ToList();
                        if(qusetions.Count() > 0)
                        {
                            db.Quizzes.RemoveRange(quiz); //DELETE commands for all entities
                            db.SaveChanges();
                        }
                        
                        db.Questionss.RemoveRange(qusetions); 
                        db.SaveChanges();
                        MessageBox.Show("You delete course witch all quizzes and questions", "Inform", MessageBoxButtons.OK);
                    }
                }
                catch (Exception ex)
                {
                    string error = "Course don't have any Quizzes\nError: " + ex;
                    MessageBox.Show(error, "Inform", MessageBoxButtons.OK);
                }

                db.Coursess.Remove(cours);//DELETE commands for one entiti
                db.SaveChanges();

                ShowDataCourse();
                MessageBox.Show("Deleted succesfull");
            }
        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            if (button1.Enabled == false)
            {
                button1.Enabled = true;
                UpdataButton.Enabled = false;
                DeleteButton.Enabled = false;
                couseID = 0;
                TitleBox.Text = "Title";
                DescriptionBox.Text = "Description";
                comboBox1.SelectedIndex = 0;
            }
        }

    }
}
