using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Question
    {
        [Key]
        public long Id { get; set; }
        public string Content { get; set; }
        public long UserId { get; set; }
        public DateTime UpdatedDate { get; set; }

        [JsonIgnore]    
        public ICollection<Answer> Answers { get; set; }

        public Question()
        {
            UpdatedDate = DateTime.Now;
        }

        public void Update(Question question)
        {
            if (question == null)
                return;

            Id = question.Id;
            Content = question.Content;
            UserId = question.UserId;
            UpdatedDate = question.UpdatedDate;
        }
    }
}
