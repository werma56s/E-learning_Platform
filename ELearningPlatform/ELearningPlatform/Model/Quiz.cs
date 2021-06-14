using System;
using System.Collections.Generic;
using System.Text;

namespace ELearningPlatform.Model
{
    public class Quiz
    {
        public int QuizID { get; set; }
        public int QuestionsID { get; set; }
        public Questions Questions { get; set; }
        public int CoursesID { get; set; }
        public Courses Courses { get; set; }
    }
}
