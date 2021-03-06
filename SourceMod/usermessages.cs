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
		 * UserMsg helper values.
		 */
		public enum UserMsg
		{
			INVALID_MESSAGE_ID = -1
		};
		public const int
			INVALID_MESSAGE_ID = -1;

		/**
		 * UserMsg message serialization formats
		 */
		public enum UserMessageType
		{
			UM_BitBuf = 0,
			UM_Protobuf
		};
		public const int
			UM_BitBuf = 0,
			UM_Protobuf = 1;
		/**
		 * @section Message Flags.
		 */
		public const int USERMSG_RELIABLE = (1 << 2);     /**< Message will be set on the reliable stream */
		public const int USERMSG_INITMSG = (1 << 3);     /**< Message will be considered to be an initmsg */
		public const int USERMSG_BLOCKHOOKS = (1 << 7);     /**< Prevents the message from triggering SourceMod and Metamod hooks */

		/**
		 * @endsection
		 */

		/**
		 * Returns usermessage serialization type used for the current engine
		 *
		 * @return              The supported usermessage type.
		 */
		public static UserMessageType GetUserMessageType() { throw new NotImplementedException(); }

		public static Protobuf UserMessageToProtobuf(Handle msg)
		{
			if (GetUserMessageType() != UserMessageType.UM_Protobuf)
			{
				return null;
			}

			return (Protobuf)(msg);
		}

		// Make sure to only call this on writable buffers (eg from StartMessage).
		public static BfWrite UserMessageToBfWrite(Handle msg)
		{
			if (GetUserMessageType() == UserMessageType.UM_Protobuf)
			{
				return null;
			}

			return (BfWrite)(msg);
		}

		// Make sure to only call this on readable buffers (eg from a message hook).
		public static BfRead UserMessageToBfRead(Handle msg)
		{
			if (GetUserMessageType() == UserMessageType.UM_Protobuf)
			{
				return null;
			}

			return (BfRead)(msg);
		}

		/**
		 * Returns the ID of a given message, or -1 on failure.
		 *
		 * @param msg           String containing message name (case sensitive).
		 * @return              A message index, or INVALID_MESSAGE_ID on failure.
		 */
		public static UserMsg GetUserMessageId(string msg) { throw new NotImplementedException(); }

		/**
		 * Retrieves the name of a message by ID.
		 *
		 * @param msg_id        Message index.
		 * @param msg           Buffer to store the name of the message.
		 * @param maxlength     Maximum length of string buffer.
		 * @return              True if message index is valid, false otherwise.
		 */
		public static bool GetUserMessageName(UserMsg msg_id, string msg, int maxlength) { throw new NotImplementedException(); }

		/**
		 * Starts a usermessage (network message).
		 *
		 * @note Only one message can be active at a time.
		 * @note It is illegal to send any message while a non-intercept hook is in progress.
		 *
		 * @param msgname       Message name to start.
		 * @param clients       Array containing player indexes to broadcast to.
		 * @param numClients    Number of players in the array.
		 * @param flags         Optional flags to set.
		 * @return              A handle to a bf_write bit packing structure, or
		 *                      INVALID_HANDLE on failure.
		 * @error               Invalid message name, unable to start a message, invalid client,
		 *                      or client not connected.
		 */
		public static Handle StartMessage(string msgname, /*const*/ int[] clients, int numClients, int flags = 0)
		{
			throw new NotImplementedException();
		}

		/**
		 * Starts a usermessage (network message).
		 *
		 * @note Only one message can be active at a time.
		 * @note It is illegal to send any message while a non-intercept hook is in progress.
		 *
		 * @param msg           Message index to start.
		 * @param clients       Array containing player indexes to broadcast to.
		 * @param numClients    Number of players in the array.
		 * @param flags         Optional flags to set.
		 * @return              A handle to a bf_write bit packing structure, or
		 *                      INVALID_HANDLE on failure.
		 * @error               Invalid message name, unable to start a message, invalid client,
		 *                      or client not connected.
		 */
		public static Handle StartMessageEx(UserMsg msg, /*const*/ int[] clients, int numClients, int flags = 0) { throw new NotImplementedException(); }

		/**
		 * Ends a previously started user message (network message).
		 */
		public static void EndMessage() { throw new NotImplementedException(); }

		/**
		 * Hook function types for user messages.
		*/

		/**
		 * Called when a protobuf based usermessage is hooked
		 *
		 * @param msg_id        Message index.
		 * @param msg           Handle to the input protobuf.
		 * @param players       Array containing player indexes.
		 * @param playersNum    Number of players in the array.
		 * @param reliable      True if message is reliable, false otherwise.
		 * @param init          True if message is an initmsg, false otherwise.
		 * @return              Ignored for normal hooks.  For intercept hooks, Plugin_Handled
		 *                      blocks the message from being sent, and Plugin_Continue
		 *                      resumes normal functionality.
		 */
		public delegate Action MsgHook(UserMsg msg_id, Handle msg, /*const*/ int[] players, int playersNum, bool reliable, bool init);

		/**
		 * Called when a message hook has completed.
		 *
		 * @param msg_id        Message index.
		 * @param sent          True if message was sent, false if blocked.
		 */
		public delegate void MsgPostHook(UserMsg msg_id, bool sent);

		/**
		 * Hooks a user message.
		 *
		 * @param msg_id        Message index.
		 * @param hook          Function to use as a hook.
		 * @param intercept     If intercept is true, message will be fully intercepted,
		 *                      allowing the user to block the message.  Otherwise,
		 *                      the hook is normal and ignores the return value.
		 * @param post          Notification function.
		 * @error               Invalid message index.
		 */
		public static void HookUserMessage(UserMsg msg_id, MsgHook hook, bool intercept = false, MsgPostHook post = INVALID_FUNCTION) { throw new NotImplementedException(); }

		/**
		 * Removes one usermessage hook.
		 *
		 * @param msg_id        Message index.
		 * @param hook          Function used for the hook.
		 * @param intercept     Specifies whether the hook was an intercept hook or not.
		 * @error               Invalid message index.
		 */
		public static void UnhookUserMessage(UserMsg msg_id, MsgHook hook, bool intercept = false) { throw new NotImplementedException(); }

		/**
		 * Starts a usermessage (network message) that broadcasts to all clients.
		 *
		 * @note See StartMessage or StartMessageEx().
		 *
		 * @param msgname       Message name to start.
		 * @param flags         Optional flags to set.
		 * @return              A handle to a bf_write bit packing structure, or
		 *                      INVALID_HANDLE on failure.
		 */
		public static Handle StartMessageAll(string msgname, int flags = 0)
		{
			int total = 0;
			int[] clients = new int[MaxClients];
			for (int i = 1; i <= MaxClients; i++)
			{
				if (IsClientConnected(i))
				{
					clients[total++] = i;
				}
			}

			return StartMessage(msgname, clients, total, flags);
		}

		/**
		 * Starts a simpler usermessage (network message) for one client.
		 *
		 * @note See StartMessage or StartMessageEx().
		 *
		 * @param msgname       Message name to start.
		 * @param client        Client to send to.
		 * @param flags         Optional flags to set.
		 * @return              A handle to a bf_write bit packing structure, or
		 *                      INVALID_HANDLE on failure.
		 */
		public static Handle StartMessageOne(string msgname, int client, int flags = 0)
		{
			int[] players = new int[1];
			players[0] = client;

			return StartMessage(msgname, players, 1, flags);
		}
	}
}
