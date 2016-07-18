using System;

namespace ICode{
	[AttributeUsage(AttributeTargets.Field, AllowMultiple=false)]
	public class SharedPersistentAttribute : Attribute
	{
		public SharedPersistentAttribute()
		{
		}
	}
}