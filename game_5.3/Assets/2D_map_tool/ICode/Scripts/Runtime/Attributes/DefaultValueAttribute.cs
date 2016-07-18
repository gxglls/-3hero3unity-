using System;

namespace ICode{
	[AttributeUsage(AttributeTargets.Field, AllowMultiple=false)]
	public class DefaultValueAttribute : Attribute {
		private readonly object value;
		public object DefaultValue{
			get{
				return this.value;
			}
		}
		
		public DefaultValueAttribute(object value){
			this.value = value;
		}
	}
}