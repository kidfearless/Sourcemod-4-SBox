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

using System;
using System.Collections.ObjectModel;
namespace Sourcemod
{
	public partial class SourceMod
	{

		/**
		 * @global All paths in SourceMod natives are relative to the mod folder
		 * unless otherwise noted.
		 *
		 * Most functions in SourceMod (at least, ones that deal with direct
		 * file manipulation) will support an alternate path specification.
		 *
		 * If the path starts with the string "file://" and the PathType is
		 * not relative, then the "file://" portion is stripped off, and the
		 * rest of the path is used without any modification (except for
		 * correcting slashes).  This can be used to override the path
		 * builder to supply alternate absolute paths.  Examples:
		 *
		 * file://C:/Temp/file.txt
		 * file:///tmp/file.txt
		 */

		/**
		 * File inode types.
		 */
		public enum FileType
		{
			FileType_Unknown = 0,   /* Unknown file type (device/socket) */
			FileType_Directory = 1, /* File is a directory */
			FileType_File = 2       /* File is a file */
		};

		/**
		 * File time modes.
		 */
		public enum FileTimeMode
		{
			FileTime_LastAccess = 0,    /* Last access (does not work on FAT) */
			FileTime_Created = 1,       /* Creation (does not work on FAT) */
			FileTime_LastChange = 2     /* Last modification */
		};

		public const int PLATFORM_MAX_PATH = 256;   /**< Maximum path length. */

		public const int SEEK_SET = 0;             /**< Seek from start. */
		public const int SEEK_CUR = 1;             /**< Seek from current position. */
		public const int SEEK_END = 2;             /**< Seek from end position. */

		/**
		 * Path types.
		 */
		public enum PathType
		{
			Path_SM,                    /**< SourceMod root folder */
		};

		// A DirectoryListing iterates over the contents of a directory. To obtain a
		// DirectoryListing handle, call OpenDirectory().
		public class DirectoryListing : Handle
		{
			// Reads the current directory entry as a local filename, then moves to the
			// next file.
			//
			// Note: Both the '.' and '..' automatic directory entries will be retrieved.
			//
			// @param buffer          String buffer to hold directory name.
			// @param maxlength       Maximum size of string buffer.
			// @param type            Optional variable to store the file type.
			// @return                True on success, false if there are no more files to read.
			public bool GetNext(string buffer, int maxlength, out FileType type) { throw new NotImplementedException(); }

			// Reads the current directory entry as a local filename, then moves to the
			// next file.
			//
			// Note: Both the '.' and '..' automatic directory entries will be retrieved.
			//
			// @param buffer          String buffer to hold directory name.
			// @param maxlength       Maximum size of string buffer.
			// @param type            Optional variable to store the file type.
			// @return                True on success, false if there are no more files to read.
			public bool GetNext(string buffer, int maxlength) { throw new NotImplementedException(); }
		};

		// A File object can be obtained by calling OpenFile(). File objects should be
		// closed with delete or Close(). Note that, "delete file" does not
		// actually delete the file, it just closes the handle.
		public class File : Handle
		{
			// Close the file handle. This is the same as using CloseHandle() or delete.
			public void Close()
			{
				CloseHandle(this) { throw new NotImplementedException(); }
			}

			// Reads a line of text from a file.
			//
			// @param buffer          String buffer to hold the line.
			// @param maxlength       Maximum size of string buffer.
			// @return                True on success, false otherwise.
			public bool ReadLine(string buffer, int maxlength) { throw new NotImplementedException(); }

			// Reads binary data from a file.
			//
			// @param items           Array to store each item read.
			// @param num_items       Number of items to read into the array.
			// @param size            Size of each element, in bytes, to be read.
			//                        Valid sizes are 1, 2, or 4.
			// @return                Number of elements read, or -1 on error.
			public int Read(any[] items, int num_items, int size) { throw new NotImplementedException(); }

