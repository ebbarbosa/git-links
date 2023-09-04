using System.Text.RegularExpressions;

namespace git.links
{
    public static class StringExtensions
    {
        public static string Sanitize(this string str)
        {
            var cleanString = Regex.Replace(str, @"[\s\\/$#%&]", " ");

            cleanString = Regex.Replace(cleanString.TrimEnd().TrimStart(), @"\s+", "-");

            cleanString = Regex.Replace(cleanString, @"-+", "-");

            return cleanString;
        }
    }
}