using UnityEngine;
using System.Collections;

namespace ICode.Actions.Math{
	[Category(Category.Math)] 
	[Tooltip("A representation of negative infinity")]
	[HelpUrl("http://docs.unity3d.com/ScriptReference/Mathf.NegativeInfinity.html")]
	[System.Serializable]
	public class NegativeInfinity : StateAction {
		[Shared]
		[Tooltip("Store the result.")]
		public FsmFloat store;
		
		
		public override void OnEnter ()
		{
			store.Value = Mathf.NegativeInfinity;
			Finish ();
		}
	}
}