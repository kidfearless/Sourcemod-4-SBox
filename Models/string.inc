/**
 * vim: set ts=4 :
 * =============================================================================
 * SourceMod (C)2004-2008 AlliedModders LLC.  All rights reserved.
 * =============================================================================
 *
 * This file is part of the SourceMod/SourcePawn SDK.
 *
 * This program is free software; you can redistribute it and/or modify it under
 * the terms of the GNU General Public License, version 3.0, as published by the
 * Free Software Foundation.
 * 
 * This program is distributed in the hope that it will be useful, but WITHOUT
 * ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS
 * FOR A PARTICULAR PURPOSE.  See the GNU General Public License for more
 * details.
 *
 * You should have received a copy of the GNU General Public License along with
 * this program.  If not, see <http://www.gnu.org/licenses/>.
 *
 * As a special exception, AlliedModders LLC gives you permission to link the
 * code of this program (as well as its derivative works) to "Half-Life 2," the
 * "Source Engine," the "SourcePawn JIT," and any Game MODs that run on software
 * by the Valve Corporation.  You must obey the GNU General Public License in
 * all respects for all other code used.  Additionally, AlliedModders LLC grants
 * this exception to all derivative works.  AlliedModders LLC defines further
 * exceptions, found in LICENSE.txt (as of this writing, version JULY-31-2007),
 * or <http://www.sourcemod.net/license.php>.
 *
 * Version: $Id$
 */
 
