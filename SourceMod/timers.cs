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
using System.Diagnostics;
using System.Threading;
using System.Timers;
namespace Sourcemod
{
	public partial class SourceMod
	{
		public const int TIMER_REPEAT = (1 << 0);       /**< Timer will repeat until it returns Plugin_Stop */
		public const int TIMER_FLAG_NO_MAPCHANGE = (1 << 1);       /**< Timer will not carry over mapchanges */
		public const int TIMER_HNDL_CLOSE = (1 << 9);       /**< Deprecated define, replaced by below */
		public const int TIMER_DATA_HNDL_CLOSE = (1 << 9);       /**< Timer will automatically call CloseHandle() on its data when finished */


		// System.Timers.Timer is too innaccurate to replace sourcemod timers
		// System.Threading.Timer lacks too much functionality.
		// So we're just going to create a thread and manage it myself
		public class TickedTimer : Handle, IDisposable
		{
			private any? Data;
			private Timer Func;
			private Stopwatch StopWatch;
			private bool IsRepeating = false;
			private bool NoMapChange = false;
			private bool AutoClose = false;
			private bool ShouldRun = true;
			private bool IsExecuting = false;

			private readonly TimeSpan Interval;

			public long ElapsedMilliseconds { get => StopWatch.ElapsedMilliseconds; }
			public long ElapsedSeconds { get => (long)StopWatch.Elapsed.TotalSeconds; }
			public long ElapsedTicks { get => StopWatch.ElapsedTicks; }
			public long TickInterval { get => Interval.Ticks; }
			public double MillisecondInterval { get => Interval.TotalMilliseconds; }
			public double SecondInterval { get => Interval.TotalSeconds; }



			public TickedTimer(float interval, Timer func, any? data = null, int flags = 0)
			{
				Data = data;
				StopWatch = new Stopwatch();

				IsRepeating = (flags & TIMER_REPEAT) != 0;
				AutoClose = (flags & TIMER_DATA_HNDL_CLOSE) != 0;
				NoMapChange = (flags & TIMER_FLAG_NO_MAPCHANGE) != 0;
				Interval = TimeSpan.FromSeconds(interval);
				Func = func;
				new Thread(Thread_Callback).Start();
			}

			private void Thread_Callback(object obj)
			{
				Thread.CurrentThread.IsBackground = true;
				StopWatch.Start();

				while (ShouldRun)
				{
					if (StopWatch.Elapsed < Interval)
					{
						continue;
					}

					StopWatch.Stop();

					IsExecuting = true;
					Func(this, Data);
					IsExecuting = false;

					if (IsRepeating)
					{
						StopWatch.Restart();
					}
					else
					{
						ShouldRun = false;
					}
				}

				CloseHandle(this);

				if(AutoClose)
				{
					CloseHandle(Data);
				}
			}

			public override void Dispose()
			{
				base.Dispose();
			}

			public override void Close()
			{
				this.Dispose();
				base.Close();
			}

			public void Trigger(bool reset = false)
			{
				if(IsExecuting)
				{
					return;
				}

				if(!IsValid)
				{
					return;
					//throw new NullReferenceException($"Exception reported: Invalid timer handle {this.GetHashCode():X}");
				}

				Func(this, Data);
				if(reset)
				{
					StopWatch.Restart();
				}
			}

			public void Kill(bool autoClose = false)
			{
				this.Close();
				if(autoClose)
				{
					CloseHandle(Data);
				}
			}
		}


		/**
		 * Called when the timer interval has elapsed.
		 *
		 * @param timer         Handle to the timer object.
		 * @param data          Data passed to CreateTimer() when timer was created.
		 * @return              Plugin_Stop to stop a repeating timer, any other value for
		 *                      default behavior.
		 */
		public delegate Action Timer(Handle timer, any? data);

		/**
		 * Called when the timer interval has elapsed.
		 *
		 * @param timer         Handle to the timer object.
		 * @param data          Data passed to CreateTimer() when timer was created.
		 * @return              Plugin_Stop to stop a repeating timer, any other value for
		 *                      default behavior.
		 */
		public delegate Action TimerCallback(TickedTimer timer, any? data);

		/**
		 * Creates a basic timer.  Calling CloseHandle() on a timer will end the timer.
		 *
		 * @param interval      Interval from the current game time to execute the given function.
		 * @param func          Function to execute once the given interval has elapsed.
		 * @param data          Handle or value to pass through to the timer callback function.
		 * @param flags         Flags to set (such as repeatability or auto-Handle closing).
		 * @return              Handle to the timer object.  You do not need to call CloseHandle().
		 *                      If the timer could not be created, INVALID_HANDLE will be returned.
		 */
		public static Handle CreateTimer(float interval, Timer func, any? data = null, int flags = 0) => new TickedTimer(interval, func, data, flags);

		
		/**
		 * Kills a timer.  Use this instead of CloseHandle() if you need more options.
		 *
		 * @param timer         Timer Handle to kill.
		 * @param autoClose     If autoClose is true, the data that was passed to CreateTimer() will
		 *                      be closed as a handle if TIMER_DATA_HNDL_CLOSE was not specified.
		 * @error               Invalid handles will cause a run time error.
		 */
		public static void KillTimer(Handle timer, bool autoClose = false) => ((TickedTimer)timer).Kill(autoClose);

