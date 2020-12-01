using System;

namespace Sprint_10.Task_01
{
    public class MailService
    {
        public bool ValidEmail(string email)
            => email.Contains("@");

        public void SendEmail(string mail, string emailTitle, string emailBody)
            => Console.WriteLine("Mail:{0}, Title:{1}, Body:{2}", mail, emailTitle, emailBody);
    }
}
