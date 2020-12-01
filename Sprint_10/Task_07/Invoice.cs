using System;

namespace Sprint_10.Task_07
{
    public class Invoice
    {
        public long Amount { get; set; }
        public DateTime InvoiceDate { get; set; }

        public void FileLogger()
        {
            // Code for initialization i.e. Creating Log file with specified  
            // details
        }

        public void Add()
        {
            Console.WriteLine("Adding amount...");
            // Code for adding invoice
            // Once Invoice has been added , send mail 
            var mailMessage = "Your invoice is ready.";

            new MailSender().SendEmail(mailMessage);
        }

        public void Delete()
        {
            Console.WriteLine("Deleting amount...");
            // Code for Delete invoice
        }
    }
}
