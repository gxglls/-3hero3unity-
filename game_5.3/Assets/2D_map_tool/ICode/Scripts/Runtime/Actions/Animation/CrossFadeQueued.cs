using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityAnimation{
	[Category(Category.Animation)]   
	[Tooltip("Cross fades an animation after previous animations has finished playing.")]
	[HelpUrl("http://docs.unity3d.com/ScriptReference/Animation.CrossFadeQueued.html")]
	[System.Serializable]
	public class CrossFadeQueued : AnimationAction {
		[InspectorLabel("Name")]
		[Tooltip("Animation name to crossfade to.")]
		public FsmString _name;
		[Tooltip("Fading time.")]
		[DefaultValue(0.3f)]
		public FsmFloat fadeLenght;
		[Tooltip("QueueMode.")]
		public QueueMode queue=QueueMode.CompleteOthers;
		[Tooltip("PlayMode.")]
		public PlayMode mode=PlayMode.StopSameLayer;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;
		
		public override void OnEnter ()
		{
			base.OnEnter ();
			animation.CrossFadeQueued (_name.Value, fadeLenght.Value,queue,mode);
			if (!everyFrame) {
				Finish();			
			}
		}
		
		public override void OnUpdate ()
		{
			animation.CrossFadeQueued (_name.Value, fadeLenght.Value, queue, mode);
		}
	}
}