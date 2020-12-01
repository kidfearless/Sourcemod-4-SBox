/**
 * vim: set ts=4 :
 * =============================================================================
 * SourceMod (C)2004-2011 AlliedModders LLC.  All rights reserved.
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
 * Cookie access types for client viewing
 */
enum CookieAccess
{
	CookieAccess_Public,            /**< Visible and Changeable by users */
	CookieAccess_Protected,         /**< Read only to users */
	CookieAccess_Private            /**< Completely hidden cookie */
};

/**
 * Cookie Prefab menu types
 */
enum CookieMenu
{
	CookieMenu_YesNo,           /**< Yes/No menu with "yes"/"no" results saved into the cookie */
	CookieMenu_YesNo_Int,       /**< Yes/No menu with 1/0 saved into the cookie */
	CookieMenu_OnOff,           /**< On/Off menu with "on"/"off" results saved into the cookie */
	CookieMenu_OnOff_Int        /**< On/Off menu with 1/0 saved into the cookie */
};

enum CookieMenuAction
{
	/**
	 * An option is being drawn for a menu.
	 *
	 * INPUT : Client index and data if available.
	 * OUTPUT: Buffer for rendering, maxlength of buffer.
	 */
	CookieMenuAction_DisplayOption = 0,
	
	/**
	 * A menu option has been selected.
	 *
	 * INPUT : Client index and any data if available.
	 */
	CookieMenuAction_SelectOption = 1
};

/**
 * Cookie Menu Callback prototype
 *
 * @param client        Client index.
 * @param action        CookieMenuAction being performed.
 * @param info          Info data passed.
 * @param buffer        Outbut buffer.
 * @param maxlen        Max length of the output buffer.
 */
typedef CookieMenuHandler = function void (
  int client,
  CookieMenuAction action,
  any info,
  string buffer,
  int maxlen
) { throw new NotImplementedException(); }

/**
 * Note:
 * 
 * A successful return value/result on any client prefs public static only guarantees that the local cache has been updated.
 * Database connection problems can still prevent the data from being permanently saved. Connection problems will be logged as
 * errors by the clientprefs extension.
 */

public class Cookie : Handle {
	// Creates a new Client preference cookie.
	//
	// Handles returned can be closed via CloseHandle() when
	// no longer needed.
	//
	// @param name          Name of the new preference cookie.
	// @param description   Optional description of the preference cookie.
	// @param access        What CookieAccess level to assign to this cookie.
	// @return              A handle to the newly created cookie. If the cookie already
	//                      exists, a handle to it will still be returned.
	// @error               Cookie name is blank.
	public Cookie(string name, string description, CookieAccess access) { throw new NotImplementedException(); }

	// Searches for a Client preference cookie.
	//
	// Handles returned by Cookie.Find can be closed via CloseHandle() when
	// no longer needed.
	//
	// @param name          Name of cookie to find.
	// @return              A handle to the cookie if it is found, null otherwise.

	public static public static Cookie Find(string name) { throw new NotImplementedException(); }

	// Set the value of a Client preference cookie.
	//
	// @param client        Client index.
	// @param value         String value to set.
	// @error               Invalid cookie handle or invalid client index.
	public void Set(int client, string value) { throw new NotImplementedException(); }

	// Retrieve the value of a Client preference cookie.
	//
	// @param client        Client index.
	// @param buffer        Copyback buffer for value.
	// @param maxlen        Maximum length of the buffer.
	// @error               Invalid cookie handle or invalid client index.
	public void Get(int client, string buffer, int maxlen) { throw new NotImplementedException(); }

	// Sets the value of a Client preference cookie based on an authID string.
	//
	// @param authID        String Auth/STEAM ID of player to set.
	// @param value         String value to set.
	// @error               Invalid cookie handle.
	public void SetByAuthId(string authID, string value) { throw new NotImplementedException(); }

