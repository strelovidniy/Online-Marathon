using System;

namespace Sprint_10.Task_05
{
    public class SmsService : INotification
    {
        public string Number { get; set; }
        public string SmsText { get; set; }


        public void SendNotification()
            => Console.WriteLine("Number:{0}, Message:{1}", Number, SmsText);

        public SmsService(string number, string smsText)
        {
            Number = number;
            SmsText = smsText;
        }

        public SmsService()
        {

        }
    }
}
