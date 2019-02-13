using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Wissen.Controllers
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
        [HttpPost]
        public ActionResult Contact(string firstName, string lastName, string email, string phone, string subject,string message)
        {
            //
            //todoMail gönderme
            System.Net.Mail.MailMessage mailMessage = new System.Net.Mail.MailMessage();

            mailMessage.From = new System.Net.Mail.MailAddress("macitbunyamin@gmail.com", "Gönderen Firma Adı");
            mailMessage.Subject = "İletişim Formu: " + firstName +lastName;

            mailMessage.To.Add("macitbunyamin@gmail.com");

            string body;
            body = "Ad Soyad: " + firstName+ lastName +"<br />";
            body += "Telefon: " +phone+ "<br />";
            body += "E-posta: " + email+ "<br />";
            body += "Konu: " + subject + "<br />";
            body += "Mesaj: " +message + "<br />";
            body += "Tarih: " + DateTime.Now.ToString("dd MMMM yyyy") + "<br />";
            mailMessage.IsBodyHtml = true;
            mailMessage.Body = body;

            System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient("smtp.gmail.com", 587);
            smtp.Credentials = new System.Net.NetworkCredential("macitbunyamin@gmail.com", "gönderici sifresi");
            smtp.EnableSsl = true;
            smtp.Send(mailMessage);
           
            ViewBag.Message = "Form başarıyla ileildi,en kısa zamanda dönüş yapacağız...";
            return View();
        }
    }
}