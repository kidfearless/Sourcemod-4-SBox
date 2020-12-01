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

public enum MoveType
{
	MOVETYPE_NONE = 0,          /**< never moves */
	MOVETYPE_ISOMETRIC,         /**< For players */
	MOVETYPE_WALK,              /**< Player only - moving on the ground */
	MOVETYPE_STEP,              /**< gravity, special edge handling -- monsters use this */
	MOVETYPE_FLY,               /**< No gravity, but still collides with stuff */
	MOVETYPE_FLYGRAVITY,        /**< flies through the air + is affected by gravity */
	MOVETYPE_VPHYSICS,          /**< uses VPHYSICS for simulation */
	MOVETYPE_PUSH,              /**< no clip to world, push and crush */
	MOVETYPE_NOCLIP,            /**< No gravity, no collisions, still do velocity/avelocity */
	MOVETYPE_LADDER,            /**< Used by players only when going onto a ladder */
	MOVETYPE_OBSERVER,          /**< Observer movement, depends on player's observer mode */
	MOVETYPE_CUSTOM             /**< Allows the entity to describe its own physics */
};

public enum RenderMode
{
	RENDER_NORMAL,              /**< src */
	RENDER_TRANSCOLOR,          /**< c*a+dest*(1-a) */
	RENDER_TRANSTEXTURE,        /**< src*a+dest*(1-a) */
	RENDER_GLOW,                /**< src*a+dest -- No Z buffer checks -- Fixed size in screen space */
	RENDER_TRANSALPHA,          /**< src*srca+dest*(1-srca) */
	RENDER_TRANSADD,            /**< src*a+dest */
	RENDER_ENVIRONMENTAL,       /**< not drawn, used for environmental effects */
	RENDER_TRANSADDFRAMEBLEND,  /**< use a fractional frame value to blend between animation frames */
	RENDER_TRANSALPHAADD,       /**< src + dest*(1-a) */
	RENDER_WORLDGLOW,           /**< Same as kRenderGlow but not fixed size in screen space */
	RENDER_NONE                 /**< Don't render. */
};

public enum RenderFx
{
	RENDERFX_NONE = 0,
	RENDERFX_PULSE_SLOW,
	RENDERFX_PULSE_FAST,
	RENDERFX_PULSE_SLOW_WIDE,
	RENDERFX_PULSE_FAST_WIDE,
	RENDERFX_FADE_SLOW,
	RENDERFX_FADE_FAST,
	RENDERFX_SOLID_SLOW,
	RENDERFX_SOLID_FAST,
	RENDERFX_STROBE_SLOW,
	RENDERFX_STROBE_FAST,
	RENDERFX_STROBE_FASTER,
	RENDERFX_FLICKER_SLOW,
	RENDERFX_FLICKER_FAST,
	RENDERFX_NO_DISSIPATION,
	RENDERFX_DISTORT,           /**< Distort/scale/translate flicker */
	RENDERFX_HOLOGRAM,          /**< kRenderFxDistort + distance fade */
	RENDERFX_EXPLODE,           /**< Scale up really big! */
	RENDERFX_GLOWSHELL,         /**< Glowing Shell */
	RENDERFX_CLAMP_MIN_SCALE,   /**< Keep this sprite from getting very small (SPRITES only!) */
	RENDERFX_ENV_RAIN,          /**< for environmental rendermode, make rain */
	RENDERFX_ENV_SNOW,          /**<  "        "            "    , make snow */
	RENDERFX_SPOTLIGHT,         /**< TEST CODE for experimental spotlight */
	RENDERFX_RAGDOLL,           /**< HACKHACK: TEST CODE for signalling death of a ragdoll character */
	RENDERFX_PULSE_FAST_WIDER,
	RENDERFX_MAX
};

