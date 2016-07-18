using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityAnimator{
	[Category(Category.Animator)]
	[Tooltip("Gets the next State information on a specified AnimatorController layer.")]
	[HelpUrl("http://docs.unity3d.com/ScriptReference/Animator.GetNextAnimatorStateInfo.html")]
	[System.Serializable]
	public class GetNextAnimatorStateInfo : AnimatorAction {
		[Tooltip("Animator layer.")]
		public FsmInt layer;
		[NotRequired]
		[Shared]
		[Tooltip("Name of the State.")]
		public FsmInt nameHash;
		[NotRequired]
		[Shared]
		[Tooltip("The Tag of the State.")]
		public FsmInt tagHash;
		[NotRequired]
		[Shared]
		[Tooltip("Normalized time of the State.")]
		public FsmFloat normalizedTime;
		[NotRequired]
		[Shared]
		[Tooltip("Current duration of the state.")]
		public FsmFloat length;
		[NotRequired]
		[Shared]
		[Tooltip("Is the state looping.")]
		public FsmBool loop;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;

		public override void OnEnter ()
		{
			base.OnEnter ();
			DoGetNextAnimatorStateInfo ();
			if (!everyFrame) {
				Finish ();
			}
		}

		public override void OnUpdate ()
		{
			DoGetNextAnimatorStateInfo ();
		}

		private void DoGetNextAnimatorStateInfo(){
			AnimatorStateInfo info = animator.GetNextAnimatorStateInfo (layer.Value);
			if (!nameHash.IsNone) {
				#if UNITY_5
				nameHash.Value=info.fullPathHash;
				#else
				nameHash.Value = info.nameHash;
				#endif
			}
			if(!tagHash.IsNone)
				tagHash.Value = info.tagHash;
			if (!normalizedTime.IsNone)					
				normalizedTime.Value = info.normalizedTime;
			if(!length.IsNone)
				length.Value = info.length;
			if(!loop.IsNone)
				loop.Value = info.loop;
		}
	}
}