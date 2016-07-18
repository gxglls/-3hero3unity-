using UnityEngine;
using System.Collections;

namespace ICode.Actions.Math{
	[Category(Category.Math)]    
	[Tooltip("Computes the product of its operands")]
	[HelpUrl("http://msdn.microsoft.com/en-us/library/z19tbbca.aspx")]
	[System.Serializable]
	public class Multiply : StateAction {
		[Tooltip("First operand.")]
		public FsmFloat first;
		[Tooltip("Second operand")]
		public FsmFloat second;
		[Shared]
		[Tooltip("Store the result.")]
		public FsmFloat store;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;

		public override void OnEnter ()
		{
			store.Value = first.Value * second.Value;
			if (!everyFrame) {
				Finish ();
			}
		}
		
		public override void OnUpdate ()
		{
			store.Value = first.Value * second.Value;
		}
	}
}