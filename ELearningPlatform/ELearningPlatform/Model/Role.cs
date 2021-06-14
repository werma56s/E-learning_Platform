using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ELearningPlatform.Model
{
    public class Role
    {
        public int RoleID { get; set; }
        
        [MaxLength(20)]
        public string RoleName { get; set; }
        public User User { get; set; }
    }
}
