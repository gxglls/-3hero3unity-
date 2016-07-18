using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityAnimation{
	[Category(Category.Animation)]   
	[Tooltip("Adds a transform which should be animated. This allows you to reduce the number of animations you have to create.")]
	[HelpUrl("http://docs.unity3d.com/ScriptReference/AnimationState.AddMixingTransform.html")]
	[System.Serializable]
	public class AddMixingTransform : AnimationAction {
		[InspectorLabel("Name")]
		[Tooltip("Animation name.")]
		public FsmString _name;
		[Tooltip("The mixing transform. E.g., root/upper_body/left_shoulder")]
		public FsmGameObject mix;
		[Tooltip("If recursive is true all children of the mix transform will also be animated.")]
		[DefaultValue(true)]
		public FsmBool recursive ;

		public override void OnEnter ()
		{
			base.OnEnter ();
			animation [_name.Value].AddMixingTransform (mix.Value.transform, recursive.Value);
		}
		
	}
}