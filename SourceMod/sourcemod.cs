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

		/**
		 * Plugin public information.
		 */
		public struct Plugin
		{
			public string name;        /**< Plugin Name */
			public string description; /**< Plugin Description */
			public string author;      /**< Plugin Author */
			public string version;     /**< Plugin Version */
			public string url;         /**< Plugin URL */
		};


		public enum APLRes
		{
			APLRes_Success = 0,     /**< Plugin should load */
			APLRes_Failure,         /**< Plugin shouldn't load and should display an error */
			APLRes_SilentFailure    /**< Plugin shouldn't load but do so silently */
		};
		public const int
			APLRes_Success = 0,     /**< Plugin should load */
			APLRes_Failure = 1,         /**< Plugin shouldn't load and should display an error */
			APLRes_SilentFailure = 2;   /**< Plugin shouldn't load but do so silently */
		public class GameData : Handle
		{
			// Loads a game config file.
			//
			// @param file          File to load.  The path must be relative to the 'gamedata' folder under the config folder
			//                      and the extension should be omitted.
			// @return              A handle to the game config file or null on failure.
			public GameData(string file) { throw new NotImplementedException(); }

			// Returns an offset value.
			//
			// @param key           Key to retrieve from the offset section.
			// @return              An offset, or -1 on failure.
			public int GetOffset(string key) { throw new NotImplementedException(); }

			// Gets the value of a key from the "Keys" section.
			//
			// @param key           Key to retrieve from the Keys section.
			// @param buffer        Destination string buffer.
			// @param maxlen        Maximum length of output string buffer.
			// @return              True if key existed, false otherwise.
			public bool GetKeyValue(string key, string buffer, int maxlen) { throw new NotImplementedException(); }

			// Finds an address calculation in a GameConfig file,
			// performs LoadFromAddress on it as appropriate, then returns the final address.
			//
			// @param name          Name of the public to find.
			// @return              An address calculated on success, or 0 on failure.
			public Address GetAddress(string name) { throw new NotImplementedException(); }

			// Returns a function address calculated from a signature.
			//
			// @param name          Name of the public to find.
			// @return              An address calculated on success, or 0 on failure.
			public Address GetMemSig(string name) { throw new NotImplementedException(); }
		};

		/**
		 * Called when the plugin is fully initialized and all known external references
		 * are resolved. This is only called once in the lifetime of the plugin, and is
		 * paired with OnPluginEnd().
		 *
		 * If any run-time error is thrown during this callback, the plugin will be marked
		 * as failed.
		 */
		public virtual void OnPluginStart() { throw new NotImplementedException(); }

		/**
		 * Called before OnPluginStart, in case the plugin wants to check for load failure.
		 * This is called even if the plugin type is "private."  Any natives from modules are
		 * not available at this point.  Thus, this public virtual should only be used for explicit
		 * pre-emptive things, such as adding dynamic natives, setting certain types of load
		 * filters (such as not loading the plugin for certain games).
		 *
		 * @note It is not safe to call externally resolved natives until OnPluginStart().
		 * @note Any sort of RTE in this function will cause the plugin to fail loading.
		 * @note If you do not return anything, it is treated like returning success.
		 * @note If a plugin has an AskPluginLoad2(), AskPluginLoad() will not be called.
		 *
		 * @param myself        Handle to the plugin.
		 * @param late          Whether or not the plugin was loaded "late" (after map load).
		 * @param error         Error message buffer in case load failed.
		 * @param err_max       Maximum number of characters for error message buffer.
		 * @return              APLRes_Success for load success, APLRes_Failure or APLRes_SilentFailure otherwise
		 */
		public virtual APLRes AskPluginLoad2(Handle myself, bool late, string error, int err_max) { throw new NotImplementedException(); }

		/**
		 * Called when the plugin is about to be unloaded.
		 *
		 * It is not necessary to close any handles or remove hooks in this function.
		 * SourceMod guarantees that plugin shutdown automatically and correctly releases
		 * all resources.
		 */
		public virtual void OnPluginEnd() { throw new NotImplementedException(); }

		/**
		 * Called when the plugin's pause status is changing.
		 *
		 * @param pause         True if the plugin is being paused, false otherwise.
		 */
		public virtual void OnPluginPauseChange(bool pause) { throw new NotImplementedException(); }

		/**
		 * Called before every server frame.  Note that you should avoid
		 * doing expensive computations or declaring large local arrays.
		 */
		public virtual void OnGameFrame() { throw new NotImplementedException(); }

		/**
		 * Called when the map is loaded.
		 *
		 * @note This used to be OnServerLoad(), which is now deprecated.
		 *       Plugins still using the old public virtual will work.
		 */
		public virtual void OnMapStart() { throw new NotImplementedException(); }

		/**
		 * Called right before a map ends.
		 */
		public virtual void OnMapEnd() { throw new NotImplementedException(); }

		/**
		 * Called when the map has loaded, servercfgfile (server.cfg) has been
		 * executed, and all plugin configs are done executing.  This is the best
		 * place to initialize plugin functions which are based on cvar data.
		 *
		 * @note This will always be called once and only once per map.  It will be
		 *       called after OnMapStart().
		 */
		public virtual void OnConfigsExecuted() { throw new NotImplementedException(); }

		/**
		 * This is called once, right after OnMapStart() but any time before
		 * OnConfigsExecuted().  It is called after the "exec sourcemod.cfg"
		 * command and all AutoExecConfig() exec commands have been added to
		 * the ServerCommand() buffer.
		 *
		 * If you need to load per-map settings that override default values,
		 * adding commands to the ServerCommand() buffer here will guarantee
		 * that they're set before OnConfigsExecuted().
		 *
		 * Unlike OnMapStart() and OnConfigsExecuted(), this is not called on
		 * late loads that occur after OnMapStart().
		 */
		public virtual void OnAutoConfigsBuffered() { throw new NotImplementedException(); }

		/**
		 * Called after all plugins have been loaded.  This is called once for
		 * every plugin.  If a plugin late loads, it will be called immediately
		 * after OnPluginStart().
		 */
		public virtual void OnAllPluginsLoaded() { throw new NotImplementedException(); }

		/**
		 * Returns the calling plugin's Handle.
		 *
		 * @return              Handle of the calling plugin.
		 */
		public static Handle GetMyHandle() { throw new NotImplementedException(); }

		/**
		 * Returns an iterator that can be used to search through plugins.
		 *
		 * @return              Handle to iterate with.  Must be closed via
		 *                      CloseHandle().
		 * @error               Invalid Handle.
		 */
		public static Handle GetPluginIterator() { throw new NotImplementedException(); }

		/**
		 * Returns whether there are more plugins available in the iterator.
		 *
		 * @param iter          Handle to the plugin iterator.
		 * @return              True on more plugins, false otherwise.
		 * @error               Invalid Handle.
		 */
		public static bool MorePlugins(Handle iter) { throw new NotImplementedException(); }

		/**
		 * Returns the current plugin in the iterator and advances the iterator.
		 *
		 * @param iter          Handle to the plugin iterator.
		 * @return              Current plugin the iterator is at, before
		 *                      the iterator is advanced.
		 * @error               Invalid Handle.
		 */
		public static Handle ReadPlugin(Handle iter) { throw new NotImplementedException(); }

		/**
		 * Returns a plugin's status.
		 *
		 * @param plugin        Plugin Handle (INVALID_HANDLE uses the calling plugin).
		 * @return              Status code for the plugin.
		 * @error               Invalid Handle.
		 */
		public static PluginStatus GetPluginStatus(Handle plugin) { throw new NotImplementedException(); }

		/**
		 * Retrieves a plugin's file name relative to the plugins folder.
		 *
		 * @param plugin        Plugin Handle (INVALID_HANDLE uses the calling plugin).
		 * @param buffer        Buffer to the store the file name.
		 * @param maxlength     Maximum length of the name buffer.
		 * @error               Invalid Handle.
		 */
		public static void GetPluginFilename(Handle plugin, out string buffer, int maxlength) { throw new NotImplementedException(); }


		/**
		 * Retrieves whether or not a plugin is being debugged.
		 *
		 * @param plugin        Plugin Handle (INVALID_HANDLE uses the calling plugin).
		 * @return              True if being debugged, false otherwise.
		 * @error               Invalid Handle.
		 */
		public static bool IsPluginDebugging(Handle plugin) { throw new NotImplementedException(); }

		/**
		 * Retrieves a plugin's public info.
		 *
		 * @param plugin        Plugin Handle (INVALID_HANDLE uses the calling plugin).
		 * @param info          Plugin info public to retrieve.
		 * @param buffer        Buffer to store info in.
		 * @param maxlength     Maximum length of buffer.
		 * @return              True on success, false if public is not available.
		 * @error               Invalid Handle.
		 */
		public static bool GetPluginInfo(Handle plugin, PluginInfo info, string buffer, int maxlength) { throw new NotImplementedException(); }

		/**
		 * Finds a plugin by its order in the list from the "plugins list" server
		 * "sm" command.  You should not use this function to loop through all plugins,
		 * use the iterator instead.  Looping through all plugins using this native
		 * is O(n^2), whereas using the iterator is O(n).
		 *
		 * @param order_num     Number of the plugin as it appears in "sm plugins list".
		 * @return              Plugin Handle on success, INVALID_HANDLE if no plugin
		 *                      matches the given number.
		 */
		public static Handle FindPluginByNumber(int order_num) { throw new NotImplementedException(); }

		/**
		 * Causes the plugin to enter a failed state.  An error will be thrown and
		 * the plugin will be paused until it is unloaded or reloaded.
		 *
		 * For backwards compatibility, if no extra arguments are passed, no
		 * formatting is applied.  If one or more additional arguments is passed,
		 * the string is formatted using Format().  If any errors are encountered
		 * during formatting, both the format specifier string and an additional
		 * error message are written.
		 *
		 * This function does not return, and no further code in the plugin is
		 * executed.
		 *
		 * @param string        Format specifier string.
		 * @param ...           Formatting arguments.
		 * @error               Always throws SP_ERROR_ABORT.
		 */
		public static void SetFailState(string String, params object[] args) { throw new NotImplementedException(); }

		/**
		 * Aborts the current callback and throws an error.  This function
		 * does not return in that no code is executed following it.
		 *
		 * @param fmt           String format.
		 * @param ...           Format arguments.
		 * @error               Always!
		 */
		public static void ThrowError(string fmt, params object[] args) { throw new NotImplementedException(); }

		/**
		 * Logs a stack trace from the current function call. Code
		 * execution continues after the call
		 *
		 * @param fmt           Format string to send with the stack trace.
		 * @param ...           Format arguments.
		 * @error               Always logs a stack trace.
		 */
		public static void LogStackTrace(string fmt, params object[] args) { throw new NotImplementedException(); }

		/**
		 * Gets the system time as a unix timestamp.
		 *
		 * @param bigStamp      Optional array to store the 64bit timestamp in.
		 * @return              32bit timestamp (number of seconds since unix epoch).
		 */
		public static int GetTime(out int[] bigStamp) { throw new NotImplementedException(); }

		/**
		 * Gets the system time as a unix timestamp.
		 *
		 * @param bigStamp      Optional array to store the 64bit timestamp in.
		 * @return              32bit timestamp (number of seconds since unix epoch).
		 */
		public static int GetTime() { throw new NotImplementedException(); }
		/**
		 * Produces a date and/or time string value for a timestamp.
		 *
		 * See this URL for valid parameters:
		 * http://cplusplus.com/reference/clibrary/ctime/strftime.html
		 *
		 * Note that available parameters depends on support from your operating system.
		 * In particular, ones highlighted in yellow on that page are not currently
		 * available on Windows and should be avoided for portable plugins.
		 *
		 * @param buffer        Destination string buffer.
		 * @param maxlength     Maximum length of output string buffer.
		 * @param format        Formatting rules (passing NULL_STRING will use the rules defined in sm_datetime_format).
		 * @param stamp         Optional time stamp.
		 * @error               Buffer too small or invalid time format.
		 */
		public static void FormatTime(string buffer, int maxlength, string format, int stamp = -1) { throw new NotImplementedException(); }

		/**
		 * Loads a game config file.
		 *
		 * @param file          File to load.  The path must be relative to the 'gamedata' folder under the config folder
		 *                      and the extension should be omitted.
		 * @return              A handle to the game config file or INVALID_HANDLE on failure.
		 */
		public static GameData LoadGameConfigFile(string file) { throw new NotImplementedException(); }

		/**
		 * Returns an offset value.
		 *
		 * @param gc            Game config handle.
		 * @param key           Key to retrieve from the offset section.
		 * @return              An offset, or -1 on failure.
		 */
		public static int GameConfGetOffset(Handle gc, string key) { throw new NotImplementedException(); }

		/**
		 * Gets the value of a key from the "Keys" section.
		 *
		 * @param gc            Game config handle.
		 * @param key           Key to retrieve from the Keys section.
		 * @param buffer        Destination string buffer.
		 * @param maxlen        Maximum length of output string buffer.
		 * @return              True if key existed, false otherwise.
		 */
		public static bool GameConfGetKeyValue(Handle gc, string key, string buffer, int maxlen) { throw new NotImplementedException(); }

		/**
		 * Finds an address calculation in a GameConfig file,
		 * performs LoadFromAddress on it as appropriate, then returns the final address.
		 *
		 * @param gameconf      Game config handle.
		 * @param name          Name of the public to find.
		 * @return              An address calculated on success, or 0 on failure.
		 */
		public static Address GameConfGetAddress(Handle gameconf, string name) { throw new NotImplementedException(); }

		/**
		 * Returns the operating system's "tick count," which is a number of
		 * milliseconds since the operating system loaded.  This can be used
		 * for basic benchmarks.
		 *
		 * @return              Tick count in milliseconds.
		 */
		public static int GetSysTickCount() { throw new NotImplementedException(); }

		/**
		 * Specifies that the given config file should be executed after plugin load.
		 * OnConfigsExecuted() will not be called until the config file has executed,
		 * but it will be called if the execution fails.
		 *
		 * @param autoCreate    If true, and the config file does not exist, such a config
		 *                      file will be automatically created and populated with
		 *                      information from the plugin's registered cvars.
		 * @param name          Name of the config file, excluding the .cfg extension.
		 *                      If empty, <plugin.filename.cfg> is assumed.
		 * @param folder        Folder under cfg/ to use.  By default this is "sourcemod."
		 */
		public static void AutoExecConfig(bool autoCreate = true, string name = "", string folder = "sourcemod") { throw new NotImplementedException(); }

		/**
		 * Registers a library name for identifying as a dependency to
		 * other plugins.
		 *
		 * @param name          Library name.
		 */
		public static void RegPluginLibrary(string name) { throw new NotImplementedException(); }

		/**
		 * Returns whether a library exists.  This function should be considered
		 * expensive; it should only be called on plugin to determine availability
		 * of resources.  Use OnLibraryAdded()/OnLibraryRemoved() to detect changes
		 * in libraries.
		 *
		 * @param name          Library name of a plugin or extension.
		 * @return              True if exists, false otherwise.
		 */
		public static bool LibraryExists(string name) { throw new NotImplementedException(); }

		/**
		 * Returns the status of an extension, by filename.
		 *
		 * @param name          Extension name (like "sdktools.ext").
		 * @param error         Optional error message buffer.
		 * @param maxlength     Length of optional error message buffer.
		 * @return              -2 if the extension was not found.
		 *                      -1 if the extension was found but failed to load.
		 *                      0 if the extension loaded but reported an error.
		 *                      1 if the extension is running without error.
		 */
		public static int GetExtensionFileStatus(string name, string error = "", int maxlength = 0) { throw new NotImplementedException(); }

		/**
		 * Called after a library is added.
		 * A library is either a plugin name or extension name, as
		 * exposed via its include file.
		 *
		 * @param name          Library name.
		 */
		public virtual void OnLibraryAdded(string name) { throw new NotImplementedException(); }

		/**
		 * Called right before a library is removed.
		 * A library is either a plugin name or extension name, as
		 * exposed via its include file.
		 *
		 * @param name          Library name.
		 */
		public virtual void OnLibraryRemoved(string name) { throw new NotImplementedException(); }

		public const int MAPLIST_FLAG_MAPSFOLDER = (1 << 0);   /**< On failure, use all maps in the maps folder. */
		public const int MAPLIST_FLAG_CLEARARRAY = (1 << 1); /**< If an input array is specified, clear it before adding. */
		public const int MAPLIST_FLAG_NO_DEFAULT = (1 << 2);   /**< Do not read "default" or "mapcyclefile" on failure. */

		/**
		 * Loads a map list to an ADT Array.
		 *
		 * A map list is a list of maps from a file.  SourceMod allows easy configuration of
		 * maplists through addons/sourcemod/configs/maplists.cfg.  Each entry is given a
		 * name and a file (for example, "rtv" => "rtv.cfg"), or a name and a redirection
		 * (for example, "rtv" => "default").  This public static will read a map list entry,
		 * cache the file, and return the list of maps it holds.
		 *
		 * Serial change numbers are used to identify if a map list has changed.  Thus, if
		 * you pass a serial change number and it's equal to what SourceMod currently knows
		 * about the map list, then SourceMod won't re-parse the file.
		 *
		 * If the maps end up being read from the maps folder (MAPLIST_FLAG_MAPSFOLDER), they
		 * are automatically sorted in alphabetical, ascending order.
		 *
		 * Arrays created by this function are temporary and must be freed via CloseHandle().
		 * Modifying arrays created by this function will not affect future return values or
		 * or the contents of arrays returned to other plugins.
		 *
		 * @param array         Array to store the map list.  If INVALID_HANDLE, a new blank
		 *                      array will be created.  The blocksize should be at least 16;
		 *                      otherwise results may be truncated.  Items are added to the array
		 *                      as strings.  The array is never checked for duplicates, and it is
		 *                      not read beforehand.  Only the serial number is used to detect
		 *                      changes.
		 * @param serial        Serial number to identify last known map list change.  If -1, the
		 *                      the value will not be checked.  If the map list has since changed,
		 *                      the serial is updated (even if -1 was passed).  If there is an error
		 *                      finding a valid maplist, then the serial is set to -1.
		 * @param str           Config name, or "default" for the default map list.  Config names
		 *                      should be somewhat descriptive.  For example, the admin menu uses
		 *                      a config name of "admin menu".  The list names can be configured
		 *                      by users in addons/sourcemod/configs/maplists.cfg.
		 * @param flags         MAPLIST_FLAG flags.
		 * @return              On failure:
		 *                      INVALID_HANDLE is returned, the serial is set to -1, and the input
		 *                      array (if any) is left unchanged.
		 *                      On no change:
		 *                      INVALID_HANDLE is returned, the serial is unchanged, and the input
		 *                      array (if any) is left unchanged.
		 *                      On success:
		 *                      A valid array Handle is returned, containing at least one map string.
		 *                      If an array was passed, the return value is equal to the passed Array
		 *                      Handle.  If the passed array was not cleared, it will have grown by at
		 *                      least one item.  The serial number is updated to a positive number.
		 * @error               Invalid array Handle that is not INVALID_HANDLE.
		 */
		public static Handle ReadMapList(Handle array, out int serial, string str = "default", int flags = MAPLIST_FLAG_CLEARARRAY) { throw new NotImplementedException(); }

		/**
		 * Makes a compatibility binding for map lists.  For example, if a function previously used
		 * "clam.cfg" for map lists, this function will insert a "fake" binding to "clam.cfg" that
		 * will be overridden if it's in the maplists.cfg file.
		 *
		 * @param name          Configuration name that would be used with ReadMapList().
		 * @param file          Default file to use.
		 */
		public static void SetMapListCompatBind(string name, string file) { throw new NotImplementedException(); }

		/**
		 * Called when a client has sent chat text.  This must return either true or
		 * false to indicate that a client is or is not spamming the server.
		 *
		 * The return value is a hint only.  Core or another plugin may decide
		 * otherwise.
		 *
		 * @param client        Client index.  The server (0) will never be passed.
		 * @return              True if client is spamming the server, false otherwise.
		 */
		public virtual bool OnClientFloodCheck(int client) { throw new NotImplementedException(); }

		/**
		 * Called after a client's flood check has been computed.  This can be used
		 * by antiflood algorithms to decay/increase flooding weights.
		 *
		 * Since the result from "OnClientFloodCheck" isn't guaranteed to be the
		 * final result, it is generally a good idea to use this to play with other
		 * algorithms nicely.
		 *
		 * @param client        Client index.  The server (0) will never be passed.
		 * @param blocked       True if client flooded last "say", false otherwise.
		 */
		public virtual void OnClientFloodResult(int client, bool blocked) { throw new NotImplementedException(); }

		/**
		 * Feature types.
		 */
		public enum FeatureType
		{
			/**
			 * A public static function call.
			 */
			FeatureType_Native,

			/**
			 * A named capability. This is distinctly different from checking for a
			 * native, because the underlying functionality could be enabled on-demand
			 * to improve loading time. Thus a public static may appear to exist, but it might
			 * be part of a set of features that are not compatible with the current game
			 * or version of SourceMod.
			 */
			FeatureType_Capability
		};
		public const int 
			/**
			 * A public static function call.
			 */
			FeatureType_Native = 0,

			/**
			 * A named capability. This is distinctly different from checking for a
			 * native, because the underlying functionality could be enabled on-demand
			 * to improve loading time. Thus a public static may appear to exist, but it might
			 * be part of a set of features that are not compatible with the current game
			 * or version of SourceMod.
			 */
			FeatureType_Capability = 1;

		/**
		 * Feature statuses.
		 */
		public enum FeatureStatus
		{
			/**
			 * Feature is available for use.
			 */
			FeatureStatus_Available,

			/**
			 * Feature is not available.
			 */
			FeatureStatus_Unavailable,

			/**
			 * Feature is not known at all.
			 */
			FeatureStatus_Unknown
		};

		public const int 
			/**
			 * Feature is available for use.
			 */
			FeatureStatus_Available = 0,

			/**
			 * Feature is not available.
			 */
			FeatureStatus_Unavailable = 1,

			/**
			 * Feature is not known at all.
			 */
			FeatureStatus_Unknown = 2;

		/**
		 * Returns whether "GetFeatureStatus" will work. Using this native
		 * or this function will not cause SourceMod to fail loading on older versions,
		 * however, GetFeatureStatus will only work if this function returns true.
		 *
		 * @return              True if GetFeatureStatus will work, false otherwise.
		 */
		public static bool CanTestFeatures()
		{
			return LibraryExists("__CanTestFeatures__");
		}

		/**
		 * Returns whether a feature exists, and if so, whether it is usable.
		 *
		 * @param type          Feature type.
		 * @param name          Feature name.
		 * @return              Feature status.
		 */
		public static FeatureStatus GetFeatureStatus(FeatureType type, string name) { throw new NotImplementedException(); }

		/**
		 * Requires that a given feature is available. If it is not, SetFailState()
		 * is called with the given message.
		 *
		 * @param type          Feature type.
		 * @param name          Feature name.
		 * @param fmt           Message format string, or empty to use default.
		 * @param ...           Message format parameters, if any.
		 */
		public static void RequireFeature(FeatureType type, string name, string fmt = "", params object[] args) { throw new NotImplementedException(); }

		/**
		 * Represents how many bytes we can read from an address with one load
		 */
		public enum NumberType
		{
			NumberType_Int8,
			NumberType_Int16,
			NumberType_Int32
		};
		public const int  
			NumberType_Int8 = 0,
			NumberType_Int16 = 1,
			NumberType_Int32 = 2;

		public enum Address
		{
			Address_Null = 0               // a typical invalid result when an address lookup fails
		};
		public const int
			Address_Null = 0;               // a typical invalid result when an address lookup fails

		/**
		 * Load up to 4 bytes from a memory address.
		 *
		 * @param addr          Address to a memory location.
		 * @param size          How many bytes should be read.
		 *                      If loading a floating-point value, use NumberType_Int32.
		 * @return              The value that is stored at that address.
		 */
		public static any LoadFromAddress(Address addr, NumberType size) { throw new NotImplementedException(); }

		/**
		 * Store up to 4 bytes to a memory address.
		 *
		 * @param addr          Address to a memory location.
		 * @param data          Value to store at the address.
		 * @param size          How many bytes should be written.
		 *                      If storing a floating-point value, use NumberType_Int32.
		 */
		public static void StoreToAddress(Address addr, any data, NumberType size) { throw new NotImplementedException(); }

		public class FrameIterator : Handle
		{
			// Creates a stack frame iterator to build your own stack traces.
			// @return              New handle to a FrameIterator.
			public FrameIterator() { throw new NotImplementedException(); }

			// Advances the iterator to the next stack frame.
			// @return              True if another frame was fetched and data can be successfully read.
			// @error               No next element exception.
			public bool Next() { throw new NotImplementedException(); }

			// Resets the iterator back to it's starting position.
			public void Reset() { throw new NotImplementedException(); }

			// Returns the line number of the current function call.
			public int LineNumber
			{
				get
				{
					throw new NotImplementedException();
				}
			}

			// Gets the name of the current function in the call stack.
			//
			// @param buffer Buffer to copy to.
			// @param maxlen Max size of the buffer.
			public void GetFunctionName(string buffer, int maxlen) { throw new NotImplementedException(); }

			// Gets the file path to the current call in the call stack.
			//
			// @param buffer Buffer to copy to.
			// @param maxlen Max size of the buffer.
			public void GetFilePath(string buffer, int maxlen) { throw new NotImplementedException(); }
		}

	}
}
