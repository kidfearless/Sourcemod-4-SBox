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
		 * Returns plugin handle from plugin filename.
		 *
		 * @param filename      Filename of the plugin to search for.
		 * @return              Handle to plugin if found, INVALID_HANDLE otherwise.
		 */
		public static Handle FindPluginByFile(string filename)
		{
			string buffer;

			Handle iter = GetPluginIterator();
			Handle pl;

			while (MorePlugins(iter))
			{
				pl = ReadPlugin(iter);

				GetPluginFilename(pl, out buffer, buffer.Length);
				if (strcmp(buffer, filename, false) == 0)
				{
					CloseHandle(iter);
					return pl;
				}
			}

			CloseHandle(iter);

			return INVALID_HANDLE;
		}


		/**
		 * Wraps ProcessTargetString() and handles producing error messages for
		 * bad targets.
		 *
		 * Note that you should use LoadTranslations("common.phrases") in OnPluginStart(). 
		 * "common.phrases" contains all of the translatable phrases that FindTarget() will
		 * reply with in the event a target is not found (error).
		 *
		 * @param client        Client who issued command
		 * @param target        Client's target argument
		 * @param nobots        Optional. Set to true if bots should NOT be targetted
		 * @param immunity      Optional. Set to false to ignore target immunity.
		 * @return              Index of target client, or -1 on error.
		 */
		public static int FindTarget(int client, string target, bool nobots = false, bool immunity = true)
		{
			string target_name;
			int[/* 1 */] target_list;
			int target_count;
			bool tn_is_ml;

			int flags = COMMAND_FILTER_NO_MULTI;
			if (nobots)
			{
				flags |= COMMAND_FILTER_NO_BOTS;
			}

			if (!immunity)
			{
				flags |= COMMAND_FILTER_NO_IMMUNITY;
			}

			if ((target_count = ProcessTargetString(
					target,
					client,
					out target_list,
					1,
					flags,
					out target_name,
					256,
					out tn_is_ml)) > 0)
			{
				return target_list[0];
			}

			ReplyToTargetError(client, target_count);
			return -1;
		}
	}
}
