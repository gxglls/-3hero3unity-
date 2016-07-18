using System;

namespace ICode{
	[AttributeUsage(AttributeTargets.Field)]
	public sealed class InspectorLabelAttribute : Attribute
	{
		private readonly string label;
		
		public string Label{
			get{
				return this.label;
			}
		}
		
		public InspectorLabelAttribute(string label){
			this.label = label;
		}
	}
}