using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace rateservice.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string FirstName { get; set; }
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
        [Required]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Некорректный адрес")]
        public string Email { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 6, ErrorMessage = "Длина должна быть от 6 до 50 символов")]
        public string Password { get; set; }
        public string Picture { get; set; }

        public virtual ICollection<Question> Questions { get; set; }
        public virtual ICollection<Answer> Answers { get; set; }
        public virtual ICollection<Quiz> Quizs { get; set; }
        public virtual ICollection<Rate> Rates { get; set; }

        [ForeignKey("UserId")]
        public ICollection<Friend> Friends { get; set; }

        [ForeignKey("UserId")]
        public ICollection<FriendRequest> FriendRequests { get; set; }

        public User()
        {
            Questions = new List<Question>();
            Answers = new List<Answer>();
            Quizs = new List<Quiz>();
            Rates = new List<Rate>();
            Friends = new List<Friend>();
            FriendRequests = new List<FriendRequest>();
            Picture = "https://www.netactivity.us/backup2019/wp-content/uploads/2018/08/Network-Profile.png";
        }
    }
}