using UnityEngine;
using System.Collections;

namespace ICode.Actions.Math{
	[Category(Category.Math)]   
	[Tooltip("Interpolates between a and b.")]
	[HelpUrl("http://docs.unity3d.com/Documentation/ScriptReference/Mathf.Lerp.html")]
	[System.Serializable]
	public class Lerp : StateAction {
		[Tooltip("Interpolate from.")]
		public FsmFloat from;
		[Tooltip("Interpolate to.")]
		public FsmFloat to;
		[Tooltip("Speed.")]
		public FsmFloat speed;
		[Shared]
		[Tooltip("Store the result.")]
		public FsmFloat store;
	
		public override void OnEnter ()
		{
			base.OnEnter ();
			DoLerp ();
		}

		public override void OnUpdate ()
		{
			DoLerp ();
		}

		private void DoLerp(){
			if (speed != null) {
				store.Value = Mathf.Lerp (from.Value, to.Value, Time.deltaTime*speed.Value);
			} else {
				store.Value = Mathf.Lerp (from.Value, to.Value, Time.deltaTime);
			}
		}
	}
}