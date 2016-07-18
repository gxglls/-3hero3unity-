using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityAnimation{
	[Category(Category.Animation)]   
	[Tooltip("The current time of the animation.")]
	[HelpUrl("http://docs.unity3d.com/ScriptReference/AnimationState-time.html")]
	[System.Serializable]
	public class SetTime : AnimationAction {
		[InspectorLabel("Name")]
		[Tooltip("Animation name.")]
		public FsmString _name;
		[Tooltip("If the time is larger than length it will be wrapped according to wrapMode. The value can be larger than the animations length. In this case playback mode will remap the time before sampling. This value usually goes from 0 to infinity.")]
		public FsmFloat time;
		
		public override void OnEnter ()
		{
			base.OnEnter ();
			animation[_name.Value].time = time.Value;
		}
		
	}
}