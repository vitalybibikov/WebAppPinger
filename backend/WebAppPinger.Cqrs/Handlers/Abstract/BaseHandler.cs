using WebAppPinger.Data;

namespace WebAppPinger.Cqrs.Handlers.Abstract
{
    public class BaseHandler
    {
        protected WebPingerDbContext Context { get; }

        protected BaseHandler(WebPingerDbContext context)
        {
            Context = context;
        }
    }
}
