using System.Text.RegularExpressions;

namespace WorkPlace.Business.Helpers
{
    public static class Extension
	{
		public static bool isOnlyLetters(this string word)
		{
			return !Regex.IsMatch(word, @"^[a-zA-Z]+$");
        }
	}
}

