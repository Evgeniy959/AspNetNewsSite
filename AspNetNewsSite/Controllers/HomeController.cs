using AspNetNewsSite.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetNewsSite.Controllers
{
    public class HomeController : Controller
    {
        private readonly BlogDbContext blogDbContext;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, BlogDbContext blogDbContext)
        {
            _logger = logger;
            this.blogDbContext = blogDbContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult NewsWorld()
        {
            return View(blogDbContext.Сomments.Where(x => x.PostTitle == "NewsWorld").ToList());
        }

        public IActionResult NewsInteresting()
        {
            return View(blogDbContext.Сomments.Where(x => x.PostTitle == "NewsInteresting").ToList());
        }

        public IActionResult NewsEcology()
        {
            return View(blogDbContext.Сomments.Where(x => x.PostTitle == "NewsEcology").ToList());
        }

        public IActionResult GoodNews()
        {
            return View(blogDbContext.Сomments.Where(x => x.PostTitle == "GoodNews").ToList());
        }

        public IActionResult Sport()
        {
            return View(blogDbContext.Сomments.Where(x => x.PostTitle == "Sport").ToList());
        }

        public IActionResult Journeys()
        {
            return View(blogDbContext.Сomments.Where(x => x.PostTitle == "Journeys").ToList());
        }

        public IActionResult Games()
        {
            return View(blogDbContext.Сomments.Where(x => x.PostTitle == "Games").ToList());
        }

        public IActionResult Technology()
        {
            return View(blogDbContext.Сomments.Where(x => x.PostTitle == "Technology").ToList());
        }
        public IActionResult Entertainment()
        {
            return View(blogDbContext.Сomments.Where(x => x.PostTitle == "Entertainment").ToList());
        }
        public IActionResult Politics()
        {
            return View(blogDbContext.Сomments.Where(x => x.PostTitle == "Politics").ToList());
        }
        public IActionResult Environment()
        {
            return View(blogDbContext.Сomments.Where(x => x.PostTitle == "Environment").ToList());
        }

        public IActionResult OnlyGoodleft()
        {
            return View(blogDbContext.Сomments.Where(x => x.PostTitle == "OnlyGoodleft").ToList());
        }

        public IActionResult OnlyGoodCentre()
        {
            return View(blogDbContext.Сomments.Where(x => x.PostTitle == "OnlyGoodCentre").ToList());
        }
        
        public IActionResult OnlyGoodRight()
        {
            return View(blogDbContext.Сomments.Where(x => x.PostTitle == "OnlyGoodRight").ToList());
        }

        [HttpPost]
        public async Task<IActionResult> AddComment(Сomment comment)
        {
            comment.Date = DateTime.Now;
            blogDbContext.Сomments.AddAsync(comment);
            await blogDbContext.SaveChangesAsync();
            return View("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
