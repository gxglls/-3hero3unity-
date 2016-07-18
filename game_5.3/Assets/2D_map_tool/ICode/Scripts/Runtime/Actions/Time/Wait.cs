using UnityEngine;
using System.Collections;

namespace ICode.Actions{
	[Category(Category.Time)]   
	[Tooltip("")]
	[HelpUrl("")]
	[System.Serializable]
	public class Wait : StateAction {
		[Tooltip("Time in seconds.")]
		public FsmFloat time;
		private float waitTime;

		public override void OnEnter ()
		{
			waitTime = Time.time + time.Value;
		}	
		
		public override void OnUpdate ()
		{
			if (Time.time > waitTime) {
				Finish();			
			}
		}
	}
}