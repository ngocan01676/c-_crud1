using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]   
    public class AnswerController : BaseController
    {
        public AnswerController(QuestionDbContext context, IConfiguration configuration) :
            base(context, configuration)
        { }
                

        /// <summary>
        /// Get by question id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}", Name = "get-by-question-id")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var answers = await DbContext.Answers.Include(c => c.Question)
                    .Where(c => c.QuestionId == id).AsNoTracking().ToListAsync();

                if (!answers.Any())
                {
                    return NotFound(); // status code = 404
                }
                else
                {
                    var results = answers.Select(ans => new Answer
                    {
                        Id = ans.Id,
                        Content = ans.Content,
                        QuestionId = ans.QuestionId,
                        UpdatedDate = ans.UpdatedDate,
                        UserId = ans.UserId,
                        QuestionContent = ans.Question.Content
                    });

                    return new ObjectResult(results);  // status code = 200
                }
            }
            catch
            {
                return BadRequest();  // status code = 400
            }           
        }
    }
}