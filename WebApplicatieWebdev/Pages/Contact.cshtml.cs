using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json.Linq;
using System.ComponentModel.DataAnnotations;
using System.Net.Mail;
using System.Text.RegularExpressions;
using WebCommon.ViewModels;

namespace WebApplicatieWebdev.Pages
{
    public class ContactModel : PageModel
    {
        [BindProperty] public ContactViewModel ContactForm { get; set; }

        public const int MaxSubjectLength = 200;
        public const int MaxMessageLength = 600;
        public Func<string, bool> EmailCheck = x => new EmailAddressAttribute().IsValid(x);

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var response = Request.Form["g-recaptcha-response"];
            var client = new HttpClient();
            var result = await client.GetStringAsync($"https://www.google.com/recaptcha/api/siteverify?secret=6LewDRglAAAAAMAXfArFgKeMoBFbS3cJAntQjmnH&response={response}");
            var obj = JObject.Parse(result);
            var success = (bool)obj["success"];
            var subjectValid = ContactForm.Subject.Length > 0 && ContactForm.Subject.Length <= MaxSubjectLength;
            var emailValid = EmailCheck(ContactForm.Email);
            var messageValid = ContactForm.Message.Length > 0 && ContactForm.Subject.Length <= MaxMessageLength;

            if (!success)
            {
                ModelState.AddModelError("reCAPTCHA", "Please complete the reCAPTCHA challenge.");
            }

            if (!subjectValid)
            {
                ModelState.AddModelError("Subject", "Subject has to be between 1-200 characters long.");
            }

            if (!emailValid)
            {
                ModelState.AddModelError("Email", "Invalid email. (test@email.com)");
            }

            if (!messageValid)
            {
                ModelState.AddModelError("Message", "Message has to be between 1-600 characters long.");
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }

            using (var message = new MailMessage(ContactForm.Email, "s1123859@student.windesheim.nl"))
            {
                message.Subject = ContactForm.Subject;
                message.Body = ContactForm.Message;
                using (var smtpClient = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtpClient.UseDefaultCredentials = false;
                    await smtpClient.SendMailAsync(message);
                    return RedirectToPage("ContactConfirmation");
                }
            }
        }
    }
}
