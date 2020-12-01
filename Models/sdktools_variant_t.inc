/**
 * vim: set ts=4 :
 * =============================================================================
 * SourceMod (C)2004-2017 AlliedModders LLC.  All rights reserved.
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
 * Sets a bool value in the global variant object.
 *
 * @param val           Input value.
 */
public static void SetVariantBool(bool val) { throw new NotImplementedException(); }

/**
 * Sets a string in the global variant object.
 *
 * @param str           Input string.
 */
public static void SetVariantString(string str) { throw new NotImplementedException(); }

/**
 * Sets an integer value in the global variant object.
 *
 * @param val           Input value.
 */
public static void SetVariantInt(int val) { throw new NotImplementedException(); }

/**
 * Sets a floating point value in the global variant object.
 *
 * @param val           Input value.
 */
public static void SetVariantFloat(float val) { throw new NotImplementedException(); }

/**
 * Sets a 3D vector in the global variant object.
 *
 * @param vec           Input vector.
 */
public static void SetVariantVector3D(ReadOnlyCollection<float> vec[3]) { throw new NotImplementedException(); }

/**
 * Sets a 3D position vector in the global variant object.
 *
 * @param vec           Input position vector.
 */
public static void SetVariantPosVector3D(ReadOnlyCollection<float> vec[3]) { throw new NotImplementedException(); }

/**
 * Sets a color in the global variant object.
 *
 * @param color         Input color.
 */
public static void SetVariantColor(const int color[4]) { throw new NotImplementedException(); }

/**
 * Sets an entity in the global variant object.
 *
 * @param entity        Entity index.
 * @error               Invalid entity index.
 */
public static void SetVariantEntity(int entity) { throw new NotImplementedException(); }
	}
}