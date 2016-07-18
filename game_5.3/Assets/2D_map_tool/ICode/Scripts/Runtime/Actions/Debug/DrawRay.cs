using UnityEngine;
using System.Collections;

namespace ICode.Actions{
	[Category(Category.Debug)]
	[Tooltip("Draws a line from start to start + dir in world coordinates.")]
	[HelpUrl("http://docs.unity3d.com/Documentation/ScriptReference/Debug.DrawRay.html")]
	[System.Serializable]
	public class DrawRay : StateAction {
		[NotRequired]
		[SharedPersistent]
		[Tooltip("Draw a line from a Game Object.")]
		public FsmGameObject fromObject;
		[NotRequired]
		[Tooltip("Start position of the line.")]
		public FsmVector3 start;
		[Tooltip("The direction of the ray.")]
		public FsmVector3 direction;
		[Tooltip("Color of the ray.")]
		public FsmColor color;

		public override void OnUpdate ()
		{
			Debug.DrawRay (FsmUtility.GetPosition(fromObject, start.Value), direction.Value, color.Value);
		}
	}
}
