using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityTransform{
	[Category(Category.Transform)]  
	[Tooltip("Get a Vector3 position in range of the gameObject.")]
	[HelpUrl("")]
	[System.Serializable]
	public class GetPositionInRange : TransformAction {
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
			base.OnEnter ();
			DoGetPositionInRange ();
			if (!everyFrame) {
				Finish ();
			}
		}

		public override void OnUpdate ()
		{
			DoGetPositionInRange ();
		}

		private void DoGetPositionInRange(){
			Vector3 position = transform.position;
			Vector3 inRange = new Vector3 (position.x + Random.Range (-range.Value, range.Value),
			                               position.y+(setY.Value?Random.Range(-range.Value, range.Value):0),
			                               position.z + Random.Range (-range.Value, range.Value)
			                               );
			store.Value = inRange;
		}
	}
}