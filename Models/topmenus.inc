/**
 * vim: set ts=4 sw=4 tw=99 noet:
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

#include <menus>

/**
 * Actions a top menu will take on an topobj.
 */
public enum TopMenuAction
{
	/**
	 * An option is being drawn for a menu (or for sorting purposes).
	 *
	 * INPUT : TopMenu Handle, topobj ID, client index.
	 * OUTPUT: Buffer for rendering, maxlength of buffer.
	 */
	TopMenuAction_DisplayOption = 0,

	/**
	 * The title of a menu is being drawn for a given topobj.
	 *
	 * Note: The Object ID will be INVALID_TOPMENUOBJECT if drawing the
	 * root title.  Otherwise, the Object ID is a category.
	 *
	 * INPUT : TopMenu Handle, topobj ID, client index.
	 * OUTPUT: Buffer for rendering, maxlength of buffer.
	 */
	TopMenuAction_DisplayTitle = 1,

	/**
	 * A menu option has been selected.
	 *
	 * The Object ID will always be an item (not a category).
	 *
	 * INPUT : TopMenu Handle, topobj ID, client index.
	 */
	TopMenuAction_SelectOption = 2,

	/**
	 * A menu option is being drawn and its flags can be overridden.
	 *
	 * INPUT : TopMenu Handle, topobj ID, client index.
	 * OUTPUT: The first byte of the 'buffer' string should be set
	 *                      to the desired flags.  By default, it will contain
	 *                      ITEMDRAW_DEFAULT.
	 */
	 TopMenuAction_DrawOption = 3,

	/**
	 * Called when an topobj is being removed from the menu.
	 * This can be used to clean up data stored in the info string.
	 *
	 * INPUT : TopMenu Handle, topobj ID.
	 */
	 TopMenuAction_RemoveObject = 4
};

/**
 * Top menu topobj types.
 */
public enum TopMenuObjectType
{
	TopMenuObject_Category = 0,         /**< Category (sub-menu branching from root) */
	TopMenuObject_Item = 1              /**< Item on a sub-menu */
};

/**
 * Top menu starting positions for display.
 */
public enum TopMenuPosition
{
	TopMenuPosition_Start = 0,          /**< Start/root of the menu */
	TopMenuPosition_LastRoot = 1,       /**< Last position in the root menu */
	TopMenuPosition_LastCategory = 3    /**< Last position in their last category */
};

/**
 * Top menu topobj tag for type checking.
 */
public enum TopMenuObject
{
	INVALID_TOPMENUOBJECT = 0
};

/**
 * TopMenu callback prototype.
 *
 * @param topmenu       Handle to the TopMenu.
 * @param action        TopMenuAction being performed.
 * @param topobj_id     The topobj ID (if used).
 * @param param         Extra parameter (if used).
 * @param buffer        Output buffer (if used).
 * @param maxlength     Output buffer (if used).
 */
typedef TopMenuHandler = function void (
  TopMenu topmenu,
  TopMenuAction action,
  TopMenuObject topobj_id,
  int param,
  string buffer,
  int maxlength
) { throw new NotImplementedException(); }

// TopMenu objects are used for constructing multi-layer menus. Currently, they
// support at most two levels. The first level of items are called "categories".
public class TopMenu : Handle
{
	// Creates a new TopMenu.
	//
	// @param handler       Handler to use for drawing the root title.
	// @return              A new TopMenu.
	public TopMenu(TopMenuHandler handler) { throw new NotImplementedException(); }

	// Returns a TopMenu handle from a generic handle. If the given handle is
	// a TopMenu, the handle is simply casted back. Otherwise, an error is
	// raised.
	public static public static TopMenu FromHandle(Handle handle) { throw new NotImplementedException(); }

