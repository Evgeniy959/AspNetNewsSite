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
        public IActionResult Show()
        {
            return View();
        }

        [HttpPost]
        //  [ValidateAntiForgeryToken]
        public async Task<IActionResult> Subscribe(Person person)
        {
            blogDbContext.Persons.AddAsync(person);
            await blogDbContext.SaveChangesAsync();
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append($"<h2>Поздравляем {person.Name} Вы подписаны на наши новости!</h2>");
            await emailSender.SendEmailAsync(person.Email, "Подписка на новости NewsSite", stringBuilder.ToString());
            return View(person);
        }
        
        [HttpGet]
        public IActionResult Unsubsribe()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Unsubsribe(Person person, string Email)
        {
            //person.Name = "ser";
            person = blogDbContext.Persons.Where(x => x.Email == Email).FirstOrDefault();
            //Person person1 = person.;
            Console.WriteLine(person.Id);
            person = blogDbContext.Persons.Find(person.Id);
            if (person != null)
            {
                blogDbContext.Persons.Remove(person);
                //db.SaveChanges();
                await blogDbContext.SaveChangesAsync();
            }
            //return RedirectToAction("Index");
            //return View(person);
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append($"<h2>Вы отписаны от наших новостей!</h2>");
            await emailSender.SendEmailAsync(Email, "Подписка на новости NewsSite", stringBuilder.ToString());
            return View("Show");
        }
        
    }
}
