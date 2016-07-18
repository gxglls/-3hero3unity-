using UnityEngine;
using System.Collections;

namespace ICode.Actions.Math{
	[Category(Category.Math)] 
	[Tooltip("A tiny floating point value.")]
	[HelpUrl("http://docs.unity3d.com/ScriptReference/Mathf.Epsilon.html")]
	[System.Serializable]
	public class Epsilon : StateAction {
		[Shared]
		[Tooltip("Store the result.")]
		public FsmFloat store;
		
		
		public override void OnEnter ()
		{
			store.Value = Mathf.Epsilon;
			Finish ();
		}
	}
}