	// Add a new prefab item to the client cookie settings menu.
	//
	// Note: This handles everything automatically and does not require a callback
	//
	// @param type          A CookieMenu prefab menu type.
	// @param display       Text to show on the menu.
	// @param handler       Optional handler callback for translations and output on selection
	// @param info          Info data to pass to the callback.
	// @error               Invalid cookie handle.
	public void SetPrefabMenu(CookieMenu type, string display, CookieMenuHandler handler=INVALID_FUNCTION, any info=0) { throw new NotImplementedException(); }

	// Returns the last updated timestamp for a client cookie
	//
	// @param client        Client index.
	// @return              Last updated timestamp.
	public int GetClientTime(int client) { throw new NotImplementedException(); }

	// Returns the access level of a cookie
	//
	// @return              CookieAccess access level.
	// @error               Invalid cookie handle.
	public CookieAccess AccessLevel {
		get { throw new NotImplementedException(); }
	}
};

/**
 * Creates a new Client preference cookie.
 *
 * Handles returned by RegClientCookie can be closed via CloseHandle() when
 * no longer needed.
 *
 * @param name          Name of the new preference cookie.
 * @param description   Optional description of the preference cookie.
 * @param access        What CookieAccess level to assign to this cookie.
 * @return              A handle to the newly created cookie. If the cookie already
 *                      exists, a handle to it will still be returned.
 * @error               Cookie name is blank.
 */
public static Cookie RegClientCookie(string name, string description, CookieAccess access) { throw new NotImplementedException(); }

/**
 * Searches for a Client preference cookie.
 *
 * Handles returned by FindClientCookie can be closed via CloseHandle() when
 * no longer needed.
 *
 * @param name          Name of cookie to find.
 * @return              A handle to the cookie if it is found, null otherwise.

 */
public static Cookie FindClientCookie(string name) { throw new NotImplementedException(); }

/**
 * Set the value of a Client preference cookie.
 *
 * @param client        Client index.
 * @param cookie        Client preference cookie handle.
 * @param value         String value to set.
 * @error               Invalid cookie handle or invalid client index.
 */
public static void SetClientCookie(int client, Handle cookie, string value) { throw new NotImplementedException(); }

/**
 * Retrieve the value of a Client preference cookie.
 *
 * @param client        Client index.
 * @param cookie        Client preference cookie handle.
 * @param buffer        Copyback buffer for value.
 * @param maxlen        Maximum length of the buffer.
 * @error               Invalid cookie handle or invalid client index.
 */
public static void GetClientCookie(int client, Handle cookie, string buffer, int maxlen) { throw new NotImplementedException(); }

/**
 * Sets the value of a Client preference cookie based on an authID string.
 *
 * @param authID        String Auth/STEAM ID of player to set.
 * @param cookie        Client preference cookie handle.
 * @param value         String value to set.
 * @error               Invalid cookie handle.
 */
public static void SetAuthIdCookie(string authID, Handle cookie, string value) { throw new NotImplementedException(); }

/**
 * Checks if a clients cookies have been loaded from the database.
 *
 * @param client        Client index.
 * @return              True if loaded, false otherwise.
 * @error               Invalid client index.
 */
public static bool AreClientCookiesCached(int client) { throw new NotImplementedException(); }

/**
 * Called once a client's saved cookies have been loaded from the database.
 *
 * @param client        Client index.
 */
public static override void OnClientCookiesCached(int client) { throw new NotImplementedException(); }

/**
 * Add a new prefab item to the client cookie settings menu.
 *
 * Note: This handles everything automatically and does not require a callback
 *
 * @param cookie        Client preference cookie handle.
 * @param type          A CookieMenu prefab menu type.
 * @param display       Text to show on the menu.
 * @param handler       Optional handler callback for translations and output on selection
 * @param info          Info data to pass to the callback.
 * @error               Invalid cookie handle.
 */
public static void SetCookiePrefabMenu(Handle cookie, CookieMenu type, string display, CookieMenuHandler handler=INVALID_FUNCTION, any info=0) { throw new NotImplementedException(); }

/**
 * Adds a new item to the client cookie settings menu.
 *
 * Note: This only adds the top level menu item. You need to handle any submenus from the callback.
 *
 * @param handler       A MenuHandler callback function.
 * @param info          Data to pass to the callback.
 * @param display       Text to show on the menu.
 * @error               Invalid cookie handle.
 */
