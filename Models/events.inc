/**
 * vim: set ts=4 sw=4 tw=99 noet :
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
 
using System;
using System.Collections.ObjectModel;
namespace Sourcemod
{
	public partial class SourceMod
	{

/**
 * Event hook modes determining how hooking should be handled
 */
enum EventHookMode
{
	EventHookMode_Pre,                  //< Hook callback fired before event is fired */
	EventHookMode_Post,                 //< Hook callback fired after event is fired */
	EventHookMode_PostNoCopy            //< Hook callback fired after event is fired, but event data won't be copied */
};

/**
 * Hook function types for events.
 */
typeset EventHook
{
	// Called when a game event is fired.
	//
	// @param event         Handle to event. This could be INVALID_HANDLE if every plugin hooking 
	//                      this event has set the hook mode EventHookMode_PostNoCopy.
	// @param name          String containing the name of the event.
	// @param dontBroadcast True if event was not broadcast to clients, false otherwise.
	//                      May not correspond to the real value. Use the property BroadcastDisabled.
	// @return              Ignored for post hooks. Plugin_Handled will block event if hooked as pre.
	///
	function Action (Event event, string name, bool dontBroadcast) { throw new NotImplementedException(); }
	
	//
	// Called when a game event is fired.
	//
	// @param event         Handle to event. This could be INVALID_HANDLE if every plugin hooking 
	//                      this event has set the hook mode EventHookMode_PostNoCopy.
	// @param name          String containing the name of the event.
	// @param dontBroadcast True if event was not broadcast to clients, false otherwise.
	///
	function void (Event event, string name, bool dontBroadcast) { throw new NotImplementedException(); }
};

methodmap Event < Handle
{
	// Fires a game event.
	//
	// This function closes the event Handle after completing.
	//
	// @param dontBroadcast Optional boolean that determines if event should be broadcast to clients.
	public native void Fire(bool dontBroadcast=false) { throw new NotImplementedException(); }
	
	// Fires a game event to only the specified client.
	//
	// Unlike Fire, this function DOES NOT close the event Handle.
	//
	// @param client        Index of client to receive the event..
	public native void FireToClient(int client) { throw new NotImplementedException(); }

	// Cancels a previously created game event that has not been fired. This
	// is necessary to avoid leaking memory when an event isn't fired.
	public native void Cancel() { throw new NotImplementedException(); }

	// Returns the boolean value of a game event's key.
	//
	// @param key          Name of event key.
	// @param defValue     Optional default value to use if the key is not found.
	// @return             The boolean value of the specified event key.
	public native bool GetBool(string key, bool defValue=false) { throw new NotImplementedException(); }

	// Sets the boolean value of a game event's key.
	//
	// @param key          Name of event key.
	// @param value        New boolean value.
	public native void SetBool(string key, bool value) { throw new NotImplementedException(); }

	// Returns the integer value of a game event's key.
	//
	// @param key          Name of event key.
	// @param defValue     Optional default value to use if the key is not found.
	// @return             The integer value of the specified event key.
	public native int GetInt(string key, int defValue=0) { throw new NotImplementedException(); }

	// Sets the integer value of a game event's key.
	//
	// Integer value refers to anything that can be reduced to an integer.
	// The various size specifiers, such as "byte" and "short" are still 
	// integers, and only refer to how much data will actually be sent 
	// over the network (if applicable).
	//
	// @param key          Name of event key.
	// @param value        New integer value.
	public native void SetInt(string key, int value) { throw new NotImplementedException(); }

	// Returns the floating point value of a game event's key.
	//
	// @param key          Name of event key.
	// @param defValue     Optional default value to use if the key is not found.
	// @return             The floating point value of the specified event key.
	public native float GetFloat(string key, float defValue=0.0) { throw new NotImplementedException(); }

	// Sets the floating point value of a game event's key.
	//
	// @param key          Name of event key.
	// @param value        New floating point value.
	public native void SetFloat(string key, float value) { throw new NotImplementedException(); }

	// Retrieves the string value of a game event's key.
	//
	// @param key          Name of event key.
	// @param value        Buffer to store the value of the specified event key.
	// @param maxlength    Maximum length of string buffer.
	// @param defValue     Optional default value to use if the key is not found.
	public native void GetString(string key, string value, int maxlength, string defvalue="") { throw new NotImplementedException(); }

	// Sets the string value of a game event's key.
	//
	// @param key          Name of event key.
	// @param value        New string value.
	public native void SetString(string key, string value) { throw new NotImplementedException(); }

	// Retrieves the name of a game event.
	//
	// @param name         Buffer to store the name of the event.
	// @param maxlength    Maximum length of string buffer.
	public native void GetName(string name, int maxlength) { throw new NotImplementedException(); }

	// Sets whether an event's broadcasting will be disabled or not.
	//
	// This has no effect on events Handles that are not from HookEvent
	// or HookEventEx callbacks.
	property bool BroadcastDisabled {
		public native set(bool dontBroadcast) { throw new NotImplementedException(); }
		public native get() { throw new NotImplementedException(); }
	}
}

/**
 * Creates a hook for when a game event is fired.
 *
 * @param name          Name of event.
 * @param callback      An EventHook function pointer.
 * @param mode          Optional EventHookMode determining the type of hook.
 * @error               Invalid event name or invalid callback function.
 */
public static void HookEvent(string name, EventHook callback, EventHookMode mode=EventHookMode_Post) { throw new NotImplementedException(); }

/**
 * Creates a hook for when a game event is fired.
 *
 * @param name          Name of event.
 * @param callback      An EventHook function pointer.
 * @param mode          Optional EventHookMode determining the type of hook.
 * @return              True if event exists and was hooked successfully, false otherwise.
 * @error               Invalid callback function.
 */
