using UnityEngine;
using System.Collections;

namespace ICode.Actions.Math{
	[Category(Category.Math)] 
	[Tooltip("Returns a raised to the specified power.")]
	[HelpUrl("http://docs.unity3d.com/ScriptReference/Mathf.Exp.html")]
	[System.Serializable]
	public class Exp : StateAction {
		[Tooltip("The value to use.")]
		public FsmFloat power;
		[Shared]
		[Tooltip("Store the result.")]
		public FsmFloat store;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;
		
		public override void OnEnter ()
		{
			store.Value = Mathf.Exp (power.Value);
			if (!everyFrame) {
				Finish ();
			}
		}
		
		public override void OnUpdate ()
		{
			store.Value = Mathf.Exp (power.Value);
		}
	}
}