			// Reads a UTF8 or ANSI string from a file.
			//
			// @param buffer          Buffer to store the string.
			// @param max_size        Maximum size of the string buffer.
			// @param read_count      If -1, reads until a null terminator is encountered in
			//                        the file.  Otherwise, read_count bytes are read
			//                        into the buffer provided.  In this case the buffer
			//                        is not explicitly null terminated, and the buffer
			//                        will contain any null terminators read from the file.
			// @return                Number of characters written to the buffer, or -1
			//                        if an error was encountered.
			// @error                 read_count > max_size.
			public int ReadString(string buffer, int max_size, int read_count = -1) { throw new NotImplementedException(); }

			// Writes binary data to a file.
			//
			// @param items           Array of items to write.  The data is read directly.
			//                        That is, in 1 or 2-byte mode, the lower byte(s) in
			//                        each cell are used directly, rather than performing
			//                        any casts from a 4-byte number to a smaller number.
			// @param num_items       Number of items in the array.
			// @param size            Size of each item in the array in bytes.
			//                        Valid sizes are 1, 2, or 4.
			// @return                True on success, false on error.
			public bool Write(any[] items, int num_items, int size)
			{
				throw new NotImplementedException();
			}

			// Writes a binary string to a file.
			//
			// @param buffer          String to write.
			// @param term            True to append NUL terminator, false otherwise.
			// @return                True on success, false on error.
			public bool WriteString(string buffer, bool term) { throw new NotImplementedException(); }

			// Writes a line of text to a text file.  A newline is automatically appended.
			//
			// @param hndl            Handle to the file.
			// @param format          Formatting rules.
			// @param ...             Variable number of format parameters.
			// @return                True on success, false otherwise.
			public bool WriteLine(string format, params any[] args) { throw new NotImplementedException(); }

			// Reads a single int8 (byte) from a file. The returned value is sign-
			// extended to an int32.
			//
			// @param data            Variable to store the data read.
			// @return                True on success, false on failure.
			public bool ReadInt8(out int data) { throw new NotImplementedException(); }

			// Reads a single uint8 (unsigned byte) from a file. The returned value is
			// zero-extended to an int32.
			//
			// @param data            Variable to store the data read.
			// @return                True on success, false on failure.
			public bool ReadUint8(out int data) { throw new NotImplementedException(); }

			// Reads a single int16 (short) from a file. The value is sign-extended to
			// an int32.
			//
			// @param data            Variable to store the data read.
			// @return                True on success, false on failure.
			public bool ReadInt16(out int data) { throw new NotImplementedException(); }

			// Reads a single unt16 (unsigned short) from a file. The value is zero-
			// extended to an int32.
			//
			// @param data            Variable to store the data read.
			// @return                True on success, false on failure.
			public bool ReadUint16(out int data) { throw new NotImplementedException(); }

			// Reads a single int32 (int/cell) from a file.
			//
			// @param data            Variable to store the data read.
			// @return                True on success, false on failure.
			public bool ReadInt32(out int data) { throw new NotImplementedException(); }

			// Writes a single int8 (byte) to a file.
			//
			// @param data            Data to write (truncated to an int8).
			// @return                True on success, false on failure.
			public bool WriteInt8(int data) { throw new NotImplementedException(); }

			// Writes a single int16 (short) to a file.
			//
			// @param data            Data to write (truncated to an int16).
			// @return                True on success, false on failure.
			public bool WriteInt16(int data) { throw new NotImplementedException(); }

			// Writes a single int32 (int/cell) to a file.
			//
			// @param data            Data to write.
			// @return                True on success, false on failure.
			public bool WriteInt32(int data) { throw new NotImplementedException(); }

			// Tests if the end of file has been reached.
			//
			// @return                True if end of file has been reached, false otherwise.
			public bool EndOfFile() { throw new NotImplementedException(); }

			// Sets the file position indicator.
			//
			// @param position        Position relative to what is specified in whence.
			// @param where           SEEK_ constant value of where to see from.
			// @return                True on success, false otherwise.
			public bool Seek(int position, int where) { throw new NotImplementedException(); }

