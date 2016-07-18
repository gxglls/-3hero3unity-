using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityPlayerPrefs{
	[Category(Category.PlayerPrefs)]
	[Tooltip("Sets the value of the preference identified by key.")]
	[System.Serializable]
	public class SetVector3 : PlayerPrefsAction {
		[Tooltip("The value to set.")]
		public FsmVector3 value;
		
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;

		public override void OnEnter ()
		{
			DoSetVector3 ();
			if (!everyFrame) {
				Finish();			
			}
		}

		public override void OnUpdate ()
		{	
			DoSetVector3 ();
		}

		private void DoSetVector3(){
			PlayerPrefs.SetFloat (key.Value+"_x", value.Value.x);
			PlayerPrefs.SetFloat (key.Value+"_y", value.Value.y);
			PlayerPrefs.SetFloat (key.Value+"_z", value.Value.z);
		}
		
	}
}