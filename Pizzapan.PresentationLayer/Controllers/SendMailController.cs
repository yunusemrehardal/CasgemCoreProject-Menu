using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using Pizzapan.PresentationLayer.Models;

namespace Pizzapan.PresentationLayer.Controllers
{
    public class SendMailController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(MailRequest mailRequest)
        {
            SendEmail(mailRequest);
            return View();
        }
        public void SendEmail(MailRequest mailRequest)
        {
            MimeMessage mimeMessage = new MimeMessage();
            MailboxAddress mailboxAddressFrom = new MailboxAddress("Admin", "hardaalyunusemre@gmail.com");
            mimeMessage.From.Add(mailboxAddressFrom);

            MailboxAddress mailboxAddressTo = new MailboxAddress("User", mailRequest.RecieverMail);
            mimeMessage.To.Add(mailboxAddressTo);

            var bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody = mailRequest.MessageContent;
            mimeMessage.Body = bodyBuilder.ToMessageBody();

            using (var smtpClient = new SmtpClient())
            {
                smtpClient.Connect("smtp.gmail.com", 587, false);
                smtpClient.Authenticate("hardaalyunusemre@gmail.com", "vjorucsdznkgqdno");
                smtpClient.Send(mimeMessage);
                smtpClient.Disconnect(true);
            }
        }
        
    }
}
