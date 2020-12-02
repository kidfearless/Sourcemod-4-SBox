/**
 * vim: set ts=4 sw=4 tw=99 noet :
 * =============================================================================
 * SourceMod (C)2013 AlliedModders LLC.  All rights reserved.
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

public const int PB_FIELD_NOT_REPEATED -1

public class Protobuf : Handle
{
	// Reads an int32, uint32, sint32, fixed32, sfixed32, or public enum value from a protobuf message.
	//
	// @param field      Field name.
	// @param index      Index into repeated field.
	// @return           Integer value read.
	// @error            Non-existent field, or incorrect field type.
	public int ReadInt(string field, int index = PB_FIELD_NOT_REPEATED) { throw new NotImplementedException(); }

	// Reads an int64, uint64, sint64, fixed64, sfixed64 from a protobuf message.
	//
	// @param field      Field name.
	// @param value      Array to represent the large integer (0=High bits, 1=Low bits).
	// @param index      Index into repeated field.
	// @error            Non-existent field, or incorrect field type.
	public void ReadInt64(string field, int value[2], int index = PB_FIELD_NOT_REPEATED) { throw new NotImplementedException(); }

	// Reads a float or downcasted double from a protobuf message.
	//
	// @param field      Field name.
	// @param index      Index into repeated field.
	// @return           Float value read.
	// @error            Non-existent field, or incorrect field type.
	public float ReadFloat(string field, int index = PB_FIELD_NOT_REPEATED) { throw new NotImplementedException(); }

	// Reads a bool from a protobuf message.
	//
	// @param field      Field name.
	// @param index      Index into repeated field.
	// @return           Boolean value read.
	// @error            Non-existent field, or incorrect field type.
	public bool ReadBool(string field, int index = PB_FIELD_NOT_REPEATED) { throw new NotImplementedException(); }

	// Reads a string from a protobuf message.
	//
	// @param field      Field name.
	// @param buffer     Destination string buffer.
	// @param maxlength  Maximum length of output string buffer.
	// @param index      Index into repeated field.
	// @error            Non-existent field, or incorrect field type.
	public void ReadString(string field, string buffer, int maxlength, int index = PB_FIELD_NOT_REPEATED) { throw new NotImplementedException(); }

	// Reads an RGBA color value from a protobuf message.
	//
	// @param field      Field name.
	// @param buffer     Destination color buffer.
	// @param index      Index into repeated field.
	// @error            Non-existent field, or incorrect field type.
	public void ReadColor(string field, int buffer[4], int index = PB_FIELD_NOT_REPEATED) { throw new NotImplementedException(); }

	// Reads an XYZ angle value from a protobuf message.
	//
	// @param field      Field name.
	// @param buffer     Destination angle buffer.
	// @param index      Index into repeated field.
	// @error            Non-existent field, or incorrect field type.
	public void ReadAngle(string field, float buffer[3], int index = PB_FIELD_NOT_REPEATED) { throw new NotImplementedException(); }

	// Reads an XYZ vector value from a protobuf message.
	//
	// @param pb         protobuf handle.
	// @param field      Field name.
	// @param buffer     Destination vector buffer.
	// @param index      Index into repeated field.
	// @error            Non-existent field, or incorrect field type.
	public void ReadVector(string field, float buffer[3], int index = PB_FIELD_NOT_REPEATED) { throw new NotImplementedException(); }

	// Reads an XY vector value from a protobuf message.
	//
	// @param field      Field name.
	// @param buffer     Destination vector buffer.
	// @param index      Index into repeated field.
	// @error            Non-existent field, or incorrect field type.
	public void ReadVector2D(string field, float buffer[2], int index = PB_FIELD_NOT_REPEATED) { throw new NotImplementedException(); }

	// Gets the number of elements in a repeated field of a protobuf message.
	//
	// @param field      Field name.
	// @return           Number of elements in the field.
	// @error            Non-existent field, or non-repeated field.
	public int GetRepeatedFieldCount(string field) { throw new NotImplementedException(); }

	// Returns whether or not the named, non-repeated field has a value set.
	//
	// @param field      Field name.
	// @return           True if value has been set, else false.
	// @error            Non-existent field, or repeated field.
	public bool HasField(string field) { throw new NotImplementedException(); }

	// Sets an int32, uint32, sint32, fixed32, sfixed32, or public enum value on a protobuf message.
	//
	// @param field      Field name.
	// @param value      Integer value to set.
	// @param index      Index into repeated field.
	// @error            Non-existent field, or incorrect field type.
	public void SetInt(string field, int value, int index = PB_FIELD_NOT_REPEATED) { throw new NotImplementedException(); }

	// Sets an int64, uint64, sint64, fixed64, sfixed64 on a protobuf message.
	//
	// @param field      Field name.
	// @param value      Large integer value to set (0=High bits, 1=Low bits).
	// @param index      Index into repeated field.
	// @error            Non-existent field, or incorrect field type.
	public void SetInt64(string field, int value[2], int index = PB_FIELD_NOT_REPEATED) { throw new NotImplementedException(); }

	// Sets a float or double on a protobuf message.
	//
	// @param field      Field name.
	// @param value      Float value to set.
	// @param index      Index into repeated field.
	// @error            Non-existent field, or incorrect field type.
	public void SetFloat(string field, float value, int index = PB_FIELD_NOT_REPEATED) { throw new NotImplementedException(); }

	// Sets a bool on a protobuf message.
	//
	// @param field      Field name.
	// @param value      Boolean value to set.
	// @param index      Index into repeated field.
	// @error            Non-existent field, or incorrect field type.
	public void SetBool(string field, bool value, int index = PB_FIELD_NOT_REPEATED) { throw new NotImplementedException(); }

	// Sets a string on a protobuf message.
	//
	// @param field      Field name.
	// @param value      String value to set.
	// @param index      Index into repeated field.
	// @error            Non-existent field, or incorrect field type.
	public void SetString(string field, string value, int index = PB_FIELD_NOT_REPEATED) { throw new NotImplementedException(); }

	// Sets an RGBA color on a protobuf message.
	//
	// @param field      Field name.
	// @param color      Color value to set.
	// @param index      Index into repeated field.
	// @error            Non-existent field, or incorrect field type.
	public void SetColor(string field, const int color[4], int index = PB_FIELD_NOT_REPEATED) { throw new NotImplementedException(); }

	// Sets an XYZ angle on a protobuf message.
	//
	// @param field      Field name.
	// @param angle      Angle value to set.
	// @param index      Index into repeated field.
	// @error            Non-existent field, or incorrect field type.
	public void SetAngle(string field, float[] angle[3], int index = PB_FIELD_NOT_REPEATED) { throw new NotImplementedException(); }

	// Sets an XYZ vector on a protobuf message.
	//
	// @param field      Field name.
	// @param vec        Vector value to set.
	// @param index      Index into repeated field.
	// @error            Non-existent field, or incorrect field type.
	public void SetVector(string field, float[] vec[3], int index = PB_FIELD_NOT_REPEATED) { throw new NotImplementedException(); }

	// Sets an XY vector on a protobuf message.
	//
	// @param field      Field name.
	// @param vec        Vector value to set.
	// @param index      Index into repeated field.
	// @error            Non-existent field, or incorrect field type.
	public void SetVector2D(string field, float[] vec[2], int index = PB_FIELD_NOT_REPEATED) { throw new NotImplementedException(); }

	// Add an int32, uint32, sint32, fixed32, sfixed32, or public enum value to a protobuf message repeated field.
	//
	// @param field      Field name.
	// @param value      Integer value to add.
	// @error            Non-existent field, or incorrect field type.
	public void AddInt(string field, int value) { throw new NotImplementedException(); }

	// Add an int64, uint64, sint64, fixed64, sfixed64 to a protobuf message repeated field.
	//
	// @param field      Field name.
	// @param value      Large integer value to add (0=High bits, 1=Low bits).
	// @error            Non-existent field, or incorrect field type.
	public void AddInt64(string field, int value[2]) { throw new NotImplementedException(); }

	// Add a float or double to a protobuf message repeated field.
	//
	// @param field      Field name.
	// @param value      Float value to add.
	// @error            Non-existent field, or incorrect field type.
	public void AddFloat(string field, float value) { throw new NotImplementedException(); }

	// Add a bool to a protobuf message repeated field.
	//
	// @param field      Field name.
	// @param value      Boolean value to add.
	// @error            Non-existent field, or incorrect field type.
	public void AddBool(string field, bool value) { throw new NotImplementedException(); }

	// Add a string to a protobuf message repeated field.
	//
	// @param field      Field name.
	// @param value      String value to add.
	// @error            Non-existent field, or incorrect field type.
	public void AddString(string field, string value) { throw new NotImplementedException(); }

	// Add an RGBA color to a protobuf message repeated field.
	//
	// @param field      Field name.
	// @param color      Color value to add.
	// @error            Non-existent field, or incorrect field type.
	public void AddColor(string field, const int color[4]) { throw new NotImplementedException(); }

	// Add an XYZ angle to a protobuf message repeated field.
	//
	// @param field      Field name.
	// @param angle      Angle value to add.
	// @error            Non-existent field, or incorrect field type.
	public void AddAngle(string field, float[] angle[3]) { throw new NotImplementedException(); }

	// Add an XYZ vector to a protobuf message repeated field.
	//
	// @param field      Field name.
	// @param vec        Vector value to add.
	// @error            Non-existent field, or incorrect field type.
	public void AddVector(string field, float[] vec[3]) { throw new NotImplementedException(); }

	// Add an XY vector to a protobuf message repeated field.
	//
	// @param field      Field name.
	// @param vec        Vector value to add.
	// @error            Non-existent field, or incorrect field type.
	public void AddVector2D(string field, float[] vec[2]) { throw new NotImplementedException(); }

	// Removes a value by index from a protobuf message repeated field.
	//
	// @param field      Field name.
	// @param index      Index into repeated field.
	// @error            Non-existent field, or incorrect field type.
	public void RemoveRepeatedFieldValue(string field, int index) { throw new NotImplementedException(); }

	// Retrieve a handle to an embedded protobuf message in a protobuf message.
	//
	// @param field      Field name.
	// @return           Protobuf handle to embedded message.
	// @error            Non-existent field, or incorrect field type.
	public Protobuf ReadMessage(string field) { throw new NotImplementedException(); }

	// Retrieve a handle to an embedded protobuf message in a protobuf message
	// repeated field.
	//
	// @param field      Field name.
	// @param index      Index in the repeated field.
	// @return           Protobuf handle to embedded message.
	// @error            Non-existent field, or incorrect field type.
	public Protobuf ReadRepeatedMessage(string field, int index) { throw new NotImplementedException(); }

	// Adds an embedded protobuf message to a protobuf message repeated field.
	//
	// @param field      Field name.
	// @return           Protobuf handle to added, embedded message.
	// @error            Non-existent field, or incorrect field type.
	public Protobuf AddMessage(string field) { throw new NotImplementedException(); }
};

/**
 * Reads an int32, uint32, sint32, fixed32, sfixed32, or public enum value from a protobuf message.
 *
 * @param pb            protobuf handle.
 * @param field         Field name.
 * @param index         Index into repeated field.
 * @return              Integer value read.
 * @error               Invalid or incorrect Handle, non-existent field, or incorrect field type.
 */
