using UnityEngine;

namespace ICode.Actions{
	[Category(Category.Tween)]    
	[Tooltip("Tweens the position.")]
	[HelpUrl("")]
	[System.Serializable]
	public class TweenPosition : TweenTransform {
		public FsmVector3 from;
		public FsmVector3 to;

		public override void OnTween (float percentage)
		{
			transform.position = GetValue(from.Value, to.Value,percentage);
		}
	}
}