	// Re-sorts the items in a TopMenu via a configuration file.
	//
	// The format of the configuration file should be a Valve Key-Values
	// formatted file that SourceMod can parse.  There should be one root
	// section, and one sub-section for each category.  Each sub-section's
	// name should match the category name.
	//
	// Each sub-section may only contain key/value pairs in the form of:
	// key: "item"
	// value: Name of the item as passed to AddToTopMenu().
	//
	// The TopMenu will draw items in the order declared in the configuration
	// file.  If items do not appear in the configuration file, they are sorted
	// per-player based on how the handler function renders for that player.
	// These items appear after the configuration sorted items.
	//
	// @param topmenu      TopMenu Handle.
	// @param file         File path.
	// @param error        Error buffer.
	// @param maxlength    Maximum size of the error buffer. Error buffer
	//                     will be filled with a zero-terminated string if
	//                     false is returned.
	// @return              True on success, false on failure.
	public bool LoadConfig(string file, string error, int maxlength) { throw new NotImplementedException(); }

	// Adds a category to a TopMenu.
	//
	// @param name         Object name (MUST be unique).
	// @param handler      Handler for topobj.
	// @param cmdname      Command name (for access overrides).
	// @param flags        Default access flags.
	// @param info_string  Arbitrary storage (max 255 bytes).
	// @return              A new TopMenuObject ID, or INVALID_TOPMENUOBJECT on failure.
	public TopMenuObject AddCategory(string name, TopMenuHandler handler,
	                                        string cmdname = "", int flags = 0,
	                                        string info_string = "") { throw new NotImplementedException(); }

	// Adds an item to a TopMenu category.
	//
	// @param name         Object name (MUST be unique).
	// @param handler      Handler for topobj.
	// @param category     The object of the parent category for the item.
	// @param cmdname      Command name (for access overrides).
	// @param flags        Default access flags.
	// @param info_string  Arbitrary storage (max 255 bytes).
	// @return              A new TopMenuObject ID, or INVALID_TOPMENUOBJECT on failure.
	public TopMenuObject AddItem(string name, TopMenuHandler handler,
	                                    TopMenuObject parent, string cmdname = "",
	                                    int flags = 0, string info_string = "") { throw new NotImplementedException(); }

	// Retrieves the info string of a top menu item.
	//
	// @param parent       TopMenuObject ID.
	// @param buffer       Buffer to store info string.
	// @param maxlength    Maximum size of info string.
	// @return              Number of bytes written, not including the  null terminator.
	public int GetInfoString(TopMenuObject parent, string buffer, int maxlength) { throw new NotImplementedException(); }

	// Retrieves the name string of a top menu item.
	//
	// @param topobj       TopMenuObject ID.
	// @param buffer       Buffer to store info string.
	// @param maxlength    Maximum size of info string.
	// @return              Number of bytes written, not including the null terminator.
	public int GetObjName(TopMenuObject topobj, string buffer, int maxlength) { throw new NotImplementedException(); }

	// Removes an topobj from a TopMenu.
	//
	// Plugins' topobjs are automatically removed all TopMenus when the given
	// plugin unloads or pauses.  In the case of unpausing, all items are restored.
	//
	// @param topobj       TopMenuObject ID.
	public void Remove(TopMenuObject topobj) { throw new NotImplementedException(); }

	// Displays a TopMenu to a client.
	//
	// @param client       Client index.
	// @param position     Position to display from.
	// @return              True on success, false on failure.
	public bool Display(int client, TopMenuPosition position) { throw new NotImplementedException(); }

	// Displays a TopMenu category to a client.
	//
	// @param category     Category topobj id.
	// @param client       Client index.
	// @return              True on success, false on failure.
	public bool DisplayCategory(TopMenuObject category, int client) { throw new NotImplementedException(); }

	// Finds a category's topobj ID in a TopMenu.
	//
	// @param name         Object's unique name.
	// @return              TopMenuObject ID on success, or
	//                     INVALID_TOPMENUOBJECT on failure.
	public TopMenuObject FindCategory(string name) { throw new NotImplementedException(); }

	// Set the menu title caching behavior of the TopMenu. By default titles
	// are cached to reduce overhead. If you need dynamic menu titles which
	// change each time the menu is displayed to a user, set this to false.
	public bool CacheTitles {
		public set(bool value) { throw new NotImplementedException(); }
	}
};

/**
 * Creates a TopMenu.
 *
 * @param handler       Handler to use for drawing the root title.
 * @return              A new TopMenu Handle, or INVALID_HANDLE on failure.
 */