public static int PbReadInt(Handle pb, string field, int index = PB_FIELD_NOT_REPEATED) { throw new NotImplementedException(); }

/**
 * Reads a float or downcasted double from a protobuf message.
 *
 * @param pb            protobuf handle.
 * @param field         Field name.
 * @param index         Index into repeated field.
 * @return              Float value read.
 * @error               Invalid or incorrect Handle, non-existent field, or incorrect field type.
 */
public static float PbReadFloat(Handle pb, string field, int index = PB_FIELD_NOT_REPEATED) { throw new NotImplementedException(); }

/**
 * Reads a bool from a protobuf message.
 *
 * @param pb            protobuf handle.
 * @param field         Field name.
 * @param index         Index into repeated field.
 * @return              Boolean value read.
 * @error               Invalid or incorrect Handle, non-existent field, or incorrect field type.
 */
public static bool PbReadBool(Handle pb, string field, int index = PB_FIELD_NOT_REPEATED) { throw new NotImplementedException(); }

/**
 * Reads a string from a protobuf message.
 *
 * @param pb            protobuf handle.
 * @param field         Field name.
 * @param buffer        Destination string buffer.
 * @param maxlength     Maximum length of output string buffer.
 * @param index         Index into repeated field.
 * @error               Invalid or incorrect Handle, non-existent field, or incorrect field type.
 */
