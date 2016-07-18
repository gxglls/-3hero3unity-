using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityAnimation{
	[Category(Category.Animation)]   
	[Tooltip("Sets the weight of animation.")]
	[HelpUrl("http://docs.unity3d.com/ScriptReference/AnimationState-weight.html")]
	[System.Serializable]
	public class SetWeight : AnimationAction {
		[InspectorLabel("Name")]
		[Tooltip("Animation name.")]
		public FsmString _name;
		[Tooltip("The weight of animation.")]
		public FsmFloat weight;
		
		public override void OnEnter ()
		{
			base.OnEnter ();
			animation[_name.Value].weight = weight.Value;
		}
		
	}
}