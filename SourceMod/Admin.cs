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
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sourcemod
{
	public partial class SourceMod
	{
		public struct AdminFlag
		{
			public int _value;
			public AdminFlag(int value) => _value = value;
			#region Access levels (flags) for admins.
			public const int Reservation = 0;   /**< Reserved slot */
			public const int Generic = 1;       /**< Generic admin abilities */
			public const int Kick = 2;          /**< Kick another user */
			public const int Ban = 3;           /**< Ban another user */
			public const int Unban = 4;         /**< Unban another user */
			public const int Slay = 5;          /**< Slay/kill/damage another user */
			public const int Changemap = 6;     /**< Change the map */
			public const int Convars = 7;       /**< Change basic convars */
			public const int Config = 8;        /**< Change configuration */
			public const int Chat = 9;          /**< Special chat privileges */
			public const int Vote = 10;         /**< Special vote privileges */
			public const int Password = 11;     /**< Set a server password */
			public const int RCON = 12;         /**< Use RCON */
			public const int Cheats = 13;       /**< Change sv_cheats and use its commands */
			public const int Root = 14;         /**< All access by default */
			public const int Custom1 = 15;      /**< First custom flag type */
			public const int Custom2 = 16;      /**< Second custom flag type */
			public const int Custom3 = 17;      /**< Third custom flag type */
			public const int Custom4 = 18;      /**< Fourth custom flag type */
			public const int Custom5 = 19;      /**< Fifth custom flag type */
			public const int Custom6 = 20;      /**< Sixth custom flag type */
			public const int Total = 21;        /**< Total number of admin flags */
			#endregion

			public static implicit operator AdminFlag(int value) => new AdminFlag(value);

			public static implicit operator int(AdminFlag value) => value._value;
		}
		#region Bitwise values definitions for admin flags.
		public const int ADMFLAG_RESERVATION = (1 << 0);      /**< Convenience macro for Admin_Reservation as a FlagBit */
		public const int ADMFLAG_GENERIC = (1 << 1);      /**< Convenience macro for Admin_Generic as a FlagBit */
		public const int ADMFLAG_KICK = (1 << 2);      /**< Convenience macro for Admin_Kick as a FlagBit */
		public const int ADMFLAG_BAN = (1 << 3);      /**< Convenience macro for Admin_Ban as a FlagBit */
		public const int ADMFLAG_UNBAN = (1 << 4);      /**< Convenience macro for Admin_Unban as a FlagBit */
		public const int ADMFLAG_SLAY = (1 << 5);      /**< Convenience macro for Admin_Slay as a FlagBit */
		public const int ADMFLAG_CHANGEMAP = (1 << 6);      /**< Convenience macro for Admin_Changemap as a FlagBit */
		public const int ADMFLAG_CONVARS = (1 << 7);      /**< Convenience macro for Admin_Convars as a FlagBit */
		public const int ADMFLAG_CONFIG = (1 << 8);      /**< Convenience macro for Admin_Config as a FlagBit */
		public const int ADMFLAG_CHAT = (1 << 9);      /**< Convenience macro for Admin_Chat as a FlagBit */
		public const int ADMFLAG_VOTE = (1 << 10);     /**< Convenience macro for Admin_Vote as a FlagBit */
		public const int ADMFLAG_PASSWORD = (1 << 11);     /**< Convenience macro for Admin_Password as a FlagBit */
		public const int ADMFLAG_RCON = (1 << 12);     /**< Convenience macro for Admin_RCON as a FlagBit */
		public const int ADMFLAG_CHEATS = (1 << 13);     /**< Convenience macro for Admin_Cheats as a FlagBit */
		public const int ADMFLAG_ROOT = (1 << 14);     /**< Convenience macro for Admin_Root as a FlagBit */
		public const int ADMFLAG_CUSTOM1 = (1 << 15);     /**< Convenience macro for Admin_Custom1 as a FlagBit */
		public const int ADMFLAG_CUSTOM2 = (1 << 16);     /**< Convenience macro for Admin_Custom2 as a FlagBit */
		public const int ADMFLAG_CUSTOM3 = (1 << 17);     /**< Convenience macro for Admin_Custom3 as a FlagBit */
		public const int ADMFLAG_CUSTOM4 = (1 << 18);     /**< Convenience macro for Admin_Custom4 as a FlagBit */
		public const int ADMFLAG_CUSTOM5 = (1 << 19);     /**< Convenience macro for Admin_Custom5 as a FlagBit */
		public const int ADMFLAG_CUSTOM6 = (1 << 20);     /**< Convenience macro for Admin_Custom6 as a FlagBit */
		#endregion


		/**
		 * Access override types.
		 */
		public enum OverrideType
		{
			Override_Command = 1,   /**< Command */
			Override_CommandGroup   /**< Command group */
		};

		public const int
			Override_Command = 1,   /**< Command */
			Override_CommandGroup = 2;   /**< Command group */

		/**
		 * Access override rules.
		 */
		public enum OverrideRule
		{
			Command_Deny = 0,
			Command_Allow = 1
		};

		public const int
			Command_Deny = 0,
			Command_Allow = 1;
		/**
		 * Methods of computing access permissions.
		 */
		public enum AdmAccessMode
		{
			Access_Real,        /**< Access the user has inherently */
			Access_Effective    /**< Access the user has from their groups */
		};
		public const int
			Access_Real = 0,        /**< Access the user has inherently */
			Access_Effective = 1;    /**< Access the user has from their groups */

		/**
		 * Represents the various cache regions.
		 */
		public enum AdminCachePart
		{
			AdminCache_Overrides = 0,       /**< Global overrides */
			AdminCache_Groups = 1,          /**< All groups (automatically invalidates admins too) */
			AdminCache_Admins = 2           /**< All admins */
		};

		public const int
		AdminCache_Overrides = 0,       /**< Global overrides */
		AdminCache_Groups = 1,          /**< All groups (automatically invalidates admins too) */
		AdminCache_Admins = 2;           /**< All admins */

		#region Hardcoded authentication methods
		public const string AUTHMETHOD_STEAM = "steam";     /**< SteamID based authentication */
		public const string AUTHMETHOD_IP = "ip";           /**< IP based authentication */
		public const string AUTHMETHOD_NAME = "name";       /**< Name based authentication */
		#endregion
		public readonly AdminId INVALID_ADMIN_ID = -1;
		public class AdminId
		{
			public int _value;
			public static implicit operator AdminId(int value) => new AdminId(value);
			public static implicit operator int(AdminId value) => value._value;

			/**
			 * Identifies a unique entry in the admin permissions cache.  These are not Handles.
			 */

			public AdminId(int value) => _value = value;

			/**< An invalid/non-existent admin */

			// Retrieves an admin's user name as made with CreateAdmin().
			//
			// @note This function can return UTF-8 strings, and will safely chop UTF-8 strings.
			//
			// @param name          String buffer to store name.
			// @param maxlength     Maximum size of string buffer.
			// @return              Number of bytes written.
			public void GetUsername(char[] name, int maxlength) { throw new NotImplementedException(); }

			// Binds an admin to an identity for fast lookup later on.  The bind must be unique.
			//
			// @param authMethod    Auth method to use, predefined or from RegisterAuthIdentType().
			// @param ident         String containing the arbitrary, unique identity.
			// @return              True on success, false if the auth method was not found,
			//                      ident was already taken, or ident invalid for auth method.
			public bool BindIdentity(string authMethod, string ident) { throw new NotImplementedException(); }

			// Sets whether or not a flag is enabled on an admin.
			//
			// @param flag          Admin flag to use.
			// @param enabled       True to enable, false to disable.
			public void SetFlag(AdminFlag flag, bool enabled) { throw new NotImplementedException(); }

			// Returns whether or not a flag is enabled on an admin.
			//
			// @param flag          Admin flag to use.
			// @param mode          Access mode to check.
			// @return              True if enabled, false otherwise.
			public bool HasFlag(AdminFlag flag, AdmAccessMode mode = AdmAccessMode.Access_Effective) { throw new NotImplementedException(); }

			// Returns the bitstring of access flags on an admin.
			//
			// @param mode          Access mode to use.
			// @return              A bitstring containing which flags are enabled.
			public int GetFlags(AdmAccessMode mode) { throw new NotImplementedException(); }

			// Adds a group to an admin's inherited group list.  Any flags the group has
			// will be added to the admin's effective flags.
			//
			// @param gid           GroupId index of the group.
			// @return              True on success, false on invalid input or duplicate membership.
			public bool InheritGroup(GroupId gid) { throw new NotImplementedException(); }

			// Returns group information from an admin.
			//
			// @param index         Group number to retrieve, from 0 to N-1, where N
			//                      is the value of the GroupCount property.
			// @param name          Buffer to store the group's name.
			//                      Note: This will safely chop UTF-8 strings.
			// @param maxlength     Maximum size of the output name buffer.
			// @return              A GroupId index and a name pointer, or
			//                      INVALID_GROUP_ID and NULL if an error occurred.
			public GroupId GetGroup(int index, char[] name, int maxlength) { throw new NotImplementedException(); }

			// Sets a password on an admin.
			//
			// @param password      String containing the password.
			public void SetPassword(string password) { throw new NotImplementedException(); }

			// Gets an admin's password.
			//
			// @param buffer        Optional buffer to store the admin's password.
			// @param maxlength     Maximum size of the output name buffer.
			//                      Note: This will safely chop UTF-8 strings.
			// @return              True if there was a password set, false otherwise.
			public bool GetPassword(string buffer = "", int maxlength = 0) { throw new NotImplementedException(); }

			// Tests whether one admin can target another.
			//
			// The heuristics for this check are as follows:
			// 0. If the targeting AdminId is INVALID_ADMIN_ID, targeting fails.
			// 1. If the targeted AdminId is INVALID_ADMIN_ID, targeting succeeds.
			// 2. If the targeted AdminId is the same as the targeting AdminId,
			//    (self) targeting succeeds.
			// 3. If the targeting admin is root, targeting succeeds.
			// 4. If the targeted admin has access higher (as interpreted by
			//    (sm_immunity_mode) than the targeting admin, then targeting fails.
			// 5. If the targeted admin has specific immunity from the
			//    targeting admin via group immunities, targeting fails.
			// 6. Targeting succeeds.
			//
			// @param target        Target admin (may be INVALID_ADMIN_ID).
			// @return              True if targetable, false if immune.
			public bool CanTarget(AdminId other) { throw new NotImplementedException(); }

			// The number of groups of which this admin is a member.
			public int GroupCount
			{
				get
				{
					throw new NotImplementedException();
				}
			}

			// Immunity level used for targetting.
			public int ImmunityLevel
			{
				get
				{
					throw new NotImplementedException();
				}
				set
				{
					throw new NotImplementedException();
				}
			}
		}

		public readonly GroupId INVALID_GROUP_ID = -1;   /**< An invalid/non-existent group */

		public class GroupId
		{
			public int _value;
			public static implicit operator GroupId(int value) => new GroupId(value);
			public static implicit operator int(GroupId value) => value._value;

			/**
			 * Identifies a unique entry in the admin permissions cache.  These are not Handles.
			 */

			public GroupId(int value) => _value = value;

			/**
			 * Identifies a unique entry in the group permissions cache.  These are not Handles.
			 */

			// Gets whether or not a flag is enabled on a group's flag set.
			//
			// @param flag          Admin flag to retrieve.
			// @return              True if enabled, false otherwise,
			public bool HasFlag(AdminFlag flag) { throw new NotImplementedException(); }

			// Adds or removes a flag from a group's flag set.
			//
			// @param flag          Admin flag to toggle.
			// @param enabled       True to set the flag, false to unset/disable.
			public void SetFlag(AdminFlag flag, bool enabled) { throw new NotImplementedException(); }

			// Returns the flag set that is added to users from this group.
			//
			// @return              Bitstring containing the flags enabled.
			public int GetFlags() { throw new NotImplementedException(); }

			// Returns a group that this group is immune to given an index.
			//
			// @param number        Index from 0 to N-1, from GroupImmunitiesCount.
			// @return              GroupId that this group is immune to, or INVALID_GROUP_ID on failure.
			public GroupId GetGroupImmunity(int index) { throw new NotImplementedException(); }

			// Adds immunity to a specific group.
			//
			// @param other         Group id to receive immunity to.
			public void AddGroupImmunity(GroupId other) { throw new NotImplementedException(); }

			// Retrieves a group-specific command override.
			//
			// @param name          String containing command name (case sensitive).
			// @param type          Override type (specific command or group).
			// @param rule          Optional pointer to store allow/deny setting.
			// @return              True if an override exists, false otherwise.
			public bool GetCommandOverride(string name, OverrideType type, ref OverrideRule rule) { throw new NotImplementedException(); }

			// Adds a group-specific override type.
			//
			// @param name          String containing command name (case sensitive).
			// @param type          Override type (specific command or group).
			// @param rule          Override allow/deny setting.
			public void AddCommandOverride(string name, OverrideType type, OverrideRule rule) { throw new NotImplementedException(); }

			// Number of specific group immunities
			public int GroupImmunitiesCount
			{
				get { throw new NotImplementedException(); }
			}

			// Immunity level used for targetting.
			public int ImmunityLevel
			{
				get { throw new NotImplementedException(); }
				set { throw new NotImplementedException(); }
			}
		}

		/**
		 * Called when part of the cache needs to be rebuilt.
		 *
		 * @param part          Part of the admin cache to rebuild.
		 */
		public virtual void OnRebuildAdminCache(AdminCachePart part) { throw new NotImplementedException(); }

		/**
		 * Tells the admin system to dump a portion of the cache.
		 *
		 * @param part          Part of the cache to dump.  Specifying groups also dumps admins.
		 * @param rebuild       If true, the rebuild forwards will fire.
		 */
		public static void DumpAdminCache(AdminCachePart part, bool rebuild) { throw new NotImplementedException(); }

		/**
		 * Adds a global command flag override.  Any command registered with this name
		 * will assume the new flag.  This is applied retroactively as well.
		 *
		 * @param cmd           String containing command name (case sensitive).
		 * @param type          Override type (specific command or group).
		 * @param flags         New admin flag.
		 */
		public static void AddCommandOverride(string cmd, OverrideType type, int flags) { throw new NotImplementedException(); }

		/**
		* Returns a command override.
		*
		* @param cmd           String containing command name (case sensitive).
		* @param type          Override type (specific command or group).
		* @param flags         By-reference cell to store the flag (undefined if not found).
		* @return              True if there is an override, false otherwise.
		*/
		public static bool GetCommandOverride(string cmd, OverrideType type, out int flags) { throw new NotImplementedException(); }

		/**
		 * Unsets a command override.
		 *
		 * @param cmd           String containing command name (case sensitive).
		 * @param type          Override type (specific command or group).
		 */
		public static void UnsetCommandOverride(string cmd, OverrideType type) { throw new NotImplementedException(); }

		/**
		 * Adds a new group.  Name must be unique.
		 *
		 * @param group_name    String containing the group name.
		 * @return              A new group id, INVALID_GROUP_ID if it already exists.
		 */
		public static GroupId CreateAdmGroup(string group_name) { throw new NotImplementedException(); }

		/**
		 * Finds a group by name.
		 *
		 * @param group_name    String containing the group name.
		 * @return              A group id, or INVALID_GROUP_ID if not found.
		 */
		public static GroupId FindAdmGroup(string group_name) { throw new NotImplementedException(); }

		/**
		 * Adds or removes a flag from a group's flag set.
		 * @note These are called "add flags" because they add to a user's flags.
		 *
		 * @param id            Group id.
		 * @param flag          Admin flag to toggle.
		 * @param enabled       True to set the flag, false to unset/disable.
		 */
		public static void SetAdmGroupAddFlag(GroupId id, AdminFlag flag, bool enabled) { throw new NotImplementedException(); }

		/**
		 * Gets the set value of an add flag on a group's flag set.
		 * @note These are called "add flags" because they add to a user's flags.
		 *
		 * @param id            Group id.
		 * @param flag          Admin flag to retrieve.
		 * @return              True if enabled, false otherwise,
		 */
		public static bool GetAdmGroupAddFlag(GroupId id, AdminFlag flag) { throw new NotImplementedException(); }

		/**
		 * Returns the flag set that is added to a user from their group.
		 * @note These are called "add flags" because they add to a user's flags.
		 *
		 * @param id            GroupId of the group.
		 * @return              Bitstring containing the flags enabled.
		 */
		public static int GetAdmGroupAddFlags(GroupId id) { throw new NotImplementedException(); }


		/**
		 * Adds immunity to a specific group.
		 *
		 * @param id            Group id.
		 * @param other_id      Group id to receive immunity to.
		 */
		public static void SetAdmGroupImmuneFrom(GroupId id, GroupId other_id) { throw new NotImplementedException(); }

		/**
		 * Returns the number of specific group immunities.
		 *
		 * @param id            Group id.
		 * @return              Number of group immunities.
		 */
		public static int GetAdmGroupImmuneCount(GroupId id) { throw new NotImplementedException(); }

		/**
		 * Returns a group that this group is immune to given an index.
		 *
		 * @param id            Group id.
		 * @param number        Index from 0 to N-1, from GetAdmGroupImmuneCount().
		 * @return              GroupId that this group is immune to, or INVALID_GROUP_ID on failure.
		 */
		public static GroupId GetAdmGroupImmuneFrom(GroupId id, int number) { throw new NotImplementedException(); }

		/**
		 * Adds a group-specific override type.
		 *
		 * @param id            Group id.
		 * @param name          String containing command name (case sensitive).
		 * @param type          Override type (specific command or group).
		 * @param rule          Override allow/deny setting.
		 */
		public static void AddAdmGroupCmdOverride(GroupId id, string name, OverrideType type, OverrideRule rule) { throw new NotImplementedException(); }

		/**
		 * Retrieves a group-specific command override.
		 *
		 * @param id            Group id.
		 * @param name          String containing command name (case sensitive).
		 * @param type          Override type (specific command or group).
		 * @param rule          Optional pointer to store allow/deny setting.
		 * @return              True if an override exists, false otherwise.
		 */
		public static bool GetAdmGroupCmdOverride(GroupId id, string name, OverrideType type, out OverrideRule rule) { throw new NotImplementedException(); }

		/**
		 * Registers an authentication identity type.  You normally never need to call this except for
		 * very specific systems.
		 *
		 * @param name          Codename to use for your authentication type.
		 */
		public static void RegisterAuthIdentType(string name) { throw new NotImplementedException(); }

		/**
		 * Creates a new admin entry in the permissions cache and returns the generated AdminId index.
		 *
		 * @param name          Name for this entry (does not have to be unique).
		 *                      Specify an empty string for an anonymous admin.
		 * @return              New AdminId index or INVALID_ADMIN_ID if name is empty
		 */
		public static AdminId CreateAdmin(string name = "") { throw new NotImplementedException(); }

		/**
		 * Retrieves an admin's user name as made with CreateAdmin().
		 *
		 * @note This function can return UTF-8 strings, and will safely chop UTF-8 strings.
		 *
		 * @param id            AdminId of the admin.
		 * @param name          String buffer to store name.
		 * @param maxlength     Maximum size of string buffer.
		 * @return              Number of bytes written.
		 */
		public static int GetAdminUsername(AdminId id, string name, int maxlength) { throw new NotImplementedException(); }

		/**
		 * Binds an admin to an identity for fast lookup later on.  The bind must be unique.
		 *
		 * @param id            AdminId of the admin.
		 * @param auth          Auth method to use, predefined or from RegisterAuthIdentType().
		 * @param ident         String containing the arbitrary, unique identity.
		 * @return              True on success, false if the auth method was not found,
		 *                      ident was already taken, or ident invalid for auth method.
		 */
		public static bool BindAdminIdentity(AdminId id, string auth, string ident) { throw new NotImplementedException(); }

		/**
		* Sets whether or not a flag is enabled on an admin.
		*
		* @param id            AdminId index of the admin.
		* @param flag          Admin flag to use.
		* @param enabled       True to enable, false to disable.
		*/
		public static void SetAdminFlag(AdminId id, AdminFlag flag, bool enabled) { throw new NotImplementedException(); }

		/**
		* Returns whether or not a flag is enabled on an admin.
		*
		* @param id            AdminId index of the admin.
		* @param flag          Admin flag to use.
		* @param mode          Access mode to check.
		* @return              True if enabled, false otherwise.
		*/
		public static bool GetAdminFlag(AdminId id, AdminFlag flag, AdmAccessMode mode = AdmAccessMode.Access_Effective) { throw new NotImplementedException(); }

		/**
		* Returns the bitstring of access flags on an admin.
		*
		* @param id            AdminId index of the admin.
		* @param mode          Access mode to use.
		* @return              A bitstring containing which flags are enabled.
		*/
		public static int GetAdminFlags(AdminId id, AdmAccessMode mode) { throw new NotImplementedException(); }

		/**
		* Adds a group to an admin's inherited group list.  Any flags the group has
		* will be added to the admin's effective flags.
		*
		* @param id            AdminId index of the admin.
		* @param gid           GroupId index of the group.
		* @return              True on success, false on invalid input or duplicate membership.
		*/
		public static bool AdminInheritGroup(AdminId id, GroupId gid) { throw new NotImplementedException(); }

		/**
		* Returns the number of groups this admin is a member of.
		*
		* @param id            AdminId index of the admin.
		* @return              Number of groups this admin is a member of.
		*/
		public static int GetAdminGroupCount(AdminId id) { throw new NotImplementedException(); }

		/**
		* Returns group information from an admin.
		*
		* @param id            AdminId index of the admin.
		* @param index         Group number to retrieve, from 0 to N-1, where N
		*                      is the value of GetAdminGroupCount(id).
		* @param name          Buffer to store the group's name.
		*                      Note: This will safely chop UTF-8 strings.
		* @param maxlength     Maximum size of the output name buffer.
		* @return              A GroupId index and a name pointer, or
		*                      INVALID_GROUP_ID and NULL if an error occurred.
		*/
		public static GroupId GetAdminGroup(AdminId id, int index, char[] name, int maxlength) { throw new NotImplementedException(); }

		/**
		* Sets a password on an admin.
		*
		* @param id            AdminId index of the admin.
		* @param password      String containing the password.
		*/
		public static void SetAdminPassword(AdminId id, string password) { throw new NotImplementedException(); }

		/**
		* Gets an admin's password.
		*
		* @param id            AdminId index of the admin.
		* @param buffer        Optional buffer to store the admin's password.
		* @param maxlength     Maximum size of the output name buffer.
		*                      Note: This will safely chop UTF-8 strings.
		* @return              True if there was a password set, false otherwise.
		*/
		public static bool GetAdminPassword(AdminId id, string buffer = "", int maxlength = 0) { throw new NotImplementedException(); }

		/**
		* Attempts to find an admin by an auth method and an identity.
		*
		* @param auth          Auth method to try.
		* @param identity      Identity string to look up.
		* @return              An AdminId index if found, INVALID_ADMIN_ID otherwise.
		*/
		public static AdminId FindAdminByIdentity(string auth, string identity) { throw new NotImplementedException(); }

		/**
		* Removes an admin entry from the cache.
		*
		* @note This will remove any bindings to a specific user.
		*
		* @param id            AdminId index to remove/invalidate.
		* @return              True on success, false otherwise.
		*/
		public static bool RemoveAdmin(AdminId id) { throw new NotImplementedException(); }

		/**
		* Converts a flag bit string to a bit array.
		*
		* @param bits          Bit string containing the flags.
		* @param array         Array to write the flags to.  Enabled flags will be 'true'.
		* @param maxSize       Maximum number of flags the array can store.
		* @return              Number of flags written.
		*/
		public static int FlagBitsToBitArray(int bits, bool[] array, int maxSize) { throw new NotImplementedException(); }

		/**
		* Converts a flag array to a bit string.
		*
		* @param array         Array containing true or false for each AdminFlag.
		* @param maxSize       Maximum size of the flag array.
		* @return              A bit string composed of the array bits.
		*/
		public static int FlagBitArrayToBits(ReadOnlyCollection<bool[]> array, int maxSize) { throw new NotImplementedException(); }

		/**
		* Converts an array of flags to bits.
		*
		* @param array         Array containing flags that are enabled.
		* @param numFlags      Number of flags in the array.
		* @return              A bit string composed of the array flags.
		*/
		public static int FlagArrayToBits(ReadOnlyCollection<AdminFlag[]> array, int numFlags) { throw new NotImplementedException(); }

		/**
		* Converts a bit string to an array of flags.
		*
		* @param bits          Bit string containing the flags.
		* @param array         Output array to write flags.
		* @param maxSize       Maximum size of the flag array.
		* @return              Number of flags written.
		*/
		public static int FlagBitsToArray(int bits, AdminFlag[] array, int maxSize) { throw new NotImplementedException(); }

		/**
		* Finds a flag by its string name.
		*
		* @param name          Flag name (like "kick"), case sensitive.
		* @param flag          Variable to store flag in.
		* @return              True on success, false if not found.
		*/
		public static bool FindFlagByName(string name, out AdminFlag flag) { throw new NotImplementedException(); }

		/**
		* Finds a flag by a given character.
		*
		* @param c             Flag ASCII character/token.
		* @param flag          Variable to store flag in.
		* @return              True on success, false if not found.
		*/
		public static bool FindFlagByChar(int c, out AdminFlag flag) { throw new NotImplementedException(); }

		/**
		* Finds the flag char for a given admin flag.
		*
		* @param flag          Flag to look up.
		* @param c             Variable to store flag char.
		* @return              True on success, false if not found.
		*/
		public static bool FindFlagChar(AdminFlag flag, out int c) { throw new NotImplementedException(); }

		/**
		* Converts a string of flag characters to a bit string.
		*
		* @param flags         Flag ASCII string.
		* @param numchars      Optional variable to store the number of bytes read.
		* @return              Bit string of ADMFLAG values.
		*/
		public static int ReadFlagString(string flags) { throw new NotImplementedException(); }


		/**
		* Converts a string of flag characters to a bit string.
		*
		* @param flags         Flag ASCII string.
		* @param numchars      Optional variable to store the number of bytes read.
		* @return              Bit string of ADMFLAG values.
		*/
		public static int ReadFlagString(string flags, out int numchars) { throw new NotImplementedException(); }

		/**
		* Tests whether one admin can target another.
		*
		* The heuristics for this check are as follows:
		* 0. If the targeting AdminId is INVALID_ADMIN_ID, targeting fails.
		* 1. If the targeted AdminId is INVALID_ADMIN_ID, targeting succeeds.
		* 2. If the targeted AdminId is the same as the targeting AdminId,
		*    (self) targeting succeeds.
		* 3. If the targeting admin is root, targeting succeeds.
		* 4. If the targeted admin has access higher (as interpreted by
		*    (sm_immunity_mode) than the targeting admin, then targeting fails.
		* 5. If the targeted admin has specific immunity from the
		*    targeting admin via group immunities, targeting fails.
		* 6. Targeting succeeds.
		*
		* @param admin         Admin doing the targetting (may be INVALID_ADMIN_ID).
		* @param target        Target admin (may be INVALID_ADMIN_ID).
		* @return              True if targetable, false if immune.
		*/
		public static bool CanAdminTarget(AdminId admin, AdminId target) { throw new NotImplementedException(); }

		/**
		* Creates an admin auth method.  This does not need to be called more than once
		* per method, ever.
		*
		* @param method        Name of the authentication method.
		* @return              True on success, false on failure.
		*/
		public static bool CreateAuthMethod(string method) { throw new NotImplementedException(); }

		/**
		* Sets a group's immunity level.
		*
		* @param gid           Group Id.
		* @param level         Immunity level value.
		* @return              Old immunity level value.
		*/
		public static int SetAdmGroupImmunityLevel(GroupId gid, int level) { throw new NotImplementedException(); }

		/**
		* Gets a group's immunity level (defaults to 0).
		*
		* @param gid           Group Id.
		* @return              Immunity level value.
		*/
		public static int GetAdmGroupImmunityLevel(GroupId gid) { throw new NotImplementedException(); }

		/**
		* Sets an admin's immunity level.
		*
		* @param id            Admin Id.
		* @param level         Immunity level value.
		* @return              Old immunity level value.
		*/
		public static int SetAdminImmunityLevel(AdminId id, int level) { throw new NotImplementedException(); }

		/**
		* Gets an admin's immunity level.
		*
		* @param id            Admin Id.
		* @return              Immunity level value.
		*/
		public static int GetAdminImmunityLevel(AdminId id) { throw new NotImplementedException(); }

		/**
		* Converts a flag to its single bit.
		*
		* @param flag          Flag to convert.
		* @return              Bit representation of the flag.
		*/
		public static int FlagToBit(AdminFlag flag)
		{
			return (1 << flag);
		}

		/**
		* Converts a bit to an AdminFlag.
		*
		* @param bit           Bit to convert.
		* @param flag          Stores the converted flag by reference.
		* @return              True on success, false otherwise.
		*/
		public static bool BitToFlag(int bit, out AdminFlag flag)
		{
			AdminFlag[] array = new AdminFlag[1];

			if (FlagBitsToArray(bit, array, 1) != 0)
			{
				flag = array[0];
				return true;
			}

			flag = -1;
			return false;
		}

	}
}