public static void PbReadString(Handle pb, string field, string buffer, int maxlength, int index = PB_FIELD_NOT_REPEATED) { throw new NotImplementedException(); }

/**
 * Reads an RGBA color value from a protobuf message.
 *
 * @param pb            protobuf handle.
 * @param field         Field name.
 * @param buffer        Destination color buffer.
 * @param index         Index into repeated field.
 * @error               Invalid or incorrect Handle, non-existent field, or incorrect field type.
 */
public static void PbReadColor(Handle pb, string field, int buffer[4], int index = PB_FIELD_NOT_REPEATED) { throw new NotImplementedException(); }

/**
 * Reads an XYZ angle value from a protobuf message.
 *
 * @param pb            protobuf handle.
 * @param field         Field name.
 * @param buffer        Destination angle buffer.
 * @param index         Index into repeated field.
 * @error               Invalid or incorrect Handle, non-existent field, or incorrect field type.
 */
public static void PbReadAngle(Handle pb, string field, float buffer[3], int index = PB_FIELD_NOT_REPEATED) { throw new NotImplementedException(); }

/**
 * Reads an XYZ vector value from a protobuf message.
 *
 * @param pb            protobuf handle.
 * @param field         Field name.
 * @param buffer        Destination vector buffer.
 * @param index         Index into repeated field.
 * @error               Invalid or incorrect Handle, non-existent field, or incorrect field type.
 */
