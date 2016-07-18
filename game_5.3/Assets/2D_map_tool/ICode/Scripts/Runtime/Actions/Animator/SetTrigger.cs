using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityAnimator{
	[Category(Category.Animator)]
	[Tooltip("Sets a trigger parameter to active or inactive.")]
	[HelpUrl("http://docs.unity3d.com/Documentation/ScriptReference/Animator.SetTrigger.html")]
	[System.Serializable]
	public class SetTrigger : AnimatorAction {
		[Tooltip("The animator trigger parameter name.")]
		public FsmString parameter;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;

		private int id;
		public override void OnEnter ()
		{
			base.OnEnter ();
			id = Animator.StringToHash (parameter.Value);
			DoSetTrigger ();
			if (!everyFrame) {
				Finish ();
			}
		}

		public override void OnUpdate ()
		{
			DoSetTrigger ();
		}

		private void DoSetTrigger(){
			animator.SetTrigger (id);
		}
	}
}