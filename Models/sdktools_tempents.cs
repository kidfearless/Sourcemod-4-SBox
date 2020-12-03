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

		/**
		 * Called when a temp entity is going to be sent.
		 *
		 * @param te_name       TE name.
		 * @param Players       Array containing target player indexes.
		 * @param numClients    Number of players in the array.
		 * @param delay         Delay in seconds to send the TE.
		 * @return              Plugin_Continue to allow the transmission of the TE, Plugin_Stop to block it.
		 */
		public delegate Action TEHook(string te_name, /*const*/ int[] Players, int numClients, float delay);

		/**
		 * Hooks a temp entity.
		 *
		 * @param te_name       TE name to hook.
		 * @param hook          Function to use as a hook.
		 * @error               Temp Entity name not available or invalid function hook.
		 */
		public static void AddTempEntHook(string te_name, TEHook hook) { throw new NotImplementedException(); }

		/**
		 * Removes a temp entity hook.
		 *
		 * @param te_name       TE name to unhook.
		 * @param hook          Function used for the hook.
		 * @error               Temp Entity name not available or invalid function hook.
		 */
		public static void RemoveTempEntHook(string te_name, TEHook hook) { throw new NotImplementedException(); }

		/**
		 * Starts a temp entity transmission.
		 *
		 * @param te_name       TE name.
		 * @error               Temp Entity name not available.
		 */
		public static void TE_Start(string te_name) { throw new NotImplementedException(); }

		/**
		 * Checks if a certain TE public exists.
		 *
		 * @param prop          public to use.
		 * @return              True if the public exists, otherwise false.
		 */
		public static bool TE_IsValidProp(string prop) { throw new NotImplementedException(); }

		/**
		 * Sets an integer value in the current temp entity.
		 *
		 * @param prop          public to use.
		 * @param value         Integer value to set.
		 * @error               public not found.
		 */
		public static void TE_WriteNum(string prop, int value) { throw new NotImplementedException(); }

		/**
		 * Reads an integer value in the current temp entity.
		 *
		 * @param prop          public to use.
		 * @return              public value.
		 * @error               public not found.
		 */
		public static int TE_ReadNum(string prop) { throw new NotImplementedException(); }

		/**
		 * Sets a floating point number in the current temp entity.
		 *
		 * @param prop          public to use.
		 * @param value         Floating point number to set.
		 * @error               public not found.
		 */
		public static void TE_WriteFloat(string prop, float value) { throw new NotImplementedException(); }

		/**
		 * Reads a floating point number in the current temp entity.
		 *
		 * @param prop          public to use.
		 * @return              public value.
		 * @error               public not found.
		 */
		public static float TE_ReadFloat(string prop) { throw new NotImplementedException(); }

		/**
		 * Sets a vector in the current temp entity.
		 *
		 * @param prop          public to use.
		 * @param vector        Vector to set.
		 * @error               public not found.
		 */
		public static void TE_WriteVector(string prop, float[/*3*/] vector) { throw new NotImplementedException(); }

		/**
		 * Reads a vector in the current temp entity.
		 *
		 * @param prop          public to use.
		 * @param vector        Vector to read.
		 * @error               public not found.
		 */
		public static void TE_ReadVector(string prop, float[/* 3 */] vector) { throw new NotImplementedException(); }

		/**
		 * Sets a QAngle in the current temp entity.
		 *
		 * @param prop          public to use.
		 * @param angles        Angles to set.
		 * @error               public not found.
		 */
		public static void TE_WriteAngles(string prop, float[/*3*/] angles) { throw new NotImplementedException(); }

		/**
		 * Sets an array of floats in the current temp entity.
		 *
		 * @param prop          public to use.
		 * @param array         Array of values to copy.
		 * @param arraySize     Number of values to copy.
		 * @error               public not found.
		 */
		public static void TE_WriteFloatArray(string prop, float[][] array, int arraySize) { throw new NotImplementedException(); }

		/**
		 * Sends the current temp entity to one or more clients.
		 *
		 * @param clients       Array containing player indexes to broadcast to.
		 * @param numClients    Number of players in the array.
		 * @param delay         Delay in seconds to send the TE.
		 * @error               Invalid client index or client not in game.
		 */
		public static void TE_Send(/*const*/ int[] clients, int numClients, float delay = 0.0f) { throw new NotImplementedException(); }

		/**
		 * Sets an encoded entity index in the current temp entity.
		 * (This is usually used for m_nStartEntity and m_nEndEntity).
		 *
		 * @param prop          public to use.
		 * @param value         Value to set.
		 * @error               public not found.
		 */
		public static void TE_WriteEncodedEnt(string prop, int value)
		{
			int encvalue = (value & 0x0FFF) | ((1 & 0xF) << 12);
			TE_WriteNum(prop, encvalue);
		}

		/**
		 * Broadcasts the current temp entity to all clients.
		 * @note See TE_Start().
		 *
		 * @param delay         Delay in seconds to send the TE.
		 */
		public static void TE_SendToAll(float delay = 0.0f)
		{
			int total = 0;
			int[] clients = new int[MaxClients];
			for (int i = 1; i <= MaxClients; i++)
			{
				if (IsClientInGame(i))
				{
					clients[total++] = i;
				}
			}
			TE_Send(clients, total, delay);
		}

		/**
		 * Sends the current TE to only a client.
		 * @note See TE_Start().
		 *
		 * @param client        Client to send to.
		 * @param delay         Delay in seconds to send the TE.
		 * @error               Invalid client index or client not in game.
		 */
		public static void TE_SendToClient(int client, float delay = 0.0f)
		{
			int[] players = new int[1];

			players[0] = client;

			TE_Send(players, 1, delay);
		}

		/**
		 * Sends the current TE to all clients that are in
		 * visible or audible range of the origin.
		 * @note See TE_Start().
		 * @note See GetClientsInRange()
		 *
		 * @param origin        Coordinates from which to test range.
		 * @param rangeType     Range type to use for filtering clients.
		 * @param delay         Delay in seconds to send the TE.
		 */
		public static void TE_SendToAllInRange(float[/*3*/] origin, ClientRangeType rangeType, float delay = 0.0f)
		{
			int[] clients = new int[MaxClients];
			int total = GetClientsInRange(origin, rangeType, clients, MaxClients);
			TE_Send(clients, total, delay);
		}
	}
}
