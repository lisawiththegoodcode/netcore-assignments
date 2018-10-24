using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoApp.Models;

namespace ToDoApp.Controllers
{
    public class SocialMediaViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var SocialMediaCollection = new List<SocialMediaModel>()
            {
                new SocialMediaModel { Href = "https://www.twitter.com/", IconClass = "fab fa-twitter-square"},
                new SocialMediaModel { Href = "https://www.facebook.com/", IconClass = "fab fa-facebook-square"},
                new SocialMediaModel { Href = "https://www.linkedin.com/", IconClass = "fab fa-linkedin-square"}

            };
            return View(SocialMediaCollection);
        }
    }
}

//List<SocialMediaModel> SocialMediaCollection