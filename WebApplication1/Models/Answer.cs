using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Answer
    {
        public long Id { get; set; }
        public string Content { get; set; }
        public long QuestionId { get; set; }
        public DateTime UpdatedDate { get; set; }
        public long UserId { get; set; }

        [NotMapped]
        public string QuestionContent { get; set; }

        [JsonIgnore]
        public Question Question { get; set; }
    }
}
