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
namespace Sourcemod
{
	public partial class SourceMod
	{

		public const int CONTENTS_EMPTY = 0;            /**< No contents. */
		public const int CONTENTS_SOLID = 0x1;          /**< an eye is never valid in a solid . */
		public const int CONTENTS_WINDOW = 0x2;          /**< translucent, but not watery (glass). */
		public const int CONTENTS_AUX = 0x4;
		public const int CONTENTS_GRATE = 0x8;          /**< alpha-tested "grate" textures.  Bullets/sight pass through, but solids don't. */
		public const int CONTENTS_SLIME = 0x10;
		public const int CONTENTS_WATER = 0x20;
		public const int CONTENTS_MIST = 0x40;
		public const int CONTENTS_OPAQUE = 0x80;         /**< things that cannot be seen through (may be non-solid though). */
		public const int LAST_VISIBLE_CONTENTS = 0x80;
		public const int ALL_VISIBLE_CONTENTS = (LAST_VISIBLE_CONTENTS | (LAST_VISIBLE_CONTENTS - 1));
public const int CONTENTS_TESTFOGVOLUME = 0x100;
		public const int CONTENTS_UNUSED5 = 0x200;
		public const int CONTENTS_UNUSED6 = 0x4000;
		public const int CONTENTS_TEAM1 = 0x800;     /**< per team contents used to differentiate collisions. */
		public const int CONTENTS_TEAM2 = 0x1000;     /**< between players and objects on different teams. */
		public const int CONTENTS_IGNORE_NODRAW_OPAQUE = 0x2000;       /**< ignore CONTENTS_OPAQUE on surfaces that have SURF_NODRAW. */
		public const int CONTENTS_MOVEABLE = 0x4000;       /**< hits entities which are MOVETYPE_PUSH (doors, plats, etc) */
		public const int CONTENTS_AREAPORTAL = 0x8000;       /**< remaining contents are non-visible, and don't eat brushes. */
		public const int CONTENTS_PLAYERCLIP = 0x10000;
		public const int CONTENTS_MONSTERCLIP = 0x20000;

		/**
		 * @section currents can be added to any other contents, and may be mixed
		 */
		public const int CONTENTS_CURRENT_0 = 0x40000;
		public const int CONTENTS_CURRENT_90 = 0x80000;
		public const int CONTENTS_CURRENT_180 = 0x100000;
		public const int CONTENTS_CURRENT_270 = 0x200000;
		public const int CONTENTS_CURRENT_UP = 0x400000;
		public const int CONTENTS_CURRENT_DOWN = 0x800000;

		/**
		 * @endsection
		 */

		public const int CONTENTS_ORIGIN = 0x1000000;    /**< removed before bsp-ing an entity. */
		public const int CONTENTS_MONSTER = 0x2000000;    /**< should never be on a brush, only in game. */
		public const int CONTENTS_DEBRIS = 0x4000000;
		public const int CONTENTS_DETAIL = 0x8000000;    /**< brushes to be added after vis leafs. */
		public const int CONTENTS_TRANSLUCENT = 0x10000000;   /**< auto set if any surface has trans. */
		public const int CONTENTS_LADDER = 0x20000000;
		public const int CONTENTS_HITBOX = 0x40000000;   /**< use accurate hitboxes on trace. */

