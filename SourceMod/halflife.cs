/**
 * vim: set ts=4 :
 * =============================================================================
 * SourceMod (C)2004-2016 AlliedModders LLC.  All rights reserved.
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

		public const int SOURCE_SDK_UNKNOWN = 0;      /**< Could not determine the engine version */
		public const int SOURCE_SDK_ORIGINAL = 10;      /**< Original Source engine (still used by "The Ship") */
		public const int SOURCE_SDK_DARKMESSIAH = 15;      /**< Modified version of original engine used by Dark Messiah (no SDK) */
		public const int SOURCE_SDK_EPISODE1 = 20;      /**< SDK+Engine released after Episode 1 */
		public const int SOURCE_SDK_EPISODE2 = 30;      /**< SDK+Engine released after Episode 2/Orange Box */
		public const int SOURCE_SDK_BLOODYGOODTIME = 32;      /**< Modified version of ep2 engine used by Bloody Good Time (no SDK) */
		public const int SOURCE_SDK_EYE = 33;      /**< Modified version of ep2 engine used by E.Y.E Divine Cybermancy (no SDK) */
		public const int SOURCE_SDK_CSS = 34;      /**< Sometime-older version of Source 2009 SDK+Engine, used for Counter-Strike: Source */
		public const int SOURCE_SDK_EPISODE2VALVE = 35;      /**< SDK+Engine released after Episode 2/Orange Box, "Source 2009" or "Source MP" */
		public const int SOURCE_SDK_LEFT4DEAD = 40;      /**< Engine released after Left 4 Dead (no SDK yet) */
		public const int SOURCE_SDK_LEFT4DEAD2 = 50;      /**< Engine released after Left 4 Dead 2 (no SDK yet) */
		public const int SOURCE_SDK_ALIENSWARM = 60;      /**< SDK+Engine released after Alien Swarm */
		public const int SOURCE_SDK_CSGO = 80;      /**< Engine released after CS:GO (no SDK yet) */
		public const int SOURCE_SDK_DOTA = 90;      /**< Engine released after Dota 2 (no SDK) */

		public const int MOTDPANEL_TYPE_TEXT = 0;     /**< Treat msg as plain text */
		public const int MOTDPANEL_TYPE_INDEX = 1;     /**< Msg is auto determined by the engine */
		public const int MOTDPANEL_TYPE_URL = 2;     /**< Treat msg as an URL link */
		public const int MOTDPANEL_TYPE_FILE = 3;     /**< Treat msg as a filename to be opened */

		public enum DialogType
		{
			DialogType_Msg = 0,     /**< just an on screen message */
			DialogType_Menu,        /**< an options menu */
			DialogType_Text,        /**< a richtext dialog */
			DialogType_Entry,       /**< an entry box */
			DialogType_AskConnect   /**< ask the client to connect to a specified IP */
		};
		public const int
			DialogType_Msg = 0,     /**< just an on screen message */
			DialogType_Menu = 1,        /**< an options menu */
			DialogType_Text = 2,        /**< a richtext dialog */
			DialogType_Entry = 3,       /**< an entry box */
			DialogType_AskConnect = 4;   /**< ask the client to connect to a specified IP */

		public enum EngineVersion
		{
			Engine_Unknown,             /**< Could not determine the engine version */
			Engine_Original,            /**< Original Source Engine (used by The Ship) */
			Engine_SourceSDK2006,       /**< Episode 1 Source Engine (second major SDK) */
			Engine_SourceSDK2007,       /**< Orange Box Source Engine (third major SDK) */
			Engine_Left4Dead,           /**< Left 4 Dead */
			Engine_DarkMessiah,         /**< Dark Messiah Multiplayer (based on original engine) */
			Engine_Left4Dead2 = 7,      /**< Left 4 Dead 2 */
			Engine_AlienSwarm,          /**< Alien Swarm (and Alien Swarm SDK) */
			Engine_BloodyGoodTime,      /**< Bloody Good Time */
			Engine_EYE,                 /**< E.Y.E Divine Cybermancy */
			Engine_Portal2,             /**< Portal 2 */
			Engine_CSGO,                /**< Counter-Strike: Global Offensive */
			Engine_CSS,                 /**< Counter-Strike: Source */
			Engine_DOTA,                /**< Dota 2 */
			Engine_HL2DM,               /**< Half-Life 2 Deathmatch */
			Engine_DODS,                /**< Day of Defeat: Source */
			Engine_TF2,                 /**< Team Fortress 2 */
			Engine_NuclearDawn,         /**< Nuclear Dawn */
			Engine_SDK2013,             /**< Source SDK 2013 */
			Engine_Blade,               /**< Blade Symphony */
			Engine_Insurgency,          /**< Insurgency (2013 Retail version)*/
			Engine_Contagion,           /**< Contagion */
			Engine_BlackMesa,           /**< Black Mesa Multiplayer */
			Engine_DOI                  /**< Day of Infamy */
		};
		public const int
			Engine_Unknown = 0,             /**< Could not determine the engine version */
			Engine_Original = 1,            /**< Original Source Engine (used by The Ship) */
			Engine_SourceSDK2006 = 2,       /**< Episode 1 Source Engine (second major SDK) */
			Engine_SourceSDK2007 = 3,       /**< Orange Box Source Engine (third major SDK) */
			Engine_Left4Dead = 4,           /**< Left 4 Dead */
			Engine_DarkMessiah = 5,         /**< Dark Messiah Multiplayer (based on original engine) */
			Engine_Left4Dead2 = 7,      /**< Left 4 Dead 2 */
			Engine_AlienSwarm = 8,          /**< Alien Swarm (and Alien Swarm SDK) */
			Engine_BloodyGoodTime = 9,      /**< Bloody Good Time */
			Engine_EYE = 10,                 /**< E.Y.E Divine Cybermancy */
			Engine_Portal2 = 11,             /**< Portal 2 */
			Engine_CSGO = 12,                /**< Counter-Strike: Global Offensive */
			Engine_CSS = 13,                 /**< Counter-Strike: Source */
			Engine_DOTA = 14,                /**< Dota 2 */
			Engine_HL2DM = 15,               /**< Half-Life 2 Deathmatch */
			Engine_DODS = 16,                /**< Day of Defeat: Source */
			Engine_TF2 = 17,                 /**< Team Fortress 2 */
			Engine_NuclearDawn = 18,         /**< Nuclear Dawn */
			Engine_SDK2013 = 19,             /**< Source SDK 2013 */
			Engine_Blade = 20,               /**< Blade Symphony */
			Engine_Insurgency = 21,          /**< Insurgency (2013 Retail version)*/
			Engine_Contagion = 22,           /**< Contagion */
			Engine_BlackMesa = 23,           /**< Black Mesa Multiplayer */
			Engine_DOI = 24;                  /**< Day of Infamy */

		public enum FindMapResult
		{
			// A direct match for this name was found
			FindMap_Found,
			// No match for this map name could be found.
			FindMap_NotFound,
			// A fuzzy match for this map name was found.
			// Ex: cp_dust -> cp_dustbowl, c1m1 -> c1m1_hotel
			// Only supported for maps that the engine knows about. (This excludes workshop maps on Orangebox).
			FindMap_FuzzyMatch,
			// A non-canonical match for this map name was found.
			// Ex: workshop/1234 -> workshop/cp_qualified_name.ugc1234
			// Only supported on "Orangebox" games with workshop support.
			FindMap_NonCanonical,
			// No currently available match for this map name could be found, but it may be possible to load
			// Only supported on "Orangebox" games with workshop support.
			FindMap_PossiblyAvailable
		};
		public const int
			// A direct match for this name was found
			FindMap_Found = 0,
			// No match for this map name could be found.
			FindMap_NotFound = 1,
			// A fuzzy match for this map name was found.
			// Ex: cp_dust -> cp_dustbowl, c1m1 -> c1m1_hotel
			// Only supported for maps that the engine knows about. (This excludes workshop maps on Orangebox).
			FindMap_FuzzyMatch = 2,
			// A non-canonical match for this map name was found.
			// Ex: workshop/1234 -> workshop/cp_qualified_name.ugc1234
			// Only supported on "Orangebox" games with workshop support.
			FindMap_NonCanonical = 3,
			// No currently available match for this map name could be found, but it may be possible to load
			// Only supported on "Orangebox" games with workshop support.
			FindMap_PossiblyAvailable = 4;

		public const uint INVALID_ENT_REFERENCE = 0xFFFFFFFF;

		/**
		 * Logs a generic message to the HL2 logs.
		 *
		 * @param format        String format.
		 * @param ...           Format arguments.
		 */
		public static void LogToGame(string format, params object[] args) { throw new NotImplementedException(); }

		/**
		 * Sets the seed value for the global Half-Life 2 Random Stream.
		 *
		 * @param seed         Seed value.
		 */
		public static void SetRandomSeed(int seed) { throw new NotImplementedException(); }

		/**
		 * Returns a random floating point number from the Half-Life 2 Random Stream.
		 *
		 * @param fMin          Minimum random bound.
		 * @param fMax          Maximum random bound.
		 * @return              A random number between (inclusive) fMin and fMax.
		 */
		public static float GetRandomFloat(float fMin = 0.0f, float fMax = 1.0f) { throw new NotImplementedException(); }

		/**
		 * Returns a random number from the Half-Life 2 Random Stream.
		 *
		 * @param nmin          Minimum random bound.
		 * @param nmax          Maximum random bound.
		 * @return              A random number between (inclusive) nmin and nmax.
		 */
		public static int GetRandomInt(int nmin, int nmax) { throw new NotImplementedException(); }

		/**
		 * Returns whether a map is valid or not.
		 *
		 * @param map           Map name, excluding .bsp extension.
		 * @return              True if valid, false otherwise.
		 */
		public static bool IsMapValid(string map) { throw new NotImplementedException(); }

		/**
		 * Returns whether a full or partial map name is found or can be resolved
		 *
		 * @param map           Map name (usually same as map path relative to maps/ dir,
		 *                      excluding .bsp extension).
		 * @param foundmap      Resolved map name. If the return is FindMap_FuzzyMatch
		 *                      or FindMap_NonCanonical the buffer will be the full path.
		 * @param maxlen        Maximum length to write to map var.
		 * @return              Result of the find operation. Not all result types are supported on all games.
		 */
		public static FindMapResult FindMap(string map, string foundmap, int maxlen) { throw new NotImplementedException(); }

		/**
		 * Get the display name of a workshop map.
		 *
		 * Note: You do not need to call FindMap first.  This public static will call FindMap internally.
		 *
		 * @param map           Map name (usually same as map path relative to maps/ dir,
		 *                      excluding .bsp extension).
		 * @param displayName   Map's display name, i.e. cp_mymapname or de_mymapname.
		 *                      If FindMap returns FindMap_PossiblyAvailable or FindMap_NotFound,
		 *                      the map cannot be resolved and this public static will return false,
		 *                      but displayName will be a copy of map.
		 * @param maxlen        Maximum length to write to displayName var.
		 * @return              true if FindMap returns FindMap_Found, FindMap_FuzzyMatch, or
		 *                      FindMap_NonCanonical.
		 *                      false if FindMap returns FindMap_PossiblyAvailable or FindMap_NotFound.
		 */
		public static bool GetMapDisplayName(string map, string displayName, int maxlen) { throw new NotImplementedException(); }

		/**
		 * Returns whether the server is dedicated.
		 *
		 * @return              True if dedicated, false otherwise.
		 */
		public static bool IsDedicatedServer() { throw new NotImplementedException(); }

		/**
		 * Returns a high-precision time value for profiling the engine.
		 *
		 * @return              A floating point time value.
		 */
		public static float GetEngineTime() { throw new NotImplementedException(); }

		/**
		 * Returns the game time based on the game tick.
		 *
		 * @return              Game tick time.
		 */
		public static float GetGameTime() { throw new NotImplementedException(); }

		/**
		 * Returns the game's internal tick count.
		 *
		 * @return              Game tick count.
		 */
		public static int GetGameTickCount() { throw new NotImplementedException(); }

		/**
		 * Returns the time the Game took processing the last frame.
		 *
		 * @return              Game frame time.
		 */
		public static float GetGameFrameTime() { throw new NotImplementedException(); }

		/**
		 * Returns the game description from the mod.
		 *
		 * @param buffer        Buffer to store the description.
		 * @param maxlength     Maximum size of the buffer.
		 * @param original      If true, retrieves the original game description,
		 *                      ignoring any potential hooks from plugins.
		 * @return              Number of bytes written to the buffer (UTF-8 safe).
		 */
		public static int GetGameDescription(string buffer, int maxlength, bool original = false) { throw new NotImplementedException(); }

		/**
		 * Returns the name of the game's directory.
		 *
		 * @param buffer        Buffer to store the directory name.
		 * @param maxlength     Maximum size of the buffer.
		 * @return              Number of bytes written to the buffer (UTF-8 safe).
		 */
		public static int GetGameFolderName(string buffer, int maxlength) { throw new NotImplementedException(); }

		/**
		 * Returns the current map name.
		 *
		 * @param buffer        Buffer to store map name.
		 * @param maxlength     Maximum length of buffer.
		 * @return              Number of bytes written (UTF-8 safe).
		 */
		public static int GetCurrentMap(out string buffer, int maxlength) { throw new NotImplementedException(); }

		/**
		 * Precaches a given model.
		 *
		 * @param model         Name of the model to precache.
		 * @param preload       If preload is true the file will be precached before level startup.
		 * @return              Returns the model index, 0 for error.
		 */
		public static int PrecacheModel(string model, bool preload = false) { throw new NotImplementedException(); }

		/**
		 * Precaches a given sentence file.
		 *
		 * @param file          Name of the sentence file to precache.
		 * @param preload       If preload is true the file will be precached before level startup.
		 * @return              Returns a sentence file index.
		 */
		public static int PrecacheSentenceFile(string file, bool preload = false) { throw new NotImplementedException(); }

		/**
		 * Precaches a given decal.
		 *
		 * @param decal         Name of the decal to precache.
		 * @param preload       If preload is true the file will be precached before level startup.
		 * @return              Returns a decal index.
		 */
		public static int PrecacheDecal(string decal, bool preload = false) { throw new NotImplementedException(); }

		/**
		 * Precaches a given generic file.
		 *
		 * @param generic       Name of the generic file to precache.
		 * @param preload       If preload is true the file will be precached before level startup.
		 * @return              Returns a generic file index.
		 */
		public static int PrecacheGeneric(string generic, bool preload = false) { throw new NotImplementedException(); }

		/**
		 * Returns if a given model is precached.
		 *
		 * @param model         Name of the model to check.
		 * @return              True if precached, false otherwise.
		 */
		public static bool IsModelPrecached(string model) { throw new NotImplementedException(); }

		/**
		 * Returns if a given decal is precached.
		 *
		 * @param decal         Name of the decal to check.
		 * @return              True if precached, false otherwise.
		 */
		public static bool IsDecalPrecached(string decal) { throw new NotImplementedException(); }

		/**
		 * Returns if a given generic file is precached.
		 *
		 * @param generic       Name of the generic file to check.
		 * @return              True if precached, false otherwise.
		 */
		public static bool IsGenericPrecached(string generic) { throw new NotImplementedException(); }

		/**
		 * Precaches a given sound.
		 *
		 * @param sound         Name of the sound to precache.
		 * @param preload       If preload is true the file will be precached before level startup.
		 * @return              True if successfully precached, false otherwise.
		 */
		public static bool PrecacheSound(string sound, bool preload = false) { throw new NotImplementedException(); }

		/**
		 * Creates different types of ingame messages.
		 *
		 * @param client        Index of the client.
		 * @param kv            KeyValues handle to set the menu keys and options. (Check iserverplugin.h for more information).
		 * @param type          Message type to display ingame.
		 * @error               Invalid client index, or client not connected.
		 */
		public static void CreateDialog(int client, Handle kv, DialogType type) { throw new NotImplementedException(); }

		/**
		 * Gets the engine version that the currently-loaded SM core was compiled against.
		 *
		 * The engine version values are not guaranteed to be in any particular order,
		 * and should only be compared by (in)equality.
		 *
		 * @return              An EngineVersion value.
		 */
		public static EngineVersion GetEngineVersion() { throw new NotImplementedException(); }

		/**
		 * Prints a message to a specific client in the chat area.
		 *
		 * @param client        Client index.
		 * @param format        Formatting rules.
		 * @param ...           Variable number of format parameters.
		 * @error               If the client is not connected an error will be thrown.
		 */
		public static void PrintToChat(int client, string format, params object[] args) { throw new NotImplementedException(); }

		/**
		 * Prints a message to all clients in the chat area.
		 *
		 * @param format        Formatting rules.
		 * @param ...           Variable number of format parameters.
		 */
		public static void PrintToChatAll(string format, params object[] args)
		{
			string buffer = null;

			for (int i = 1; i <= MaxClients; i++)
			{
				if (IsClientInGame(i))
				{
					SetGlobalTransTarget(i);
					VFormat(out buffer, buffer.Length, format, 2);
					PrintToChat(i, "%s", buffer);
				}
			}
		}

		/**
		 * Prints a message to a specific client in the center of the screen.
		 *
		 * @param client        Client index.
		 * @param format        Formatting rules.
		 * @param ...           Variable number of format parameters.
		 * @error               If the client is not connected an error will be thrown.
		 */
		public static void PrintCenterText(int client, string format, params object[] args) { throw new NotImplementedException(); }

		/**
		 * Prints a message to all clients in the center of the screen.
		 *
		 * @param format        Formatting rules.
		 * @param ...           Variable number of format parameters.
		 */
		public static void PrintCenterTextAll(string format, params object[] args)
		{
			string buffer;

			for (int i = 1; i <= MaxClients; i++)
			{
				if (IsClientInGame(i))
				{
					SetGlobalTransTarget(i);
					VFormat(out buffer, -1, format, 2);
					PrintCenterText(i, "%s", buffer);
				}
			}
		}

		/**
		 * Prints a message to a specific client with a hint box.
		 *
		 * @param client        Client index.
		 * @param format        Formatting rules.
		 * @param ...           Variable number of format parameters.
		 * @error               If the client is not connected an error will be thrown.
		 */
		public static void PrintHintText(int client, string format, params object[] args) { throw new NotImplementedException(); }

		/**
		 * Prints a message to all clients with a hint box.
		 *
		 * @param format        Formatting rules.
		 * @param ...           Variable number of format parameters.
		 */
		public static void PrintHintTextToAll(string format, params object[] args)
		{
			string buffer;

			for (int i = 1; i <= MaxClients; i++)
			{
				if (IsClientInGame(i))
				{
					SetGlobalTransTarget(i);
					VFormat(out buffer, -1, format, 2);
					PrintHintText(i, "%s", buffer);
				}
			}
		}

		/**
		 * Shows a VGUI panel to a specific client.
		 *
		 * @param client        Client index.
		 * @param name          Panel type name (Check viewport_panel_names.h to see a list of
		 *                      some panel names).
		 * @param Kv            KeyValues handle with all the data for the panel setup (Depends
		 *                      on the panel type and may be unused).
		 * @param show          True to show the panel, or false to remove it from the client screen.
		 * @error               If the client is not connected an error will be thrown.
		 */
		public static void ShowVGUIPanel(int client, string name, Handle Kv = INVALID_HANDLE, bool show = true) { throw new NotImplementedException(); }

		/**
		 * Creates a HUD synchronization object.  This object is used to automatically assign and
		 * re-use channels for a set of messages.
		 *
		 * The HUD has a hardcoded number of channels (usually 6) for displaying
		 * text.  You can use any channel for any area of the screen.  Text on
		 * different channels can overlap, but text on the same channel will
		 * erase the old text first.  This overlapping and overwriting gets problematic.
		 *
		 * A HUD synchronization object automatically selects channels for you based on
		 * the following heuristics:
		 *  - If channel X was last used by the object, and hasn't been modified again,
		 *    channel X gets re-used.
		 *  - Otherwise, a new channel is chosen based on the least-recently-used channel.
		 *
		 * This ensures that if you display text on a sync object, that the previous text
		 * displayed on it will always be cleared first.  This is because your new text
		 * will either overwrite the old text on the same channel, or because another
		 * channel has already erased your text.
		 *
		 * Note that messages can still overlap if they are on different synchronization
		 * objects, or they are displayed to manual channels.
		 *
		 * These are particularly useful for displaying repeating or refreshing HUD text, in
		 * addition to displaying multiple message sets in one area of the screen (for example,
		 * center-say messages that may pop up randomly that you don't want to overlap each
		 * other).
		 *
		 * @return              New HUD synchronization object.
		 *                      The Handle can be closed with CloseHandle().
		 *                      If HUD text is not supported on this mod, then
		 *                      INVALID_HANDLE is returned.
		 */
		public static Handle CreateHudSynchronizer() { throw new NotImplementedException(); }

		/**
		 * Sets the HUD parameters for drawing text.  These parameters are stored
		 * globally, although nothing other than this function and SetHudTextParamsEx
		 * modify them.
		 *
		 * You must call this function before drawing text.  If you are drawing
		 * text to multiple clients, you can set the parameters once, since
		 * they won't be modified.  However, as soon as you pass control back
		 * to other plugins, you must reset the parameters next time you draw.
		 *
		 * @param x             x coordinate, from 0 to 1.  -1.0 is the center.
		 * @param y             y coordinate, from 0 to 1.  -1.0 is the center.
		 * @param holdTime      Number of seconds to hold the text.
		 * @param r             Red color value.
		 * @param g             Green color value.
		 * @param b             Blue color value.
		 * @param a             Alpha transparency value.
		 * @param effect        0/1 causes the text to fade in and fade out.
		 *                      2 causes the text to flash[?].
		 * @param fxTime        Duration of chosen effect (may not apply to all effects).
		 * @param fadeIn        Number of seconds to spend fading in.
		 * @param fadeOut       Number of seconds to spend fading out.
		 */
		public static void SetHudTextParams(float x, float y, float holdTime, int r, int g, int b, int a, int effect = 0,
								float fxTime = 6.0f, float fadeIn = 0.1f, float fadeOut = 0.2f)
		{ throw new NotImplementedException(); }

		/**
		 * Sets the HUD parameters for drawing text.  These parameters are stored
		 * globally, although nothing other than this function and SetHudTextParams
		 * modify them.
		 *
		 * This is the same as SetHudTextParams(), except it lets you set the alternate
		 * color for when effects require it.
		 *
		 * @param x             x coordinate, from 0 to 1.  -1.0 is the center.
		 * @param y             y coordinate, from 0 to 1.  -1.0 is the center.
		 * @param holdTime      Number of seconds to hold the text.
		 * @param color1        First color set, array values being [red, green, blue, alpha]
		 * @param color2        Second color set, array values being [red, green, blue, alpha]
		 * @param effect        0/1 causes the text to fade in and fade out.
		 *                      2 causes the text to flash[?].
		 * @param fxTime        Duration of chosen effect (may not apply to all effects).
		 * @param fadeIn        Number of seconds to spend fading in.
		 * @param fadeOut       Number of seconds to spend fading out.
		 */
		public static void SetHudTextParamsEx(float x, float y, float holdTime, int[] color1,
								  int[] color2 = null, int effect = 0, float fxTime = 6.0f,
						  float fadeIn = 0.1f, float fadeOut = 0.2f)
		{
			if (color2 is null)
			{
				color2 = new int[4] { 255, 255, 255, 0 };
			}
			throw new NotImplementedException();
		}

		/**
		 * Shows a synchronized HUD message to a client.
		 *
		 * As of this writing, only TF, HL2MP, and SourceForts support HUD Text.
		 *
		 * @param client        Client index to send the message to.
		 * @param sync          Synchronization object.
		 * @param message       Message text or formatting rules.
		 * @param ...           Message formatting parameters.
		 * @return              -1 on failure, anything else on success.
		 *                      This function fails if the mod does not support it.
		 * @error               Client not in-game, or sync object not valid.
		 */
		public static int ShowSyncHudText(int client, Handle sync, string message, params object[] args) { throw new NotImplementedException(); }

		/**
		 * Clears the text on a synchronized HUD channel.
		 *
		 * This is not the same as sending "" because it guarantees that it won't
		 * overwrite text on another channel.  For example, consider the scenario:
		 *
		 * 1. Your synchronized message goes to channel 3.
		 * 2. Someone else's non-synchronized message goes to channel 3.
		 *
		 * If you were to simply send "" on your synchronized message,
		 * then someone else's text could be overwritten.
		 *
		 * @param client        Client index to send the message to.
		 * @param sync          Synchronization object.
		 * @error               Client not in-game, or sync object not valid.
		 */
		public static void ClearSyncHud(int client, Handle sync) { throw new NotImplementedException(); }

		/**
		 * Shows a HUD message to a client on the given channel.
		 *
		 * As of this writing, only TF, HL2MP, and SourceForts support HUD Text.
		 *
		 * @param client        Client index to send the message to.
		 * @param channel       A channel number.
		 *                      If -1, then a channel will automatically be selected
		 *                      based on the least-recently-used channel.  If the
		 *                      channel is any other number, it will be modulo'd with
		 *                      the channel count to get a final channel number.
		 * @param message       Message text or formatting rules.
		 * @param ...           Message formatting parameters.
		 * @return              -1 on failure (lack of mod support).
		 *                      Any other return value is the channel number that was
		 *                      used to render the text.
		 */
		public static int ShowHudText(int client, int channel, string message, params object[] args) { throw new NotImplementedException(); }

		/**
		 * Shows a MOTD panel to a specific client.
		 *
		 * @param client        Client index.
		 * @param title         Title of the panel (printed on the top border of the window).
		 * @param msg           Contents of the panel, it can be treated as an url, filename or plain text
		 *                      depending on the type parameter (WARNING: msg has to be 192 bytes maximum!)
		 * @param type          Determines the way to treat the message body of the panel.
		 * @error               If the client is not connected an error will be thrown.
		 */
		public static void ShowMOTDPanel(int client, string title, string msg, int type = MOTDPANEL_TYPE_INDEX)
		{
			throw new NotImplementedException();

			/*string num;
			IntToString(type, num, sizeof(num));

			KeyValues kv = new KeyValues("data");
			kv.SetString("title", title);
			kv.SetString("type", num);
			kv.SetString("msg", msg);
			ShowVGUIPanel(client, "info", kv);
			delete kv;*/
		}

		/**
		 * Displays a panel asking the client to connect to a specified IP.
		 *
		 * @param client        Client index.
		 * @param time          Duration to hold the panel on the client's screen.
		 * @param ip            Destination IP.
		 * @param password      Password to connect to the destination IP. The client will be able to see this.
		 */
		public static void DisplayAskConnectBox(int client, float time, string ip, string password = "")
		{
			throw new NotImplementedException();

			/*string destination;
			FormatEx(destination, sizeof(destination), "%s/%s", ip, password);

			KeyValues kv = new KeyValues("data");

			kv.SetFloat("time", time);
			kv.SetString("title", destination);
			CreateDialog(client, kv, DialogType_AskConnect);
			delete kv;*/
		}

		/**
		 * Converts an entity index into a serial encoded entity reference.
		 *
		 * @param entity        Entity index.
		 * @return              Entity reference.
		 */
		public static int EntIndexToEntRef(int entity) { throw new NotImplementedException(); }

		/**
		 * Retrieves the entity index from a reference.
		 *
		 * @param ref           Entity reference.
		 * @return              Entity index.
		 */
		public static int EntRefToEntIndex(int Ref) { throw new NotImplementedException(); }

		/**
		 * Converts a reference into a backwards compatible version.
		 *
		 * @param ref           Entity reference.
		 * @return              Bcompat reference.
		 */
		public static int MakeCompatEntRef(int Ref) { throw new NotImplementedException(); }

		public enum ClientRangeType
		{
			RangeType_Visibility = 0,
			RangeType_Audibility
		}

		/**
		 * Find clients that are potentially in range of a position.
		 *
		 * @param origin        Coordinates from which to test range.
		 * @param rangeType     Range type to use for filtering clients.
		 * @param clients       Array to which found client indexes will be written.
		 * @param size          Maximum size of clients array.
		 * @return              Number of client indexes written to clients array.
		 */
		public static int GetClientsInRange(float[] origin, ClientRangeType rangeType, int[] clients, int size) { throw new NotImplementedException(); }

		/**
		 * Retrieves the server's authentication string (SteamID).
		 *
		 * Note: If called before server is connected to Steam, auth id
		 * will be invalid ([I:0:1], 1, etc.)
		 *
		 * @param authType      Auth id type and format to use.
		 *                      (Only AuthId_Steam3 and AuthId_SteamID64 are supported)
		 * @param auth          Buffer to store the server's auth id.
		 * @param maxlen        Maximum length of string buffer (includes NULL terminator).
		 * @error               Invalid AuthIdType given.
		 */
		public static void GetServerAuthId(AuthIdType authType, string auth, int maxlen) { throw new NotImplementedException(); }

		/**
		 * Returns the server's Steam account ID.
		 *
		 * @return              Steam account ID or 0 if not available.
		 */
		public static int GetServerSteamAccountId() { throw new NotImplementedException(); }
	}
}