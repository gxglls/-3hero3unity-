using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityInput{
	[Category(Category.Input)]
	[Tooltip("Last measured linear acceleration of a device in three-dimensional space.")]
	[HelpUrl("http://docs.unity3d.com/ScriptReference/Input-acceleration.html")]
	[System.Serializable]
	public class GetAcceleration : StateAction {
		[Shared]
		[Tooltip("Store the result.")]
		public FsmVector3 store;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;

		public override void OnEnter ()
		{
			store.Value = Input.acceleration;
			if (!everyFrame) {
				Finish ();
			}
		}
		
		public override void OnUpdate ()
		{
			store.Value = Input.acceleration;	
		}
	}
}