public static void PbReadVector(Handle pb, string field, float buffer[3], int index = PB_FIELD_NOT_REPEATED) { throw new NotImplementedException(); }

/**
 * Reads an XY vector value from a protobuf message.
 *
 * @param pb            protobuf handle.
 * @param field         Field name.
 * @param buffer        Destination vector buffer.
 * @param index         Index into repeated field.
 * @error               Invalid or incorrect Handle, non-existent field, or incorrect field type.
 */
public static void PbReadVector2D(Handle pb, string field, float buffer[2], int index = PB_FIELD_NOT_REPEATED) { throw new NotImplementedException(); }

/**
 * Gets the number of elements in a repeated field of a protobuf message.
 *
 * @param pb            protobuf handle.
 * @param field         Field name.
 * @return              Number of elements in the field.
 * @error               Invalid or incorrect Handle, non-existent field, or incorrect field type.
 */
public static int PbGetRepeatedFieldCount(Handle pb, string field) { throw new NotImplementedException(); }

/**
 * Sets an int32, uint32, sint32, fixed32, sfixed32, or public enum value on a protobuf message.
 *
 * @param pb            protobuf handle.
 * @param field         Field name.
 * @param value         Integer value to set.
 * @param index         Index into repeated field.
 * @error               Invalid or incorrect Handle, non-existent field, or incorrect field type.
 */
