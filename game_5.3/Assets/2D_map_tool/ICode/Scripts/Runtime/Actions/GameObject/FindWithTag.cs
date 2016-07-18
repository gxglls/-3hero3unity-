using UnityEngine;
using System.Collections;

namespace ICode.Actions{
	[Category(Category.GameObject)]
	[Tooltip("Finds a game object by tag.")]
	[HelpUrl("https://docs.unity3d.com/Documentation/ScriptReference/GameObject.FindWithTag.html")]
	[System.Serializable]
	public class FindWithTag : StateAction {
		[Tag]
		[Tooltip("The tag to find.")]
		public FsmString tag;
		[Shared]
		[Tooltip("Store the result.")]
		public FsmGameObject store;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;

		public override void OnEnter ()
		{
			store.Value = GameObject.FindWithTag (tag.Value);
			if(!everyFrame){
				Finish ();
			}
		}

		public override void OnUpdate ()
		{
			store.Value = GameObject.FindWithTag (tag.Value);
		}
	}
}