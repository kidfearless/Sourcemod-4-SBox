using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sourcemod
{
	public partial class SourceMod
	{
		public T view_as<T>(any param)
		{
			dynamic result = param;
			return (T)result;
		}
	}
}
