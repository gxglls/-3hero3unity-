using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityTransform{
	[Category(Category.Transform)]    
	[Tooltip("The number of children the Transform has.")]
	[HelpUrl("http://docs.unity3d.com/ScriptReference/Transform-childCount.html")]
	[System.Serializable]
	public class GetChildCount : TransformAction {
		[Shared]
		[Tooltip("Store the result.")]
		public FsmInt store;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;

		public override void OnEnter ()
		{
			base.OnEnter ();
			store.Value = transform.childCount;
			if (!everyFrame) {
				Finish ();
			}
		}

		public override void OnUpdate ()
		{
			store.Value = transform.childCount;
		}
	}
}