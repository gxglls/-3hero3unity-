using UnityEngine;
using System.Collections;

namespace ICode.Actions{
	[Category(Category.Time)]   
	[Tooltip("Slows game playback time to allow screenshots to be saved between frames.")]
	[HelpUrl("http://docs.unity3d.com/ScriptReference/Time-captureFramerate.html")]
	[System.Serializable]
	public class SetCaptureFramerate : StateAction {
		[Tooltip("Value to set.")]
		public FsmInt framerate;
		
		public override void OnEnter ()
		{
			Time.captureFramerate = framerate.Value;
			Finish ();
		}	
	}
}