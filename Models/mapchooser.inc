/**
 * vim: set ts=4 :
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
#if defined _mapchooser_included_
 #endinput
#endif
public const object _mapchooser_included_

enum NominateResult
{
	Nominate_Added,         /** The map was added to the nominate list */
	Nominate_Replaced,      /** A clients existing nomination was replaced */
	Nominate_AlreadyInVote, /** Specified map was already in the vote */
	Nominate_InvalidMap,    /** Mapname specified wasn't a valid map */
	Nominate_VoteFull       /** This will only occur if force was set to false */
};

enum MapChange
{
	MapChange_Instant,      /** Change map as soon as the voting results have come in */
	MapChange_RoundEnd,     /** Change map at the end of the round */
	MapChange_MapEnd        /** Change the sm_nextmap cvar */
};

/**
 * Attempt to add a map to the mapchooser map list.
 *
 * @param map           Map to add.
 * @param force         Should we force the map in even if it requires overwriting an existing nomination?
 * @param owner         Client index of the nominator. If the client disconnects the nomination will be removed.
 *                      Use 0 for constant nominations
 * @return              Nominate Result of the outcome
 */
public static NominateResult NominateMap(string map, bool force, int owner) { throw new NotImplementedException(); }

/**
 * Attempt to remove a map from the mapchooser map list.
 *
 * @param map           Map to remove.
 * @return              True if the nomination was found and removed, or false if the nomination was not found.
 */
public static bool RemoveNominationByMap(string map) { throw new NotImplementedException(); }

/**
 * Attempt to remove a map from the mapchooser map list.
 *
 * @param owner         Client index of the nominator.
 * @return              True if the nomination was found and removed, or false if the nomination was not found.
 */
public static bool RemoveNominationByOwner(int owner) { throw new NotImplementedException(); }

/**
 * Gets the current list of excluded maps.
 *
 * @param array         An ADT array handle to add the map strings to.
 */
public static void GetExcludeMapList(ArrayList array) { throw new NotImplementedException(); }

/**
 * Gets the current list of nominated maps.
 *
 * @param maparray      An ADT array handle to add the map strings to.
 * @param ownerarray    An optional ADT array handle to add the nominator client indexes to.
 */
public static void GetNominatedMapList(ArrayList maparray, ArrayList ownerarray = null) { throw new NotImplementedException(); }

/**
 * Checks if MapChooser will allow a vote
 *
 * @return              True if a vote can be held, or false if mapchooser is already holding a vote.
 */
public static bool CanMapChooserStartVote() { throw new NotImplementedException(); }

/**
 * Initiates a MapChooser map vote
 *
 * Note: If no input array is specified mapchooser will use its internal list. This includes
 * any nominations and excluded maps (as per mapchoosers convars).
 *
 * @param when          MapChange consant of when the resulting mapchange should occur.
 * @param inputarray    ADT array list of maps to add to the vote.
 */
public static void InitiateMapChooserVote(MapChange when, ArrayList inputarray=null) { throw new NotImplementedException(); }

/**
 * Checks if MapChooser's end of map vote has completed.
 *
 * @return              True if complete, false otherwise.
 */
public static bool HasEndOfMapVoteFinished() { throw new NotImplementedException(); }

/**
 * Checks if MapChooser is set to run an end of map vote.
 *
 * @return              True if enabled, false otherwise.
 */
public static bool EndOfMapVoteEnabled() { throw new NotImplementedException(); }

/**
 * Called when mapchooser removes a nomination from its list.
 * Nominations cleared on map start will not trigger this forward
 */
public static override void OnNominationRemoved(string map, int owner) { throw new NotImplementedException(); }

/**
 * Called when mapchooser starts a Map Vote.
 */
public static override void OnMapVoteStarted() { throw new NotImplementedException(); }

public SharedPlugin __pl_mapchooser =
{
	name = "mapchooser",
	file = "mapchooser.smx",
#if defined REQUIRE_PLUGIN
	required = 1,
#else
	required = 0,
#endif
};

public void __pl_mapchooser_SetNTVOptional()
{
	MarkNativeAsOptional("NominateMap") { throw new NotImplementedException(); }
	MarkNativeAsOptional("RemoveNominationByMap") { throw new NotImplementedException(); }
	MarkNativeAsOptional("RemoveNominationByOwner") { throw new NotImplementedException(); }
	MarkNativeAsOptional("GetExcludeMapList") { throw new NotImplementedException(); }
	MarkNativeAsOptional("GetNominatedMapList") { throw new NotImplementedException(); }
	MarkNativeAsOptional("CanMapChooserStartVote") { throw new NotImplementedException(); }
	MarkNativeAsOptional("InitiateMapChooserVote") { throw new NotImplementedException(); }
	MarkNativeAsOptional("HasEndOfMapVoteFinished") { throw new NotImplementedException(); }
	MarkNativeAsOptional("EndOfMapVoteEnabled") { throw new NotImplementedException(); }
}
	}
}