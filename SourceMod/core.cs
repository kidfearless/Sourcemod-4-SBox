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

		/** If this gets changed, you need to update Core's check. */
		public const int SOURCEMOD_PLUGINAPI_VERSION = 5;

		public struct PlVers
		{
			public int version;
			public string filevers;
			public string date;
			public string time;
		};

		/**
		 * Specifies what to do after a hook completes.
		 */
		public enum Action
		{
			Plugin_Continue = 0,    /**< Continue with the original action */
			Plugin_Changed = 1,     /**< Inputs or outputs have been overridden with new values */
			Plugin_Handled = 3,     /**< Handle the action at the end (don't call it) */
			Plugin_Stop = 4         /**< Immediately stop the hook chain and handle the original */
		};
		public const int
			Plugin_Continue = 0,    /**< Continue with the original action */
			Plugin_Changed = 1,     /**< Inputs or outputs have been overridden with new values */
			Plugin_Handled = 3,     /**< Handle the action at the end (don't call it) */
			Plugin_Stop = 4;         /**< Immediately stop the hook chain and handle the original */

		/**
		 * Specifies identity types.
		 */
		public enum Identity
		{
			Identity_Core = 0,
			Identity_Extension = 1,
			Identity_Plugin = 2
		};
		public const int
			Identity_Core = 0,
			Identity_Extension = 1,
			Identity_Plugin = 2;

		protected PlVers __version = new PlVers()
		{
			version = SOURCEMOD_PLUGINAPI_VERSION,
			filevers = SOURCEMOD_VERSION,
			date = DateTime.Now.Date.ToString(),
			time = DateTime.Now.TimeOfDay.ToString()
		};

		/**
		 * Plugin status values.
		 */
		public enum PluginStatus
		{
			Plugin_Running = 0,       /**< Plugin is running */
			/* All states below are "temporarily" unexecutable */
			Plugin_Paused,          /**< Plugin is loaded but paused */
			Plugin_Error,           /**< Plugin is loaded but errored/locked */
			/* All states below do not have all natives */
			Plugin_Loaded,          /**< Plugin has passed loading and can be finalized */
			Plugin_Failed,          /**< Plugin has a fatal failure */
			Plugin_Created,         /**< Plugin is created but not initialized */
			Plugin_Uncompiled,      /**< Plugin is not yet compiled by the JIT */
			Plugin_BadLoad,         /**< Plugin failed to load */
			Plugin_Evicted          /**< Plugin was unloaded due to an error */
		};
		public const int 
			Plugin_Running = 0,       /**< Plugin is running */
			/* All states below are "temporarily" unexecutable */
			Plugin_Paused = 1,          /**< Plugin is loaded but paused */
			Plugin_Error = 2,           /**< Plugin is loaded but errored/locked */
			/* All states below do not have all natives */
			Plugin_Loaded = 3,          /**< Plugin has passed loading and can be finalized */
			Plugin_Failed = 4,          /**< Plugin has a fatal failure */
			Plugin_Created = 5,         /**< Plugin is created but not initialized */
			Plugin_Uncompiled = 6,      /**< Plugin is not yet compiled by the JIT */
			Plugin_BadLoad = 7,         /**< Plugin failed to load */
			Plugin_Evicted = 8;          /**< Plugin was unloaded due to an error */

		/**
		 * Plugin information properties. Plugins can declare a global variable with
		 * their info. Example,
		 *
		 *   public Plugin myinfo = {
		 *   	name = "Admin Help",
		 *   	author = "AlliedModders LLC",
		 *   	description = "Display command information",
		 *   	version = "1.0",
		 *   	url = "http://www.sourcemod.net/"
		 *   };
		 *
		 * SourceMod will display this information when a user inspects plugins in the
		 * console.
		 */
		public enum PluginInfo
		{
			PlInfo_Name,            /**< Plugin name */
			PlInfo_Author,          /**< Plugin author */
			PlInfo_Description,     /**< Plugin description */
			PlInfo_Version,         /**< Plugin version */
			PlInfo_URL              /**< Plugin URL */
		};
		public const int
			PlInfo_Name = 0,            /**< Plugin name */
			PlInfo_Author = 1,          /**< Plugin author */
			PlInfo_Description = 2,     /**< Plugin description */
			PlInfo_Version = 3,         /**< Plugin version */
			PlInfo_URL = 4;              /**< Plugin URL */

		/**
		 * Defines how an extension must expose itself for autoloading.
		 */
		public struct Extension
		{
			public string name;   /**< Short name */
			public string file;   /**< Default file name */
			public bool autoload;       /**< Whether or not to auto-load */
			public bool required;       /**< Whether or not to require */
		};

		/**
		 * Defines how a plugin must expose itself for public static requiring.
		 */
		public struct SharedPlugin
		{
			public string name;   /**< Short name */
			public string file;   /**< File name */
			public bool required;       /**< Whether or not to require */
		};

		public const float[] NULL_VECTOR = null;        /**< Pass this into certain functions to act as a C++ NULL */
		public const string NULL_STRING = null;   /**< pass this into certain functions to act as a C++ NULL */

		/**
		 * Check if the given vector is the NULL_VECTOR.
		 *
		 * @param vec     The vector to test.
		 * @return        True if NULL_VECTOR, false otherwise.
		 */
		public static bool IsNullVector(float[] vec)
		{
			return vec == NULL_VECTOR;
		}

		/**
		 * Check if the given string is the NULL_STRING.
		 *
		 * @param str     The string to test.
		 * @return        True if NULL_STRING, false otherwise.
		 */
		public static bool IsNullString(string str)
		{
			return str == NULL_STRING;
		}

		public static int VerifyCoreVersion() { throw new NotImplementedException(); }

		/**
		 * Sets a public static as optional, such that if it is unloaded, removed,
		 * or otherwise non-existent, the plugin will still work.  Calling
		 * removed natives results in a run-time error.
		 *
		 * @param name          public static name.
		 */
		public static void MarkNativeAsOptional(string name) { throw new NotImplementedException(); }

	}
}