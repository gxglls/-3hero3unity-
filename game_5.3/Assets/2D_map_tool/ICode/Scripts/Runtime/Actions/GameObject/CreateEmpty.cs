using UnityEngine;
using System;

namespace ICode.Actions{
	[Category(Category.GameObject)]
	[Tooltip("Creates an empty game object.")]
	[HelpUrl("http://docs.unity3d.com/ScriptReference/GameObject.html")]
	[System.Serializable]
	public class CreateEmpty : StateAction {
		[NotRequired]
		[SharedPersistent]
		[Tooltip("Create the empty game object at the position of another game object. If this value is set, position will be set as offset.")]
		public FsmGameObject spawnPoint;
		public FsmVector3 position;
		public FsmVector3 rotation;
		[InspectorLabel("Name")]
		[Tooltip("Name of the new created game object.")]
		public FsmString _name;
		[NotRequired]
		[Shared]
		[Tooltip("Store the created object.")]
		public FsmGameObject storeObject;

		
		public override void OnEnter ()
		{
			GameObject createdObject = new GameObject (_name.IsNone?string.Empty:_name.Value);
			createdObject.transform.position = FsmUtility.GetPosition(spawnPoint,position);
			createdObject.transform.rotation = Quaternion.Euler (rotation.Value);
			if (!storeObject.IsNone) {
				storeObject.Value=createdObject;			
			}
			Finish ();
		}
	}
}