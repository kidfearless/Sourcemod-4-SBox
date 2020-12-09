
using System;
using System.Collections.Generic;
using System.Text;

using static Sourcemod.SourceMod;

namespace SourcemodTests1.Tests
{
	[TestClass]
	class ViewAsTest
	{
		[TestMethod]
		public void CharToInt()
		{
			Assert.AreEqual(view_as<int>('@'), 64);
		}

		[TestMethod]
		public void IntToChar()
		{
			Assert.AreEqual(view_as<char>(64), '@');
		}

		[TestMethod]
		public void IntToBool()
		{
			Assert.AreEqual(view_as<bool>(1), true);
			Assert.AreEqual(view_as<bool>(-1), true);
			Assert.AreEqual(view_as<bool>(-2), true);
			Assert.AreEqual(view_as<bool>(2), true);
			Assert.AreEqual(view_as<bool>(0), false);
		}

		[TestMethod]
		public void BoolToInt()
		{
			Assert.AreEqual(view_as<int>(true), 1);
			Assert.AreEqual(view_as<int>(false), 0);
		}
	}
}
