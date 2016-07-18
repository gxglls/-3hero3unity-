using UnityEngine;
using System.Collections;

namespace ICode.Actions.Variable{
	[Category(Category.Variable)]
	[Tooltip("Sets the Vector2 value of a variable.")]
	[System.Serializable]
	public class SetVector2 : StateAction {
		[Shared]
		[Tooltip("The variable to use.")]
		public FsmVector2 variable;
		[Tooltip("The value to set.")]
		public FsmVector2 value;
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