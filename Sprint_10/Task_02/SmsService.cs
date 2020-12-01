using System;

namespace Sprint_10.Task_02
{
    public class SmsService : NotificationService
    {
        public string Number { get; set; }
        public string SmsText { get; set; }


        public override void SendNotification()
            => Console.WriteLine("Number:{0}, Message:{1}", Number, SmsText);

        public SmsService(string number, string smsText)
        {
            Number = number;
            SmsText = smsText;
        }
    }
}