		/**
		 * @section Trace masks.
		 */
		public const uint MASK_ALL = (0xFFFFFFFF);
		public const int MASK_SOLID = (CONTENTS_SOLID | CONTENTS_MOVEABLE | CONTENTS_WINDOW | CONTENTS_MONSTER | CONTENTS_GRATE);                       /**< everything that is normally solid */
		public const int MASK_PLAYERSOLID = (CONTENTS_SOLID | CONTENTS_MOVEABLE | CONTENTS_PLAYERCLIP | CONTENTS_WINDOW | CONTENTS_MONSTER | CONTENTS_GRATE);   /**< everything that blocks player movement */
		public const int MASK_NPCSOLID = (CONTENTS_SOLID | CONTENTS_MOVEABLE | CONTENTS_MONSTERCLIP | CONTENTS_WINDOW | CONTENTS_MONSTER | CONTENTS_GRATE);  /**< blocks npc movement */
		public const int MASK_WATER = (CONTENTS_WATER | CONTENTS_MOVEABLE | CONTENTS_SLIME);                                                        /**< water physics in these contents */
		public const int MASK_OPAQUE = (CONTENTS_SOLID | CONTENTS_MOVEABLE | CONTENTS_OPAQUE);                                                       /**< everything that blocks line of sight for AI, lighting, etc */
		public const int MASK_OPAQUE_AND_NPCS = (MASK_OPAQUE | CONTENTS_MONSTER);                                                                           /**< everything that blocks line of sight for AI, lighting, etc, but with monsters added. */
		public const int MASK_VISIBLE = (MASK_OPAQUE | CONTENTS_IGNORE_NODRAW_OPAQUE);                                                              /**< everything that blocks line of sight for players */
		public const int MASK_VISIBLE_AND_NPCS = (MASK_OPAQUE_AND_NPCS | CONTENTS_IGNORE_NODRAW_OPAQUE);                                                     /**< everything that blocks line of sight for players, but with monsters added. */
		public const int MASK_SHOT = (CONTENTS_SOLID | CONTENTS_MOVEABLE | CONTENTS_MONSTER | CONTENTS_WINDOW | CONTENTS_DEBRIS | CONTENTS_HITBOX);      /**< bullets see these as solid */
		public const int MASK_SHOT_HULL = (CONTENTS_SOLID | CONTENTS_MOVEABLE | CONTENTS_MONSTER | CONTENTS_WINDOW | CONTENTS_DEBRIS | CONTENTS_GRATE);       /**< non-raycasted weapons see this as solid (includes grates) */
		public const int MASK_SHOT_PORTAL = (CONTENTS_SOLID | CONTENTS_MOVEABLE | CONTENTS_WINDOW);                                                       /**< hits solids (not grates) and passes through everything else */
		public const int MASK_SOLID_BRUSHONLY = (CONTENTS_SOLID | CONTENTS_MOVEABLE | CONTENTS_WINDOW | CONTENTS_GRATE);                                        /**< everything normally solid, except monsters (world+brush only) */
		public const int MASK_PLAYERSOLID_BRUSHONLY = (CONTENTS_SOLID | CONTENTS_MOVEABLE | CONTENTS_WINDOW | CONTENTS_PLAYERCLIP | CONTENTS_GRATE);                    /**< everything normally solid for player movement, except monsters (world+brush only) */
		public const int MASK_NPCSOLID_BRUSHONLY = (CONTENTS_SOLID | CONTENTS_MOVEABLE | CONTENTS_WINDOW | CONTENTS_MONSTERCLIP | CONTENTS_GRATE);                   /**< everything normally solid for npc movement, except monsters (world+brush only) */
		public const int MASK_NPCWORLDSTATIC = (CONTENTS_SOLID | CONTENTS_WINDOW | CONTENTS_MONSTERCLIP | CONTENTS_GRATE);                                     /**< just the world, used for route rebuilding */
		public const int MASK_SPLITAREAPORTAL = (CONTENTS_WATER | CONTENTS_SLIME);                                                                          /**< These are things that can split areaportals */

		/**
		 * @endsection
		 */

		/**
		 * @section Surface flags.
		 */

		public const int SURF_LIGHT = 0x0001;       /**< value will hold the light strength */
		public const int SURF_SKY2D = 0x0002;      /**< don't draw, indicates we should skylight + draw 2d sky but not draw the 3D skybox */
		public const int SURF_SKY = 0x0004;       /**< don't draw, but add to skybox */
		public const int SURF_WARP = 0x0008;       /**< turbulent water warp */
		public const int SURF_TRANS = 0x0010;
		public const int SURF_NOPORTAL = 0x0020;       /**< the surface can not have a portal placed on it */
		public const int SURF_TRIGGER = 0x0040;       /**< This is an xbox hack to work around elimination of trigger surfaces, which breaks occluders */
		public const int SURF_NODRAW = 0x0080;       /**< don't bother referencing the texture */

