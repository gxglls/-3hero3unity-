using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityAnimator{
	[Category(Category.Animator)]
	[Tooltip("Create a dynamic transition between the current state and the destination state.")]
	[HelpUrl("https://docs.unity3d.com/Documentation/ScriptReference/Animator.CrossFade.html")]
	[System.Serializable]
	public class CrossFade : AnimatorAction {
		[Tooltip("Layer index containing the destination state.")]
		public FsmInt layer;
		[Tooltip("The name of the destination state.")]
		public FsmString stateName;
		[Tooltip("The duration of the transition. Value is in source state normalized time.")]
		public FsmFloat transitionDuration;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;

		private int nameHash;

		public override void OnEnter ()
		{
			base.OnEnter ();
			nameHash = Animator.StringToHash (stateName.Value);
			DoCrossFade ();
			if (!everyFrame) {
				Finish();			
			}
		}

		public override void OnUpdate ()
		{
			DoCrossFade ();
		}

		private void DoCrossFade(){
			animator.CrossFade (nameHash, transitionDuration.Value, layer.Value);
		}
	}
}