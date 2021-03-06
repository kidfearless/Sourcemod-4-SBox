/**
 * vim: set ts=4 sw=4 tw=99 noet :
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
		 * Console variable bound values used with Get/SetConVarBounds()
		 */
		public enum ConVarBounds
		{
			ConVarBound_Upper = 0,
			ConVarBound_Lower
		};
		public const int
			ConVarBound_Upper = 0,
			ConVarBound_Lower = 1;

		/**
		 * Console variable query result values.
		 */
		public enum ConVarQueryResult
		{
			ConVarQuery_Okay = 0,               //< Retrieval of client convar value was successful. */
			ConVarQuery_NotFound,               //< Client convar was not found. */
			ConVarQuery_NotValid,               //< A console command with the same name was found, but there is no convar. */
			ConVarQuery_Protected               //< Client convar was found, but it is protected. The server cannot retrieve its value. */
		};
		public const int
			ConVarQuery_Okay = 0,               //< Retrieval of client convar value was successful. */
			ConVarQuery_NotFound = 1,               //< Client convar was not found. */
			ConVarQuery_NotValid = 2,               //< A console command with the same name was found, but there is no convar. */
			ConVarQuery_Protected = 3;               //< Client convar was found, but it is protected. The server cannot retrieve its value. */

		/**
		 * Called when a console variable's value is changed.
		 * 
		 * @param convar        Handle to the convar that was changed.
		 * @param oldValue      String containing the value of the convar before it was changed.
		 * @param newValue      String containing the new value of the convar.
		 */
		public delegate void ConVarChanged(ConVar convar, string oldValue, string newValue);

		/**
		 * Creates a new console variable.
		 *
		 * @param name          Name of new convar.
		 * @param defaultValue  String containing the default value of new convar.
		 * @param description   Optional description of the convar.
		 * @param flags         Optional bitstring of flags determining how the convar should be handled. See FCVAR_* constants for more details.
		 * @param hasMin        Optional boolean that determines if the convar has a minimum value.
		 * @param min           Minimum floating point value that the convar can have if hasMin is true.
		 * @param hasMax        Optional boolean that determines if the convar has a maximum value.
		 * @param max           Maximum floating point value that the convar can have if hasMax is true.
		 * @return              A handle to the newly created convar. If the convar already exists, a handle to it will still be returned.
		 * @error               Convar name is blank or is the same as an existing console command.
		 */
		public static ConVar CreateConVar(string name,	string defaultValue,string description = "",int flags = 0,bool hasMin = false, float min = 0.0f,bool hasMax = false, float max = 0.0f)
		{ throw new NotImplementedException(); }

		/**
		 * Searches for a console variable.
		 *
		 * @param name          Name of convar to find.
		 * @return              A ConVar object if found; null otherwise.
		 */
		public static ConVar FindConVar(string name) { throw new NotImplementedException(); }

		// A ConVar is a configurable, named setting in the srcds console.
		public class ConVar : Handle
		{
			// Retrieves or sets a boolean value for the convar.
			public bool BoolValue
			{
				get { throw new NotImplementedException(); }
				set
				{
					throw new NotImplementedException();
				}
			}

			// Retrieves or sets an integer value for the convar.
			public int IntValue
			{
				get { throw new NotImplementedException(); }
				set { throw new NotImplementedException(); }
			}

			// Retrieves or sets a float value for the convar.
			public float FloatValue
			{
				get { throw new NotImplementedException(); }
				set { throw new NotImplementedException(); }
			}

			// Gets or sets the flag bits (FCVAR_*) on the convar.
			public int Flags
			{
				get { throw new NotImplementedException(); }
				set { throw new NotImplementedException(); }
			}

			// Sets the boolean value of a console variable.
			//
			// Note: The replicate and notify params are only relevant for the
			// original, Dark Messiah, and Episode 1 engines. Newer engines
			// automatically do these things when the convar value is changed.
			//
			// @param value     New boolean value.
			// @param replicate If set to true, the new convar value will be set on all clients.
			//                  This will only work if the convar has the FCVAR_REPLICATED flag
			//                  and actually exists on clients.
			// @param notify    If set to true, clients will be notified that the convar has changed.
			//                  This will only work if the convar has the FCVAR_NOTIFY flag.
			public void SetBool(bool value, bool replicate = false, bool notify = false) { throw new NotImplementedException(); }

			// Sets the integer value of a console variable.
			//
			// Note: The replicate and notify params are only relevant for the
			// original, Dark Messiah, and Episode 1 engines. Newer engines
			// automatically do these things when the convar value is changed.
			//
			// @param value     New integer value.
			// @param replicate If set to true, the new convar value will be set on all clients.
			//                  This will only work if the convar has the FCVAR_REPLICATED flag
			//                  and actually exists on clients.
			// @param notify    If set to true, clients will be notified that the convar has changed.
			//                  This will only work if the convar has the FCVAR_NOTIFY flag.
			public void SetInt(int value, bool replicate = false, bool notify = false) { throw new NotImplementedException(); }

			// Sets the floating point value of a console variable.
			//
			// Note: The replicate and notify params are only relevant for the
			// original, Dark Messiah, and Episode 1 engines. Newer engines
			// automatically do these things when the convar value is changed.
			//
			// @param value     New floating point value.
			// @param replicate If set to true, the new convar value will be set on all clients.
			//                  This will only work if the convar has the FCVAR_REPLICATED flag
			//                  and actually exists on clients.
			// @param notify    If set to true, clients will be notified that the convar has changed.
			//                  This will only work if the convar has the FCVAR_NOTIFY flag.
			public void SetFloat(float value, bool replicate = false, bool notify = false) { throw new NotImplementedException(); }

			// Retrieves the string value of a console variable.
			//
			// @param convar     Handle to the convar.
			// @param value      Buffer to store the value of the convar.
			// @param maxlength  Maximum length of string buffer.
			public void GetString(string value, int maxlength) { throw new NotImplementedException(); }

			// Sets the string value of a console variable.
			//
			// Note: The replicate and notify params are only relevant for the
			// original, Dark Messiah, and Episode 1 engines. Newer engines
			// automatically do these things when the convar value is changed.
			//
			// @param value      New string value.
			// @param replicate  If set to true, the new convar value will be set on all clients.
			//                   This will only work if the convar has the FCVAR_REPLICATED flag
			//                   and actually exists on clients.
			// @param notify     If set to true, clients will be notified that the convar has changed.
			//                   This will only work if the convar has the FCVAR_NOTIFY flag.
			public void SetString(string value, bool replicate = false, bool notify = false) { throw new NotImplementedException(); }

			// Resets the console variable to its default value.
			//
			// Note: The replicate and notify params are only relevant for the
			// original, Dark Messiah, and Episode 1 engines. Newer engines
			// automatically do these things when the convar value is changed.
			//
			// @param replicate  If set to true, the new convar value will be set on all clients.
			//                   This will only work if the convar has the FCVAR_REPLICATED flag
			//                   and actually exists on clients.
			// @param notify     If set to true, clients will be notified that the convar has changed.
			//                   This will only work if the convar has the FCVAR_NOTIFY flag.
			public void RestoreDefault(bool replicate = false, bool notify = false) { throw new NotImplementedException(); }

			// Retrieves the default string value of a console variable.
			//
			// @param value      Buffer to store the default value of the convar.
			// @param maxlength  Maximum length of string buffer.
			// @return           Number of bytes written to the buffer (UTF-8 safe).
			public int GetDefault(string value, int maxlength) { throw new NotImplementedException(); }

			// Retrieves the specified bound of a console variable.
			//
			// @param type       Type of bound to retrieve, ConVarBound_Lower or ConVarBound_Upper.
			// @param value      By-reference cell to store the specified floating point bound value.
			// @return           True if the convar has the specified bound set, false otherwise.
			public bool GetBounds(ConVarBounds type, out float value) { throw new NotImplementedException(); }

			// Sets the specified bound of a console variable.
			//
			// @param type       Type of bound to set, ConVarBound_Lower or ConVarBound_Upper
			// @param set        If set to true, convar will use specified bound. If false, bound will be removed.
			// @param value      Floating point value to use as the specified bound.
			public void SetBounds(ConVarBounds type, bool set, float value = 0.0f) { throw new NotImplementedException(); }

			// Retrieves the name of a console variable.
			//
			// @param name       Buffer to store the name of the convar.
			// @param maxlength  Maximum length of string buffer.
			public void GetName(string name, int maxlength) { throw new NotImplementedException(); }

			// Replicates a convar value to a specific client. This does not change the actual convar value.
			//
			// @param client     Client index
			// @param value      String value to send
			// @return           True on success, false on failure
			// @error            Invalid client index, client not in game, or client is fake
			public bool ReplicateToClient(int client, string value) { throw new NotImplementedException(); }

			// Creates a hook for when a console variable's value is changed.
			//
			// @param callback  An OnConVarChanged function pointer.
			public void AddChangeHook(ConVarChanged callback) { throw new NotImplementedException(); }

			// Removes a hook for when a console variable's value is changed.
			//
			// @param convar    Handle to the convar.
			// @param callback  An OnConVarChanged function pointer.
			// @error           No active hook on convar.
			public void RemoveChangeHook(ConVarChanged callback) { throw new NotImplementedException(); }
		}

		/**
		 * Creates a hook for when a console variable's value is changed.
		 *
		 * @param convar        Handle to the convar.
		 * @param callback      An OnConVarChanged function pointer.
		 * @error               Invalid or corrupt Handle or invalid callback function.
		 */
		public static void HookConVarChange(Handle convar, ConVarChanged callback) { throw new NotImplementedException(); }

		/**
		 * Removes a hook for when a console variable's value is changed.
		 *
		 * @param convar        Handle to the convar.
		 * @param callback      An OnConVarChanged function pointer.
		 * @error               Invalid or corrupt Handle, invalid callback function, or no active hook on convar.
		 */
		public static void UnhookConVarChange(Handle convar, ConVarChanged callback) { throw new NotImplementedException(); }

		/**
		 * Returns the boolean value of a console variable.
		 *
		 * @param convar        Handle to the convar.
		 * @return              The boolean value of the convar.
		 * @error               Invalid or corrupt Handle.
		 */
		public static bool GetConVarBool(Handle convar) { throw new NotImplementedException(); }

		/**
		 * Sets the boolean value of a console variable.
		 *
		 * Note: The replicate and notify params are only relevant for the original, Dark Messiah, and
		 * Episode 1 engines. Newer engines automatically do these things when the convar value is changed.
		 *
		 * @param convar        Handle to the convar.
		 * @param value         New boolean value.
		 * @param replicate     If set to true, the new convar value will be set on all clients.
		 *                      This will only work if the convar has the FCVAR_REPLICATED flag
		 *                      and actually exists on clients.
		 * @param notify        If set to true, clients will be notified that the convar has changed.
		 *                      This will only work if the convar has the FCVAR_NOTIFY flag.
		 * @error               Invalid or corrupt Handle.
		 */
		public static void SetConVarBool(Handle convar, bool value, bool replicate = false, bool notify = false) { throw new NotImplementedException(); }

		/**
		 * Returns the integer value of a console variable.
		 *
		 * @param convar        Handle to the convar.
		 * @return              The integer value of the convar.
		 * @error               Invalid or corrupt Handle.
		 */
		public static int GetConVarInt(Handle convar) { throw new NotImplementedException(); }

		/**
		 * Sets the integer value of a console variable.
		 *
		 * Note: The replicate and notify params are only relevant for the original, Dark Messiah, and
		 * Episode 1 engines. Newer engines automatically do these things when the convar value is changed.
		 *
		 * @param convar        Handle to the convar.
		 * @param value         New integer value.
		 * @param replicate     If set to true, the new convar value will be set on all clients.
		 *                      This will only work if the convar has the FCVAR_REPLICATED flag
		 *                      and actually exists on clients.
		 * @param notify        If set to true, clients will be notified that the convar has changed.
		 *                      This will only work if the convar has the FCVAR_NOTIFY flag.
		 * @error               Invalid or corrupt Handle.
		 */
		public static void SetConVarInt(Handle convar, int value, bool replicate = false, bool notify = false) { throw new NotImplementedException(); }

		/**
		 * Returns the floating point value of a console variable.
		 *
		 * @param convar        Handle to the convar.
		 * @return              The floating point value of the convar.
		 * @error               Invalid or corrupt Handle.
		 */
		public static float GetConVarFloat(Handle convar) { throw new NotImplementedException(); }

		/**
		 * Sets the floating point value of a console variable.
		 *
		 * Note: The replicate and notify params are only relevant for the original, Dark Messiah, and
		 * Episode 1 engines. Newer engines automatically do these things when the convar value is changed.
		 *
		 * @param convar        Handle to the convar.
		 * @param value         New floating point value.
		 * @param replicate     If set to true, the new convar value will be set on all clients.
		 *                      This will only work if the convar has the FCVAR_REPLICATED flag
		 *                      and actually exists on clients.
		 * @param notify        If set to true, clients will be notified that the convar has changed.
		 *                      This will only work if the convar has the FCVAR_NOTIFY flag.
		 * @error               Invalid or corrupt Handle.
		 */
		public static void SetConVarFloat(Handle convar, float value, bool replicate = false, bool notify = false) { throw new NotImplementedException(); }

		/**
		 * Retrieves the string value of a console variable.
		 *
		 * @param convar        Handle to the convar.
		 * @param value         Buffer to store the value of the convar.
		 * @param maxlength     Maximum length of string buffer.
		 * @error               Invalid or corrupt Handle.     
		 */
		public static void GetConVarString(Handle convar, string value, int maxlength) { throw new NotImplementedException(); }

		/**
		 * Sets the string value of a console variable.
		 *
		 * Note: The replicate and notify params are only relevant for the original, Dark Messiah, and
		 * Episode 1 engines. Newer engines automatically do these things when the convar value is changed.
		 *
		 * @param convar        Handle to the convar.
		 * @param value         New string value.
		 * @param replicate     If set to true, the new convar value will be set on all clients.
		 *                      This will only work if the convar has the FCVAR_REPLICATED flag
		 *                      and actually exists on clients.
		 * @param notify        If set to true, clients will be notified that the convar has changed.
		 *                      This will only work if the convar has the FCVAR_NOTIFY flag.
		 * @error               Invalid or corrupt Handle.
		 */
		public static void SetConVarString(Handle convar, string value, bool replicate = false, bool notify = false) { throw new NotImplementedException(); }

		/**
		 * Resets the console variable to its default value.
		 *
		 * Note: The replicate and notify params are only relevant for the original, Dark Messiah, and
		 * Episode 1 engines. Newer engines automatically do these things when the convar value is changed.
		 *
		 * @param convar        Handle to the convar.
		 * @param replicate     If set to true, the new convar value will be set on all clients.
		 *                      This will only work if the convar has the FCVAR_REPLICATED flag
		 *                      and actually exists on clients.
		 * @param notify        If set to true, clients will be notified that the convar has changed.
		 *                      This will only work if the convar has the FCVAR_NOTIFY flag.
		 * @error               Invalid or corrupt Handle.
		 */
		public static void ResetConVar(Handle convar, bool replicate = false, bool notify = false) { throw new NotImplementedException(); }

		/**
		 * Retrieves the default string value of a console variable.
		 *
		 * @param convar        Handle to the convar.
		 * @param value         Buffer to store the default value of the convar.
		 * @param maxlength     Maximum length of string buffer.
		 * @return              Number of bytes written to the buffer (UTF-8 safe).
		 * @error               Invalid or corrupt Handle.
		 */
		public static int GetConVarDefault(Handle convar, string value, int maxlength) { throw new NotImplementedException(); }

		/**
		 * Returns the bitstring of flags on a console variable.
		 *
		 * @param convar        Handle to the convar.
		 * @return              A bitstring containing the FCVAR_* flags that are enabled.
		 * @error               Invalid or corrupt Handle.
		 */
		public static int GetConVarFlags(Handle convar) { throw new NotImplementedException(); }

		/**
		 * Sets the bitstring of flags on a console variable.
		 *
		 * @param convar        Handle to the convar.
		 * @param flags         A bitstring containing the FCVAR_* flags to enable.
		 * @error               Invalid or corrupt Handle.
		 */
		public static void SetConVarFlags(Handle convar, int flags) { throw new NotImplementedException(); }

		/**
		 * Retrieves the specified bound of a console variable.
		 *
		 * @param convar        Handle to the convar.
		 * @param type          Type of bound to retrieve, ConVarBound_Lower or ConVarBound_Upper.
		 * @param value         By-reference cell to store the specified floating point bound value.
		 * @return              True if the convar has the specified bound set, false otherwise.
		 * @error               Invalid or corrupt Handle.
		 */
		public static bool GetConVarBounds(Handle convar, ConVarBounds type, out float value) { throw new NotImplementedException(); }

		/**
		 * Sets the specified bound of a console variable.
		 *
		 * @param convar        Handle to the convar.
		 * @param type          Type of bound to set, ConVarBound_Lower or ConVarBound_Upper
		 * @param set           If set to true, convar will use specified bound. If false, bound will be removed.
		 * @param value         Floating point value to use as the specified bound.
		 * @error               Invalid or corrupt Handle.
		 */
		public static void SetConVarBounds(Handle convar, ConVarBounds type, bool set, float value = 0.0f) { throw new NotImplementedException(); }

		/**
		 * Retrieves the name of a console variable.
		 *
		 * @param convar        Handle to the convar.
		 * @param name          Buffer to store the name of the convar.
		 * @param maxlength     Maximum length of string buffer.
		 * @error               Invalid or corrupt Handle.     
		 */
		public static void GetConVarName(Handle convar, string name, int maxlength) { throw new NotImplementedException(); }

		/**
		 * Replicates a convar value to a specific client. This does not change the actual convar value.
		 *
		 * @param client        Client index
		 * @param convar        ConVar handle
		 * @param value         String value to send
		 * @return              True on success, false on failure
		 * @error               Invalid client index, client not in game, or client is fake
		 */
		public static bool SendConVarValue(int client, Handle convar, string value) { throw new NotImplementedException(); }


		// Called when a query to retrieve a client's console variable has finished.
		//
		// @param cookie        Unique identifier of query.
		// @param client        Player index.
		// @param result        Result of query that tells one whether or not query was successful.
		//                      See ConVarQueryResult public enum for more details.
		// @param convarName    Name of client convar that was queried.
		// @param convarValue   Value of client convar that was queried if successful. This will be "" if it was not.
		// @param value         Value that was passed when query was started.
		public delegate void ConVarQueryFinished(QueryCookie cookie, int client, ConVarQueryResult result, string cvarName, string cvarValue, any value);

		/**
		 * Starts a query to retrieve the value of a client's console variable.
		 *
		 * @param client        Player index.
		 * @param cvarName      Name of client convar to query.
		 * @param callback      A function to use as a callback when the query has finished.
		 * @param value         Optional value to pass to the callback function.
		 * @return              A cookie that uniquely identifies the query. 
		 *                      Returns QUERYCOOKIE_FAILED on failure, such as when used on a bot.
		 */
		public static QueryCookie QueryClientConVar(int client, string cvarName, ConVarQueryFinished callback, any? value = null) { throw new NotImplementedException(); }

		/**
		 * Returns true if the supplied character is valid in a ConVar name.
		 *
		 * @param c             Character to validate.
		 * @return              True is valid for ConVars, false otherwise
		 */
		public static bool IsValidConVarChar(int c)
		{
			return (c == '_' || IsCharAlpha(c) || IsCharNumeric(c));
		}
	}
}