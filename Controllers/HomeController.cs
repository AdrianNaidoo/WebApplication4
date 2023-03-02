using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace WebApplication4.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();


        }



        [HttpPost]
        public ActionResult IndexView()
        {
            string url = "https://analytics.google.com/analytics/web/#/p286310101/reports/reportinghub";

            return Redirect(url);

        }

        public ActionResult Sample()
        {
            return View();


        }

        public ActionResult TestEmail()
        {
            string receiver = "21919901@dut4life.ac.za";
            string subject = "E-Library Order Confirmation  ";
            string message = "We have received your order and are processing it. See you soon!";

            try
            {
                if (ModelState.IsValid)
                {
                    var senderEmail = new MailAddress("21919901@dut4life.ac.za", "e-Library");
                    var receiverEmail = new MailAddress(receiver, "Receiver");
                    var password = "Dut010207";
                    var sub = subject;
                    var body = message;
                    var smtp = new SmtpClient
                    {
                        Host = "smtp-mail.outlook.com",
                        Port = 587,
                        EnableSsl = true,
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        UseDefaultCredentials = false,
                        Credentials = new NetworkCredential(senderEmail.Address, password)
                    };
                    using (var mess = new MailMessage(senderEmail, receiverEmail)
                    {
                        Subject = subject,
                        Body = body
                    })
                    {
                        smtp.Send(mess);
                    }
                    return View();
                }
            }
            catch (Exception)
            {
                ViewBag.Error = "Some Error";
            }

            return View();

        }

        //    public ActionResult ThankYou()
        //{



        //    string subject = "<do-not-reply> e-Library Order Confirmation";
        //    string body = "Good day ! We have received your order and are processing it. See you soon!";


        //    return View();
        //}



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
    }
}