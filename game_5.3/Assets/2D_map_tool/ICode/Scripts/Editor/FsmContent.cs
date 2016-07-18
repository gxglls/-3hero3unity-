using UnityEngine;
using System.Collections;

namespace ICode.FSMEditor{
	public static class FsmContent  {
		public static GUIContent createState;
		public static GUIContent createSubFsm;

		public static GUIContent sequence;
		public static GUIContent makeTransition;
		public static GUIContent setAsDefault;
		public static GUIContent copy;
		public static GUIContent paste;
		public static GUIContent delete;
		public static GUIContent addToSelection;
		public static GUIContent saveAsAsset;
		public static GUIContent bindToGameObject;
		public static GUIContent moveToSubStateMachine;
		public static GUIContent moveToParentStateMachine;

		static FsmContent(){
			createState = new GUIContent ("Create State");	
			createSubFsm = new GUIContent ("Create Sub-State Machine");
			makeTransition = new GUIContent ("Make Transition");
			setAsDefault = new GUIContent ("Set As Default");
			copy = new GUIContent ("Copy");
			delete = new GUIContent ("Delete");
			paste= new GUIContent("Paste");
			sequence = new GUIContent ("Sequence");
			addToSelection = new GUIContent ("Add To Selection");
			saveAsAsset = new GUIContent ("Save As Asset");
			bindToGameObject = new GUIContent ("Bind To Selection");
			moveToSubStateMachine = new GUIContent ("Move To SubStateMachine");
			moveToParentStateMachine = new GUIContent ("Move To ParentSateMachine");
		}
	}
}