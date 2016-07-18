using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityAnimation{
	[Category(Category.Animation)]   
	[Tooltip("Plays animation without any blending.")]
	[HelpUrl("http://docs.unity3d.com/ScriptReference/Animation.Play.html")]
	[System.Serializable]
	public class Play : AnimationAction {
		[InspectorLabel("Name")]
		[Tooltip("Animation name to crossfade to.")]
		public FsmString _name;
		[Tooltip("PlayMode.")]
		public PlayMode mode=PlayMode.StopSameLayer;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;

		public override void OnEnter ()
		{
			base.OnEnter ();
			animation.Play (_name.Value, mode);
			if (!everyFrame) {
				Finish();			
			}
		}
		public override void OnUpdate ()
		{
			animation.Play (_name.Value, mode);
		}
	}
}