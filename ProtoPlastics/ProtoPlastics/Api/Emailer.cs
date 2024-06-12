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
        private SendEmailService()
        {
            // smtpClient = new ...
            Console.WriteLine("Created SendEmailService");
        }

        public async Task<bool> Call(string name, string emailTo, string subject, string body)
        {
            await Task.Delay(0);
            Console.WriteLine("Email sent");
            return true;
        }

    }
}
