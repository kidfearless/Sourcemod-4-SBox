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

		public const int CS_TEAM_NONE = 0;  /**< No team yet. */
		public const int CS_TEAM_SPECTATOR = 1;  /**< Spectators. */
		public const int CS_TEAM_T = 2;  /**< Terrorists. */
		public const int CS_TEAM_CT = 3;  /**< Counter-Terrorists. */

		public const int CS_SLOT_PRIMARY = 0;  /**< Primary weapon slot. */
		public const int CS_SLOT_SECONDARY = 1;  /**< Secondary weapon slot. */
		public const int CS_SLOT_KNIFE = 2;  /**< Knife slot. */
		public const int CS_SLOT_GRENADE = 3;  /**< Grenade slot (will only return one grenade). */
		public const int CS_SLOT_C4 = 4;  /**< C4 slot. */
		public const int CS_SLOT_BOOST = 11;  /**< Slot for healthshot and shield (will only return one weapon/item). */
		public const int CS_SLOT_UTILITY = 12;  /**< Slot for tablet. */

		public const int CS_DMG_HEADSHOT = (1 << 30);    /**< Headshot */

		public enum CSRoundEndReason
		{
			CSRoundEnd_TargetBombed = 0,           /**< Target Successfully Bombed! */
			CSRoundEnd_VIPEscaped = 1,                 /**< The VIP has escaped! - Doesn't exist on CS:GO */
			CSRoundEnd_VIPKilled = 2,                  /**< VIP has been assassinated! - Doesn't exist on CS:GO */
			CSRoundEnd_TerroristsEscaped = 3,          /**< The terrorists have escaped! */
			CSRoundEnd_CTStoppedEscape = 4,            /**< The CTs have prevented most of the terrorists from escaping! */
			CSRoundEnd_TerroristsStopped = 5,          /**< Escaping terrorists have all been neutralized! */
			CSRoundEnd_BombDefused = 6,                /**< The bomb has been defused! */
			CSRoundEnd_CTWin = 7,                      /**< Counter-Terrorists Win! */
			CSRoundEnd_TerroristWin = 8,               /**< Terrorists Win! */
			CSRoundEnd_Draw = 9,                       /**< Round Draw! */
			CSRoundEnd_HostagesRescued = 10,            /**< All Hostages have been rescued! */
			CSRoundEnd_TargetSaved = 11,                /**< Target has been saved! */
			CSRoundEnd_HostagesNotRescued = 12,         /**< Hostages have not been rescued! */
			CSRoundEnd_TerroristsNotEscaped = 13,       /**< Terrorists have not escaped! */
			CSRoundEnd_VIPNotEscaped = 14,              /**< VIP has not escaped! - Doesn't exist on CS:GO */
			CSRoundEnd_GameStart = 15,                  /**< Game Commencing! */

			// The below only exist on CS:GO
			CSRoundEnd_TerroristsSurrender= 16,        /**< Terrorists Surrender */
			CSRoundEnd_CTSurrender= 17,                /**< CTs Surrender */
			CSRoundEnd_TerroristsPlanted= 18,          /**< Terrorists Planted the bomb */
			CSRoundEnd_CTsReachedHostage= 19           /**< CTs Reached the hostage */
		};
		public const int
			CSRoundEnd_TargetBombed = 0,           /**< Target Successfully Bombed! */
			CSRoundEnd_VIPEscaped = 1,                 /**< The VIP has escaped! - Doesn't exist on CS:GO */
			CSRoundEnd_VIPKilled = 2,                  /**< VIP has been assassinated! - Doesn't exist on CS:GO */
			CSRoundEnd_TerroristsEscaped = 3,          /**< The terrorists have escaped! */
			CSRoundEnd_CTStoppedEscape = 4,            /**< The CTs have prevented most of the terrorists from escaping! */
			CSRoundEnd_TerroristsStopped = 5,          /**< Escaping terrorists have all been neutralized! */
			CSRoundEnd_BombDefused = 6,                /**< The bomb has been defused! */
			CSRoundEnd_CTWin = 7,                      /**< Counter-Terrorists Win! */
			CSRoundEnd_TerroristWin = 8,               /**< Terrorists Win! */
			CSRoundEnd_Draw = 9,                       /**< Round Draw! */
			CSRoundEnd_HostagesRescued = 10,            /**< All Hostages have been rescued! */
			CSRoundEnd_TargetSaved = 11,                /**< Target has been saved! */
			CSRoundEnd_HostagesNotRescued = 12,         /**< Hostages have not been rescued! */
			CSRoundEnd_TerroristsNotEscaped = 13,       /**< Terrorists have not escaped! */
			CSRoundEnd_VIPNotEscaped = 14,              /**< VIP has not escaped! - Doesn't exist on CS:GO */
			CSRoundEnd_GameStart = 15,                  /**< Game Commencing! */

			// The below only exist on CS:GO
			CSRoundEnd_TerroristsSurrender= 16,        /**< Terrorists Surrender */
			CSRoundEnd_CTSurrender= 17,                /**< CTs Surrender */
			CSRoundEnd_TerroristsPlanted= 18,          /**< Terrorists Planted the bomb */
			CSRoundEnd_CTsReachedHostage= 19;           /**< CTs Reached the hostage */

		public enum CSWeaponID
		{
			CSWeapon_NONE = 0,
			CSWeapon_P228,
			CSWeapon_GLOCK,
			CSWeapon_SCOUT,
			CSWeapon_HEGRENADE,
			CSWeapon_XM1014,
			CSWeapon_C4,
			CSWeapon_MAC10,
			CSWeapon_AUG,
			CSWeapon_SMOKEGRENADE,
			CSWeapon_ELITE,
			CSWeapon_FIVESEVEN,
			CSWeapon_UMP45,
			CSWeapon_SG550,
			CSWeapon_GALIL,
			CSWeapon_FAMAS,
			CSWeapon_USP,
			CSWeapon_AWP,
			CSWeapon_MP5NAVY,
			CSWeapon_M249,
			CSWeapon_M3,
			CSWeapon_M4A1,
			CSWeapon_TMP,
			CSWeapon_G3SG1,
			CSWeapon_FLASHBANG,
			CSWeapon_DEAGLE,
			CSWeapon_SG552,
			CSWeapon_AK47,
			CSWeapon_KNIFE,
			CSWeapon_P90,
			CSWeapon_SHIELD,
			CSWeapon_KEVLAR,
			CSWeapon_ASSAULTSUIT,
			CSWeapon_NIGHTVISION, //Anything below is CS:GO ONLY
			CSWeapon_GALILAR,
			CSWeapon_BIZON,
			CSWeapon_MAG7,
			CSWeapon_NEGEV,
			CSWeapon_SAWEDOFF,
			CSWeapon_TEC9,
			CSWeapon_TASER,
			CSWeapon_HKP2000,
			CSWeapon_MP7,
			CSWeapon_MP9,
			CSWeapon_NOVA,
			CSWeapon_P250,
			CSWeapon_SCAR17,
			CSWeapon_SCAR20,
			CSWeapon_SG556,
			CSWeapon_SSG08,
			CSWeapon_KNIFE_GG,
			CSWeapon_MOLOTOV,
			CSWeapon_DECOY,
			CSWeapon_INCGRENADE,
			CSWeapon_DEFUSER,
			CSWeapon_HEAVYASSAULTSUIT,
			//The rest are actual item definition indexes for CS:GO
			CSWeapon_CUTTERS = 56,
			CSWeapon_HEALTHSHOT = 57,
			CSWeapon_KNIFE_T = 59,
			CSWeapon_M4A1_SILENCER = 60,
			CSWeapon_USP_SILENCER = 61,
			CSWeapon_CZ75A = 63,
			CSWeapon_REVOLVER = 64,
			CSWeapon_TAGGRENADE = 68,
			CSWeapon_FISTS = 69,
			CSWeapon_BREACHCHARGE = 70,
			CSWeapon_TABLET = 72,
			CSWeapon_MELEE = 74,
			CSWeapon_AXE = 75,
			CSWeapon_HAMMER = 76,
			CSWeapon_SPANNER = 78,
			CSWeapon_KNIFE_GHOST = 80,
			CSWeapon_FIREBOMB = 81,
			CSWeapon_DIVERSION = 82,
			CSWeapon_FRAGGRENADE = 83,
			CSWeapon_SNOWBALL = 84,
			CSWeapon_BUMPMINE = 85,
			CSWeapon_MAX_WEAPONS_NO_KNIFES, // Max without the knife item defs, useful when treating all knives as a regular knife.
			CSWeapon_BAYONET = 500,
			CSWeapon_KNIFE_CLASSIC = 503,
			CSWeapon_KNIFE_FLIP = 505,
			CSWeapon_KNIFE_GUT = 506,
			CSWeapon_KNIFE_KARAMBIT = 507,
			CSWeapon_KNIFE_M9_BAYONET = 508,
			CSWeapon_KNIFE_TATICAL = 509,
			CSWeapon_KNIFE_FALCHION = 512,
			CSWeapon_KNIFE_SURVIVAL_BOWIE = 514,
			CSWeapon_KNIFE_BUTTERFLY = 515,
			CSWeapon_KNIFE_PUSH = 516,
			CSWeapon_KNIFE_CORD = 517,
			CSWeapon_KNIFE_CANIS = 518,
			CSWeapon_KNIFE_URSUS = 519,
			CSWeapon_KNIFE_GYPSY_JACKKNIFE = 520,
			CSWeapon_KNIFE_OUTDOOR = 521,
			CSWeapon_KNIFE_STILETTO = 522,
			CSWeapon_KNIFE_WIDOWMAKER = 523,
			CSWeapon_KNIFE_SKELETON = 525,
			CSWeapon_MAX_WEAPONS //THIS MUST BE LAST, EASY WAY TO CREATE LOOPS. When looping, do CS_IsValidWeaponID(i), to check.
		};
		public const int 
			CSWeapon_NONE = 0,
			CSWeapon_P228 = 1,
			CSWeapon_GLOCK = 2,
			CSWeapon_SCOUT = 3,
			CSWeapon_HEGRENADE = 4,
			CSWeapon_XM1014 = 5,
			CSWeapon_C4 = 6,
			CSWeapon_MAC10 = 7,
			CSWeapon_AUG = 8,
			CSWeapon_SMOKEGRENADE = 9,
			CSWeapon_ELITE = 10,
			CSWeapon_FIVESEVEN = 11,
			CSWeapon_UMP45 = 12,
			CSWeapon_SG550 = 13,
			CSWeapon_GALIL = 14,
			CSWeapon_FAMAS = 15,
			CSWeapon_USP = 16,
			CSWeapon_AWP = 17,
			CSWeapon_MP5NAVY = 18,
			CSWeapon_M249 = 19,
			CSWeapon_M3 = 20,
			CSWeapon_M4A1 = 21,
			CSWeapon_TMP = 22,
			CSWeapon_G3SG1 = 23,
			CSWeapon_FLASHBANG = 24,
			CSWeapon_DEAGLE = 25,
			CSWeapon_SG552 = 26,
			CSWeapon_AK47 = 27,
			CSWeapon_KNIFE = 28,
			CSWeapon_P90 = 29,
			CSWeapon_SHIELD = 30,
			CSWeapon_KEVLAR = 31,
			CSWeapon_ASSAULTSUIT = 32,
			CSWeapon_NIGHTVISION = 33, //Anything below is CS:GO ONLY
			CSWeapon_GALILAR = 34,
			CSWeapon_BIZON = 35,
			CSWeapon_MAG7 = 36,
			CSWeapon_NEGEV = 37,
			CSWeapon_SAWEDOFF = 38,
			CSWeapon_TEC9 = 39,
			CSWeapon_TASER = 40,
			CSWeapon_HKP2000 = 41,
			CSWeapon_MP7 = 42,
			CSWeapon_MP9 = 43,
			CSWeapon_NOVA = 44,
			CSWeapon_P250 = 45,
			CSWeapon_SCAR17 = 46,
			CSWeapon_SCAR20 = 47,
			CSWeapon_SG556 = 48,
			CSWeapon_SSG08 = 49,
			CSWeapon_KNIFE_GG = 50,
			CSWeapon_MOLOTOV = 51,
			CSWeapon_DECOY = 52,
			CSWeapon_INCGRENADE = 53,
			CSWeapon_DEFUSER = 54,
			CSWeapon_HEAVYASSAULTSUIT = 55,
			//The rest are actual item definition indexes for CS:GO
			CSWeapon_CUTTERS = 56,
			CSWeapon_HEALTHSHOT = 57,
			CSWeapon_KNIFE_T = 59,
			CSWeapon_M4A1_SILENCER = 60,
			CSWeapon_USP_SILENCER = 61,
			CSWeapon_CZ75A = 63,
			CSWeapon_REVOLVER = 64,
			CSWeapon_TAGGRENADE = 68,
			CSWeapon_FISTS = 69,
			CSWeapon_BREACHCHARGE = 70,
			CSWeapon_TABLET = 72,
			CSWeapon_MELEE = 74,
			CSWeapon_AXE = 75,
			CSWeapon_HAMMER = 76,
			CSWeapon_SPANNER = 78,
			CSWeapon_KNIFE_GHOST = 80,
			CSWeapon_FIREBOMB = 81,
			CSWeapon_DIVERSION = 82,
			CSWeapon_FRAGGRENADE = 83,
			CSWeapon_SNOWBALL = 84,
			CSWeapon_BUMPMINE = 85,
			CSWeapon_MAX_WEAPONS_NO_KNIFES = 86, // Max without the knife item defs, useful when treating all knives as a regular knife.
			CSWeapon_BAYONET = 500,
			CSWeapon_KNIFE_CLASSIC = 503,
			CSWeapon_KNIFE_FLIP = 505,
			CSWeapon_KNIFE_GUT = 506,
			CSWeapon_KNIFE_KARAMBIT = 507,
			CSWeapon_KNIFE_M9_BAYONET = 508,
			CSWeapon_KNIFE_TATICAL = 509,
			CSWeapon_KNIFE_FALCHION = 512,
			CSWeapon_KNIFE_SURVIVAL_BOWIE = 514,
			CSWeapon_KNIFE_BUTTERFLY = 515,
			CSWeapon_KNIFE_PUSH = 516,
			CSWeapon_KNIFE_CORD = 517,
			CSWeapon_KNIFE_CANIS = 518,
			CSWeapon_KNIFE_URSUS = 519,
			CSWeapon_KNIFE_GYPSY_JACKKNIFE = 520,
			CSWeapon_KNIFE_OUTDOOR = 521,
			CSWeapon_KNIFE_STILETTO = 522,
			CSWeapon_KNIFE_WIDOWMAKER = 523,
			CSWeapon_KNIFE_SKELETON = 525,
			CSWeapon_MAX_WEAPONS = 526; //THIS MUST BE LAST, EASY WAY TO CREATE LOOPS. When looping, do CS_IsValidWeaponID(i), to check.

		/**
		 * Called when a player attempts to purchase an item.
		 * Return Plugin_Continue to allow the purchase or return a
		 * higher action to deny.
		 *
		 * @param client        Client index
		 * @param weapon        User input for weapon name
		 */
		public static  Action CS_OnBuyCommand(int client, string weapon) { throw new NotImplementedException(); }

		/**
		 * Called when CSWeaponDrop is called
		 * Return Plugin_Continue to allow the call or return a
		 * higher action to block.
		 *
		 * @param client        Client index
		 * @param weaponIndex   Weapon index
		 */
		public static  Action CS_OnCSWeaponDrop(int client, int weaponIndex) { throw new NotImplementedException(); }

		/**
		 * Called when game retrieves a weapon's price for a player.
		 * Return Plugin_Continue to use default value or return a higher
		 * action to use a newly-set price.
		 * 
		 * @note This can be called multiple times per weapon purchase
		 * 
		 * @param client        Client index
		 * @param weapon        Weapon classname
		 * @param price         Buffer param for the price of the weapon
		 *
		 * @note Not all "weapons" call GetWeaponPrice. Example: c4, knife, vest, vest helmet, night vision.
		 */
		public static Action CS_OnGetWeaponPrice(int client, string weapon, ref int price) { throw new NotImplementedException(); }

		/**
		 * Called when TerminateRound is called.
		 * Return Plugin_Continue to ignore, return Plugin_Changed to continue,
		 * using the given delay and reason, or return Plugin_Handled or a higher
		 * action to block TerminateRound from firing.
		 *
		 * @param delay         Time (in seconds) until new round starts
		 * @param reason        Reason for round end
		 */
		public static Action CS_OnTerminateRound(ref float delay, ref CSRoundEndReason reason) { throw new NotImplementedException(); }

		/**
		 * Respawns a player.
		 *
		 * @param client        Player's index.
		 * @error               Invalid client index, client not in game.
		 */
		public static void CS_RespawnPlayer(int client) { throw new NotImplementedException(); }

		/**
		 * Switches the player's team.
		 *
		 * @param client        Player's index.
		 * @param team          Team index.
		 * @error               Invalid client index, client not in game.
		 */
		public static void CS_SwitchTeam(int client, int team) { throw new NotImplementedException(); }

		/**
		 * Forces a player to drop or toss their weapon
		 *
		 * @param client        Player's index.
		 * @param weaponIndex   Index of weapon to drop.
		 * @param toss          True to toss weapon (with velocity) or false to just drop weapon
		 * @param blockhook     Set to true to stop the corresponding CS_OnCSWeaponDrop
		 * @error               Invalid client index, client not in game, or invalid weapon index.
		 */
		public static void CS_DropWeapon(int client, int weaponIndex, bool toss, bool blockhook = false) { throw new NotImplementedException(); }

		/**
		 * Forces round to end with a reason
		 *
		 * @param delay         Time (in seconds) to delay before new round starts
		 * @param reason        Reason for the round ending
		 * @param blockhook     Set to true to stop the corresponding CS_OnTerminateRound
		 *                      public virtual from being called.
		 */
		public static void CS_TerminateRound(float delay, CSRoundEndReason reason, bool blockhook = false) { throw new NotImplementedException(); }

		/**
		 * Gets a weapon name from a weapon alias
		 *
		 * @param alias         Weapons alias to get weapon name for.
		 * @param weapon        Buffer to store weapons name
		 * @param size          Size of buffer to store the weapons name.
		 *
		 * @note Will set the buffer to the original alias if it is not an alias to a weapon.
		 */
		public static void CS_GetTranslatedWeaponAlias(string alias, string weapon, int size) { throw new NotImplementedException(); }

		/**
		 * Gets a weapon's price
		 *
		 * @param client        Client to check weapon price for.
		 * @param id            Weapon id for the weapon to check
		 * @param defaultprice  Set to true to get defaultprice.
		 * @return              Returns price of the weapon (even if modified)
		 * @error               Invalid client, failing to get weapon info, or failing to get price offset.
		 *
		 * @note c4, knife and shield will always return 0. vest, vest helmet and night vision will always return default price.
		 */
		public static int CS_GetWeaponPrice(int client, CSWeaponID id, bool defaultprice = false) { throw new NotImplementedException(); }

		/**
		 * Gets a clients clan tag
		 *
		 * @param client        Client index to get clan tag for.
		 * @param buffer        Buffer to store clients clan tag in.
		 * @param size          Size of the buffer.
		 * @return              Number of non-null bytes written.
		 * @error               Invalid client.
		 */
		public static int CS_GetClientClanTag(int client, string buffer, int size) { throw new NotImplementedException(); }

		/**
		 * Sets a clients clan tag
		 *
		 * @param client        Client index to set clan tag for.
		 * @param tag           Tag to set clients clan tag as.
		 * @error               Invalid client.
		 */
		public static void CS_SetClientClanTag(int client, string tag) { throw new NotImplementedException(); }

		/**
		 * Gets a team's score
		 *
		 * @param team          Team index to get score for.
		 * @return              Returns the internal team score.
		 * @error               Invalid team index.
		 */
		public static int CS_GetTeamScore(int team) { throw new NotImplementedException(); }

		/**
		 * Sets a team's score
		 *
		 * @param team          Team index to set score for.
		 * @param value         Value to set teams score as.
		 * @error               Invalid team index.
		 *
		 * @note This will update the scoreboard only after the scoreboard update function is called.
		 *       Use SetTeamScore plus this to update the scoreboard instantly and save values correctly.
		 */
		public static void CS_SetTeamScore(int team, int value) { throw new NotImplementedException(); }

		/**
		 * Gets a client's mvp count
		 *
		 * @param client        Client index to get mvp count of.
		 * @return              Returns the client's internal MVP count.
		 * @error               Invalid client.
		 */
		public static int CS_GetMVPCount(int client) { throw new NotImplementedException(); }

		/**
		 * Sets a client's mvp count
		 *
		 * @param client        Client index to set mvp count for.
		 * @param value         Value to set client's mvp count as.
		 * @error               Invalid client.
		 */
		public static void CS_SetMVPCount(int client, int value) { throw new NotImplementedException(); }

		/**
		 * Gets a client's contribution score (CS:GO only)
		 *
		 * @param client        Client index to get score of.
		 * @return              Returns the client's score.
		 * @error               Invalid client.
		 */
		public static int CS_GetClientContributionScore(int client) { throw new NotImplementedException(); }

		/**
		 * Sets a client's contribution score (CS:GO only)
		 *
		 * @param client        Client index to set score for.
		 * @param value         Value to set client's score as.
		 * @error               Invalid client.
		 */
		public static void CS_SetClientContributionScore(int client, int value) { throw new NotImplementedException(); }

		/**
		 * Gets a client's assists (CS:GO only)
		 *
		 * @param client        Client index to get assists of.
		 * @return              Returns the client's assists.
		 * @error               Invalid client.
		 */
		public static int CS_GetClientAssists(int client) { throw new NotImplementedException(); }

		/**
		 * Sets a client's assists (CS:GO only)
		 *
		 * @param client        Client index to set assists for.
		 * @param value         Value to set client's assists as.
		 * @error               Invalid client.
		 */
		public static void CS_SetClientAssists(int client, int value) { throw new NotImplementedException(); }

		/**
		 * Gets a weaponID from a alias
		 *
		 * @param alias         Weapon alias to attempt to get an id for.
		 * @return              Returns a weapon id or 0 if failed to find a match.
		 *
		 * @note For best results use CS_GetTranslatedWeaponAlias on the weapon name before passing it.
		 */
		public static CSWeaponID CS_AliasToWeaponID(string alias) { throw new NotImplementedException(); }

		/**
		 * Gets a alias from a weaponID
		 *
		 * @param weaponID      WeaponID to get alias for.
		 * @param destination   Destination string to hold the weapon alias.
		 * @param len           Length of the destination array.
		 * @return              Returns number of cells written.
		 */
		public static int CS_WeaponIDToAlias(CSWeaponID weaponID, string destination, int len) { throw new NotImplementedException(); }

		/**
		 * Returns weather a WeaponID is valid on the current mod (css or csgo)
		 *
		 * @param weaponID      WeaponID to check
		 * @return              Returns true if its a valid WeaponID false otherwise.
		 *
		 * @note This will return false always for CSWeapon_NONE. Should only be called after OnMapStart since weapon info isnt intialized before.
		 */
		public static bool CS_IsValidWeaponID(CSWeaponID id) { throw new NotImplementedException(); }

		/**
		 * Sets a player's model based on their current class
		 *
		 * @param client        Player's index.
		 * @error               Invalid client index, client not in game.
		 */
		public static void CS_UpdateClientModel(int client) { throw new NotImplementedException(); }

		/**
		 * Returns a CSWeaponID equivalent based on the item definition index.
		 *
		 * @param iDefIndex     Definition index to get the CSWeaponID value for.
		 * @return              Returns CSWeaponID value for the definition index.
		 * @error               Invalid definition index.
		 *
		 * @note In most cases the id will be the item definition index. Works for CS:GO ONLY.
		 */
		public static CSWeaponID CS_ItemDefIndexToID(int iDefIndex) { throw new NotImplementedException(); }

		/**
		 * Returns a item definition index equivalent based on the CSWeaponID.
		 *
		 * @param id            CSWeaponID to get the item definition for.
		 * @return              Returns item definition index value for the weapon id.
		 * @error               Invalid weapon id.
		 *
		 * @note In most cases the item deinition index will be the id. Works for CS:GO ONLY.
		 */
		public static int CS_WeaponIDToItemDefIndex(CSWeaponID id) { throw new NotImplementedException(); }

	}
}