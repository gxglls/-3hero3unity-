using UnityEngine;

namespace ICode.Actions{
	[Category(Category.Tween)]    
	[Tooltip("Tweens the scale.")]
	[HelpUrl("")]
	[System.Serializable]
	public class TweenScale : TweenTransform {
		public FsmVector3 from;
		public FsmVector3 to;
		public override void OnTween (float percentage)
		{
			transform.localScale = GetValue(from.Value, to.Value,percentage);
		}
	}
}