		public const int SURF_HINT = 0x0100;       /**< make a primary bsp splitter */

		public const int SURF_SKIP = 0x0200;       /**< completely ignore, allowing non-closed brushes */
		public const int SURF_NOLIGHT = 0x0400;       /**< Don't calculate light */
		public const int SURF_BUMPLIGHT = 0x0800;       /**< calculate three lightmaps for the surface for bumpmapping */
		public const int SURF_NOSHADOWS = 0x1000;       /**< Don't receive shadows */
		public const int SURF_NODECALS = 0x2000;       /**< Don't receive decals */
		public const int SURF_NOCHOP = 0x4000;       /**< Don't subdivide patches on this surface */
		public const int SURF_HITBOX = 0x8000;       /**< surface is part of a hitbox */

		/**
		 * @endsection
		 */

		/**
		 * @section Partition masks.
		 */

		public const int PARTITION_SOLID_EDICTS = (1 << 1); /**< every edict_t that isn't SOLID_TRIGGER or SOLID_NOT (and static props) */
		public const int PARTITION_TRIGGER_EDICTS = (1 << 2); /**< every edict_t that IS SOLID_TRIGGER */
		public const int PARTITION_NON_STATIC_EDICTS = (1 << 5); /**< everything in solid & trigger except the static props, includes SOLID_NOTs */
		public const int PARTITION_STATIC_PROPS = (1 << 7);

		/**
		 * @endsection
		 */

		/**
		 * @section Displacement flags.
		 */

		public const int DISPSURF_FLAG_SURFACE = (1 << 0);
		public const int DISPSURF_FLAG_WALKABLE = (1 << 1);
		public const int DISPSURF_FLAG_BUILDABLE = (1 << 2);
		public const int DISPSURF_FLAG_SURFPROP1 = (1 << 3);
		public const int DISPSURF_FLAG_SURFPROP2 = (1 << 4);

		/**
		 * @endsection
		 */

		public enum RayType
		{
			RayType_EndPoint,   /**< The trace ray will go from the start position to the end position. */
			RayType_Infinite    /**< The trace ray will go from the start position to infinity using a direction vector. */
		};
		public const int
			RayType_EndPoint = 0,   /**< The trace ray will go from the start position to the end position. */
			RayType_Infinite = 1;    /**< The trace ray will go from the start position to infinity using a direction vector. */



		/**
		 * Called on entity filtering.
		 *
		 * @param entity        Entity index.
		 * @param contentsMask  Contents Mask.
		 * @param data          Data value, if used.
		 * @return              True to allow the current entity to be hit, otherwise false.
		 */
		public delegate bool TraceEntityFilter(int entity, int contentsMask, any? data);

		/**
		 * Called for each entity public enumerated with public enumerateEntities*.
		 *
		 * @param entity        Entity index.
		 * @param data          Data value, if used.
		 * @return              True to continue public enumerating, otherwise false. */
		public delegate bool TraceEntityEnumerator(int entity, any? data);

		/**
		 * Get the contents mask and the entity index at the given position.
		 *
		 * @param pos           World position to test.
		 * @param entindex      Entity index found at the given position (by reference).
		 * @return              Contents mask.
		 */
		public static int TR_GetPointContents(float[/*3*/] pos) { throw new NotImplementedException(); }

		/**
		 * Get the contents mask and the entity index at the given position.
		 *
		 * @param pos           World position to test.
		 * @param entindex      Entity index found at the given position (by reference).
		 * @return              Contents mask.
		 */
		public static int TR_GetPointContents(float[/*3*/] pos, out int? entindex) { throw new NotImplementedException(); }

