using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace rateservice.Models
{
    public class QuizChoice
    {
        public int Id { get; set; }
        [Required]
        public bool IsCorrectChoice { get; set; }
        [Required]
        public string QuizChoiceText { get; set; }
        [Required]
        public int? QuizId { get; set; }
        public virtual ICollection<Rate> Rates { get; set; }
        public virtual Quiz Quiz { get; set; }

        public QuizChoice()
        {
            Rates = new List<Rate>();
        }
    }
}