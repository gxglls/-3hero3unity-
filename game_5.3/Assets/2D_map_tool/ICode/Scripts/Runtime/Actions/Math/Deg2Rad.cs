using UnityEngine;
using System.Collections;

namespace ICode.Actions.Math{
	[Category(Category.Math)] 
	[Tooltip("Degrees-to-radians conversion constant.")]
	[HelpUrl("http://docs.unity3d.com/ScriptReference/Mathf.Deg2Rad.html")]
	[System.Serializable]
	public class Deg2Rad : StateAction {
		[Shared]
		[Tooltip("Store the result.")]
		public FsmFloat store;
		
		public override void OnEnter ()
		{
			store.Value = Mathf.Deg2Rad;
			Finish ();
		}
	}
}