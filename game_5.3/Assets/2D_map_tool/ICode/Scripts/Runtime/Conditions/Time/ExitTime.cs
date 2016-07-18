using UnityEngine;
using System.Collections;

namespace ICode.Conditions{
	[Category(Category.Time)]
	[Tooltip("Delay a transition.")]
	[System.Serializable]
	public class ExitTime : Condition {
		[Tooltip("Time in seconds.")]
		public FsmFloat time;
		[Tooltip("Remember the time, switching state will not reset it.")]
		public FsmBool remember;
		private float exitTime;
		
		public override void OnEnter ()
		{
			base.OnEnter ();
			if (remember.Value && exitTime > Time.time) {

			} else {
				exitTime = Time.time + time.Value;
			}
			//Debug.Log ("ExitTime");
		}

		public override bool Validate ()
		{
			return Time.time > exitTime;
		}
	}
}