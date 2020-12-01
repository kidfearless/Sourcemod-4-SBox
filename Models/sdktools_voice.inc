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

/**
 * @section voice flags.
 */
public const object VOICE_NORMAL        0   /**< Allow the client to listen and speak normally. */
public const object VOICE_MUTED         1   /**< Mutes the client from speaking to everyone. */
public const object VOICE_SPEAKALL      2   /**< Allow the client to speak to everyone. */
public const object VOICE_LISTENALL     4   /**< Allow the client to listen to everyone. */
public const object VOICE_TEAM          8   /**< Allow the client to always speak to team, even when dead. */
public const object VOICE_LISTENTEAM    16  /**< Allow the client to always hear teammates, including dead ones. */

/**
 * @endsection
 */

public enum ListenOverride
{
	Listen_Default = 0, /**< Leave it up to the game */
	Listen_No,          /**< Can't hear */
	Listen_Yes          /**< Can hear */
};

/**
 * Called when a client is speaking.
 *
 * @param client        The client index
 */
public static virtual void OnClientSpeaking(int client) { throw new NotImplementedException(); }

/**
 * Called once a client speaking end.
 *
 * @param client        The client index
 */
public static virtual void OnClientSpeakingEnd(int client) { throw new NotImplementedException(); }

/**
 * Set the client listening flags.
 *
 * @param client        The client index
 * @param flags         The voice flags
 */
public static void SetClientListeningFlags(int client, int flags) { throw new NotImplementedException(); }

/**
 * Retrieve the client current listening flags.
 *
 * @param client        The client index
 * @return              The current voice flags
 */
public static int GetClientListeningFlags(int client) { throw new NotImplementedException(); }

/**
 * Set the receiver ability to listen to the sender.
 *
 * @param iReceiver     The listener index.
 * @param iSender       The sender index.
 * @param bListen       True if the receiver can listen to the sender, false otherwise.
 * @return              True if successful otherwise false.
 * @deprecated          Use SetListenOverride() instead.
 */
#pragma deprecated Use SetListenOverride() instead
public static bool SetClientListening(int iReceiver, int iSender, bool bListen) { throw new NotImplementedException(); }

/**
 * Retrieves if the receiver can listen to the sender.
 *
 * @param iReceiver     The listener index.
 * @param iSender       The sender index.
 * @return              True if successful otherwise false.
 * @deprecated          GetListenOverride() instead.
 */
#pragma deprecated GetListenOverride() instead
public static bool GetClientListening(int iReceiver, int iSender) { throw new NotImplementedException(); }

/**
 * Override the receiver's ability to listen to the sender.
 *
 * @param iReceiver     The listener index.
 * @param iSender       The sender index.
 * @param override      The override of the receiver's ability to listen to the sender.
 * @return              True if successful otherwise false.
 */
public static bool SetListenOverride(int iReceiver, int iSender, ListenOverride override) { throw new NotImplementedException(); }

/**
 * Retrieves the override of the receiver's ability to listen to the sender.
 *
 * @param iReceiver     The listener index.
 * @param iSender       The sender index.
 * @return              The override value.
 */
public static ListenOverride GetListenOverride(int iReceiver, int iSender) { throw new NotImplementedException(); }

/**
 * Retrieves if the muter has muted the mutee.
 *
 * @param iMuter        The muter index.
 * @param iMutee        The mutee index.
 * @return              True if muter has muted mutee, false otherwise.
 */
public static bool IsClientMuted(int iMuter, int iMutee) { throw new NotImplementedException(); }
	}
}