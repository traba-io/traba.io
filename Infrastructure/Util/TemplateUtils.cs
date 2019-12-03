using System;
using System.IO;
using System.Reflection;
using System.Text;
using Infrastructure.Enum;

namespace Infrastructure.Util
{
    public class TemplateUtils
    {
        private static string GetTemplatePath (EmailTemplateType templateType)
        {
            var mainPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var path = templateType switch
            {
                EmailTemplateType.ConfirmAccount => Path.Combine(mainPath, $"Templates/ConfirmAccount.html"),
                _ => throw new ArgumentOutOfRangeException(nameof(templateType), templateType, null)
            };
            return path;
        }

        public static string FormatTemplate(EmailTemplateType templateType, object content)
        {
            var path = GetTemplatePath(templateType);
            
            var builder = new StringBuilder();
            using var reader = File.OpenText(path);
            builder.Append(reader.ReadToEnd());
            
            var properties = content.GetType().GetProperties();
            
            foreach (var propertyInfo in properties)
            {
                builder.Replace($"{{{{{propertyInfo.Name}}}}}", propertyInfo.GetValue(content).ToString());
            }

            return builder.ToString();
        }
    }
}