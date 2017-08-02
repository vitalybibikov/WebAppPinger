namespace WebAppPinger.Settings
{
    public class HangfireSettings
    {
        public string ServerName { get; set; }

        public string QueueName { get; set; }

        public int HangfireTaskInterval { get; set; }
    }
}
