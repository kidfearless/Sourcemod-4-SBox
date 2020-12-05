/**
 * vim: set ts=4 :
 * =============================================================================
 * SourceMod (C)2004-2008 AlliedModders LLC.  All rights reserved.
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
using System.Numerics;

namespace Sourcemod
{
	public partial class SourceMod
	{
		private static double RadiansToDegree(double rad) => rad * (180 / Math.PI);
		private static double DegreeToRadians(double deg) => deg * (Math.PI / 180);

		private static Vector3 CreateVector3(float[] vec)
		{
			return new Vector3(vec[0], vec[1], vec[2]);
		}


		/**
		 * Calculates a vector's length.
		 *
		 * @param vec           Vector.
		 * @param squared       If true, the result will be squared (for optimization).
		 * @return              Vector length (magnitude).
		 */
		public static float GetVectorLength(float[] vec, bool squared = false)
		{
			var v = CreateVector3(vec);
			if(squared)
			{
				return v.LengthSquared();
			}
			return v.Length();
		}

		/**
		 * Calculates the distance between two vectors.
		 *
		 * @param vec1          First vector.
		 * @param vec2          Second vector.
		 * @param squared       If true, the result will be squared (for optimization).
		 * @return              Vector distance.
		 */
		public static float GetVectorDistance(float[] vec1, float[] vec2, bool squared = false)
		{
			var v = CreateVector3(vec1);
			var v2 = CreateVector3(vec2);
			if (squared)
			{
				return Vector3.DistanceSquared(v, v2);
			}
			return Vector3.Distance(v, v2);
		}

		/**
		 * Calculates the dot product of two vectors.
		 *
		 * @param vec1          First vector.
		 * @param vec2          Second vector.
		 * @return              Dot product of the two vectors.
		 */
		public static float GetVectorDotProduct(float[] vec1, float[] vec2)
		{
			var v = CreateVector3(vec1);
			var v2 = CreateVector3(vec2);
			return Vector3.Dot(v, v2);
		}

		/**
		 * Computes the cross product of two vectors.  Any input array can be the same
		 * as the output array.
		 *
		 * @param vec1          First vector.
		 * @param vec2          Second vector.
		 * @param result        Resultant vector.
		 */
		public static void GetVectorCrossProduct(float[] vec1, float[] vec2, out float[] result)
		{
			var v = CreateVector3(vec1);
			var v2 = CreateVector3(vec2);
			
			var v3 = Vector3.Cross(v, v2);
			result = new float[3]
			{
				v3.X,
				v3.Y,
				v3.Z
			};
		}

		/**
		 * Normalizes a vector.  The input array can be the same as the output array.
		 *
		 * @param vec           Vector.
		 * @param result        Resultant vector.
		 * @return              Vector length.
		 */
		public static float NormalizeVector(float[] vec, out float[] result)
		{
			var v = CreateVector3(vec);
			var v3 = Vector3.Normalize(v);
			result = new float[3]
			{
				v3.X,
				v3.Y,
				v3.Z
			};
			return v.Length();
		}

		/**
		 * Returns vectors in the direction of an angle.
		 *
		 * @param angle         Angle.
		 * @param fwd           public virtual vector buffer or NULL_VECTOR.
		 * @param right         Right vector buffer or NULL_VECTOR.
		 * @param up            Up vector buffer or NULL_VECTOR.
		 */
		public static void GetAngleVectors(float[] angle, out float[] fwd, out float[] right, out float[] up)
		{
			SinCos((float)DegreeToRadians(angle[1]), out float sy, out float cy);
			SinCos((float)DegreeToRadians(angle[0]), out float sp, out float cp);
			SinCos((float)DegreeToRadians(angle[2]), out float sr, out float cr);


			fwd = new float[3]
			{
				cp * cy,
				cp * sy,
				-sp
			};

			right = new float[3]
			{
				(-1 * sr * sp * cy + -1 * cr * -sy),
				(-1 * sr * sp * sy + -1 * cr * cy),
				-1 * sr * cp
			};

			up = new float[3]
			{
				(cr * sp * cy + -sr * -sy),
				(cr * sp * sy + -sr * cy),
				cr * cp
			};
		}

		private static void SinCos(float radians, out float sine, out float cosine )
		{
			sine = (float)Math.Sin(radians);
			cosine = (float)Math.Cos(radians);
		}

		/**
		 * Returns angles from a vector.
		 *
		 * @param vec           Vector.
		 * @param angle         Angle buffer.
		 */
		public static void GetVectorAngles(float[] vec, out float[] angle)
		{
			float tmp, yaw, pitch;

			if (vec[1] == 0 && vec[0] == 0)
			{
				yaw = 0;
				if (vec[2] > 0)
					pitch = 270;
				else
					pitch = 90;
			}
			else
			{
				yaw = ((float)(Math.Atan2(vec[1], vec[0]) * 180 / Math.PI));
				if (yaw < 0)
					yaw += 360;

				tmp = (float)Math.Sqrt(vec[0] * vec[0] + vec[1] * vec[1]);
				pitch = ((float)(Math.Atan2(-vec[2], tmp) * 180 / Math.PI));
				if (pitch < 0)
					pitch += 360;
			}
			angle = new float[3]
			{
				pitch,
				yaw,
				0
			};
		}

		/**
		 * Returns direction vectors from a vector.
		 *
		 * @param vec           Vector.
		 * @param right         Right vector buffer or NULL_VECTOR.
		 * @param up            Up vector buffer or NULL_VECTOR.
		 */
		public static void GetVectorVectors(float[] vec, out float[] right, out float[] up)
		{
			right = new float[3];
			up = new float[3];
			if (Math.Abs(vec[0]) < 1e-6 && Math.Abs(vec[1]) < 1e-6)
			{
				// pitch 90 degrees up/down from identity
				right[0] = 0;
				right[1] = -1;
				right[2] = 0;
				up[0] = -vec[2];
				up[1] = 0;
				up[2] = 0;
			}
			else
			{
				float[] tmp = new float[3];
				tmp[0] = 0; tmp[1] = 0; tmp[2] = 1.0f;
				var r = Vector3.Cross(CreateVector3(vec), CreateVector3(tmp));
				VectorNormalize(right);
				right = new float[3]
				{
					r.X,
					r.Y,
					r.Z
				};
				CrossProduct(right, vec, up);
				VectorNormalize(up);
			}
		}

		/**
		 * Adds two vectors.  It is safe to use either input buffer as an output
		 * buffer.
		 *
		 * @param vec1          First vector.
		 * @param vec2          Second vector.
		 * @param result        Result buffer.
		 */
		public static void AddVectors(float[] vec1, float[] vec2, out float[] result)
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
		public static void SubtractVectors(float[] vec1, float[] vec2, out float[] result)
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
		public static void MakeVectorFromPoints(float[] pt1, float[] pt2, out float[] output)
		{
			output = new float[3];
			output[0] = pt2[0] - pt1[0];
			output[1] = pt2[1] - pt1[1];
			output[2] = pt2[2] - pt1[2];
		}
	}
}
