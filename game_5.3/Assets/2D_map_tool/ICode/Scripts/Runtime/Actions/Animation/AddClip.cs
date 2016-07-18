using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityAnimation{
	[Category(Category.Animation)]   
	[Tooltip("Adds a clip to the animation with name.")]
	[HelpUrl("http://docs.unity3d.com/ScriptReference/Animation.AddClip.html")]
	[System.Serializable]
	public class AddClip : AnimationAction {
		[Tooltip("Clip to add.")]
		public FsmObject clip;
		[InspectorLabel("Name")]
		[Tooltip("New name.")]
		public FsmString _name;
		
		public override void OnEnter ()
		{
			base.OnEnter ();
			animation.AddClip ((AnimationClip)clip.Value, _name.Value);
		}

	}
}