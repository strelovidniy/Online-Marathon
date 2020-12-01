using System;

namespace Sprint_10.Task_02
{
    public class MailService : NotificationService
    {
        public string Email { get; set; }
        public string EmailTitle { get; set; }
        public string EmailBody { get; set; }

        public bool ValidEmail()
            => Email.Contains("@");

        public override void SendNotification()
            => Console.WriteLine("Mail:{0}, Title:{1}, Body:{2}", Email, EmailTitle, EmailBody);

        public MailService(string email, string emailTitle, string emailBody)
        {
            Email = email;
            EmailTitle = emailTitle;
            EmailBody = emailBody;
        }
    }
}
