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

		public class BfWrite : Handle
		{
			// Writes a single bit to a writable bitbuffer (bf_write).
			//
			// @param bit       Bit to write (true for 1, false for 0).
			public void WriteBool(bool bit) { throw new NotImplementedException(); }

			// Writes a byte to a writable bitbuffer (bf_write).
			//
			// @param byte      Byte to write (value will be written as 8bit).
			public void WriteByte(int Byte) { throw new NotImplementedException(); }

			// Writes a byte to a writable bitbuffer (bf_write).
			//
			// @param chr       Character to write.
			public void WriteChar(int chr) { throw new NotImplementedException(); }

			// Writes a 16bit integer to a writable bitbuffer (bf_write).
			//
			// @param num       Integer to write (value will be written as 16bit).
			public void WriteShort(int num) { throw new NotImplementedException(); }

			// Writes a 16bit unsigned integer to a writable bitbuffer (bf_write).
			//
			// @param num       Integer to write (value will be written as 16bit).
			public void WriteWord(int num) { throw new NotImplementedException(); }

			// Writes a normal integer to a writable bitbuffer (bf_write).
			//
			// @param num       Integer to write (value will be written as 32bit).
			public void Writpublic enum(int num) { throw new NotImplementedException(); }

			// Writes a floating point number to a writable bitbuffer (bf_write).
			//
			// @param num       Number to write.
			public void WriteFloat(float num) { throw new NotImplementedException(); }

			// Writes a string to a writable bitbuffer (bf_write).
			//
			// @param string    Text string to write.
			public void WriteString(string String) { throw new NotImplementedException(); }

			// Writes an entity to a writable bitbuffer (bf_write).
			//
			// @param ent       Entity index to write.
			public void WriteEntity(int ent) { throw new NotImplementedException(); }

			// Writes a bit angle to a writable bitbuffer (bf_write).
			//
			// @param angle     Angle to write.
			// @param numBits   Optional number of bits to use.
			public void WriteAngle(float angle, int numBits = 8) { throw new NotImplementedException(); }

			// Writes a coordinate to a writable bitbuffer (bf_write).
			//
			// @param coord     Coordinate to write.
			public void WriteCoord(float coord) { throw new NotImplementedException(); }

			// Writes a 3D vector of coordinates to a writable bitbuffer (bf_write).
			//
			// @param coord     Coordinate array to write.
			public void WriteVecCoord(float[] coord) { throw new NotImplementedException(); }

			// Writes a 3D normal vector to a writable bitbuffer (bf_write).
			//
			// @param vec       Vector to write.
			public void WriteVecNormal(float[] vec) { throw new NotImplementedException(); }

			// Writes a 3D angle vector to a writable bitbuffer (bf_write).
			//
			// @param angles    Angle vector to write.
			public void WriteAngles(float[] angles) { throw new NotImplementedException(); }
		};

		public class BfRead : Handle
		{
			// Reads a single bit from a readable bitbuffer (bf_read).
			//
			// @return          Bit value read.
			public bool ReadBool() { throw new NotImplementedException(); }

			// Reads a byte from a readable bitbuffer (bf_read).
			//
			// @return          Byte value read (read as 8bit).
			public int ReadByte() { throw new NotImplementedException(); }

			// Reads a character from a readable bitbuffer (bf_read).
			//
			// @return          Character value read.
			public int ReadChar() { throw new NotImplementedException(); }

			// Reads a 16bit integer from a readable bitbuffer (bf_read).
			//
			// @param bf        bf_read handle to read from.
			// @return          Integer value read (read as 16bit).
			public int ReadShort() { throw new NotImplementedException(); }

			// Reads a 16bit unsigned integer from a readable bitbuffer (bf_read).
			//
			// @param bf        bf_read handle to read from.
			// @return          Integer value read (read as 16bit).
			public int ReadWord() { throw new NotImplementedException(); }

			// Reads a normal integer to a readable bitbuffer (bf_read).
			//
			// @return          Integer value read (read as 32bit).
			public int ReadNum() { throw new NotImplementedException(); }

			// Reads a floating point number from a readable bitbuffer (bf_read).
			//
			// @return          Floating point value read.
			public float ReadFloat() { throw new NotImplementedException(); }

			// Reads a string from a readable bitbuffer (bf_read).
			//
			// @param buffer    Destination string buffer.
			// @param maxlength Maximum length of output string buffer.
			// @param line      If true the buffer will be copied until it reaches a '\n' or a null terminator.
			// @return          Number of bytes written to the buffer.  If the bitbuffer stream overflowed, 
			//                  that is, had no terminator before the end of the stream, then a negative 
			//                  number will be returned equal to the number of characters written to the 
			//                  buffer minus 1.  The buffer will be null terminated regardless of the 
			//                  return value.
			public int ReadString(string buffer, int maxlength, bool line = false) { throw new NotImplementedException(); }

			// Reads an entity from a readable bitbuffer (bf_read).
			//
			// @return          Entity index read.
			public int ReadEntity() { throw new NotImplementedException(); }

			// Reads a bit angle from a readable bitbuffer (bf_read).
			//
			// @param numBits   Optional number of bits to use.
			// @return          Angle read.
			public float ReadAngle(int numBits = 8) { throw new NotImplementedException(); }

			// Reads a coordinate from a readable bitbuffer (bf_read).
			//
			// @return          Coordinate read.
			public float ReadCoord() { throw new NotImplementedException(); }

			// Reads a 3D vector of coordinates from a readable bitbuffer (bf_read).
			//
			// @param coord     Destination coordinate array.
			public void ReadVecCoord(float[] coord) { throw new NotImplementedException(); }

			// Reads a 3D normal vector from a readable bitbuffer (bf_read).
			//
			// @param vec       Destination vector array.
			public void ReadVecNormal(float[] vec) { throw new NotImplementedException(); }

			// Reads a 3D angle vector from a readable bitbuffer (bf_read).
			//
			// @param angles    Destination angle vector.
			public void ReadAngles(float[] angles) { throw new NotImplementedException(); }

			// Returns the number of bytes left in a readable bitbuffer (bf_read).
			public int BytesLeft
			{
				get { throw new NotImplementedException(); }
			}
		};

		/** 
		 * Writes a single bit to a writable bitbuffer (bf_write).
		 *
		 * @param bf            bf_write handle to write to.
		 * @param bit           Bit to write (true for 1, false for 0).
		 * @error               Invalid or incorrect Handle.
		 */
		public static void BfWriteBool(Handle bf, bool bit) { throw new NotImplementedException(); }

		/**
		 * Writes a byte to a writable bitbuffer (bf_write).
		 *
		 * @param bf            bf_write handle to write to.
		 * @param byte          Byte to write (value will be written as 8bit).
		 * @error               Invalid or incorrect Handle.
		 */
		public static void BfWriteByte(Handle bf, int Byte) { throw new NotImplementedException(); }

		/**
		 * Writes a byte to a writable bitbuffer (bf_write).
		 *
		 * @param bf            bf_write handle to write to.
		 * @param chr           Character to write.
		 * @error               Invalid or incorrect Handle.
		 */
		public static void BfWriteChar(Handle bf, int chr) { throw new NotImplementedException(); }

		/**
		 * Writes a 16bit integer to a writable bitbuffer (bf_write).
		 *
		 * @param bf            bf_write handle to write to.
		 * @param num           Integer to write (value will be written as 16bit).
		 * @error               Invalid or incorrect Handle.
		 */
		public static void BfWriteShort(Handle bf, int num) { throw new NotImplementedException(); }

		/**
		 * Writes a 16bit unsigned integer to a writable bitbuffer (bf_write).
		 *
		 * @param bf            bf_write handle to write to.
		 * @param num           Integer to write (value will be written as 16bit).
		 * @error               Invalid or incorrect Handle.
		 */
		public static void BfWriteWord(Handle bf, int num) { throw new NotImplementedException(); }

		/**
		 * Writes a normal integer to a writable bitbuffer (bf_write).
		 *
		 * @param bf            bf_write handle to write to.
		 * @param num           Integer to write (value will be written as 32bit).
		 * @error               Invalid or incorrect Handle.
		 */
		public static void BfWritpublic enum(Handle bf, int num) { throw new NotImplementedException(); }

		/**
		 * Writes a floating point number to a writable bitbuffer (bf_write).
		 *
		 * @param bf            bf_write handle to write to.
		 * @param num           Number to write.
		 * @error               Invalid or incorrect Handle.
		 */
		public static void BfWriteFloat(Handle bf, float num) { throw new NotImplementedException(); }

		/**
		 * Writes a string to a writable bitbuffer (bf_write).
		 *
		 * @param bf            bf_write handle to write to.
		 * @param string        Text string to write.
		 * @error               Invalid or incorrect Handle.
		 */
		public static void BfWriteString(Handle bf, string String) { throw new NotImplementedException(); }

		/**
		 * Writes an entity to a writable bitbuffer (bf_write).
		 * @note This is a wrapper around BfWriteShort().
		 *
		 * @param bf            bf_write handle to write to.
		 * @param ent           Entity index to write.
		 * @error               Invalid or incorrect Handle, or invalid entity.
		 */
		public static void BfWriteEntity(Handle bf, int ent) { throw new NotImplementedException(); }

		/**
		 * Writes a bit angle to a writable bitbuffer (bf_write).
		 *
		 * @param bf            bf_write handle to write to.
		 * @param angle         Angle to write.
		 * @param numBits       Optional number of bits to use.
		 * @error               Invalid or incorrect Handle.
		 */
		public static void BfWriteAngle(Handle bf, float angle, int numBits = 8) { throw new NotImplementedException(); }

		/**
		 * Writes a coordinate to a writable bitbuffer (bf_write).
		 *
		 * @param bf            bf_write handle to write to.
		 * @param coord         Coordinate to write.
		 * @error               Invalid or incorrect Handle.
		 */
		public static void BfWriteCoord(Handle bf, float coord) { throw new NotImplementedException(); }

		/**
		 * Writes a 3D vector of coordinates to a writable bitbuffer (bf_write).
		 *
		 * @param bf            bf_write handle to write to.
		 * @param coord         Coordinate array to write.
		 * @error               Invalid or incorrect Handle.
		 */
		public static void BfWriteVecCoord(Handle bf, float[] coord) { throw new NotImplementedException(); }

		/**
		 * Writes a 3D normal vector to a writable bitbuffer (bf_write).
		 *
		 * @param bf            bf_write handle to write to.
		 * @param vec           Vector to write.
		 * @error               Invalid or incorrect Handle.
		 */
		public static void BfWriteVecNormal(Handle bf, float[] vec) { throw new NotImplementedException(); }

		/**
		 * Writes a 3D angle vector to a writable bitbuffer (bf_write).
		 *
		 * @param bf            bf_write handle to write to.
		 * @param angles        Angle vector to write.
		 * @error               Invalid or incorrect Handle.
		 */
		public static void BfWriteAngles(Handle bf, float[] angles) { throw new NotImplementedException(); }

		/** 
		 * Reads a single bit from a readable bitbuffer (bf_read).
		 *
		 * @param bf            bf_read handle to read from.
		 * @return              Bit value read.
		 * @error               Invalid or incorrect Handle.
		 */
		public static bool BfReadBool(Handle bf) { throw new NotImplementedException(); }

		/**
		 * Reads a byte from a readable bitbuffer (bf_read).
		 *
		 * @param bf            bf_read handle to read from.
		 * @return              Byte value read (read as 8bit).
		 * @error               Invalid or incorrect Handle.
		 */
		public static int BfReadByte(Handle bf) { throw new NotImplementedException(); }

		/**
		 * Reads a character from a readable bitbuffer (bf_read).
		 *
		 * @param bf            bf_read handle to read from.
		 * @return              Character value read.
		 * @error               Invalid or incorrect Handle.
		 */
		public static int BfReadChar(Handle bf) { throw new NotImplementedException(); }

		/**
		 * Reads a 16bit integer from a readable bitbuffer (bf_read).
		 *
		 * @param bf            bf_read handle to read from.
		 * @return              Integer value read (read as 16bit).
		 * @error               Invalid or incorrect Handle.
		 */
		public static int BfReadShort(Handle bf) { throw new NotImplementedException(); }

		/**
		 * Reads a 16bit unsigned integer from a readable bitbuffer (bf_read).
		 *
		 * @param bf            bf_read handle to read from.
		 * @return              Integer value read (read as 16bit).
		 * @error               Invalid or incorrect Handle.
		 */
		public static int BfReadWord(Handle bf) { throw new NotImplementedException(); }

		/**
		 * Reads a normal integer to a readable bitbuffer (bf_read).
		 *
		 * @param bf            bf_read handle to read from.
		 * @return              Integer value read (read as 32bit).
		 * @error               Invalid or incorrect Handle.
		 */
		public static int BfReadNum(Handle bf) { throw new NotImplementedException(); }

		/**
		 * Reads a floating point number from a readable bitbuffer (bf_read).
		 *
		 * @param bf            bf_read handle to read from.
		 * @return              Floating point value read.
		 * @error               Invalid or incorrect Handle.
		 */
		public static float BfReadFloat(Handle bf) { throw new NotImplementedException(); }

		/**
		 * Reads a string from a readable bitbuffer (bf_read).
		 *
		 * @param bf            bf_read handle to read from.
		 * @param buffer        Destination string buffer.
		 * @param maxlength     Maximum length of output string buffer.
		 * @param line          If true the buffer will be copied until it reaches a '\n' or a null terminator.
		 * @return              Number of bytes written to the buffer.  If the bitbuffer stream overflowed, 
		 *                      that is, had no terminator before the end of the stream, then a negative 
		 *                      number will be returned equal to the number of characters written to the 
		 *                      buffer minus 1.  The buffer will be null terminated regardless of the 
		 *                      return value.
		 * @error               Invalid or incorrect Handle.
		 */
		public static int BfReadString(Handle bf, string buffer, int maxlength, bool line = false) { throw new NotImplementedException(); }

		/**
		 * Reads an entity from a readable bitbuffer (bf_read).
		 * @note This is a wrapper around BfReadShort().
		 *
		 * @param bf            bf_read handle to read from.
		 * @return              Entity index read.
		 * @error               Invalid or incorrect Handle.
		 */
		public static int BfReadEntity(Handle bf) { throw new NotImplementedException(); }

		/**
		 * Reads a bit angle from a readable bitbuffer (bf_read).
		 *
		 * @param bf            bf_read handle to read from.
		 * @param numBits       Optional number of bits to use.
		 * @return              Angle read.
		 * @error               Invalid or incorrect Handle.
		 */
		public static float BfReadAngle(Handle bf, int numBits = 8) { throw new NotImplementedException(); }

		/**
		 * Reads a coordinate from a readable bitbuffer (bf_read).
		 *
		 * @param bf            bf_read handle to read from.
		 * @return              Coordinate read.
		 * @error               Invalid or incorrect Handle.
		 */
		public static float BfReadCoord(Handle bf) { throw new NotImplementedException(); }

		/**
		 * Reads a 3D vector of coordinates from a readable bitbuffer (bf_read).
		 *
		 * @param bf            bf_read handle to read from.
		 * @param coord         Destination coordinate array.
		 * @error               Invalid or incorrect Handle.
		 */
		public static void BfReadVecCoord(Handle bf, float[] coord) { throw new NotImplementedException(); }

		/**
		 * Reads a 3D normal vector from a readable bitbuffer (bf_read).
		 *
		 * @param bf            bf_read handle to read from.
		 * @param vec           Destination vector array.
		 * @error               Invalid or incorrect Handle.
		 */
		public static void BfReadVecNormal(Handle bf, float[] vec) { throw new NotImplementedException(); }

		/**
		 * Reads a 3D angle vector from a readable bitbuffer (bf_read).
		 *
		 * @param bf            bf_read handle to read from.
		 * @param angles        Destination angle vector.
		 * @error               Invalid or incorrect Handle.
		 */
		public static void BfReadAngles(Handle bf, float[] angles) { throw new NotImplementedException(); }

		/**
		 * Returns the number of bytes left in a readable bitbuffer (bf_read).
		 *
		 * @param bf            bf_read handle to read from.
		 * @return              Number of bytes left unread.
		 * @error               Invalid or incorrect Handle.
		 */
		public static int BfGetNumBytesLeft(Handle bf) { throw new NotImplementedException(); }
	}
}