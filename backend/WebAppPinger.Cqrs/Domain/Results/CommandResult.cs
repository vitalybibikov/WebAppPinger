using System;

namespace WebAppPinger.Cqrs.Domain.Results
{
    public class CommandResult
    {
        public long Id { get; set; }

        public string Message { get; set; }

        public bool Success { get; set; }
    }
}
