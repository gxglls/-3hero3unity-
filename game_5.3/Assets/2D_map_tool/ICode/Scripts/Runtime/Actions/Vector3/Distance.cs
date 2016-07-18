using UnityEngine;
using System.Collections;

namespace ICode.Actions{
	[Category(Category.Vector3)]    
	[Tooltip("Distance between two Vector3 points.")]
	[HelpUrl("https://docs.unity3d.com/Documentation/ScriptReference/Vector3.Distance.html")]
	[System.Serializable]
	public class Distance : StateAction {
		[NotRequired]
		[Tooltip("Vector3 value.")]
		public FsmVector3 a;
		[SharedPersistent]
		[NotRequired]
		public FsmGameObject first;
		[NotRequired]
		[Tooltip("Vector3 value.")]
		public FsmVector3 b;
		[Shared]
		[NotRequired]
		public FsmGameObject second;

		[Shared]
		[Tooltip("Store the result.")]
		public FsmFloat store;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;

		public override void OnEnter ()
		{
			base.OnEnter ();
			store.Value = Vector3.Distance (FsmUtility.GetPosition(first, a),FsmUtility.GetPosition(second, b));
			if (!everyFrame) {
				Finish ();
			}
		}

		public override void OnUpdate ()
		{
			store.Value = Vector3.Distance (FsmUtility.GetPosition(first, a),FsmUtility.GetPosition(second, b));
		}
	}
}