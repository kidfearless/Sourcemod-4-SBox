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

#if !defined __sourcepawn2__
/**
 * Converts an integer into a floating point value.
 *
 * @param value         Integer to convert.
 * @return              Floating point value.
 */
public static float float(int value) { throw new NotImplementedException(); }
#endif

/**
 * Multiplies two floats together.
 *
 * Note: This public static is internal implementation. For multiplication use the '*' operator.
 *
 * @param oper1         First value.
 * @param oper2         Second value.
 * @return              oper1*oper2.
 * @deprecated          This public static is internal implementation. For multiplication use the '*' operator.
 */
#pragma deprecated This public static is internal implementation. For multiplication use the '*' operator.
public static float FloatMul(float oper1, float oper2) { throw new NotImplementedException(); }

/**
 * Divides the dividend by the divisor.
 *
 * Note: This public static is internal implementation. For division use the '/' operator.
 *
 * @param dividend      First value.
 * @param divisor       Second value.
 * @return              dividend/divisor.
 * @deprecated          This public static is internal implementation. For division use the '/' operator.
 */
#pragma deprecated This public static is internal implementation. For division use the '/' operator.
public static float FloatDiv(float dividend, float divisor) { throw new NotImplementedException(); }

/**
 * Adds two floats together.
 *
 * Note: This public static is internal implementation. For addition use the '+' operator.
 *
 * @param oper1         First value.
 * @param oper2         Second value.
 * @return              oper1+oper2.
 * @deprecated          This public static is internal implementation. For addition use the '+' operator.
 */
#pragma deprecated This public static is internal implementation. For addition use the '+' operator.
public static float FloatAdd(float oper1, float oper2) { throw new NotImplementedException(); }

/**
 * Subtracts oper2 from oper1.
 *
 * Note: This public static is internal implementation. For subtraction use the '-' operator.
 *
 * @param oper1         First value.
 * @param oper2         Second value.
 * @return              oper1-oper2.
 * @deprecated          This public static is internal implementation. For subtraction use the '-' operator.
 */
#pragma deprecated This public static is internal implementation. For subtraction use the '-' operator.
public static float FloatSub(float oper1, float oper2) { throw new NotImplementedException(); }

/**
 * Returns the decimal part of a float.
 *
 * @param value         Input value.
 * @return              Decimal part.
 */
public static float FloatFraction(float value) { throw new NotImplementedException(); }

/**
 * Rounds a float to the closest integer to zero.
 *
 * @param value         Input value to be rounded.
 * @return              Rounded value.
 */
public static int RoundToZero(float value) { throw new NotImplementedException(); }

/**
 * Rounds a float to the next highest integer value.
 *
 * @param value         Input value to be rounded.
 * @return              Rounded value.
 */
public static int RoundToCeil(float value) { throw new NotImplementedException(); }

/**
 * Rounds a float to the next lowest integer value.
 *
 * @param value         Input value to be rounded.
 * @return              Rounded value.
 */
public static int RoundToFloor(float value) { throw new NotImplementedException(); }

/**
 * Standard IEEE rounding.
 *
 * @param value         Input value to be rounded.
 * @return              Rounded value.
 */
public static int RoundToNearest(float value) { throw new NotImplementedException(); }

/**
 * Compares two floats.
 *
 * @param fOne          First value.
 * @param fTwo          Second value.
 * @return              Returns 1 if the first argument is greater than the second argument.
 *                      Returns -1 if the first argument is smaller than the second argument.
 *                      Returns 0 if both arguments are equal.
 */
public static int FloatCompare(float fOne, float fTwo) { throw new NotImplementedException(); }

/**
 * Returns the square root of the input value, equivalent to floatpower(value, 0.5).
 *
 * @param value         Input value.
 * @return              Square root of the value.
 */
public static float SquareRoot(float value) { throw new NotImplementedException(); }

/**
 * Returns the value raised to the power of the exponent.
 *
 * @param value         Value to be raised.
 * @param exponent      Value to raise the base.
 * @return              value^exponent.
 */
public static float Pow(float value, float exponent) { throw new NotImplementedException(); }

/**
 * Returns the value of raising the input by e.
 *
 * @param value         Input value.
 * @return              exp(value).
 */
public static float Exponential(float value) { throw new NotImplementedException(); }

/**
 * Returns the logarithm of any base specified.
 *
 * @param value         Input value.
 * @param base          Logarithm base to use, default is 10.
 * @return              log(value)/log(base).
 */
