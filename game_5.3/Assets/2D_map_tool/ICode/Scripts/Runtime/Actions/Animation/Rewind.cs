using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityAnimation{
	[Category(Category.Animation)]   
	[Tooltip("Rewinds the animation named name.")]
	[HelpUrl("http://docs.unity3d.com/ScriptReference/Animation.Rewind.html")]
	[System.Serializable]
	public class Rewind : AnimationAction {
		[InspectorLabel("Name")]
		[Tooltip("Animation name.")]
		public FsmString _name;

		public override void OnEnter ()
		{
			base.OnEnter ();
			animation.Rewind (_name.Value);
			
		}
		
	}
}