			// Flushes a file's buffered output; any buffered output
			// is immediately written to the file.
			// 
			// @return              True on success or use_valve_fs specified with OpenFile,
			//                      otherwise false on failure.
			public bool Flush() { throw new NotImplementedException(); }

			// Get the current position in the file; returns -1 on failure.
			public int Position
			{
				get { throw new NotImplementedException(); }
			}
		}

		/**
		 * Builds a path relative to the SourceMod folder.  This should be used instead of
		 * directly referencing addons/sourcemod, in case users change the name of their
		 * folder layout.
		 *
		 * @param type          Type of path to build as the base.
		 * @param buffer        Buffer to store the path.
		 * @param maxlength     Maximum length of buffer.
		 * @param fmt           Format string.
		 * @param ...           Format arguments.
		 * @return              Number of bytes written to buffer (not including null terminator).
		 */
		public static int BuildPath(PathType type, string buffer, int maxlength, string fmt, params any[] args) { throw new NotImplementedException(); }

		/**
		 * Opens a directory/folder for contents public enumeration.
		 *
		 * @note Directories are closed with CloseHandle() or delete.
		 * @note Directories Handles can be cloned.
		 * @note OpenDirectory() supports the "file://" notation.
		 *
		 * @param path          Path to open.
		 * @param use_valve_fs  If true, the Valve file system will be used instead.
		 *                      This can be used to find files existing in any of
		 *                      the Valve search paths, rather than solely files
		 *                      existing directly in the gamedir.
		 * @param valve_path_id If use_valve_fs, a search path from gameinfo or NULL_STRING for all search paths.
		 * @return              A Handle to the directory, null on error.
		 */
		public static DirectoryListing OpenDirectory(string path, bool use_valve_fs = false, string valve_path_id = "GAME") { throw new NotImplementedException(); }

		/**
		 * Reads the current directory entry as a local filename, then moves to the next file.
		 *
		 * @note Contents of buffers are undefined when returning false.
		 * @note Both the '.' and '..' automatic directory entries will be retrieved for Windows and Linux.
		 *
		 * @param dir           Handle to a directory.
		 * @param buffer        String buffer to hold directory name.
		 * @param maxlength     Maximum size of string buffer.
		 * @param type          Optional variable to store the file type.
		 * @return              True on success, false if there are no more files to read.
		 * @error               Invalid or corrupt Handle.
		 */
		public static bool ReadDirEntry(Handle dir, string buffer, int maxlength, out FileType type) { throw new NotImplementedException(); }

		/**
		 * Reads the current directory entry as a local filename, then moves to the next file.
		 *
		 * @note Contents of buffers are undefined when returning false.
		 * @note Both the '.' and '..' automatic directory entries will be retrieved for Windows and Linux.
		 *
		 * @param dir           Handle to a directory.
		 * @param buffer        String buffer to hold directory name.
		 * @param maxlength     Maximum size of string buffer.
		 * @param type          Optional variable to store the file type.
		 * @return              True on success, false if there are no more files to read.
		 * @error               Invalid or corrupt Handle.
		 */
		public static bool ReadDirEntry(Handle dir, string buffer, int maxlength) { throw new NotImplementedException(); }

