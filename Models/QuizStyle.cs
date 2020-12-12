using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace rateservice.Models
{
    public class QuizStyle
    {
        public int Id { get; set; }
        [Required]
        public string QuizStyleName { get; set; }
        public ICollection<Quiz> Quizzes { get; set; }

        public QuizStyle()
        {
            Quizzes = new List<Quiz>();
        }
    }
}