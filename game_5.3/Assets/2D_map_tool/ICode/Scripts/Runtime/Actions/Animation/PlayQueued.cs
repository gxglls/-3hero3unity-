using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityAnimation{
	[Category(Category.Animation)]   
	[Tooltip("Plays an animation after previous animations has finished playing.")]
	[HelpUrl("http://docs.unity3d.com/ScriptReference/Animation.PlayQueued.html")]
	[System.Serializable]
	public class PlayQueued : AnimationAction {
		[InspectorLabel("Name")]
		[Tooltip("Animation name to crossfade to.")]
		public FsmString _name;
		[Tooltip("PlayMode.")]
		public QueueMode queue=QueueMode.CompleteOthers;
		[Tooltip("PlayMode.")]
		public PlayMode mode=PlayMode.StopSameLayer;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;
		
		public override void OnEnter ()
		{
			base.OnEnter ();
			animation.PlayQueued (_name.Value,queue, mode);
			if (!everyFrame) {
				Finish();			
			}
		}
		public override void OnUpdate ()
		{
			animation.PlayQueued (_name.Value,queue, mode);
		}
	}
}