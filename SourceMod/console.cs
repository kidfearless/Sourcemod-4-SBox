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

		public const int INVALID_FCVAR_FLAGS = (-1);

		/**
		 * Console variable query helper values.
		 */
		public enum QueryCookie
		{
			QUERYCOOKIE_FAILED = 0
		};
		public const int QUERYCOOKIE_FAILED = 0;

		/**
		 * Reply sources for commands.
		 */
		public enum ReplySource
		{
			SM_REPLY_TO_CONSOLE = 0,
			SM_REPLY_TO_CHAT = 1
		};
		public const int
			SM_REPLY_TO_CONSOLE = 0,
			SM_REPLY_TO_CHAT = 1;

		/**
		 * @section Flags for console commands and console variables.  The descriptions 
		 * for each constant come directly from the Source SDK.
		 */

		[Obsolete("deprecated No logic using this flag ever existed in a released game. It only ever appeared in the first hl2sdk.")]
		public const int FCVAR_PLUGIN = 0;       // Actual value is same as FCVAR_SS_ADDED in Left 4 Dead and later.
		[Obsolete("deprecated Did you mean FCVAR_DEVELOPMENTONLY? (No logic using this flag ever existed in a released game. It only ever appeared in the first hl2sdk.)")]
		public const int FCVAR_LAUNCHER = (1 << 1);  // Same value as FCVAR_DEVELOPMENTONLY, which is what most usages of this were intending to use.


		public const int FCVAR_NONE = 0;     // The default, no flags at all
		public const int FCVAR_UNREGISTERED = (1 << 0);  // If this is set, don't add to linked list, etc.
		public const int FCVAR_DEVELOPMENTONLY = (1 << 1);  // Hidden in released products. Flag is removed automatically if ALLOW_DEVELOPMENT_CVARS is defined. (OB+)
		public const int FCVAR_GAMEDLL = (1 << 2);  // Defined by the game DLL.
		public const int FCVAR_CLIENTDLL = (1 << 3);  // Defined by the client DLL.
		public const int FCVAR_MATERIAL_SYSTEM = (1 << 4);  // Defined by the material system. (EP1-only)
		public const int FCVAR_HIDDEN = (1 << 4);  // Hidden. Doesn't appear in find or autocomplete. Like DEVELOPMENTONLY, but can't be compiled out.1 (OB+)
		public const int FCVAR_PROTECTED = (1 << 5);  // It's a server cvar, but we don't send the data since it's a password, etc.
													  // Sends 1 if it's not bland/zero, 0 otherwise as value.
		public const int FCVAR_SPONLY = (1 << 6);  // This cvar cannot be changed by clients connected to a multiplayer server.
		public const int FCVAR_ARCHIVE = (1 << 7);// Set to cause it to be saved to vars.rc
		public const int FCVAR_NOTIFY = (1 << 8);// Notifies players when changed.
		public const int FCVAR_USERINFO = (1 << 9);// Changes the client's info string.
		public const int FCVAR_PRINTABLEONLY = (1 << 10);// This cvar's string cannot contain unprintable characters (e.g., used for player name, etc.)
		public const int FCVAR_UNLOGGED = (1 << 11);// If this is a FCVAR_SERVER, don't log changes to the log file / console if we are creating a log
		public const int FCVAR_NEVER_AS_STRING = (1 << 12);// Never try to print that cvar.
		public const int FCVAR_REPLICATED = (1 << 13);// Server setting enforced on clients.
		public const int FCVAR_CHEAT = (1 << 14);// Only useable in singleplayer / debug / multiplayer & sv_cheats
		public const int FCVAR_SS = (1 << 15);// causes varnameN where N  2 through max splitscreen slots for mod to be autogenerated (L4D+)
		public const int FCVAR_DEMO = (1 << 16);// Record this cvar when starting a demo file.
		public const int FCVAR_DONTRECORD = (1 << 17);// Don't record these command in demo files.
		public const int FCVAR_SS_ADDED = (1 << 18);// This is one of the "added" FCVAR_SS variables for the splitscreen players (L4D+)
		public const int FCVAR_RELEASE = (1 << 19);// Cvars tagged with this are the only cvars available to customers (L4D+)
		public const int FCVAR_RELOAD_MATERIALS = (1 << 20);// If this cvar changes, it forces a material reload (OB+)
		public const int FCVAR_RELOAD_TEXTURES = (1 << 21);// If this cvar changes, if forces a texture reload (OB+)
		public const int FCVAR_NOT_CONNECTED = (1 << 22);// Cvar cannot be changed by a client that is connected to a server.
		public const int FCVAR_MATERIAL_SYSTEM_THREAD = (1 << 23);// Indicates this cvar is read from the material system thread (OB+)
		public const int FCVAR_ARCHIVE_XBOX = (1 << 24);// Cvar written to config.cfg on the Xbox.
		public const int FCVAR_ARCHIVE_GAMECONSOLE = (1 << 24);// Cvar written to config.cfg on the Xbox.
		public const int FCVAR_ACCESSIBLE_FROM_THREADS = (1 << 25);// used as a debugging tool necessary to check material system thread convars (OB+)
		public const int FCVAR_SERVER_CAN_EXECUTE = (1 << 28);// the server is allowed to execute this command on clients via
															  // ClientCommand/NET_StringCmd/CBaseClientState::ProcessStringCmd. (OB+)
		public const int FCVAR_SERVER_CANNOT_QUERY = (1 << 29); // If this is set, then the server is not allowed to query this cvar's value (via
																// IServerPluginHelpers::StartQueryCvarValue).
		public const int FCVAR_CLIENTCMD_CAN_EXECUTE = (1 << 30); // IVEngineClient::ClientCmd is allowed to execute this command. 
																  // Note: IVEngineClient::ClientCmd_Unrestricted can run any client command.

		/**
		 * @endsection
		 */

		/**
		 * Executes a server command as if it were on the server console (or RCON)
		 *
		 * @param format        Formatting rules.
		 * @param ...           Variable number of format parameters.
		 */
		public static void ServerCommand(string format, params object[] args) { throw new NotImplementedException(); }

		/**
		 * Executes a server command as if it were on the server console (or RCON) 
		 * and stores the printed text into buffer.
		 *
		 * Warning: This calls ServerExecute internally and may have issues if
		 * certain commands are in the buffer, only use when you really need
		 * the response.
		 * Also, on L4D2 this will not print the command output to the server console.
		 *
		 * @param buffer        String to store command result into.
		 * @param maxlen        Length of buffer.
		 * @param format        Formatting rules.
		 * @param ...           Variable number of format parameters.
		 */
		public static void ServerCommandEx(string buffer, int maxlen, string format, params object[] args) { throw new NotImplementedException(); }

		/**
		 * Inserts a server command at the beginning of the server command buffer.
		 *
		 * @param format        Formatting rules.
		 * @param ...           Variable number of format parameters.
		 */
		public static void InsertServerCommand(string format, params object[] args) { throw new NotImplementedException(); }

		/**
		 * Executes every command in the server's command buffer, rather than once per frame.
		 */
		public static void ServerExecute() { throw new NotImplementedException(); }

		/**
		 * Executes a client command.  Note that this will not work on clients unless
		 * they have cl_restrict_server_commands set to 0.
		 *
		 * @param client        Index of the client.
		 * @param fmt           Format of the client command.
		 * @param ...           Format parameters
		 * @error               Invalid client index, or client not connected.
		 */
		public static void ClientCommand(int client, string fmt, params object[] args) { throw new NotImplementedException(); }

		/**
		 * Executes a client command on the server without being networked.
		 *
		 * FakeClientCommand() overwrites the command tokenization buffer.  This can 
		 * cause undesired effects because future calls to GetCmdArg* will return 
		 * data from the FakeClientCommand(), not the parent command.  If you are in 
		 * a hook where this matters (for example, a "say" hook), you should use 
		 * FakeClientCommandEx() instead.
		 *
		 * @param client        Index of the client.
		 * @param fmt           Format of the client command.
		 * @param ...           Format parameters
		 * @error               Invalid client index, or client not connected.
		 */
		public static void FakeClientCommand(int client, string fmt, params object[] args) { throw new NotImplementedException(); }

		/**
		 * Executes a client command on the server without being networked.  The 
		 * execution of the client command is delayed by one frame to prevent any 
		 * re-entrancy issues that might surface with FakeClientCommand().
		 *
		 * @param client        Index of the client.
		 * @param fmt           Format of the client command.
		 * @param ...           Format parameters
		 * @error               Invalid client index, or client not connected.
		 */
		public static void FakeClientCommandEx(int client, string fmt, params object[] args) { throw new NotImplementedException(); }

		/**
		 * Executes a KeyValues client command on the server without being networked.
		 *
		 * @param client        Index of the client.
		 * @param kv            KeyValues data to be sent.
		 * @error               Invalid client index, client not connected,
		 *                      or unsupported on current game.
		 */
		public static void FakeClientCommandKeyValues(int client, KeyValues kv) { throw new NotImplementedException(); }

		/**
		 * Sends a message to the server console.
		 *
		 * @param format        Formatting rules.
		 * @param ...           Variable number of format parameters.
		 */
		public static void PrintToServer(string format, params object[] args) { throw new NotImplementedException(); }

		/**
		 * Sends a message to a client's console.
		 *
		 * @param client        Client index.
		 * @param format        Formatting rules.
		 * @param ...           Variable number of format parameters.
		 * @error               If the client is not connected an error will be thrown.
		 */
		public static void PrintToConsole(int client, string format, params object[] args) { throw new NotImplementedException(); }


		/**
		 * Sends a message to every client's console.
		 *
		 * @param format        Formatting rules.
		 * @param ...           Variable number of format parameters.
		 */
		public static void PrintToConsoleAll(string format, params object[] args)
		{
			throw new NotImplementedException();
			/*char buffer[254];

			for (int i = 1; i <= MaxClients; i++)
			{
				if (IsClientInGame(i))
				{
					SetGlobalTransTarget(i) { throw new NotImplementedException(); }
					VFormat(buffer, buffer.Length, format, 2) { throw new NotImplementedException(); }
					PrintToConsole(i, "%s", buffer) { throw new NotImplementedException(); }
				}
			}*/
		}

		/**
		 * Replies to a message in a command.
		 *
		 * A client index of 0 will use PrintToServer().
		 * If the command was from the console, PrintToConsole() is used.
		 * If the command was from chat, PrintToChat() is used.
		 *
		 * @param client        Client index, or 0 for server.
		 * @param format        Formatting rules.
		 * @param ...           Variable number of format parameters.
		 * @error               If the client is not connected or invalid.
		 */
		public static void ReplyToCommand(int client, string format, params object[] args) { throw new NotImplementedException(); }

		/**
		 * Returns the current reply source of a command.
		 *
		 * @return              ReplySource value.
		 */
		public static ReplySource GetCmdReplySource() { throw new NotImplementedException(); }

		/**
		 * Sets the current reply source of a command.
		 *
		 * Only use this if you know what you are doing.  You should save the old value
		 * and restore it once you are done.
		 *
		 * @param source        New ReplySource value.
		 * @return              Old ReplySource value.
		 */
		public static ReplySource SetCmdReplySource(ReplySource source) { throw new NotImplementedException(); }

		/**
		 * Returns whether the current say hook is a chat trigger.
		 *
		 * This function is only meaningful inside say or say_team hooks.
		 *
		 * @return              True if a chat trigger, false otherwise.
		 */
		public static bool IsChatTrigger() { throw new NotImplementedException(); }

		/**
		 * Displays usage of an admin command to users depending on the 
		 * setting of the sm_show_activity cvar.  All users receive a message 
		 * in their chat text, except for the originating client, who receives 
		 * the message based on the current ReplySource.
		 *
		 * @param client        Client index doing the action, or 0 for server.
		 * @param tag           Tag to prepend to the message.
		 * @param format        Formatting rules.
		 * @param ...           Variable number of format parameters.
		 * @error
		 */
		public static void ShowActivity2(int client, string tag, string format, params object[] args) { throw new NotImplementedException(); }

		/**
		 * Displays usage of an admin command to users depending on the 
		 * setting of the sm_show_activity cvar.  
		 *
		 * This version does not display a message to the originating client 
		 * if used from chat triggers or menus.  If manual replies are used 
		 * for these cases, then this function will suffice.  Otherwise, 
		 * ShowActivity2() is slightly more useful.
		 *
		 * @param client        Client index doing the action, or 0 for server.
		 * @param format        Formatting rules.
		 * @param ...           Variable number of format parameters.
		 * @error
		 */
		public static void ShowActivity(int client, string format, params object[] args) { throw new NotImplementedException(); }

		/**
		 * Same as ShowActivity(), except the tag parameter is used instead of
		 * "[SM] " (note that you must supply any spacing).
		 *
		 * @param client        Client index doing the action, or 0 for server.
		 * @param tag           Tag to display with.
		 * @param format        Formatting rules.
		 * @param ...           Variable number of format parameters.
		 * @error
		 */
		public static void ShowActivityEx(int client, string tag, string format, params object[] args) { throw new NotImplementedException(); }

		/**
		 * Given an originating client and a target client, returns the string 
		 * that describes the originating client according to the sm_show_activity cvar.
		 *
		 * For example, "ADMIN", "PLAYER", or a player's name could be placed in this buffer.
		 *
		 * @param client        Originating client; may be 0 for server console.
		 * @param target        Targeted client.
		 * @param namebuf       Name buffer.
		 * @param maxlength     Maximum size of the name buffer.
		 * @return              True if activity should be shown.  False otherwise.  In either 
		 *                      case, the name buffer is filled.  The return value can be used 
		 *                      to broadcast a "safe" name to all players regardless of the 
		 *                      sm_show_activity filters.
		 * @error               Invalid client index or client not connected.
		 */
		public static bool FormatActivitySource(int client, int target, string namebuf, int maxlength) { throw new NotImplementedException(); }

		/**
		 * Called when a server-only command is invoked.  
		 *
		 * @param args          Number of arguments that were in the argument string.
		 * @return              An Action value.  Not handling the command
		 *                      means that Source will report it as "not found."
		 */
		public delegate Action SrvCmd(int args);

		/**
		 * Creates a server-only console command, or hooks an already existing one.  
		 *
		 * Server commands are case sensitive.
		 *
		 * @param cmd           Name of the command to hook or create.
		 * @param callback      A function to use as a callback for when the command is invoked.
		 * @param description   Optional description to use for command creation.
		 * @param flags         Optional flags to use for command creation.
		 * @error               Command name is the same as an existing convar.
		 */
		public static void RegServerCmd(string cmd, SrvCmd callback, string description = "", int flags = 0) { throw new NotImplementedException(); }

		/**
		 * Called when a generic console command is invoked.
		 *
		 * @param client        Index of the client, or 0 from the server.
		 * @param args          Number of arguments that were in the argument string.
		 * @return              An Action value.  Not handling the command
		 *                      means that Source will report it as "not found."
		 */
		public delegate Action ConCmd(int client, int args);

		/**
		 * Creates a console command, or hooks an already existing one.
		 *
		 * Console commands are case sensitive.  However, if the command already exists in the game, 
		 * a client may enter the command in any case.  SourceMod corrects for this automatically, 
		 * and you should only hook the "real" version of the command.
		 *
		 * @param cmd           Name of the command to hook or create.
		 * @param callback      A function to use as a callback for when the command is invoked.
		 * @param description   Optional description to use for command creation.
		 * @param flags         Optional flags to use for command creation.
		 * @error               Command name is the same as an existing convar.
		 */
		public static void RegConsoleCmd(string cmd, ConCmd callback, string description = "", int flags = 0) { throw new NotImplementedException(); }

		/**
		 * Creates a console command as an administrative command.  If the command does not exist,
		 * it is created.  When this command is invoked, the access rights of the player are 
		 * automatically checked before allowing it to continue.
		 *
		 * Admin commands are case sensitive from both the client and server.
		 *
		 * @param cmd           String containing command to register.
		 * @param callback      A function to use as a callback for when the command is invoked.
		 * @param adminflags    Administrative flags (bitstring) to use for permissions.
		 * @param description   Optional description to use for help.
		 * @param group         String containing the command group to use.  If empty,
		 *                      the plugin's filename will be used instead.
		 * @param flags         Optional console flags.
		 * @error               Command name is the same as an existing convar.
		 */
		public static void RegAdminCmd(string cmd, ConCmd callback, int adminflags, string description = "", string group = "", int flags = 0) { throw new NotImplementedException(); }

		/**
		 * Returns the number of arguments from the current console or server command.
		 * @note Unlike the HL2 engine call, this does not include the command itself.
		 *
		 * @return              Number of arguments to the current command.
		 */
		public static int GetCmdArgs() { throw new NotImplementedException(); }

		/**
		 * Retrieves a command argument given its index, from the current console or 
		 * server command.
		 * @note Argument indexes start at 1; 0 retrieves the command name.
		 *
		 * @param argnum        Argument number to retrieve.
		 * @param buffer        Buffer to use for storing the string.
		 * @param maxlength     Maximum length of the buffer.
		 * @return              Length of string written to buffer.
		 */
		public static int GetCmdArg(int argnum, string buffer, int maxlength) { throw new NotImplementedException(); }

		/**
		 * Retrieves a numeric command argument given its index, from the current
		 * console or server command. Will return 0 if the argument can not be
		 * parsed as a number. Use GetCmdArgIntEx to handle that explicitly.
		 *
		 * @param argnum Argument number to retrieve.
		 * @return       Value of the command argument.
		 */
		public static int GetCmdArgInt(int argnum)
		{
			throw new NotImplementedException();
			/*			char str[12];
						GetCmdArg(argnum, str, sizeof(str)) { throw new NotImplementedException(); }

						return StringToInt(str) { throw new NotImplementedException(); }*/
		}

		/**
		 * Retrieves a numeric command argument given its index, from the current
		 * console or server command. Returns false if the argument can not be
		 * completely parsed as an integer.
		 *
		 * @param argnum Argument number to retrieve.
		 * @param value  Populated with the value of the command argument.
		 * @return       Whether the argument was entirely a numeric value.
		 */
		public static bool GetCmdArgIntEx(int argnum, out int value)
		{
			throw new NotImplementedException();

			/*char str[12];
			int len = GetCmdArg(argnum, str, sizeof(str)) { throw new NotImplementedException(); }

			return StringToIntEx(str, value) == len && len > 0;*/
		}

		/**
		 * Retrieves the entire command argument string in one lump from the current 
		 * console or server command.
		 *
		 * @param buffer        Buffer to use for storing the string.
		 * @param maxlength     Maximum length of the buffer.
		 * @return              Length of string written to buffer.
		 */
		public static int GetCmdArgString(string buffer, int maxlength) { throw new NotImplementedException(); }

		public class CommandIterator : Handle
		{
			// Creates a new CommandIterator. Must be freed with delete or
			// CloseHandle().
			//
			// The CommandIterator can be used to iterate commands created by
			// SourceMod plugins and allows inspection of properties associated
			// with the command.
			// 
			// @return              New CommandIterator Handle.
			public CommandIterator() { throw new NotImplementedException(); }

			// Determines if there is a next command. If one is found, the
			// iterator is advanced to it.
			//
			// @return              true if found and iterator is advanced.
			public bool Next() { throw new NotImplementedException(); }

			// Retrieves the command's description.
			//
			// @param buffer        Buffer to copy to.
			// @param maxlen        Maximum size of the buffer.
			// @error               Invalid iterator position.
			public void GetDescription(string buffer, int maxlen) { throw new NotImplementedException(); }

			// Retrieves the command's name.
			//
			// @param buffer        Buffer to copy to.
			// @param maxlen        Maximum size of the buffer.
			// @error               Invalid iterator position.
			public void GetName(string buffer, int maxlen) { throw new NotImplementedException(); }

			// Retrieves the plugin handle of the command's creator
			//
			// @error               Invalid iterator position.
			public Handle Plugin
			{
				get { throw new NotImplementedException(); }
			}

			// Retrieves the command's default flags
			//
			// @error                Invalid iterator position.
			public int Flags
			{
				get { throw new NotImplementedException(); }
			}
		}

		/**
		 * Gets a command iterator.  Must be freed with CloseHandle().
		 *
		 * @return              A new command iterator.
		 */
		public static Handle GetCommandIterator() { throw new NotImplementedException(); }


		/**
		 * Reads a command iterator, then advances to the next command if any.
		 * Only SourceMod specific commands are returned.
		 *
		 * @param iter          Command iterator Handle.
		 * @param name          Name buffer.
		 * @param nameLen       Name buffer size.
		 * @param eflags        Effective default flags of a command.
		 * @param desc          Command description buffer.
		 * @param descLen       Command description buffer size.
		 * @return              True on success, false if there are no more commands.
		 */
		public static bool ReadCommandIterator(Handle iter, string name, int nameLen) { throw new NotImplementedException(); }

		/**
		 * Reads a command iterator, then advances to the next command if any.
		 * Only SourceMod specific commands are returned.
		 *
		 * @param iter          Command iterator Handle.
		 * @param name          Name buffer.
		 * @param nameLen       Name buffer size.
		 * @param eflags        Effective default flags of a command.
		 * @param desc          Command description buffer.
		 * @param descLen       Command description buffer size.
		 * @return              True on success, false if there are no more commands.
		 */
		public static bool ReadCommandIterator(Handle iter, string name, int nameLen, out int eflags) { throw new NotImplementedException(); }

		/**
		 * Reads a command iterator, then advances to the next command if any.
		 * Only SourceMod specific commands are returned.
		 *
		 * @param iter          Command iterator Handle.
		 * @param name          Name buffer.
		 * @param nameLen       Name buffer size.
		 * @param eflags        Effective default flags of a command.
		 * @param desc          Command description buffer.
		 * @param descLen       Command description buffer size.
		 * @return              True on success, false if there are no more commands.
		 */
		public static bool ReadCommandIterator(Handle iter, string name, int nameLen, out int eflags, string desc = "", int descLen = 0) { throw new NotImplementedException(); }

		/**
		 * Returns whether a client has access to a given command string.  The string 
		 * can be any override string, as overrides can be independent of 
		 * commands.  This feature essentially allows you to create custom 
		 * flags using the override system.
		 *
		 * @param client        Client index.
		 * @param command       Command name.  If the command is not found, the default 
		 *                      flags are used.
		 * @param flags         Flag string to use as a default, if the command or override 
		 *                      is not found.
		 * @param override_only If true, SourceMod will not attempt to find a matching 
		 *                      command, and it will only use the default flags specified.
		 *                      Otherwise, SourceMod will ignore the default flags if 
		 *                      there is a matching admin command.
		 * @return              True if the client has access, false otherwise.
		 */
		public static bool CheckCommandAccess(int client, string command, int flags, bool override_only = false) { throw new NotImplementedException(); }

		/**
		 * Returns whether an admin has access to a given command string.  The string 
		 * can be any override string, as overrides can be independent of 
		 * commands.  This feature essentially allows you to create custom flags
		 * using the override system.
		 *
		 * @param id            AdminId of the admin.
		 * @param command       Command name.  If the command is not found, the default 
		 *                      flags are used.
		 * @param flags         Flag string to use as a default, if the command or override 
		 *                      is not found.
		 * @param override_only If true, SourceMod will not attempt to find a matching 
		 *                      command, and it will only use the default flags specified.
		 *                      Otherwise, SourceMod will ignore the default flags if 
		 *                      there is a matching admin command.
		 * @return              True if the admin has access, false otherwise.
		 */
		public static bool CheckAccess(AdminId id, string command, int flags, bool override_only = false) { throw new NotImplementedException(); }

		/**
		 * Returns the bitstring of flags of a command.
		 *
		 * @param name          Name of the command.
		 * @return              A bitstring containing the FCVAR_* flags that are enabled 
		 *                      or INVALID_FCVAR_FLAGS if command not found.
		 */
		public static int GetCommandFlags(string name) { throw new NotImplementedException(); }

		/**
		 * Sets the bitstring of flags of a command.
		 *
		 * @param name          Name of the command.
		 * @param flags         A bitstring containing the FCVAR_* flags to enable.
		 * @return              True on success, otherwise false.
		 */
		public static bool SetCommandFlags(string name, int flags) { throw new NotImplementedException(); }

		/**
		 * Starts a ConCommandBase search, traversing the list of ConVars and 
		 * ConCommands.  If a Handle is returned, the next entry must be read 
		 * via FindNextConCommand().  The order of the list is undefined.
		 *
		 * @param buffer        Buffer to store entry name.
		 * @param max_size      Maximum size of the buffer.
		 * @param isCommand     Variable to store whether the entry is a command. 
		 *                      If it is not a command, it is a ConVar.
		 * @param flags         Variable to store entry flags.
		 * @param description   Buffer to store the description, empty if no description present.
		 * @param descrmax_size Maximum size of the description buffer.
		 * @return              On success, a ConCmdIter Handle is returned, which 
								can be read via FindNextConCommand(), and must be 
								closed via CloseHandle().  Additionally, the output 
								parameters will be filled with information of the 
								first ConCommandBase entry.
								On failure, INVALID_HANDLE is returned, and the 
								contents of outputs is undefined.
		 */
		public static Handle FindFirstConCommand(string buffer, int max_size, out bool isCommand, out int flags, string description = "", int descrmax_size = 0) { throw new NotImplementedException(); }

		/**
		 * Reads the next entry in a ConCommandBase iterator.
		 *
		 * @param search        ConCmdIter Handle to search.
		 * @param buffer        Buffer to store entry name.
		 * @param max_size      Maximum size of the buffer.
		 * @param isCommand     Variable to store whether the entry is a command.
								If it is not a command, it is a ConVar.
		 * @param flags         Variable to store entry flags.
		 * @param description   Buffer to store the description, empty if no description present.
		 * @param descrmax_size Maximum size of the description buffer.
		 * @return              On success, the outputs are filled, the iterator is 
								advanced to the next entry, and true is returned.  
								If no more entries exist, false is returned, and the 
								contents of outputs is undefined.
		 */
		public static bool FindNextConCommand(Handle search, string buffer, int max_size, out bool isCommand, out int flags) { throw new NotImplementedException(); }


		/**
		 * Reads the next entry in a ConCommandBase iterator.
		 *
		 * @param search        ConCmdIter Handle to search.
		 * @param buffer        Buffer to store entry name.
		 * @param max_size      Maximum size of the buffer.
		 * @param isCommand     Variable to store whether the entry is a command.
								If it is not a command, it is a ConVar.
		 * @param flags         Variable to store entry flags.
		 * @param description   Buffer to store the description, empty if no description present.
		 * @param descrmax_size Maximum size of the description buffer.
		 * @return              On success, the outputs are filled, the iterator is 
								advanced to the next entry, and true is returned.  
								If no more entries exist, false is returned, and the 
								contents of outputs is undefined.
		 */
		public static bool FindNextConCommand(Handle search, string buffer, int max_size, out bool isCommand) { throw new NotImplementedException(); }

		/**
		 * Adds an informational string to the server's public "tags".
		 * This string should be a short, unique identifier.
		 *
		 * Note: Tags are automatically removed when a plugin unloads.
		 * Note: Currently, this function does nothing because of bugs in the Valve master.
		 *
		 * @param tag           Tag string to append.
		 */
		public static void AddServerTag(string tag) { throw new NotImplementedException(); }

		/**
		 * Removes a tag previously added by the calling plugin.
		 *
		 * @param tag           Tag string to remove.
		 */
		public static void RemoveServerTag(string tag) { throw new NotImplementedException(); }

		/**
		 * Callback for command listeners. This is invoked whenever any command
		 * reaches the server, from the server console itself or a player.
		 *
		 * Clients may be in the process of connecting when they are executing commands
		 * IsClientConnected(client) is not guaranteed to return true.  Other functions
		 * such as GetClientIP() may not work at this point either.
		 *
		 * Returning Plugin_Handled or Plugin_Stop will prevent the original,
		 * baseline code from running.
		 *
		 * -- TEXT BELOW IS IMPLEMENTATION, AND NOT GUARANTEED --
		 * Even if returning Plugin_Handled or Plugin_Stop, some callbacks will still
		 * trigger. These are:
		 *  * C++ command dispatch hooks from Metamod:Source plugins
		 *  * Reg*Cmd() hooks that did not create new commands.
		 *
		 * @param client        Client, or 0 for server.
		 *                      Client may not be connected or in game.
		 * @param command       Command name, lower case. To get name as typed, use
		 *                      GetCmdArg() and specify argument 0.
		 * @param argc          Argument count.
		 * @return              Action to take (see extended notes above).
		 */
		public delegate Action CommandListener(int client, string command, int argc);

		public const string FEATURECAP_COMMANDLISTENER = "command listener";

		/**
		 * Adds a callback that will fire when a command is sent to the server.
		 *
		 * Registering commands is designed to create a new command as part of the UI,
		 * whereas this is a lightweight hook on a command string, existing or not.
		 * Using Reg*Cmd to intercept is in poor practice, as it physically creates a
		 * new command and can slow down dispatch in general.
		 *
		 * To see if this feature is available, use FeatureType_Capability and 
		 * FEATURECAP_COMMANDLISTENER.
		 *
		 * @param callback      Callback.
		 * @param command       Command, or if not specified, a global listener.
		 *                      The command is case insensitive.
		 * @return              True if this feature is available on the current game,
		 *                      false otherwise.
		 */
		public static bool AddCommandListener(CommandListener callback, string command = "") { throw new NotImplementedException(); }

		/**
		 * Removes a previously added command listener, in reverse order of being added.
		 *
		 * @param callback      Callback.
		 * @param command       Command, or if not specified, a global listener.
		 *                      The command is case insensitive.
		 * @error               Callback has no active listeners.
		 */
		public static void RemoveCommandListener(CommandListener callback, string command = "") { throw new NotImplementedException(); }

		/**
		 * Returns true if the supplied command exists.
		 *
		 * @param command       Command to find.
		 * @return              True if command is found, false otherwise.
		 */
		public static bool CommandExists(string command)
		{
			return (GetCommandFlags(command) != INVALID_FCVAR_FLAGS);
		}
		/**
		 * Global listener for the chat commands.
		 *
		 * @param client        Client index.
		 * @param command       Command name.
		 * @param sArgs         Chat argument string.
		 * 
		 * @return              An Action value. Returning Plugin_Handled bypasses the game function call.
		 *                      Returning Plugin_Stop bypasses the post hook as well as the game function.
		 */
		public virtual Action OnClientSayCommand(int client, string command, string sArgs) { throw new NotImplementedException(); }

		/**
		 * Global post listener for the chat commands.
		 *
		 * @param client        Client index.
		 * @param command       Command name.
		 * @param sArgs         Chat argument string.
		 */
		public virtual void OnClientSayCommand_Post(int client, string command, string sArgs) { throw new NotImplementedException(); }
	}
}