using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityAnimation{
	[Category(Category.Animation)]   
	[Tooltip("The playback speed of the animation. 1 is normal playback speed.")]
	[HelpUrl("http://docs.unity3d.com/ScriptReference/AnimationState-speed.html")]
	[System.Serializable]
	public class SetSpeed : AnimationAction {
		[InspectorLabel("Name")]
		[Tooltip("Animation name.")]
		public FsmString _name;
		[Tooltip("The speed of the animation.")]
		public FsmFloat speed;
		
		public override void OnEnter ()
		{
			base.OnEnter ();
			animation[_name.Value].speed = speed.Value;
		}
		
	}
}