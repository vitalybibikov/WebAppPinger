using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppPinger.Data.Entities
{
    [Table("Endpoints", Schema = "pin")]
    public class EndpointEntity
    {
        public long Id { get; set; }

        public string Url { get; set; }

        public int Interval { get; set; }

        public DateTime LastPinged { get; set; }
    }
}