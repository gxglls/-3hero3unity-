using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace ICode.Actions{
	[Category(Category.GameObject)]
	[Tooltip("Finds a game object by name.")]
	[HelpUrl("https://docs.unity3d.com/Documentation/ScriptReference/GameObject.Find.html")]
	[System.Serializable]
	public class Find : StateAction {
		[InspectorLabel("Name")]
		[Tooltip("The name of the game object to find.")]
		public FsmString _name;
		[Tooltip("Should inactive GameObjects be included into the search?")]
		public FsmBool includeInactive;
		[Shared]
		[Tooltip("Store the result.")]
		public FsmGameObject store;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;

		public override void OnEnter ()
		{
			store.Value = DoFind ();
			if (!everyFrame) {
				Finish ();		
			}
		}

		public override void OnUpdate ()
		{
			store.Value = DoFind ();

		}

		private GameObject DoFind(){
			GameObject go = GameObject.Find (_name.Value);
			if (includeInactive.Value && go == null) {
				Transform[] gos= FsmUtility.FindAll<Transform>(true);
				foreach(Transform tr in gos){
					if(tr.name== _name.Value){
						return tr.gameObject;
					}
				}
			}
			return go;
		}


	}
}