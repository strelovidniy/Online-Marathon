using System;

namespace Sprint_10.Task_07
{
    public class MailSender
    {
        public string From { get; set; }
        public string To { get; set; }
        public string Subject { get; set; }

        public void SendEmail(string mailMessage)
        {
            Console.WriteLine("Sending Email: {0}", mailMessage);
            // Code for getting Email setting and send invoice mail
        }
    }
}
