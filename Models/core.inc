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

#include <version>

/** If this gets changed, you need to update Core's check. */
public const object SOURCEMOD_PLUGINAPI_VERSION     5

struct PlVers
{
	public int version;
	public string filevers;
	public string date;
	public string time;
};

/**
 * Specifies what to do after a hook completes.
 */
enum Action
{
	Plugin_Continue = 0,    /**< Continue with the original action */
	Plugin_Changed = 1,     /**< Inputs or outputs have been overridden with new values */
	Plugin_Handled = 3,     /**< Handle the action at the end (don't call it) */
	Plugin_Stop = 4         /**< Immediately stop the hook chain and handle the original */
};

/**
 * Specifies identity types.
 */
enum Identity
{
	Identity_Core = 0,
	Identity_Extension = 1,
	Identity_Plugin = 2
};

public PlVers __version = 
{
	version = SOURCEMOD_PLUGINAPI_VERSION,
	filevers = SOURCEMOD_VERSION,
	date = __DATE__,
	time = __TIME__
};

/**
 * Plugin status values.
 */
enum PluginStatus
{
	Plugin_Running=0,       /**< Plugin is running */
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
enum PluginInfo
{
	PlInfo_Name,            /**< Plugin name */
	PlInfo_Author,          /**< Plugin author */
	PlInfo_Description,     /**< Plugin description */
	PlInfo_Version,         /**< Plugin version */
	PlInfo_URL              /**< Plugin URL */
};

/**
 * Defines how an extension must expose itself for autoloading.
 */
struct Extension
{
	public string name;   /**< Short name */
	public string file;   /**< Default file name */
	public bool autoload;       /**< Whether or not to auto-load */
	public bool required;       /**< Whether or not to require */
};

/**
 * Defines how a plugin must expose itself for native requiring.
 */
struct SharedPlugin
{
	public string name;   /**< Short name */
	public string file;   /**< File name */
	public bool required;       /**< Whether or not to require */
};

public float NULL_VECTOR[3];        /**< Pass this into certain functions to act as a C++ NULL */
public const char NULL_STRING[1];   /**< pass this into certain functions to act as a C++ NULL */

/**
 * Check if the given vector is the NULL_VECTOR.
 *
 * @param vec     The vector to test.
 * @return        True if NULL_VECTOR, false otherwise.
 */
public static bool IsNullVector(ReadOnlyCollection<float> vec[3]) { throw new NotImplementedException(); }

/**
 * Check if the given string is the NULL_STRING.
 *
 * @param str     The string to test.
 * @return        True if NULL_STRING, false otherwise.
 */
public static bool IsNullString(string str) { throw new NotImplementedException(); }

/**
 * Horrible compatibility shim.
 */
public Extension __ext_core = 
{
	name = "Core",
	file = "core",
	autoload = 0,
	required = 0,
};

public static int VerifyCoreVersion() { throw new NotImplementedException(); }

/**
 * Sets a native as optional, such that if it is unloaded, removed,
 * or otherwise non-existent, the plugin will still work.  Calling
 * removed natives results in a run-time error.
 *
 * @param name          Native name.
 */
public static void MarkNativeAsOptional(string name) { throw new NotImplementedException(); }

public void __ext_core_SetNTVOptional()
{
	MarkNativeAsOptional("GetFeatureStatus") { throw new NotImplementedException(); }
	MarkNativeAsOptional("RequireFeature") { throw new NotImplementedException(); }
	MarkNativeAsOptional("AddCommandListener") { throw new NotImplementedException(); }
	MarkNativeAsOptional("RemoveCommandListener") { throw new NotImplementedException(); }

	MarkNativeAsOptional("BfWriteBool") { throw new NotImplementedException(); }
	MarkNativeAsOptional("BfWriteByte") { throw new NotImplementedException(); }
	MarkNativeAsOptional("BfWriteChar") { throw new NotImplementedException(); }
	MarkNativeAsOptional("BfWriteShort") { throw new NotImplementedException(); }
	MarkNativeAsOptional("BfWriteWord") { throw new NotImplementedException(); }
	MarkNativeAsOptional("BfWriteNum") { throw new NotImplementedException(); }
	MarkNativeAsOptional("BfWriteFloat") { throw new NotImplementedException(); }
	MarkNativeAsOptional("BfWriteString") { throw new NotImplementedException(); }
	MarkNativeAsOptional("BfWriteEntity") { throw new NotImplementedException(); }
	MarkNativeAsOptional("BfWriteAngle") { throw new NotImplementedException(); }
	MarkNativeAsOptional("BfWriteCoord") { throw new NotImplementedException(); }
	MarkNativeAsOptional("BfWriteVecCoord") { throw new NotImplementedException(); }
	MarkNativeAsOptional("BfWriteVecNormal") { throw new NotImplementedException(); }
	MarkNativeAsOptional("BfWriteAngles") { throw new NotImplementedException(); }
	MarkNativeAsOptional("BfReadBool") { throw new NotImplementedException(); }
	MarkNativeAsOptional("BfReadByte") { throw new NotImplementedException(); }
	MarkNativeAsOptional("BfReadChar") { throw new NotImplementedException(); }
	MarkNativeAsOptional("BfReadShort") { throw new NotImplementedException(); }
	MarkNativeAsOptional("BfReadWord") { throw new NotImplementedException(); }
	MarkNativeAsOptional("BfReadNum") { throw new NotImplementedException(); }
	MarkNativeAsOptional("BfReadFloat") { throw new NotImplementedException(); }
	MarkNativeAsOptional("BfReadString") { throw new NotImplementedException(); }
	MarkNativeAsOptional("BfReadEntity") { throw new NotImplementedException(); }
	MarkNativeAsOptional("BfReadAngle") { throw new NotImplementedException(); }
	MarkNativeAsOptional("BfReadCoord") { throw new NotImplementedException(); }
	MarkNativeAsOptional("BfReadVecCoord") { throw new NotImplementedException(); }
	MarkNativeAsOptional("BfReadVecNormal") { throw new NotImplementedException(); }
	MarkNativeAsOptional("BfReadAngles") { throw new NotImplementedException(); }
	MarkNativeAsOptional("BfGetNumBytesLeft") { throw new NotImplementedException(); }

	MarkNativeAsOptional("BfWrite.WriteBool") { throw new NotImplementedException(); }
	MarkNativeAsOptional("BfWrite.WriteByte") { throw new NotImplementedException(); }
	MarkNativeAsOptional("BfWrite.WriteChar") { throw new NotImplementedException(); }
	MarkNativeAsOptional("BfWrite.WriteShort") { throw new NotImplementedException(); }
	MarkNativeAsOptional("BfWrite.WriteWord") { throw new NotImplementedException(); }
	MarkNativeAsOptional("BfWrite.WriteNum") { throw new NotImplementedException(); }
	MarkNativeAsOptional("BfWrite.WriteFloat") { throw new NotImplementedException(); }
	MarkNativeAsOptional("BfWrite.WriteString") { throw new NotImplementedException(); }
	MarkNativeAsOptional("BfWrite.WriteEntity") { throw new NotImplementedException(); }
	MarkNativeAsOptional("BfWrite.WriteAngle") { throw new NotImplementedException(); }
	MarkNativeAsOptional("BfWrite.WriteCoord") { throw new NotImplementedException(); }
	MarkNativeAsOptional("BfWrite.WriteVecCoord") { throw new NotImplementedException(); }
	MarkNativeAsOptional("BfWrite.WriteVecNormal") { throw new NotImplementedException(); }
	MarkNativeAsOptional("BfWrite.WriteAngles") { throw new NotImplementedException(); }
	MarkNativeAsOptional("BfRead.ReadBool") { throw new NotImplementedException(); }
	MarkNativeAsOptional("BfRead.ReadByte") { throw new NotImplementedException(); }
	MarkNativeAsOptional("BfRead.ReadChar") { throw new NotImplementedException(); }
	MarkNativeAsOptional("BfRead.ReadShort") { throw new NotImplementedException(); }
	MarkNativeAsOptional("BfRead.ReadWord") { throw new NotImplementedException(); }
	MarkNativeAsOptional("BfRead.ReadNum") { throw new NotImplementedException(); }
	MarkNativeAsOptional("BfRead.ReadFloat") { throw new NotImplementedException(); }
	MarkNativeAsOptional("BfRead.ReadString") { throw new NotImplementedException(); }
	MarkNativeAsOptional("BfRead.ReadEntity") { throw new NotImplementedException(); }
	MarkNativeAsOptional("BfRead.ReadAngle") { throw new NotImplementedException(); }
	MarkNativeAsOptional("BfRead.ReadCoord") { throw new NotImplementedException(); }
	MarkNativeAsOptional("BfRead.ReadVecCoord") { throw new NotImplementedException(); }
	MarkNativeAsOptional("BfRead.ReadVecNormal") { throw new NotImplementedException(); }
	MarkNativeAsOptional("BfRead.ReadAngles") { throw new NotImplementedException(); }
	MarkNativeAsOptional("BfRead.BytesLeft.get") { throw new NotImplementedException(); }

	MarkNativeAsOptional("PbReadInt") { throw new NotImplementedException(); }
	MarkNativeAsOptional("PbReadFloat") { throw new NotImplementedException(); }
	MarkNativeAsOptional("PbReadBool") { throw new NotImplementedException(); }
	MarkNativeAsOptional("PbReadString") { throw new NotImplementedException(); }
	MarkNativeAsOptional("PbReadColor") { throw new NotImplementedException(); }
	MarkNativeAsOptional("PbReadAngle") { throw new NotImplementedException(); }
	MarkNativeAsOptional("PbReadVector") { throw new NotImplementedException(); }
	MarkNativeAsOptional("PbReadVector2D") { throw new NotImplementedException(); }
	MarkNativeAsOptional("PbGetRepeatedFieldCount") { throw new NotImplementedException(); }
	MarkNativeAsOptional("PbSetInt") { throw new NotImplementedException(); }
	MarkNativeAsOptional("PbSetFloat") { throw new NotImplementedException(); }
	MarkNativeAsOptional("PbSetBool") { throw new NotImplementedException(); }
	MarkNativeAsOptional("PbSetString") { throw new NotImplementedException(); }
	MarkNativeAsOptional("PbSetColor") { throw new NotImplementedException(); }
	MarkNativeAsOptional("PbSetAngle") { throw new NotImplementedException(); }
	MarkNativeAsOptional("PbSetVector") { throw new NotImplementedException(); }
	MarkNativeAsOptional("PbSetVector2D") { throw new NotImplementedException(); }
	MarkNativeAsOptional("PbAddInt") { throw new NotImplementedException(); }
	MarkNativeAsOptional("PbAddFloat") { throw new NotImplementedException(); }
	MarkNativeAsOptional("PbAddBool") { throw new NotImplementedException(); }
	MarkNativeAsOptional("PbAddString") { throw new NotImplementedException(); }
	MarkNativeAsOptional("PbAddColor") { throw new NotImplementedException(); }
	MarkNativeAsOptional("PbAddAngle") { throw new NotImplementedException(); }
	MarkNativeAsOptional("PbAddVector") { throw new NotImplementedException(); }
	MarkNativeAsOptional("PbAddVector2D") { throw new NotImplementedException(); }
	MarkNativeAsOptional("PbRemoveRepeatedFieldValue") { throw new NotImplementedException(); }
	MarkNativeAsOptional("PbReadMessage") { throw new NotImplementedException(); }
	MarkNativeAsOptional("PbReadRepeatedMessage") { throw new NotImplementedException(); }
	MarkNativeAsOptional("PbAddMessage") { throw new NotImplementedException(); }

	MarkNativeAsOptional("Protobuf.ReadInt") { throw new NotImplementedException(); }
	MarkNativeAsOptional("Protobuf.ReadInt64") { throw new NotImplementedException(); }
	MarkNativeAsOptional("Protobuf.ReadFloat") { throw new NotImplementedException(); }
	MarkNativeAsOptional("Protobuf.ReadBool") { throw new NotImplementedException(); }
	MarkNativeAsOptional("Protobuf.ReadString") { throw new NotImplementedException(); }
	MarkNativeAsOptional("Protobuf.ReadColor") { throw new NotImplementedException(); }
	MarkNativeAsOptional("Protobuf.ReadAngle") { throw new NotImplementedException(); }
	MarkNativeAsOptional("Protobuf.ReadVector") { throw new NotImplementedException(); }
	MarkNativeAsOptional("Protobuf.ReadVector2D") { throw new NotImplementedException(); }
	MarkNativeAsOptional("Protobuf.GetRepeatedFieldCount") { throw new NotImplementedException(); }
	MarkNativeAsOptional("Protobuf.SetInt") { throw new NotImplementedException(); }
	MarkNativeAsOptional("Protobuf.SetInt64") { throw new NotImplementedException(); }
	MarkNativeAsOptional("Protobuf.SetFloat") { throw new NotImplementedException(); }
	MarkNativeAsOptional("Protobuf.SetBool") { throw new NotImplementedException(); }
	MarkNativeAsOptional("Protobuf.SetString") { throw new NotImplementedException(); }
	MarkNativeAsOptional("Protobuf.SetColor") { throw new NotImplementedException(); }
	MarkNativeAsOptional("Protobuf.SetAngle") { throw new NotImplementedException(); }
	MarkNativeAsOptional("Protobuf.SetVector") { throw new NotImplementedException(); }
	MarkNativeAsOptional("Protobuf.SetVector2D") { throw new NotImplementedException(); }
	MarkNativeAsOptional("Protobuf.AddInt") { throw new NotImplementedException(); }
	MarkNativeAsOptional("Protobuf.AddInt64") { throw new NotImplementedException(); }
	MarkNativeAsOptional("Protobuf.AddFloat") { throw new NotImplementedException(); }
	MarkNativeAsOptional("Protobuf.AddBool") { throw new NotImplementedException(); }
	MarkNativeAsOptional("Protobuf.AddString") { throw new NotImplementedException(); }
	MarkNativeAsOptional("Protobuf.AddColor") { throw new NotImplementedException(); }
	MarkNativeAsOptional("Protobuf.AddAngle") { throw new NotImplementedException(); }
	MarkNativeAsOptional("Protobuf.AddVector") { throw new NotImplementedException(); }
	MarkNativeAsOptional("Protobuf.AddVector2D") { throw new NotImplementedException(); }
	MarkNativeAsOptional("Protobuf.RemoveRepeatedFieldValue") { throw new NotImplementedException(); }
	MarkNativeAsOptional("Protobuf.ReadMessage") { throw new NotImplementedException(); }
	MarkNativeAsOptional("Protobuf.ReadRepeatedMessage") { throw new NotImplementedException(); }
	MarkNativeAsOptional("Protobuf.AddMessage") { throw new NotImplementedException(); }

	VerifyCoreVersion() { throw new NotImplementedException(); }
}


public const object AUTOLOAD_EXTENSIONS
public const object REQUIRE_EXTENSIONS
public const object REQUIRE_PLUGIN
	}
}