using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sourcemod
{
	public partial class SourceMod
	{
		public static T view_as<T>(any? param)
		{
			if(param is null)
			{
				return (T)(dynamic)0;
			}
			dynamic result = param;
			return (T)result;
		}
	}
}
