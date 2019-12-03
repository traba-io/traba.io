using System;

namespace Domain.Util
{
    public static class EnvironmentVariables
    {
        public static string MainConnectionString => Environment.GetEnvironmentVariable("MAIN_CONNECTION_STRING");
        public static string SendGridApiKey => Environment.GetEnvironmentVariable("SENDGRID_API_KEY");
    }
}