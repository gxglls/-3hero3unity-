using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityInput{
	[Category(Category.Input)]
	[Tooltip("Get current mouse information e.g screen position,world position and hit object")]
	[System.Serializable]
	public class GetMousePosition : StateAction {
		[NotRequired]
		[Shared]
		[Tooltip("Store the screen position.")]
		public FsmVector2 screenPosition;
		[NotRequired]
		[Shared]
		[Tooltip("Store the screen position x component.")]
		public FsmFloat screenX;
		[NotRequired]
		[Shared]
		[Tooltip("Store the screen position y component.")]
		public FsmFloat screenY;
		[NotRequired]
		[Shared]
		[Tooltip("Store the world position.")]
		public FsmVector3 worldPosition;
		[NotRequired]
		[Shared]
		[Tooltip("Store the world position x component.")]
		public FsmFloat worldX;
		[NotRequired]
		[Shared]
		[Tooltip("Store the world position y component.")]
		public FsmFloat worldY;
		[NotRequired]
		[Shared]
		[Tooltip("Store the world position z component")]
		public FsmFloat worldZ;
		[NotRequired]
		[Shared]
		[Tooltip("Store the hit game object.")]
		public FsmGameObject hitObject;
		public LayerMask mask;

		public override void OnUpdate ()
		{
			Vector2 mousePosition = Input.mousePosition;
			screenPosition.Value = mousePosition;
			screenX.Value = mousePosition.x;
			screenY.Value = mousePosition.y;

			Ray ray = Camera.main.ScreenPointToRay (mousePosition);
			RaycastHit hit;
			if (Physics.Raycast (ray, out hit,Mathf.Infinity,mask)) {
				worldPosition.Value = hit.point;
				worldX.Value=hit.point.x;
				worldY.Value=hit.point.y;
				worldZ.Value=hit.point.z;

				hitObject.Value=hit.transform.gameObject;
			}
		}
	}
}