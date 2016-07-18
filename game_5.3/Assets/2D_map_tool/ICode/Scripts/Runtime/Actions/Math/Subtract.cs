using UnityEngine;
using System.Collections;

namespace ICode.Actions.Math{
	[Category(Category.Math)]  
	[Tooltip("Subtracts the value of one expression from another.")]
	[HelpUrl("http://msdn.microsoft.com/en-us/library/wch5w409.aspx")]
	[System.Serializable]
	public class Subtract : StateAction {
		[Tooltip("First operand.")]
		public FsmFloat first;
		[Tooltip("Second operand.")]
		public FsmFloat second;
		[Shared]
		[Tooltip("Store the result.")]
		public FsmFloat store;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;

		public override void OnEnter ()
		{
			store.Value = first.Value - second.Value;
			if (!everyFrame) {
				Finish ();
			}
		}

		public override void OnUpdate ()
		{
			store.Value = first.Value - second.Value;
		}
	}
}