public static TopMenu CreateTopMenu(TopMenuHandler handler) { throw new NotImplementedException(); }

/**
 * Re-sorts the items in a TopMenu via a configuration file.
 *
 * The format of the configuration file should be a Valve Key-Values
 * formatted file that SourceMod can parse.  There should be one root
 * section, and one sub-section for each category.  Each sub-section's
 * name should match the category name.
 *
 * Each sub-section may only contain key/value pairs in the form of:
 * key: "item"
 * value: Name of the item as passed to AddToTopMenu().
 *
 * The TopMenu will draw items in the order declared in the configuration
 * file.  If items do not appear in the configuration file, they are sorted
 * per-player based on how the handler function renders for that player.
 * These items appear after the configuration sorted items.
 *
 * @param topmenu       TopMenu Handle.
 * @param file          File path.
 * @param error         Error buffer.
 * @param maxlength     Maximum size of the error buffer.
 *                      Error buffer will be filled with a
 *                      zero-terminated string if false is
 *                      returned.
 * @return              True on success, false on failure.
 * @error               Invalid TopMenu Handle.
 */
public static bool LoadTopMenuConfig(Handle topmenu, string file, string error, int maxlength) { throw new NotImplementedException(); }

/**
 * Adds an topobj to a TopMenu.
 *
 * @param topmenu       TopMenu Handle.
 * @param name          Object name (MUST be unique).
 * @param type          Object type.
 * @param handler       Handler for topobj.
 * @param parent        Parent topobj ID, or INVALID_TOPMENUOBJECT for none.
 *                      Items must have a category parent.
 *                      Categories must not have a parent.
 * @param cmdname       Command name (for access overrides).
 * @param flags         Default access flags.
 * @param info_string   Arbitrary storage (max 255 bytes).
 * @return              A new TopMenuObject ID, or INVALID_TOPMENUOBJECT on
 *                      failure.
 * @error               Invalid TopMenu Handle.
 */
public static TopMenuObject AddToTopMenu(Handle topmenu,
								  string name,
								  TopMenuObjectType type,
								  TopMenuHandler handler,
								  TopMenuObject parent,
								  string cmdname="",
								  int flags=0,
								  string info_string="") { throw new NotImplementedException(); }

/**
 * Retrieves the info string of a top menu item.
 *
 * @param topmenu       TopMenu Handle.
 * @param parent        TopMenuObject ID.
 * @param buffer        Buffer to store info string.
 * @param maxlength     Maximum size of info string.
 * @return              Number of bytes written, not including the
 *                      null terminator.
 * @error               Invalid TopMenu Handle or TopMenuObject ID.
 */
public static int GetTopMenuInfoString(Handle topmenu, TopMenuObject parent, string buffer, int maxlength) { throw new NotImplementedException(); }

/**
 * Retrieves the name string of a top menu item.
 *
 * @param topmenu       TopMenu Handle.
 * @param topobj        TopMenuObject ID.
 * @param buffer        Buffer to store info string.
 * @param maxlength     Maximum size of info string.
 * @return              Number of bytes written, not including the
 *                      null terminator.
 * @error               Invalid TopMenu Handle or TopMenuObject ID.
 */
public static int GetTopMenuObjName(Handle topmenu, TopMenuObject topobj, string buffer, int maxlength) { throw new NotImplementedException(); }

/**
 * Removes an topobj from a TopMenu.
 *
 * Plugins' topobjs are automatically removed all TopMenus when the given
 * plugin unloads or pauses.  In the case of unpausing, all items are restored.
 *
 * @param topmenu       TopMenu Handle.
 * @param topobj        TopMenuObject ID.
 * @error               Invalid TopMenu Handle.
 */
public static void RemoveFromTopMenu(Handle topmenu, TopMenuObject topobj) { throw new NotImplementedException(); }

/**
 * Displays a TopMenu to a client.
 *
 * @param topmenu       TopMenu Handle.
 * @param client        Client index.
 * @param position      Position to display from.
 * @return              True on success, false on failure.
 * @error               Invalid TopMenu Handle or client not in game.
 */
