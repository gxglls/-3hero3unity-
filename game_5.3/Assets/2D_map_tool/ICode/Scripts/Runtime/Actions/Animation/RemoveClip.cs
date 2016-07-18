using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityAnimation{
	[Category(Category.Animation)]   
	[Tooltip("Remove clip from the animation list.")]
	[HelpUrl("http://docs.unity3d.com/ScriptReference/Animation.RemoveClip.html")]
	[System.Serializable]
	public class RemoveClip : AnimationAction {
		[InspectorLabel("Name")]
		[Tooltip("Name of the animation clip.")]
		public FsmString _name;
		
		public override void OnEnter ()
		{
			base.OnEnter ();
			animation.RemoveClip ( _name.Value);
		}
		
	}
}