using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace Repository.Extensions
{
    public static class StringExtensions
    {
        public static string RemoveAccents(this string text)
        {
            var sbReturn = new StringBuilder();
            var arrayText = text.Normalize(NormalizationForm.FormD).ToCharArray();
            foreach (var letter in arrayText)
            {
                if (CharUnicodeInfo.GetUnicodeCategory(letter) != UnicodeCategory.NonSpacingMark)
                    sbReturn.Append(letter);
            }
            return sbReturn.ToString();
        }
        
        public static string ToUri(this string text)
        {
            var rgx = new Regex("[^a-zA-Z0-9 -]");
            text = text.RemoveAccents();
            text = rgx.Replace(text, "");
            text = text.Trim();
            text = text.Replace(' ', '-');
            text = text.ToLower();
            return text;
        }
    }
}