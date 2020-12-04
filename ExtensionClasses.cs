using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sourcemod
{
	public static class StringExtensions
	{
		public static string SubStr(this string input, int startIndex, int maxLength)
		{
			maxLength = Math.Min(maxLength, input.Length);
			return input.Substring(startIndex, maxLength);
		}
	}
}
