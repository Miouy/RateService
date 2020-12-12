using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace rateservice.Models
{
    public class RateContext:DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Rate> Rates { get; set; }
        public DbSet<QuizStyle> QuizStyles { get; set; }
        public DbSet<QuizChoice> QuizChoices { get; set; }
        public DbSet<Quiz> Quizs { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Friend> Friends { get; set; }

    }
}