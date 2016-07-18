using UnityEngine;

namespace ICode.Actions{
	[Category(Category.Tween)]    
	[Tooltip("Tweens the color.")]
	[HelpUrl("")]
	[System.Serializable]
	public class TweenColor : TweenAction {
		public FsmColor from;
		public FsmColor to;
		[Shared]
		public FsmColor store;

		public override void OnTween (float percentage)
		{
			store.Value = GetValue(from.Value, to.Value,percentage);
		}
	}
}