using UnityEngine;

namespace ICode.Actions{
	[Category(Category.Tween)]    
	[Tooltip("Tweens the rotation.")]
	[HelpUrl("")]
	[System.Serializable]
	public class TweenRotation : TweenTransform {
		public FsmVector3 from;
		public FsmVector3 to;
		public override void OnTween (float percentage)
		{
			transform.rotation = Quaternion.Euler( GetValue(from.Value, to.Value,percentage));
		}
	}
}