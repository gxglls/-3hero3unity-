using UnityEngine;
using System.Collections;

namespace ICode.Actions.Variable{
	[Category(Category.Variable)]
	[Tooltip("Sets the Vector3 value of a variable.")]
	[System.Serializable]
	public class SetVector3 : StateAction {
		[Shared]
		[Tooltip("The variable to use.")]
		public FsmVector3 variable;
		[Tooltip("The value to set.")]
		public FsmVector3 value;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;

		public override void OnEnter ()
		{
			variable.Value = value.Value;
			if (!everyFrame) {
				Finish ();
			}
		}

		public override void OnUpdate ()
		{
			variable.Value = value.Value;
		}
	}
}