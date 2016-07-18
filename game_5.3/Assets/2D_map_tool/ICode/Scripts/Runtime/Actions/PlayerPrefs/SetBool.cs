using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityPlayerPrefs{
	[Category(Category.PlayerPrefs)]
	[Tooltip("Sets the value of the preference identified by key.")]
	[System.Serializable]
	public class SetBool : PlayerPrefsAction {
		[Tooltip("The value to set.")]
		public FsmBool value;
		
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;

		public override void OnEnter ()
		{
			PlayerPrefs.SetInt (key.Value, value.Value?1:0);
			if (!everyFrame) {
				Finish();			
			}
		}

		public override void OnUpdate ()
		{	
			PlayerPrefs.SetInt (key.Value, value.Value?1:0);
		}
		
	}
}