public static void PbSetInt(Handle pb, string field, int value, int index = PB_FIELD_NOT_REPEATED) { throw new NotImplementedException(); }

/**
 * Sets a float or double on a protobuf message.
 *
 * @param pb            protobuf handle.
 * @param field         Field name.
 * @param value         Float value to set.
 * @param index         Index into repeated field.
 * @error               Invalid or incorrect Handle, non-existent field, or incorrect field type.
 */
public static void PbSetFloat(Handle pb, string field, float value, int index = PB_FIELD_NOT_REPEATED) { throw new NotImplementedException(); }

/**
 * Sets a bool on a protobuf message.
 *
 * @param pb            protobuf handle.
 * @param field         Field name.
 * @param value         Boolean value to set.
 * @param index         Index into repeated field.
 * @error               Invalid or incorrect Handle, non-existent field, or incorrect field type.
 */
public static void PbSetBool(Handle pb, string field, bool value, int index = PB_FIELD_NOT_REPEATED) { throw new NotImplementedException(); }

/**
 * Sets a string on a protobuf message.
 *
 * @param pb            protobuf handle.
 * @param field         Field name.
 * @param value         String value to set.
 * @param index         Index into repeated field.
 * @error               Invalid or incorrect Handle, non-existent field, or incorrect field type.
 */
public static void PbSetString(Handle pb, string field, string value, int index = PB_FIELD_NOT_REPEATED) { throw new NotImplementedException(); }

/**
 * Sets an RGBA color on a protobuf message.
 *
 * @param pb            protobuf handle.
 * @param field         Field name.
 * @param color         Color value to set.
 * @param index         Index into repeated field.
 * @error               Invalid or incorrect Handle, non-existent field, or incorrect field type.
 */
public static void PbSetColor(Handle pb, string field, const int color[4], int index = PB_FIELD_NOT_REPEATED) { throw new NotImplementedException(); }

/**
 * Sets an XYZ angle on a protobuf message.
 *
 * @param pb            protobuf handle.
 * @param field         Field name.
 * @param angle         Angle value to set.
 * @param index         Index into repeated field.
 * @error               Invalid or incorrect Handle, non-existent field, or incorrect field type.
 */
public static void PbSetAngle(Handle pb, string field, float[] angle[3], int index = PB_FIELD_NOT_REPEATED) { throw new NotImplementedException(); }

/**
 * Sets an XYZ vector on a protobuf message.
 *
 * @param pb            protobuf handle.
 * @param field         Field name.
 * @param vec           Vector value to set.
 * @param index         Index into repeated field.
 * @error               Invalid or incorrect Handle, non-existent field, or incorrect field type.
 */
public static void PbSetVector(Handle pb, string field, float[] vec[3], int index = PB_FIELD_NOT_REPEATED) { throw new NotImplementedException(); }

/**
 * Sets an XY vector on a protobuf message.
 *
 * @param pb            protobuf handle.
 * @param field         Field name.
 * @param vec           Vector value to set.
 * @param index         Index into repeated field.
 * @error               Invalid or incorrect Handle, non-existent field, or incorrect field type.
 */
public static void PbSetVector2D(Handle pb, string field, float[] vec[2], int index = PB_FIELD_NOT_REPEATED) { throw new NotImplementedException(); }

/**
 * Add an int32, uint32, sint32, fixed32, sfixed32, or public enum value to a protobuf message repeated field.
 *
 * @param pb            protobuf handle.
 * @param field         Field name.
 * @param value         Integer value to add.
 * @error               Invalid or incorrect Handle, non-existent field, or incorrect field type.
 */
public static void PbAddInt(Handle pb, string field, int value) { throw new NotImplementedException(); }

/**
 * Add a float or double to a protobuf message repeated field.
 *
 * @param pb            protobuf handle.
 * @param field         Field name.
 * @param value         Float value to add.
 * @error               Invalid or incorrect Handle, non-existent field, or incorrect field type.
 */
