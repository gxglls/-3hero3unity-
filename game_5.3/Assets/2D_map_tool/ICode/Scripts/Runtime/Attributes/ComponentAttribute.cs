using UnityEngine;
using System.Collections;
using System;

namespace ICode{
	public class ComponentAttribute : PropertyAttribute  {
		private readonly Type type;
		
		public Type Type
		{
			get
			{
				return this.type;
			}
		}
		
		public ComponentAttribute(Type type)
		{
			this.type = type;
		}

		public ComponentAttribute()
		{
		}
	}
}