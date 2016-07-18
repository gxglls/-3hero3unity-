using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityResources{
	[Category(Category.Resources)]   
	[Tooltip("Unloads assetToUnload from memory.")]
	[HelpUrl("http://docs.unity3d.com/ScriptReference/Resources.UnloadAsset.html")]
	[System.Serializable]
	public class UnloadAsset : StateAction {
		[Tooltip("Asset to unload.")]
		public FsmObject asset;
		public override void OnEnter ()
		{
			Resources.UnloadAsset (asset);
			Finish();			
		}
	}
}