public static bool DisplayTopMenu(Handle topmenu, int client, TopMenuPosition position) { throw new NotImplementedException(); }

/**
 * Displays a TopMenu category to a client.
 *
 * @param topmenu       TopMenu Handle.
 * @param category      Category topobj id.
 * @param client        Client index.
 * @return              True on success, false on failure.
 * @error               Invalid TopMenu Handle or client not in game.
 */
public static bool DisplayTopMenuCategory(Handle topmenu, TopMenuObject category, int client) { throw new NotImplementedException(); }

/**
 * Finds a category's topobj ID in a TopMenu.
 *
 * @param topmenu       TopMenu Handle.
 * @param name          Object's unique name.
 * @return              TopMenuObject ID on success, or
 *                      INVALID_TOPMENUOBJECT on failure.
 * @error               Invalid TopMenu Handle.
 */
public static TopMenuObject FindTopMenuCategory(Handle topmenu, string name) { throw new NotImplementedException(); }

/**
 * Change the menu title caching behavior of the TopMenu. By default the
 * titles are cached to reduce overhead. If you need dynamic menu titles, which
 * can change everytime the menu is displayed to a user, set this to false.
 *
 * @param topmenu       TopMenu Handle.
 * @param cache_titles  Cache the menu titles and don't call the handler with
 *                      TopMenuAction_DisplayTitle everytime the menu is drawn?
 * @error               Invalid TopMenu Handle
 */
public static void SetTopMenuTitleCaching(Handle topmenu, bool cache_titles) { throw new NotImplementedException(); }


/**
 * Do not edit below this line!
 */
public Extension __ext_topmenus =
{
	name = "TopMenus",
	file = "topmenus.ext",
#if defined AUTOLOAD_EXTENSIONS
	autoload = 1,
#else
	autoload = 0,
#endif
#if defined REQUIRE_EXTENSIONS
	required = 1,
#else
	required = 0,
#endif
};

#if !defined REQUIRE_EXTENSIONS
public void __ext_topmenus_SetNTVOptional()
{
	MarkNativeAsOptional("CreateTopMenu") { throw new NotImplementedException(); }
	MarkNativeAsOptional("LoadTopMenuConfig") { throw new NotImplementedException(); }
	MarkNativeAsOptional("AddToTopMenu") { throw new NotImplementedException(); }
	MarkNativeAsOptional("RemoveFromTopMenu") { throw new NotImplementedException(); }
	MarkNativeAsOptional("DisplayTopMenu") { throw new NotImplementedException(); }
	MarkNativeAsOptional("DisplayTopMenuCategory") { throw new NotImplementedException(); }
	MarkNativeAsOptional("FindTopMenuCategory") { throw new NotImplementedException(); }
	MarkNativeAsOptional("SetTopMenuTitleCaching") { throw new NotImplementedException(); }
	MarkNativeAsOptional("TopMenu.TopMenu") { throw new NotImplementedException(); }
	MarkNativeAsOptional("TopMenu.FromHandle") { throw new NotImplementedException(); }
	MarkNativeAsOptional("TopMenu.LoadConfig") { throw new NotImplementedException(); }
	MarkNativeAsOptional("TopMenu.AddCategory") { throw new NotImplementedException(); }
	MarkNativeAsOptional("TopMenu.AddItem") { throw new NotImplementedException(); }
	MarkNativeAsOptional("TopMenu.GetInfoString") { throw new NotImplementedException(); }
	MarkNativeAsOptional("TopMenu.GetObjName") { throw new NotImplementedException(); }
	MarkNativeAsOptional("TopMenu.Remove") { throw new NotImplementedException(); }
	MarkNativeAsOptional("TopMenu.Display") { throw new NotImplementedException(); }
	MarkNativeAsOptional("TopMenu.DisplayCategory") { throw new NotImplementedException(); }
	MarkNativeAsOptional("TopMenu.FindCategory") { throw new NotImplementedException(); }
	MarkNativeAsOptional("TopMenu.CacheTitles.set") { throw new NotImplementedException(); }
}
#endif
	}
}