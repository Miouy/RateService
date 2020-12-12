using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace rateservice.Models
{
    public class Answer
    {
        public int Id { get; set; }
        [Required]
        [DataType(DataType.MultilineText)]
        public string AnswerText { get; set; }
        [Required]
        public int? QuestionId { get; set; }
        [Required]
        public int? UserId { get; set; }

        [Required]
        public virtual User User { get; set; }
        
        [Required]
        public virtual Question Question { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();

            if (string.IsNullOrWhiteSpace(this.AnswerText))
                errors.Add(new ValidationResult("Требуется поле AnswerText."));

            return errors;
        }
    }
}