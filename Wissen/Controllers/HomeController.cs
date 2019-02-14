using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
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
        public ActionResult DenemeForm()
        {
            return View();

        }
        [HttpPost]
        public ActionResult DenemeForm(Wissen.Models.DenemeForm model)
        {
            if(ModelState.IsValid)
            {
                //todo mail gönder
                ViewBag.Message = "mail gonderildi";
                return View();
            }
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
            firstName = firstName.Trim();
            lastName = lastName.Trim();
            email = email.Trim();
            phone = phone.Trim();
            message = message.Trim();
            
            if(firstName=="")
            {
                ViewBag.Message = " Ad alanı gereklidir.";
                ViewBag.IsError = true;
                return View();
            }
            if (firstName.Length>50)
            {
                ViewBag.Message = " Ad alanı 50 karakterden az gereklidir.";
                ViewBag.IsError = true;
                return View();
            }
            if (lastName == "")
            {
                ViewBag.Message = " soyad alanı gereklidir.";
                ViewBag.IsError = true;
                return View();
            }
            if (lastName.Length > 50)
            {
                ViewBag.Message = " soyad alanı 50 karakterden az gereklidir.";
                ViewBag.IsError = true;
                return View();
            }
            if (email =="")
            {
                ViewBag.Message = " email alanı gereklidir.";
                ViewBag.IsError = true;
                return View();
            }
            if (email.Length > 50)
            {
                ViewBag.Message = " email alanı 50 karakterden az gereklidir.";
                ViewBag.IsError = true;
                return View();
            }
            Regex regex = new Regex(@"^5(0[5-7]|[3-5]\d) ?\d{3} ?\d{4}$");
            Match match = regex.Match(phone);

            if (match.Success==false)
            {
                ViewBag.Message = " telefon formatı 5** *** ****.";
                ViewBag.IsError = true;
                return View();
            }
           
            if (message.Length > 50)
            {
                ViewBag.Message = " message alanı  gereklidir.";
                ViewBag.IsError = true;
                return View();
            }
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
            smtp.Credentials = new System.Net.NetworkCredential("macitbunyamin@gmail.com", "34ff6229");
            smtp.EnableSsl = true;
            smtp.Send(mailMessage);
           
            ViewBag.Message = "Form başarıyla ileildi,en kısa zamanda dönüş yapacağız...";
            return View();
        }
    }
}