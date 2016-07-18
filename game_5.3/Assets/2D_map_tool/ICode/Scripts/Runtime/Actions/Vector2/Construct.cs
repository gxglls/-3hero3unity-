using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityVector2{
	[Category(Category.Vector2)]    
	[Tooltip("Constructs a new Vector2.")]
	[HelpUrl("https://docs.unity3d.com/Documentation/ScriptReference/Vector2.html")]
	[System.Serializable]
	public class Construct : StateAction {
		[Tooltip("X component of the vector.")]
		public FsmFloat x;
		[Tooltip("Y component of the vector.")]
		public FsmFloat y;
		[Shared]
		[Tooltip("Store the result.")]
		public FsmVector2 store;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;
		
		public override void OnEnter ()
		{
			store.Value = new Vector2 (x.Value, y.Value);
			if (!everyFrame) {
				Finish ();
			}
		}
		
		public override void OnUpdate ()
		{
			store.Value = new Vector2 (x.Value, y.Value);
		}
	}
}