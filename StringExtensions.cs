using System.Text.RegularExpressions;

namespace git.links
{
    public static class StringExtensions
    {
        public static string Sanitize(this string str)
        {
            return Regex.Replace(str, @"[\s\\/$#%&]", "-");
        }
    }
}