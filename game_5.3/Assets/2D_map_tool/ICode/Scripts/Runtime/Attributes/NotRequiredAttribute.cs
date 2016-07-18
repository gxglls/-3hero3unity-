using System;

namespace ICode{
	[AttributeUsage(AttributeTargets.Field, AllowMultiple=false)]
	public class NotRequiredAttribute : Attribute
	{
		public NotRequiredAttribute()
		{
		}
	}
}