using System;
using System.Collections.Generic;
using System.Text;

namespace ELearningPlatform.Panels.User
{
    public class userCurseData
    {
        public static int UserCoursesID { get; set; }
        public static int CoursesID { get; set; }
        public static int RescultOfCours { get; set; }
        public static bool State { get; set; }

        public static void Clear()
        {
            UserCoursesID = -1;
            CoursesID = -1;
            RescultOfCours = 0;
            State = false;
        }
    }

}
