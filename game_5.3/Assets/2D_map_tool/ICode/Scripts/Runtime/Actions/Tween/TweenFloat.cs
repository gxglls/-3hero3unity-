using UnityEngine;

namespace ICode.Actions{
	[Category(Category.Tween)]    
	[Tooltip("Tweens the color.")]
	[HelpUrl("")]
	[System.Serializable]
	public class TweenFloat : TweenAction {
		public FsmFloat from;
		public FsmFloat to;
		[Shared]
		public FsmFloat store;
		
		public override void OnTween (float percentage)
		{
			store.Value = GetValue(from.Value, to.Value,percentage);
		}
	}
}