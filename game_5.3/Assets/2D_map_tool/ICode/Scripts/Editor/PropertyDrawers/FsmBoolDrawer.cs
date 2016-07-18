using UnityEngine;
using System.Collections;

namespace ICode.FSMEditor{
	[CustomDrawer(typeof(FsmBool))]
	public class FsmBoolDrawer : FsmVariableDrawer {
		public override void OnPropertyField (UnityEditor.SerializedProperty property, GUIContent label)
		{
			GUILayout.BeginHorizontal ();
			base.OnPropertyField (property, label);
			GUILayout.Label (property.boolValue.ToString());
			GUILayout.EndHorizontal ();
		}
	}
}