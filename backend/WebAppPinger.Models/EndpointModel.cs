using System;

namespace WebAppPinger.Models
{
    public class EndpointModel
    {
        public long Id { get; set; }

        public string Url { get; set; }

        public int Interval { get; set; }

        public DateTime LastPinged { get; set; }

        public bool NeedsRequest => (DateTime.Now - LastPinged).Minutes >= Interval;
    }
}