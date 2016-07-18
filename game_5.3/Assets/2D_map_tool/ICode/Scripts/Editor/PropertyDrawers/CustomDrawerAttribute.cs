using System;

namespace ICode{
	[AttributeUsage(AttributeTargets.All, AllowMultiple=false)]
	public sealed class CustomDrawerAttribute : Attribute
	{
		private readonly Type type;
		
		public Type Type
		{
			get
			{
				return this.type;
			}
		}
		
		
		public CustomDrawerAttribute(Type type)
		{
			this.type = type;
		}
	}
}