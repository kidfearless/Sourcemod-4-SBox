using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Sourcemod.SourceMod;

namespace Sourcemod
{
	[TestClass]
	public class ViewAsTest
	{
		[TestMethod]
		public void CharToInt()
		{
			Sourcemod.SourceMod x = new();
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
			Assert.IsTrue(view_as<bool>(1) == true);
			Assert.IsTrue(view_as<bool>(-1) == true);
			Assert.IsTrue(view_as<bool>(-2) == true);
			Assert.IsTrue(view_as<bool>(2) == true);
			Assert.IsTrue(view_as<bool>(0) == false);
		}

		[TestMethod]
		public void BoolToInt()
		{
			Assert.AreEqual(view_as<int>(true), 1);
			Assert.AreEqual(view_as<int>(false), 0);
		}

		class Egg
		{
			public int Value
			{
				get
				{
					return 0;
					//return view_as<int>(this);
				}
			}
		}

		[TestMethod]
		public void ViewAsEgg()
		{
			// Currently fails as there isn't a method of converting objects to ints
			Assert.AreEqual(view_as<Egg>(2).Value, 2);
		}
	}
}
