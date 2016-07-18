using System;

namespace ICode{
	[AttributeUsage(AttributeTargets.Field, AllowMultiple=false)]
	public class SharedAttribute : Attribute
	{
		public SharedAttribute()
		{
		}
	}
}