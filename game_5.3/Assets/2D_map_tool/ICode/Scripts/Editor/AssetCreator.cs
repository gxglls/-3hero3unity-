using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Linq;
using ICode;
using ArrayUtility=ICode.ArrayUtility;

namespace ICode.FSMEditor{
	public static class AssetCreator {

		[MenuItem("Assets/Create/Zerano Assets/ICode/State Machine")]
		public static void CreateStateMachineAsset()
		{
			StateMachine stateMachine = AssetCreator.CreateAsset<StateMachine> (false);
			stateMachine.color = (int)NodeColor.Blue;
			stateMachine.Name = stateMachine.name;
		
			FsmGameObject gameObject = ScriptableObject.CreateInstance<FsmGameObject> ();
			gameObject.Name="Owner";
			gameObject.hideFlags = HideFlags.HideInHierarchy;
			gameObject.IsHidden = true;
			gameObject.IsShared = true;

			stateMachine.Variables = ArrayUtility.Add<FsmVariable> (stateMachine.Variables, gameObject);
			AssetDatabase.AddObjectToAsset (gameObject, stateMachine);
			AssetDatabase.SaveAssets ();


			AnyState state = FsmEditorUtility.AddNode<AnyState> (FsmEditor.Center,stateMachine);
			state.color = (int)NodeColor.Aqua;
			state.Name="Any State";
		}

		/// <summary>
		/// Creates a custom asset
		/// </summary>
		public static T CreateAsset<T> (bool displayFilePanel) where T : ScriptableObject
		{
			if (displayFilePanel) {
				T asset = null;
				string mPath = EditorUtility.SaveFilePanelInProject (
					"Create Asset of type " + typeof(T).Name,
					"New " + typeof(T).Name + ".asset",
					"asset", "");
				
				asset = CreateAsset<T> (mPath);
				return asset;
			}
			return CreateAsset<T> ();
		}
		
		/// <summary>
		/// Creates a custom asset at selected Object
		/// </summary>
		public static T CreateAsset<T> () where T : ScriptableObject
		{
			T asset = null;
			string path = AssetDatabase.GetAssetPath (Selection.activeObject);
			
			if (path == "") {
				path = "Assets";
			} else if (System.IO.Path.GetExtension (path) != "") {
				path = path.Replace (System.IO.Path.GetFileName (AssetDatabase.GetAssetPath (Selection.activeObject)), "");
			}
			string assetPathAndName = AssetDatabase.GenerateUniqueAssetPath (path + "/New " + typeof(T).Name + ".asset");
			asset = CreateAsset<T> (assetPathAndName);
			return asset;
		}
		
		/// <summary>
		/// Creates a custom asset at path
		/// </summary>
		public static T CreateAsset<T> (string path) where T : ScriptableObject
		{
			if (string.IsNullOrEmpty (path)) {
				return null;
			}
			T data = null;
			data = ScriptableObject.CreateInstance<T> ();
			AssetDatabase.CreateAsset (data, path);
			AssetDatabase.SaveAssets ();
			return data;
		}
	}
}