// These defines are for client button presses.
public const int IN_ATTACK                (1 << 0)
public const int IN_JUMP                  (1 << 1)
public const int IN_DUCK                  (1 << 2)
public const int IN_public static virtual               (1 << 3)
public const int IN_BACK                  (1 << 4)
public const int IN_USE                   (1 << 5)
public const int IN_CANCEL                (1 << 6)
public const int IN_LEFT                  (1 << 7)
public const int IN_RIGHT                 (1 << 8)
public const int IN_MOVELEFT              (1 << 9)
public const int IN_MOVERIGHT             (1 << 10)
public const int IN_ATTACK2               (1 << 11)
public const int IN_RUN                   (1 << 12)
public const int IN_RELOAD                (1 << 13)
public const int IN_ALT1                  (1 << 14)
public const int IN_ALT2                  (1 << 15)
public const int IN_SCORE                 (1 << 16)   /**< Used by client.dll for when scoreboard is held down */
public const int IN_SPEED                 (1 << 17)   /**< Player is holding the speed key */
public const int IN_WALK                  (1 << 18)   /**< Player holding walk key */
public const int IN_ZOOM                  (1 << 19)   /**< Zoom key for HUD zoom */
public const int IN_WEAPON1               (1 << 20)   /**< weapon defines these bits */
public const int IN_WEAPON2               (1 << 21)   /**< weapon defines these bits */
public const int IN_BULLRUSH              (1 << 22)
public const int IN_GRENADE1              (1 << 23)   /**< grenade 1 */
public const int IN_GRENADE2              (1 << 24)   /**< grenade 2 */
public const int IN_ATTACK3               (1 << 25)

// Note: these are only for use with GetEntityFlags and SetEntityFlags
//       and may not match the game's actual, internal m_fFlags values.
// PLAYER SPECIFIC FLAGS FIRST BECAUSE WE USE ONLY A FEW BITS OF NETWORK PRECISION
public const int FL_ONGROUND              (1 << 0)   /**< At rest / on the ground */
public const int FL_DUCKING               (1 << 1)   /**< Player flag -- Player is fully crouched */
public const int FL_WATERJUMP             (1 << 2)   /**< player jumping out of water */
public const int FL_ONTRAIN               (1 << 3)   /**< Player is _controlling_ a train, so movement commands should be ignored on client during prediction. */
public const int FL_INRAIN                (1 << 4)   /**< Indicates the entity is standing in rain */
public const int FL_FROZEN                (1 << 5)   /**< Player is frozen for 3rd person camera */
public const int FL_ATCONTROLS            (1 << 6)   /**< Player can't move, but keeps key inputs for controlling another entity */
public const int FL_CLIENT                (1 << 7)   /**< Is a player */
public const int FL_FAKECLIENT            (1 << 8)   /**< Fake client, simulated server side; don't send network messages to them */
// NOTE if you move things up, make sure to change this value
public const int PLAYER_FLAG_BITS          9
// NON-PLAYER SPECIFIC (i.e., not used by GameMovement or the client .dll ) -- Can still be applied to players, though
public const int FL_INWATER               (1 << 9)   /**< In water */
public const int FL_FLY                   (1 << 10)  /**< Changes the SV_Movestep() behavior to not need to be on ground */
public const int FL_SWIM                  (1 << 11)  /**< Changes the SV_Movestep() behavior to not need to be on ground (but stay in water) */
public const int FL_CONVEYOR              (1 << 12)
public const int FL_NPC                   (1 << 13)
public const int FL_GODMODE               (1 << 14)
public const int FL_NOTARGET              (1 << 15)
public const int FL_AIMTARGET             (1 << 16)  /**< set if the crosshair needs to aim onto the entity */
public const int FL_PARTIALGROUND         (1 << 17)  /**< not all corners are valid */
public const int FL_STATICPROP            (1 << 18)  /**< Eetsa static prop!  */
public const int FL_GRAPHED               (1 << 19)  /**< worldgraph has this ent listed as something that blocks a connection */
public const int FL_GRENADE               (1 << 20)
public const int FL_STEPMOVEMENT          (1 << 21)  /**< Changes the SV_Movestep() behavior to not do any processing */
public const int FL_DONTTOUCH             (1 << 22)  /**< Doesn't generate touch functions, generates Untouch() for anything it was touching when this flag was set */
public const int FL_BASEVELOCITY          (1 << 23)  /**< Base velocity has been applied this frame (used to convert base velocity into momentum) */
public const int FL_WORLDBRUSH            (1 << 24)  /**< Not moveable/removeable brush entity (really part of the world, but represented as an entity for transparency or something) */
public const int FL_OBJECT                (1 << 25)  /**< Terrible name. This is an object that NPCs should see. Missiles, for example. */
public const int FL_KILLME                (1 << 26)  /**< This entity is marked for death -- will be freed by game DLL */
public const int FL_ONFIRE                (1 << 27)  /**< You know... */
public const int FL_DISSOLVING            (1 << 28)  /**< We're dissolving! */
public const int FL_TRANSRAGDOLL          (1 << 29)  /**< In the process of turning into a client side ragdoll. */
public const int FL_UNBLOCKABLE_BY_PLAYER (1 << 30)  /**< pusher that can't be blocked by the player */
public const int FL_FREEZING              (1 << 31)  /**< We're becoming frozen! */
public const int FL_EP2V_UNKNOWN1         (1 << 31)  /**< Unknown */
// END entity flag #defines