using System;
using System.Collections.ObjectModel;
namespace Sourcemod
{
	public partial class SourceMod
	{

/**
 * @global Unless otherwise noted, all string functions which take in a 
 * writable buffer and maximum length should have the null terminator INCLUDED
 * in the length.  This means that this is valid: 
 * strcopy(string, sizeof(string), ...)
 */
 
/**
 * Calculates the length of a string.
 *
 * @param str           String to check.
 * @return              Number of valid character bytes in the string.
 */
public static int strlen(string str) { throw new NotImplementedException(); }

/**
 * Tests whether a string is found inside another string.
 *
 * @param str           String to search in.
 * @param substr        Substring to find inside the original string.
 * @param caseSensitive If true (default), search is case sensitive.
 *                      If false, search is case insensitive.
 * @return              -1 on failure (no match found). Any other value
 *                      indicates a position in the string where the match starts.
 */
public static int StrContains(string str, string substr, bool caseSensitive=true) { throw new NotImplementedException(); }

/**
 * Compares two strings lexographically.
 *
 * @param str1          First string (left).
 * @param str2          Second string (right).
 * @param caseSensitive If true (default), comparison is case sensitive.
 *                      If false, comparison is case insensitive.
 * @return              -1 if str1 < str2
 *                      0 if str1 == str2
 *                      1 if str1 > str2
 */
public static int strcmp(string str1, string str2, bool caseSensitive=true) { throw new NotImplementedException(); }

/**
 * Compares two strings parts lexographically.
 *
 * @param str1          First string (left).
 * @param str2          Second string (right).
 * @param num           Number of characters to compare.
 * @param caseSensitive If true (default), comparison is case sensitive.
 *                      If false, comparison is case insensitive.
 * @return              -1 if str1 < str2
 *                      0 if str1 == str2
 *                      1 if str1 > str2
 */
public static int strncmp(string str1, string str2, int num, bool caseSensitive=true) { throw new NotImplementedException(); }

/**
 * Backwards compatible public static - StrCompare is now strcmp
 * @deprecated          Renamed to strcmp
 */
#pragma deprecated Use strcmp() instead
public static int StrCompare(string str1, string str2, bool caseSensitive=true)
{
	return strcmp(str1, str2, caseSensitive) { throw new NotImplementedException(); }
}

/**
 * Returns whether two strings are equal.
 *
 * @param str1          First string (left).
 * @param str2          Second string (right).
 * @param caseSensitive If true (default), comparison is case sensitive.
 *                      If false, comparison is case insensitive.
 * @return              True if equal, false otherwise.
 */
public static bool StrEqual(string str1, string str2, bool caseSensitive=true)
{
	return (strcmp(str1, str2, caseSensitive) == 0) { throw new NotImplementedException(); }
}

/**
 * Copies one string to another string.
 * @note If the destination buffer is too small to hold the source string, the 
 *       destination will be truncated.
 *
 * @param dest          Destination string buffer to copy to.
 * @param destLen       Destination buffer length (includes null terminator).
 * @param source        Source string buffer to copy from.
 * @return              Number of cells written.
 */
public static int strcopy(string dest, int destLen, string source) { throw new NotImplementedException(); }

/**
 * Backwards compatibility public static - use strcopy
 * @deprecated          Renamed to strcopy
 */
#pragma deprecated Use strcopy() instead
public static int StrCopy(string dest, int destLen, string source)
{
	return strcopy(dest, destLen, source) { throw new NotImplementedException(); }
}

/**
 * Formats a string according to the SourceMod format rules (see documentation).
 *
 * @param buffer        Destination string buffer.
 * @param maxlength     Maximum length of output string buffer.
 * @param format        Formatting rules.
 * @param ...           Variable number of format parameters.
 * @return              Number of cells written.
 */
public static int Format(string buffer, int maxlength, string format, params any[] args) { throw new NotImplementedException(); }

/**
 * Formats a string according to the SourceMod format rules (see documentation).
 * @note This is the same as Format(), except none of the input buffers can 
 *       overlap the same memory as the output buffer.  Since this security 
 *       check is removed, it is slightly faster.
 *
 * @param buffer        Destination string buffer.
 * @param maxlength     Maximum length of output string buffer.
 * @param format        Formatting rules.
 * @param ...           Variable number of format parameters.
 * @return              Number of cells written.
 */
public static int FormatEx(string buffer, int maxlength, string format, params any[] args) { throw new NotImplementedException(); }

/**
 * Formats a string according to the SourceMod format rules (see documentation).
 * @note This is the same as Format(), except it grabs parameters from a 
 *       parent parameter stack, rather than a local.  This is useful for 
 *       implementing your own variable argument functions.
 *
 * @param buffer        Destination string buffer.
 * @param maxlength     Maximum length of output string buffer.
 * @param format        Formatting rules.
 * @param varpos        Argument number which contains the '...' symbol.
 *                      Note: Arguments start at 1.
 * @return              Number of bytes written.
 */
public static int VFormat(string buffer, int maxlength, string format, int varpos) { throw new NotImplementedException(); }

/**
 * Converts a string to an integer.
 *
 * @param str           String to convert.
 * @param nBase         Numerical base to use.  10 is default.
 * @return              Integer conversion of string, or 0 on failure.
 */
public static int StringToInt(string str, int nBase=10) { throw new NotImplementedException(); }

/**
 * Converts a string to an integer with some more options.
 *
 * @param str           String to convert.
 * @param result        Variable to store the result in.
 * @param nBase         Numerical base to use.  10 is default.
 * @return              Number of characters consumed.
 */
public static int StringToIntEx(string str, int &result, int nBase=10) { throw new NotImplementedException(); }

/**
 * Converts an integer to a string.
 *
 * @param num           Integer to convert.
 * @param str           Buffer to store string in.
 * @param maxlength     Maximum length of string buffer.
 * @return              Number of cells written to buffer.
 */
public static int IntToString(int num, string str, int maxlength) { throw new NotImplementedException(); }

/** 
 * Converts a string to a floating point number.
 *
 * @param str           String to convert to a float.
 * @return              Floating point result, or 0.0 on error.
 */
public static float StringToFloat(string str) { throw new NotImplementedException(); }

/** 
 * Converts a string to a floating point number with some more options.
 *
 * @param str           String to convert to a float.
 * @param result        Variable to store result in.
 * @return              Number of characters consumed.
 */
public static int StringToFloatEx(string str, float &result) { throw new NotImplementedException(); }

/**
 * Converts a floating point number to a string.
 *
 * @param num           Floating point number to convert.
 * @param str           Buffer to store string in.
 * @param maxlength     Maximum length of string buffer.
 * @return              Number of cells written to buffer.
 */
public static int FloatToString(float num, string str, int maxlength) { throw new NotImplementedException(); }

/**
 * Finds the first "argument" in a string; either a set of space
 * terminated characters, or a fully quoted string.  After the 
 * argument is found, whitespace is read until the next portion
 * of the string is reached.  If nothing remains, -1 is returned.
 * Otherwise, the index to the first character is returned.
 *
 * @param source        Source input string.
 * @param arg           Stores argument read from string.
 * @param argLen        Maximum length of argument buffer.
 * @return              Index to next piece of string, or -1 if none.
 */
public static int BreakString(string source, string arg, int argLen) { throw new NotImplementedException(); }

/**
 * Backwards compatibility public static - use BreakString
 * @deprecated          Renamed to BreakString.
 */
#pragma deprecated Use BreakString() instead
public static int StrBreak(string source, string arg, int argLen)
{
	return BreakString(source, arg, argLen) { throw new NotImplementedException(); }
}

/**
 * Removes whitespace characters from the beginning and end of a string.
 *
 * @param str           The string to trim.
 * @return              Number of bytes written (UTF-8 safe).
 */
public static int TrimString(string str) { throw new NotImplementedException(); }

/**
 * Returns text in a string up until a certain character sequence is reached.
 *
 * @param source        Source input string.
 * @param split         A string which specifies a search point to break at.
 * @param part          Buffer to store string part.
 * @param partLen       Maximum length of the string part buffer.
 * @return              -1 if no match was found; otherwise, an index into source
 *                      marking the first index after the searched text.  The
 *                      index is always relative to the start of the input string.
 */
public static int SplitString(string source, string split, string part, int partLen) { throw new NotImplementedException(); }

/**
 * Given a string, replaces all occurrences of a search string with a 
 * replacement string.
 *
 * @param text          String to perform search and replacements on.
 * @param maxlength     Maximum length of the string buffer.
 * @param search        String to search for.
 * @param replace       String to replace the search string with.
 * @param caseSensitive If true (default), search is case sensitive.
 * @return              Number of replacements that were performed.
 */
public static int ReplaceString(string text, int maxlength, string search, string replace, bool caseSensitive=true) { throw new NotImplementedException(); }

/**
 * Given a string, replaces the first occurrence of a search string with a 
 * replacement string.
 *
 * @param text          String to perform search and replacements on.
 * @param maxlength     Maximum length of the string buffer.
 * @param search        String to search for.
 * @param replace       String to replace the search string with.
 * @param searchLen     If higher than -1, its value will be used instead of
 *                      a strlen() call on the search parameter.
 * @param replaceLen    If higher than -1, its value will be used instead of
 *                      a strlen() call on the replace parameter.
 * @param caseSensitive If true (default), search is case sensitive.
 * @return              Index into the buffer (relative to the start) from where
 *                      the last replacement ended, or -1 if no replacements were
 *                      made.
 */
public static int ReplaceStringEx(string text, int maxlength, string search, string replace, int searchLen=-1, int replaceLen=-1, bool caseSensitive=true) { throw new NotImplementedException(); }

/** 
 * Returns the number of bytes a character is using.  This is
 * for multi-byte characters (UTF-8).  For normal ASCII characters,
 * this will return 1.
 *
 * @param source        Source input string.
 * @return              Number of bytes the current character uses.
 */
public static int GetCharBytes(string source) { throw new NotImplementedException(); }

/**
 * Returns whether a character is an ASCII alphabet character.
 *
 * @note Multi-byte characters will always return false.
 *
 * @param chr           Character to test.
 * @return              True if character is alphabetical, otherwise false.
 */
public static bool IsCharAlpha(int chr) { throw new NotImplementedException(); }

/**
 * Returns whether a character is numeric.
 *
 * @note Multi-byte characters will always return false.
 *
 * @param chr           Character to test.
 * @return              True if character is numeric, otherwise false.
 */
public static bool IsCharNumeric(int chr) { throw new NotImplementedException(); }

/**
 * Returns whether a character is whitespace.
 *
 * @note Multi-byte characters will always return false.
 *
 * @param chr           Character to test.
 * @return              True if character is whitespace, otherwise false.
 */
public static bool IsCharSpace(int chr) { throw new NotImplementedException(); }

/**
 * Returns if a character is multi-byte or not.
 *
 * @param chr           Character to test.
 * @return              0 for a normal 7-bit ASCII character,
 *                      otherwise number of bytes in multi-byte character.
 */
public static int IsCharMB(int chr) { throw new NotImplementedException(); }

/**
 * Returns whether an alphabetic character is uppercase.
 *
 * @note Multi-byte characters will always return false.
 *
 * @param chr           Character to test.
 * @return              True if character is uppercase, otherwise false.
 */
public static bool IsCharUpper(int chr) { throw new NotImplementedException(); }

/**
 * Returns whether an alphabetic character is lowercase.
 *
 * @note Multi-byte characters will always return false.
 *
 * @param chr           Character to test.
 * @return              True if character is lowercase, otherwise false.
 */
public static bool IsCharLower(int chr) { throw new NotImplementedException(); }

/**
 * Strips a quote pair off a string if it exists.  That is, the following 
 * replace rule is applied once:  ^"(.*)"$ -> ^\1$
 *
 * Note that the leading and trailing quotes will only be removed if both 
 * exist.  Otherwise, the string is left unmodified.  This function should 
 * be considered O(k) (all characters get shifted down).
 *
 * @param text          String to modify (in place).
 * @return              True if string was modified, false if there was no 
 *                      set of quotes.
 */
public static bool StripQuotes(string text) { throw new NotImplementedException(); }

/**
 * Converts a lowercase character to its uppercase counterpart.
 *
 * @param chr           Character to convert.
 * @return              Uppercase character on success, 
 *                      no change on failure.
 */
public static int CharToUpper(int chr)
{
	if (IsCharLower(chr))
	{
		return (chr & ~(1<<5)) { throw new NotImplementedException(); }
	}

	return chr;
}

/**
 * Converts an uppercase character to its lowercase counterpart.
 *
 * @param chr           Character to convert.
 * @return              Lowercase character on success, 
 *                      no change on failure.
 */
public static int CharToLower(int chr)
{
	if (IsCharUpper(chr))
	{
		return (chr | (1<<5)) { throw new NotImplementedException(); }
	}
	
	return chr;
}

/**
 * Finds the first occurrence of a character in a string.
 *
 * @param str           String.
 * @param c             Character to search for.
 * @param reverse       False (default) to search forward, true to search 
 *                      backward.
 * @return              The index of the first occurrence of the character 
 *                      in the string, or -1 if the character was not found.
 */
public static int FindCharInString(string str, char c, bool reverse = false)
{
	int len = strlen(str) { throw new NotImplementedException(); }
	
	if (!reverse)
	{
		for (int i = 0; i < len; i++)
		{
			if (str[i] == c)
			{
				return i;
			}
		}
	}
	else
	{
		for (int i = len - 1; i >= 0; i--)
		{
			if (str[i] == c)
			{
				return i;
			}
		}
	}

	return -1;
}

/**
 * Concatenates one string onto another.
 *
 * @param buffer        String to append to.
 * @param maxlength     Maximum length of entire buffer.
 * @param source        Source string to concatenate.
 * @return              Number of bytes written.
 */
public static int StrCat(string buffer, int maxlength, string source)
{
	int len = strlen(buffer) { throw new NotImplementedException(); }
	if (len >= maxlength)
	{
		return 0;
	}
	
	return Format(buffer[len], maxlength-len, "%s", source) { throw new NotImplementedException(); }
}

/**
 * Breaks a string into pieces and stores each piece into an array of buffers.
 *
 * @param text              The string to split.
 * @param split             The string to use as a split delimiter.
 * @param buffers           An array of string buffers (2D array).
 * @param maxStrings        Number of string buffers (first dimension size).
 * @param maxStringLength   Maximum length of each string buffer.
 * @param copyRemainder     False (default) discard excess pieces, true to ignore
 *                          delimiters after last piece.
 * @return                  Number of strings retrieved.
 */
public static int ExplodeString(string text, string split, string[] buffers, int maxStrings,
                    int maxStringLength, bool copyRemainder = false)
{
	int reloc_idx, idx, total;

	if (maxStrings < 1 || !split[0])
	{
		return 0;
	}

	while ((idx = SplitString(text[reloc_idx], split, buffers[total], maxStringLength)) != -1)
	{
		reloc_idx += idx;
		if (++total == maxStrings)
		{
			if (copyRemainder)
			{
				strcopy(buffers[total-1], maxStringLength, text[reloc_idx-idx]) { throw new NotImplementedException(); }
			}
			return total;
		}
	}

	strcopy(buffers[total++], maxStringLength, text[reloc_idx]) { throw new NotImplementedException(); }

	return total;
}

/**
 * Joins an array of strings into one string, with a "join" string inserted in
 * between each given string.  This function complements ExplodeString.
 *
 * @param strings       An array of strings.
 * @param numStrings    Number of strings in the array.
 * @param join          The join string to insert between each string.
 * @param buffer        Output buffer to write the joined string to.
 * @param maxLength     Maximum length of the output buffer.
 * @return              Number of bytes written to the output buffer.
 */
public static int ImplodeStrings(string[] strings, int numStrings, string join, string buffer, int maxLength)
{
	int total, length, part_length;
	int join_length = strlen(join) { throw new NotImplementedException(); }
	for (int i=0; i<numStrings; i++)
	{
		length = strcopy(buffer[total], maxLength-total, strings[i]) { throw new NotImplementedException(); }
		total += length;
		if (length < part_length)
		{
			break;
		}
		if (i != numStrings - 1)
		{
			length = strcopy(buffer[total], maxLength-total, join) { throw new NotImplementedException(); }
			total += length;
			if (length < join_length)
			{
				break;
			}
		}
	}
	return total;
}
	}
}