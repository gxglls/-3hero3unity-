using UnityEngine;
using System.Collections;

namespace ICode.Actions{
	[Category(Category.Vector3)]   
	[Tooltip("Get a Vector3 point in range of another Vector3 point.")]
	[HelpUrl("")]
	[System.Serializable]
	public class GetInRange : StateAction {
		[NotRequired]
		[SharedPersistent]
		[Tooltip("Use targets position.")]
		public FsmGameObject target;
		[NotRequired]
		[Tooltip("Initial position")]
		public FsmVector3 initialPosition;
		[Tooltip("Range of the Vector3.")]
		public FsmFloat range;
		[Tooltip("Randomize y component?")]
		public FsmBool setY;
		[Shared]
		[Tooltip("Store the result.")]
		public FsmVector3 store;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;

		public override void OnEnter ()
		{
			DoGetInRange ();
			if (!everyFrame) {
				Finish ();
			}
		}

		public override void OnUpdate ()
		{
			DoGetInRange ();
		}

		private void DoGetInRange(){
			Vector3 position = FsmUtility.GetPosition(target, initialPosition);
			Vector3 inRange = new Vector3 (position.x + Random.Range (-range.Value, range.Value),
			                               position.y+(setY.Value?Random.Range(-range.Value, range.Value):0),
			                               position.z + Random.Range (-range.Value, range.Value)
			                               );
			store.Value = inRange;	
		}
	}
}