		/**
		 * Get the point contents testing only the given entity index.
		 *
		 * @param entindex      Entity index to test.
		 * @param pos           World position.
		 * @return              Contents mask.
		 */
		public static int TR_GetPointContentsEnt(int entindex, float[/*3*/] pos) { throw new NotImplementedException(); }

		/**
		 * Starts up a new trace ray using a global trace result.
		 *
		 * @param pos           Starting position of the ray.
		 * @param vec           Depending on RayType, it will be used as the
		 *                      ending point, or the direction angle.
		 * @param flags         Trace flags.
		 * @param rtype         Method to calculate the ray direction.
		 */
		public static void TR_TraceRay(float[/*3*/] pos, float[/*3*/] vec, int flags, RayType rtype) { throw new NotImplementedException(); }

		/**
		 * Starts up a new trace hull using a global trace result.
		 *
		 * @param pos           Starting position of the ray.
		 * @param vec           Ending position of the ray.
		 * @param mins          Hull minimum size.
		 * @param maxs          Hull maximum size.
		 * @param flags         Trace flags.
		 */
		public static void TR_TraceHull(float[/*3*/] pos, float[/*3*/] vec, float[/*3*/] mins, float[/*3*/] maxs, int flags) { throw new NotImplementedException(); }

		/**
		 * public enumerates over entities along a ray. This may find entities that are
		 * close to the ray but do not actually intersect it. Use TR_Clip*RayToEntity
		 * with TR_DidHit to check if the ray actually intersects the entity.
		 *
		 * @param pos           Starting position of the ray.
		 * @param vec           Depending on RayType, it will be used as the ending
		 *                      point, or the direction angle.
		 * @param mask          Mask to use for the trace. See PARTITION_* flags.
		 * @param rtype         Method to calculate the ray direction.
		 * @param public enumerator    Function to use as public enumerator. For each entity found
		 *                      along the ray, this function is called.
		 * @param data          Arbitrary data value to pass through to the public enumerator.
		 */
		public static void TR_EnumerateEntities(float[/*3*/] pos,
										 float[/*3*/] vec,
										 int mask,
										 RayType rtype,
										 TraceEntityEnumerator enumerator,
								 any? data = null)
		{ throw new NotImplementedException(); }

		/**
		 * public enumerates over entities along a ray hull. This may find entities that are
		 * close to the ray but do not actually intersect it. Use TR_Clip*RayToEntity
		 * with TR_DidHit to check if the ray actually intersects the entity.
		 *
		 * @param pos           Starting position of the ray.
		 * @param vec           Ending position of the ray.
		 * @param mins          Hull minimum size.
		 * @param maxs          Hull maximum size.
		 * @param mask          Mask to use for the trace. See PARTITION_* flags.
		 * @param public enumerator    Function to use as public enumerator. For each entity found
		 *                      along the ray, this function is called.
		 * @param data          Arbitrary data value to pass through to the public enumerator.
		 */
		public static void TR_EnumerateEntitiesHull(float[/*3*/] pos,
											float[/*3*/] vec,
											float[/*3*/] mins,
											float[/*3*/] maxs,
											int mask,
											TraceEntityEnumerator enumerator,
										any? data = null)
		{ throw new NotImplementedException(); }

		/**
		 * public enumerates over entities in a sphere.
		 *
		 * @param pos           Starting position of the ray.
		 * @param radius        Radius of the ray.
		 * @param mask          Mask to use for the trace. See PARTITION_* flags.
		 * @param public enumerator    Function to use as public enumerator. For each entity found
		 *                      along the ray, this function is called.
		 * @param data          Arbitrary data value to pass through to the public enumerator.
		 */
		public static void TR_EnumerateEntitiesSphere(float[/*3*/] pos,
											float radius,
											int mask,
													TraceEntityEnumerator enumerator,
										   any? data = null)
		{ throw new NotImplementedException(); }

