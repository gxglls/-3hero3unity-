using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityAnimation{
	[Category(Category.Animation)]   
	[Tooltip("Fades the animation with name animation in over a period of time seconds and fades other animations out.")]
	[HelpUrl("http://docs.unity3d.com/ScriptReference/Animation.CrossFade.html")]
	[System.Serializable]
	public class CrossFade : AnimationAction {
		[InspectorLabel("Name")]
		[Tooltip("Animation name to crossfade to.")]
		public FsmString _name;
		[Tooltip("Fading time.")]
		[DefaultValue(0.3f)]
		public FsmFloat fadeLenght;
		[Tooltip("PlayMode.")]
		public PlayMode mode=PlayMode.StopSameLayer;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;
		
		public override void OnEnter ()
		{
			base.OnEnter ();
			animation.CrossFade (_name.Value, fadeLenght.Value, mode);
			if (!everyFrame) {
				Finish();			
			}
		}
		
		public override void OnUpdate ()
		{
			animation.CrossFade (_name.Value, fadeLenght.Value, mode);
		}
	}
}