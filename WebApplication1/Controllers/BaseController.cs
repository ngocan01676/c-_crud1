using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class BaseController : Controller
    {
        protected QuestionDbContext DbContext;

        public BaseController(QuestionDbContext context, 
            IConfiguration configuration)
        {
            DbContext = context;
        }
    }
}