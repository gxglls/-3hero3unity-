using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityVector3{
	[Category(Category.Vector3)]  
	[Tooltip("Returns the angle in degrees between from and to.")]
	[HelpUrl("https://docs.unity3d.com/Documentation/ScriptReference/Vector3.Angle.html")]
	[System.Serializable]
	public class Angle : StateAction {
		[Tooltip("The angle extends round from this vector.")]
		public FsmVector3 from;
		[Tooltip("The angle extends round to this vector.")]
		public FsmVector3 to;
		[Shared]
		[Tooltip("Store the result.")]
		public FsmFloat store;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;

		public override void OnEnter ()
		{
			store.Value = Vector3.Angle (from.Value, to.Value);
			if (!everyFrame) {
				Finish ();
			}
		}

		public override void OnUpdate ()
		{
			store.Value = Vector3.Angle (from.Value, to.Value);
		}
	}
}