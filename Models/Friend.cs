using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace rateservice.Models
{
    public class Friend
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int? UserId { get; set; }
        [Required]
        public int? FuserId { get; set; }

        [DataType(DataType.Date)]
        public DateTime FriendDate { get; set; }
        public virtual User User { get; set; }
        public virtual User Fuser { get; set; }
    }
}