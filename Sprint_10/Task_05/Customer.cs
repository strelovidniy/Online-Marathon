using System;

namespace Sprint_10.Task_05
{
    public class Customer
    {
        public INotification Notification { get; set; }
        
        public void Register(string email, string password)
        {
            try
            {

            }
            catch (Exception e)
            {
                throw;
            }
        }

        public void SendNotification(INotification notification)
            => notification.SendNotification();

        public Customer(INotification notification)
            => Notification = notification;
    }
}
