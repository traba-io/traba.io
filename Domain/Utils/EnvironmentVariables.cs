using System;

namespace Domain.Utils
{
    public static class EnvironmentVariables
    {
        public static string MainConnectionString => Environment.GetEnvironmentVariable("MAIN_CONNECTION_STRING");
    }
}