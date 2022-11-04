using AspNetNewsSite.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetNewsSite.Controllers
{
    public class PostController : Controller
    {
        private readonly BlogDbContext blogDbContext;
        private readonly IEmailSender emailSender;

        public PostController(BlogDbContext blogDbContext, IEmailSender emailSender)
        {
            this.blogDbContext = blogDbContext;
            this.emailSender = emailSender;
        }


        [HttpGet]
        public IActionResult Add()
        {
            //ModelState.AddModelError("Title", "99999");
            /*ViewBag.Categories = new SelectList(blogDbContext.Categories, "Id", "Name"); 
            ViewBag.Tags = new MultiSelectList(blogDbContext.Tags, "Id", "Name");*/ 
            return View();
        }

        [HttpGet]
        /*public IActionResult Index()
        {
            return View(blogDbContext.Posts.Include(x => x.Category).ToList());
        }*/

        [HttpPost]
        //  [ValidateAntiForgeryToken]
        public async Task<IActionResult> SendEmail(Person person)
        {
            blogDbContext.Persons.AddAsync(person);
            await blogDbContext.SaveChangesAsync();
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append($"<h2>Поздравляем {person.Name} Вы подписаны на наши новости!</h2>");
            await emailSender.SendEmailAsync(person.Email, "Подписка на новости NewsSite", stringBuilder.ToString());
            return View(person);
        }
    }
}
