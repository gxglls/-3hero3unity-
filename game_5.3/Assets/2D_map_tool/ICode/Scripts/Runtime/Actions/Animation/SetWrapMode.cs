using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityAnimation{
	[Category(Category.Animation)]   
	[Tooltip("Wrapping mode of the animation.")]
	[HelpUrl("http://docs.unity3d.com/ScriptReference/AnimationState-wrapMode.html")]
	[System.Serializable]
	public class SetWrapMode : AnimationAction {
		[InspectorLabel("Name")]
		[Tooltip("Animation name.")]
		public FsmString _name;
		public WrapMode wrapMode;

		public override void OnEnter ()
		{
			base.OnEnter ();
			animation [_name.Value].wrapMode = wrapMode;
		}
		
	}
}