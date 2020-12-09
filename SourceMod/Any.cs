using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Sourcemod
{
	public partial class SourceMod
	{
		public SourceMod()
		{

		}
		/// <summary>
		/// C# implementation of the cell_t struct in pawn
		/// </summary>
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		public struct any
		{
			[FieldOffset(0)]
			public float FloatValue;
			[FieldOffset(0)]
			public int IntValue;
			[FieldOffset(0)]
			public bool BoolValue;

			[FieldOffset(0)]
			public char CharValue;

			[FieldOffset(4)]
			private Handle Handle;

			public any(bool value) : this() => BoolValue = value;
			public any(float value) : this() => FloatValue = value;
			public any(int value) : this() => IntValue = value;
			public any(char value) : this() => CharValue = value;
			public any(Handle value) : this()
			{
				Handle = value;
				IntValue = Handle.GetHashCode();
			}

			public static implicit operator any(int value) => new any(value);
			public static implicit operator any(bool value) => new any(value);
			public static implicit operator any(float value) => new any(value);
			public static implicit operator any(char value) => new any(value);
			public static implicit operator any(Handle value) => new any(value);

			public static implicit operator int(any value) => value.IntValue;
			public static implicit operator float(any value) => value.FloatValue;
			public static implicit operator bool(any value) => value.BoolValue;
			public static implicit operator char(any value) => value.CharValue;
			public static implicit operator Handle(any value) => value.Handle;
		}
	}
}
