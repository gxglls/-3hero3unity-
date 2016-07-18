using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityAnimator{
	[Category(Category.Animator)]
	[Tooltip("Returns the scale of the current Avatar for a humanoid rig, (1 by default if the rig is generic).")]
	[HelpUrl("http://docs.unity3d.com/ScriptReference/Animator-humanScale.html")]
	[System.Serializable]
	public class GetHumanScale : AnimatorAction {
		[Shared]
		[Tooltip("Store the value.")]
		public FsmFloat store;
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
			store.Value = animator.humanScale;
		}
	}
}