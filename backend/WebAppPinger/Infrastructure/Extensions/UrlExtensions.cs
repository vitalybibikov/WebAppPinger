using System;

namespace WebAppPinger.Infrastructure.Extensions
{
    public static class UrlExtensions
    {
        public static bool CheckUrlValid(this string source)
        {
            Uri uriResult;
            return Uri.TryCreate(source, UriKind.Absolute, out uriResult) &&
                   (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
        }
    }
}