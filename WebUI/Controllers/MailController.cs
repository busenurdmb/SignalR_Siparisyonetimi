﻿using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using WebUI.Dtos.MailDtos;

namespace WebUI.Controllers
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
            string quillText = createMailDto.Body; // Quill.js editöründen gelen metni buraya yerleştirin

            // Metindeki <p> etiketlerini kaldır
            string cleanedText = quillText.Replace("<p>", "").Replace("</p>", "");
            createMailDto.Body= cleanedText;
            MimeMessage mimeMessage = new MimeMessage();

            MailboxAddress mailboxAddressFrom = new MailboxAddress("SignalR Rezervasyon", "projekursapi@gmail.com");
            mimeMessage.From.Add(mailboxAddressFrom);

            MailboxAddress mailboxAddressTo = new MailboxAddress("User", createMailDto.ReceiverMail);
            mimeMessage.To.Add(mailboxAddressTo);

            var bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody = createMailDto.Body ;
            mimeMessage.Body = bodyBuilder.ToMessageBody();

            mimeMessage.Subject=createMailDto.Subject;

            SmtpClient client = new SmtpClient();
            client.Connect("smtp.gmail.com", 587, false);
            client.Authenticate("projekursapi@gmail.com", "itcs zbby vbzk uugm");

            client.Send(mimeMessage);
            client.Disconnect(true);

            return RedirectToAction("Index", "Category");
        }
    }
}
