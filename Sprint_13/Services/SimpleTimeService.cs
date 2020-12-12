using System;

namespace Sprint_13.Services
{
    public class SimpleTimeService : ITimeService
    {
        public DateTime GeTimeForTomorrow() =>
            DateTime.Today.AddDays(1);
    }
}
