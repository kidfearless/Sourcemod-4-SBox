/**
 * vim: set ts=4 :
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

// due to the fact that c# doesn't have an all encompassing function pointer class, we are going to use dynamic and figure it out at runtime.

using System;
using System.Collections.ObjectModel;
namespace Sourcemod
{
	public partial class SourceMod
	{
		public const dynamic INVALID_FUNCTION = null;
		public const int SP_PARAMFLAG_BYREF = (1 << 0);  /**< Internal use only. */

		/**
		 * Describes the various ways to pass parameters to functions or forwards.
		 */
		public enum ParamType
		{
			Param_Any = 0,                            /**< Any data type can be pushed */
			Param_Cell = (1 << 1),                       /**< Only basic cells can be pushed */
			Param_Float = (2 << 1),                       /**< Only floats can be pushed */
			Param_String = (3 << 1) | SP_PARAMFLAG_BYREF,    /**< Only strings can be pushed */
			Param_Array = (4 << 1) | SP_PARAMFLAG_BYREF,    /**< Only arrays can be pushed */
			Param_VarArgs = (5 << 1),                       /**< Same as "..." in plugins, anything can be pushed, but it will always be byref */
			Param_CellByRef = (1 << 1) | SP_PARAMFLAG_BYREF,    /**< Only a cell by reference can be pushed */
			Param_FloatByRef = (2 << 1) | SP_PARAMFLAG_BYREF     /**< Only a float by reference can be pushed */
		};
		public const int 
			Param_Any = 0,                            /**< Any data type can be pushed */
			Param_Cell = (1 << 1),                       /**< Only basic cells can be pushed */
			Param_Float = (2 << 1),                       /**< Only floats can be pushed */
			Param_String = (3 << 1) | SP_PARAMFLAG_BYREF,    /**< Only strings can be pushed */
			Param_Array = (4 << 1) | SP_PARAMFLAG_BYREF,    /**< Only arrays can be pushed */
			Param_VarArgs = (5 << 1),                       /**< Same as "..." in plugins, anything can be pushed, but it will always be byref */
			Param_CellByRef = (1 << 1) | SP_PARAMFLAG_BYREF,    /**< Only a cell by reference can be pushed */
			Param_FloatByRef = (2 << 1) | SP_PARAMFLAG_BYREF;     /**< Only a float by reference can be pushed */

		/**
		 * Defines how a Forward iterates through plugin functions.
		 */
		public enum ExecType
		{
			ET_Ignore = 0,    /**< Ignore all return values, return 0 */
			ET_Single = 1,    /**< Only return the last exec, ignore all others */
			ET_Event = 2,    /**< Acts as an event with the Actions defined in core.inc, no mid-Stops allowed, returns highest */
			ET_Hook = 3     /**< Acts as a hook with the Actions defined in core.inc, mid-Stops allowed, returns highest */
		};
		public const int 
			ET_Ignore = 0,    /**< Ignore all return values, return 0 */
			ET_Single = 1,    /**< Only return the last exec, ignore all others */
			ET_Event = 2,    /**< Acts as an event with the Actions defined in core.inc, no mid-Stops allowed, returns highest */
			ET_Hook = 3;     /**< Acts as a hook with the Actions defined in core.inc, mid-Stops allowed, returns highest */

		/**
		 * @section Flags that are used with Call_PushArrayEx() and Call_PushStringEx()
		 */

		public const int SM_PARAM_COPYBACK = (1 << 0);  /**< Copy an array/reference back after call */

		public const int SM_PARAM_STRING_UTF8 = (1 << 0);   /**< String should be UTF-8 handled */
		public const int SM_PARAM_STRING_COPY = (1 << 1);    /**< String should be copied into the plugin */
		public const int SM_PARAM_STRING_BINARY = (1 << 2);    /**< Treat the string as a binary string */

		/**
		 * @endsection
		 */

		/**
		 * @section Error codes
		 */
		public const int SP_ERROR_NONE = 0;  /**< No error occurred */
		public const int SP_ERROR_FILE_FORMAT = 1;  /**< File format unrecognized */
		public const int SP_ERROR_DECOMPRESSOR = 2;  /**< A decompressor was not found */
		public const int SP_ERROR_HEAPLOW = 3;  /**< Not enough space left on the heap */
		public const int SP_ERROR_PARAM = 4;  /**< Invalid parameter or parameter type */
		public const int SP_ERROR_INVALID_ADDRESS = 5;  /**< A memory address was not valid */
		public const int SP_ERROR_NOT_FOUND = 6;  /**< The object in question was not found */
		public const int SP_ERROR_INDEX = 7;  /**< Invalid index parameter */
		public const int SP_ERROR_STACKLOW = 8;  /**< Not enough space left on the stack */
		public const int SP_ERROR_NOTDEBUGGING = 9;  /**< Debug mode was not on or debug section not found */
		public const int SP_ERROR_INVALID_INSTRUCTION = 10;  /**< Invalid instruction was encountered */
		public const int SP_ERROR_MEMACCESS = 11;  /**< Invalid memory access */
		public const int SP_ERROR_STACKMIN = 12;  /**< Stack went beyond its minimum value */
		public const int SP_ERROR_HEAPMIN = 13;  /**< Heap went beyond its minimum value */
		public const int SP_ERROR_DIVIDE_BY_ZERO = 14;  /**< Division by zero */
		public const int SP_ERROR_ARRAY_BOUNDS = 15;  /**< Array index is out of bounds */
		public const int SP_ERROR_INSTRUCTION_PARAM = 16;  /**< Instruction had an invalid parameter */
		public const int SP_ERROR_STACKLEAK = 17;  /**< A native leaked an item on the stack */
		public const int SP_ERROR_HEAPLEAK = 18;  /**< A native leaked an item on the heap */
		public const int SP_ERROR_ARRAY_TOO_BIG = 19;  /**< A dynamic array is too big */
		public const int SP_ERROR_TRACKER_BOUNDS = 20;  /**< Tracker stack is out of bounds */
		public const int SP_ERROR_INVALID_NATIVE = 21; /**< Native was pending or invalid */
		public const int SP_ERROR_PARAMS_MAX = 22;  /**< Maximum number of parameters reached */
		public const int SP_ERROR_NATIVE = 23;  /**< Error originates from a native */
		public const int SP_ERROR_NOT_RUNNABLE = 24;  /**< Function or plugin is not runnable */
		public const int SP_ERROR_ABORTED = 25;  /**< Function call was aborted */

		/**
		 * @endsection
		 */

		public class GlobalForward : Handle
		{
			// Creates a global forward.
			//
			// @note The name used to create the Forward is used as its public function in all target plugins.
			// @note This is ideal for global, static forwards that are never changed.
			// @note Global forwards cannot be cloned.
			// @note Use CloseHandle() to destroy these.
			//
			// @param name              Name of public function to use in forward.
			// @param type              Execution type to be used.
			// @param ...               Variable number of parameter types (up to 32).
			// @return                  Handle to new global forward.
			// @error                   More than 32 parameter types passed.
			public GlobalForward(string name, ExecType type, params ParamType[] args) { throw new NotImplementedException(); }

			protected GlobalForward() { throw new NotImplementedException(); }

			// Returns the number of functions in a global or private forward's call list.
			public int FunctionCount
			{
				get { throw new NotImplementedException(); }
			}
		};

		public class PrivateForward : GlobalForward
		{
			// Creates a private forward.
			//
			// @note No functions are automatically added. Use AddToForward() to do this.
			// @note Private forwards can be cloned.
			// @note Use CloseHandle() to destroy these.
			//
			// @param type          Execution type to be used.
			// @param ...           Variable number of parameter types (up to 32).
			// @return              Handle to new private forward.
			// @error               More than 32 parameter types passed.
			public PrivateForward(ExecType type, params ParamType[] args) { throw new NotImplementedException(); }

			// Adds a function to a private forward's call list.
			//
			// @note Cannot be used during an incomplete call.
			//
			// @param plugin        Handle of the plugin that contains the function.
			//                      Pass INVALID_HANDLE to specify the calling plugin.
			// @param func          Function to add to forward.
			// @return              True on success, false otherwise.
			// @error               Invalid or corrupt private Forward handle, invalid or corrupt plugin handle, or invalid function.
			public bool AddFunction(Handle plugin, dynamic func)
			{
				throw new NotImplementedException();
			}

			// Removes a function from a private forward's call list.
			//
			// @note Only removes one instance.
			// @note Functions will be removed automatically if their parent plugin is unloaded.
			//
			// @param plugin        Handle of the plugin that contains the function.
			//                      Pass INVALID_HANDLE to specify the calling plugin.
			// @param func          Function to remove from forward.
			// @return              True on success, false otherwise.
			// @error               Invalid or corrupt private Forward handle, invalid or corrupt plugin handle, or invalid function.
			public bool RemoveFunction(Handle plugin, dynamic func) { throw new NotImplementedException(); }

			// Removes all instances of a plugin from a private forward's call list.
			//
			// @note Functions will be removed automatically if their parent plugin is unloaded.
			//
			// @param plugin        Handle of the plugin to remove instances of.
			//                      Pass INVALID_HANDLE to specify the calling plugin.
			// @return              Number of functions removed from forward.
			// @error               Invalid or corrupt private Forward handle or invalid or corrupt plugin handle.
			public int RemoveAllFunctions(Handle plugin) { throw new NotImplementedException(); }
		};

		/**
		 * Gets a function id from a function name.
		 *
		 * @param plugin        Handle of the plugin that contains the function.
		 *                      Pass INVALID_HANDLE to search in the calling plugin.
		 * @param name          Name of the function.
		 * @return              Function id or INVALID_FUNCTION if not found.
		 * @error               Invalid or corrupt plugin handle.
		 */
		public static dynamic GetFunctionByName(Handle plugin, string name) { throw new NotImplementedException(); }

		/**
		 * Creates a global forward.
		 *
		 * @note The name used to create the Forward is used as its public function in all target plugins.
		 * @note This is ideal for global, static forwards that are never changed.
		 * @note Global forwards cannot be cloned.
		 * @note Use CloseHandle() to destroy these.
		 *
		 * @param name          Name of public function to use in forward.
		 * @param type          Execution type to be used.
		 * @param ...           Variable number of parameter types (up to 32).
		 * @return              Handle to new global forward.
		 * @error               More than 32 parameter types passed.
		 */
		public static GlobalForward CreateGlobalForward(string name, ExecType type, params ParamType[] args) { throw new NotImplementedException(); }

		/**
		 * Creates a private forward.
		 *
		 * @note No functions are automatically added. Use AddToForward() to do this.
		 * @note Private forwards can be cloned.
		 * @note Use CloseHandle() to destroy these.
		 *
		 * @param type          Execution type to be used.
		 * @param ...           Variable number of parameter types (up to 32).
		 * @return              Handle to new private forward.
		 * @error               More than 32 parameter types passed.
		 */
		public static PrivateForward CreateForward(ExecType type, params ParamType[] args) { throw new NotImplementedException(); }

		/**
		 * Returns the number of functions in a global or private forward's call list.
		 *
		 * @param fwd           Handle to global or private forward.
		 * @return              Number of functions in forward.
		 * @error               Invalid or corrupt Forward handle.
		 */
		public static int GetForwardFunctionCount(Handle fwd) { throw new NotImplementedException(); }

		/**
		 * Adds a function to a private forward's call list.
		 *
		 * @note Cannot be used during an incomplete call.
		 *
		 * @param fwd           Handle to private forward.
		 * @param plugin        Handle of the plugin that contains the function.
		 *                      Pass INVALID_HANDLE to specify the calling plugin.
		 * @param func          Function to add to forward.
		 * @return              True on success, false otherwise.
		 * @error               Invalid or corrupt private Forward handle, invalid or corrupt plugin handle, or invalid function.
		 */
		public static bool AddToForward(Handle fwd, Handle plugin, dynamic func) { throw new NotImplementedException(); }

		/**
		 * Removes a function from a private forward's call list.
		 *
		 * @note Only removes one instance.
		 * @note Functions will be removed automatically if their parent plugin is unloaded.
		 *
		 * @param fwd           Handle to private forward.
		 * @param plugin        Handle of the plugin that contains the function.
		 *                      Pass INVALID_HANDLE to specify the calling plugin.
		 * @param func          Function to remove from forward.
		 * @return              True on success, false otherwise.
		 * @error               Invalid or corrupt private Forward handle, invalid or corrupt plugin handle, or invalid function.
		 */
		public static bool RemoveFromForward(Handle fwd, Handle plugin, dynamic func) { throw new NotImplementedException(); }

		/**
		 * Removes all instances of a plugin from a private forward's call list.
		 *
		 * @note Functions will be removed automatically if their parent plugin is unloaded.
		 *
		 * @param fwd           Handle to private forward.
		 * @param plugin        Handle of the plugin to remove instances of.
		 *                      Pass INVALID_HANDLE to specify the calling plugin.
		 * @return              Number of functions removed from forward.
		 * @error               Invalid or corrupt private Forward handle or invalid or corrupt plugin handle.
		 */
		public static int RemoveAllFromForward(Handle fwd, Handle plugin) { throw new NotImplementedException(); }

		/**
		 * Starts a call to functions in a forward's call list.
		 *
		 * @note Cannot be used during an incomplete call.
		 *
		 * @param fwd           Handle to global or private forward.
		 * @error               Invalid or corrupt Forward handle or called before another call has completed.
		 */
		public static void Call_StartForward(Handle fwd) { throw new NotImplementedException(); }

		/**
		 * Starts a call to a function.
		 *
		 * @note Cannot be used during an incomplete call.
		 *
		 * @param plugin        Handle of the plugin that contains the function.
		 *                      Pass INVALID_HANDLE to specify the calling plugin.
		 * @param func          Function to call.
		 * @error               Invalid or corrupt plugin handle, invalid function, or called before another call has completed.
		 */
		public static void Call_StartFunction(Handle plugin, dynamic func) { throw new NotImplementedException(); }

		/**
		 * Pushes a cell onto the current call.
		 *
		 * @note Cannot be used before a call has been started.
		 *
		 * @param value         Cell value to push.
		 * @error               Called before a call has been started.
		 */
		public static void Call_PushCell(any value) { throw new NotImplementedException(); }

		/**
		 * Pushes a cell by reference onto the current call.
		 *
		 * @note Cannot be used before a call has been started.
		 *
		 * @param value         Cell reference to push.
		 * @error               Called before a call has been started.
		 */
		public static void Call_PushCellRef(ref any value) { throw new NotImplementedException(); }

		/**
		 * Pushes a float onto the current call.
		 *
		 * @note Cannot be used before a call has been started.
		 *
		 * @param value         Floating point value to push.
		 * @error               Called before a call has been started.
		 */
		public static void Call_PushFloat(float value) { throw new NotImplementedException(); }

		/**
		 * Pushes a float by reference onto the current call.
		 *
		 * @note Cannot be used before a call has been started.
		 *
		 * @param value         Floating point reference to push.
		 * @error               Called before a call has been started.
		 */
		public static void Call_PushFloatRef(ref float value) { throw new NotImplementedException(); }

		/**
		 * Pushes an array onto the current call.
		 *
		 * @note Changes to array are not copied back to caller. Use PushArrayEx() to do this.
		 * @note Cannot be used before a call has been started.
		 *
		 * @param value         Array to push.
		 * @param size          Size of array.
		 * @error               Called before a call has been started.
		 */
		public static void Call_PushArray(any[] value, int size) { throw new NotImplementedException(); }

		/**
		 * Pushes an array onto the current call.
		 *
		 * @note Cannot be used before a call has been started.
		 *
		 * @param value         Array to push.
		 * @param size          Size of array.
		 * @param cpflags       Whether or not changes should be copied back to the input array.
		 *                      See SP_PARAM_* constants for details.
		 * @error               Called before a call has been started.
		 */
		public static void Call_PushArrayEx(any[] value, int size, int cpflags) { throw new NotImplementedException(); }

		/**
		 * Pushes the NULL_VECTOR onto the current call.
		 * @see IsNullVector
		 *
		 * @note Cannot be used before a call has been started.
		 *
		 * @error               Called before a call has been started.
		 */
		public static void Call_PushNullVector() { throw new NotImplementedException(); }

		/**
		 * Pushes a string onto the current call.
		 *
		 * @note Changes to string are not copied back to caller. Use PushStringEx() to do this.
		 * @note Cannot be used before a call has been started.
		 *
		 * @param value         String to push.
		 * @error               Called before a call has been started.
		 */
		public static void Call_PushString(string value) { throw new NotImplementedException(); }

		/**
		 * Pushes a string onto the current call.
		 *
		 * @note Cannot be used before a call has been started.
		 *
		 * @param value         String to push.
		 * @param length        Length of string buffer.
		 * @param szflags       Flags determining how string should be handled.
		 *                      See SM_PARAM_STRING_* constants for details.
		 *                      The default (0) is to push ASCII.
		 * @param cpflags       Whether or not changes should be copied back to the input array.
		 *                      See SM_PARAM_* constants for details.
		 * @error               Called before a call has been started.
		 */
		public static void Call_PushStringEx(string value, int length, int szflags, int cpflags) { throw new NotImplementedException(); }

		/**
		 * Pushes the NULL_STRING onto the current call.
		 * @see IsNullString
		 *
		 * @note Cannot be used before a call has been started.
		 *
		 * @error               Called before a call has been started.
		 */
		public static void Call_PushNullString() { throw new NotImplementedException(); }

		/**
		 * Completes a call to a function or forward's call list.
		 *
		 * @note Cannot be used before a call has been started.
		 *
		 * @param result        Return value of function or forward's call list.
		 * @return              SP_ERROR_NONE on success, any other integer on failure.
		 * @error               Called before a call has been started.
		 */
		public static int Call_Finish(ref any result) { throw new NotImplementedException(); }
		/**
 * Completes a call to a function or forward's call list.
 *
 * @note Cannot be used before a call has been started.
 *
 * @param result        Return value of function or forward's call list.
 * @return              SP_ERROR_NONE on success, any other integer on failure.
 * @error               Called before a call has been started.
 */
		public static int Call_Finish() { throw new NotImplementedException(); }

		/**
		 * Cancels a call to a function or forward's call list.
		 *
		 * @note Cannot be used before a call has been started.
		 *
		 * @error               Called before a call has been started.
		 */
		public static void Call_Cancel() { throw new NotImplementedException(); }


		/**
		 * Defines a public static function.
		 *
		 * It is not necessary to validate the parameter count
		 *
		 * @param plugin         Handle of the calling plugin.
		 * @param numParams      Number of parameters passed to the native.
		 * @return               Value for the public static call to return.
		 */
		public delegate any NativeCall(Handle plugin, int numParams);

		/**
		 * Creates a dynamic native.  This should only be called in AskPluginLoad(), or
		 * else you risk not having your public static shared with other plugins.
		 *
		 * @param name          Name of the dynamic native; must be unique among
		 *                      all other registered dynamic natives.
		 * @param func          Function to use as the dynamic native.
		 */
		public static void CreateNative(string name, NativeCall func) { throw new NotImplementedException(); }

		/**
		 * Throws an error in the calling plugin of a native, instead of your own plugin.
		 *
		 * @param error         Error code to use.
		 * @param fmt           Error message format.
		 * @param ...           Format arguments.
		 */
		public static int ThrowNativeError(int error, string fmt, params object[] args) { throw new NotImplementedException(); }

		/**
		 * Retrieves the string length from a public static parameter string.  This is useful for
		 * fetching the entire string using dynamic arrays.
		 *
		 * @note If this function succeeds, Get/SetNativeString will also succeed.
		 *
		 * @param param         Parameter number, starting from 1.
		 * @param length        Stores the length of the string.
		 * @return              SP_ERROR_NONE on success, any other integer on failure.
		 * @error               Invalid parameter number or calling from a non-public static function.
		 */
		public static int GetNativeStringLength(int param, out int length) { throw new NotImplementedException(); }

		/**
		 * Retrieves a string from a public static parameter.
		 *
		 * @note Output conditions are undefined on failure.
		 *
		 * @param param         Parameter number, starting from 1.
		 * @param buffer        Buffer to store the string in.
		 * @param maxlength     Maximum length of the buffer.
		 * @param bytes         Optionally store the number of bytes written.
		 * @return              SP_ERROR_NONE on success, any other integer on failure.
		 * @error               Invalid parameter number or calling from a non-public static function.
		 */
		public static int GetNativeString(int param, string buffer, int maxlength) { throw new NotImplementedException(); }


		/**
		 * Retrieves a string from a public static parameter.
		 *
		 * @note Output conditions are undefined on failure.
		 *
		 * @param param         Parameter number, starting from 1.
		 * @param buffer        Buffer to store the string in.
		 * @param maxlength     Maximum length of the buffer.
		 * @param bytes         Optionally store the number of bytes written.
		 * @return              SP_ERROR_NONE on success, any other integer on failure.
		 * @error               Invalid parameter number or calling from a non-public static function.
		 */
		public static int GetNativeString(int param, string buffer, int maxlength, out int bytes) { throw new NotImplementedException(); }

		/**
		 * Sets a string in a public static parameter.
		 *
		 * @note Output conditions are undefined on failure.
		 *
		 * @param param         Parameter number, starting from 1.
		 * @param source        Source string to use.
		 * @param maxlength     Maximum number of bytes to write.
		 * @param utf8          If false, string will not be written
		 *                      with UTF8 safety.
		 * @param bytes         Optionally store the number of bytes written.
		 * @return              SP_ERROR_NONE on success, any other integer on failure.
		 * @error               Invalid parameter number or calling from a non-public static function.
		 */
		public static int SetNativeString(int param, string source, int maxlength, bool utf8, out int bytes) { throw new NotImplementedException(); }


		/**
		 * Sets a string in a public static parameter.
		 *
		 * @note Output conditions are undefined on failure.
		 *
		 * @param param         Parameter number, starting from 1.
		 * @param source        Source string to use.
		 * @param maxlength     Maximum number of bytes to write.
		 * @param utf8          If false, string will not be written
		 *                      with UTF8 safety.
		 * @param bytes         Optionally store the number of bytes written.
		 * @return              SP_ERROR_NONE on success, any other integer on failure.
		 * @error               Invalid parameter number or calling from a non-public static function.
		 */
		public static int SetNativeString(int param, string source, int maxlength, bool utf8 = true) { throw new NotImplementedException(); }

		/**
		 * Gets a cell from a public static parameter.
		 *
		 * @param param         Parameter number, starting from 1.
		 * @return              Cell value at the parameter number.
		 * @error               Invalid parameter number or calling from a non-public static function.
		 */
		public static any GetNativeCell(int param) { throw new NotImplementedException(); }

		/**
		 * Gets a function pointer from a public static parameter.
		 *
		 * @param param             Parameter number, starting from 1.
		 * @return                  Function pointer at the given parameter number.
		 * @error                   Invalid parameter number, or calling from a non-public static function.
		 */
		public static dynamic GetNativeFunction(int param) { throw new NotImplementedException(); }

		/**
		 * Gets a cell from a public static parameter, by reference.
		 *
		 * @param param         Parameter number, starting from 1.
		 * @return              Cell value at the parameter number.
		 * @error               Invalid parameter number or calling from a non-public static function.
		 */
		public static any GetNativeCellRef(int param)
		{ throw new NotImplementedException(); }

		/**
		 * Sets a cell from a public static parameter, by reference.
		 *
		 * @param param         Parameter number, starting from 1.
		 * @param value         Cell value at the parameter number to set by reference.
		 * @error               Invalid parameter number or calling from a non-public static function.
		 */
		public static void SetNativeCellRef(int param, any value) { throw new NotImplementedException(); }

		/**
		 * Gets an array from a public static parameter (always by reference).
		 *
		 * @param param         Parameter number, starting from 1.
		 * @param local         Local array to copy into.
		 * @param size          Maximum size of local array.
		 * @return              SP_ERROR_NONE on success, anything else on failure.
		 * @error               Invalid parameter number or calling from a non-public static function.
		 */
		public static int GetNativeArray(int param, any[] local, int size) { throw new NotImplementedException(); }

		/**
		 * Copies a local array into a public static parameter array (always by reference).
		 *
		 * @param param         Parameter number, starting from 1.
		 * @param local         Local array to copy from.
		 * @param size          Size of the local array to copy.
		 * @return              SP_ERROR_NONE on success, anything else on failure.
		 * @error               Invalid parameter number or calling from a non-public static function.
		 */
		public static int SetNativeArray(int param, any[] local, int size)
		{
			throw new NotImplementedException();
		}

		/**
		 * Check if the public static parameter is the NULL_VECTOR.
		 *
		 * @param param         Parameter number, starting from 1.
		 * @return              True if NULL_VECTOR, false otherwise.
		 */
		public static bool IsNativeParamNullVector(int param) { throw new NotImplementedException(); }

		/**
		 * Check if the public static parameter is the NULL_STRING.
		 *
		 * @param param         Parameter number, starting from 1.
		 * @return              True if NULL_STRING, false otherwise.
		 */
		public static bool IsNativeParamNullString(int param) { throw new NotImplementedException(); }

		/**
		 * Formats a string using parameters from a native.
		 *
		 * @note All parameter indexes start at 1.
		 * @note If the input and output buffers overlap, the contents
		 *       of the output buffer at the end is undefined.
		 *
		 * @param out_param     Output parameter number to write to.  If 0, out_string is used.
		 * @param fmt_param     Format parameter number.  If 0, fmt_string is used.
		 * @param vararg_param  First variable parameter number.
		 * @param out_len       Output string buffer maximum length (always required).
		 * @param written       Optionally stores the number of bytes written.
		 * @param out_string    Output string buffer to use if out_param is not used.
		 * @param fmt_string    Format string to use if fmt_param is not used.
		 * @return              SP_ERROR_NONE on success, anything else on failure.
		 */
		public static int FormatNativeString(int out_param, int fmt_param, int vararg_param, int out_len, out int written, out string out_string, out string fmt_string)
		{ throw new NotImplementedException(); }

		/**
		 * Formats a string using parameters from a native.
		 *
		 * @note All parameter indexes start at 1.
		 * @note If the input and output buffers overlap, the contents
		 *       of the output buffer at the end is undefined.
		 *
		 * @param out_param     Output parameter number to write to.  If 0, out_string is used.
		 * @param fmt_param     Format parameter number.  If 0, fmt_string is used.
		 * @param vararg_param  First variable parameter number.
		 * @param out_len       Output string buffer maximum length (always required).
		 * @param written       Optionally stores the number of bytes written.
		 * @param out_string    Output string buffer to use if out_param is not used.
		 * @param fmt_string    Format string to use if fmt_param is not used.
		 * @return              SP_ERROR_NONE on success, anything else on failure.
		 */
		public static int FormatNativeString(int out_param, int fmt_param, int vararg_param, int out_len, out int written, out string out_string)
		{ throw new NotImplementedException(); }

		/**
		 * Formats a string using parameters from a native.
		 *
		 * @note All parameter indexes start at 1.
		 * @note If the input and output buffers overlap, the contents
		 *       of the output buffer at the end is undefined.
		 *
		 * @param out_param     Output parameter number to write to.  If 0, out_string is used.
		 * @param fmt_param     Format parameter number.  If 0, fmt_string is used.
		 * @param vararg_param  First variable parameter number.
		 * @param out_len       Output string buffer maximum length (always required).
		 * @param written       Optionally stores the number of bytes written.
		 * @param out_string    Output string buffer to use if out_param is not used.
		 * @param fmt_string    Format string to use if fmt_param is not used.
		 * @return              SP_ERROR_NONE on success, anything else on failure.
		 */
		public static int FormatNativeString(int out_param, int fmt_param, int vararg_param, int out_len, out int written)
		{ throw new NotImplementedException(); }

		/**
		 * Formats a string using parameters from a native.
		 *
		 * @note All parameter indexes start at 1.
		 * @note If the input and output buffers overlap, the contents
		 *       of the output buffer at the end is undefined.
		 *
		 * @param out_param     Output parameter number to write to.  If 0, out_string is used.
		 * @param fmt_param     Format parameter number.  If 0, fmt_string is used.
		 * @param vararg_param  First variable parameter number.
		 * @param out_len       Output string buffer maximum length (always required).
		 * @param written       Optionally stores the number of bytes written.
		 * @param out_string    Output string buffer to use if out_param is not used.
		 * @param fmt_string    Format string to use if fmt_param is not used.
		 * @return              SP_ERROR_NONE on success, anything else on failure.
		 */
		public static int FormatNativeString(int out_param, int fmt_param, int vararg_param, int out_len)
		{ throw new NotImplementedException(); }
		/**
		 * Defines a RequestFrame Callback.
		 *
		 * @param data          Data passed to the RequestFrame native.
		 */
		public delegate void RequestFrameCallback(any data);

		/**
		 * Creates a single use Next Frame hook.
		 *
		 * @param Function      Function to call on the next frame.
		 * @param data          Value to be passed on the invocation of the Function.
		 */
		public static void RequestFrame(RequestFrameCallback Function, any? data = null) { throw new NotImplementedException(); }
	}
}