		/**
		 * Opens or creates a file, returning a File handle on success. File handles
		 * should be closed with delete or CloseHandle().
		 *
		 * The open mode may be one of the following strings:
		 *   "r": Open an existing file for reading.
		 *   "w": Create a file for writing, or truncate (delete the contents of) an
		 *        existing file and then open it for writing.
		 *   "a": Create a file for writing, or open an existing file such that writes
		 *        will be appended to the end.
		 *   "r+": Open an existing file for both reading and writing.
		 *   "w+": Create a file for reading and writing, or truncate an existing file
		 *         and then open it for reading and writing.
		 *   "a+": Create a file for both reading and writing, or open an existing file
		 *         such that writes will be appended to the end.
		 *
		 * The open mode may also contain an additional character after "r", "w", or "a",
		 * but before any "+" sign. This character may be "b" (indicating binary mode) or
		 * "t" (indicating text mode). By default, "text" mode is implied. On Linux and
		 * Mac, this has no distinction from binary mode. On Windows, it causes the '\n'
		 * character (0xA) to be written as "\r\n" (0xD, 0xA).
		 *
		 * Example: "rb" opens a binary file for reading; "at" opens a text file for
		 * appending.
		 *
		 * @param file          File to open.
		 * @param mode          Open mode.
		 * @param use_valve_fs  If true, the Valve file system will be used instead.
		 *                      This can be used to find files existing in valve
		 *                      search paths, rather than solely files existing directly
		 *                      in the gamedir.
		 * @param valve_path_id If use_valve_fs, a search path from gameinfo or NULL_STRING for all search paths.
		 * @return              A File handle, or null if the file could not be opened.
		 */
		public static File OpenFile(string file, string mode, bool use_valve_fs = false, string valve_path_id = "GAME") { throw new NotImplementedException(); }

		/**
		 * Deletes a file.
		 *
		 * @param path          Path of the file to delete.
		 * @param use_valve_fs  If true, the Valve file system will be used instead.
		 *                      This can be used to delete files existing in the Valve
		 *                      search path, rather than solely files existing directly
		 *                      in the gamedir.
		 * @param valve_path_id If use_valve_fs, a search path from gameinfo or NULL_STRING for all search paths.
		 * @return              True on success, false on failure or if file not immediately removed.
		 */
		public static bool DeleteFile(string path, bool use_valve_fs = false, string valve_path_id = "DEFAULT_WRITE_PATH") { throw new NotImplementedException(); }

		/**
		 * Reads a line from a text file.
		 *
		 * @param hndl          Handle to the file.
		 * @param buffer        String buffer to hold the line.
		 * @param maxlength     Maximum size of string buffer.
		 * @return              True on success, false otherwise.
		 */
		public static bool ReadFileLine(Handle hndl, string buffer, int maxlength) { throw new NotImplementedException(); }

		/**
		 * Reads binary data from a file.
		 *
		 * @param hndl          Handle to the file.
		 * @param items         Array to store each item read.
		 * @param num_items     Number of items to read into the array.
		 * @param size          Size of each element, in bytes, to be read.
		 *                      Valid sizes are 1, 2, or 4.
		 * @return              Number of elements read, or -1 on error.
		 */
		public static int ReadFile(Handle hndl, any[] items, int num_items, int size) { throw new NotImplementedException(); }

		/**
		 * Reads binary data from a file.
		 *
		 * @param hndl          Handle to the file.
		 * @param items         Array to store each item read.
		 * @param num_items     Number of items to read into the array.
		 * @param size          Size of each element, in bytes, to be read.
		 *                      Valid sizes are 1, 2, or 4.
		 * @return              Number of elements read, or -1 on error.
		 */
		public static int ReadFile(Handle hndl, float[] items, int num_items, int size) { throw new NotImplementedException(); }


		/**
		 * Reads binary data from a file.
		 *
		 * @param hndl          Handle to the file.
		 * @param items         Array to store each item read.
		 * @param num_items     Number of items to read into the array.
		 * @param size          Size of each element, in bytes, to be read.
		 *                      Valid sizes are 1, 2, or 4.
		 * @return              Number of elements read, or -1 on error.
		 */
		public static int ReadFile(Handle hndl, int[] items, int num_items, int size) { throw new NotImplementedException(); }

