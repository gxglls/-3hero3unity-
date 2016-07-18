using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityAnimation{
	[Category(Category.Animation)]   
	[Tooltip("Configurate the AnimationState")]
	[HelpUrl("http://docs.unity3d.com/ScriptReference/AnimationState.html")]
	[System.Serializable]
	public class SetAnimationSettings : AnimationAction {
		[InspectorLabel("Name")]
		[Tooltip("Animation name.")]
		public FsmString _name;
		[Tooltip("The behavior of the animation when it wraps.")]
		public WrapMode wrapMode;
		[Tooltip("How the animation is blended with other animations on the Game Object.")]
		public AnimationBlendMode blendMode;
		[NotRequired]
		[Tooltip("The speed of the animation.")]
		public FsmFloat speed;
		[NotRequired]
		[Tooltip("The animation layer.")]
		public FsmInt layer;
		
		public override void OnEnter ()
		{
			base.OnEnter ();
			animation[_name.Value].wrapMode = wrapMode;
			animation[_name.Value].blendMode = blendMode;
			if (!layer.IsNone)
			{
				animation[_name.Value].layer = layer.Value;
			}
			
			if (!speed.IsNone)
			{
				animation[_name.Value].speed = speed.Value;
			}
		}
		
	}
}