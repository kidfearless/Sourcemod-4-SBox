/**
 * vim: set ts=4 :
 * =============================================================================
 * SourceMod (C)2004-2011 AlliedModders LLC.  All rights reserved.
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
		 * public types for entities.
		 */
		public enum PropType
		{
			Prop_Send = 0,  /**< This public is networked. */
			Prop_Data = 1   /**< This public is for save game data fields. */
		};
		public const int 
			Prop_Send = 0,  /**< This public is networked. */
			Prop_Data = 1;   /**< This public is for save game data fields. */

		/**
		 * @section For more information on these, see the HL2SDK (public/edict.h)
		 */
		public const int FL_EDICT_CHANGED = (1 << 0);  /**< Game DLL sets this when the entity state changes
                                                     Mutually exclusive with FL_EDICT_PARTIAL_CHANGE. */
		public const int FL_EDICT_FREE = (1 << 1);  /**< this edict if free for reuse */
		public const int FL_EDICT_FULL = (1 << 2);  /**< this is a full server entity */
		public const int FL_EDICT_FULLCHECK = (0 << 0);  /**< call ShouldTransmit() each time, this is a fake flag */
		public const int FL_EDICT_ALWAYS = (1 << 3);  /**< always transmit this entity */
		public const int FL_EDICT_DONTSEND = (1 << 4);  /**< don't transmit this entity */
		public const int FL_EDICT_PVSCHECK = (1 << 5);  /**< always transmit entity, but cull against PVS */
		public const int FL_EDICT_PENDING_DORMANT_CHECK = (1 << 6);
		public const int FL_EDICT_DIRTY_PVS_INFORMATION = (1 << 7);
		public const int FL_FULL_EDICT_CHANGED = (1 << 8);

		public enum PropFieldType
		{
			PropField_Unsupported,      /**< The type is unsupported. */
			PropField_Integer,          /**< Valid for SendProp and Data fields */
			PropField_Float,            /**< Valid for SendProp and Data fields */
			PropField_Entity,           /**< Valid for Data fields only (SendProp shows as int) */
			PropField_Vector,           /**< Valid for SendProp and Data fields */
			PropField_String,           /**< Valid for SendProp and Data fields */
			PropField_String_T,         /**< Valid for Data fields.  Read only.
	                                 Note that the size of a string_t is dynamic, and
	                                 thus FindDataMapOffs() will return the constant size
	                                 of the string_t container (which is 32 bits right now). */
			PropField_Variant           /**< Valid for Data fields only Type is not known at the field level,
                                     (for this call), but dependent on current field value. */
		};
		public const int 
			PropField_Unsupported = 0,      /**< The type is unsupported. */
			PropField_Integer = 1,          /**< Valid for SendProp and Data fields */
			PropField_Float = 2,            /**< Valid for SendProp and Data fields */
			PropField_Entity = 3,           /**< Valid for Data fields only (SendProp shows as int) */
			PropField_Vector = 4,           /**< Valid for SendProp and Data fields */
			PropField_String = 5,           /**< Valid for SendProp and Data fields */
			PropField_String_T = 6,         /**< Valid for Data fields.  Read only.
	                                 Note that the size of a string_t is dynamic, and
	                                 thus FindDataMapOffs() will return the constant size
	                                 of the string_t container (which is 32 bits right now). */
			PropField_Variant = 7;           /**< Valid for Data fields only Type is not known at the field level,
                                     (for this call), but dependent on current field value. */

		/**
		 * @endsection
		 */

		/**
		 * Returns the maximum number of networked entities.
		 *
		 * Note: For legacy reasons, this only returns the maximum
		 * networked entities (maximum edicts), rather than total
		 * maximum entities.
		 *
		 * @return              Maximum number of networked entities.
		 */
		public static int GetMaxEntities() { throw new NotImplementedException(); }

		/**
		 * Returns the number of networked entities in the server.
		 *
		 * Note: For legacy reasons, this only returns the current count
		 * of networked entities (current edicts), rather than total
		 * count of current entities.
		 *
		 * @return              Number of entities in the server.
		 */
		public static int GetEntityCount() { throw new NotImplementedException(); }

		/**
		 * Returns whether or not an entity is valid.  Returns false
		 * if there is no matching CBaseEntity for this entity index.
		 *
		 * @param entity        Index of the entity.
		 * @return              True if valid, false otherwise.
		 */
		public static bool IsValidEntity(int entity) { throw new NotImplementedException(); }

		/**
		 * Returns whether or not an edict index is valid.
		 *
		 * @param edict         Index of the edict.
		 * @return              True if valid, false otherwise.
		 */
		public static bool IsValidEdict(int edict) { throw new NotImplementedException(); }

		/**
		 * Returns whether or not an entity has a valid networkable edict.
		 *
		 * @param entity        Index of the entity.
		 * @return              True if networkable, false if invalid or not networkable.
		 */
		public static bool IsEntNetworkable(int entity) { throw new NotImplementedException(); }

		/**
		 * Creates a new edict (the basis of a networkable entity)
		 *
		 * @return              Index of the edict, 0 on failure.
		 */
		public static int CreateEdict() { throw new NotImplementedException(); }

		/**
		 * Removes an edict from the world.
		 *
		 * @param edict         Index of the edict.
		 * @error               Invalid edict index.
		 */
		public static void RemoveEdict(int edict) { throw new NotImplementedException(); }

		/**
		 * Marks an entity for deletion.
		 *
		 * @param entity        Index of the entity.
		 * @error               Invalid entity index.
		 */
		public static void RemoveEntity(int entity) { throw new NotImplementedException(); }

		/**
		 * Returns the flags on an edict.  These are not the same as entity flags.
		 *
		 * @param edict         Index of the entity.
		 * @return              Edict flags.
		 * @error               Invalid edict index.
		 */
		public static int GetEdictFlags(int edict) { throw new NotImplementedException(); }

		/**
		 * Sets the flags on an edict.  These are not the same as entity flags.
		 *
		 * @param edict         Index of the entity.
		 * @param flags         Flags to set.
		 * @error               Invalid edict index.
		 */
		public static void SetEdictFlags(int edict, int flags) { throw new NotImplementedException(); }

		/**
		 * Retrieves an edict classname.
		 *
		 * @param edict         Index of the entity.
		 * @param clsname       Buffer to store the classname.
		 * @param maxlength     Maximum length of the buffer.
		 * @return              True on success, false if there is no classname set.
		 */
		public static bool GetEdictClassname(int edict, out string clsname, int maxlength) { throw new NotImplementedException(); }

		/**
		 * Retrieves an entity's networkable serverclass name.
		 * This is not the same as the classname and is used for networkable state changes.
		 *
		 * @param edict         Index of the entity.
		 * @param clsname       Buffer to store the serverclass name.
		 * @param maxlength     Maximum length of the buffer.
		 * @return              True on success, false if the edict is not networkable.
		 * @error               Invalid edict index.
		 */
		public static bool GetEntityNetClass(int edict, out string clsname, int maxlength) { throw new NotImplementedException(); }

		/**
		 * @section Entity offset functions
		 *
		 * Offsets should be specified in byte distance from the CBaseEntity
		 * structure, not short (double byte) or integer (four byte) multiples.
		 * It is somewhat common practice to use offsets aligned to their final
		 * type, and thus make sure you are not falling to this error in SourceMod.
		 * For example, if your "integer-aligned" offset was 119, your byte-aligned
		 * offset is 119*4, or 476.

		 * Specifying incorrect offsets or the incorrect data type for an offset
		 * can have fatal consequences.  If you are hardcoding offsets, and the
		 * layout of CBaseEntity does not match, you can easily crash the server.
		 *
		 * The reasonable bounds for offsets is greater than or equal to 0 and
		 * below 32768.  Offsets out of these bounds will throw an error.  However,
		 * this does not represent any real range, it is simply a sanity check for
		 * illegal values.  Any range outside of the CBaseEntity structure's private
		 * size will cause undefined behavior or even crash.
		 */

		/**
		 * Marks an entity as state changed.  This can be useful if you set an offset
		 * and wish for it to be immediately changed over the network.  By default this
		 * is not done for offset setting functions.
		 *
		 * @param edict         Index to the edict.
		 * @param offset        Offset to mark as changed.  If 0,
		 *                      the entire edict is marked as changed.
		 * @error               Invalid entity or offset out of bounds.
		 */
		public static void ChangeEdictState(int edict, int offset = 0) { throw new NotImplementedException(); }

		/**
		 * Peeks into an entity's object data and retrieves the integer value at
		 * the given offset.
		 *
		 * @param entity        Edict index.
		 * @param offset        Offset to use.
		 * @param size          Number of bytes to read (valid values are 1, 2, or 4).
		 * @return              Value at the given memory location.
		 * @error               Invalid entity or offset out of reasonable bounds.
		 */
		public static int GetEntData(int entity, int offset, int size = 4) { throw new NotImplementedException(); }

		/**
		 * Peeks into an entity's object data and sets the integer value at
		 * the given offset.
		 *
		 * @param entity        Edict index.
		 * @param offset        Offset to use.
		 * @param value         Value to set.
		 * @param size          Number of bytes to write (valid values are 1, 2, or 4).
		 * @param changeState   If true, change will be sent over the network.
		 * @error               Invalid entity or offset out of reasonable bounds.
		 */
		public static void SetEntData(int entity, int offset, any value, int size = 4, bool changeState = false) { throw new NotImplementedException(); }

		/**
		 * Peeks into an entity's object data and retrieves the float value at
		 * the given offset.
		 *
		 * @param entity        Edict index.
		 * @param offset        Offset to use.
		 * @return              Value at the given memory location.
		 * @error               Invalid entity or offset out of reasonable bounds.
		 */
		public static float GetEntDataFloat(int entity, int offset) { throw new NotImplementedException(); }

		/**
		 * Peeks into an entity's object data and sets the float value at
		 * the given offset.
		 *
		 * @param entity        Edict index.
		 * @param offset        Offset to use.
		 * @param value         Value to set.
		 * @param changeState   If true, change will be sent over the network.
		 * @error               Invalid entity or offset out of reasonable bounds.
		 */
		public static void SetEntDataFloat(int entity, int offset, float value, bool changeState = false) { throw new NotImplementedException(); }

		/**
		 * This function is deprecated.  Use GetEntDataEnt2 instead, for
		 * reasons explained in the notes.
		 *
		 * Note: This function returns 0 on failure, which may be misleading,
		 * as the number 0 is also used for the world entity index.
		 *
		 * Note: This function makes no attempt to validate the returned
		 * entity, and in fact, it could be garbage or completely unexpected.
		 *
		 * @param entity        Edict index.
		 * @param offset        Offset to use.
		 * @return              Entity index at the given location, or 0 if none.
		 * @error               Invalid entity or offset out of reasonable bounds.
		 * @deprecated          Use GetEntDataEnt2() instead.
		 */
		public static int GetEntDataEnt(int entity, int offset) => GetEntDataEnt2(entity, offset);

		/**
		 * This function is deprecated.   Use SetEntDataEnt2 instead, for
		 * reasons explained in the notes.
		 *
		 * Note: This function uses 0 as an indicator to unset data, but
		 * 0 is also the world entity index.  Thus, a public cannot
		 * be set to the world entity using this native.
		 *
		 * @param entity        Edict index.
		 * @param offset        Offset to use.
		 * @param other         Entity index to set, or 0 to clear.
		 * @param changeState   If true, change will be sent over the network.
		 * @error               Invalid entity or offset out of reasonable bounds.
		 * @deprecated          Use SetEntDataEnt2() instead.
		 */
		public static void SetEntDataEnt(int entity, int offset, int other, bool changeState = false) => SetEntDataEnt2(entity, offset, other, changeState);

		/**
		 * Peeks into an entity's object data and retrieves the entity index
		 * at the given offset.
		 *
		 * Note: This will only work on offsets that are stored as "entity
		 * handles" (which usually looks like m_h* in properties).  These
		 * are not SourceMod Handles, but internal Source structures.
		 *
		 * @param entity        Edict index.
		 * @param offset        Offset to use.
		 * @return              Entity index at the given location.  If there is no entity,
		 *                      or the stored entity is invalid, then -1 is returned.
		 * @error               Invalid input entity, or offset out of reasonable bounds.
		 */
		public static int GetEntDataEnt2(int entity, int offset) { throw new NotImplementedException(); }

		/**
		 * Peeks into an entity's object data and sets the entity index at the
		 * given offset.
		 *
		 * Note: This will only work on offsets that are stored as "entity
		 * handles" (which usually looks like m_h* in properties).  These
		 * are not SourceMod Handles, but internal Source structures.
		 *
		 * @param entity        Edict index.
		 * @param offset        Offset to use.
		 * @param other         Entity index to set, or -1 to clear.
		 * @param changeState   If true, change will be sent over the network.
		 * @error               Invalid input entity, or offset out of reasonable bounds.
		 */
		public static void SetEntDataEnt2(int entity, int offset, int other, bool changeState = false) { throw new NotImplementedException(); }

		/**
		 * Peeks into an entity's object data and retrieves the vector at the
		 * given offset.
		 * @note Both a Vector and a QAngle are three floats.  This is a
		 *       convenience function and will work with both types.
		 *
		 * @param entity        Edict index.
		 * @param offset        Offset to use.
		 * @param vec           Vector buffer to store data in.
		 * @error               Invalid entity or offset out of reasonable bounds.
		 */
		public static void GetEntDataVector(int entity, int offset, float[] vec) { throw new NotImplementedException(); }

		/**
		 * Peeks into an entity's object data and sets the vector at the given
		 * offset.
		 * @note Both a Vector and a QAngle are three floats.  This is a
		 *       convenience function and will work with both types.
		 *
		 * @param entity        Edict index.
		 * @param offset        Offset to use.
		 * @param vec           Vector to set.
		 * @param changeState   If true, change will be sent over the network.
		 * @error               Invalid entity or offset out of reasonable bounds.
		 */
		public static void SetEntDataVector(int entity, int offset, float[] vec, bool changeState = false) { throw new NotImplementedException(); }

		/**
		 * Peeks into an entity's object data and retrieves the string at
		 * the given offset.
		 *
		 * @param entity        Edict index.
		 * @param offset        Offset to use.
		 * @param buffer        Destination string buffer.
		 * @param maxlen        Maximum length of output string buffer.
		 * @return              Number of non-null bytes written.
		 * @error               Invalid entity or offset out of reasonable bounds.
		 */
		public static int GetEntDataString(int entity, int offset, string buffer, int maxlen) { throw new NotImplementedException(); }

		/**
		 * Peeks into an entity's object data and sets the string at
		 * the given offset.
		 *
		 * @param entity        Edict index.
		 * @param offset        Offset to use.
		 * @param buffer        String to set.
		 * @param maxlen        Maximum length of bytes to write.
		 * @param changeState   If true, change will be sent over the network.
		 * @return              Number of non-null bytes written.
		 * @error               Invalid entity or offset out of reasonable bounds.
		 */
		public static int SetEntDataString(int entity, int offset, string buffer, int maxlen, bool changeState = false) { throw new NotImplementedException(); }

		/**
		 * @endsection
		 */


		/**
		 * Given a ServerClass name, finds a networkable send public offset.
		 * This information is cached for future calls.
		 *
		 * @param cls           Classname.
		 * @param prop          public name.
		 * @param type          Optional parameter to store the type.
		 * @param num_bits      Optional parameter to store the number of bits the field
		 *                      uses, if applicable (otherwise 0 is stored).  The number
		 *                      of bits varies for integers and floats, and is always 0
		 *                      for strings.
		 * @param local_offset  Optional parameter to store the local offset, as
		 *                      FindSendPropOffs() would return.
		 * @return              On success, returns an absolutely computed offset.
		 *                      If no offset is available, 0 is returned.
		 *                      If the public is not found, -1 is returned.
		 */
		public static int FindSendPropInfo(string cls, string prop, out PropFieldType type, out int num_bits, out int local_offset) { throw new NotImplementedException(); }


		/**
		 * Given a ServerClass name, finds a networkable send public offset.
		 * This information is cached for future calls.
		 *
		 * @param cls           Classname.
		 * @param prop          public name.
		 * @param type          Optional parameter to store the type.
		 * @param num_bits      Optional parameter to store the number of bits the field
		 *                      uses, if applicable (otherwise 0 is stored).  The number
		 *                      of bits varies for integers and floats, and is always 0
		 *                      for strings.
		 * @param local_offset  Optional parameter to store the local offset, as
		 *                      FindSendPropOffs() would return.
		 * @return              On success, returns an absolutely computed offset.
		 *                      If no offset is available, 0 is returned.
		 *                      If the public is not found, -1 is returned.
		 */
		public static int FindSendPropInfo(string cls, string prop, out PropFieldType type, out int num_bits) { throw new NotImplementedException(); }

		/**
		 * Given a ServerClass name, finds a networkable send public offset.
		 * This information is cached for future calls.
		 *
		 * @param cls           Classname.
		 * @param prop          public name.
		 * @param type          Optional parameter to store the type.
		 * @param num_bits      Optional parameter to store the number of bits the field
		 *                      uses, if applicable (otherwise 0 is stored).  The number
		 *                      of bits varies for integers and floats, and is always 0
		 *                      for strings.
		 * @param local_offset  Optional parameter to store the local offset, as
		 *                      FindSendPropOffs() would return.
		 * @return              On success, returns an absolutely computed offset.
		 *                      If no offset is available, 0 is returned.
		 *                      If the public is not found, -1 is returned.
		 */
		public static int FindSendPropInfo(string cls, string prop, out PropFieldType type) { throw new NotImplementedException(); }

		/**
		 * Given a ServerClass name, finds a networkable send public offset.
		 * This information is cached for future calls.
		 *
		 * @param cls           Classname.
		 * @param prop          public name.
		 * @param type          Optional parameter to store the type.
		 * @param num_bits      Optional parameter to store the number of bits the field
		 *                      uses, if applicable (otherwise 0 is stored).  The number
		 *                      of bits varies for integers and floats, and is always 0
		 *                      for strings.
		 * @param local_offset  Optional parameter to store the local offset, as
		 *                      FindSendPropOffs() would return.
		 * @return              On success, returns an absolutely computed offset.
		 *                      If no offset is available, 0 is returned.
		 *                      If the public is not found, -1 is returned.
		 */
		public static int FindSendPropInfo(string cls, string prop) { throw new NotImplementedException(); }


		/**
		 * Given an entity, finds a nested datamap public offset.
		 * This information is cached for future calls.
		 *
		 * @param entity        Entity index.
		 * @param prop          public name.
		 * @param type          Optional parameter to store the type.
		 * @param num_bits      Optional parameter to store the number of bits the field
		 *                      uses.  The bit count will either be 1 (for boolean) or
		 *                      divisible by 8 (including 0 if unknown).
		 * @param local_offset  Optional parameter to store the local offset, as
		 *                      FindDataMapOffs() would return.
		 * @return              An offset, or -1 on failure.
		 */
		public static int FindDataMapInfo(int entity, string prop, out PropFieldType type, out int num_bits, out int local_offset) { throw new NotImplementedException(); }

		/**
		 * Given an entity, finds a nested datamap public offset.
		 * This information is cached for future calls.
		 *
		 * @param entity        Entity index.
		 * @param prop          public name.
		 * @param type          Optional parameter to store the type.
		 * @param num_bits      Optional parameter to store the number of bits the field
		 *                      uses.  The bit count will either be 1 (for boolean) or
		 *                      divisible by 8 (including 0 if unknown).
		 * @param local_offset  Optional parameter to store the local offset, as
		 *                      FindDataMapOffs() would return.
		 * @return              An offset, or -1 on failure.
		 */
		public static int FindDataMapInfo(int entity, string prop, out PropFieldType type, out int num_bits) { throw new NotImplementedException(); }

		/**
		 * Given an entity, finds a nested datamap public offset.
		 * This information is cached for future calls.
		 *
		 * @param entity        Entity index.
		 * @param prop          public name.
		 * @param type          Optional parameter to store the type.
		 * @param num_bits      Optional parameter to store the number of bits the field
		 *                      uses.  The bit count will either be 1 (for boolean) or
		 *                      divisible by 8 (including 0 if unknown).
		 * @param local_offset  Optional parameter to store the local offset, as
		 *                      FindDataMapOffs() would return.
		 * @return              An offset, or -1 on failure.
		 */
		public static int FindDataMapInfo(int entity, string prop, out PropFieldType type) { throw new NotImplementedException(); }

		/**
		 * Given an entity, finds a nested datamap public offset.
		 * This information is cached for future calls.
		 *
		 * @param entity        Entity index.
		 * @param prop          public name.
		 * @param type          Optional parameter to store the type.
		 * @param num_bits      Optional parameter to store the number of bits the field
		 *                      uses.  The bit count will either be 1 (for boolean) or
		 *                      divisible by 8 (including 0 if unknown).
		 * @param local_offset  Optional parameter to store the local offset, as
		 *                      FindDataMapOffs() would return.
		 * @return              An offset, or -1 on failure.
		 */
		public static int FindDataMapInfo(int entity, string prop) { throw new NotImplementedException(); }
		/**
		 * Wrapper function for finding a send public for a particular entity.
		 *
		 * @param ent           Entity index.
		 * @param prop          public name.
		 * @param actual        Defaults to false for backwards compatibility.
		 *                      If true, the newer FindSendPropInfo() function
		 *                      is used instead.
		 * @return              An offset, or -1 on failure.
		 */
		public static int GetEntSendPropOffs(int ent, string prop, bool actual = false)
		{
			if (!GetEntityNetClass(ent, out string cls, 64))
			{
				return -1;
			}

			int local = -1;
			int offset = FindSendPropInfo(cls, prop, out PropFieldType _, out int _, out local);

			if (actual)
			{
				return offset;
			}

			return local;
		}

		/**
		 * Checks if an entity public exists on an entity.
		 *
		 * @param entity        Entity/edict index.
		 * @param type          public type.
		 * @param prop          public name.
		 * @return              Whether the public exists on the entity.
		 * @error               Invalid entity.
		 */
		public static bool HasEntProp(int entity, PropType type, string prop)
		{
			if (type == PropType.Prop_Data)
			{
				return (FindDataMapInfo(entity, prop) != -1);
			}

			if (type != PropType.Prop_Send)
			{
				return false;
			}

			if (!GetEntityNetClass(entity, out string cls, 64))
			{
				return false;
			}

			return (FindSendPropInfo(cls, prop) != -1);
		}

		/**
		 * Retrieves an integer value from an entity's property.
		 *
		 * This function is considered safer and more robust over GetEntData,
		 * because it performs strict offset checking and typing rules.
		 *
		 * @param entity        Entity/edict index.
		 * @param type          public type.
		 * @param prop          public name.
		 * @param size          Number of bytes to write (valid values are 1, 2, or 4).
		 *                      This value is auto-detected, and the size parameter is
		 *                      only used as a fallback in case detection fails.
		 * @param element       Element # (starting from 0) if public is an array.
		 * @return              Value at the given public offset.
		 * @error               Invalid entity or public not found.
		 */
		public static int GetEntProp(int entity, PropType type, string prop, int size = 4, int element = 0) { throw new NotImplementedException(); }

		/**
		 * Sets an integer value in an entity's property.
		 *
		 * This function is considered safer and more robust over SetEntData,
		 * because it performs strict offset checking and typing rules.
		 *
		 * @param entity        Entity/edict index.
		 * @param type          public type.
		 * @param prop          public name.
		 * @param value         Value to set.
		 * @param size          Number of bytes to write (valid values are 1, 2, or 4).
		 *                      This value is auto-detected, and the size parameter is
		 *                      only used as a fallback in case detection fails.
		 * @param element       Element # (starting from 0) if public is an array.
		 * @error               Invalid entity or offset out of reasonable bounds.
		 */
		public static void SetEntProp(int entity, PropType type, string prop, any value, int size = 4, int element = 0) { throw new NotImplementedException(); }

		/**
		 * Retrieves a float value from an entity's property.
		 *
		 * This function is considered safer and more robust over GetEntDataFloat,
		 * because it performs strict offset checking and typing rules.
		 *
		 * @param entity        Entity/edict index.
		 * @param type          public type.
		 * @param prop          public name.
		 * @param element       Element # (starting from 0) if public is an array.
		 * @return              Value at the given public offset.
		 * @error               Invalid entity or offset out of reasonable bounds.
		 */
		public static float GetEntPropFloat(int entity, PropType type, string prop, int element = 0) { throw new NotImplementedException(); }

		/**
		 * Sets a float value in an entity's property.
		 *
		 * This function is considered safer and more robust over SetEntDataFloat,
		 * because it performs strict offset checking and typing rules.
		 *
		 * @param entity        Entity/edict index.
		 * @param type          public type.
		 * @param prop          public name.
		 * @param value         Value to set.
		 * @param element       Element # (starting from 0) if public is an array.
		 * @error               Invalid entity or offset out of reasonable bounds.
		 */
		public static void SetEntPropFloat(int entity, PropType type, string prop, float value, int element = 0) { throw new NotImplementedException(); }

		/**
		 * Retrieves an entity index from an entity's property.
		 *
		 * This function is considered safer and more robust over GetEntDataEnt*,
		 * because it performs strict offset checking and typing rules.
		 *
		 * @param entity        Entity/edict index.
		 * @param type          public type.
		 * @param prop          public name.
		 * @param element       Element # (starting from 0) if public is an array.
		 * @return              Entity index at the given property.
		 *                      If there is no entity, or the entity is not valid,
		 *                      then -1 is returned.
		 * @error               Invalid entity or offset out of reasonable bounds.
		 */
		public static int GetEntPropEnt(int entity, PropType type, string prop, int element = 0) { throw new NotImplementedException(); }

		/**
		 * Sets an entity index in an entity's property.
		 *
		 * This function is considered safer and more robust over SetEntDataEnt*,
		 * because it performs strict offset checking and typing rules.
		 *
		 * @param entity        Entity/edict index.
		 * @param type          public type.
		 * @param prop          public name.
		 * @param other         Entity index to set, or -1 to unset.
		 * @param element       Element # (starting from 0) if public is an array.
		 * @error               Invalid entity or offset out of reasonable bounds.
		 */
		public static void SetEntPropEnt(int entity, PropType type, string prop, int other, int element = 0) { throw new NotImplementedException(); }

		/**
		 * Retrieves a vector of floats from an entity, given a named network property.
		 *
		 * This function is considered safer and more robust over GetEntDataVector,
		 * because it performs strict offset checking and typing rules.
		 *
		 * @param entity        Entity/edict index.
		 * @param type          public type.
		 * @param prop          public name.
		 * @param vec           Vector buffer to store data in.
		 * @param element       Element # (starting from 0) if public is an array.
		 * @error               Invalid entity, public not found, or public not
		 *                      actually a vector data type.
		 */
		public static void GetEntPropVector(int entity, PropType type, string prop, float[] vec, int element = 0) { throw new NotImplementedException(); }

		/**
		 * Sets a vector of floats in an entity, given a named network property.
		 *
		 * This function is considered safer and more robust over SetEntDataVector,
		 * because it performs strict offset checking and typing rules.
		 *
		 * @param entity        Entity/edict index.
		 * @param type          public type.
		 * @param prop          public name.
		 * @param vec           Vector to set.
		 * @param element       Element # (starting from 0) if public is an array.
		 * @error               Invalid entity, public not found, or public not
		 *                      actually a vector data type.
		 */
		public static void SetEntPropVector(int entity, PropType type, string prop, float[] vec, int element = 0) { throw new NotImplementedException(); }

		/**
		 * Gets a network public as a string.
		 *
		 * @param entity        Edict index.
		 * @param type          public type.
		 * @param prop          public to use.
		 * @param buffer        Destination string buffer.
		 * @param maxlen        Maximum length of output string buffer.
		 * @param element       Element # (starting from 0) if public is an array.
		 * @return              Number of non-null bytes written.
		 * @error               Invalid entity, offset out of reasonable bounds, or public is not a valid string.
		 */
		public static int GetEntPropString(int entity, PropType type, string prop, string buffer, int maxlen, int element = 0) { throw new NotImplementedException(); }

		/**
		 * Sets a network public as a string.
		 *
		 * @param entity        Edict index.
		 * @param type          public type.
		 * @param prop          public to use.
		 * @param buffer        String to set.
		 * @param element       Element # (starting from 0) if public is an array.
		 * @return              Number of non-null bytes written.
		 * @error               Invalid entity, offset out of reasonable bounds, or public is not a valid string.
		 */
		public static int SetEntPropString(int entity, PropType type, string prop, string buffer, int element = 0) { throw new NotImplementedException(); }

		/**
		 * Retrieves the count of values that an entity property's array can store.
		 *
		 * @param entity        Entity/edict index.
		 * @param type          public type.
		 * @param prop          public name.
		 * @return              Size of array (in elements) or 1 if public is not an array.
		 * @error               Invalid entity or public not found.
		 */
		public static int GetEntPropArraySize(int entity, PropType type, string prop) { throw new NotImplementedException(); }

		/**
		 * Copies an array of cells from an entity at a given offset.
		 *
		 * @param entity        Entity index.
		 * @param offset        Offset to use.
		 * @param array         Array to read into.
		 * @param arraySize     Number of values to read.
		 * @param dataSize      Size of each value in bytes (1, 2, or 4).
		 * @error               Invalid entity or offset out of reasonable bounds.
		 */
		public static void GetEntDataArray(int entity, int offset, any[] array, int arraySize, int dataSize = 4)
		{
			for (int i = 0; i < arraySize; i++)
			{
				array[i] = GetEntData(entity, offset + i * dataSize, dataSize);
			}
		}

		/**
		 * Copies an array of cells to an entity at a given offset.
		 *
		 * @param entity        Entity index.
		 * @param offset        Offset to use.
		 * @param array         Array of values to copy.
		 * @param arraySize     Number of values to copy.
		 * @param dataSize      Size of each value in bytes (1, 2, or 4).
		 * @param changeState   True to set the network state as changed; false otherwise.
		 * @error               Invalid entity or offset out of reasonable bounds.
		 */
		public static void SetEntDataArray(int entity, int offset, any[] array, int arraySize, int dataSize = 4, bool changeState = false)
		{
			for (int i = 0; i < arraySize; i++)
			{
				SetEntData(entity, offset + i * dataSize, array[i], dataSize, changeState);
			}
		}

		/**
		 * Gets the memory address of an entity.
		 *
		 * @param entity        Entity index.
		 * @return              Address of the entity.
		 * @error               Invalid entity.
		 */
		public static Address GetEntityAddress(int entity) { throw new NotImplementedException(); }

		/**
		 * Retrieves the classname of an entity.
		 * This is like GetEdictClassname(), except it works for ALL
		 * entities, not just edicts.
		 *
		 * @param entity        Index of the entity.
		 * @param clsname       Buffer to store the classname.
		 * @param maxlength     Maximum length of the buffer.
		 * @return              True on success, false if there is no classname set.
		 */
		public static bool GetEntityClassname(int entity, string clsname, int maxlength)
		{
			return GetEntPropString(entity, PropType.Prop_Data, "m_iClassname", clsname, maxlength) != 0;
		}
	}
}