using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityPlayerPrefs{
	[Category(Category.PlayerPrefs)]
	[Tooltip("Returns the value corresponding to key in the preference file if it exists.")]
	[System.Serializable]
	public class GetVector3 : PlayerPrefsAction {
		[Tooltip("The default value to set, if the key does not exist.")]
		public FsmVector3 defaultValue;
		[Shared]
		[Tooltip("Store the result.")]
		public FsmVector3 store;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;

		public override void OnEnter ()
		{
			DoGetVector3 ();
			if (!everyFrame) {
				Finish();			
			}
		}

		public override void OnUpdate ()
		{	
			DoGetVector3 ();
		}

		private void DoGetVector3(){
			float x=PlayerPrefs.GetFloat (key.Value+"_x", defaultValue.Value.x);
			float y=PlayerPrefs.GetFloat (key.Value+"_y", defaultValue.Value.y);
			float z=PlayerPrefs.GetFloat (key.Value+"_z", defaultValue.Value.z);
			store.Value = new Vector3 (x, y, z);
		}
	}
}