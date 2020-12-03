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
		 * Network flow directions.
		 */
		public enum NetFlow
		{
			NetFlow_Outgoing = 0,   /**< Outgoing traffic */
			NetFlow_Incoming,       /**< Incoming traffic */
			NetFlow_Both            /**< Both values added together */
		};

		/**
		 * Auth string types.
		 *
		 * Note that for the Steam2 and Steam3 types, the following ids are
		 * also valid values:
		 * "STEAM_ID_PENDING" - Authentication is pending.
		 * "STEAM_ID_LAN" - Authentication is disabled because of being on a LAN server.
		 * "BOT" - The client is a bot.
		 */
		public enum AuthIdType
		{
			AuthId_Engine = 0,     /**< The game-specific auth string as returned from the engine */

			// The following are only available on games that support Steam authentication.
			AuthId_Steam2,         /**< Steam2 rendered format, ex "STEAM_1:1:4153990" */
			AuthId_Steam3,         /**< Steam3 rendered format, ex "[U:1:8307981]" */
			AuthId_SteamID64       /**< A SteamID64 (uint64) as a String, ex "76561197968573709" */
		};

		/**
		 * MAXPLAYERS is not the same as MaxClients.
		 * MAXPLAYERS is a hardcoded value as an upper limit.  MaxClients changes based on the server.
		 */

		public const int MAXPLAYERS = 65;  /**< Maximum number of players SourceMod supports */
		public const int MAX_NAME_LENGTH = 128; /**< Maximum buffer required to store a client name */

		public static int MaxClients => GetMaxClients();   /**< Maximum number of players the server supports (dynamic) */

		/**
		 * Called on client connection.  If you return true, the client will be allowed in the server.
		 * If you return false (or return nothing), the client will be rejected.  If the client is 
		 * rejected by this public virtual or any other, OnClientDisconnect will not be called.
		 *
		 * Note: Do not write to rejectmsg if you plan on returning true.  If multiple plugins write
		 * to the string buffer, it is not defined which plugin's string will be shown to the client,
		 * but it is guaranteed one of them will.
		 *
		 * @param client        Client index.
		 * @param rejectmsg     Buffer to store the rejection message when the connection is refused.
		 * @param maxlen        Maximum number of characters for rejection buffer.
		 * @return              True to validate client's connection, false to refuse it.
		 */
		public virtual bool OnClientConnect(int client, string rejectmsg, int maxlen) { throw new NotImplementedException(); }

		/**
		 * Called once a client successfully connects.  This callback is paired with OnClientDisconnect.
		 *
		 * @param client        Client index.
		 */
		public virtual void OnClientConnected(int client) { throw new NotImplementedException(); }

		/**
		 * Called when a client is entering the game.
		 *
		 * Whether a client has a steamid is undefined until OnClientAuthorized
		 * is called, which may occur either before or after OnClientPutInServer.
		 * Similarly, use OnClientPostAdminCheck() if you need to verify whether 
		 * connecting players are admins.
		 *
		 * GetClientCount() will include clients as they are passed through this 
		 * function, as clients are already in game at this point.
		 *
		 * @param client        Client index.
		 */
		public virtual void OnClientPutInServer(int client) { throw new NotImplementedException(); }

		/**
		 * Called when a client is disconnecting from the server.
		 *
		 * @param client        Client index.
		 */
		public virtual void OnClientDisconnect(int client) { throw new NotImplementedException(); }

		/**
		 * Called when a client is disconnected from the server.
		 *
		 * @param client        Client index.
		 */
		public virtual void OnClientDisconnect_Post(int client) { throw new NotImplementedException(); }

		/**
		 * Called when a client is sending a command.
		 *
		 * As of SourceMod 1.3, the client is guaranteed to be in-game.
		 * Use command listeners (console.inc) for more advanced hooks.
		 *
		 * @param client        Client index.
		 * @param args          Number of arguments.
		 * @return              Plugin_Handled blocks the command from being sent,
		 *                      and Plugin_Continue resumes normal functionality.
		 */
		public virtual Action OnClientCommand(int client, int args) { throw new NotImplementedException(); }

		/**
		 * Called when a client is sending a KeyValues command.
		 *
		 * @param client        Client index.
		 * @param kv            Editable KeyValues data to be sent as the command.
		 *                      (This handle should not be stored and will be closed
		 *                      after this public virtual completes.)
		 * @return              Plugin_Handled blocks the command from being sent,
		 *                      and Plugin_Continue resumes normal functionality.
		 */
		public virtual Action OnClientCommandKeyValues(int client, KeyValues kv) { throw new NotImplementedException(); }

		/**
		 * Called after a client has sent a KeyValues command.
		 *
		 * @param client        Client index.
		 * @param kv            KeyValues data sent as the command.
		 *                      (This handle should not be stored and will be closed
		 *                      after this public virtual completes.)
		 */
		public virtual void OnClientCommandKeyValues_Post(int client, KeyValues kv) { throw new NotImplementedException(); }

		/**
		 * Called whenever the client's settings are changed.
		 *
		 * @param client        Client index.
		 */
		public virtual void OnClientSettingsChanged(int client) { throw new NotImplementedException(); }

		/**
		 * Called when a client receives an auth ID.  The state of a client's 
		 * authorization as an admin is not guaranteed here.  Use 
		 * OnClientPostAdminCheck() if you need a client's admin status.
		 *
		 * This is called by bots, but the ID will be "BOT".
		 *
		 * @param client        Client index.
		 * @param auth          Client Steam2 id, if available, else engine auth id.
		 */
		public virtual void OnClientAuthorized(int client, string auth) { throw new NotImplementedException(); }

		/**
		 * Called once a client is authorized and fully in-game, but 
		 * before admin checks are done.  This can be used to override 
		 * the default admin checks for a client.  You should only use 
		 * this for overriding; use OnClientPostAdminCheck() instead 
		 * if you want notification.
		 *
		 * Note: If handled/blocked, PostAdminCheck must be signalled 
		 * manually via NotifyPostAdminCheck().
		 *
		 * This callback is guaranteed to occur on all clients, and always 
		 * after each OnClientPutInServer() call.
		 *
		 * @param client        Client index.
		 * @return              Plugin_Handled to block admin checks.
		 */
		public virtual Action OnClientPreAdminCheck(int client) { throw new NotImplementedException(); }

		/**
		 * Called directly before OnClientPostAdminCheck() as a method to 
		 * alter administrative permissions before plugins perform final 
		 * post-connect operations.  
		 *
		 * In general, do not use this function unless you are specifically 
		 * attempting to change access permissions.  Use OnClientPostAdminCheck() 
		 * instead if you simply want to perform post-connect authorization 
		 * routines.
		 *
		 * See OnClientPostAdminCheck() for more information.
		 *
		 * @param client        Client index.
		 */
		public virtual void OnClientPostAdminFilter(int client) { throw new NotImplementedException(); }

		/**
		 * Called once a client is authorized and fully in-game, and 
		 * after all post-connection authorizations have been performed.  
		 *
		 * This callback is guaranteed to occur on all clients, and always 
		 * after each OnClientPutInServer() call.
		 *
		 * @param client        Client index.
		 */
		public virtual void OnClientPostAdminCheck(int client) { throw new NotImplementedException(); }

		/**
		 * This function is deprecated. Use the MaxClients variable instead.
		 *
		 * Returns the maximum number of clients allowed on the server.  This may 
		 * return 0 if called before OnMapStart(), and thus should not be called 
		 * in OnPluginStart().  
		 *
		 * You should not globally cache the value to GetMaxClients() because it can change from 
		 * SourceTV or TF2's arena mode.  Use the "MaxClients" dynamic variable documented at the 
		 * top of this file.
		 *
		 * @return              Maximum number of clients allowed.
		 */
		private static int GetMaxClients() { throw new NotImplementedException(); }

		/**
		 * Returns the maximum number of human players allowed on the server.  This is 
		 * a game-specific function used on newer games to limit the number of humans
		 * that can join a game and can be lower than MaxClients. It is the number often
		 * reflected in the server browser or when viewing the output of the status command.
		 * On unsupported games or modes without overrides, it will return the same value
		 * as MaxClients.
		 *
		 * You should not globally cache the value to GetMaxHumanPlayers() because it can change across
		 * game modes. You may still cache it locally.
		 *
		 * @return              Maximum number of humans allowed.
		 */
		public static int GetMaxHumanPlayers() { throw new NotImplementedException(); }

		/**
		 * Returns the client count put in the server.
		 *
		 * @param inGameOnly    If false connecting players are also counted.
		 * @return              Client count in the server.
		 */
		public static int GetClientCount(bool inGameOnly = true) { throw new NotImplementedException(); }

		/**
		 * Returns the client's name.
		 *
		 * @param client        Player index.
		 * @param name          Buffer to store the client's name.
		 * @param maxlen        Maximum length of string buffer (includes NULL terminator).
		 * @return              True on success, false otherwise.
		 * @error               If the client is not connected an error will be thrown.
		 */
		public static bool GetClientName(int client, string name, int maxlen) { throw new NotImplementedException(); }

		/**
		 * Retrieves a client's IP address.
		 *
		 * @param client        Player index.
		 * @param ip            Buffer to store the client's ip address.
		 * @param maxlen        Maximum length of string buffer (includes NULL terminator).
		 * @param remport       Remove client's port from the ip string (true by default).
		 * @return              True on success, false otherwise.
		 * @error               If the client is not connected or the index is invalid.
		 */
		public static bool GetClientIP(int client, string ip, int maxlen, bool remport = true) { throw new NotImplementedException(); }

		/**
		 * Retrieves a client's authentication string (SteamID).
		 *
		 * @param client        Player index.
		 * @param authType      Auth id type and format to use.
		 * @param auth          Buffer to store the client's auth id.
		 * @param maxlen        Maximum length of string buffer (includes NULL terminator).
		 * @param validate      Check backend validation status.
		 *                      DO NOT PASS FALSE UNLESS YOU UNDERSTAND THE CONSEQUENCES,
		 *                      You WILL KNOW if you need to use this, MOST WILL NOT.
		 * @return              True on success, false otherwise.
		 * @error               If the client is not connected or the index is invalid.
		 */
		public static bool GetClientAuthId(int client, AuthIdType authType, string auth, int maxlen, bool validate = true) { throw new NotImplementedException(); }

		/**
		 * Returns the client's Steam account ID, a number uniquely identifying a given Steam account.
		 * This number is the basis for the various display SteamID forms, see the AuthIdType public enum for examples.
		 *
		 * @param client        Client Index.
		 * @param validate      Check backend validation status.
		 *                      DO NOT PASS FALSE UNLESS YOU UNDERSTAND THE CONSEQUENCES,
		 *                      You WILL KNOW if you need to use this, MOST WILL NOT.
		 * @return              Steam account ID or 0 if not available.
		 * @error               If the client is not connected or the index is invalid.
		 */
		public static int GetSteamAccountID(int client, bool validate = true) { throw new NotImplementedException(); }

		/**
		 * Retrieves a client's user id, which is an index incremented for every client
		 * that joins the server.
		 *
		 * @param client        Player index.
		 * @return              User id of the client.
		 * @error               If the client is not connected or the index is invalid.
		 */
		public static int GetClientUserId(int client) { throw new NotImplementedException(); }

		/**
		 * Returns if a certain player is connected.
		 *
		 * @param client        Player index.
		 * @return              True if player is connected to the server, false otherwise.
		 */
		public static bool IsClientConnected(int client) { throw new NotImplementedException(); }

		/**
		 * Returns if a certain player has entered the game.
		 *
		 * @param client        Player index (index does not have to be connected).
		 * @return              True if player has entered the game, false otherwise.
		 * @error               Invalid client index.
		 */
		public static bool IsClientInGame(int client) { throw new NotImplementedException(); }

		/**
		 * Returns if a client is in the "kick queue" (i.e. the client will be kicked 
		 * shortly and thus they should not appear as valid).
		 *
		 * @param client        Player index (must be connected).
		 * @return              True if in the kick queue, false otherwise.
		 * @error               Invalid client index.
		 */
		public static bool IsClientInKickQueue(int client) { throw new NotImplementedException(); }

		/**
		 * Returns if a certain player has been authenticated.
		 *
		 * @param client        Player index.
		 * @return              True if player has been authenticated, false otherwise.
		 */
		public static bool IsClientAuthorized(int client) { throw new NotImplementedException(); }

		/**
		 * Returns if a certain player is a fake client.
		 *
		 * @param client        Player index.
		 * @return              True if player is a fake client, false otherwise.
		 */
		public static bool IsFakeClient(int client) { throw new NotImplementedException(); }

		/**
		 * Returns if a certain player is the SourceTV bot.
		 *
		 * @param client        Player index.
		 * @return              True if player is the SourceTV bot, false otherwise.
		 */
		public static bool IsClientSourceTV(int client) { throw new NotImplementedException(); }

		/**
		 * Returns if a certain player is the Replay bot.
		 *
		 * @param client        Player index.
		 * @return              True if player is the Replay bot, false otherwise.
		 */
		public static bool IsClientReplay(int client) { throw new NotImplementedException(); }

		/**
		 * Returns if a certain player is an observer/spectator.
		 *
		 * @param client        Player index.
		 * @return              True if player is an observer, false otherwise.
		 */
		public static bool IsClientObserver(int client) { throw new NotImplementedException(); }

		/**
		 * Returns if the client is alive or dead.
		 *
		 * Note: This function was originally in SDKTools and was moved to core.
		 *
		 * @param client        Player's index.
		 * @return              True if the client is alive, false otherwise.
		 * @error               Invalid client index, client not in game, or no mod support.
		 */
		public static bool IsPlayerAlive(int client) { throw new NotImplementedException(); }

		/**
		 * Retrieves values from client replicated keys.
		 *
		 * @param client        Player's index.
		 * @param key           Key string.
		 * @param value         Buffer to store value.
		 * @param maxlen        Maximum length of valve (UTF-8 safe).
		 * @return              True on success, false otherwise.
		 * @error               Invalid client index, or client not connected.
		 */
		public static bool GetClientInfo(int client, string key, string value, int maxlen) { throw new NotImplementedException(); }

		/**
		 * Retrieves a client's team index.
		 *
		 * @param client        Player's index.
		 * @return              Team index the client is on (mod specific).
		 * @error               Invalid client index, client not in game, or no mod support.
		 */
		public static int GetClientTeam(int client) { throw new NotImplementedException(); }

		/**
		 * Sets a client's AdminId.  
		 *
		 * @param client        Player's index.
		 * @param id            AdminId to set.  INVALID_ADMIN_ID removes admin permissions.
		 * @param temp          True if the id should be freed on disconnect.
		 * @error               Invalid client index, client not connected, or bogus AdminId.
		 */
		public static void SetUserAdmin(int client, AdminId id, bool temp = false) { throw new NotImplementedException(); }

		/**
		 * Retrieves a client's AdminId.
		 *
		 * @param client        Player's index.
		 * @return              AdminId of the client, or INVALID_ADMIN_ID if none.
		 * @error               Invalid client index, or client not connected.
		 */
		public static AdminId GetUserAdmin(int client) { throw new NotImplementedException(); }

		/**
		 * Sets access flags on a client.  If the client is not an admin,
		 * a temporary, anonymous AdminId is given.
		 *
		 * @param client        Player's index.
		 * @param ...           Flags to set on the client.
		 * @error               Invalid client index, or client not connected.
		 */
		public static void AddUserFlags(int client, params AdminFlag[] args) { throw new NotImplementedException(); }

		/**
		 * Removes flags from a client.  If the client is not an admin,
		 * this has no effect.
		 *
		 * @param client        Player's index.
		 * @param ...           Flags to remove from the client.
		 * @error               Invalid client index, or client not connected.
		 */
		public static void RemoveUserFlags(int client, params AdminFlag[] args) { throw new NotImplementedException(); }

		/** 
		 * Sets access flags on a client using bits instead of flags.  If the
		 * client is not an admin, and flags not 0, a temporary, anonymous AdminId is given.
		 *
		 * @param client        Player's index.
		 * @param flags         Bitstring of flags to set on client.
		 */
		public static void SetUserFlagBits(int client, int flags) { throw new NotImplementedException(); }

		/**
		 * Returns client access flags.  If the client is not an admin,
		 * the result is always 0.
		 * 
		 * @param client        Player's index.
		 * @return              Flags
		 * @error               Invalid client index, or client not connected.
		 */
		public static int GetUserFlagBits(int client) { throw new NotImplementedException(); }

		/**
		 * Returns whether a user can target another user.
		 * This is a helper function for CanAdminTarget.
		 *
		 * @param client        Player's index.
		 * @param target        Target player's index.
		 * @return              True if target is targettable by the player, false otherwise.
		 * @error               Invalid or unconnected player indexers.
		 */
		public static bool CanUserTarget(int client, int target) { throw new NotImplementedException(); }

		/**
		 * Runs through the Core-defined admin authorization checks on a player.
		 * Has no effect if the player is already an admin.
		 *
		 * Note: This function is based on the internal cache only.
		 *
		 * @param client        Client index.
		 * @return              True if access was changed, false if it did not.
		 * @error               Invalid client index or client not in-game AND authorized.
		 */
		public static bool RunAdminCacheChecks(int client) { throw new NotImplementedException(); }

		/**
		 * Signals that a player has completed post-connection admin checks.
		 * Has no effect if the player has already had this event signalled.
		 *
		 * Note: This must be sent even if no admin id was assigned.
		 *
		 * @param client        Client index.
		 * @error               Invalid client index or client not in-game AND authorized.
		 */
		public static void NotifyPostAdminCheck(int client) { throw new NotImplementedException(); }

		/** 
		 * Creates a fake client.
		 *
		 * @param name          Name to use.
		 * @return              Client index on success, 0 otherwise.
		 */
		public static int CreateFakeClient(string name) { throw new NotImplementedException(); }

		/**
		 * Sets a convar value on a fake client.
		 *
		 * @param client        Client index.
		 * @param cvar          ConVar name.
		 * @param value         ConVar value.
		 * @error               Invalid client index, client not connected,
		 *                      or client not a fake client.
		 */
		public static void SetFakeClientConVar(int client, string cvar, string value) { throw new NotImplementedException(); }

		/**
		 * Returns the client's health.
		 *
		 * @param client        Player's index.
		 * @return              Health value.
		 * @error               Invalid client index, client not in game, or no mod support.
		 */
		public static int GetClientHealth(int client) { throw new NotImplementedException(); }

		/**
		 * Returns the client's model name.
		 *
		 * @param client        Player's index.
		 * @param model         Buffer to store the client's model name.
		 * @param maxlen        Maximum length of string buffer (includes NULL terminator).
		 * @error               Invalid client index, client not in game, or no mod support.
		 */
		public static void GetClientModel(int client, string model, int maxlen) { throw new NotImplementedException(); }

		/**
		 * Returns the client's weapon name.
		 *
		 * @param client        Player's index.
		 * @param weapon        Buffer to store the client's weapon name.
		 * @param maxlen        Maximum length of string buffer (includes NULL terminator).
		 * @error               Invalid client index, client not in game, or no mod support.
		 */
		public static void GetClientWeapon(int client, string weapon, int maxlen) { throw new NotImplementedException(); }

		/**
		 * Returns the client's max size vector.
		 *
		 * @param client        Player's index.
		 * @param vec           Destination vector to store the client's max size.
		 * @error               Invalid client index, client not in game, or no mod support.
		 */
		public static void GetClientMaxs(int client, float[] vec) { throw new NotImplementedException(); }

		/**
		 * Returns the client's min size vector.
		 *
		 * @param client        Player's index.
		 * @param vec           Destination vector to store the client's min size.
		 * @error               Invalid client index, client not in game, or no mod support.
		 */
		public static void GetClientMins(int client, float[] vec) { throw new NotImplementedException(); }

		/**
		 * Returns the client's position angle.
		 *
		 * @param client        Player's index.
		 * @param ang           Destination vector to store the client's position angle.
		 * @error               Invalid client index, client not in game, or no mod support.
		 */
		public static void GetClientAbsAngles(int client, float[] ang) { throw new NotImplementedException(); }

		/**
		 * Returns the client's origin vector.
		 *
		 * @param client        Player's index.
		 * @param vec           Destination vector to store the client's origin vector.
		 * @error               Invalid client index, client not in game, or no mod support.
		 */
		public static void GetClientAbsOrigin(int client, float[] vec) { throw new NotImplementedException(); }

		/**
		 * Returns the client's armor.
		 *
		 * @param client        Player's index.
		 * @return              Armor value.
		 * @error               Invalid client index, client not in game, or no mod support.
		 */
		public static int GetClientArmor(int client) { throw new NotImplementedException(); }

		/**
		 * Returns the client's death count.
		 *
		 * @param client        Player's index.
		 * @return              Death count.
		 * @error               Invalid client index, client not in game, or no mod support.
		 */
		public static int GetClientDeaths(int client) { throw new NotImplementedException(); }

		/**
		 * Returns the client's frag count.
		 *
		 * @param client        Player's index.
		 * @return              Frag count.
		 * @error               Invalid client index, client not in game, or no mod support.
		 */
		public static int GetClientFrags(int client) { throw new NotImplementedException(); }

		/**
		 * Returns the client's send data rate in bytes/sec.
		 *
		 * @param client        Player's index.
		 * @return              Data rate.
		 * @error               Invalid client index, client not connected, or fake client.
		 */
		public static int GetClientDataRate(int client) { throw new NotImplementedException(); }

		/**
		 * Returns if a client is timing out
		 *
		 * @param client        Player's index.
		 * @return              True if client is timing out, false otherwise.
		 * @error               Invalid client index, client not connected, or fake client.
		 */
		public static bool IsClientTimingOut(int client) { throw new NotImplementedException(); }

		/**
		 * Returns the client's connection time in seconds.
		 *
		 * @param client        Player's index.
		 * @return              Connection time.
		 * @error               Invalid client index, client not connected, or fake client.
		 */
		public static float GetClientTime(int client) { throw new NotImplementedException(); }

		/**
		 * Returns the client's current latency (RTT), more accurate than GetAvgLatency but jittering.
		 *
		 * @param client        Player's index.
		 * @param flow          Traffic flowing direction.
		 * @return              Latency, or -1 if network info is not available.
		 * @error               Invalid client index, client not connected, or fake client.
		 */
		public static float GetClientLatency(int client, NetFlow flow) { throw new NotImplementedException(); }

		/**
		 * Returns the client's average packet latency in seconds.
		 *
		 * @param client        Player's index.
		 * @param flow          Traffic flowing direction.
		 * @return              Latency, or -1 if network info is not available.
		 * @error               Invalid client index, client not connected, or fake client.
		 */
		public static float GetClientAvgLatency(int client, NetFlow flow) { throw new NotImplementedException(); }

		/**
		 * Returns the client's average packet loss, values go from 0 to 1 (for percentages).
		 *
		 * @param client        Player's index.
		 * @param flow          Traffic flowing direction.
		 * @return              Average packet loss, or -1 if network info is not available.
		 * @error               Invalid client index, client not connected, or fake client.
		 */
		public static float GetClientAvgLoss(int client, NetFlow flow) { throw new NotImplementedException(); }

		/**
		 * Returns the client's average packet choke, values go from 0 to 1 (for percentages).
		 *
		 * @param client        Player's index.
		 * @param flow          Traffic flowing direction.
		 * @return              Average packet loss, or -1 if network info is not available.
		 * @error               Invalid client index, client not connected, or fake client.
		 */
		public static float GetClientAvgChoke(int client, NetFlow flow) { throw new NotImplementedException(); }

		/**
		 * Returns the client's data flow in bytes/sec.
		 *
		 * @param client        Player's index.
		 * @param flow          Traffic flowing direction.
		 * @return              Data flow.
		 * @error               Invalid client index, client not connected, or fake client.
		 */
		public static float GetClientAvgData(int client, NetFlow flow) { throw new NotImplementedException(); }

		/**
		 * Returns the client's average packet frequency in packets/sec.
		 *
		 * @param client        Player's index.
		 * @param flow          Traffic flowing direction.
		 * @return              Packet frequency.
		 * @error               Invalid client index, client not connected, or fake client.
		 */
		public static float GetClientAvgPackets(int client, NetFlow flow) { throw new NotImplementedException(); }

		/**
		 * Translates an userid index to the real player index.
		 *
		 * @param userid        Userid value.
		 * @return              Client value.
		 * @error               Returns 0 if invalid userid.
		 */
		public static int GetClientOfUserId(int userid) { throw new NotImplementedException(); }

		/**
		 * Disconnects a client from the server as soon as the next frame starts.
		 *
		 * Note: Originally, KickClient() was immediate.  The delay was introduced 
		 * because despite warnings, plugins were using it in ways that would crash. 
		 * The new safe version can break cases that rely on immediate disconnects, 
		 * but ensures that plugins do not accidentally cause crashes.
		 *
		 * If you need immediate disconnects, use KickClientEx().
		 *
		 * Note: IsClientInKickQueue() will return true before the kick occurs.
		 *
		 * @param client        Client index.
		 * @param format        Optional formatting rules for disconnect reason.
		 *                      Note that a period is automatically appended to the string by the engine.
		 * @param ...           Variable number of format parameters.
		 * @error               Invalid client index, or client not connected.
		 */
		public static void KickClient(int client, string format = "", params object[] args) { throw new NotImplementedException(); }

		/**
		 * Immediately disconnects a client from the server.
		 *
		 * Kicking clients from certain events or callbacks may cause crashes.  If in 
		 * doubt, create a short (0.1 second) timer to kick the client in the next 
		 * available frame.
		 *
		 * @param client        Client index.
		 * @param format        Optional formatting rules for disconnect reason.
		 *                      Note that a period is automatically appended to the string by the engine.
		 * @param ...           Variable number of format parameters.
		 * @error               Invalid client index, or client not connected.
		 */
		public static void KickClientEx(int client, string format = "", params object[] args) { throw new NotImplementedException(); }

		/**
		 * Changes a client's team through the mod's generic team changing function.
		 * On CS:S, this will kill the player.
		 *
		 * @param client        Client index.
		 * @param team          Mod-specific team index.
		 * @error               Invalid client index, client not connected, or lack of 
		 *                      mod support.
		 */
		public static void ChangeClientTeam(int client, int team) { throw new NotImplementedException(); }

		/**
		 * Returns the clients unique serial identifier.
		 *
		 * @param client        Client index.
		 * @return              Serial number.
		 * @error               Invalid client index, or client not connected.
		 */
		public static int GetClientSerial(int client) { throw new NotImplementedException(); }

		/**
		 * Returns the client index by its serial number.
		 *
		 * @param serial        Serial number.
		 * @return              Client index, or 0 for invalid serial.
		 */
		public static int GetClientFromSerial(int serial) { throw new NotImplementedException(); }
	}
}