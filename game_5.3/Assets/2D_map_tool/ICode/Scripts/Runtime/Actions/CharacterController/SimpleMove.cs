using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityCharacterController{
	[Category(Category.CharacterController)]   
	[Tooltip("Moves the character with speed.")]
	[HelpUrl("https://docs.unity3d.com/Documentation/ScriptReference/CharacterController.SimpleMove.html")]
	[System.Serializable]
	public class SimpleMove : CharacterControllerAction {
		[NotRequired]
		[Tooltip("The direction to move towards.")]
		public FsmVector3 direction;
		[NotRequired]
		[Tooltip("Direction x value")]
		public FsmFloat x;
		[NotRequired]
		[Tooltip("Direction y value")]
		public FsmFloat y;
		[NotRequired]
		[Tooltip("Direction z Value")]
		public FsmFloat z;
		[Tooltip("The direction is relative to the world or the Game Object.")]
		public Space space = Space.World;
		
		[Tooltip("The speed to move.")]
		public FsmFloat speed;
		
		public override void OnUpdate ()
		{
			if (controller == null) {
				Debug.LogWarning("Simple Move requires a CharacterController on the game object.");
				Finish();
				return;
			}

			Vector3 mDirection = direction.IsNone ? new Vector3 (x.Value, y.Value, z.Value) : direction.Value;
			if (!x.IsNone) mDirection.x = x.Value;
			if (!y.IsNone) mDirection.y = y.Value;
			if (!z.IsNone) mDirection.z = z.Value;

			if (space == Space.Self) {
				controller.SimpleMove (controller.transform.TransformDirection (mDirection) * speed.Value);
			} else {
				controller.SimpleMove (mDirection * speed.Value);
			}
		}
	}
}