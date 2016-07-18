using UnityEngine;
using System.Collections;

namespace ICode.Conditions{
	[Category(Category.Time)]
	[Tooltip("Delay a transition.")]
	[System.Serializable]
	public class RandomExitTime : Condition {
		[Tooltip("Time in seconds.")]
		public FsmFloat min;
		[Tooltip("Time in seconds.")]
		public FsmFloat max;
		[Tooltip("Remember the time, switching state will not reset it.")]
		public FsmBool remember;
		private float exitTime;
		
		public override void OnEnter ()
		{
			base.OnEnter ();
			if (remember.Value && exitTime > Time.time) {

			} else {
				exitTime = Time.time + Random.Range(min.Value,max.Value);
			}
		}

		public override bool Validate ()
		{
			return Time.time > exitTime;
		}
	}
}