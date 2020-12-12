using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace rateservice.Models
{
    public class FriendRequest
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int? UserId { get; set; }
        [Required]
        public int? SenderId { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime SentTime { get; set; }
        public virtual User User { get; set; }
        public virtual User Sender { get; set; }

    }
}