using UnityEngine;
using System.Collections;

namespace ICode.Actions.Math{
	[Category(Category.Math)] 
	[Tooltip("Radians-to-degrees conversion constant ")]
	[HelpUrl("http://docs.unity3d.com/ScriptReference/Mathf.Rad2Deg.html")]
	[System.Serializable]
	public class Rad2Deg : StateAction {
		[Shared]
		[Tooltip("Store the result.")]
		public FsmFloat store;
			
		public override void OnEnter ()
		{
			store.Value = Mathf.Rad2Deg;
			Finish ();
		}
	}
}