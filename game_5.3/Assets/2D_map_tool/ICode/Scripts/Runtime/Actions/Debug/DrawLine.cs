using UnityEngine;
using System.Collections;

namespace ICode.Actions{
	[Category(Category.Debug)]
	[Tooltip("Draws a line between specified start and end points.")]
	[HelpUrl("http://docs.unity3d.com/Documentation/ScriptReference/Debug.DrawLine.html")]
	[System.Serializable]
	public class DrawLine : StateAction {
		[NotRequired]
		[SharedPersistent]
		[Tooltip("Draw a line from a Game Object.")]
		public FsmGameObject fromObject;
		[NotRequired]
		[Tooltip("Start position of the line.")]
		public FsmVector3 start;
		[NotRequired]
		[SharedPersistent]
		[Tooltip("Draw a line to a Game Object.")]
		public FsmGameObject toObject;
		[NotRequired]
		[Tooltip("End position of the line.")]
		public FsmVector3 end;
		[Tooltip("Color of the line.")]
		public FsmColor color;

		public override void OnUpdate ()
		{
			DoDrawLine ();
		}

		private void DoDrawLine(){
			Debug.DrawLine (FsmUtility.GetPosition(fromObject, start), FsmUtility.GetPosition(toObject, end), color.Value);
		}
	}
}
