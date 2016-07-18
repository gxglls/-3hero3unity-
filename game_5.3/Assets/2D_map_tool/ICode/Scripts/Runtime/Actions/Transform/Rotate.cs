using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityTransform{
	[Category(Category.Transform)]  
	[Tooltip("Applies a rotation of /eulerAngles.z/ degrees around the z axis, /eulerAngles.x/ degrees around the x axis, and /eulerAngles.y/ degrees around the y axis (in that order).")]
	[HelpUrl("https://docs.unity3d.com/Documentation/ScriptReference/Transform.Rotate.html")]
	[System.Serializable]
	public class Rotate : TransformAction {
		[NotRequired]
		[Tooltip("Euler Angles")]
		public FsmVector3 eulerAngles;
		[NotRequired]
		[Tooltip("Rotate arround x axis")]
		public FsmFloat x;
		[NotRequired]
		[Tooltip("Rotate arround y axis")]
		public FsmFloat y;
		[NotRequired]
		[Tooltip("Rotate arround z axis")]
		public FsmFloat z;
		[Tooltip("The coordinate space in which to operate.")]
		public Space space;
		[Tooltip("Use this to make your game frame rate independent.")]
		public FsmBool deltaTime;


		public override void OnUpdate ()
		{
			Vector3 euler = eulerAngles.IsNone ? new Vector3 (x.Value, y.Value, z.Value) : eulerAngles.Value;
			if (!x.IsNone) euler.x = x.Value;
			if (!y.IsNone) euler.y = y.Value;
			if (!z.IsNone) euler.z = z.Value;

			if (deltaTime.Value) {
				transform.Rotate (euler*Time.deltaTime, space);
			} else {
				transform.Rotate (euler, space);
			}
		}
	}
}