		/**
		 * public enumerates over entities in a box.
		 *
		 * @param mins          Box minimum size.
		 * @param maxs          Box maximum size.
		 * @param mask          Mask to use for the trace. See PARTITION_* flags.
		 * @param public enumerator    Function to use as public enumerator. For each entity found
		 *                      along the box, this function is called.
		 * @param data          Arbitrary data value to pass through to the public enumerator.
		 */
		public static void TR_EnumerateEntitiesBox(float[/*3*/] mins,
											float[/*3*/] maxs,
											int mask,
											TraceEntityEnumerator enumerator,
											any? data = null)
		{ throw new NotImplementedException(); }

		/**
		 * public enumerates over entities at point.
		 *
		 * @param pos           Position of the point.
		 * @param mask          Mask to use for the trace. See PARTITION_* flags.
		 * @param public enumerator    Function to use as public enumerator. For each entity found
		 *                      along the point, this function is called.
		 * @param data          Arbitrary data value to pass through to the public enumerator.
		 */
		public static void TR_EnumerateEntitiesPoint(float[/*3*/] pos,
											int mask,
											TraceEntityEnumerator enumerator,
											any? data = null)
		{ throw new NotImplementedException(); }

		/**
		 * Starts up a new trace ray using a global trace result and a customized
		 * trace ray filter.
		 *
		 * Calling TR_Trace*Filter or TR_Trace*FilterEx from inside a filter
		 * function is currently not allowed and may not work.
		 *
		 * @param pos           Starting position of the ray.
		 * @param vec           Depending on RayType, it will be used as the ending
		 *                      point, or the direction angle.
		 * @param flags         Trace flags.
		 * @param rtype         Method to calculate the ray direction.
		 * @param filter        Function to use as a filter.
		 * @param data          Arbitrary data value to pass through to the filter
		 *                      function.
		 */
		public static void TR_TraceRayFilter(float[/*3*/] pos,
									  float[/*3*/] vec,
									  int flags,
									  RayType rtype,
									  TraceEntityFilter filter,
									  any? data = null)
		{ throw new NotImplementedException(); }

		/**
		 * Starts up a new trace hull using a global trace result and a customized
		 * trace ray filter.
		 *
		 * Calling TR_Trace*Filter or TR_Trace*FilterEx from inside a filter
		 * function is currently not allowed and may not work.
		 *
		 * @param pos           Starting position of the ray.
		 * @param vec           Ending position of the ray.
		 * @param mins          Hull minimum size.
		 * @param maxs          Hull maximum size.
		 * @param flags         Trace flags.
		 * @param filter        Function to use as a filter.
		 * @param data          Arbitrary data value to pass through to the filter
		 *                      function.
		 */
		public static void TR_TraceHullFilter(float[/*3*/] pos,
									   float[/*3*/] vec,
									   float[/*3*/] mins,
									   float[/*3*/] maxs,
									   int flags,
									   TraceEntityFilter filter,
									   any? data = null)
		{ throw new NotImplementedException(); }

		/**
		 * Clips a ray to a particular entity.
		 *
		 * @param pos           Starting position of the ray.
		 * @param vec           Depending on RayType, it will be used as the ending
		 *                      point, or the direction angle.
		 * @param flags         Trace flags.
		 * @param rtype         Method to calculate the ray direction.
		 * @param entity        Entity to clip to.
		 */
		public static void TR_ClipRayToEntity(float[/*3*/] pos,
									   float[/*3*/] vec,
									   int flags,
									   RayType rtype,
									   int entity)
		{ throw new NotImplementedException(); }

		/**
		 * Clips a ray hull to a particular entity.
		 *
		 * @param pos           Starting position of the ray.
		 * @param vec           Ending position of the ray.
		 * @param mins          Hull minimum size.
		 * @param maxs          Hull maximum size.
		 * @param flags         Trace flags.
		 * @param entity        Entity to clip to.
		 */
		public static void TR_ClipRayHullToEntity(float[/*3*/] pos,
										   float[/*3*/] vec,
										   float[/*3*/] mins,
										   float[/*3*/] maxs,
										   int flags,
										   int entity)
		{ throw new NotImplementedException(); }