		/**
		 * Reads a UTF8 or ANSI string from a file.
		 *
		 * @param hndl          Handle to the file.
		 * @param buffer        Buffer to store the string.
		 * @param max_size      Maximum size of the string buffer.
		 * @param read_count    If -1, reads until a null terminator is encountered in
		 *                      the file.  Otherwise, read_count bytes are read
		 *                      into the buffer provided.  In this case the buffer
		 *                      is not explicitly null terminated, and the buffer
		 *                      will contain any null terminators read from the file.
		 * @return              Number of characters written to the buffer, or -1
		 *                      if an error was encountered.
		 * @error               Invalid Handle, or read_count > max_size.
		 */
		public static int ReadFileString(Handle hndl, string buffer, int max_size, int read_count = -1) { throw new NotImplementedException(); }

		/**
		 * Writes binary data to a file.
		 *
		 * @param hndl          Handle to the file.
		 * @param items         Array of items to write.  The data is read directly.
		 *                      That is, in 1 or 2-byte mode, the lower byte(s) in
		 *                      each cell are used directly, rather than performing
		 *                      any casts from a 4-byte number to a smaller number.
		 * @param num_items     Number of items in the array.
		 * @param size          Size of each item in the array in bytes.
		 *                      Valid sizes are 1, 2, or 4.
		 * @return              True on success, false on error.
		 * @error               Invalid Handle.
		 */
		public static bool WriteFile(Handle hndl, any[] items, int num_items, int size) { throw new NotImplementedException(); }


		/**
		 * Writes binary data to a file.
		 *
		 * @param hndl          Handle to the file.
		 * @param items         Array of items to write.  The data is read directly.
		 *                      That is, in 1 or 2-byte mode, the lower byte(s) in
		 *                      each cell are used directly, rather than performing
		 *                      any casts from a 4-byte number to a smaller number.
		 * @param num_items     Number of items in the array.
		 * @param size          Size of each item in the array in bytes.
		 *                      Valid sizes are 1, 2, or 4.
		 * @return              True on success, false on error.
		 * @error               Invalid Handle.
		 */
		public static bool WriteFile(Handle hndl, int[] items, int num_items, int size) { throw new NotImplementedException(); }

		/**
		 * Writes binary data to a file.
		 *
		 * @param hndl          Handle to the file.
		 * @param items         Array of items to write.  The data is read directly.
		 *                      That is, in 1 or 2-byte mode, the lower byte(s) in
		 *                      each cell are used directly, rather than performing
		 *                      any casts from a 4-byte number to a smaller number.
		 * @param num_items     Number of items in the array.
		 * @param size          Size of each item in the array in bytes.
		 *                      Valid sizes are 1, 2, or 4.
		 * @return              True on success, false on error.
		 * @error               Invalid Handle.
		 */
		public static bool WriteFile(Handle hndl, float[] items, int num_items, int size) { throw new NotImplementedException(); }

		/**
		 * Writes a binary string to a file.
		 *
		 * @param hndl          Handle to the file.
		 * @param buffer        String to write.
		 * @param term          True to append NUL terminator, false otherwise.
		 * @return              True on success, false on error.
		 * @error               Invalid Handle.
		 */
		public static bool WriteFileString(Handle hndl, string buffer, bool term) { throw new NotImplementedException(); }

		/**
		 * Writes a line of text to a text file.  A newline is automatically appended.
		 *
		 * @param hndl          Handle to the file.
		 * @param format        Formatting rules.
		 * @param ...           Variable number of format parameters.
		 * @return              True on success, false otherwise.
		 * @error               Invalid Handle.
		 */
		public static bool WriteFileLine(Handle hndl, string format, params any[] args) { throw new NotImplementedException(); }

		/**
		 * Reads a single binary cell from a file.
		 *
		 * @param hndl          Handle to the file.
		 * @param data          Variable to store the data read.
		 * @param size          Size of the data to read in bytes.  Valid
		 *                      sizes are 1, 2, or 4 bytes.
		 * @return              Number of elements read (max 1), or -1 on error.
		 * @error               Invalid Handle.
		 */
		public static int ReadFileCell(Handle hndl, out int data, int size)
		{
			int ret;
			int[] array = new int[1];
			data = 0;
			if ((ret = ReadFile(hndl, array, 1, size)) == 1)
			{
				data = array[0];
			}

			return ret;
		}

