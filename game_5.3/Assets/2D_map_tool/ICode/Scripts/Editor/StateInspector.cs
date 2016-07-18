using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System;
using ICode;
using ICode.Actions;
using ArrayUtility=ICode.ArrayUtility;

namespace ICode.FSMEditor{
	[CustomEditor(typeof(State),true)]
	public class StateInspector : NodeInspector {
		private ActionEditor actionEditor;
		private State state;

		public override void OnEnable() {
			base.OnEnable ();
			state = node as State;
			actionEditor = new ActionEditor (state, this);
			actionEditor.OnEnable ();
		}

	
		private void CreateAction(Type type){
			if (!type.IsSubclassOf (typeof(StateAction)) || state == null) {
				return;			
			}
			StateAction action = (StateAction)ScriptableObject.CreateInstance(type);
			if (EditorUtility.IsPersistent (state)) {
				AssetDatabase.AddObjectToAsset (action, state);
				AssetDatabase.SaveAssets();
			}
			state.Actions = ArrayUtility.Add<StateAction> (state.Actions, action);
		
		}

		public override void OnInspectorGUI (){
			actionEditor.OnInspectorGUI ();
			GUILayout.Space (10f);
			base.OnInspectorGUI ();
			if (GUI.changed) {
				EditorUtility.SetDirty(state);			
			}
		}

		protected override void MarkDirty ()
		{
			base.MarkDirty ();
			actionEditor.OnEnable ();
		}
	}
}