		/**
		 * Clips the current global ray (or hull) to a particular entity.
		 *
		 * @param flags         Trace flags.
		 * @param entity        Entity to clip to.
		 */
		public static void TR_ClipCurrentRayToEntity(int flags, int entity) { throw new NotImplementedException(); }

		/**
		 * Starts up a new trace ray using a new trace result.
		 *
		 * @param pos           Starting position of the ray.
		 * @param vec           Depending on RayType, it will be used as the ending
		 *                      point, or the direction angle.
		 * @param flags         Trace flags.
		 * @param rtype         Method to calculate the ray direction.
		 * @return              Ray trace handle, which must be closed via CloseHandle().
		 */
		public static Handle TR_TraceRayEx(float[/*3*/] pos,
									float[/*3*/] vec,
									int flags,
									RayType rtype)
		{ throw new NotImplementedException(); }

		/**
		 * Starts up a new trace hull using a new trace result.
		 *
		 * @param pos           Starting position of the ray.
		 * @param vec           Ending position of the ray.
		 * @param mins          Hull minimum size.
		 * @param maxs          Hull maximum size.
		 * @param flags         Trace flags.
		 * @return              Ray trace handle, which must be closed via CloseHandle().
		 */
		public static Handle TR_TraceHullEx(float[/*3*/] pos,
									 float[/*3*/] vec,
									 float[/*3*/] mins,
									 float[/*3*/] maxs,
									 int flags)
		{ throw new NotImplementedException(); }

		/**
		 * Starts up a new trace ray using a new trace result and a customized
		 * trace ray filter.
		 *
		 * Calling TR_Trace*Filter or TR_TraceRay*Ex from inside a filter
		 * function is currently not allowed and may not work.
		 *
		 * @param pos           Starting position of the ray.
		 * @param vec           Depending on RayType, it will be used as the ending
		 *                      point, or the direction angle.
		 * @param flags         Trace flags.
		 * @param rtype         Method to calculate the ray direction.
		 * @param filter        Function to use as a filter.
		 * @param data          Arbitrary data value to pass through to the filter function.
		 * @return              Ray trace handle, which must be closed via CloseHandle().
		 */
		public static Handle TR_TraceRayFilterEx(float[/*3*/] pos,
										  float[/*3*/] vec,
										  int flags,
										  RayType rtype,
										  TraceEntityFilter filter,
										  any? data = null)
		{ throw new NotImplementedException(); }

		/**
		 * Starts up a new trace hull using a new trace result and a customized
		 * trace ray filter.
		 *
		 * Calling TR_Trace*Filter or TR_Trace*FilterEx from inside a filter
		 * function is currently not allowed and may not work.
		 *
		 * @param pos           Starting position of the ray.
		 * @param vec           Ending position of the ray.
		 * @param mins          Hull minimum size.
		 * @param maxs          Hull maximum size.
		 * @param flags         Trace flags.
		 * @param filter        Function to use as a filter.
		 * @param data          Arbitrary data value to pass through to the filter function.
		 * @return              Ray trace handle, which must be closed via CloseHandle().
		 */
		public static Handle TR_TraceHullFilterEx(float[/*3*/] pos,
										   float[/*3*/] vec,
										   float[/*3*/] mins,
										   float[/*3*/] maxs,
										   int flags,
										   TraceEntityFilter filter,
										   any? data = null)
		{ throw new NotImplementedException(); }

		/**
		 * Clips a ray to a particular entity.
		 *
		 * @param pos           Starting position of the ray.
		 * @param vec           Depending on RayType, it will be used as the ending
		 *                      point, or the direction angle.
		 * @param flags         Trace flags.
		 * @param rtype         Method to calculate the ray direction.
		 * @param entity        Entity to clip to.
		 * @return              Ray trace handle, which must be closed via CloseHandle().
		 */
		public static Handle TR_ClipRayToEntityEx(float[/*3*/] pos,
										   float[/*3*/] vec,
										   int flags,
										   RayType rtype,
										   int entity)
		{ throw new NotImplementedException(); }