		/**
		 * Writes a single binary cell to a file.
		 *
		 * @param hndl          Handle to the file.
		 * @param data          Cell to write to the file.
		 * @param size          Size of the data to read in bytes.  Valid
		 *                      sizes are 1, 2, or 4 bytes.  If the size
		 *                      is less than 4 bytes, the data is truncated
		 *                      rather than casted.  That is, only the lower
		 *                      bits will be read.
		 * @return              True on success, false on error.
		 * @error               Invalid Handle.
		 */
		public static bool WriteFileCell(Handle hndl, int data, int size)
		{
			int[] array = new int[1];
			array[0] = data;

			return WriteFile(hndl, (int[])array.Clone(), 1, size) { throw new NotImplementedException(); }
		}

		/**
		 * Tests if the end of file has been reached.
		 *
		 * @param file          Handle to the file.
		 * @return              True if end of file has been reached, false otherwise.
		 * @error               Invalid Handle.
		 */
		public static bool IsEndOfFile(Handle file) { throw new NotImplementedException(); }

		/**
		 * Sets the file position indicator.
		 *
		 * @param file          Handle to the file.
		 * @param position      Position relative to what is specified in whence.
		 * @param where         SEEK_ constant value of where to see from.
		 * @return              True on success, false otherwise.
		 * @error               Invalid Handle.
		 */
		public static bool FileSeek(Handle file, int position, int where) { throw new NotImplementedException(); }

		/**
		 * Get current position in the file.
		 *
		 * @param file          Handle to the file.
		 * @return              Value for the file position indicator.
		 * @error               Invalid Handle.
		 */
		public static int FilePosition(Handle file) { throw new NotImplementedException(); }

		/**
		 * Checks if a file exists.
		 *
		 * @param path          Path to the file.
		 * @param use_valve_fs  If true, the Valve file system will be used instead.
		 *                      This can be used to find files existing in any of
		 *                      the Valve search paths, rather than solely files
		 *                      existing directly in the gamedir.
		 * @param valve_path_id If use_valve_fs, a search path from gameinfo or NULL_STRING for all search paths.
		 * @return              True if the file exists, false otherwise.
		 */
		public static bool FileExists(string path, bool use_valve_fs = false, string valve_path_id = "GAME") { throw new NotImplementedException(); }

		/**
		 * Renames a file.
		 *
		 * @param newpath       New path to the file.
		 * @param oldpath       Path to the existing file.
		 * @param use_valve_fs  If true, the Valve file system will be used instead.
		 *                      This can be used to rename files in the game's
		 *                      Valve search paths, rather than directly in the gamedir.
		 * @param valve_path_id If use_valve_fs, a search path from gameinfo or NULL_STRING for all search paths.
		 * @return              True on success or use_valve_fs specified, false otherwise.
		 */
		public static bool RenameFile(string newpath, string oldpath, bool use_valve_fs = false, string valve_path_id = "DEFAULT_WRITE_PATH") { throw new NotImplementedException(); }

		/**
		 * Checks if a directory exists.
		 *
		 * @param path          Path to the directory.
		 * @param use_valve_fs  If true, the Valve file system will be used instead.
		 *                      This can be used to find files existing in any of
		 *                      the Valve search paths, rather than solely files
		 *                      existing directly in the gamedir.
		 * @param valve_path_id If use_valve_fs, a search path from gameinfo or NULL_STRING for all search paths.
		 * @return              True if the directory exists, false otherwise.
		 */
		public static bool DirExists(string path, bool use_valve_fs = false, string valve_path_id = "GAME") { throw new NotImplementedException(); }

