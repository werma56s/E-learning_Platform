using System;
using System.Collections.Generic;
using System.Text;

namespace ELearningPlatform.Model
{
    public class Category
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public ICollection<Courses> Coursess { get; set; }
    }
}
