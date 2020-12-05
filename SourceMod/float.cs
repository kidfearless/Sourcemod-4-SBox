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
		private static Random random = new Random();

		/**
		 * Converts an integer into a floating point value.
		 *
		 * @param value         Integer to convert.
		 * @return              Floating point value.
		 */
		public static float Float(int value) => (float)value;

		/**
		 * Returns the decimal part of a float.
		 *
		 * @param value         Input value.
		 * @return              Decimal part.
		 */
		public static float FloatFraction(float value)
		{
			return value - (float)Math.Floor(value);
		}

		/**
		 * Rounds a float to the closest integer to zero.
		 *
		 * @param value         Input value to be rounded.
		 * @return              Rounded value.
		 */
		public static int RoundToZero(float value) => (int)Math.Round(value, MidpointRounding.ToZero);

		/**
		 * Rounds a float to the next highest integer value.
		 *
		 * @param value         Input value to be rounded.
		 * @return              Rounded value.
		 */
		public static int RoundToCeil(float value) => (int)Math.Round(value, MidpointRounding.ToPositiveInfinity);

		/**
		 * Rounds a float to the next lowest integer value.
		 *
		 * @param value         Input value to be rounded.
		 * @return              Rounded value.
		 */
		public static int RoundToFloor(float value) => (int)Math.Round(value, MidpointRounding.ToNegativeInfinity);

		/**
		 * Standard IEEE rounding.
		 *
		 * @param value         Input value to be rounded.
		 * @return              Rounded value.
		 */
		public static int RoundToNearest(float value) => (int)Math.Round(value);

		/**
		 * Compares two floats.
		 *
		 * @param fOne          First value.
		 * @param fTwo          Second value.
		 * @return              Returns 1 if the first argument is greater than the second argument.
		 *                      Returns -1 if the first argument is smaller than the second argument.
		 *                      Returns 0 if both arguments are equal.
		 */
		public static int FloatCompare(float fOne, float fTwo)
		{
			return Math.Sign(fOne - fTwo);
		}

		/**
		 * Returns the square root of the input value, equivalent to floatpower(value, 0.5).
		 *
		 * @param value         Input value.
		 * @return              Square root of the value.
		 */
		public static float SquareRoot(float value) => (float)Math.Sqrt(value);

		/**
		 * Returns the value raised to the power of the exponent.
		 *
		 * @param value         Value to be raised.
		 * @param exponent      Value to raise the base.
		 * @return              value^exponent.
		 */
		public static float Pow(float value, float exponent) => (float)Math.Pow(value, exponent);

		/**
		 * Returns the value of raising the input by e.
		 *
		 * @param value         Input value.
		 * @return              exp(value).
		 */
		public static float Exponential(float value) => (float)Math.Pow(value, Math.E);

		/**
		 * Returns the logarithm of any base specified.
		 *
		 * @param value         Input value.
		 * @param base          Logarithm base to use, default is 10.
		 * @return              log(value)/log(base).
		 */
		public static float Logarithm(float value, float Base = 10.0f) => (float)Math.Log(value, Base);

		/**
		 * Returns the sine of the argument.
		 *
		 * @param value         Input value in radians.
		 * @return              sin(value).
		 */
		public static float Sine(float value) => (float)Math.Sin(value) ;

		/**
		 * Returns the cosine of the argument.
		 *
		 * @param value         Input value in radians.
		 * @return              cos(value).
		 */
		public static float Cosine(float value) => (float)Math.Cos(value) ;

		/**
		 * Returns the tangent of the argument.
		 *
		 * @param value         Input value in radians.
		 * @return              tan(value).
		 */
		public static float Tangent(float value) => (float)Math.Tan(value);

		/**
		 * Returns an absolute value.
		 *
		 * @param value         Input value.
		 * @return              Absolute value of the input.
		 */
		public static float FloatAbs(float value) => (float)Math.Abs(value);

		/**
		 * Returns the arctangent of the input value.
		 *
		 * @param angle         Input value.
		 * @return              atan(value) in radians.
		 */
		public static float ArcTangent(float angle) => (float)Math.Atan(angle) ;

		/**
		 * Returns the arccosine of the input value.
		 *
		 * @param angle         Input value.
		 * @return              acos(value) in radians.
		 */
		public static float ArcCosine(float angle) => (float)Math.Acos(angle);

		/**
		 * Returns the arcsine of the input value.
		 *
		 * @param angle         Input value.
		 * @return              asin(value) in radians.
		 */
		public static float ArcSine(float angle) => (float)Math.Asin(angle);

		/**
		 * Returns the arctangent2 of the input values.
		 *
		 * @param x             Horizontal value.
		 * @param y             Vertical value.
		 * @return              atan2(value) in radians.
		 */
		public static float ArcTangent2(float x, float y) => (float)Math.Atan2(x, y);

		/**
		 * Rounds a floating point number using the "round to nearest" algorithm.
		 *
		 * @param value         Floating point value to round.
		 * @return              The value rounded to the nearest integer.
		 */
		public static int RoundFloat(float value)
		{
			return RoundToNearest(value);
		}


		public const float FLOAT_PI = 3.1415926535897932384626433832795f;

		/**
		 * Converts degrees to radians.
		 *
		 * @param angle         Degrees.
		 * @return              Radians.
		 */
		public static float DegToRad(float angle)
		{
			return (angle * FLOAT_PI) / 180;
		}

		/**
		 * Converts radians to degrees.
		 *
		 * @param angle         Radians.
		 * @return              Degrees.
		 */
		public static float RadToDeg(float angle)
		{
			return (angle * 180) / FLOAT_PI;
		}

		/**
		 * Returns a random integer in the range [0, 2^31-1].
		 *
		 * Note: Uniform random number streams are seeded automatically per-plugin.
		 *
		 * @return              Random integer.
		 */
		public static int GetURandomInt() => random.Next(0, int.MaxValue);

		/**
		 * Returns a uniform random float in the range [0, 1).
		 *
		 * Note: Uniform random number streams are seeded automatically per-plugin.
		 *
		 * @return              Uniform random floating-point number.
		 */
		public static float GetURandomFloat() => (float)random.NextDouble();

		/**
		 * Seeds a plugin's uniform random number stream. This is done automatically,
		 * so normally it is totally unnecessary to call this.
		 *
		 * @param seeds         Array of numbers to use as seeding data.
		 * @param numSeeds      Number of seeds in the seeds array.
		 */
		public static void SetURandomSeed(int[] seeds, int numSeeds) =>  random = new Random(seeds[0]);

		/**
		 * Seeds a plugin's uniform random number stream. This is done automatically,
		 * so normally it is totally unnecessary to call this.
		 *
		 * @param
		{
		
		}seed value.
		 */
		public static void SetURandomSeedSimple(int seed)
		{
			int[] seeds = new int[1];
			seeds[0] = seed;
			SetURandomSeed(seeds, 1);
		}
	}
}