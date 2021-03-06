/**
 * vim: set ts=4 :
 * =============================================================================
 * SourceMod (C)2004-2011 AlliedModders LLC.  All rights reserved.
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

		public enum RoundState
		{
			// initialize the game, create teams
			RoundState_Init,

			//Before players have joined the game. Periodically checks to see if enough players are ready
			//to start a game. Also reverts to this when there are no active players
			RoundState_Pregame,

			//The game is about to start, wait a bit and spawn everyone
			RoundState_StartGame,

			//All players are respawned, frozen in place
			RoundState_Preround,

			//Round is on, playing normally
			RoundState_RoundRunning,

			//Someone has won the round
			RoundState_TeamWin,

			//Noone has won, manually restart the game, reset scores
			RoundState_Restart,

			//Noone has won, restart the game
			RoundState_Stalemate,

			//Game is over, showing the scoreboard etc
			RoundState_GameOver,

			//Game is over, doing bonus round stuff
			RoundState_Bonus,

			//Between rounds
			RoundState_BetweenRounds
		};

		public const int 
			// initialize the game, create teams
			RoundState_Init = 0,

			//Before players have joined the game. Periodically checks to see if enough players are ready
			//to start a game. Also reverts to this when there are no active players
			RoundState_Pregame = 1,

			//The game is about to start, wait a bit and spawn everyone
			RoundState_StartGame = 2,

			//All players are respawned, frozen in place
			RoundState_Preround = 3,

			//Round is on, playing normally
			RoundState_RoundRunning = 4,

			//Someone has won the round
			RoundState_TeamWin = 5,

			//Noone has won, manually restart the game, reset scores
			RoundState_Restart = 6,

			//Noone has won, restart the game
			RoundState_Stalemate = 7,

			//Game is over, showing the scoreboard etc
			RoundState_GameOver = 8,

			//Game is over, doing bonus round stuff
			RoundState_Bonus = 9,

			//Between rounds
			RoundState_BetweenRounds = 10;

		/**
		 * Retrieves an integer value from a public of the gamerules entity.
		 *
		 * @param prop          public name.
		 * @param size          Number of bytes to read (valid values are 1, 2, or 4).
		 *                      This value is auto-detected, and the size parameter is
		 *                      only used as a fallback in case detection fails.
		 * @param element       Element # (starting from 0) if public is an array.
		 * @return              Value at the given public offset.
		 * @error               Not supported.
		 */
		public static int GameRules_GetProp(string prop, int size = 4, int element = 0) { throw new NotImplementedException(); }

		/**
		 * Sets an integer value for a public of the gamerules entity.
		 *
		 * @param prop          public name.
		 * @param value         Value to set.
		 * @param size          Number of bytes to write (valid values are 1, 2, or 4).
		 *                      This value is auto-detected, and the size parameter is
		 *                      only used as a fallback in case detection fails.
		 * @param element       Element # (starting from 0) if public is an array.
		 * @param changeState   This parameter is ignored.
		 * @error               Not supported.
		 */
		public static void GameRules_SetProp(string prop, any value, int size = 4, int element = 0, bool changeState = false) { throw new NotImplementedException(); }

		/**
		 * Retrieves a float value from a public of the gamerules entity.
		 *
		 * @param prop          public name.
		 * @param element       Element # (starting from 0) if public is an array.
		 * @return              Value at the given public offset.
		 * @error               Not supported.
		 */
		public static float GameRules_GetPropFloat(string prop, int element = 0) { throw new NotImplementedException(); }

		/**
		 * Sets a float value for a public of the gamerules entity.
		 *
		 * @param prop          public name.
		 * @param value         Value to set.
		 * @param element       Element # (starting from 0) if public is an array.
		 * @param changeState   This parameter is ignored.
		 * @error               Not supported.
		 */
		public static void GameRules_SetPropFloat(string prop, float value, int element = 0, bool changeState = false) { throw new NotImplementedException(); }

		/**
		 * Retrieves a entity index from a public of the gamerules entity.
		 *
		 * @param prop          public name.
		 * @param element       Element # (starting from 0) if public is an array.
		 * @return              Entity index at the given property.
		 *                      If there is no entity, or the entity is not valid,
		 *                      then -1 is returned.
		 * @error               Not supported.
		 */
		public static int GameRules_GetPropEnt(string prop, int element = 0) { throw new NotImplementedException(); }

		/**
		 * Sets an entity index for a public of the gamerules entity.
		 *
		 * @param prop          public name.
		 * @param other         Entity index to set, or -1 to unset.
		 * @param element       Element # (starting from 0) if public is an array.
		 * @param changeState   This parameter is ignored.
		 * @error               Not supported.
		 */
		public static void GameRules_SetPropEnt(string prop, int other, int element = 0, bool changeState = false) { throw new NotImplementedException(); }

		/**
		 * Retrieves a vector of floats from the gamerules entity, given a named network property.
		 *
		 * @param prop          public name.
		 * @param vec           Vector buffer to store data in.
		 * @param element       Element # (starting from 0) if public is an array.
		 * @error               Not supported.
		 */
		public static void GameRules_GetPropVector(string prop, float[/* 3 */] vec, int element = 0) { throw new NotImplementedException(); }

		/**
		 * Sets a vector of floats in the gamerules entity, given a named network property.
		 *
		 * @param prop          public name.
		 * @param vec           Vector to set.
		 * @param element       Element # (starting from 0) if public is an array.
		 * @param changeState   This parameter is ignored.
		 * @error               Not supported.
		 */
		public static void GameRules_SetPropVector(string prop, float[/*3*/] vec, int element = 0, bool changeState = false) { throw new NotImplementedException(); }

		/**
		 * Gets a gamerules public as a string.
		 *
		 * @param prop          public to use.
		 * @param buffer        Destination string buffer.
		 * @param maxlen        Maximum length of output string buffer.
		 * @return              Number of non-null bytes written.
		 * @error               Not supported.
		 */
		public static int GameRules_GetPropString(string prop, string buffer, int maxlen) { throw new NotImplementedException(); }

		/**
		 * Sets a gamerules public as a string.
		 *
		 * @param prop          public to use.
		 * @param buffer        String to set.
		 * @param changeState   This parameter is ignored.
		 * @return              Number of non-null bytes written.
		 * @error               Not supported.
		 */
		public static int GameRules_SetPropString(string prop, string buffer, bool changeState = false) { throw new NotImplementedException(); }

		/**
		 * Gets the current round state.
		 *
		 * @return              Round state.
		 * @error               Game doesn't support round state.
		 */
		public static int GameRules_GetRoundState()
		{
			return (GameRules_GetProp("m_iRoundState"));
		}
	}
}
