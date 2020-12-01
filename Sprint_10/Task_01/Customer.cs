using System;

namespace Sprint_10.Task_01
{
    public class Customer
    {
        public void Register(string email, string password)
        {
            try
            {
                var mailService = new MailService();
                
                if (mailService.ValidEmail(email))
                {
                    mailService.SendEmail(email, "Email title", "Email body");
                }
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
