using System;

namespace ICode{
	[AttributeUsage(AttributeTargets.All)]
	public sealed class TooltipAttribute : Attribute
	{
		private readonly string text;
		
		public string Text
		{
			get
			{
				return this.text;
			}
		}
		
		public TooltipAttribute(string text)
		{
			this.text = text;
		}
	}
}