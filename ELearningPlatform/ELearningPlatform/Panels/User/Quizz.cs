using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ELearningPlatform.Data;
using ELearningPlatform.Model;
using System.Linq;

namespace ELearningPlatform.Panels.User
{
    public partial class Quizz : UserControl
    {
        public Quizz()
        {
            InitializeComponent();
            AnswerLabel.AutoSize = true;
            AnswerLabel.Dock = DockStyle.Fill;
        }

        private void panel1_ClientSizeChanged(object sender, EventArgs e)
        {
            AnswerLabel.MaximumSize = new Size((sender as Control).ClientSize.Width - label1.Left, 10000);
        }
        int countOfQusestions;
        private void Quizz_Load(object sender, EventArgs e)
        {
            using var db = new ELearningPlatformContext();
            var listOdIDQuestions = db.Quizzes.Where(q => q.CoursesID == userCurseData.CoursesID).Select(x => x.QuestionsID).ToList();
            countOfQusestions = listOdIDQuestions.Count;
            int firstItemInList;
            if(listOdIDQuestions != null && countOfQusestions != 0)
            {
                firstItemInList = listOdIDQuestions.First();
                Questions questions = new Questions();
                for (int i = 0; i < 1; i++)
                {
                    label3.Text = ++i + "/" + countOfQusestions;

                    questions = db.Questionss.Where(q => q.QuestionsID == firstItemInList).First();
                    AnswerLabel.Text = questions.QTitle;
                    radioButton1.Text = questions.Qa;
                    radioButton2.Text = questions.Qb;
                    radioButton3.Text = questions.Qc;
                    radioButton4.Text = questions.Qd;
                    
                }
                i = 1;
            }
            else
            {
                MessageBox.Show("This course don't have any questions","Inform",MessageBoxButtons.OK,MessageBoxIcon.Information);
                this.Parent.Controls.Remove(this);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Parent.Controls.Remove(this);
            //this.Visible = false;
            // this.SendToBack();
        }

        private void ClearRadioButton()
        {
            if (radioButton1.Checked || radioButton2.Checked || radioButton3.Checked || radioButton4.Checked)
            {
                radioButton1.Checked = false; 
                radioButton2.Checked = false;
                radioButton3.Checked = false;
                radioButton4.Checked = false;
            }
        }
        int j = 0;
        private int Result()
        {
            return (j * 100) / countOfQusestions;
        }
        //public string Error = string.Empty;
        private bool AddResultToData(int result)
        {
            bool state = false;
            try
            {
                using var db = new ELearningPlatformContext();
                UserCourses userCourses = new UserCourses();
                userCourses = db.UserCoursess.Where(u => u.UserID == AboutUser.UserID && u.CoursesID == userCurseData.CoursesID).First();
                userCourses.RescultOfCours = result;
                db.UserCoursess.Update(userCourses);
                db.SaveChanges();
                state = true;
            }
            catch(Exception e)
            {
                //Error = e;
                state = false;
            }
            return state;
        }

        int i = 1; 
        private void button2_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)  {  j++;  }
            using var db = new ELearningPlatformContext();
            var listOdIDQuestions = db.Quizzes.Where(q => q.CoursesID == userCurseData.CoursesID).Select(x => x.QuestionsID).ToList();
            countOfQusestions = listOdIDQuestions.Count;
            int firstItemInList = listOdIDQuestions.First();
                Questions questions = new Questions();
            while (true)
            {
                if (i <= countOfQusestions)
                {
                    if (i == countOfQusestions)
                    {

                        if (AddResultToData(Result()))
                        {
                            string result = "Result of Cours: " + Result();
                            MessageBox.Show(result, "End OF Course", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            break;
                        }
                        else
                        {
                            MessageBox.Show("Contact with admin", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                    int q = i;
                    label3.Text = ++q + "/" + countOfQusestions;

                    //
                    questions = db.Questionss.Where(q => q.QuestionsID == firstItemInList).ToList().First();
                    AnswerLabel.Text = questions.QTitle;
                    radioButton1.Text = questions.Qa;
                    radioButton2.Text = questions.Qb;
                    radioButton3.Text = questions.Qc;
                    radioButton4.Text = questions.Qd;

                    i++;
                    ClearRadioButton();
                    break;
                }
            }
        }

        private void radioButton1_Click(object sender, EventArgs e)
        {
            /*if (radioButton1.Checked || radioButton2.Checked || radioButton3.Checked || radioButton4.Checked)
            {
                button2.Enabled = true;
            }*/
            button2.Enabled = true;
        }

        private void radioButton2_Click(object sender, EventArgs e)
        {
            button2.Enabled = true;
        }

        private void radioButton3_Click(object sender, EventArgs e)
        {
            button2.Enabled = true;
        }

        private void radioButton4_Click(object sender, EventArgs e)
        {
            button2.Enabled = true;
        }
    }
}
