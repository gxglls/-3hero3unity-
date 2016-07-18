using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityAnimator{
	[Category(Category.Animator)]
	[Tooltip("Returns true if the object has a transform hierarchy.")]
	[HelpUrl("http://docs.unity3d.com/ScriptReference/Animator-hasTransformHierarchy.html")]
	[System.Serializable]
	public class HasTransformHierarchy : AnimatorAction {
		[Shared]
		[Tooltip("Store the value.")]
		public FsmBool store;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;
		
		public override void OnEnter ()
		{
			base.OnEnter ();
			DoGetInfo ();
			if (!everyFrame) {
				Finish ();
			}
		}
		
		public override void OnUpdate ()
		{
			DoGetInfo ();
		}
		
		private void DoGetInfo(){
			store.Value = animator.hasTransformHierarchy;
		}
	}
}