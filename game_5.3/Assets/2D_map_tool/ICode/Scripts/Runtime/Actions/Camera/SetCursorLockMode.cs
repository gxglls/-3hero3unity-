using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityCamera{
	[Category(Category.Camera)]   
	[Tooltip("How should the cursor be handled?")]
	[HelpUrl("http://docs.unity3d.com/ScriptReference/Cursor-lockState.html")]
	[System.Serializable]
	public  class SetCursorLockMode : StateAction {
		#if UNITY_5
			public CursorLockMode mode;
		#else
			public FsmBool lockCursor;
		#endif

		public override void OnEnter (){
			#if UNITY_5
				Cursor.lockState = mode;
			#else
				Screen.lockCursor=lockCursor.Value;
			#endif
			Finish ();
		}
	}
}