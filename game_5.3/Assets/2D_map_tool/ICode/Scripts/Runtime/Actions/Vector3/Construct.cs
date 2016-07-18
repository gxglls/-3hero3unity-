using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityVector3{
	[Category(Category.Vector3)]    
	[Tooltip("Constructs a new Vector3.")]
	[HelpUrl("https://docs.unity3d.com/Documentation/ScriptReference/Vector3.html")]
	[System.Serializable]
	public class Construct : StateAction {
		[Tooltip("X component of the vector.")]
		public FsmFloat x;
		[Tooltip("Y component of the vector.")]
		public FsmFloat y;
		[Tooltip("Z component of the vector.")]
		public FsmFloat z;
		
		[Shared]
		[Tooltip("Store the result.")]
		public FsmVector3 store;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;

		public override void OnEnter ()
		{
			store.Value = new Vector3 (x.Value, y.Value, z.Value);
			if (!everyFrame) {
				Finish ();
			}
		}

		public override void OnUpdate ()
		{
			store.Value = new Vector3 (x.Value, y.Value, z.Value);
		}
	}
}