		/**
		 * Get the file size in bytes.
		 *
		 * @param path          Path to the file.
		 * @param use_valve_fs  If true, the Valve file system will be used instead.
		 *                      This can be used to find files existing in any of
		 *                      the Valve search paths, rather than solely files
		 *                      existing directly in the gamedir.
		 * @param valve_path_id If use_valve_fs, a search path from gameinfo or NULL_STRING for all search paths.
		 * @return              File size in bytes, -1 if file not found.
		 */
		public static int FileSize(string path, bool use_valve_fs = false, string valve_path_id = "GAME") { throw new NotImplementedException(); }

		/**
		 * Flushes a file's buffered output; any buffered output
		 * is immediately written to the file.
		 *
		 * @param file          Handle to the file.
		 * @return              True on success or use_valve_fs specified with OpenFile,
		 *                      otherwise false on failure.
		 */
		public static bool FlushFile(Handle file) { throw new NotImplementedException(); }

		/**
		 * Removes a directory.
		 * @note On most Operating Systems you cannot remove a directory which has files inside it.
		 *
		 * @param path          Path to the directory.
		 * @return              True on success, false otherwise.
		 */
		public static bool RemoveDir(string path) { throw new NotImplementedException(); }

		public const int FPERM_U_READ = 0x0100;  /* User can read. */
		public const int FPERM_U_WRITE = 0x0080; /* User can write. */
		public const int FPERM_U_EXEC = 0x0040; /* User can exec. */
		public const int FPERM_G_READ = 0x0020; /* Group can read. */
		public const int FPERM_G_WRITE = 0x0010; /* Group can write. */
		public const int FPERM_G_EXEC = 0x0008; /* Group can exec. */
		public const int FPERM_O_READ = 0x0004; /* Anyone can read. */
		public const int FPERM_O_WRITE = 0x0002; /* Anyone can write. */
		public const int FPERM_O_EXEC = 0x0001; /* Anyone can exec. */

		/**
		 * Creates a directory.
		 *
		 * @param path          Path to create.
		 * @param mode          Permissions (default is o=rx,g=rx,u=rwx).  Note that folders must have
		 *                      the execute bit set on Linux.  On Windows, the mode is ignored.
		 * @param use_valve_fs  If true, the Valve file system will be used instead.
		 *                      This can be used to create folders in the game's
		 *                      Valve search paths, rather than directly in the gamedir.
		 * @param valve_path_id If use_valve_fs, a search path from gameinfo or NULL_STRING for default.
		 *                      In this case, mode is ignored.
		 * @return              True on success, false otherwise.
		 */
		public static bool CreateDirectory(string path, int mode, bool use_valve_fs = false, string valve_path_id = "DEFAULT_WRITE_PATH") { throw new NotImplementedException(); }

		/**
		 * Changes a file or directories permissions.
		 *
		 * @param path          Path to the file.
		 * @param mode          Permissions to set.
		 * @return              True on success, false otherwise.
		 */
		public static bool SetFilePermissions(string path, int mode) { throw new NotImplementedException(); }

		/**
		 * Returns a file timestamp as a unix timestamp.
		 *
		 * @param file          File name.
		 * @param tmode         Time mode.
		 * @return              Time value, or -1 on failure.
		 */
		public static int GetFileTime(string file, FileTimeMode tmode) { throw new NotImplementedException(); }

		/**
		 * Same as LogToFile(), except uses an open file Handle.  The file must
		 * be opened in text appending mode.
		 *
		 * @param hndl          Handle to the file.
		 * @param message       Message format.
		 * @param ...           Message format parameters.
		 * @error               Invalid Handle.
		 */
		public static void LogToOpenFile(Handle hndl, string message, params any[] args) { throw new NotImplementedException(); }

		/**
		 * Same as LogToFileEx(), except uses an open file Handle.  The file must
		 * be opened in text appending mode.
		 *
		 * @param hndl          Handle to the file.
		 * @param message       Message format.
		 * @param ...           Message format parameters.
		 * @error               Invalid Handle.
		 */
		public static void LogToOpenFileEx(Handle hndl, string message, params any[] args) { throw new NotImplementedException(); }
	}
}