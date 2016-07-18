using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityAnimator{
	[Category(Category.Animator)]
	[Tooltip("Gets the current State information on a specified AnimatorController layer.")]
	[HelpUrl("http://docs.unity3d.com/ScriptReference/Animator.GetCurrentAnimatorStateInfo.html")]
	[System.Serializable]
	public class GetCurrentAnimatorStateInfo : AnimatorAction {
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
			DoGetCurrentAnimatorStateInfo ();
			if (!everyFrame) {
				Finish ();
			}
		}

		public override void OnUpdate ()
		{
			DoGetCurrentAnimatorStateInfo ();
		}

		private void DoGetCurrentAnimatorStateInfo(){
			AnimatorStateInfo info = animator.GetCurrentAnimatorStateInfo (layer.Value);
			#if UNITY_5
			nameHash.Value=info.fullPathHash;
			#else
			nameHash.Value = info.nameHash;
			#endif
			tagHash.Value = info.tagHash;
			normalizedTime.Value = info.normalizedTime;
			length.Value = info.length;
			loop.Value = info.loop;
		}
	}
}