		/**
		 * Clips a ray hull to a particular entity.
		 *
		 * @param pos           Starting position of the ray.
		 * @param vec           Ending position of the ray.
		 * @param mins          Hull minimum size.
		 * @param maxs          Hull maximum size.
		 * @param flags         Trace flags.
		 * @param entity        Entity to clip to.
		 * @return              Ray trace handle, which must be closed via CloseHandle().
		 */
		public static Handle TR_ClipRayHullToEntityEx(float[/*3*/] pos,
											   float[/*3*/] vec,
											   float[/*3*/] mins,
											   float[/*3*/] maxs,
											   int flags,
											   int entity)
		{ throw new NotImplementedException(); }

		/**
		 * Clips the current global ray (or hull) to a particular entity.
		 *
		 * @param flags         Trace flags.
		 * @param entity        Entity to clip to.
		 * @return              Ray trace handle, which must be closed via CloseHandle().
		 */
		public static Handle TR_ClipCurrentRayToEntityEx(int flags, int entity) { throw new NotImplementedException(); }

		/**
		 * Returns the time fraction from a trace result (1.0 means no collision).
		 *
		 * @param hndl          A trace Handle, or INVALID_HANDLE to use a global trace result.
		 * @return              Time fraction value of the trace.
		 * @error               Invalid Handle.
		 */
		public static float TR_GetFraction(Handle hndl = INVALID_HANDLE) { throw new NotImplementedException(); }

		/**
		 * Returns the time fraction from a trace result when it left a solid.
		 * Only valid if trace started in solid
		 *
		 * @param hndl          A trace Handle, or INVALID_HANDLE to use a global trace result.
		 * @return              Time fraction left solid value of the trace.
		 * @error               Invalid Handle.
		 */
		public static float TR_GetFractionLeftSolid(Handle hndl = INVALID_HANDLE) { throw new NotImplementedException(); }

		/**
		 * Returns the starting position of a trace.
		 *
		 * @param hndl          A trace Handle, or INVALID_HANDLE to use a global trace result.
		 * @param pos           Vector buffer to store data in.
		 * @error               Invalid Handle.
		 */
		public static void TR_GetStartPosition(Handle hndl, float[/* 3 */] pos) { throw new NotImplementedException(); }

		/**
		 * Returns the collision position of a trace result.
		 *
		 * @param pos           Vector buffer to store data in.
		 * @param hndl          A trace Handle, or INVALID_HANDLE to use a global trace result.
		 * @error               Invalid Handle.
		 */
		public static void TR_GetEndPosition(float[/* 3 */] pos, Handle hndl = INVALID_HANDLE) { throw new NotImplementedException(); }

		/**
		 * Returns the entity index that collided with the trace.
		 *
		 * @param hndl          A trace Handle, or INVALID_HANDLE to use a global trace result.
		 * @return              Entity index or -1 for no collision.
		 * @error               Invalid Handle.
		 */
		public static int TR_GetEntityIndex(Handle hndl = INVALID_HANDLE) { throw new NotImplementedException(); }

		/**
		 * Returns the displacement flags for the surface that was hit. See DISPSURF_FLAG_*.
		 *
		 * @param hndl          A trace Handle, or INVALID_HANDLE to use a global trace result.
		 * @return              Displacement flags.
		 * @error               Invalid Handle.
		 */
		public static int TR_GetDisplacementFlags(Handle hndl = INVALID_HANDLE) { throw new NotImplementedException(); }

		/**
		 * Returns the name of the surface that was hit.
		 *
		 * @param hndl          A trace Handle, or INVALID_HANDLE to use a global trace result.
		 * @param buffer        Buffer to store surface name in
		 * @param maxlen        Maximum length of output buffer
		 * @error               Invalid Handle.
		 */
		public static void TR_GetSurfaceName(Handle hndl, string buffer, int maxlen) { throw new NotImplementedException(); }

