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
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace Sourcemod
{
	public partial class SourceMod
	{

		/**
		 * Opaque handle to a datapack position.
		 */
		public enum DataPackPos { };

		// A DataPack allows serializing multiple variables into a single stream.
		[Serializable]
		public class DataPack : Handle, IDisposable
		{
			private MemoryStream stream;
			// Creates a new data pack.
			public DataPack()
			{
				stream = new MemoryStream();
			}

			private void WriteBytes(byte[] bytes)
			{
				var buffer = stream.GetBuffer();
				for (int i = 0; i < bytes.Length; i++)
				{
					buffer[stream.Position + i] = bytes[i];
				}

				stream.SetLength(0);
				stream.Write(buffer);
			}

			// Packs a normal cell into a data pack.
			//
			// @param cell          Cell to add.
			// @param insert        Determines whether mid-pack writes will insert instead of overwrite.
			public void WriteCell(any cell, bool insert = false)
			{
				var bytes = BitConverter.GetBytes(cell.IntValue);
				if(insert)
				{
					stream.Write(bytes, 0, bytes.Length);
				}
				else
				{
					WriteBytes(bytes);
				}
			}

		

			// Packs a float into a data pack.
			//
			// @param val           Float to add.
			// @param insert        Determines whether mid-pack writes will insert instead of overwrite.
			public void WriteFloat(float val, bool insert = false)
			{
				var bytes = BitConverter.GetBytes(val);
				if (insert)
				{
					stream.Write(bytes, 0, bytes.Length);
				}
				else
				{
					WriteBytes(bytes);
				}
			}


			// Packs a string into a data pack.
			//
			// @param str           String to add.
			// @param insert        Determines whether mid-pack writes will insert instead of overwrite.
			public void WriteString(string str, bool insert = false)
			{
				Encoding.UTF8.GetBytes(str);
				var bytes = Encoding.UTF8.GetBytes(str);
				if (insert)
				{
					stream.Write(bytes, 0, bytes.Length);
				}
				else
				{
					WriteBytes(bytes);
				}
			}

			// Packs a function pointer into a data pack.
			//
			// @param fktptr        Function pointer to add.
			// @param insert        Determines whether mid-pack writes will insert instead of overwrite.
			public void WriteFunction(dynamic fktptr, bool insert = false)
			{
				throw new NotImplementedException();
			}

			// Packs an array of cells into a data pack.
			//
			// @param array         Array to add.
			// @param count         Number of elements
			// @param insert        Determines whether mid-pack writes will insert instead of overwrite.
			public void WriteCellArray(any[] array, int count, bool insert = false)
			{
				for(int i = 0; i < count; i++)
				{
					WriteCell(array[i], insert);
				}
			}

			// Packs an array of floats into a data pack.
			//
			// @param array         Array to add.
			// @param count         Number of elements
			// @param insert        Determines whether mid-pack writes will insert instead of overwrite.
			public void WriteFloatArray(float[] array, int count, bool insert = false)
			{
				for (int i = 0; i < count; i++)
				{
					WriteFloat(array[i], insert);
				}
			}

			// Reads a cell from a data pack.
			//
			// @return		A cell at this position
			public any ReadCell()
			{
				byte[] arr = new byte[4];
				stream.Read(arr, 0, 4);
				return BitConverter.ToInt32(arr);
			}

			// Reads a float from a data pack.
			//
			// @return		Float at this position
			public float ReadFloat()
			{
				byte[] arr = new byte[4];
				stream.Read(arr, 0, 4);
				return BitConverter.ToSingle(arr);
			}

			// Reads a string from a data pack.
			//
			// @param buffer        Destination string buffer.
			// @param maxlen        Maximum length of output string buffer.
			public void ReadString(out string buffer, int maxlen)
			{
				byte[] arr = new byte[maxlen];
				stream.Read(arr, 0, maxlen);
				buffer = Encoding.UTF8.GetString(arr);
			}

			// Reads a function pointer from a data pack.
			//
			// @return              Function pointer.
			public dynamic ReadFunction() => throw new NotImplementedException();

			// Reads an array of cells a data pack.
			//
			// @param buffer        Destination buffer.
			// @param count         Maximum length of output buffer.
			public void ReadCellArray(any[] buffer, int count)
			{
				for(int i = 0; i < count; i++)
				{
					buffer[i] = ReadCell();
				}
			}


			// Reads an array of floats from a data pack.
			//
			// @param buffer        Destination buffer.
			// @param count         Maximum length of output buffer.
			public void ReadFloatArray(float[] buffer, int count)
			{
				for (int i = 0; i < count; i++)
				{
					buffer[i] = ReadFloat();
				}
			}

			// Resets the position in a data pack.
			//
			// @param clear         If true, clears the contained data.
			public void Reset(bool clear = false)
			{
				if(clear)
				{
					stream.SetLength(0);
				}
				else
				{
					stream.Position = 0;
				}
			}

			// Returns whether or not a specified number of bytes from the data pack
			//  position to the end can be read.
			//
			// @param unused        Unused variable. Exists for backwards compatability.
			public bool IsReadable(int unused = 0) => stream.CanRead;

			// The read or write position in a data pack.
			public DataPackPos Position
			{
				get => (DataPackPos)stream.Position;
				set => stream.Position = (long)value;
			}

			public void Dispose()
			{
				stream?.Dispose();
			}
		}

		/**
		 * Creates a new data pack.
		 *
		 * @return              A Handle to the data pack.  Must be closed with CloseHandle().
		 */
		public static DataPack CreateDataPack() => new DataPack();

		/**
		 * Packs a normal cell into a data pack.
		 *
		 * @param pack          Handle to the data pack.
		 * @param cell          Cell to add.
		 * @error               Invalid handle.
		 */
		public static void WritePackCell(Handle pack, any cell) => ((DataPack)pack).WriteCell(cell);

		/**
		 * Packs a float into a data pack.
		 *
		 * @param pack          Handle to the data pack.
		 * @param val           Float to add.
		 * @error               Invalid handle.
		 */
		public static void WritePackFloat(Handle pack, float val) => ((DataPack)pack).WriteFloat(val);

		/**
		 * Packs a string into a data pack.
		 *
		 * @param pack          Handle to the data pack.
		 * @param str           String to add.
		 * @error               Invalid handle.
		 */
		public static void WritePackString(Handle pack, string str) => ((DataPack)pack).WriteString(str);

		/**
		 * Packs a function pointer into a data pack.
		 *
		 * @param pack          Handle to the data pack.
		 * @param fktptr        Function pointer to add.
		 * @error               Invalid handle.
		 */
		public static void WritePackFunction(Handle pack, dynamic fktptr) => ((DataPack)pack).WriteFunction(fktptr);

		/**
		 * Reads a cell from a data pack.
		 *
		 * @param pack          Handle to the data pack.
		 * @return              Cell value.
		 * @error               Invalid handle, or bounds error.
		 */
		public static any ReadPackCell(Handle pack) => ((DataPack)pack).ReadCell();

		/**
		 * Reads a float from a data pack.
		 *
		 * @param pack          Handle to the data pack.
		 * @return              Float value.
		 * @error               Invalid handle, or bounds error.
		 */
		public static float ReadPackFloat(Handle pack) => ((DataPack)pack).ReadFloat();

		/**
		 * Reads a string from a data pack.
		 *
		 * @param pack          Handle to the data pack.
		 * @param buffer        Destination string buffer.
		 * @param maxlen        Maximum length of output string buffer.
		 * @error               Invalid handle, or bounds error.
		 */
		public static void ReadPackString(Handle pack, out string buffer, int maxlen) => ((DataPack)pack).ReadString(out buffer, maxlen);

		/**
		 * Reads a function pointer from a data pack.
		 *
		 * @param pack          Handle to the data pack.
		 * @return              Function pointer.
		 * @error               Invalid handle, or bounds error.
		 */
		public static dynamic ReadPackFunction(Handle pack) => ((DataPack)pack).ReadFunction();

		/**
		 * Resets the position in a data pack.
		 *
		 * @param pack          Handle to the data pack.
		 * @param clear         If true, clears the contained data.
		 * @error               Invalid handle.
		 */
		public static void ResetPack(Handle pack, bool clear = false) => ((DataPack)pack).Reset(clear);

		/**
		 * Returns the read or write position in a data pack.
		 *
		 * @param pack          Handle to the data pack.
		 * @return              Position in the data pack, only usable with calls to SetPackPosition.
		 * @error               Invalid handle.
		 */
		public static DataPackPos GetPackPosition(Handle pack) => ((DataPack)pack).Position;

		/**
		 * Sets the read/write position in a data pack.
		 *
		 * @param pack          Handle to the data pack.
		 * @param position      New position to set. Must have been previously retrieved from a call to GetPackPosition.
		 * @error               Invalid handle, or position is beyond the pack bounds.
		 */
		public static void SetPackPosition(Handle pack, DataPackPos position) => ((DataPack)pack).Position = position;

		/**
		 * Returns whether or not a specified number of bytes from the data pack
		 * position to the end can be read.
		 *
		 * @param pack          Handle to the data pack.
		 * @param bytes         Number of bytes to simulate reading.
		 * @return              True if can be read, false otherwise.
		 * @error               Invalid handle.
		 */
		public static bool IsPackReadable(Handle pack, int bytes = 0) => ((DataPack)pack).IsReadable(bytes);
	}
}