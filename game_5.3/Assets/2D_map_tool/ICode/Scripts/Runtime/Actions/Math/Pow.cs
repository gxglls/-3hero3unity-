using UnityEngine;
using System.Collections;

namespace ICode.Actions.Math{
	[Category(Category.Math)] 
	[Tooltip("Returns f raised to power p.")]
	[HelpUrl("http://docs.unity3d.com/ScriptReference/Mathf.Pow.html")]
	[System.Serializable]
	public class Pow : StateAction {
		public FsmFloat f;
		public FsmFloat p;
		[Shared]
		[Tooltip("Store the result.")]
		public FsmFloat store;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;
		
		public override void OnEnter ()
		{
			store.Value = Mathf.Pow (f.Value,p.Value);
			if (!everyFrame) {
				Finish ();
			}
		}
		
		public override void OnUpdate ()
		{
			store.Value = Mathf.Pow (f.Value,p.Value);
		}
	}
}