/**
 * vim: set ts=4 :
 * =============================================================================
 * SourceMod (C)2004-2014 AlliedModders LLC.  All rights reserved.
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
		 * Sets SourceMod's internal nextmap.
		 * Equivalent to changing sm_nextmap but with an added validity check.
		 *
		 * @param map           Next map to set.
		 * @return              True if the nextmap was set, false if map was invalid.
		 */
		public static bool SetNextMap(string map) { throw new NotImplementedException(); }

		/**
		 * Returns SourceMod's internal nextmap.
		 *
		 * @param map           Buffer to store the nextmap name.
		 * @param maxlen        Maximum length of the map buffer.
		 * @return              True if a Map was found and copied, false if no nextmap is set (map will be unchanged).
		 */
		public static bool GetNextMap(string map, int maxlen) { throw new NotImplementedException(); }

		/**
		 * Changes the current map and records the reason for the change with maphistory
		 *
		 * @param map           Map to change to.
		 * @param reason        Reason for change.
		 */
		public static void ForceChangeLevel(string map, string reason) { throw new NotImplementedException(); }

		/**
		 * Gets the current number of maps in the map history
		 *
		 * @return              Number of maps.
		 */
		public static int GetMapHistorySize() { throw new NotImplementedException(); }

		/**
		 * Retrieves a map from the map history list.
		 *
		 * @param item          Item number. Must be 0 or greater and less than GetMapHistorySize().
		 * @param map           Buffer to store the map name.
		 * @param mapLen        Length of map buffer.
		 * @param reason        Buffer to store the change reason.
		 * @param reasonLen     Length of the reason buffer.
		 * @param startTime     Time the map started.
		 * @error               Invalid item number.
		 */
		public static void GetMapHistory(int item, string map, int mapLen, string reason, int reasonLen, ref int startTime) { throw new NotImplementedException(); }
	}
}