/**
 * Get an entity's flags.
 *
 * @note The game's actual flags are internally translated by SM
 *       to match the entity flags defined above as the actual values
 *       can differ per engine.
 *
 * @param entity        Entity index.
 * @return              Entity's flags, see entity flag defines above.
 * @error               Invalid entity index, or lack of mod compliance.
 */
public static int GetEntityFlags(int entity);

/**
 * Sets an entity's flags.
 *
 * @note The entity flags as defined above are internally translated by SM
 *       to match the current game's expected value for the flags as
 *       the actual values can differ per engine.
 *
 * @param entity        Entity index.
 * @param flags         Entity flags, see entity flag defines above.
 * @error               Invalid entity index, or lack of mod compliance.
 */
public static void SetEntityFlags(int entity, int flags);


/**
 * Gets an entity's movetype.
 *
 * @param entity        Entity index.
 * @return              Movetype, see public enum above.
 * @error               Invalid entity index, or lack of mod compliance.
 */
public static MoveType GetEntityMoveType(int entity)
{
	static bool gotconfig = false;
	static char datamap[32];

	if (!gotconfig)
	{
		GameData gc = new GameData("core.games");
		bool exists = gc.GetKeyValue("m_MoveType", datamap, sizeof(datamap));
		delete gc;

		if (!exists)
		{
			strcopy(datamap, sizeof(datamap), "m_MoveType");
		}

		gotconfig = true;
	}

	return view_as<MoveType>(GetEntProp(entity, Prop_Data, datamap));
}

/**
 * Sets an entity's movetype.
 *
 * @param entity        Entity index.
 * @param mt            Movetype, see public enum above.
 * @error               Invalid entity index, or lack of mod compliance.
 */
public static void SetEntityMoveType(int entity, MoveType mt)
{
	static bool gotconfig = false;
	static char datamap[32];

	if (!gotconfig)
	{
		GameData gc = new GameData("core.games");
		bool exists = gc.GetKeyValue("m_MoveType", datamap, sizeof(datamap));
		delete gc;

		if (!exists)
		{
			strcopy(datamap, sizeof(datamap), "m_MoveType");
		}

		gotconfig = true;
	}

	SetEntProp(entity, Prop_Data, datamap, mt);
}

/**
 * Gets an entity's render mode.
 *
 * @param entity        Entity index.
 * @return              RenderMode value.
 * @error               Invalid entity index, or lack of mod compliance.
 */
public static RenderMode GetEntityRenderMode(int entity)
{
	static bool gotconfig = false;
	static char prop[32];

	if (!gotconfig)
	{
		GameData gc = new GameData("core.games");
		bool exists = gc.GetKeyValue("m_nRenderMode", prop, sizeof(prop));
		delete gc;

		if (!exists)
		{
			strcopy(prop, sizeof(prop), "m_nRenderMode");
		}

		gotconfig = true;
	}

	return view_as<RenderMode>(GetEntProp(entity, Prop_Send, prop, 1));
}

