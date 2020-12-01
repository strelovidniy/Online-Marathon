using System;

namespace Sprint_10.Task_03
{
    public class Customer
    {
        public static void Register(string email, string password)
        {
            try
            {
                var mailService = new MailService(email, "User registration", "Body of message...");
                var smService = new SmsService("111 111 111", "User successfully registered...");
                
                if (mailService.ValidEmail())
                {
                    mailService.SendNotification();
                    smService.SendNotification();
                }
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
