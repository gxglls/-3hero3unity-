using UnityEngine;
using System.Collections;

namespace ICode.Actions{
	[Category(Category.Time)]   
	[Tooltip("The interface to get time information from Unity.")]
	[HelpUrl("http://docs.unity3d.com/ScriptReference/Time.html")]
	[System.Serializable]
	public class GetTimeInfo : StateAction {
		public TimeInfo timeInfo;
		[Shared]
		[Tooltip("Store the result.")]
		public FsmFloat store;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;
		
		public override void OnEnter ()
		{
			DoGetTimeInfo ();
			if (!everyFrame) {
				Finish ();
			}
		}	

		public override void OnUpdate ()
		{
			DoGetTimeInfo ();
		}

		private void DoGetTimeInfo(){
			switch (timeInfo) {
			case TimeInfo.deltaTime:
				store.Value=Time.deltaTime;
				break;
			case TimeInfo.fixedDeltaTime:
				store.Value=Time.fixedDeltaTime;
				break;
			case TimeInfo.fixedTime:
				store.Value=Time.fixedTime;
				break;
			case TimeInfo.realtimeSinceStartup:
				store.Value=Time.realtimeSinceStartup;
				break;
			case TimeInfo.smoothDeltaTime:
				store.Value=Time.smoothDeltaTime;
				break;
			case TimeInfo.time:
				store.Value=Time.time;
				break;
			case TimeInfo.timeScale:
				store.Value=Time.timeScale;
				break;
			case TimeInfo.timeSinceLevelLoaded:
				store.Value=Time.timeSinceLevelLoad;
				break;
			case TimeInfo.unscaledDeltaTime:
				store.Value=Time.unscaledDeltaTime;
				break;
			case TimeInfo.unscaledTime:
				store.Value=Time.unscaledTime;
				break;
			}
		}

		public enum TimeInfo{
			deltaTime,
			fixedDeltaTime,
			fixedTime,
			realtimeSinceStartup,
			smoothDeltaTime,
			timeScale,
			timeSinceLevelLoaded,
			unscaledDeltaTime,
			time,
			unscaledTime
		}
	}
}