namespace SIS.HTTP.Cookies
{
    using System;
    using System.Text;

    using SIS.HTTP.Common;

    public class HttpCookie
    {
        private const int HttpCookieDefaultExprirationDays = 3;
        private const string HttpCookieDefaultPath = "/";

        public HttpCookie(string key, 
                          string value, 
                          int exprires = HttpCookieDefaultExprirationDays, 
                          string path = HttpCookieDefaultPath)
        {
            CoreValidator.ThrowIfNullOrEmpty(key, nameof(key));
            CoreValidator.ThrowIfNullOrEmpty(value, nameof(value));

            this.Key = key;
            this.Value = value;
            this.IsNew = true;
            this.Path = path;
            this.Expires = DateTime.UtcNow.AddDays(exprires);
        }

        public HttpCookie(string key,
                          string value,
                          bool isNew,
                          int exprires = HttpCookieDefaultExprirationDays,
                          string path = HttpCookieDefaultPath)
            : this(key, value, exprires, path)
        {
            this.IsNew = isNew;
        }

        public string Key { get; set; }

        public string Value { get; set; }

        public DateTime Expires { get; private set; }

        public string Path { get; set; }

        public bool IsNew { get; set; }

        public bool HttpOnly { get; set; } = true;

        public void Delete()
        {
            this.Expires = DateTime.UtcNow.AddDays(-1);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{this.Key}={this.Value}; Expires={this.Expires:R}");

            if (this.HttpOnly)
            {
                sb.Append("; HttpOnly");
            }

            sb.Append($"; Path={this.Path}");

            return sb.ToString().TrimEnd();
        }
    }
}
