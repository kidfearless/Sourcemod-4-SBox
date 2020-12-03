/**
 * vim: set ts=4 :
 * =============================================================================
 * SourceMod (C)2004-2017 AlliedModders LLC.  All rights reserved.
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
		public enum SDKCallType
		{
			SDKCall_Static,         /**< Static call */
			SDKCall_Entity,         /**< CBaseEntity call */
			SDKCall_Player,         /**< CBasePlayer call */
			SDKCall_GameRules,      /**< CGameRules call */
			SDKCall_EntityList,     /**< CGlobalEntityList call */
			SDKCall_Raw             /**< |this| pointer with an arbitrary address */
		};

		public enum SDKLibrary
		{
			SDKLibrary_Server,      /**< server.dll/server_i486.so */
			SDKLibrary_Engine       /**< engine.dll/engine_*.so */
		};

		public enum SDKFuncConfSource
		{
			SDKConf_Virtual = 0,    /**< Read a virtual index from the Offsets section */
			SDKConf_Signature = 1,  /**< Read a signature from the Signatures section */
			SDKConf_Address = 2     /**< Read an address from the Addresses section */
		};

		public enum SDKType
		{
			SDKType_CBaseEntity,    /**< CBaseEntity (always as pointer) */
			SDKType_CBasePlayer,    /**< CBasePlayer (always as pointer) */
			SDKType_Vector,         /**< Vector (pointer, byval, or byref) */
			SDKType_QAngle,         /**< QAngles (pointer, byval, or byref) */
			SDKType_PlainOldData,   /**< Integer/generic data <=32bit (any) */
			SDKType_Float,          /**< Float (any) */
			SDKType_Edict,          /**< edict_t (always as pointer) */
			SDKType_String,         /**< NULL-terminated string (always as pointer) */
			SDKType_Bool            /**< Boolean (any) */
		};

		public enum SDKPassMethod
		{
			SDKPass_Pointer,        /**< Pass as a pointer */
			SDKPass_Plain,          /**< Pass as plain data */
			SDKPass_ByValue,        /**< Pass an object by value */
			SDKPass_ByRef           /**< Pass an object by reference */
		};

		public const int VDECODE_FLAG_ALLOWNULL = (1 << 0);     /**< Allow NULL for pointers */
		public const int VDECODE_FLAG_ALLOWNOTINGAME = (1 << 1);     /**< Allow players not in game */
		public const int VDECODE_FLAG_ALLOWWORLD = (1 << 2);     /**< Allow World entity */
		public const int VDECODE_FLAG_BYREF = (1 << 3);     /**< Floats/ints by reference */

		public const int VENCODE_FLAG_COPYBACK = (1 << 0);     /**< Copy back data once done */

		/**
		 * Starts the preparation of an SDK call.
		 *
		 * @param type          Type of function call this will be.
		 */
		public static void StartPrepSDKCall(SDKCallType type) { throw new NotImplementedException(); }

		/**
		 * Sets the virtual index of the SDK call if it is virtual.
		 *
		 * @param vtblidx       Virtual table index.
		 */
		public static void PrepSDKCall_SetVirtual(int vtblidx) { throw new NotImplementedException(); }

		/**
		 * Finds an address in a library and sets it as the address to use for the SDK call.
		 *
		 * @param lib           Library to use.
		 * @param signature     Binary data to search for in the library.  If it starts with '@',
		 *                      the bytes parameter is ignored and the signature is interpreted
		 *                      as a symbol lookup in the library.
		 * @param bytes         Number of bytes in the binary search string.
		 * @return              True on success, false if nothing was found.
		 */
		public static bool PrepSDKCall_SetSignature(SDKLibrary lib, string signature, int bytes) { throw new NotImplementedException(); }

		/**
		 * Uses the given function address for the SDK call.
		 *
		 * @param addr          Address of function to use.
		 * @return              True on success, false on failure.
		 */
		public static bool PrepSDKCall_SetAddress(Address addr) { throw new NotImplementedException(); }

		/**
		 * Finds an address or virtual function index in a GameConfig file and sets it as
		 * the calling information for the SDK call.
		 *
		 * @param gameconf      GameConfig Handle, or INVALID_HANDLE to use sdktools.games.txt.
		 * @param source        Whether to look in Offsets or Signatures.
		 * @param name          Name of the public to find.
		 * @return              True on success, false if nothing was found.
		 */
		public static bool PrepSDKCall_SetFromConf(Handle gameconf, SDKFuncConfSource source, string name) { throw new NotImplementedException(); }

		/**
		 * Sets the return information of an SDK call.  Do not call this if there is no return data.
		 * This must be called if there is a return value (i.e. it is not necessarily safe to ignore
		 * the data).
		 *
		 * @param type          Data type to convert to/from.
		 * @param pass          How the data is passed in C++.
		 * @param decflags      Flags on decoding from the plugin to C++.
		 * @param encflags      Flags on encoding from C++ to the plugin.
		 */
		public static void PrepSDKCall_SetReturnInfo(SDKType type, SDKPassMethod pass, int decflags = 0, int encflags = 0) { throw new NotImplementedException(); }

		/**
		 * Adds a parameter to the calling convention.  This should be called in normal ascending order.
		 *
		 * @param type          Data type to convert to/from.
		 * @param pass          How the data is passed in C++.
		 * @param decflags      Flags on decoding from the plugin to C++.
		 * @param encflags      Flags on encoding from C++ to the plugin.
		 */
		public static void PrepSDKCall_AddParameter(SDKType type, SDKPassMethod pass, int decflags = 0, int encflags = 0) { throw new NotImplementedException(); }

		/**
		 * Finalizes an SDK call preparation and returns the resultant Handle.
		 *
		 * @return              A new SDKCall Handle on success, or INVALID_HANDLE on failure.
		 */
		public static Handle EndPrepSDKCall() { throw new NotImplementedException(); }

		/**
		 * Calls an SDK function with the given parameters.
		 *
		 * If the call type is Entity or Player, the index MUST ALWAYS be the FIRST parameter passed.
		 * If the call type is GameRules, then nothing special needs to be passed.
		 * If the return value is a Vector or QAngles, the SECOND parameter must be a Float[3].
		 * If the return value is a string, the THIRD parameter must be a String buffer, and the
		 *  FOURTH parameter must be the maximum length.
		 * All parameters must be passed after the above is followed.  Failure to follow these
		 *  rules will result in crashes or wildly unexpected behavior!
		 *
		 * If the return value is a float or integer, the return value will be this value.
		 * If the return value is a CBaseEntity, CBasePlayer, or edict, the return value will
		 *  always be the entity index, or -1 for NULL.
		 *
		 * @param call          SDKCall Handle.
		 * @param ...           Call Parameters.
		 * @return              Simple return value, if any.
		 * @error               Invalid Handle or internal decoding error.
		 */
		public static any SDKCall(Handle call, params object[] args) { throw new NotImplementedException(); }

		/**
		 * Returns the entity index of the player resource/manager entity.
		 *
		 * @return              Index of resource entity or -1 if not found.
		 */
		public static int GetPlayerResourceEntity() { throw new NotImplementedException(); }
	}
}
