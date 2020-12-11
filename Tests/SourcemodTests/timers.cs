using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sourcemod;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using static Sourcemod.SourceMod;
using Action = Sourcemod.SourceMod.Action;

namespace Sourcemod
{
	[TestClass]
	public class TimerTests
	{
		bool hasFired = false;
		Stopwatch Stopwatch;

		[TestMethod]
		public void TestCallbacks()
		{
			using TickedTimer timer = CreateTimer(1.0f, Timer_Ticked, 1.0f) as TickedTimer;	

			while (!hasFired) ;

			Assert.AreEqual(timer.ElapsedMilliseconds, (long)timer.MillisecondInterval);
		}

		private Action Timer_Ticked(Handle timer, any? data)
		{
			hasFired = true;
			return Action.Plugin_Continue;
		}

		private Action NULL_TIMER(Handle timer, any? data)
		{
			return Action.Plugin_Continue;
		}

		[TestMethod]
		public void SingleFireAutoClosesSelf()
		{
			using Handle timer = CreateTimer(0.0f, NULL_TIMER);
			// timer callback is fired immediately on a different thread, so we have to wait
			Thread.Sleep(1);

			Assert.IsFalse(IsValidHandle(timer));
		}

		[TestMethod]
		public void SingleFireCanBeReFiredBeforePlannedFire()
		{
			bool early = true;
			Stopwatch watch = new Stopwatch();
			watch.Start();
			long totalDuration = 0;
			using TickedTimer timer = CreateTimer(1.0f, (Handle timer, any? data) =>
			{
				if(early)
				{
					Assert.AreNotEqual(((TickedTimer)timer).ElapsedMilliseconds, ((TickedTimer)timer).MillisecondInterval);
				}
				else
				{
					Assert.AreEqual(((TickedTimer)timer).ElapsedMilliseconds, ((TickedTimer)timer).MillisecondInterval);
				}
				early = !early;
				return Action.Plugin_Continue;
			}) as TickedTimer;

			Thread.Sleep(500);
			
			TriggerTimer(timer, reset: false);
			
			while (IsValidHandle(timer))
			{
				totalDuration = watch.ElapsedMilliseconds;
			}
			watch.Stop();
			// add 1 cause of innaccuracies
			if(totalDuration > 1000 + 1)
			{
				Assert.Fail($"Expected duration: 1000, Received duration: {totalDuration}");
			}
		}

		[TestMethod]
		public void SingleFireCanBeResetBeforePlannedFire()
		{
			bool early = true;
			Stopwatch watch = new Stopwatch();
			watch.Start();
			long totalDuration = 0;
			using TickedTimer timer = CreateTimer(1.0f, (Handle timer, any? data) =>
			{
				if (early)
				{
					Assert.AreNotEqual(((TickedTimer)timer).ElapsedMilliseconds, ((TickedTimer)timer).MillisecondInterval);
				}
				else
				{
					Assert.AreEqual(((TickedTimer)timer).ElapsedMilliseconds, ((TickedTimer)timer).MillisecondInterval);
				}
				early = !early;
				return Action.Plugin_Continue;
			}) as TickedTimer;

			Thread.Sleep(500);

			TriggerTimer(timer, reset: true);

			while (IsValidHandle(timer))
			{
				totalDuration = watch.ElapsedMilliseconds;
			}
			watch.Stop();
			// add 1 cause of innaccuracies
			if (totalDuration <= 1000 + 1)
			{
				Assert.Fail($"Expected duration: 1500, Received duration: {totalDuration}");
			}
		}

		[TestMethod]
		public void SingleFireCannotBeFiredAfterPlannedFire()
		{
			int fireCount = 0;
			using TickedTimer timer = CreateTimer(0.0f, (Handle timer, any? data) =>
			{
				fireCount++;
				return Action.Plugin_Continue;
			}) as TickedTimer;
			timer.Close();
			TriggerTimer(timer);
			Thread.Sleep(1);
			Assert.AreEqual(1, fireCount);
		}
	}
}
