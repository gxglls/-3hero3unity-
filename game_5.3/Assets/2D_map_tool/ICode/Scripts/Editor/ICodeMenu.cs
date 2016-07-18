using UnityEngine;
using UnityEditor;
using System.Collections;

namespace ICode.FSMEditor{
	public static class ICodeMenu {
		[MenuItem("Window/Zerano Assets/ICode/Open Editor",false,2)]
		public static void OpenFsmEditor()
		{
			FsmEditor.ShowWindow ();
		}

		[MenuItem("Window/Zerano Assets/ICode/Fsm Tool",false,2)]
		public static void OpenFsmToolEditor()
		{
			FsmTool.ShowWindow ();
		}

		[MenuItem("Window/Zerano Assets/ICode/MonoBehaviour Converter",false,2)]
		public static void OpenConverterEditor()
		{
			MonoBehaviourConverter.ShowWindow ();
		}

		[MenuItem("Window/Zerano Assets/ICode/Create State Machine",false,2)]
		public static void CreateStateMachine()
		{
			FsmEditor.ShowWindow ();
			StateMachine stateMachine = AssetCreator.CreateAsset<StateMachine> (true);
			if (stateMachine == null) {
				return;			
			}
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
			FsmEditor.SelectStateMachine(stateMachine);
			
		}
	}
}