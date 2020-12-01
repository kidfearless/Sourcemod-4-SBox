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

public const int LANG_SERVER 0      /**< Translate using the server's language */

/**
 * Loads a translation file for the plugin calling this native.
 * If no extension is specified, .txt is assumed.
 *
 * @param file          Translation file.
 */
public static void LoadTranslations(string file) { throw new NotImplementedException(); }

/**
 * Sets the global language target.  This is useful for creating functions
 * that will be compatible with the %t format specifier.  Note that invalid
 * indexes can be specified but the error will occur during translation,
 * not during this function call.
 *
 * @param client        Client index or LANG_SERVER.
 */
public static void SetGlobalTransTarget(int client) { throw new NotImplementedException(); }

/**
 * Retrieves the language number of a client.
 *
 * @param client        Client index.
 * @return              Language number client is using.
 * @error               Invalid client index or client not connected.
 */
public static int GetClientLanguage(int client) { throw new NotImplementedException(); }

/**
 * Retrieves the server's language.
 *
 * @return              Language number server is using.
 */
public static int GetServerLanguage() { throw new NotImplementedException(); }

/**
 * Returns the number of languages known in languages.cfg.
 *
 * @return              Language count.
 */
public static int GetLanguageCount() { throw new NotImplementedException(); }

/**
 * Retrieves info about a given language number.
 *
 * @param language      Language number.
 * @param code          Language code buffer (2-3 characters usually).
 * @param codeLen       Maximum length of the language code buffer.
 * @param name          Language name buffer.
 * @param nameLen       Maximum length of the language name buffer.
 * @error               Invalid language number.
 */
public static void GetLanguageInfo(int language, string code="", int codeLen=0, string name="", int nameLen=0) { throw new NotImplementedException(); }

/**
 * Sets the language number of a client.
 *
 * @param client        Client index.
 * @param language      Language number.
 * @error               Invalid client index or client not connected.
 */
public static void SetClientLanguage(int client, int language) { throw new NotImplementedException(); }

/**
 * Retrieves the language number from a language code.
 *
 * @param code          Language code (2-3 characters usually).
 * @return              Language number. -1 if not found.
 */
public static int GetLanguageByCode(string code) { throw new NotImplementedException(); }

/**
 * Retrieves the language number from a language name.
 *
 * @param name          Language name (case insensitive).
 * @return              Language number. -1 if not found.
 */
public static int GetLanguageByName(string name) { throw new NotImplementedException(); }

/**
 * Determines if the specified phrase exists within the plugin's
 * translation cache.
 *
 * @param phrase        Phrase to look for.
 * @return              True if phrase exists.
 */
public static bool TranslationPhraseExists(string phrase) { throw new NotImplementedException(); }

/**
 * Determines if there is a translation for the specified language.
 *
 * @param phrase        Phrase to check.
 * @param language      Language number.
 * @return              True if translation exists.
 */
public static bool IsTranslatedForLanguage(string phrase, int language) { throw new NotImplementedException(); }
	}
}