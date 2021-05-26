namespace SIS.HTTP.Cookies
{
    using SIS.HTTP.Common;
    using System.Collections.Generic;
    using System.Linq;

    public class HttpCookieCollection : IHttpCookieCollection
    {
        private const string HttpCookiesStringSeparator = ";";

        private List<HttpCookie> cookies;

        public HttpCookieCollection()
        {
            this.cookies = new List<HttpCookie>();
        }

        public void AddCoookie(HttpCookie cookie)
        {
            CoreValidator.ThrowIfNull(cookie, nameof(cookie));
            this.cookies.Add(cookie);
        }

        public bool ContainsCookie(string key)
        {
            CoreValidator.ThrowIfNullOrEmpty(key, nameof(key));
            return this.cookies.Any(c => c.Key == key);
        }

        public HttpCookie GetCookie(string key)
        {
            CoreValidator.ThrowIfNullOrEmpty(key, nameof(key));
            return this.cookies.FirstOrDefault(x => x.Key == key);
        }

        public bool HasCookie()
        {
            return this.cookies.Any();
        }

        public override string ToString()
        {
            return string.Join(HttpCookiesStringSeparator, this.cookies);
        }
    }
}
