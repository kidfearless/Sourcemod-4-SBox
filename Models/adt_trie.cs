
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
		/* Object-oriented wrapper for maps. */
		public class StringMap : Handle
		{
			// Creates a hash map. A hash map is a container that can map strings (called
			// "keys") to arbitrary values (cells, arrays, or strings). Keys in a hash map
			// are unique. That is, there is at most one entry in the map for a given key.
			//
			// Insertion, deletion, and lookup in a hash map are all considered to be fast
			// operations, amortized to O(1), or constant time.
			//
			// The word "Trie" in this API is historical. As of SourceMod 1.6, tries have
			// been internally replaced with hash tables, which have O(1) insertion time
			// instead of O(n).
			//
			// The StringMap must be freed via delete or CloseHandle().
			public StringMap() { throw new NotImplementedException(); }

			// Clones a string map, returning a new handle with the same size and data.
			// This should NOT be confused with CloneHandle. This is a completely new
			// handle with the same data but no relation to the original. It should be
			// closed when no longer needed with delete or CloseHandle().
			//
			// @return              New handle to the cloned string map
			public StringMap Clone() { throw new NotImplementedException(); }

			// Sets a value in a hash map, either inserting a new entry or replacing an old one.
			//
			// @param key        Key string.
			// @param value      Value to store at this key.
			// @param replace    If false, operation will fail if the key is already set.
			// @return           True on success, false on failure.
			public bool SetValue(string key, any value, bool replace = true) { throw new NotImplementedException(); }

			// Sets an array value in a Map, either inserting a new entry or replacing an old one.
			//
			// @param key        Key string.
			// @param array      Array to store.
			// @param num_items  Number of items in the array.
			// @param replace    If false, operation will fail if the key is already set.
			// @return           True on success, false on failure.
			public bool SetArray(string key, any[] array, int num_items, bool replace = true) { throw new NotImplementedException(); }

			// Sets a string value in a Map, either inserting a new entry or replacing an old one.
			//
			// @param key        Key string.
			// @param value      String to store.
			// @param replace    If false, operation will fail if the key is already set.
			// @return           True on success, false on failure.
			public bool SetString(string key, string value, bool replace = true) { throw new NotImplementedException(); }

			// Retrieves a value in a Map.
			//
			// @param key        Key string.
			// @param value      Variable to store value.
			// @return           True on success.  False if the key is not set, or the key is set 
			//                   as an array or string (not a value).
			public bool GetValue(string key, out any value) { throw new NotImplementedException(); }

			// Retrieves an array in a Map.
			//
			// @param map        Map Handle.
			// @param key        Key string.
			// @param array      Buffer to store array.
			// @param max_size   Maximum size of array buffer.
			// @param size       Optional parameter to store the number of elements written to the buffer.
			// @return           True on success.  False if the key is not set, or the key is set 
			//                   as a value or string (not an array).
			public bool GetArray(string key, any[] array, int max_size, out int size) { throw new NotImplementedException(); }
			// Retrieves an array in a Map.
			//
			// @param map        Map Handle.
			// @param key        Key string.
			// @param array      Buffer to store array.
			// @param max_size   Maximum size of array buffer.
			// @param size       Optional parameter to store the number of elements written to the buffer.
			// @return           True on success.  False if the key is not set, or the key is set 
			//                   as a value or string (not an array).
			public bool GetArray(string key, any[] array, int max_size) { throw new NotImplementedException(); }

			// Retrieves a string in a Map.
			//
			// @param key        Key string.
			// @param value      Buffer to store value.
			// @param max_size   Maximum size of string buffer.
			// @return           True on success.  False if the key is not set, or the key is set 
			//                   as a value or array (not a string).
			public bool GetString(string key, char[] value, int max_size) { throw new NotImplementedException(); }

			// Retrieves a string in a Map.
			//
			// @param key        Key string.
			// @param value      Buffer to store value.
			// @param max_size   Maximum size of string buffer.
			// @param size       Optional parameter to store the number of bytes written to the buffer.
			// @return           True on success.  False if the key is not set, or the key is set 
			//                   as a value or array (not a string).
			public bool GetString(string key, char[] value, int max_size, out int size) { throw new NotImplementedException(); }

			// Removes a key entry from a Map.
			//
			// @param key        Key string.
			// @return           True on success, false if the value was never set.
			public bool Remove(string key) { throw new NotImplementedException(); }

			// Clears all entries from a Map.
			public void Clear() { throw new NotImplementedException(); }

			// Create a snapshot of the map's keys. See StringMapSnapshot.
			public StringMapSnapshot Snapshot() { throw new NotImplementedException(); }

			// Retrieves the number of elements in a map.
			public int Size { get; }
		}

		/**
		 * A StringMapSnapshot is created via StringMap.Snapshot(). It captures the
		 * keys on a map so they can be read. Snapshots must be freed with delete or
		 * CloseHandle().
		 */
		public class StringMapSnapshot : Handle
		{
			// Returns the number of keys in the map snapshot.
			public int Length { get; }

			// Returns the buffer size required to store a given key. That is, it
			// returns the length of the key plus one.
			// 
			// @param index     Key index (starting from 0).
			// @return          Buffer size required to store the key string.
			// @error           Index out of range.
			public int KeyBufferSize(int index) { throw new NotImplementedException(); }

			// Retrieves the key string of a given key in a map snapshot.
			// 
			// @param index      Key index (starting from 0).
			// @param buffer     String buffer.
			// @param maxlength  Maximum buffer length.
			// @return           Number of bytes written to the buffer.
			// @error            Index out of range.
			public int GetKey(int index, char[] buffer, int maxlength) { throw new NotImplementedException(); }
		};

		/**
		 * Creates a hash map. A hash map is a container that can map strings (called
		 * "keys") to arbitrary values (cells, arrays, or strings). Keys in a hash map
		 * are unique. That is, there is at most one entry in the map for a given key.
		 *
		 * Insertion, deletion, and lookup in a hash map are all considered to be fast
		 * operations, amortized to O(1), or constant time.
		 *
		 * The word "Trie" in this API is historical. As of SourceMod 1.6, tries have
		 * been internally replaced with hash tables, which have O(1) insertion time
		 * instead of O(n).
		 *
		 * @return              New Map Handle, which must be freed via CloseHandle().
		 */
		public static StringMap CreateTrie() { throw new NotImplementedException(); }

		/**
		 * Sets a value in a hash map, either inserting a new entry or replacing an old one.
		 *
		 * @param map           Map Handle.
		 * @param key           Key string.
		 * @param value         Value to store at this key.
		 * @param replace       If false, operation will fail if the key is already set.
		 * @return              True on success, false on failure.
		 * @error               Invalid Handle.
		 */
		public static bool SetTrieValue(Handle map, string key, any value, bool replace = true) { throw new NotImplementedException(); }

		/**
		 * Sets an array value in a Map, either inserting a new entry or replacing an old one.
		 *
		 * @param map           Map Handle.
		 * @param key           Key string.
		 * @param array         Array to store.
		 * @param num_items     Number of items in the array.
		 * @param replace       If false, operation will fail if the key is already set.
		 * @return              True on success, false on failure.
		 * @error               Invalid Handle.
		 */
		public static bool SetTrieArray(Handle map, string key, any[] array, int num_items, bool replace = true) { throw new NotImplementedException(); }

		/**
		 * Sets a string value in a Map, either inserting a new entry or replacing an old one.
		 *
		 * @param map           Map Handle.
		 * @param key           Key string.
		 * @param value         String to store.
		 * @param replace       If false, operation will fail if the key is already set.
		 * @return              True on success, false on failure.
		 * @error               Invalid Handle.
		 */
		public static bool SetTrieString(Handle map, string key, string value, bool replace = true) { throw new NotImplementedException(); }

		/**
		 * Retrieves a value in a Map.
		 *
		 * @param map           Map Handle.
		 * @param key           Key string.
		 * @param value         Variable to store value.
		 * @return              True on success.  False if the key is not set, or the key is set 
		 *                      as an array or string (not a value).
		 * @error               Invalid Handle.
		 */
		public static bool GetTrieValue(Handle map, string key, out any value) { throw new NotImplementedException(); }

		/**
		 * Retrieves an array in a Map.
		 *
		 * @param map           Map Handle.
		 * @param key           Key string.
		 * @param array         Buffer to store array.
		 * @param max_size      Maximum size of array buffer.
		 * @param size          Optional parameter to store the number of elements written to the buffer.
		 * @return              True on success.  False if the key is not set, or the key is set 
		 *                      as a value or string (not an array).
		 * @error               Invalid Handle.
		 */
		public static bool GetTrieArray(Handle map, string key, any[] array, int max_size, out int size) { throw new NotImplementedException(); }

		/**
		 * Retrieves an array in a Map.
		 *
		 * @param map           Map Handle.
		 * @param key           Key string.
		 * @param array         Buffer to store array.
		 * @param max_size      Maximum size of array buffer.
		 * @param size          Optional parameter to store the number of elements written to the buffer.
		 * @return              True on success.  False if the key is not set, or the key is set 
		 *                      as a value or string (not an array).
		 * @error               Invalid Handle.
		 */
		public static bool GetTrieArray(Handle map, string key, any[] array, int max_size) { throw new NotImplementedException(); }

		/**
		 * Retrieves a string in a Map.
		 *
		 * @param map           Map Handle.
		 * @param key           Key string.
		 * @param value         Buffer to store value.
		 * @param max_size      Maximum size of string buffer.
		 * @param size          Optional parameter to store the number of bytes written to the buffer.
		 * @return              True on success.  False if the key is not set, or the key is set 
		 *                      as a value or array (not a string).
		 * @error               Invalid Handle.
		 */
		public static bool GetTrieString(Handle map, string key, char[] value, int max_size, out int size) { throw new NotImplementedException(); }

		/**
		 * Retrieves a string in a Map.
		 *
		 * @param map           Map Handle.
		 * @param key           Key string.
		 * @param value         Buffer to store value.
		 * @param max_size      Maximum size of string buffer.
		 * @param size          Optional parameter to store the number of bytes written to the buffer.
		 * @return              True on success.  False if the key is not set, or the key is set 
		 *                      as a value or array (not a string).
		 * @error               Invalid Handle.
		 */
		public static bool GetTrieString(Handle map, string key, char[] value, int max_size) { throw new NotImplementedException(); }

		/**
		 * Removes a key entry from a Map.
		 *
		 * @param map           Map Handle.
		 * @param key           Key string.
		 * @return              True on success, false if the value was never set.
		 * @error               Invalid Handle.
		 */
		public static bool RemoveFromTrie(Handle map, string key) { throw new NotImplementedException(); }

		/**
		 * Clears all entries from a Map.
		 *
		 * @param map           Map Handle.
		 * @error               Invalid Handle.
		 */
		public static void ClearTrie(Handle map) { throw new NotImplementedException(); }

		/**
		 * Retrieves the number of elements in a map.
		 *
		 * @param map           Map Handle.
		 * @return              Number of elements in the trie.
		 * @error               Invalid Handle.
		 */
		public static int GetTrieSize(Handle map) { throw new NotImplementedException(); }

		/**
		 * Creates a snapshot of all keys in the map. If the map is changed after this
		 * call, the changes are not reflected in the snapshot. Keys are not sorted.
		 *
		 * @param map           Map Handle.
		 * @return              New Map Snapshot Handle, which must be closed via CloseHandle().
		 * @error               Invalid Handle.
		 */
		public static Handle CreateTrieSnapshot(Handle map) { throw new NotImplementedException(); }

		/**
		 * Returns the number of keys in a map snapshot. Note that this may be
		 * different from the size of the map, since the map can change after the
		 * snapshot of its keys was taken.
		 *
		 * @param snapshot      Map snapshot.
		 * @return              Number of keys.
		 * @error               Invalid Handle.
		 */
		public static int TrieSnapshotLength(Handle snapshot) { throw new NotImplementedException(); }

		/**
		 * Returns the buffer size required to store a given key. That is, it returns
		 * the length of the key plus one.
		 *
		 * @param snapshot      Map snapshot.
		 * @param index         Key index (starting from 0).
		 * @return              Buffer size required to store the key string.
		 * @error               Invalid Handle or index out of range.
		 */
		public static int TrieSnapshotKeyBufferSize(Handle snapshot, int index) { throw new NotImplementedException(); }

		/**
		 * Retrieves the key string of a given key in a map snapshot.
		 *
		 * @param snapshot      Map snapshot.
		 * @param index         Key index (starting from 0).
		 * @param buffer        String buffer.
		 * @param maxlength     Maximum buffer length.
		 * @return              Number of bytes written to the buffer.
		 * @error               Invalid Handle or index out of range.
		 */
		public static int GetTrieSnapshotKey(Handle snapshot, int index, char[] buffer, int maxlength) { throw new NotImplementedException(); }
	}
}