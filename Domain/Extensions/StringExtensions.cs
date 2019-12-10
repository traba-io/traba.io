using System;

namespace Domain.Extensions
{
    public static class StringExtensions
    {
        public static string ToConnectionString(this string text)
        {
            try
            {
                var uri = new Uri(text);
                var username = uri.UserInfo.Split(':')[0];
                var password = uri.UserInfo.Split(':')[1];
                return
                    $"User ID={username};Password={password};Host={uri.Host};Port={uri.Port};Database={uri.Segments[1]}";
            }
            catch
            {
                return text;
            }
        }
    }
}