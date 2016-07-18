using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityPlayerPrefs{
	[Category(Category.PlayerPrefs)]
	[Tooltip("Sets the value of the preference identified by key.")]
	[HelpUrl("https://docs.unity3d.com/Documentation/ScriptReference/PlayerPrefs.SetFloat.html")]
	[System.Serializable]
	public class SetFloat : PlayerPrefsAction {
		[Tooltip("The value to set.")]
		public FsmFloat value;
	
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;

		public override void OnEnter ()
		{
			PlayerPrefs.SetFloat (key.Value, value.Value);
			if (!everyFrame) {
				Finish();			
			}
		}

		public override void OnUpdate ()
		{	
			PlayerPrefs.SetFloat (key.Value, value.Value);
		}
		
	}
}