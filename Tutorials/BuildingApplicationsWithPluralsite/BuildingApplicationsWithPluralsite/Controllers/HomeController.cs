using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BuildingApplicationsWithPluralsite.Controllers
{
    public class HomeController : Controller
    {

        public HomeController(IMailService mail)
        {
            private IMailService _mail;

            public HomeController(IMailService mail)
            {
                _mail = mail;
            }
        

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

        [HttpPost]
        public ActionResult Contact(ContactModel model)
        {
            var msg = string.Format("Comment Form: {1}{0}Email:{2}{0}Website: {3}{0}Comments" Environment.NewLine,
                model.Name,
                model.Email,
                model.Website,
                model.Comment);

            var svc = new MailService();

            if (_mail.SendMail("noreply@yourdomain.com", "foo@yourdomail.com", "Website Contact", msg))
            {
                ViewBag.MailSent = true;
            }
            return View();
        }

        [Authorize]
        public ActionResult MyMessages)
        {
            return View();
        }

        [Authorize]
        public ActionResult Moderation()
        {
        return View();
        }
}
}