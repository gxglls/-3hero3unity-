using UnityEngine;
using System.Collections;

namespace ICode.Actions{
	[Category(Category.Vector3)] 
	[Tooltip("Set the z component of the Vector3.")]
	[System.Serializable]
	public class SetZ : StateAction {
		[Shared]
		[Tooltip("Vector3 to use")]
		public FsmVector3 vector;
		[Tooltip("The value to set.")]
		public FsmFloat z;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;
		
		public override void OnEnter ()
		{
			vector.Value = new Vector3 (vector.Value.x,vector.Value.y,z.Value);
			if (!everyFrame) {
				Finish ();
			}
		}
		
		public override void OnUpdate ()
		{
			vector.Value = new Vector3 (vector.Value.x,vector.Value.y,z.Value);
		}
	}
}