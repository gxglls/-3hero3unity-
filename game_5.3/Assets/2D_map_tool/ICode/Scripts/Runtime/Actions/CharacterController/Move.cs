using UnityEngine;
using System.Collections;


namespace ICode.Actions.UnityCharacterController{
	[Category(Category.CharacterController)]  
	[Tooltip("A more complex move function taking absolute movement deltas.")]
	[HelpUrl("https://docs.unity3d.com/Documentation/ScriptReference/CharacterController.Move.html")]
	[System.Serializable]
	public class Move : CharacterControllerAction {
		[Tooltip("The direction to move towards.")]
		public FsmVector3 direction;
		[Tooltip("The direction is relative to the world or the Game Object.")]
		public Space space = Space.World;
		[Tooltip("The speed to move.")]
		public FsmFloat speed;
		[NotRequired]
		[Tooltip( "Use gravity during movement?")]
		public FsmBool useGravity;
		[NotRequired]
		[Shared]
		[Tooltip("The character controller will jump if the value is true.")]
		public FsmBool jump;
		[NotRequired]
		[Tooltip("Jump speed.")]
		public FsmFloat jumpSpeed;

		public override void OnUpdate ()
		{
			Vector3 dir = (space == Space.Self) ? controller.transform.TransformDirection(direction.Value) : direction.Value;
			dir *= speed.Value;
			
			if (useGravity.Value) {
				if (controller.isGrounded)
					dir.y -= 0.9f; 
				else {
					dir += Physics.gravity * Time.deltaTime;
					dir.y += controller.velocity.y;
				}
				
				if (jump.Value) {
					dir.y += jumpSpeed.Value;
					jump.Value = false;
				}
			}
			
			controller.Move(dir * Time.deltaTime);
		}
	}
}