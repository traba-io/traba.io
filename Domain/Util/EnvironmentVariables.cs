using System;

namespace Domain.Util
{
    public static class EnvironmentVariables
    {
        public static string DatabaseUrl => Environment.GetEnvironmentVariable("DATABASE_URL");
        public static string SendGridApiKey => Environment.GetEnvironmentVariable("SENDGRID_API_KEY");
        public static string TinyPngApiKey => Environment.GetEnvironmentVariable("TINYPNG_API_KEY");
        public static string AwsAccessKeyId => Environment.GetEnvironmentVariable("AWS_ACCESS_KEY_ID");
        public static string AwsSecretAccessKey => Environment.GetEnvironmentVariable("AWS_SECRET_ACCESS_KEY");
        public static string AwsBucketName => Environment.GetEnvironmentVariable("AWS_BUCKET_NAME");
    }
}