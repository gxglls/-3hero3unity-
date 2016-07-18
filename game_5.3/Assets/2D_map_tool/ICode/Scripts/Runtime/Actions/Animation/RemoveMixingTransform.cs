using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityAnimation{
	[Category(Category.Animation)]   
	[Tooltip("Removes a transform which should be animated.")]
	[HelpUrl("http://docs.unity3d.com/ScriptReference/AnimationState.RemoveMixingTransform.html")]
	[System.Serializable]
	public class RemoveMixingTransform : AnimationAction {
		[InspectorLabel("Name")]
		[Tooltip("Animation name.")]
		public FsmString _name;
		[Tooltip("Transform to remove.")]
		public FsmGameObject mix;
		
		public override void OnEnter ()
		{
			base.OnEnter ();
			animation [_name.Value].RemoveMixingTransform (mix.Value.transform);
		}
		
	}
}