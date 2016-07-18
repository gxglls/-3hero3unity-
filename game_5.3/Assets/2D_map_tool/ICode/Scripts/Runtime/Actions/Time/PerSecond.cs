using UnityEngine;
using System.Collections;

namespace ICode.Actions{
	[Category(Category.Time)]   
	[Tooltip("Multiplies a float by Time.deltaTime to use in frame-rate independent operations.")]
	[HelpUrl("")]
	[System.Serializable]
	public class PerSecond : StateAction {
		[Tooltip("Value to set.")]
		public FsmFloat value;
		[Shared]
		[Tooltip("Store the result.")]
		public FsmFloat store;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;

		public override void OnEnter ()
		{
			store.Value = Time.deltaTime * value.Value;	
			if (!everyFrame) {
				Finish();			
			}
		}	

		public override void OnUpdate ()
		{
			store.Value = Time.deltaTime * value.Value;	
		}
	}
}