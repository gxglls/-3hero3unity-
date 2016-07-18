using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityAnimator{
	[Category(Category.Animator)]
	[Tooltip("Sets the value of a float parameter.")]
	[HelpUrl("http://docs.unity3d.com/Documentation/ScriptReference/Animator.SetFloat.html")]
	[System.Serializable]
	public class SetFloat : AnimatorAction {
		[Tooltip("The animator float parameter name to set.")]
		public FsmString parameter;
		[Tooltip("The time allowed to parameter to reach the value.")]
		public FsmFloat dampTime;
		[Tooltip("The value to set.")]
		public FsmFloat value;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;

		public override void OnEnter ()
		{
			base.OnEnter ();
			DoSetFloat ();
			if (!everyFrame) {
				Finish ();
			}
		}

		public override void OnUpdate ()
		{
			DoSetFloat ();
		}

		private void DoSetFloat(){
			if (dampTime.Value > 0) {
				animator.SetFloat (parameter.Value, value.Value,dampTime.Value,Time.deltaTime);
			}else{
				animator.SetFloat (parameter.Value, value.Value);
			}
		}
	}
}