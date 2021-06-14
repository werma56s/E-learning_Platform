using System;
using System.Collections.Generic;
using System.Text;

namespace ELearningPlatform
{
    static class AboutUser //class working like session in web app, Inspireited by atricle in stacoverflow : https://stackoverflow.com/questions/14599127/session-for-windows-forms-application-in-c-sharp
    {
        public static int UserID { get; set; }
        public static string Name { get; set; }
        public static string Surname { get; set; }
        public static string Login { get; set; }
        public static string Password { get; set; }
        public static int TypeAccound { get; set; }

        public static string FullName()
        {
            return Name + " " + Surname;
        }
        public static string TypeAccoundd()
        {
            string role = String.Empty;
            if(TypeAccound == 1)
            {
                role = "Admin";
            }
            else if (TypeAccound == 2)
            {
                role = "User - Student";

            }else if (TypeAccound == 3)
            {
                role = "Creator";
            }
            return role;
        }
    }
}
