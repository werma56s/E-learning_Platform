using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ELearningPlatform.Model
{
    public class User
    {
        public int UserID { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        
        [MaxLength(50)]
        public string Surname { get; set; }
        
        [Required]
        [MaxLength(50)]
        public string Login { get; set; }
        
        [Required]
        [MaxLength(400)]
        public string Password { get; set; }
        public int RoleID { get; set; }
        public Role Role { get; set; }
        public ICollection<UserCourses> UserCourses { get; set; }
    }
}
