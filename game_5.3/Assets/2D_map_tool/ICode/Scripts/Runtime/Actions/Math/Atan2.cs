using UnityEngine;
using System.Collections;

namespace ICode.Actions.Math{
	[Category(Category.Math)]   
	[Tooltip("Returns the angle in radians whose Tan is y/x.")] 
	[HelpUrl("http://docs.unity3d.com/ScriptReference/Mathf.Atan2.html")]
	[System.Serializable]
	public class Atan2 : StateAction {
		[Tooltip("Y value to use.")]
		public FsmFloat y;
		[Tooltip("X value to use.")]
		public FsmFloat x;
		[Shared]
		[Tooltip("Store the result.")]
		public FsmFloat store;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;
		
		public override void OnEnter ()
		{
			store.Value = Mathf.Atan2 (y.Value,x.Value);
			if (!everyFrame) {
				Finish ();
			}
		}
		
		public override void OnUpdate ()
		{
			store.Value = Mathf.Atan2 (y.Value,x.Value);
		}
	}
}