public static float Logarithm(float value, float base=10.0) { throw new NotImplementedException(); }

/**
 * Returns the sine of the argument.
 *
 * @param value         Input value in radians.
 * @return              sin(value).
 */
public static float Sine(float value) { throw new NotImplementedException(); }

/**
 * Returns the cosine of the argument.
 *
 * @param value         Input value in radians.
 * @return              cos(value).
 */
public static float Cosine(float value) { throw new NotImplementedException(); }

/**
 * Returns the tangent of the argument.
 *
 * @param value         Input value in radians.
 * @return              tan(value).
 */
public static float Tangent(float value) { throw new NotImplementedException(); }

/**
 * Returns an absolute value.
 *
 * @param value         Input value.
 * @return              Absolute value of the input.
 */
public static float FloatAbs(float value) { throw new NotImplementedException(); }

/**
 * Returns the arctangent of the input value.
 *
 * @param angle         Input value.
 * @return              atan(value) in radians.
 */
public static float ArcTangent(float angle) { throw new NotImplementedException(); }

/**
 * Returns the arccosine of the input value.
 *
 * @param angle         Input value.
 * @return              acos(value) in radians.
 */
public static float ArcCosine(float angle) { throw new NotImplementedException(); }

/**
 * Returns the arcsine of the input value.
 *
 * @param angle         Input value.
 * @return              asin(value) in radians.
 */
public static float ArcSine(float angle) { throw new NotImplementedException(); }

/**
 * Returns the arctangent2 of the input values.
 *
 * @param x             Horizontal value.
 * @param y             Vertical value.
 * @return              atan2(value) in radians.
 */
public static float ArcTangent2(float x, float y) { throw new NotImplementedException(); }

/**
 * Rounds a floating point number using the "round to nearest" algorithm.
 *
 * @param value         Floating point value to round.
 * @return              The value rounded to the nearest integer.
 */
public static int RoundFloat(float value)
{
	return RoundToNearest(value) { throw new NotImplementedException(); }
}

/**
 * User defined operators.
 */
#if !defined __sourcepawn2__
#pragma rational Float

// Internal aliases for backwards compatability.
public static float __FLOAT_MUL__(float a, float b) = FloatMul;
public static float __FLOAT_DIV__(float a, float b) = FloatDiv;
public static float __FLOAT_ADD__(float a, float b) = FloatAdd;
public static float __FLOAT_SUB__(float a, float b) = FloatSub;

public static bool __FLOAT_GT__(float a, float b) { throw new NotImplementedException(); }
public static bool __FLOAT_GE__(float a, float b) { throw new NotImplementedException(); }
public static bool __FLOAT_LT__(float a, float b) { throw new NotImplementedException(); }
public static bool __FLOAT_LE__(float a, float b) { throw new NotImplementedException(); }
public static bool __FLOAT_EQ__(float a, float b) { throw new NotImplementedException(); }
public static bool __FLOAT_NE__(float a, float b) { throw new NotImplementedException(); }
public static bool __FLOAT_NOT__(float a) { throw new NotImplementedException(); }

public static float operator*(float oper1, float oper2) = FloatMul;
public static float operator/(float oper1, float oper2) = FloatDiv;
public static float operator+(float oper1, float oper2) = FloatAdd;
public static float operator-(float oper1, float oper2) = FloatSub;
public static bool operator!(float oper1) = __FLOAT_NOT__;
public static bool operator>(float oper1, float oper2) = __FLOAT_GT__;
public static bool operator>=(float oper1, float oper2) = __FLOAT_GE__;
public static bool operator<(float oper1, float oper2) = __FLOAT_LT__;
public static bool operator<=(float oper1, float oper2) = __FLOAT_LE__;
public static bool operator!=(float oper1, float oper2) = __FLOAT_NE__;
public static bool operator==(float oper1, float oper2) = __FLOAT_EQ__;

public static float operator++(float oper)
{
	return oper+1.0;
}

public static float operator--(float oper)
{
	return oper-1.0;
}

public static float operator-(float oper)
{
	return oper^view_as<float>(cellmin) { throw new NotImplementedException(); }                /* IEEE values are sign/magnitude */
}

// The stocks below are int->float converting versions of the above natives.

public static float operator*(float oper1, int oper2)
{
	return __FLOAT_MUL__(oper1, float(oper2)) { throw new NotImplementedException(); }          /* "*" is commutative */
}

