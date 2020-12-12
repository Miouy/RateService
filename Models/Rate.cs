using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace rateservice.Models
{
    public class Rate
    {
        public int Id { get; set; }
        [Required]
        public int? QuizChoiceId { get; set; }
        [Required]
        public int? UserId { get; set; }
        [Required]
        public int? QuizId { get; set; }
        public virtual User User { get; set; }
        public virtual Quiz Quiz { get; set; }
        public virtual QuizChoice QuizChoice { get; set; }
    }
}