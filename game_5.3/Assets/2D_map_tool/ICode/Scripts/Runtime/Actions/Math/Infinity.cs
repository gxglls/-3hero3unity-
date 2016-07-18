using UnityEngine;
using System.Collections;

namespace ICode.Actions.Math{
	[Category(Category.Math)]     
	[Tooltip("A representation of positive infinity.")]    
	[HelpUrl("http://docs.unity3d.com/ScriptReference/Mathf.Infinity.html")]
	[System.Serializable]
	public class Infinity : StateAction {
		[Shared]
		[Tooltip("Store the result.")]
		public FsmFloat store;
		
		
		public override void OnEnter ()
		{
			store.Value = Mathf.Infinity;
			Finish ();
		}
	}
}