		/**
		 * Kills a timer.  Use this instead of CloseHandle() if you need more options.
		 *
		 * @param timer         Timer Handle to kill.
		 * @param autoClose     If autoClose is true, the data that was passed to CreateTimer() will
		 *                      be closed as a handle if TIMER_DATA_HNDL_CLOSE was not specified.
		 * @error               Invalid handles will cause a run time error.
		 */
		public static void KillTimer(TickedTimer timer, bool autoClose = false) => timer.Kill(autoClose);

		/**
		 * Manually triggers a timer so its function will be called.
		 *
		 * @param timer         Timer Handle to trigger.
		 * @param reset         If reset is true, the elapsed time counter is reset
		 *                      so the full interval must pass again.
		 */
		public static void TriggerTimer(Handle timer, bool reset = false) => ((TickedTimer)timer).Trigger(reset);
		/**
		 * Manually triggers a timer so its function will be called.
		 *
		 * @param timer         Timer Handle to trigger.
		 * @param reset         If reset is true, the elapsed time counter is reset
		 *                      so the full interval must pass again.
		 */
		public static void TriggerTimer(TickedTimer timer, bool reset = false) => timer.Trigger(reset);

		/**
		 * Returns the simulated game time.
		 *
		 * This time is internally maintained by SourceMod and is based on the game
		 * tick count and tick rate.  Unlike GetGameTime(), it will increment past
		 * map changes and while no players are connected.  Unlike GetEngineTime(),
		 * it will not increment based on the system clock (i.e. it is still bound
		 * to the ticking process).
		 *
		 * @return              Time based on the game tick count.
		 */
		public static float GetTickedTime() { throw new NotImplementedException(); }

		/**
		 * Returns an estimate of the time left before the map ends.  If the server
		 * has not processed any frames yet (i.e. no players have joined the map yet),
		 * then the time left returned will always be infinite.
		 *
		 * @param timeleft      Variable to store the time, in seconds.  If the
		 *                      value is less than 0, the time limit is infinite.
		 * @return              True if the operation is supported, false otherwise.
		 */
		public static bool GetMapTimeLeft(out int timeleft) { throw new NotImplementedException(); }

		/**
		 * Retrieves the current map time limit.  If the server has not processed any
		 * frames yet (i.e. no players have joined the map yet), then the time limit
		 * returned will always be 0.
		 *
		 * @param time          Set to the number of total seconds in the map time
		 *                      limit, or 0 if there is no time limit set.
		 * @return              True on success, false if operation is not supported.
		 */
		public static bool GetMapTimeLimit(ref int time) { throw new NotImplementedException(); }

		/**
		 * Extends the map time limit in a way that will notify all plugins.
		 *
		 * @param time          Number of seconds to extend map time limit by.
		 *                      The number can be negative to decrease the time limit.
		 *                      If 0, the map will be set to have no time limit.
		 * @return              True on success, false if operation is not supported.
		 */
		public static bool ExtendMapTimeLimit(int time) { throw new NotImplementedException(); }

		/**
		 * Returns the number of seconds in between game server ticks.
		 *
		 * Note: A tick, in this context, is a frame.
		 *
		 * @return              Number of seconds in between ticks.
		 */
		public static float GetTickInterval() { throw new NotImplementedException(); }

		/**
		 * Notification that the map's time left has changed via a change in the time
		 * limit or a change in the game rules (such as mp_restartgame).  This is useful
		 * for plugins trying to create timers based on the time left in the map.
		 *
		 * Calling ExtendMapTimeLimit() from here, without proper precaution, will
		 * cause infinite recursion.
		 *
		 * If the operation is not supported, this will never be called.

		 * If the server has not yet processed any frames (i.e. no players have joined
		 * the map yet), then this will be called once the server begins ticking, even
		 * if there is no time limit set.
		 */
		public virtual void OnMapTimeLeftChanged() { throw new NotImplementedException(); }

		/**
		 * Returns whether or not the server is processing frames or not.
		 *
		 * The server does not process frames until at least one client joins the game.
		 * If server hibernation is disabled, once the first player has joined, even if that player
		 * leaves, the server's timers and entities will continue to work.
		 *
		 * @return              True if the server is ticking, false otherwise.
		 */
		public static bool IsServerProcessing() { throw new NotImplementedException(); }

		/**
		 * Creates a timer associated with a new datapack, and returns the datapack.
		 * @note The datapack is automatically freed when the timer ends.
		 * @note The position of the datapack is not reset or changed for the timer function.
		 *
		 * @param interval      Interval from the current game time to execute the given function.
		 * @param func          Function to execute once the given interval has elapsed.
		 * @param datapack      The newly created datapack is passed though this by-reference
		 *                      parameter to the timer callback function.
		 * @param flags         Timer flags.
		 * @return              Handle to the timer object.  You do not need to call CloseHandle().
		 */
		public static Handle CreateDataTimer(float interval, Timer func, ref Handle datapack, int flags = 0)
		{
			datapack = new DataPack();
			flags |= TIMER_DATA_HNDL_CLOSE;
			return CreateTimer(interval, func, datapack, flags);
		}
	}
}