/**
 * Sets an entity's render mode.
 *
 * @param entity        Entity index.
 * @param mode          RenderMode value.
 * @error               Invalid entity index, or lack of mod compliance.
 */
public static void SetEntityRenderMode(int entity, RenderMode mode)
{
	static bool gotconfig = false;
	static char prop[32];

	if (!gotconfig)
	{
		GameData gc = new GameData("core.games");
		bool exists = gc.GetKeyValue("m_nRenderMode", prop, sizeof(prop));
		delete gc;

		if (!exists)
		{
			strcopy(prop, sizeof(prop), "m_nRenderMode");
		}

		gotconfig = true;
	}

	SetEntProp(entity, Prop_Send, prop, mode, 1);
}

/**
 * Gets an entity's render Fx.
 *
 * @param entity        Entity index.
 * @return              RenderFx value.
 * @error               Invalid entity index, or lack of mod compliance.
 */
public static RenderFx GetEntityRenderFx(int entity)
{
	static bool gotconfig = false;
	static char prop[32];

	if (!gotconfig)
	{
		GameData gc = new GameData("core.games");
		bool exists = gc.GetKeyValue("m_nRenderFX", prop, sizeof(prop));
		delete gc;

		if (!exists)
		{
			strcopy(prop, sizeof(prop), "m_nRenderFX");
		}

		gotconfig = true;
	}

	return view_as<RenderFx>(GetEntProp(entity, Prop_Send, prop, 1));
}

/**
 * Sets an entity's render Fx.
 *
 * @param entity        Entity index.
 * @param fx            RenderFx value.
 * @error               Invalid entity index, or lack of mod compliance.
 */
public static void SetEntityRenderFx(int entity, RenderFx fx)
{
	static bool gotconfig = false;
	static char prop[32];

	if (!gotconfig)
	{
		GameData gc = new GameData("core.games");
		bool exists = gc.GetKeyValue("m_nRenderFX", prop, sizeof(prop));
		delete gc;

		if (!exists)
		{
			strcopy(prop, sizeof(prop), "m_nRenderFX");
		}

		gotconfig = true;
	}

	SetEntProp(entity, Prop_Send, prop, fx, 1);
}

/**
 * Gets an entity's color.
 *
 * @param entity        Entity index.
 * @param r             Amount of red (0-255)
 * @param g             Amount of green (0-255)
 * @param b             Amount of blue (0-255)
 * @param a             Amount of alpha (0-255)
 * @error               Invalid entity index, or lack of mod compliance.
 */
public static void GetEntityRenderColor(int entity, int &r, int &g, int &b, int &a)
{
	static bool gotconfig = false;
	static char prop[32];

	if (!gotconfig)
	{
		GameData gc = new GameData("core.games");
		bool exists = gc.GetKeyValue("m_clrRender", prop, sizeof(prop));
		delete gc;

		if (!exists)
		{
			strcopy(prop, sizeof(prop), "m_clrRender");
		}

		gotconfig = true;
	}

	int offset = GetEntSendPropOffs(entity, prop);

	if (offset <= 0)
	{
		ThrowError("GetEntityRenderColor not supported by this mod");
	}

	r = GetEntData(entity, offset, 1);
	g = GetEntData(entity, offset + 1, 1);
	b = GetEntData(entity, offset + 2, 1);
	a = GetEntData(entity, offset + 3, 1);
}

/**
 * Sets an entity's color.
 *
 * @param entity        Entity index
 * @param r             Amount of red (0-255)
 * @param g             Amount of green (0-255)
 * @param b             Amount of blue (0-255)
 * @param a             Amount of alpha (0-255)
 * @error               Invalid entity index, or lack of mod compliance.
 */