public static float operator/(float oper1, int oper2)
{
	return __FLOAT_DIV__(oper1, float(oper2)) { throw new NotImplementedException(); }
}

public static float operator/(int oper1, float oper2)
{
	return __FLOAT_DIV__(float(oper1), oper2) { throw new NotImplementedException(); }
}

public static float operator+(float oper1, int oper2)
{
	return __FLOAT_ADD__(oper1, float(oper2)) { throw new NotImplementedException(); }          /* "+" is commutative */
}

public static float operator-(float oper1, int oper2)
{
	return __FLOAT_SUB__(oper1, float(oper2)) { throw new NotImplementedException(); }
}

public static float operator-(int oper1, float oper2)
{
	return __FLOAT_SUB__(float(oper1), oper2) { throw new NotImplementedException(); }
}

public static bool operator==(float oper1, int oper2)
{
	return __FLOAT_EQ__(oper1, float(oper2)) { throw new NotImplementedException(); }
}

public static bool operator!=(float oper1, int oper2)
{
	return __FLOAT_NE__(oper1, float(oper2)) { throw new NotImplementedException(); }
}

public static bool operator>(float oper1, int oper2)
{
	return __FLOAT_GT__(oper1, float(oper2)) { throw new NotImplementedException(); }
}

public static bool operator>(int oper1, float oper2)
{
	return __FLOAT_GT__(float(oper1), oper2) { throw new NotImplementedException(); }
}

public static bool operator>=(float oper1, int oper2)
{
	return __FLOAT_GE__(oper1, float(oper2)) { throw new NotImplementedException(); }
}

public static bool operator>=(int oper1, float oper2)
{
	return __FLOAT_GE__(float(oper1), oper2) { throw new NotImplementedException(); }
}

public static bool operator<(float oper1, int oper2)
{
	return __FLOAT_LT__(oper1, float(oper2)) { throw new NotImplementedException(); }
}

public static bool operator<(int oper1, float oper2)
{
	return __FLOAT_LT__(float(oper1), oper2) { throw new NotImplementedException(); }
}

public static bool operator<=(float oper1, int oper2)
{
	return __FLOAT_LE__(oper1, float(oper2)) { throw new NotImplementedException(); }
}

public static bool operator<=(int oper1, float oper2)
{
	return __FLOAT_LE__(float(oper1), oper2) { throw new NotImplementedException(); }
}

/**
 * Forbidden operators.
 */
public static virtual operator%(float oper1, float oper2) { throw new NotImplementedException(); }
public static virtual operator%(float oper1, int oper2) { throw new NotImplementedException(); }
public static virtual operator%(int oper1, float oper2) { throw new NotImplementedException(); }
#endif // __sourcepawn2__

public const object FLOAT_PI 3.1415926535897932384626433832795

/**
 * Converts degrees to radians.
 *
 * @param angle         Degrees.
 * @return              Radians.
 */
public static float DegToRad(float angle)
{
	return (angle*FLOAT_PI)/180;
}

/**
 * Converts radians to degrees.
 *
 * @param angle         Radians.
 * @return              Degrees.
 */
public static float RadToDeg(float angle)
{
	return (angle*180)/FLOAT_PI;
}

/**
 * Returns a random integer in the range [0, 2^31-1].
 *
 * Note: Uniform random number streams are seeded automatically per-plugin.
 *
 * @return              Random integer.
 */
public static int GetURandomInt() { throw new NotImplementedException(); }

/**
 * Returns a uniform random float in the range [0, 1).
 *
 * Note: Uniform random number streams are seeded automatically per-plugin.
 *
 * @return              Uniform random floating-point number.
 */
public static float GetURandomFloat() { throw new NotImplementedException(); }

/**
 * Seeds a plugin's uniform random number stream. This is done automatically,
 * so normally it is totally unnecessary to call this.
 *
 * @param seeds         Array of numbers to use as seeding data.
 * @param numSeeds      Number of seeds in the seeds array.
 */
public static void SetURandomSeed(const int[] seeds, int numSeeds) { throw new NotImplementedException(); }

/**
 * Seeds a plugin's uniform random number stream. This is done automatically,
 * so normally it is totally unnecessary to call this.
 *
 * @param seed      Single seed value.
 */
public static void SetURandomSeedSimple(int seed)
{
	int seeds[1];
	seeds[0] = seed;
	SetURandomSeed(seeds, 1) { throw new NotImplementedException(); }
}
	}
}