public static void PbAddFloat(Handle pb, string field, float value) { throw new NotImplementedException(); }

/**
 * Add a bool to a protobuf message repeated field.
 *
 * @param pb            protobuf handle.
 * @param field         Field name.
 * @param value         Boolean value to add.
 * @error               Invalid or incorrect Handle, non-existent field, or incorrect field type.
 */
public static void PbAddBool(Handle pb, string field, bool value) { throw new NotImplementedException(); }

/**
 * Add a string to a protobuf message repeated field.
 *
 * @param pb            protobuf handle.
 * @param field         Field name.
 * @param value         String value to add.
 * @error               Invalid or incorrect Handle, non-existent field, or incorrect field type.
 */
public static void PbAddString(Handle pb, string field, string value) { throw new NotImplementedException(); }

/**
 * Add an RGBA color to a protobuf message repeated field.
 *
 * @param pb            protobuf handle.
 * @param field         Field name.
 * @param color         Color value to add.
 * @error               Invalid or incorrect Handle, non-existent field, or incorrect field type.
 */
public static void PbAddColor(Handle pb, string field, const int color[4]) { throw new NotImplementedException(); }

/**
 * Add an XYZ angle to a protobuf message repeated field.
 *
 * @param pb            protobuf handle.
 * @param field         Field name.
 * @param angle         Angle value to add.
 * @error               Invalid or incorrect Handle, non-existent field, or incorrect field type.
 */
public static void PbAddAngle(Handle pb, string field, float[] angle[3]) { throw new NotImplementedException(); }

/**
 * Add an XYZ vector to a protobuf message repeated field.
 *
 * @param pb            protobuf handle.
 * @param field         Field name.
 * @param vec           Vector value to add.
 * @error               Invalid or incorrect Handle, non-existent field, or incorrect field type.
 */
public static void PbAddVector(Handle pb, string field, float[] vec[3]) { throw new NotImplementedException(); }

/**
 * Add an XY vector to a protobuf message repeated field.
 *
 * @param pb            protobuf handle.
 * @param field         Field name.
 * @param vec           Vector value to add.
 * @error               Invalid or incorrect Handle, non-existent field, or incorrect field type.
 */
public static void PbAddVector2D(Handle pb, string field, float[] vec[2]) { throw new NotImplementedException(); }

/**
 * Removes a value by index from a protobuf message repeated field.
 *
 * @param pb            protobuf handle.
 * @param field         Field name.
 * @param index         Index into repeated field.
 * @error               Invalid or incorrect Handle, non-existent field, or incorrect field type.
 */
public static void PbRemoveRepeatedFieldValue(Handle pb, string field, int index) { throw new NotImplementedException(); }

/**
 * Retrieve a handle to an embedded protobuf message in a protobuf message.
 *
 * @param pb            protobuf handle.
 * @param field         Field name.
 * @return              protobuf handle to embedded message.
 * @error               Invalid or incorrect Handle, non-existent field, or incorrect field type.
 */
public static Handle PbReadMessage(Handle pb, string field) { throw new NotImplementedException(); }

/**
 * Retrieve a handle to an embedded protobuf message in a protobuf message repeated field.
 *
 * @param pb            protobuf handle.
 * @param field         Field name.
 * @param index         Index in the repeated field.
 * @return              protobuf handle to embedded message.
 * @error               Invalid or incorrect Handle, non-existent field, or incorrect field type.
 */
public static Handle PbReadRepeatedMessage(Handle pb, string field, int index) { throw new NotImplementedException(); }

/**
 * Adds an embedded protobuf message to a protobuf message repeated field.
 *
 * @param pb            protobuf handle.
 * @param field         Field name.
 * @return              protobuf handle to added, embedded message.
 * @error               Invalid or incorrect Handle, non-existent field, or incorrect field type.
 */
public static Handle PbAddMessage(Handle pb, string field) { throw new NotImplementedException(); }
	}
}