

using System;
using System.Collections.ObjectModel;
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
namespace Sourcemod
{
	public partial class SourceMod
	{
		public class ArrayStack : Handle
		{
			// Creates a stack structure.  A stack is a LIFO (last in, first out) 
			// vector (array) of items.  It has O(1) insertion and O(1) removal.
			//
			// Stacks have two operations: Push (adding an item) and Pop (removes 
			// items in reverse-push order).
			// 
			// The contents of the stack are uniform; i.e. storing a string and then 
			// retrieving it as an integer is NOT the same as StringToInt()!
			//
			// The "blocksize" determines how many cells each slot has; it cannot
			// be changed after creation.
			//
			// @param blocksize    The number of cells each entry in the stack can 
			//                     hold.  For example, 32 cells is equivalent to:
			//                     new Array[X][32]
			public ArrayStack(int blocksize = 1) { throw new NotImplementedException(); }

			// Clones an stack, returning a new handle with the same size and data.
			// This should NOT be confused with CloneHandle. This is a completely new
			// handle with the same data but no relation to the original. It should
			// closed when no longer needed.
			//
			// @return             New handle to the cloned stack object
			public ArrayStack Clone() { throw new NotImplementedException(); }

			// Pushes a value onto the end of the stack, adding a new index.
			//
			// This may safely be used even if the stack has a blocksize
			// greater than 1.
			//
			// @param value        Value to push.
			public void Push(any value) { throw new NotImplementedException(); }

			// Pushes a copy of a string onto the end of a stack, truncating it if it
			// is too big.
			//
			// @param value        String to push.
			public void PushString(string value) { throw new NotImplementedException(); }

			// Pushes a copy of an array of cells onto the end of a stack. The cells
			// are pushed as a block (i.e. the entire array takes up one stack slot),
			// rather than pushing each cell individually.
			//
			// @param stack        Stack Handle.
			// @param values       Block of values to copy.
			// @param size         If not set, the number of elements copied from the array
			//                     will be equal to the blocksize.  If set higher than the 
			//                     blocksize, the operation will be truncated.
			public void PushArray(ReadOnlyCollection<any[]> values, int size = -1) { throw new NotImplementedException(); }

			// Pops a cell value from a stack.
			//
			// @param block        Optionally specify which block to read from
			//                     (useful if the blocksize > 0).
			// @param asChar       Optionally read as a byte instead of a cell.
			// @return             Value popped from the stack.
			// @error              The stack is empty.
			public any Pop(int block = 0, bool asChar = false) { throw new NotImplementedException(); }

			// Pops a string value from a stack.
			//
			// @param buffer       Buffer to store string.
			// @param maxlength    Maximum size of the buffer.
			// @param written      Number of characters written to buffer, not including
			//                     the null terminator.
			// @error              The stack is empty.
			public void PopString(char[] buffer, int maxlength, out int written) { throw new NotImplementedException(); }

			// Pops a string value from a stack.
			//
			// @param buffer       Buffer to store string.
			// @param maxlength    Maximum size of the buffer.
			// @param written      Number of characters written to buffer, not including
			//                     the null terminator.
			// @error              The stack is empty.
			public void PopString(char[] buffer, int maxlength) { throw new NotImplementedException(); }

			// Pops an array of cells from a stack.
			//
			// @param buffer       Buffer to store the array in.
			// @param size         If not set, assumes the buffer size is equal to the
			//                     blocksize.  Otherwise, the size passed is used.
			// @error              The stack is empty.
			public static void PopArray(any[] buffer, int size = -1) { throw new NotImplementedException(); }

			// Returns true if the stack is empty, false otherwise.
			public bool Empty
			{
				get { throw new NotImplementedException(); }
			}
			// Retrieve the blocksize the stack was created with.
			public int BlockSize
			{
				get { throw new NotImplementedException(); }
			}
		}


	/**
	 * Creates a stack structure.  A stack is a LIFO (last in, first out) 
	 * vector (array) of items.  It has O(1) insertion and O(1) removal.
	 *
	 * Stacks have two operations: Push (adding an item) and Pop (removes 
	 * items in reverse-push order).
	 * 
	 * The contents of the stack are uniform; i.e. storing a string and then 
	 * retrieving it as an integer is NOT the same as StringToInt()!
	 *
	 * The "blocksize" determines how many cells each slot has; it cannot
	 * be changed after creation.
	 *
	 * @param blocksize     The number of cells each entry in the stack can 
	 *                      hold.  For example, 32 cells is equivalent to:
	 *                      new Array[X][32]
	 * @return              New stack Handle.
	 */
	public static ArrayStack CreateStack(int blocksize = 1) { throw new NotImplementedException(); }

