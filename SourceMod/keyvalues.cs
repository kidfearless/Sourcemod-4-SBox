/**
 * vim: set ts=4 sw=4 tw=99 noet :
 * =============================================================================
 * SourceMod (C)2004-2014 AlliedModders LLC.  All rights reserved.
 * =============================================================================
 *
 * This file is part of the SourceMod/SourcePawn SDK.
 *
 * This program is free software; you can redistribute it and/or modify it under
 * the terms of the GNU General Public License, version 3.0f, as published by the
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
		 * KeyValue data value types
		 */
		public enum KvDataTypes
		{
			KvData_None = 0,    /**< Type could not be identified, or no type */
			KvData_String,      /**< String value */
			KvData_Int,         /**< Integer value */
			KvData_Float,       /**< Floating point value */
			KvData_Ptr,         /**< Pointer value (sometimes called "long") */
			KvData_WString,     /**< Wide string value */
			KvData_Color,       /**< Color value */
			KvData_UInt64,      /**< Large integer value */
			/* --- */
			KvData_NUMTYPES
		};
		public const int
			KvData_None = 0,    /**< Type could not be identified, or no type */
			KvData_String = 1,      /**< String value */
			KvData_Int = 2,         /**< Integer value */
			KvData_Float = 3,       /**< Floating point value */
			KvData_Ptr = 4,         /**< Pointer value (sometimes called "long") */
			KvData_WString = 5,     /**< Wide string value */
			KvData_Color = 6,       /**< Color value */
			KvData_UInt64 = 7,      /**< Large integer value */
			/* --- */
			KvData_NUMTYPES = 8;

		public class KeyValues : Handle
		{
			// Creates a new KeyValues structure.  The Handle must be closed with
			// CloseHandle() or delete.
			//
			// @param name          Name of the root section.
			// @param firstKey      If non-empty, specifies the first key value.
			// @param firstValue    If firstKey is non-empty, specifies the first key's value.
			public KeyValues(string name, string firstKey = "", string firstValue = "") { throw new NotImplementedException(); }

			// Exports a KeyValues tree to a file. The tree is dumped from the current position.
			//
			// @param file          File to dump write to.
			// @return              True on success, false otherwise.
			public bool ExportToFile(string file) { throw new NotImplementedException(); }

			// Exports a KeyValues tree to a string. The string is dumped from the current position.
			//
			// @param buffer        Buffer to write to.
			// @param maxlength     Max length of buffer.
			// @return              Number of bytes that can be written to buffer.
			public int ExportToString(string buffer, int maxlength) { throw new NotImplementedException(); }

			// Amount of bytes written by ExportToFile & ExportToString.
			public int ExportLength
			{
				get { throw new NotImplementedException(); }
			}

			// Imports a file in KeyValues format. The file is read into the current
			// position of the tree.
			//
			// @param file          File to read from.
			// @return              True on success, false otherwise.
			public bool ImportFromFile(string file) { throw new NotImplementedException(); }

			// Converts a given string to a KeyValues tree.  The string is read into
			// the current postion of the tree.
			//
			// @param buffer        String buffer to load into the KeyValues.
			// @param resourceName  The resource name of the KeyValues, used for error tracking purposes.
			// @return              True on success, false otherwise.
			public bool ImportFromString(string buffer, string resourceName = "StringToKeyValues") { throw new NotImplementedException(); }

			// Imports subkeys in the given KeyValues, at the current position in that
			// KeyValues, into the current position in this KeyValues. Note that this
			// copies keys; it does not embed a reference to them.
			//
			// @param other         Origin KeyValues Handle.
			public void Import(KeyValues other) { throw new NotImplementedException(); }

			// Sets a string value of a KeyValues key.
			//
			// @param kv            KeyValues Handle.
			// @param key           Name of the key, or NULL_STRING.
			// @param value         String value.
			public void SetString(string key, string value) { throw new NotImplementedException(); }

			// Sets an integer value of a KeyValues key.
			//
			// @param key           Name of the key, or NULL_STRING.
			// @param value         Value number.
			public void SetNum(string key, int value) { throw new NotImplementedException(); }

			// Sets a large integer value of a KeyValues key.
			//
			// @param key           Name of the key, or NULL_STRING.
			// @param value         Large integer value (0=High bits, 1=Low bits)
			public void SetUInt64(string key, int[/* 2 */] value)
			{
				throw new NotImplementedException();
			}

			// Sets a floating point value of a KeyValues key.
			//
			// @param key           Name of the key, or NULL_STRING.
			// @param value         Floating point value.
			public void SetFloat(string key, float value) { throw new NotImplementedException(); }

			// Sets a set of color values of a KeyValues key.
			//
			// @param key           Name of the key, or NULL_STRING.
			// @param r             Red value.
			// @param g             Green value.
			// @param b             Blue value.
			// @param a             Alpha value.
			public void SetColor(string key, int r, int g, int b, int a = 0) { throw new NotImplementedException(); }

			// Sets a set of color values of a KeyValues key.
			//
			// @param key           Name of the key, or NULL_STRING.
			// @param color         Red, green, blue and alpha channels.
			public void SetColor4(string key, int[/* 4 */] color)
			{
				this.SetColor(key, color[0], color[1], color[2], color[3]);
			}

			// Sets a vector value of a KeyValues key.
			//
			// @param key           Name of the key, or NULL_STRING.
			// @param vec           Vector value.
			public void SetVector(string key, float[/*3*/] vec) { throw new NotImplementedException(); }

			// Retrieves a string value from a KeyValues key.
			//
			// @param key           Name of the key, or NULL_STRING.
			// @param value         Buffer to store key value in.
			// @param maxlength     Maximum length of the value buffer.
			// @param defvalue      Optional default value to use if the key is not found.
			public void GetString(string key, string value, int maxlength, string defvalue = "") { throw new NotImplementedException(); }

			// Retrieves an integer value from a KeyValues key.
			//
			// @param key           Name of the key, or NULL_STRING.
			// @param defvalue      Optional default value to use if the key is not found.
			// @return              Integer value of the key.
			public int GetNum(string key, int defvalue = 0) { throw new NotImplementedException(); }

			// Retrieves a floating point value from a KeyValues key.
			//
			// @param key           Name of the key, or NULL_STRING.
			// @param defvalue      Optional default value to use if the key is not found.
			// @return              Floating point value of the key.
			public float GetFloat(string key, float defvalue = 0.0f) { throw new NotImplementedException(); }

			// Retrieves a set of color values from a KeyValues key.
			//
			// @param key           Name of the key, or NULL_STRING.
			// @param r             Red value, set by reference.
			// @param g             Green value, set by reference.
			// @param b             Blue value, set by reference.
			// @param a             Alpha value, set by reference.
			public void GetColor(string key, out int r, out int g, out int b, out int a) { throw new NotImplementedException(); }

			// Retrieves a set of color values from a KeyValues key.
			//
			// @param key           Name of the key, or NULL_STRING.
			// @param color         Red, green, blue, and alpha channels.
			public void GetColor4(string key, int[/* 4 */] color)
			{
				int r, g, b, a;
				this.GetColor(key, out r, out g, out b, out a);
				color[0] = r;
				color[1] = g;
				color[2] = b;
				color[3] = a;
			}

			// Retrieves a large integer value from a KeyValues key.
			//
			// @param key           Name of the key, or NULL_STRING.
			// @param value         Array to represent the large integer.
			// @param defvalue      Optional default value to use if the key is not found.
			public void GetUInt64(string key, int[/* 2 */] value, int[/*2*/] defvalue = null)
			{
				throw new NotImplementedException();
			}

			// Retrieves a vector value from a KeyValues key.
			//
			// @param key           Name of the key, or NULL_STRING.
			// @param vec           Destination vector to store the value in.
			// @param defvalue      Optional default value to use if the key is not found.
			public void GetVector(string key, float[/* 3 */] vec, float[/*3*/] defvalue = null)
			{
				throw new NotImplementedException();
			}

			// Sets the current position in the KeyValues tree to the given key.
			//
			// @param key           Name of the key.
			// @param create        If true, and the key does not exist, it will be created.
			// @return              True if the key exists, false if it does not and was not created.
			public bool JumpToKey(string key, bool create = false) { throw new NotImplementedException(); }

			// Sets the current position in the KeyValues tree to the given key.
			//
			// @param id            KeyValues id.
			// @return              True if the key exists, false if it does not.
			public bool JumpToKeySymbol(int id) { throw new NotImplementedException(); }

			// Sets the current position in the KeyValues tree to the first sub key.
			// This public static adds to the internal traversal stack.
			//
			// @param keyOnly       If false, non-keys will be traversed (values).
			// @return              True on success, false if there was no first sub key.
			public bool GotoFirstSubKey(bool keyOnly = true) { throw new NotImplementedException(); }

			// Sets the current position in the KeyValues tree to the next sub key.
			// This public static does NOT add to the internal traversal stack, and thus
			// GoBack() is not needed for each successive call to this function.
			//
			// @param keyOnly       If false, non-keys will be traversed (values).
			// @return              True on success, false if there was no next sub key.
			public bool GotoNextKey(bool keyOnly = true) { throw new NotImplementedException(); }

			// Saves the current position in the traversal stack onto the traversal
			// stack.  This can be useful if you wish to use KvGotoNextKey() and
			// have the previous key saved for backwards traversal.
			//
			// @param kv            KeyValues Handle.
			public void SavePosition() { throw new NotImplementedException(); }

			// Jumps back to the previous position.  Returns false if there are no
			// previous positions (i.e., at the root node).  This should be called
			// once for each successful Jump call, in order to return to the top node.
			// This function pops one node off the internal traversal stack.
			//
			// @return              True on success, false if there is no higher node.
			public bool GoBack() { throw new NotImplementedException(); }

			// Removes the given key from the current position.
			//
			// @param key           Name of the key.
			// @return              True on success, false if key did not exist.
			public bool DeleteKey(string key) { throw new NotImplementedException(); }

			// Removes the current sub-key and attempts to set the position
			// to the sub-key after the removed one.  If no such sub-key exists,
			// the position will be the parent key in the traversal stack.
			// Given the sub-key having position "N" in the traversal stack, the
			// removal will always take place from position "N-1."
			//
			// @param kv            KeyValues Handle.
			// @return              1 if removal succeeded and there was another key.
			//                      0 if the current node was not contained in the
			//                        previous node, or no previous node exists.
			//                      -1 if removal succeeded and there were no more keys,
			//                        thus the state is as if KvGoBack() was called.
			public int DeleteThis() { throw new NotImplementedException(); }

			// Sets the position back to the top node, emptying the entire node
			// traversal history.  This can be used instead of looping KvGoBack()
			// if recursive iteration is not important.
			//
			// @param kv            KeyValues Handle.
			public void Rewind() { throw new NotImplementedException(); }

			// Retrieves the current section name.
			//
			// @param section       Buffer to store the section name.
			// @param maxlength     Maximum length of the name buffer.
			// @return              True on success, false on failure.
			public bool GetSectionName(string section, int maxlength) { throw new NotImplementedException(); }

			// Sets the current section name.
			//
			// @param section       Section name.
			public void SetSectionName(string section) { throw new NotImplementedException(); }

			// Returns the data type at a key.
			//
			// @param key           Key name.
			// @return              KvDataType value of the key.
			public KvDataTypes GetDataType(string key) { throw new NotImplementedException(); }

			// Sets whether or not the KeyValues parser will read escape sequences.
			// For example, \n would be read as a literal newline.  This defaults
			// to false for new KeyValues structures.
			//
			// @param useEscapes    Whether or not to read escape sequences.
			public void SetEscapeSequences(bool useEscapes) { throw new NotImplementedException(); }

			// Returns the position in the jump stack; I.e. the number of calls
			// required for KvGoBack to return to the root node.  If at the root node,
			// 0 is returned.
			//
			// @return              Number of non-root nodes in the jump stack.
			public int NodesInStack() { throw new NotImplementedException(); }

			// Finds a KeyValues name by id.
			//
			// @param id            KeyValues id.
			// @param name          Buffer to store the name.
			// @param maxlength     Maximum length of the value buffer.
			// @return              True on success, false if id not found.
			public bool FindKeyById(int id, string name, int maxlength) { throw new NotImplementedException(); }

			// Finds a KeyValues id inside a KeyValues tree.
			//
			// @param key           Key name.
			// @param id            Id of the found KeyValue.
			// @return              True on success, false if key not found.
			public bool GetNameSymbol(string key, ref int id) { throw new NotImplementedException(); }

			// Retrieves the current section id.
			//
			// @param kv            KeyValues Handle.
			// @param id            Id of the current section.
			// @return              True on success, false on failure.
			public bool GetSectionSymbol(ref int id) { throw new NotImplementedException(); }
		};

		/**
		 * Creates a new KeyValues structure.  The Handle must always be closed.
		 *
		 * @param name          Name of the root section.
		 * @param firstKey      If non-empty, specifies the first key value.
		 * @param firstValue    If firstKey is non-empty, specifies the first key's value.
		 * @return              A Handle to a new KeyValues structure.
		 */
		public static KeyValues CreateKeyValues(string name, string firstKey = "", string firstValue = "") { throw new NotImplementedException(); }

		/**
		 * Sets a string value of a KeyValues key.
		 *
		 * @param kv            KeyValues Handle.
		 * @param key           Name of the key, or NULL_STRING.
		 * @param value         String value.
		 * @error               Invalid Handle.
		 */
		public static void KvSetString(Handle kv, string key, string value) { throw new NotImplementedException(); }

		/**
		 * Sets an integer value of a KeyValues key.
		 *
		 * @param kv            KeyValues Handle.
		 * @param key           Name of the key, or NULL_STRING.
		 * @param value         Value number.
		 * @error               Invalid Handle.
		 */
		public static void KvSetNum(Handle kv, string key, int value) { throw new NotImplementedException(); }

		/**
		 * Sets a large integer value of a KeyValues key.
		 *
		 * @param kv            KeyValues Handle.
		 * @param key           Name of the key, or NULL_STRING.
		 * @param value         Large integer value (0=High bits, 1=Low bits)
		 * @error               Invalid Handle.
		 */
		public static void KvSetUInt64(Handle kv, string key, int[/* 2 */] value) { throw new NotImplementedException(); }

		/**
		 * Sets a floating point value of a KeyValues key.
		 *
		 * @param kv            KeyValues Handle.
		 * @param key           Name of the key, or NULL_STRING.
		 * @param value         Floating point value.
		 * @error               Invalid Handle.
		 */
		public static void KvSetFloat(Handle kv, string key, float value) { throw new NotImplementedException(); }

		/**
		 * Sets a set of color values of a KeyValues key.
		 *
		 * @param kv            KeyValues Handle.
		 * @param key           Name of the key, or NULL_STRING.
		 * @param r             Red value.
		 * @param g             Green value.
		 * @param b             Blue value.
		 * @param a             Alpha value.
		 * @error               Invalid Handle.
		 */
		public static void KvSetColor(Handle kv, string key, int r, int g, int b, int a = 0) { throw new NotImplementedException(); }

		/**
		 * Sets a vector value of a KeyValues key.
		 *
		 * @param kv            KeyValues Handle.
		 * @param key           Name of the key, or NULL_STRING.
		 * @param vec           Vector value.
		 * @error               Invalid Handle.
		 */
		public static void KvSetVector(Handle kv, string key, float[/*3*/] vec) { throw new NotImplementedException(); }

		/**
		 * Retrieves a string value from a KeyValues key.
		 *
		 * @param kv            KeyValues Handle.
		 * @param key           Name of the key, or NULL_STRING.
		 * @param value         Buffer to store key value in.
		 * @param maxlength     Maximum length of the value buffer.
		 * @param defvalue      Optional default value to use if the key is not found.
		 * @error               Invalid Handle.
		 */
		public static void KvGetString(Handle kv, string key, string value, int maxlength, string defvalue = "") { throw new NotImplementedException(); }

		/**
		 * Retrieves an integer value from a KeyValues key.
		 *
		 * @param kv            KeyValues Handle.
		 * @param key           Name of the key, or NULL_STRING.
		 * @param defvalue      Optional default value to use if the key is not found.
		 * @return              Integer value of the key.
		 * @error               Invalid Handle.
		 */
		public static int KvGetNum(Handle kv, string key, int defvalue = 0) { throw new NotImplementedException(); }

		/**
		 * Retrieves a floating point value from a KeyValues key.
		 *
		 * @param kv            KeyValues Handle.
		 * @param key           Name of the key, or NULL_STRING.
		 * @param defvalue      Optional default value to use if the key is not found.
		 * @return              Floating point value of the key.
		 * @error               Invalid Handle.
		 */
		public static float KvGetFloat(Handle kv, string key, float defvalue = 0.0f) { throw new NotImplementedException(); }

		/**
		 * Retrieves a set of color values from a KeyValues key.
		 *
		 * @param kv            KeyValues Handle.
		 * @param key           Name of the key, or NULL_STRING.
		 * @param r             Red value, set by reference.
		 * @param g             Green value, set by reference.
		 * @param b             Blue value, set by reference.
		 * @param a             Alpha value, set by reference.
		 * @error               Invalid Handle.
		 */
		public static void KvGetColor(Handle kv, string key, ref int r, ref int g, ref int b, ref int a) { throw new NotImplementedException(); }

		/**
		 * Retrieves a large integer value from a KeyValues key.
		 *
		 * @param kv            KeyValues Handle.
		 * @param key           Name of the key, or NULL_STRING.
		 * @param value         Array to represent the large integer.
		 * @param defvalue      Optional default value to use if the key is not found.
		 * @error               Invalid Handle.
		 */
		public static void KvGetUInt64(Handle kv, string key, int[/* 2 */] value, int[/*2*/] defvalue = null) { throw new NotImplementedException(); }

		/**
		 * Retrieves a vector value from a KeyValues key.
		 *
		 * @param kv            KeyValues Handle.
		 * @param key           Name of the key, or NULL_STRING.
		 * @param vec           Destination vector to store the value in.
		 * @param defvalue      Optional default value to use if the key is not found.
		 * @error               Invalid Handle.
		 */
		public static void KvGetVector(Handle kv, string key, float[/* 3 */] vec, float[/*3*/] defvalue = null) { throw new NotImplementedException(); }

		/**
		 * Sets the current position in the KeyValues tree to the given key.
		 *
		 * @param kv            KeyValues Handle.
		 * @param key           Name of the key.
		 * @param create        If true, and the key does not exist, it will be created.
		 * @return              True if the key exists, false if it does not and was not created.
		 */
		public static bool KvJumpToKey(Handle kv, string key, bool create = false) { throw new NotImplementedException(); }

		/**
		 * Sets the current position in the KeyValues tree to the given key.
		 *
		 * @param kv            KeyValues Handle.
		 * @param id            KeyValues id.
		 * @return              True if the key exists, false if it does not.
		 */
		public static bool KvJumpToKeySymbol(Handle kv, int id) { throw new NotImplementedException(); }

		/**
		 * Sets the current position in the KeyValues tree to the first sub key.
		 * This public static adds to the internal traversal stack.
		 *
		 * @param kv            KeyValues Handle.
		 * @param keyOnly       If false, non-keys will be traversed (values).
		 * @return              True on success, false if there was no first sub key.
		 * @error               Invalid Handle.
		 */
		public static bool KvGotoFirstSubKey(Handle kv, bool keyOnly = true) { throw new NotImplementedException(); }

		/**
		 * Sets the current position in the KeyValues tree to the next sub key.
		 * This public static does NOT add to the internal traversal stack, and thus
		 * KvGoBack() is not needed for each successive call to this function.
		 *
		 * @param kv            KeyValues Handle.
		 * @param keyOnly       If false, non-keys will be traversed (values).
		 * @return              True on success, false if there was no next sub key.
		 * @error               Invalid Handle.
		 */
		public static bool KvGotoNextKey(Handle kv, bool keyOnly = true) { throw new NotImplementedException(); }

		/**
		 * Saves the current position in the traversal stack onto the traversal
		 * stack.  This can be useful if you wish to use KvGotoNextKey() and
		 * have the previous key saved for backwards traversal.
		 *
		 * @param kv            KeyValues Handle.
		 * @error               Invalid Handle.
		 */
		public static void KvSavePosition(Handle kv) { throw new NotImplementedException(); }

		/**
		 * Removes the given key from the current position.
		 *
		 * @param kv            KeyValues Handle.
		 * @param key           Name of the key.
		 * @return              True on success, false if key did not exist.
		 * @error               Invalid Handle.
		 */
		public static bool KvDeleteKey(Handle kv, string key) { throw new NotImplementedException(); }

		/**
		 * Removes the current sub-key and attempts to set the position
		 * to the sub-key after the removed one.  If no such sub-key exists,
		 * the position will be the parent key in the traversal stack.
		 * Given the sub-key having position "N" in the traversal stack, the
		 * removal will always take place from position "N-1."
		 *
		 * @param kv            KeyValues Handle.
		 * @return              1 if removal succeeded and there was another key.
		 *                      0 if the current node was not contained in the
		 *                        previous node, or no previous node exists.
		 *                     -1 if removal succeeded and there were no more keys,
		 *                        thus the state is as if KvGoBack() was called.
		 * @error               Invalid Handle.
		 */
		public static int KvDeleteThis(Handle kv) { throw new NotImplementedException(); }

		/**
		 * Jumps back to the previous position.  Returns false if there are no
		 * previous positions (i.e., at the root node).  This should be called
		 * once for each successful Jump call, in order to return to the top node.
		 * This function pops one node off the internal traversal stack.
		 *
		 * @param kv            KeyValues Handle.
		 * @return              True on success, false if there is no higher node.
		 * @error               Invalid Handle.
		 */
		public static bool KvGoBack(Handle kv) { throw new NotImplementedException(); }

		/**
		 * Sets the position back to the top node, emptying the entire node
		 * traversal history.  This can be used instead of looping KvGoBack()
		 * if recursive iteration is not important.
		 *
		 * @param kv            KeyValues Handle.
		 * @error               Invalid Handle.
		 */
		public static void KvRewind(Handle kv) { throw new NotImplementedException(); }

		/**
		 * Retrieves the current section name.
		 *
		 * @param kv            KeyValues Handle.
		 * @param section       Buffer to store the section name.
		 * @param maxlength     Maximum length of the name buffer.
		 * @return              True on success, false on failure.
		 * @error               Invalid Handle.
		 */
		public static bool KvGetSectionName(Handle kv, string section, int maxlength) { throw new NotImplementedException(); }

		/**
		 * Sets the current section name.
		 *
		 * @param kv            KeyValues Handle.
		 * @param section       Section name.
		 * @error               Invalid Handle.
		 */
		public static void KvSetSectionName(Handle kv, string section) { throw new NotImplementedException(); }

		/**
		 * Returns the data type at a key.
		 *
		 * @param kv            KeyValues Handle.
		 * @param key           Key name.
		 * @return              KvDataType value of the key.
		 * @error               Invalid Handle.
		 */
		public static KvDataTypes KvGetDataType(Handle kv, string key) { throw new NotImplementedException(); }

		/**
		 * Converts a KeyValues tree to a file.  The tree is dumped
		 * from the current position.
		 *
		 * @param kv            KeyValues Handle.
		 * @param file          File to dump write to.
		 * @return              True on success, false otherwise.
		 * @error               Invalid Handle.
		 */
		public static bool KeyValuesToFile(Handle kv, string file) { throw new NotImplementedException(); }

		/**
		 * Converts a file to a KeyValues tree.  The file is read into
		 * the current position of the tree.
		 *
		 * @param kv            KeyValues Handle.
		 * @param file          File to read from.
		 * @return              True on success, false otherwise.
		 * @error               Invalid Handle.
		 */
		public static bool FileToKeyValues(Handle kv, string file) { throw new NotImplementedException(); }

		/**
		 * Converts a given string to a KeyValues tree.  The string is read into
		 * the current postion of the tree.
		 *
		 * @param kv            KeyValues Handle.
		 * @param buffer        String buffer to load into the KeyValues.
		 * @param resourceName  The resource name of the KeyValues, used for error tracking purposes.
		 * @return              True on success, false otherwise.
		 * @error               Invalid Handle.
		 */
		public static bool StringToKeyValues(Handle kv, string buffer, string resourceName = "StringToKeyValues") { throw new NotImplementedException(); }

		/**
		 * Sets whether or not the KeyValues parser will read escape sequences.
		 * For example, \n would be read as a literal newline.  This defaults
		 * to false for new KeyValues structures.
		 *
		 * @param kv            KeyValues Handle.
		 * @param useEscapes    Whether or not to read escape sequences.
		 * @error               Invalid Handle.
		 */
		public static void KvSetEscapeSequences(Handle kv, bool useEscapes) { throw new NotImplementedException(); }

		/**
		 * Returns the position in the jump stack; I.e. the number of calls
		 * required for KvGoBack to return to the root node.  If at the root node,
		 * 0 is returned.
		 *
		 * @param kv            KeyValues Handle.
		 * @return              Number of non-root nodes in the jump stack.
		 * @error               Invalid Handle.
		 */
		public static int KvNodesInStack(Handle kv) { throw new NotImplementedException(); }

		/**
		 * Makes a new copy of all subkeys in the origin KeyValues to
		 * the destination KeyValues.
		 * NOTE: All KeyValues are processed from the current location not the root one.
		 *
		 * @param origin        Origin KeyValues Handle.
		 * @param dest          Destination KeyValues Handle.
		 * @error               Invalid Handle.
		 */
		public static void KvCopySubkeys(Handle origin, Handle dest) { throw new NotImplementedException(); }

		/**
		 * Finds a KeyValues name by id.
		 *
		 * @param kv            KeyValues Handle.
		 * @param id            KeyValues id.
		 * @param name          Buffer to store the name.
		 * @param maxlength     Maximum length of the value buffer.
		 * @return              True on success, false if id not found.
		 * @error               Invalid Handle.
		 */
		public static bool KvFindKeyById(Handle kv, int id, string name, int maxlength) { throw new NotImplementedException(); }

		/**
		 * Finds a KeyValues id inside a KeyValues tree.
		 *
		 * @param kv            KeyValues Handle.
		 * @param key           Key name.
		 * @param id            Id of the found KeyValue.
		 * @return              True on success, false if key not found.
		 * @error               Invalid Handle.
		 */
		public static bool KvGetNameSymbol(Handle kv, string key, ref int id) { throw new NotImplementedException(); }

		/**
		 * Retrieves the current section id.
		 *
		 * @param kv            KeyValues Handle.
		 * @param id            Id of the current section.
		 * @return              True on success, false on failure.
		 * @error               Invalid Handle.
		 */
		public static bool KvGetSectionSymbol(Handle kv, ref int id) { throw new NotImplementedException(); }
	}
}
