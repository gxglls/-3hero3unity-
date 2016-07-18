using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityAnimator{
	[Category(Category.Animator)]
	[Tooltip("Returns transform mapped to this human bone id.")]
	[HelpUrl("http://docs.unity3d.com/ScriptReference/Animator.GetBoneTransform.html")]
	[System.Serializable]
	public class GetBoneTransform : AnimatorAction {
		public HumanBodyBones humanBoneId;
		[Shared]
		[Tooltip("Store the value.")]
		public FsmObject store;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;
		
		public override void OnEnter ()
		{
			base.OnEnter ();
			DoGetLayerWeight ();
			if (!everyFrame) {
				Finish ();
			}
		}
		
		public override void OnUpdate ()
		{
			DoGetLayerWeight ();
		}
		
		private void DoGetLayerWeight(){
			store.Value = animator.GetBoneTransform (humanBoneId);
		}
	}
}