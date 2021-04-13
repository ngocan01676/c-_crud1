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
    public class QuestionController : BaseController
    {
        public QuestionController(QuestionDbContext context, 
            IConfiguration configuration) :
            base(context, configuration) { }

        /// <summary>
        /// Get all questions
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<Question>> Get()
        {
            var questions = await DbContext.Questions.AsNoTracking().ToListAsync();
            return questions;
        }


        /// <summary>
        /// Get a question by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var question = await DbContext.Questions.AsNoTracking().FirstOrDefaultAsync(q => q.Id == id);

                if (question == null)
                {
                    return NotFound();
                }
                else
                {
                    return new ObjectResult(question);
                }        
            }
            catch(Exception ex)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// POST api/question
        /// </summary>
        /// <param name="value"></param>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Question item)
        {
            try
            {
                if (item == null)
                {
                    return BadRequest();
                }
                else
                {
                    DbContext.Questions.Add(item);
                    await DbContext.SaveChangesAsync();

                    return new ObjectResult(item); // status 200 => OK
                }
            }
            catch(Exception ex)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// PUT api/question/id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Question item)
        {
            try
            {
                if (item == null || item.Id != id)
                {
                    return BadRequest();
                }
                else
                {
                    //var question = DbContext.Questions.AsNoTracking().FirstOrDefault(q => q.Id == id);
                    var question = DbContext.Questions.FirstOrDefault(q => q.Id == id);
                    if (question == null)
                    {
                        return NotFound();
                    }
                    else
                    {
                       question.Update(item);
                       // DbContext.Attach(question);
                      //  DbContext.Entry(question).State = EntityState.Modified;
                      await DbContext.SaveChangesAsync();

                       return new ObjectResult(question); // status 200 => OK
                    }            
                }
            }
            catch
            {
                return BadRequest(); // status code = 400 
            }
        }

        /// <summary>
        /// DELETE api/question/id
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                if (id < 1)
                {
                    return BadRequest();
                }
                else
                {
                    var question = DbContext.Questions.FirstOrDefault(q => q.Id == id);
                    if (question == null)
                    {
                        return NotFound();
                    }

                    DbContext.Questions.Remove(question);
                    await DbContext.SaveChangesAsync();
                }
               
                return new NoContentResult(); //status code = 204
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}









/* 
    return Ok(); // Http status code 200
    return Created(); // Http status code 201
    return NoContent(); // Http status code 204
    return BadRequest(); // Http status code 400
    return Unauthorized(); // Http status code 401
    return Forbid(); // Http status code 403
    return NotFound(); // Http status code 404
*/
