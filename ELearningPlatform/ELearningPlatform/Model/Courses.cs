using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ELearningPlatform.Model
{
    public class Courses
    {
        public int CoursesID { get; set; }
        
        [Required]
        [MaxLength(200)]
        public string Title { get; set; }

        [Required]
        [MaxLength(5000)]
        public string Description { get; set; }

        [Required]
        [MaxLength(100)]
        public string Author { get; set; }
        public int Views { get; set; }

        public int CategoryID { get; set; }
        public Category Category { get; set; } 

        public ICollection<UserCourses> UserCourses { get; set; }
        public ICollection<Quiz> Quizzes { get; set; }
    }
}
