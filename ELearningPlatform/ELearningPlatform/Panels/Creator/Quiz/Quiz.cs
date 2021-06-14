using ELearningPlatform.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ELearningPlatform.Model;
using System.Linq;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace ELearningPlatform.Panels.Creator.Quiz
{
    public partial class Quiz : UserControl
    {
        
        public void ListOfChoiceQurse()
        {
            using (var db = new ELearningPlatformContext())
            {
                List<Courses> courses = db.Coursess.Where(x => x.Author == AboutUser.FullName()).ToList();
                comboCourseBox.DataSource = courses;
                comboCourseBox.ValueMember = "Title";
                comboCourseBox.DisplayMember = "Category of Course";
            }
        }
        public Quiz()
        {
            InitializeComponent();
            correctAnsBox.Text = answerABox.Text;
        }

        
        public void ShowDataListOfQuizzes()
        {
            using (var db = new ELearningPlatformContext())
            {
                var Query1 = from ques in db.Questionss
                             join q in db.Quizzes on ques.QuestionsID equals q.QuestionsID 
                             join course in db.Coursess on q.CoursesID equals course.CoursesID
                             where  ques.QuestionsID == q.QuestionsID && course.Title == comboCourseBox.SelectedValue.ToString() && course.Author == AboutUser.FullName()
                             select new
                             {
                                 q.QuizID,
                                 q.QuestionsID,
                                 q.CoursesID,
                                 CourseList = course.Title,
                                 Question = ques.QTitle,
                                 AnswerA = ques.Qa,
                                 AnswerB = ques.Qb,
                                 AnswerC = ques.Qc,
                                 AnswerD = ques.Qd,
                                 Qcorrect = ques.Qcorect,
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
        //check coise id where title is equal to selected falue in combobox
        public int CourseID()
        {
            using var db = new ELearningPlatformContext();
            string titleOfCours = comboCourseBox.SelectedValue.ToString();
            var courses = db.Coursess.Where(x => x.Title == titleOfCours).Select(x => x.CoursesID).First();
            return courses;
        }
        
        public bool CreateQuiz(int courseID, string question, string a, string b, string c, string d)
        {
            bool result = false;
            try
            {
                using (var db = new ELearningPlatformContext())
                {
                    //create and save question
                    Questions quest = new Questions();
                    quest.QTitle = question;
                    quest.Qa = a;
                    quest.Qb = b;
                    quest.Qc = c;
                    quest.Qd = d;
                    quest.Qcorect = a;
                    db.Questionss.Add(quest);
                    db.SaveChanges();
                    //create quiz with choosen course
                    Model.Quiz quiz = new Model.Quiz();
                    quiz.CoursesID = courseID;
                    quiz.QuestionsID = quest.QuestionsID;

                    db.Quizzes.Add(quiz);
                    db.SaveChanges();

                    result = true;
                }
            }
            catch (Exception e)
            {
                result = false;
            }
            return result;
        }
        
        public bool UpdataQuiz(int questionID, string question, string a, string b, string c, string d)
        {
            bool result = false;
            try
            {
                var db = new ELearningPlatformContext();
                //create and save question
                Model.Questions quest = db.Questionss.First(s => s.QuestionsID.Equals(questionID));
                quest.QTitle = question;
                quest.Qa = a;
                quest.Qb = b;
                quest.Qc = c;
                quest.Qd = d;
                quest.Qcorect = a;
                db.Questionss.Update(quest);
                db.SaveChanges();

                result = true;
            }
            catch (Exception e)
            {
                result = false;
            }
            return result;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (TitleBox.Text == "Title" || TitleBox.Equals(" ") || String.IsNullOrWhiteSpace(TitleBox.Text) || String.IsNullOrEmpty(TitleBox.Text))
            {
                MessageBox.Show("Title is incorrect or empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (answerABox.Text == "Answer A" || answerABox.Equals(" ") || String.IsNullOrWhiteSpace(answerABox.Text) || String.IsNullOrEmpty(answerABox.Text))
            {
                MessageBox.Show("Answer A is incorrect or empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (answerBBox.Text == "Answer B" || answerBBox.Equals(" ") || String.IsNullOrWhiteSpace(answerBBox.Text) || String.IsNullOrEmpty(answerBBox.Text))
            {
                MessageBox.Show("Answer B is incorrect or empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (answerCBox.Text == "Answer C" || answerCBox.Equals(" ") || String.IsNullOrWhiteSpace(answerCBox.Text) || String.IsNullOrEmpty(answerCBox.Text))
            {
                MessageBox.Show("Answer C is incorrect or empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (answerDBox.Text == "Answer D" || answerDBox.Equals(" ") || String.IsNullOrWhiteSpace(answerDBox.Text) || String.IsNullOrEmpty(answerDBox.Text))
            {
                MessageBox.Show("Answer D is incorrect or empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (CreateQuiz(CourseID(), TitleBox.Text, answerABox.Text, answerBBox.Text, answerCBox.Text, answerDBox.Text)) //zrboić unit test
                {

                    MessageBox.Show("Success!", "CreateCours", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ShowDataListOfQuizzes();
                    TitleBox.Text = "Title";
                    answerABox.Text = "Answer A";
                    answerBBox.Text = "Answer B";
                    answerCBox.Text = "Answer C";
                    answerDBox.Text = "Answer D";

                }
            }
        }


        public int quizID = 0, questionsID = 0;
        Model.Quiz quiz1 = new Model.Quiz();
        Model.Questions questions = new Questions();
        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (dataGridView1.CurrentRow.Index != -1)
            {
                quizID = Convert.ToInt32(dataGridView1.CurrentRow.Cells["QuizID"].Value);
                questionsID = Convert.ToInt32(dataGridView1.CurrentRow.Cells["QuestionsID"].Value);
                using (var db = new ELearningPlatformContext())
                {
                    quiz1 = db.Quizzes.Where(x => x.QuizID == quizID).First();
                    questions = db.Questionss.Where(x => x.QuestionsID == questionsID).First();
                    TitleBox.Text = questions.QTitle;
                    answerABox.Text = questions.Qa;
                    answerBBox.Text = questions.Qb;
                    answerCBox.Text = questions.Qc;
                    answerDBox.Text = questions.Qd;
                    correctAnsBox.Text = questions.Qcorect;
                    
                    comboCourseBox.SelectedValue = db.Coursess.Where(x => x.CoursesID == CourseID()).Select(x => x.Title).First();
                   
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
            else if (answerABox.Text == "Answer A" || answerABox.Equals(" ") || String.IsNullOrWhiteSpace(answerABox.Text) || String.IsNullOrEmpty(answerABox.Text))
            {
                MessageBox.Show("Answer A is incorrect or empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (answerBBox.Text == "Answer B" || answerBBox.Equals(" ") || String.IsNullOrWhiteSpace(answerBBox.Text) || String.IsNullOrEmpty(answerBBox.Text))
            {
                MessageBox.Show("Answer B is incorrect or empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (answerCBox.Text == "Answer C" || answerCBox.Equals(" ") || String.IsNullOrWhiteSpace(answerCBox.Text) || String.IsNullOrEmpty(answerCBox.Text))
            {
                MessageBox.Show("Answer C is incorrect or empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (answerDBox.Text == "Answer D" || answerDBox.Equals(" ") || String.IsNullOrWhiteSpace(answerDBox.Text) || String.IsNullOrEmpty(answerDBox.Text))
            {
                MessageBox.Show("Answer D is incorrect or empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (UpdataQuiz(questionsID, TitleBox.Text, answerABox.Text, answerBBox.Text, answerCBox.Text, answerDBox.Text)) //zrboić unit test
                {

                    MessageBox.Show("Success!", "CreateCours", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ShowDataListOfQuizzes();
                    ClearData();
                }
            }
        }

        private void Quiz_Load(object sender, EventArgs e)
        {
            ListOfChoiceQurse();
            ShowDataListOfQuizzes();
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure to delate this Question?", "Inform", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                using var db = new ELearningPlatformContext();
                var entry = db.Entry(quiz1);
                var entry2 = db.Entry(questions);
                if (entry.State == Microsoft.EntityFrameworkCore.EntityState.Detached && entry2.State == Microsoft.EntityFrameworkCore.EntityState.Detached)
                    db.Quizzes.Attach(quiz1); db.Questionss.Attach(questions);
                db.Quizzes.Remove(quiz1);
                db.Questionss.Remove(questions);
                db.SaveChanges();
                ShowDataListOfQuizzes();
                ClearData();
                MessageBox.Show("Deleted succesfull");
            }
        }
       
        public void ClearData()
        {
            TitleBox.Text = "Title";
            answerABox.Text = "Answer A";
            answerBBox.Text = "Answer B";
            answerCBox.Text = "Answer C";
            answerDBox.Text = "Answer D";
            correctAnsBox.Text = answerABox.Text;
        }

        
        private void RefreshButton_Click(object sender, EventArgs e)
        {
            if (button1.Enabled == false)
            {
                button1.Enabled = true;
                UpdataButton.Enabled = false;
                DeleteButton.Enabled = false;
                quizID = 0;
                questionsID = 0;
                ClearData();
                //comboCourseBox.SelectedIndex = 0;
                ShowDataListOfQuizzes();
                //ListOfChoiceQurse();
            }
            ShowDataListOfQuizzes();
            ListOfChoiceQurse();
        }


    }
}
