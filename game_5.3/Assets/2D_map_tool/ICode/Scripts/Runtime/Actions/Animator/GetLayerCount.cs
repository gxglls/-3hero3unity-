using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityAnimator{
	[Category(Category.Animator)]
	[Tooltip("The AnimatorController layer count.")]
	[HelpUrl("http://docs.unity3d.com/ScriptReference/Animator-layerCount.html")]
	[System.Serializable]
	public class GetLayerCount : AnimatorAction {
		[Shared]
		[Tooltip("Store the value.")]
		public FsmInt store;
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
			store.Value = animator.layerCount;
		}
	}
}