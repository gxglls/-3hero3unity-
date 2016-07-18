using UnityEngine;
using System.Collections;
using System.Linq;
namespace ICode.Actions.UnityResources{
	[Category(Category.Resources)]     
	[Tooltip("Loads all assets in a folder or file at path in a Resources folder.")]
	[HelpUrl("http://docs.unity3d.com/ScriptReference/Resources.LoadAll.html")]
	[System.Serializable]
	public class LoadAll : StateAction {
		[Tooltip("Pathname of the target folder.")]
		public FsmString path;
		[Shared]
		[Tooltip("Store the loaded Objects")]
		public FsmArray store;
		public override void OnEnter ()
		{
			store.Value = Resources.LoadAll (path.Value).Cast<object>().ToArray();
			Finish();			
		}
	}
}