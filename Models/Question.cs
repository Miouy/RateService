using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace rateservice.Models
{
    public class Question
    {
        public int Id { get; set; }
        [Required]
        public string QuestionTitle { get; set; }
        [Required]
        [Remote("CheckQuestionText", "Home", ErrorMessage = "Текст слишком коротки")]
        public string QuestionText { get; set; }
        [Required]
        public bool ForFriends { get; set; }
        [Required]
        public bool QuestionIsActive { get; set; }
        [Required]
        public bool IsAnonymously { get; set; }
        [Required]
        public int? UserId { get; set; }
        
        [ForeignKey("UserId")]
        public virtual User User { get; set; }
        public ICollection<Answer> Answers { get; set; }

        public Question()
        {
            Answers = new List<Answer>();
        }

    }
}