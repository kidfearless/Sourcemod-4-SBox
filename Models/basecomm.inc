/**
 * vim: set ts=4 :
 * =============================================================================
 * SourceMod (C)2004-2011 AlliedModders LLC.  All rights reserved.
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
 * Called when a client is muted or unmuted
 * 
 * @param   client      Client index
 * @param   muteState   True if client was muted, false otherwise
 */
public virtual void BaseComm_OnClientMute(int client, bool muteState) { throw new NotImplementedException(); }
 
 /**
 * Called when a client is gagged or ungagged
 * 
 * @param   client      Client index
 * @param   gagState    True if client was gaged, false otherwise
 */
public virtual void BaseComm_OnClientGag(int client, bool gagState) { throw new NotImplementedException(); }
 
/**
 * Returns whether or not a client is gagged
 *
 * @param client        Client index.
 * @return              True if client is gagged, false otherwise.
 */
public static bool BaseComm_IsClientGagged(int client) { throw new NotImplementedException(); }

/**
 * Returns whether or not a client is muted
 *
 * @param client        Client index.
 * @return              True if client is muted, false otherwise.
 */
public static bool BaseComm_IsClientMuted(int client) { throw new NotImplementedException(); }

/**
 * Sets a client's gag state
 *
 * @param client        Client index.
 * @param gagState      True to gag client, false to ungag.
 * @return              True if this caused a change in gag state, false otherwise.
 */
public static bool BaseComm_SetClientGag(int client, bool gagState) { throw new NotImplementedException(); }

/**
 * Sets a client's mute state
 *
 * @param client        Client index.
 * @param muteState     True to mute client, false to unmute.
 * @return              True if this caused a change in mute state, false otherwise.
 */
public static bool BaseComm_SetClientMute(int client, bool muteState) { throw new NotImplementedException(); }