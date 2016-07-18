using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityPlayerPrefs{
	[Category(Category.PlayerPrefs)]
	[Tooltip("Returns the value corresponding to key in the preference file if it exists.")]
	[System.Serializable]
	public class GetBool : PlayerPrefsAction {
		[Tooltip("The default value to set, if the key does not exist.")]
		public FsmBool defaultValue;
		[Shared]
		[Tooltip("Store the result")]
		public FsmBool store;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;

		public override void OnEnter ()
		{
			store.Value = (PlayerPrefs.GetInt (key.Value, defaultValue.Value?1:0)==0?false:true);
			
			if (!everyFrame) {
				Finish();			
			}
		}

		public override void OnUpdate ()
		{	
			store.Value = (PlayerPrefs.GetInt (key.Value, defaultValue.Value?1:0)==0?false:true);
		}
		
	}
}