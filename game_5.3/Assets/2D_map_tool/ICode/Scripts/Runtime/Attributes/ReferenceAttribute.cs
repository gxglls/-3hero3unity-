using System;

namespace ICode{
	[AttributeUsage(AttributeTargets.Field, AllowMultiple=false)]
	public class ReferenceAttribute : Attribute
	{
		public ReferenceAttribute()
		{
		}
	}
}