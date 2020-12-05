/**
* vim: set ts=4 sw=4 tw=99 noet :
* =============================================================================
* SourceMod (C)2004-2014 AlliedModders LLC.  All rights reserved.
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
* _base program.  If not, see <http://www.gnu.org/licenses/>.
*
* As a special exception, AlliedModders LLC gives you permission to link the
* code of _base program (as well as its derivative works) to "Half-Life 2," the
* "Source Engine," the "SourcePawn JIT," and any Game MODs that run on software
* by the Valve Corporation.  You must obey the GNU General Public License in
* all respects for all other code used.  Additionally, AlliedModders LLC grants
* _base exception to all derivative works.  AlliedModders LLC defines further
* exceptions, found in LICENSE.txt (as of _base writing, version JULY-31-2007),
* or <http://www.sourcemod.net/license.php>.
*
* Version: $Id$
*/
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace Sourcemod
{
	public partial class SourceMod
	{
		/**
		 * Given a maximum string size (including the null terminator),
		 * returns the number of cells required to fit that string.
		 *
		 * @param size          Number of bytes.
		 * @return              Minimum number of cells required to fit the byte count.
		 */
		public static int ByteCountToCells(int size)
		{
			if (size != 0)
			{
				return 1;
			}

			return (size + 3) / 4;
		}

		public class ArrayList : Handle
		{
			private List<dynamic> _base;
			private int blocksize;
			// Creates a dynamic global cell array.  While slower than a normal array,
			// it can be used globally AND dynamically, which is otherwise impossible.
			//
			// The contents of the array are uniform; i.e. storing a string at index X
			// and then retrieving it as an integer is NOT the same as StringToInt()!
			// The "blocksize" determines how many cells each array slot has; it cannot
			// be changed after creation.
			//
			// @param blocksize     The number of cells each member of the array can
			//                      hold.  For example, 32 cells is equivalent to:
			//                      new Array[X][32]
			// @param startsize     Initial size of the array.  Note that data will
			//                      NOT be auto-initialized.
			// @return              New Handle to the array object.
			public ArrayList(int blocksize = 1, int startsize = 0)
			{
				this.blocksize = blocksize;
				_base = new List<dynamic>(startsize);
			}

			public ArrayList(IEnumerable<dynamic> collection)
			{
				this.blocksize = 1;
				_base = new List<dynamic>(collection);
			}



			// Clears an array of all entries.  This is the same as Resize(0).
			public void Clear() => _base.Clear();

			// Clones an array, returning a new handle with the same size and data.
			// This should NOT be confused with CloneHandle. This is a completely new
			// handle with the same data but no relation to the original. It should
			// closed when no longer needed.
			//
			// @return              New handle to the cloned array object
			public ArrayList Clone() => new ArrayList(_base);

			// Resizes an array.  If the size is smaller than the current size, the
			// array is truncated.  If the size is larger than the current size,
			// the data at the additional indexes will not be initialized.
			//
			// @param newsize       New size.
			public void Resize(int newsize)
			{
				if (newsize < this.Length)
				{
					int len = this.Length - newsize;
					_base.RemoveRange(newsize, len);
				}
				else
				{
					_base.Capacity = newsize;
				}
				Debug.Assert(newsize == this.Length);
				throw new NotImplementedException();
			}

			// Pushes a value onto the end of an array, adding a new index.
			//
			// This may safely be used even if the array has a blocksize greater
			// than 1.
			//
			// @param value         Value to push.
			// @return              Index of the new entry.
			// @error               Invalid Handle or out of memory.
			public int Push(any value)
			{
				_base.Add(value);
				return this.Length - 1;
			}

			// Pushes a string onto the end of an array, truncating it if it is too big.
			//
			// @param value         String to push.
			// @return              Index of the new entry.
			public int PushString(string value)
			{
				_base.Add(value);
				return this.Length - 1;
			}

			// Pushes an array of cells onto the end of an array.  The cells
			// are pushed as a block (i.e. the entire array sits at the index),
			// rather than pushing each cell individually.
			//
			// @param values        Block of values to copy.
			// @param size          If not set, the number of elements copied from the array
			//                      will be equal to the blocksize.  If set higher than the
			//                      blocksize, the operation will be truncated.
			// @return              Index of the new entry.
			public int PushArray(/*const*/ any[] values, int size = -1)
			{
				// TODO: handle size limits to match original behavior
				_base.Add(values);
				return this.Length - 1;
			}

			// Retrieves a cell value from an array.
			//
			// @param index         Index in the array.
			// @param block         Optionally specify which block to read from
			//                      (useful if the blocksize > 0).
			// @param asChar        Optionally read as a byte instead of a cell.
			// @return              Value read.
			// @error               Invalid index.
			public any Get(int index, int block = 0, bool asChar = false)
			{
				dynamic obj = _base[index];
				if (obj is Array arr)
				{
					return (any)arr.GetValue(block);
				}
				return obj;
			}

			// Retrieves a string value from an array.
			//
			// @param index         Index in the array.
			// @param buffer        Buffer to copy to.
			// @param maxlength     Maximum size of the buffer.
			// @return              Number of characters copied.
			// @error               Invalid index.
			public int GetString(int index, out string buffer, int? maxlength = null)
			{
				buffer = _base[index];
				if (maxlength is not null)
				{
					buffer = buffer.SubStr(0, (int)(maxlength));
					Debug.Assert(buffer.Length <= (int)(maxlength));
				}

				return buffer.Length;
			}

			// Retrieves an array of cells from an array.
			//
			// @param index         Index in the array.
			// @param buffer        Buffer to store the array in.
			// @param size          If not set, assumes the buffer size is equal to the
			//                      blocksize.  Otherwise, the size passed is used.
			// @return              Number of cells copied.
			// @error               Invalid index.
			public int GetArray(int index, any[] buffer, int? size = null)
			{
				any[] arr = _base[index];
				size ??= arr.Length;
				Array.Copy(arr, buffer, (int)size);
				return arr.Length;
			}

			// Sets a cell value in an array.
			//
			// @param index         Index in the array.
			// @param value         Cell value to set.
			// @param block         Optionally specify which block to write to
			//                      (useful if the blocksize > 0).
			// @param asChar        Optionally set as a byte instead of a cell.
			// @error               Invalid index, or invalid block.
			public void Set(int index, any value, int block = 0, bool asChar = false)
			{
				_base[index] = value;
			}

			// Sets a string value in an array.
			//
			// @param index         Index in the array.
			// @param value         String value to set.
			// @return              Number of characters copied.
			// @error               Invalid index.
			public int SetString(int index, string value)
			{
				_base[index] = value;
				return value.Length;
			}

			// Sets an array of cells in an array.
			//
			// @param index         Index in the array.
			// @param values        Array to copy.
			// @param size          If not set, assumes the buffer size is equal to the
			//                      blocksize.  Otherwise, the size passed is used.
			// @return              Number of cells copied.
			// @error               Invalid index.
			public int SetArray(int index, /*const*/ any[] values, int size = -1)
			{
				_base[index] = values;
				return values.Length;
			}

			// Shifts an array up.  All array contents after and including the given
			// index are shifted up by one, and the given index is then "free."
			// After shifting, the contents of the given index is undefined.
			//
			// @param index         Index in the array to shift up from.
			// @error               Invalid index.
			public void ShiftUp(int index)
			{
				_base.Insert(index, null);
			}

			// Removes an array index, shifting the entire array down from that position
			// on.  For example, if item 8 of 10 is removed, the last 3 items will then be
			// (6,7,8) instead of (7,8,9), and all indexes before 8 will remain unchanged.
			//
			// @param index         Index in the array to remove at.
			// @error               Invalid index.
			public void Erase(int index)
			{
				_base.RemoveAt(index);
			}

			// Swaps two items in the array.
			//
			// @param index1        First index.
			// @param index2        Second index.
			// @error               Invalid index.
			public void SwapAt(int index1, int index2)
			{
				dynamic first = _base[index1];
				dynamic second = _base[index2];
				_base[index1] = second;
				_base[index2] = first;
			}

			// Returns the index for the first occurrence of the provided string. If
			// the string cannot be located, -1 will be returned.
			//
			// @param item          String to search for
			// @return              Array index, or -1 on failure
			public int FindString(string item)
			{
				return _base.IndexOf(item);
			}

			// Returns the index for the first occurrence of the provided value. If the
			// value cannot be located, -1 will be returned.
			//
			// @param item          Value to search for
			// @param block         Optionally which block to search in
			// @return              Array index, or -1 on failure
			// @error               Invalid block index
			public int FindValue(any item, int block = 0)
			{
				return _base.IndexOf(item);
			}
			// Sort an ADT Array. Specify the type as Integer, Float, or String.
			//
			// @param order         Sort order to use, same as other sorts.
			// @param type          Data type stored in the ADT Array
			public void Sort(SortOrder order, SortType type)
			{
				switch (order)
				{
					case SortOrder.Sort_Ascending:
						_base.Sort();
						break;
					case SortOrder.Sort_Descending:
						_base.Sort((dynamic x, dynamic y) =>
						{
							return x > y;
						});
						break;
					case SortOrder.Sort_Random:
						{
							_base.Sort((dynamic x, dynamic y) =>
							{
								return new Random().Next(0, 2);
							});
						}
						break;
					default:
						break;
				}
			}
			// Custom sorts an ADT Array. You must pass in a comparison function.
			//
			// @param sortfunc      Sort comparison function to use
			// @param hndl          Optional Handle to pass through the comparison calls.
			[Obsolete("Cannot gurantee accuracy of indices, use the other sort method")]
			public void SortCustom(SortFuncADTArray sortfunc, Handle hndl = INVALID_HANDLE)
			{
				_base.Sort((dynamic x, dynamic y) =>
				{
					return sortfunc.Invoke(_base.IndexOf(x), _base.IndexOf(y), this, hndl);
				});
			}
			// Retrieve the size of the array.
			public int Length
			{
				get => _base.Count;
			}

			// Retrieve the blocksize the array was created with.
			public int BlockSize
			{
				get => int.MaxValue;
			}

			internal void Remove(int index)
			{
				throw new NotImplementedException();
			}
		}

		/**
		 * Creates a dynamic global cell array.  While slower than a normal array,
		 * it can be used globally AND dynamically, which is otherwise impossible.
		 *
		 * The contents of the array are uniform; i.e. storing a string at index X
		 * and then retrieving it as an integer is NOT the same as StringToInt()!
		 * The "blocksize" determines how many cells each array slot has; it cannot
		 * be changed after creation.
		 *
		 * @param blocksize     The number of cells each member of the array can
		 *                      hold.  For example, 32 cells is equivalent to:
		 *                      new Array[X][32]
		 * @param startsize     Initial size of the array.  Note that data will
		 *                      NOT be auto-initialized.
		 * @return              New Handle to the array object.
		 */
		public static ArrayList CreateArray(int blocksize = 1, int startsize = 0) => new ArrayList(blocksize, startsize);

		/**
		 * Clears an array of all entries.  This is the same as ResizeArray(0).
		 *
		 * @param array         Array Handle.
		 * @error               Invalid Handle.
		 */
		public static void ClearArray(Handle array) => ((ArrayList)array).Clear();

		/**
		 * Clones an array, returning a new handle with the same size and data. This should NOT
		 * be confused with CloneHandle. This is a completely new handle with the same data but
		 * no relation to the original. You MUST close it.
		 *
		 * @param array         Array handle to be cloned
		 * @return              New handle to the cloned array object
		 * @error               Invalid Handle
		 */
		public static Handle CloneArray(Handle array) => ((ArrayList)array).Clone();

		/**
		 * Resizes an array.  If the size is smaller than the current size,
		 * the array is truncated.  If the size is larger than the current size,
		 * the data at the additional indexes will not be initialized.
		 *
		 * @param array         Array Handle.
		 * @param newsize       New size.
		 * @error               Invalid Handle or out of memory.
		 */
		public static void ResizeArray(Handle array, int newsize) => ((ArrayList)array).Resize(newsize);

		/**
		 * Returns the array size.
		 *
		 * @param array         Array Handle.
		 * @return              Number of elements in the array.
		 * @error               Invalid Handle.
		 */
		public static int GetArraySize(Handle array) => ((ArrayList)array).Length;

		/**
		 * Pushes a value onto the end of an array, adding a new index.
		 *
		 * This may safely be used even if the array has a blocksize
		 * greater than 1.
		 *
		 * @param array         Array Handle.
		 * @param value         Value to push.
		 * @return              Index of the new entry.
		 * @error               Invalid Handle or out of memory.
		 */
		public static int PushArrayCell(Handle array, any value) => ((ArrayList)array).Push(value);

		/**
		 * Pushes a string onto the end of an array, truncating it
		 * if it is too big.
		 *
		 * @param array         Array Handle.
		 * @param value         String to push.
		 * @return              Index of the new entry.
		 * @error               Invalid Handle or out of memory.
		 */
		public static int PushArrayString(Handle array, string value) => ((ArrayList)array).PushString(value);

		/**
		 * Pushes an array of cells onto the end of an array.  The cells
		 * are pushed as a block (i.e. the entire array sits at the index),
		 * rather than pushing each cell individually.
		 *
		 * @param array         Array Handle.
		 * @param values        Block of values to copy.
		 * @param size          If not set, the number of elements copied from the array
		 *                      will be equal to the blocksize.  If set higher than the
		 *                      blocksize, the operation will be truncated.
		 * @return              Index of the new entry.
		 * @error               Invalid Handle or out of memory.
		 */
		public static int PushArrayArray(Handle array, any[] values, int size = -1) => ((ArrayList)array).PushArray(values, size);

		/**
		 * Retrieves a cell value from an array.
		 *
		 * @param array         Array Handle.
		 * @param index         Index in the array.
		 * @param block         Optionally specify which block to read from
		 *                      (useful if the blocksize > 0).
		 * @param asChar        Optionally read as a byte instead of a cell.
		 * @return              Value read.
		 * @error               Invalid Handle, invalid index, or invalid block.
		 */
		public static any GetArrayCell(Handle array, int index, int block = 0, bool asChar = false) => ((ArrayList)array).Get(index, block, asChar);

		/**
		 * Retrieves a string value from an array.
		 *
		 * @param array         Array Handle.
		 * @param index         Index in the array.
		 * @param buffer        Buffer to copy to.
		 * @param maxlength     Maximum size of the buffer.
		 * @return              Number of characters copied.
		 * @error               Invalid Handle or invalid index.
		 */
		public static int GetArrayString(Handle array, int index, out string buffer, int maxlength) => ((ArrayList)array).GetString(index, out buffer, maxlength);

		/**
		 * Retrieves an array of cells from an array.
		 *
		 * @param array         Array Handle.
		 * @param index         Index in the array.
		 * @param buffer        Buffer to store the array in.
		 * @param size          If not set, assumes the buffer size is equal to the
		 *                      blocksize.  Otherwise, the size passed is used.
		 * @return              Number of cells copied.
		 * @error               Invalid Handle or invalid index.
		 */
		public static int GetArrayArray(Handle array, int index, any[] buffer, int size = -1) => ((ArrayList)array).GetArray(index, buffer, size);

		/**
		 * Sets a cell value in an array.
		 *
		 * @param array         Array Handle.
		 * @param index         Index in the array.
		 * @param value         Cell value to set.
		 * @param block         Optionally specify which block to write to
		 *                      (useful if the blocksize > 0).
		 * @param asChar        Optionally set as a byte instead of a cell.
		 * @error               Invalid Handle, invalid index, or invalid block.
		 */
		public static void SetArrayCell(Handle array, int index, any value, int block = 0, bool asChar = false) => ((ArrayList)array).Set(index, value, block, asChar);

		/**
		 * Sets a string value in an array.
		 *
		 * @param array         Array Handle.
		 * @param index         Index in the array.
		 * @param value         String value to set.
		 * @return              Number of characters copied.
		 * @error               Invalid Handle or invalid index.
		 */
		public static int SetArrayString(Handle array, int index, string value) => ((ArrayList)array).SetString(index, value);

		/**
		 * Sets an array of cells in an array.
		 *
		 * @param array         Array Handle.
		 * @param index         Index in the array.
		 * @param values        Array to copy.
		 * @param size          If not set, assumes the buffer size is equal to the
		 *                      blocksize.  Otherwise, the size passed is used.
		 * @return              Number of cells copied.
		 * @error               Invalid Handle or invalid index.
		 */
		public static int SetArrayArray(Handle array, int index, any[] values, int size = -1) => ((ArrayList)array).SetArray(index, values, size);

		/**
		 * Shifts an array up.  All array contents after and including the given
		 * index are shifted up by one, and the given index is then "free."
		 * After shifting, the contents of the given index is undefined.
		 *
		 * @param array         Array Handle.
		 * @param index         Index in the array to shift up from.
		 * @error               Invalid Handle or invalid index.
		 */
		public static void ShiftArrayUp(Handle array, int index) => ((ArrayList)array).ShiftUp(index);

		/**
		 * Removes an array index, shifting the entire array down from that position
		 * on.  For example, if item 8 of 10 is removed, the last 3 items will then be
		 * (6,7,8) instead of (7,8,9), and all indexes before 8 will remain unchanged.
		 *
		 * @param array         Array Handle.
		 * @param index         Index in the array to remove at.
		 * @error               Invalid Handle or invalid index.
		 */
		public static void RemoveFromArray(Handle array, int index) => ((ArrayList)array).Remove(index);

		/**
		 * Swaps two items in the array.
		 *
		 * @param array         Array Handle.
		 * @param index1        First index.
		 * @param index2        Second index.
		 * @error               Invalid Handle or invalid index.
		 */
		public static void SwapArrayItems(Handle array, int index1, int index2) => ((ArrayList)array).SwapAt(index1, index2);

		/**
		 * Returns the index for the first occurrence of the provided string. If the string
		 * cannot be located, -1 will be returned.
		 *
		 * @param array         Array Handle.
		 * @param item          String to search for
		 * @return              Array index, or -1 on failure
		 * @error               Invalid Handle
		 */
		public static int FindStringInArray(Handle array, string item) => ((ArrayList)array).FindString(item);

		/**
		 * Returns the index for the first occurrence of the provided value. If the value
		 * cannot be located, -1 will be returned.
		 *
		 * @param array         Array Handle.
		 * @param item          Value to search for
		 * @param block         Optionally which block to search in
		 * @return              Array index, or -1 on failure
		 * @error               Invalid Handle or invalid block
		 */
		public static int FindValueInArray(Handle array, any item, int block = 0) => ((ArrayList)array).FindValue(item, block);

		/**
		 * Returns the blocksize the array was created with.
		 *
		 * @param array         Array Handle.
		 * @return              The blocksize of the array.
		 * @error               Invalid Handle
		 */
		public static int GetArrayBlockSize(Handle array) => ((ArrayList)array).BlockSize;
	}
}