		/**
		 * Returns the surface properties index of the surface that was hit.
		 *
		 * @param hndl          A trace Handle, or INVALID_HANDLE to use a global trace result.
		 * @return              Surface props.
		 * @error               Invalid Handle.
		 */
		public static int TR_GetSurfaceProps(Handle hndl = INVALID_HANDLE) { throw new NotImplementedException(); }

		/**
		 * Returns the surface flags. See SURF_*.
		 *
		 * @param hndl          A trace Handle, or INVALID_HANDLE to use a global trace result.
		 * @return              Surface flags.
		 * @error               Invalid Handle.
		 */
		public static int TR_GetSurfaceFlags(Handle hndl = INVALID_HANDLE) { throw new NotImplementedException(); }

		/**
		 * Returns the index of the physics bone that was hit.
		 *
		 * @param hndl          A trace Handle, or INVALID_HANDLE to use a global trace result.
		 * @return              Physics bone index.
		 * @error               Invalid Handle.
		 */
		public static int TR_GetPhysicsBone(Handle hndl = INVALID_HANDLE) { throw new NotImplementedException(); }

		/**
		 * Returns whether the entire trace was in a solid area.
		 *
		 * @param hndl          A trace Handle, or INVALID_HANDLE to use a global trace result.
		 * @return              True if entire trace was in a solid area, otherwise false.
		 * @error               Invalid Handle.
		 */
		public static bool TR_AllSolid(Handle hndl = INVALID_HANDLE) { throw new NotImplementedException(); }

		/**
		 * Returns whether the initial point was in a solid area.
		 *
		 * @param hndl          A trace Handle, or INVALID_HANDLE to use a global trace result.
		 * @return              True if initial point was in a solid area, otherwise false.
		 * @error               Invalid Handle.
		 */
		public static bool TR_StartSolid(Handle hndl = INVALID_HANDLE) { throw new NotImplementedException(); }

		/**
		 * Returns if there was any kind of collision along the trace ray.
		 *
		 * @param hndl          A trace Handle, or INVALID_HANDLE to use a global trace result.
		 * @return              True if any collision found, otherwise false.
		 * @error               Invalid Handle.
		 */
		public static bool TR_DidHit(Handle hndl = INVALID_HANDLE) { throw new NotImplementedException(); }

		/**
		 * Returns in which body hit group the trace collided if any.
		 *
		 * @param hndl          A trace Handle, or INVALID_HANDLE to use a global trace result.
		 * @return              Body hit group.
		 * @error               Invalid Handle.
		 */
		public static int TR_GetHitGroup(Handle hndl = INVALID_HANDLE) { throw new NotImplementedException(); }

		/**
		 * Returns in which hitbox the trace collided if any. 
		 *
		 * Note: if the entity that collided with the trace is the world entity, 
		 * then this function doesn't return an hitbox index but a static prop index.
		 *
		 * @param hndl          A trace Handle, or INVALID_HANDLE to use a global trace result.
		 * @return              Hitbox index (Or static prop index).
		 * @error               Invalid Handle.
		 */
		public static int TR_GetHitBoxIndex(Handle hndl = INVALID_HANDLE) { throw new NotImplementedException(); }

		/**
		 * Find the normal vector to the collision plane of a trace.
		 *
		 * @param hndl          A trace Handle, or INVALID_HANDLE to use a global trace result.
		 * @param normal        Vector buffer to store the vector normal to the collision plane
		 * @error               Invalid Handle
		 */
		public static void TR_GetPlaneNormal(Handle hndl, float[/* 3 */] normal) { throw new NotImplementedException(); }

		/**
		 * Tests a point to see if it's outside any playable area
		 *
		 * @param pos           Vector buffer to store data in.
		 * @return              True if outside world, otherwise false.
		 */
		public static bool TR_PointOutsideWorld(float[/* 3 */] pos) { throw new NotImplementedException(); }
	}
}
