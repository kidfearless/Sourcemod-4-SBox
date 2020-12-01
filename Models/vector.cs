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

using System;
using System.Collections.ObjectModel;
namespace Sourcemod
{
	public partial class SourceMod
	{

		/**
		 * Calculates a vector's length.
		 *
		 * @param vec           Vector.
		 * @param squared       If true, the result will be squared (for optimization).
		 * @return              Vector length (magnitude).
		 */
		public static float GetVectorLength(ReadOnlyCollection<float> vec, bool squared = false)
		{
			throw new NotImplementedException();
		}

		/**
		 * Calculates the distance between two vectors.
		 *
		 * @param vec1          First vector.
		 * @param vec2          Second vector.
		 * @param squared       If true, the result will be squared (for optimization).
		 * @return              Vector distance.
		 */
		public static float GetVectorDistance(ReadOnlyCollection<float> vec1, ReadOnlyCollection<float> vec2, bool squared = false) { throw new NotImplementedException(); }

		/**
		 * Calculates the dot product of two vectors.
		 *
		 * @param vec1          First vector.
		 * @param vec2          Second vector.
		 * @return              Dot product of the two vectors.
		 */
		public static float GetVectorDotProduct(ReadOnlyCollection<float> vec1, ReadOnlyCollection<float> vec2) { throw new NotImplementedException(); }

		/**
		 * Computes the cross product of two vectors.  Any input array can be the same
		 * as the output array.
		 *
		 * @param vec1          First vector.
		 * @param vec2          Second vector.
		 * @param result        Resultant vector.
		 */
		public static void GetVectorCrossProduct(ReadOnlyCollection<float> vec1, ReadOnlyCollection<float> vec2, out float[] result) { throw new NotImplementedException(); }

		/**
		 * Normalizes a vector.  The input array can be the same as the output array.
		 *
		 * @param vec           Vector.
		 * @param result        Resultant vector.
		 * @return              Vector length.
		 */
		public static float NormalizeVector(ReadOnlyCollection<float> vec, out float[] result) { throw new NotImplementedException(); }

		/**
		 * Returns vectors in the direction of an angle.
		 *
		 * @param angle         Angle.
		 * @param fwd           public static override vector buffer or NULL_VECTOR.
		 * @param right         Right vector buffer or NULL_VECTOR.
		 * @param up            Up vector buffer or NULL_VECTOR.
		 */
		public static void GetAngleVectors(ReadOnlyCollection<float> angle, out float[] fwd, out float[] right, out float[] up) { throw new NotImplementedException(); }

		/**
		 * Returns angles from a vector.
		 *
		 * @param vec           Vector.
		 * @param angle         Angle buffer.
		 */
		public static void GetVectorAngles(ReadOnlyCollection<float> vec, out float[] angle) { throw new NotImplementedException(); }

		/**
		 * Returns direction vectors from a vector.
		 *
		 * @param vec           Vector.
		 * @param right         Right vector buffer or NULL_VECTOR.
		 * @param up            Up vector buffer or NULL_VECTOR.
		 */
		public static void GetVectorVectors(ReadOnlyCollection<float> vec, out float[] right, out float[] up) { throw new NotImplementedException(); }

		/**
		 * Adds two vectors.  It is safe to use either input buffer as an output
		 * buffer.
		 *
		 * @param vec1          First vector.
		 * @param vec2          Second vector.
		 * @param result        Result buffer.
		 */
		public static void AddVectors(ReadOnlyCollection<float> vec1, ReadOnlyCollection<float> vec2, out float[] result)
		{
			result = new float[3];
			result[0] = vec1[0] + vec2[0];
			result[1] = vec1[1] + vec2[1];
			result[2] = vec1[2] + vec2[2];
		}

		/**
		 * Subtracts a vector from another vector.  It is safe to use either input
		 * buffer as an output buffer.
		 *
		 * @param vec1          First vector.
		 * @param vec2          Second vector to subtract from first.
		 * @param result        Result buffer.
		 */
		public static void SubtractVectors(ReadOnlyCollection<float> vec1, ReadOnlyCollection<float> vec2, out float[] result)
		{
			result = new float[3];
			result[0] = vec1[0] - vec2[0];
			result[1] = vec1[1] - vec2[1];
			result[2] = vec1[2] - vec2[2];
		}

		/**
		 * Scales a vector.
		 *
		 * @param vec           Vector.
		 * @param scale         Scale value.
		 */
		public static void ScaleVector(float[] vec, float scale)
		{
			vec[0] *= scale;
			vec[1] *= scale;
			vec[2] *= scale;
		}

		/**
		 * Negatives a vector.
		 *
		 * @param vec           Vector.
		 */
		public static void NegateVector(float[] vec)
		{
			vec[0] = -vec[0];
			vec[1] = -vec[1];
			vec[2] = -vec[2];
		}

		/**
		 * Builds a vector from two points by subtracting the points.
		 *
		 * @param pt1           First point (to be subtracted from the second).
		 * @param pt2           Second point.
		 * @param output        Output vector buffer.
		 */
		public static void MakeVectorFromPoints(ReadOnlyCollection<float> pt1, ReadOnlyCollection<float> pt2, out float[] output)
		{
			output = new float[3];
			output[0] = pt2[0] - pt1[0];
			output[1] = pt2[1] - pt1[1];
			output[2] = pt2[2] - pt1[2];
		}
	}
}