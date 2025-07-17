using Microsoft.AspNetCore.Mvc;
using DevToolKit.Models;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DevToolKit.Controllers
{
    public class ContactController : Controller
    {
        [HttpGet("/contact")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("/contact")]
        public async Task<IActionResult> Index(ContactViewModel model)
        {
            if (ModelState.IsValid)
            {
                var body = new StringBuilder();
                body.AppendLine($"<h2>New Contact or Tool Suggestion</h2>");
                body.AppendLine($"<b>Name:</b> {model.Name}<br/>");
                body.AppendLine($"<b>Email:</b> {model.Email}<br/>");
                body.AppendLine($"<b>Subject:</b> {model.Subject}<br/>");
                if (!string.IsNullOrWhiteSpace(model.ToolSuggestion))
                    body.AppendLine($"<b>Tool Suggestion:</b> {model.ToolSuggestion}<br/>");
                body.AppendLine($"<b>Message:</b><br/>{model.Message?.Replace("\n", "<br/>")}");

                try
                {
                    await SendEmailAsync("asifrjv@gmail.com", "Developer Tools - New Contact or Tool Suggestion", body.ToString());
                    ViewBag.Success = true;
                }
                catch
                {
                    ViewBag.Error = true;
                }
            }
            return View(model);
        }

        private async Task SendEmailAsync(string email, string subject, string message)
        {
            try
            {
                var smtpClient = new SmtpClient("smtp.mail.ru", 587)
                {
                    Credentials = new NetworkCredential("asifrjv@mail.ru", "S5Jk6bJp4Th6bfrnZqjP"),
                    EnableSsl = true
                };

                var mailMessage = new MailMessage
                {
                    From = new MailAddress("asifrjv@mail.ru"),
                    Subject = subject,
                    Body = message,
                    IsBodyHtml = true,
                };

                mailMessage.To.Add(email);

                await smtpClient.SendMailAsync(mailMessage);
            }
            catch (Exception ex)
            {
                // Optionally log the error
                throw;
            }
        }
    }
} 