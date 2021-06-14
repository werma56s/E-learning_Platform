using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ELearningPlatform.Model
{
    public class Questions
    {
        public int QuestionsID { get; set; }
        
        [Required]
        [MaxLength(500)]
        public string QTitle { get; set; }
        
        [Required]
        [MaxLength(250)]
        public string Qa { get; set; }
        [Required]
        [MaxLength(250)]
        public string Qb { get; set; }
        [Required]
        [MaxLength(250)]
        public string Qc { get; set; }
        [Required]
        [MaxLength(250)]
        public string Qd { get; set; }
        [Required]
        [MaxLength(250)]
        public string Qcorect { get; set; }
        public ICollection<Quiz> Quiz { get; set; }
        
    }
}