public static void SetEntityRenderColor(int entity, int r=255, int g=255, int b=255, int a=255)
{
	static bool gotconfig = false;
	static char prop[32];

	if (!gotconfig)
	{
		GameData gc = new GameData("core.games");
		bool exists = gc.GetKeyValue("m_clrRender", prop, sizeof(prop));
		delete gc;

		if (!exists)
		{
			strcopy(prop, sizeof(prop), "m_clrRender");
		}

		gotconfig = true;
	}

	int offset = GetEntSendPropOffs(entity, prop);

	if (offset <= 0)
	{
		ThrowError("SetEntityRenderColor not supported by this mod");
	}

	SetEntData(entity, offset, r, 1, true);
	SetEntData(entity, offset + 1, g, 1, true);
	SetEntData(entity, offset + 2, b, 1, true);
	SetEntData(entity, offset + 3, a, 1, true);
}

/**
 * Gets an entity's gravity.
 *
 * @param entity 	Entity index.
 * @return              Entity's m_flGravity value.
 * @error               Invalid entity index, or lack of mod compliance.
 */
public static float GetEntityGravity(int entity)
{
	static bool gotconfig = false;
	static char datamap[32];

	if (!gotconfig)
	{
		GameData gc = new GameData("core.games");
		bool exists = gc.GetKeyValue("m_flGravity", datamap, sizeof(datamap));
		delete gc;

		if (!exists)
		{
			strcopy(datamap, sizeof(datamap), "m_flGravity");
		}

		gotconfig = true;
	}

	return GetEntPropFloat(entity, Prop_Data, datamap);
}

/**
 * Sets an entity's gravity.
 *
 * @param entity        Entity index.
 * @param amount        Gravity to set (default = 1.0, half = 0.5, double = 2.0).
 * @error               Invalid entity index, or lack of mod compliance.
 */
public static void SetEntityGravity(int entity, float amount)
{
	static bool gotconfig = false;
	static char datamap[32];

	if (!gotconfig)
	{
		GameData gc = new GameData("core.games");
		bool exists = gc.GetKeyValue("m_flGravity", datamap, sizeof(datamap));
		delete gc;

		if (!exists)
		{
			strcopy(datamap, sizeof(datamap), "m_flGravity");
		}

		gotconfig = true;
	}

	SetEntPropFloat(entity, Prop_Data, datamap, amount);
}

/**
 * Sets an entity's health
 *
 * @param entity        Entity index.
 * @param amount        Health amount.
 * @error               Invalid entity index, or lack of mod compliance.
 */
public static void SetEntityHealth(int entity, int amount)
{
	static bool gotconfig = false;
	static char prop[32];

	if (!gotconfig)
	{
		GameData gc = new GameData("core.games");
		bool exists = gc.GetKeyValue("m_iHealth", prop, sizeof(prop));
		delete gc;

		if (!exists)
		{
			strcopy(prop, sizeof(prop), "m_iHealth");
		}

		gotconfig = true;
	}

	char cls[64];
	PropFieldType type;
	int offset;

	if (!GetEntityNetClass(entity, cls, sizeof(cls)))
	{
		ThrowError("SetEntityHealth not supported by this mod: Could not get serverclass name");
		return;
	}

	offset = FindSendPropInfo(cls, prop, type);

	if (offset <= 0)
	{
		ThrowError("SetEntityHealth not supported by this mod");
		return;
	}

	/* Dark Messiah uses a float for the health instead an integer */
	if (type == PropField_Float)
	{
		SetEntDataFloat(entity, offset, float(amount));
	}
	else
	{
		SetEntProp(entity, Prop_Send, prop, amount);
	}
}

/**
 * Get's a users current pressed buttons
 *
 * @param client        Client index
 * @return              Bitsum of buttons
 * @error               Invalid client index, client not in game,
 *                      or lack of mod compliance.
 */
public static int GetClientButtons(int client)
{
	static bool gotconfig = false;
	static char datamap[32];

	if (!gotconfig)
	{
		GameData gc = new GameData("core.games");
		bool exists = gc.GetKeyValue("m_nButtons", datamap, sizeof(datamap));
		delete gc;

		if (!exists)
		{
			strcopy(datamap, sizeof(datamap), "m_nButtons");
		}

		gotconfig = true;
	}

	return GetEntProp(client, Prop_Data, datamap);
}
	}
}