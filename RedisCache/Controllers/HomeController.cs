using ServiceStack.Redis;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RedisCache.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Counter()
        {
            var host = ConfigurationManager.AppSettings["host"].ToString();
            var port = Convert.ToInt32(ConfigurationManager.AppSettings["port"]);
            RedisEndpoint redisEndpoint = new RedisEndpoint(host, port);

            using (var client = new RedisClient(redisEndpoint))
            {
                ViewBag.Visit = client.Increment("Website_Counter", 1);
            }

            return View();
        }
    }
}