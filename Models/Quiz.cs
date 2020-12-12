using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace rateservice.Models
{
    public class Quiz
    {
        public int Id { get; set; }
        [Required]
        public string QuizTitle { get; set; }
        [Required]
        public bool ForFriends { get; set; }
        [Required]
        public bool QuizIsActive { get; set; }
        [Required]
        public bool IsAnonymously { get; set; }
        [Required]
        public int? QuizStyleId { get; set; }
        [Required]
        public int? UserId { get; set; }
        public virtual User User { get; set; }
        public virtual QuizStyle QuizStyle { get; set; }
        public virtual ICollection<Rate> Rates { get; set; }
        public virtual ICollection<QuizChoice> QuizChoices { get; set; }

        public Quiz()
        {
            Rates = new List<Rate>();
            QuizChoices = new List<QuizChoice>();
        }
    }
}