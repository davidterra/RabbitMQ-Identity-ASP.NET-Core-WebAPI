using System.Linq;

namespace Common.Core.Extensions
{
    public static class StringExtensions
    {
        public static string OnlyNumbers(this string str, string input) => new string(input.Where(char.IsDigit).ToArray());
    }
}
