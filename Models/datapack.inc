/**
 * vim: set ts=4 sw=4 tw=99 noet :
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
 * Opaque handle to a datapack position.
 */
enum DataPackPos: {};

// A DataPack allows serializing multiple variables into a single stream.
methodmap DataPack < Handle
{
	// Creates a new data pack.
	public native DataPack() { throw new NotImplementedException(); }

	// Packs a normal cell into a data pack.
	//
	// @param cell          Cell to add.
	// @param insert        Determines whether mid-pack writes will insert instead of overwrite.
	public native void WriteCell(any cell, bool insert = false) { throw new NotImplementedException(); }

	// Packs a float into a data pack.
	//
	// @param val           Float to add.
	// @param insert        Determines whether mid-pack writes will insert instead of overwrite.
	public native void WriteFloat(float val, bool insert = false) { throw new NotImplementedException(); }

	// Packs a string into a data pack.
	//
	// @param str           String to add.
	// @param insert        Determines whether mid-pack writes will insert instead of overwrite.
	public native void WriteString(string str, bool insert = false) { throw new NotImplementedException(); }

	// Packs a function pointer into a data pack.
	//
	// @param fktptr        Function pointer to add.
	// @param insert        Determines whether mid-pack writes will insert instead of overwrite.
	public native void WriteFunction(Function fktptr, bool insert = false) { throw new NotImplementedException(); }

	// Packs an array of cells into a data pack.
	//
	// @param array         Array to add.
	// @param count         Number of elements
	// @param insert        Determines whether mid-pack writes will insert instead of overwrite.
	public native void WriteCellArray(const any[] array, int count, bool insert = false) { throw new NotImplementedException(); }

	// Packs an array of floats into a data pack.
	//
	// @param array         Array to add.
	// @param count         Number of elements
	// @param insert        Determines whether mid-pack writes will insert instead of overwrite.
	public native void WriteFloatArray(const float[] array, int count, bool insert = false) { throw new NotImplementedException(); }

	// Reads a cell from a data pack.
	//
	// @return		A cell at this position
	public native any ReadCell() { throw new NotImplementedException(); }

	// Reads a float from a data pack.
	//
	// @return		Float at this position
	public native float ReadFloat() { throw new NotImplementedException(); }

	// Reads a string from a data pack.
	//
	// @param buffer        Destination string buffer.
	// @param maxlen        Maximum length of output string buffer.
	public native void ReadString(string buffer, int maxlen) { throw new NotImplementedException(); }

	// Reads a function pointer from a data pack.
	//
	// @return              Function pointer.
	public native Function ReadFunction() { throw new NotImplementedException(); }

	// Reads an array of cells a data pack.
	//
	// @param buffer        Destination buffer.
	// @param count         Maximum length of output buffer.
	public native void ReadCellArray(any[] buffer, int count) { throw new NotImplementedException(); }

	// Reads an array of floats from a data pack.
	//
	// @param buffer        Destination buffer.
	// @param count         Maximum length of output buffer.
	public native void ReadFloatArray(float[] buffer, int count) { throw new NotImplementedException(); }

	// Resets the position in a data pack.
	//
	// @param clear         If true, clears the contained data.
	public native void Reset(bool clear=false) { throw new NotImplementedException(); }

	// Returns whether or not a specified number of bytes from the data pack
	//  position to the end can be read.
	//
	// @param unused        Unused variable. Exists for backwards compatability.
	public native bool IsReadable(int unused = 0) { throw new NotImplementedException(); }
	
	// The read or write position in a data pack.
	property DataPackPos Position {
		public native get() { throw new NotImplementedException(); }
		public native set(DataPackPos pos) { throw new NotImplementedException(); }
	}
};

/**
 * Creates a new data pack.
 *
 * @return              A Handle to the data pack.  Must be closed with CloseHandle().
 */
public static DataPack CreateDataPack() { throw new NotImplementedException(); }

/**
 * Packs a normal cell into a data pack.
 *
 * @param pack          Handle to the data pack.
 * @param cell          Cell to add.
 * @error               Invalid handle.
 */
public static void WritePackCell(Handle pack, any cell) { throw new NotImplementedException(); }

/**
 * Packs a float into a data pack.
 *
 * @param pack          Handle to the data pack.
 * @param val           Float to add.
 * @error               Invalid handle.
 */
public static void WritePackFloat(Handle pack, float val) { throw new NotImplementedException(); }

/**
 * Packs a string into a data pack.
 *
 * @param pack          Handle to the data pack.
 * @param str           String to add.
 * @error               Invalid handle.
 */
public static void WritePackString(Handle pack, string str) { throw new NotImplementedException(); }

/**
 * Packs a function pointer into a data pack.
 *
 * @param pack          Handle to the data pack.
 * @param fktptr        Function pointer to add.
 * @error               Invalid handle.
 */
public static void WritePackFunction(Handle pack, Function fktptr) { throw new NotImplementedException(); }

/**
 * Reads a cell from a data pack.
 *
 * @param pack          Handle to the data pack.
 * @return              Cell value.
 * @error               Invalid handle, or bounds error.
 */
public static any ReadPackCell(Handle pack) { throw new NotImplementedException(); }

/**
 * Reads a float from a data pack.
 *
 * @param pack          Handle to the data pack.
 * @return              Float value.
 * @error               Invalid handle, or bounds error.
 */
public static float ReadPackFloat(Handle pack) { throw new NotImplementedException(); }

/**
 * Reads a string from a data pack.
 *
 * @param pack          Handle to the data pack.
 * @param buffer        Destination string buffer.
 * @param maxlen        Maximum length of output string buffer.
 * @error               Invalid handle, or bounds error.
 */
public static void ReadPackString(Handle pack, string buffer, int maxlen) { throw new NotImplementedException(); }

/**
 * Reads a function pointer from a data pack.
 *
 * @param pack          Handle to the data pack.
 * @return              Function pointer.
 * @error               Invalid handle, or bounds error.
 */
public static Function ReadPackFunction(Handle pack) { throw new NotImplementedException(); }

/**
 * Resets the position in a data pack.
 *
 * @param pack          Handle to the data pack.
 * @param clear         If true, clears the contained data.
 * @error               Invalid handle.
 */
public static void ResetPack(Handle pack, bool clear=false) { throw new NotImplementedException(); }

/**
 * Returns the read or write position in a data pack.
 *
 * @param pack          Handle to the data pack.
 * @return              Position in the data pack, only usable with calls to SetPackPosition.
 * @error               Invalid handle.
 */
public static DataPackPos GetPackPosition(Handle pack) { throw new NotImplementedException(); }

/**
 * Sets the read/write position in a data pack.
 *
 * @param pack          Handle to the data pack.
 * @param position      New position to set. Must have been previously retrieved from a call to GetPackPosition.
 * @error               Invalid handle, or position is beyond the pack bounds.
 */
public static void SetPackPosition(Handle pack, DataPackPos position) { throw new NotImplementedException(); }

/**
 * Returns whether or not a specified number of bytes from the data pack
 * position to the end can be read.
 *
 * @param pack          Handle to the data pack.
 * @param bytes         Number of bytes to simulate reading.
 * @return              True if can be read, false otherwise.
 * @error               Invalid handle.
 */
public static bool IsPackReadable(Handle pack, int bytes) { throw new NotImplementedException(); }
	}
}