	/**
	 * Pushes a value onto the end of the stack, adding a new index.
	 *
	 * This may safely be used even if the stack has a blocksize
	 * greater than 1.
	 *
	 * @param stack         Stack Handle.
	 * @param value         Value to push.
	 * @error               Invalid Handle or out of memory.
	 */
	public static void PushStackCell(Handle stack, any value) { throw new NotImplementedException(); }

	/**
	 * Pushes a copy of a string onto the end of a stack, truncating it if it is 
	 * too big.
	 *
	 * @param stack         Stack Handle.
	 * @param value         String to push.
	 * @error               Invalid Handle or out of memory.
	 */
	public static void PushStackString(Handle stack, string value) { throw new NotImplementedException(); }

	/**
	 * Pushes a copy of an array of cells onto the end of a stack.  The cells
	 * are pushed as a block (i.e. the entire array takes up one stack slot),
	 * rather than pushing each cell individually.
	 *
	 * @param stack         Stack Handle.
	 * @param values        Block of values to copy.
	 * @param size          If not set, the number of elements copied from the array
	 *                      will be equal to the blocksize.  If set higher than the 
	 *                      blocksize, the operation will be truncated.
	 * @error               Invalid Handle or out of memory.
	 */
	public static void PushStackArray(Handle stack, ReadOnlyCollection<any> values, int size = -1) { throw new NotImplementedException(); }

	/**
	 * Pops a cell value from a stack.
	 *
	 * @param stack         Stack Handle.
	 * @param value         Variable to store the value.
	 * @param block         Optionally specify which block to read from
	 *                      (useful if the blocksize > 0).
	 * @param asChar        Optionally read as a byte instead of a cell.
	 * @return              True on success, false if the stack is empty.
	 * @error               Invalid Handle.
	 */
	public static bool PopStackCell(Handle stack, out any value, int block = 0, bool asChar = false) { throw new NotImplementedException(); }

	/**
	 * Pops a string value from a stack.
	 *
	 * @param stack         Stack Handle.
	 * @param buffer        Buffer to store string.
	 * @param maxlength     Maximum size of the buffer.
	 * @return              True on success, false if the stack is empty.
	 * @error               Invalid Handle.
	 */
	public static bool PopStackString(Handle stack, string buffer, int maxlength, out int written) { throw new NotImplementedException(); }
	/**
	 * Pops a string value from a stack.
	 *
	 * @param stack         Stack Handle.
	 * @param buffer        Buffer to store string.
	 * @param maxlength     Maximum size of the buffer.
	 * @return              True on success, false if the stack is empty.
	 * @error               Invalid Handle.
	 */
	public static bool PopStackString(Handle stack, string buffer, int maxlength) { throw new NotImplementedException(); }

	/**
	 * Pops an array of cells from a stack.
	 *
	 * @param stack         Stack Handle.
	 * @param buffer        Buffer to store the array in.
	 * @param size          If not set, assumes the buffer size is equal to the
	 *                      blocksize.  Otherwise, the size passed is used.
	 * @return              True on success, false if the stack is empty.
	 * @error               Invalid Handle.
	 */
	public static bool PopStackArray(Handle stack, any[] buffer, int size = -1) { throw new NotImplementedException(); }

	/**
	 * Checks if a stack is empty.
	 *
	 * @param stack         Stack Handle.
	 * @return              True if empty, false if not empty.
	 * @error               Invalid Handle.
	 */
	public static bool IsStackEmpty(Handle stack) { throw new NotImplementedException(); }

	/**
	 * Pops a value off a stack, ignoring it completely.
	 *
	 * @param stack         Stack Handle.
	 * @return              True if something was popped, false otherwise.
	 * @error               Invalid Handle.
	 */
	public static bool PopStack(Handle stack)
	{
		any value;
		return PopStackCell(stack, out value);
	}

	/**
	 * Returns the blocksize the stack was created with.
	 *
	 * @param stack         Stack Handle.
	 * @return              The blocksize of the stack.
	 * @error               Invalid Handle
	 */
	public static int GetStackBlockSize(Handle stack) { throw new NotImplementedException(); }
}
}