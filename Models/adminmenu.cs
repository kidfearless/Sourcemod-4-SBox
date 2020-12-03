/**
 * vim: set ts=4 :
 * =============================================================================
 * SourceMod (C)2004-2008 AlliedModders LLC.  All rights reserved.
 * =============================================================================
 *
 * This file is part of the SourceMod/SourcePawn SDK.
 *
 * This program is free software; you can redistribute it and/or modify it under
 * the terms of the GNU General Public License, version 3.0f, as published by the
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


		/** Category for player commands. */
		public const string ADMINMENU_PLAYERCOMMANDS = "PlayerCommands";
		/** Category for server commands. */
		public const string ADMINMENU_SERVERCOMMANDS = "ServerCommands";
		/** Category for voting commands. */
		public const string ADMINMENU_VOTINGCOMMANDS = "VotingCommands";

		/**
		 * Called when the admin menu is created and 3rd party plugins can grab 
		 * the Handle or add categories.
		 * 
		 * @param topmenu       Handle to the admin menu's TopMenu.
		 */
		public virtual void OnAdminMenuCreated(Handle topmenu) { throw new NotImplementedException(); }

		/**
		 * Called when the admin menu is ready to have items added.
		 * 
		 * @param topmenu       Handle to the admin menu's TopMenu.
		 */
		public virtual void OnAdminMenuReady(Handle topmenu) { throw new NotImplementedException(); }

		/**
		 * Retrieves the Handle to the admin top menu.
		 *
		 * @return              Handle to the admin menu's TopMenu,
		 *                      or INVALID_HANDLE if not created yet.
		 */
		public static TopMenu GetAdminTopMenu() { throw new NotImplementedException(); }

		/**
		 * Adds targets to an admin menu.
		 *
		 * Each client is displayed as: name (userid)
		 * Each item contains the userid as a string for its info.
		 *
		 * @param menu          Menu Handle.
		 * @param source_client Source client, or 0 to ignore immunity.
		 * @param in_game_only  True to only select in-game players.
		 * @param alive_only    True to only select alive players.
		 * @return              Number of clients added.
		 */
		public static int AddTargetsToMenu(Handle menu,
									int source_client,
									bool in_game_only = true,
									bool alive_only = false)
		{ throw new NotImplementedException(); }

		/**
		 * Adds targets to an admin menu.
		 *
		 * Each client is displayed as: name (userid)
		 * Each item contains the userid as a string for its info.
		 *
		 * @param menu          Menu Handle.
		 * @param source_client Source client, or 0 to ignore immunity.
		 * @param flags         COMMAND_FILTER flags from commandfilters.inc.
		 * @return              Number of clients added.
		 */
		public static int AddTargetsToMenu2(Handle menu, int source_client, int flags) { throw new NotImplementedException(); }

		/**
		 * Re-displays the admin menu to a client after selecting an item.
		 * Auto-aborts if the Handle is invalid.
		 *
		 * @param topmenu       TopMenu Handle.
		 * @param client        Client index.
		 * @return              True on success, false on failure.
		 */
		public static bool RedisplayAdminMenu(Handle topmenu, int client)
		{
			if (topmenu == INVALID_HANDLE)
			{
				return false;
			}

			return DisplayTopMenu(topmenu, client, TopMenuPosition.TopMenuPosition_LastCategory);
		}

	}
}
