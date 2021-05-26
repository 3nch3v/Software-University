namespace SIS.HTTP.Cookies
{
    public interface IHttpCookieCollection
    {
        void AddCoookie(HttpCookie cookie);

        bool ContainsCookie(string key);

        HttpCookie GetCookie(string key);

        bool HasCookie();
    }
}
