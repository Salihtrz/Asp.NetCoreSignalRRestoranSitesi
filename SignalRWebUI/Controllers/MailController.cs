using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using SignalRWebUI.Dtos.MailDtos;

namespace SignalRWebUI.Controllers
{
    public class MailController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(CreateMailDto createMailDto)
        {
            MimeMessage mimeMessage = new MimeMessage();
            MailboxAddress mailboxAddressFrom = new MailboxAddress("SignalRRezervasyon","muazcetin81@gmail.com");
            mimeMessage.From.Add(mailboxAddressFrom); // Mailin kimden gönderileceği
            MailboxAddress mailboxAddressTo = new MailboxAddress("user",createMailDto.ReceiverMail);
            mimeMessage.To.Add(mailboxAddressTo); // Mailin kime gönderileceği
            var bodybuilder = new BodyBuilder();
            bodybuilder.TextBody = createMailDto.Body;
            mimeMessage.Body = bodybuilder.ToMessageBody(); // Mailin içeriği
            mimeMessage.Subject = createMailDto.Subject;
            
            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Connect("smtp.gmail.com",587,false);
            smtpClient.Authenticate("muazcetin81@gmail.com", "gjer ikuj jtyz fbca");
            smtpClient.Send(mimeMessage);
            smtpClient.Disconnect(true);
            return RedirectToAction("Index","Category");
        }
    }
}
