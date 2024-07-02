using System.Net;
using System.Net.Mail;
namespace ProtoPlastics.Api
{
    public class SendEmailService
    {
        private static SendEmailService? instance = null;
        public static SendEmailService Instance()
        {
            if (instance == null)
            {
                instance = new SendEmailService();
            }
            return instance;
        }


        private static readonly string HOST_MAIL = Environment.GetEnvironmentVariable("HOST_MAIL") ?? "";
        private static readonly string HOST_KEY = Environment.GetEnvironmentVariable("HOST_KEY") ?? "";
        private static readonly string MAIL_TO = Environment.GetEnvironmentVariable("MAIL_TO") ?? "";
        SmtpClient? smtpClient;
        private SendEmailService() { }

        public bool Call(string name, string email, string subject, string body)
        {
            // await Task.Delay(0);
            Console.WriteLine("Attempting to send email");
            try
            {
                NetworkCredential myCredentials = new NetworkCredential(HOST_MAIL, HOST_KEY);
                smtpClient = new SmtpClient("smtp-mail.outlook.com")
                {
                    Port = 587,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    EnableSsl = true,
                    Credentials = myCredentials,

                };

                MailMessage message = new MailMessage(HOST_MAIL, MAIL_TO)
                {
                    Subject = $"Website Inquiry: {subject}",
                    Body = CreateBody(name, email, body),
                    IsBodyHtml = true
                };
                smtpClient.Send(message);

                Console.WriteLine("Email sent");
                return true;
            }
            catch (Exception exc)
            {
                Console.WriteLine("Emailer:\n" + exc.ToString());
                return false;
            }
        }

        private string CreateBody(string name, string email, string body)
        {
            return $@"
            <div class=""md-padding"">
                <h1>You've got a message!</h1>
  
                <h3>Sent from {name} ( <a href=""mailto:{email}"">{email}</a> )</h3>
  
                <p>{body}</p>
            </div>
            ";
        }

    }
}
