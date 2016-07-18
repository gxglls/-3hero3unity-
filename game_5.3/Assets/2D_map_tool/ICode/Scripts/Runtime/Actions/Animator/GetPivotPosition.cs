using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityAnimator{
	[Category(Category.Animator)]
	[Tooltip("Get the current position of the pivot.")]
	[HelpUrl("http://docs.unity3d.com/ScriptReference/Animator-pivotPosition.html")]
	[System.Serializable]
	public class GetPivotPosition : AnimatorAction {
		[Shared]
		[Tooltip("Store the value.")]
		public FsmVector3 store;
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
			store.Value = animator.pivotPosition;
		}
	}
}