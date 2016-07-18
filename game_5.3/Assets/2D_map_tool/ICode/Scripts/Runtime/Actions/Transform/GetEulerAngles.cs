using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityTransform{
	[Category(Category.Transform)]   
	[Tooltip("The rotation as Euler angles in degrees.")]
	[HelpUrl("http://docs.unity3d.com/ScriptReference/Transform-eulerAngles.html")]
	[System.Serializable]
	public class GetEulerAngles : TransformAction {
		[Shared]
		[Tooltip("Store the result.")]
		public FsmVector3 store;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;

		public override void OnEnter ()
		{
			base.OnEnter ();
			store.Value = transform.rotation.eulerAngles;
			if (!everyFrame) {
				Finish ();
			}
		}

		public override void OnUpdate ()
		{
			store.Value = transform.rotation.eulerAngles;
		}
	}
}