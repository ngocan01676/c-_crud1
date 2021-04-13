using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    //ref link: http://www.entityframeworktutorial.net/efcore/entity-framework-core.aspx

    public class QuestionDbContext  : DbContext
    {
        public QuestionDbContext(DbContextOptions<QuestionDbContext> options)
           : base(options)
        {
        }

        public DbSet<Question> Questions { get; set; }

        public DbSet<Answer> Answers { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Question>().ToTable("Question");
            modelBuilder.Entity<Answer>().ToTable("Answer");
        }
    }
}
