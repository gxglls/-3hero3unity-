using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityAnimator{
	[Category(Category.Animator)]
	[Tooltip("Plays a state.")]
	[HelpUrl("http://docs.unity3d.com/ScriptReference/Animator.Play.html")]
	[System.Serializable]
	public class Play : AnimatorAction {
		[NotRequired]
		[Tooltip("The state name.")]
		public FsmString stateName;
		[NotRequired]
		[Shared]
		[Tooltip("The state name hash")]
		public FsmInt stateNameHash;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;

		private int nameHash;
		public override void OnEnter ()
		{
			base.OnEnter ();
			if (!string.IsNullOrEmpty (stateName.Value)) {
				nameHash = Animator.StringToHash (stateName.Value);
			} else {
				nameHash=stateNameHash.Value;			
			}
			animator.Play (nameHash);
			if (!everyFrame) {
				Finish ();
			}
		}

		public override void OnUpdate ()
		{
			animator.Play (nameHash);
		}
	}
}