using System;
using System.Collections.Generic;
using System.Text;

namespace ELearningPlatform.Model
{
    public class UserCourses
    {
        public int UserCoursesID { get; set; }
        public int UserID { get; set; }
        public int CoursesID { get; set; }
        public int RescultOfCours { get; set; }
        public bool State { get; set; } //active/in proggres course - true, inactive/ended course - false
        public Courses Courses { get; set; }
        public User User { get; set; }
    }
}
