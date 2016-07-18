using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityResources{
	[Category(Category.Resources)]   
	[Tooltip("Loads an asset stored at path in a Resources folder.")]
	[HelpUrl("http://docs.unity3d.com/ScriptReference/Resources.Load.html")]
	[System.Serializable]
	public class Load : StateAction {
		[InspectorLabel("Name")]
		[Tooltip("Name of the Object")]
		public FsmString _name;
		[Shared]
		[Tooltip("Store the loaded Object")]
		public FsmObject storeObject;
		public override void OnEnter ()
		{
			storeObject.Value = Resources.Load (_name.Value);
			Finish();			
		}
	}
}