public static bool HookEventEx(string name, EventHook callback, EventHookMode mode=EventHookMode_Post) { throw new NotImplementedException(); }

/**
 * Removes a hook for when a game event is fired.
 *
 * @param name          Name of event.
 * @param callback      An EventHook function pointer.
 * @param mode          Optional EventHookMode determining the type of hook.
 * @error               Invalid callback function or no active hook for specified event.
 */
public static void UnhookEvent(string name, EventHook callback, EventHookMode mode=EventHookMode_Post) { throw new NotImplementedException(); }

/**
 * Creates a game event to be fired later.
 *
 * The Handle should not be closed via CloseHandle().  It must be closed via 
 * event.Fire() or event.Cancel().
 *
 * @param name          Name of event.
 * @param force         If set to true, this forces the event to be created even if it's not being hooked.
 *                      Note that this will not force it if the event doesn't exist at all.
 * @return              Handle to event. INVALID_HANDLE is returned if the event doesn't exist or isn't 
 *                      being hooked (unless force is true).
 */
public static Event CreateEvent(string name, bool force=false) { throw new NotImplementedException(); }

/**
 * Fires a game event.
 *
 * This function closes the event Handle after completing.
 *
 * @param event         Handle to the event.
 * @param dontBroadcast Optional boolean that determines if event should be broadcast to clients.
 * @error               Invalid or corrupt Handle.
 */
public static void FireEvent(Handle event, bool dontBroadcast=false) { throw new NotImplementedException(); }

/**
 * Cancels a previously created game event that has not been fired.
 *
 * @param event         Handled to the event.
 * @error               Invalid or corrupt Handle.
 */
public static void CancelCreatedEvent(Handle event) { throw new NotImplementedException(); }

/**
 * Returns the boolean value of a game event's key.
 *
 * @param event         Handle to the event.
 * @param key           Name of event key.
 * @param defValue      Optional default value to use if the key is not found.
 * @return              The boolean value of the specified event key.
 * @error               Invalid or corrupt Handle.
 */
public static bool GetEventBool(Handle event, string key, bool defValue=false) { throw new NotImplementedException(); }

/**
 * Sets the boolean value of a game event's key.
 *
 * @param event         Handle to the event.
 * @param key           Name of event key.
 * @param value         New boolean value.
 * @error               Invalid or corrupt Handle.
 */
public static void SetEventBool(Handle event, string key, bool value) { throw new NotImplementedException(); }

/**
 * Returns the integer value of a game event's key.
 *
 * @param event         Handle to the event.
 * @param key           Name of event key.
 * @param defValue      Optional default value to use if the key is not found.
 * @return              The integer value of the specified event key.
 * @error               Invalid or corrupt Handle.
 */
public static int GetEventInt(Handle event, string key, int defValue=0) { throw new NotImplementedException(); }

/**
 * Sets the integer value of a game event's key.
 *
 * Integer value refers to anything that can be reduced to an integer.
 * The various size specifiers, such as "byte" and "short" are still 
 * integers, and only refer to how much data will actually be sent 
 * over the network (if applicable).
 *
 * @param event         Handle to the event.
 * @param key           Name of event key.
 * @param value         New integer value.
 * @error               Invalid or corrupt Handle.
 */
public static void SetEventInt(Handle event, string key, int value) { throw new NotImplementedException(); }

/**
 * Returns the floating point value of a game event's key.
 *
 * @param event         Handle to the event.
 * @param key           Name of event key.
 * @param defValue      Optional default value to use if the key is not found.
 * @return              The floating point value of the specified event key.
 * @error               Invalid or corrupt Handle.
 */
public static float GetEventFloat(Handle event, string key, float defValue=0.0) { throw new NotImplementedException(); }

/**
 * Sets the floating point value of a game event's key.
 *
 * @param event         Handle to the event.
 * @param key           Name of event key.
 * @param value         New floating point value.
 * @error               Invalid or corrupt Handle.
 */
public static void SetEventFloat(Handle event, string key, float value) { throw new NotImplementedException(); }

/**
 * Retrieves the string value of a game event's key.
 *
 * @param event         Handle to the event.
 * @param key           Name of event key.
 * @param value         Buffer to store the value of the specified event key.
 * @param maxlength     Maximum length of string buffer.
 * @param defValue      Optional default value to use if the key is not found.
 * @error               Invalid or corrupt Handle.
 */
public static void GetEventString(Handle event, string key, string value, int maxlength, string defvalue="") { throw new NotImplementedException(); }

/**
 * Sets the string value of a game event's key.
 *
 * @param event         Handle to the event.
 * @param key           Name of event key.
 * @param value         New string value.
 * @error               Invalid or corrupt Handle.
 */
public static void SetEventString(Handle event, string key, string value) { throw new NotImplementedException(); }

/**
 * Retrieves the name of a game event.
 *
 * @param event         Handle to the event.
 * @param name          Buffer to store the name of the event.
 * @param maxlength     Maximum length of string buffer.
 * @error               Invalid or corrupt Handle.     
 */
public static void GetEventName(Handle event, string name, int maxlength) { throw new NotImplementedException(); }

/**
 * Sets whether an event's broadcasting will be disabled or not.
 *
 * This has no effect on events Handles that are not from HookEvent
 * or HookEventEx callbacks.
 *
 * @param event         Handle to an event from an event hook.
 * @param dontBroadcast True to disable broadcasting, false otherwise.
 * @error               Invalid Handle.
 */
public static void SetEventBroadcast(Handle event, bool dontBroadcast) { throw new NotImplementedException(); }
	}
}