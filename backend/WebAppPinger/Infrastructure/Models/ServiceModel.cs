using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebAppPinger.Infrastructure.Models
{
    public class ServiceModel
    {
        public string Name { get; set; }

        public List<string> Uri { get; set; }

        [Range(1, 3600)]
        public int Interval { get; set; }

        [Range(1, 5)]
        public int RepitsOnFailNumber { get; set; }
    }
}