using UnityEngine;
using System.Collections;

namespace ICode.Actions.Math{
	[Category(Category.Math)] 
	[Tooltip("The infamous 3.14159265358979... value.")]
	[HelpUrl("http://docs.unity3d.com/ScriptReference/Mathf.PI.html")]
	[System.Serializable]
	public class PI : StateAction {
		[Shared]
		[Tooltip("Store the result.")]
		public FsmFloat store;
		
		
		public override void OnEnter ()
		{
			store.Value = Mathf.PI;
			Finish ();
		}
	}
}