public static void SetCookieMenuItem(CookieMenuHandler handler, any info, string display) { throw new NotImplementedException(); }

/**
 * Displays the settings menu to a client.
 *
 * @param client        Client index.
 */
public static void ShowCookieMenu(int client) { throw new NotImplementedException(); }

/**
 * Gets a cookie iterator.  Must be freed with CloseHandle().
 *
 * @return              A new cookie iterator.
 */
public static Handle GetCookieIterator() { throw new NotImplementedException(); }

/**
 * Reads a cookie iterator, then advances to the next cookie if any.
 *
 * @param iter          Cookie iterator Handle.
 * @param name          Name buffer.
 * @param nameLen       Name buffer size.
 * @param access        Access level of the cookie.
 * @param desc          Cookie description buffer.
 * @param descLen       Cookie description buffer size.
 * @return              True on success, false if there are no more commands.
 */
public static bool ReadCookieIterator(Handle iter, 
								string name, 
								int nameLen,
								CookieAccess &access, 
								string desc="", 
								int descLen=0) { throw new NotImplementedException(); }

/**
 * Returns the access level of a cookie
 *
 * @param cookie        Client preference cookie handle.
 * @return              CookieAccess access level.
 * @error               Invalid cookie handle.
 */
public static CookieAccess GetCookieAccess(Handle cookie) { throw new NotImplementedException(); }

/**
 * Returns the last updated timestamp for a client cookie
 *
 * @param client        Client index.
 * @param cookie        Cookie handle.
 * @return              Last updated timestamp.
 */
public static int GetClientCookieTime(int client, Handle cookie) { throw new NotImplementedException(); }

/**
 * Do not edit below this line!
 */
public Extension __ext_cprefs = 
{
	name = "Client Preferences",
	file = "clientprefs.ext",
	autoload = 1,
#if defined REQUIRE_EXTENSIONS
	required = 1,
#else
	required = 0,
#endif
};

#if !defined REQUIRE_EXTENSIONS
public void __ext_cprefs_SetNTVOptional()
{
	MarkNativeAsOptional("RegClientCookie") { throw new NotImplementedException(); }
	MarkNativeAsOptional("FindClientCookie") { throw new NotImplementedException(); }
	MarkNativeAsOptional("SetClientCookie") { throw new NotImplementedException(); }
	MarkNativeAsOptional("GetClientCookie") { throw new NotImplementedException(); }
	MarkNativeAsOptional("SetAuthIdCookie") { throw new NotImplementedException(); }
	MarkNativeAsOptional("AreClientCookiesCached") { throw new NotImplementedException(); }
	MarkNativeAsOptional("SetCookiePrefabMenu") { throw new NotImplementedException(); }
	MarkNativeAsOptional("SetCookieMenuItem") { throw new NotImplementedException(); }
	MarkNativeAsOptional("ShowCookieMenu") { throw new NotImplementedException(); }
	MarkNativeAsOptional("GetCookieIterator") { throw new NotImplementedException(); }
	MarkNativeAsOptional("ReadCookieIterator") { throw new NotImplementedException(); }
	MarkNativeAsOptional("GetCookieAccess") { throw new NotImplementedException(); }
	MarkNativeAsOptional("GetClientCookieTime") { throw new NotImplementedException(); }

	MarkNativeAsOptional("Cookie.Cookie") { throw new NotImplementedException(); }
	MarkNativeAsOptional("Cookie.Find") { throw new NotImplementedException(); }
	MarkNativeAsOptional("Cookie.Set") { throw new NotImplementedException(); }
	MarkNativeAsOptional("Cookie.Get") { throw new NotImplementedException(); }
	MarkNativeAsOptional("Cookie.SetByAuthId") { throw new NotImplementedException(); }
	MarkNativeAsOptional("Cookie.SetPrefabMenu") { throw new NotImplementedException(); }
	MarkNativeAsOptional("Cookie.GetClientTime") { throw new NotImplementedException(); }
	MarkNativeAsOptional("Cookie.AccessLevel.get") { throw new NotImplementedException(); }
}
#endif
	}
}