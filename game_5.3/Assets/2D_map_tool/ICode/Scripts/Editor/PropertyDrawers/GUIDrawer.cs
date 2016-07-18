using UnityEngine;
using UnityEditor;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

namespace ICode.FSMEditor{
	public class GUIDrawer {
		private static Dictionary<Type,PropertyDrawer> drawers;
		private static Dictionary<Type,FieldInfo[]> fieldsLookup;

		static GUIDrawer(){
			RebuildDrawers ();
			fieldsLookup = new Dictionary<Type, FieldInfo[]> ();
		}
		
		private static void RebuildDrawers(){
			GUIDrawer.drawers = new Dictionary<Type, PropertyDrawer>();
			Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
			for (int i = 0; i < (int)assemblies.Length; i++)
			{
				Assembly assembly = assemblies[i];
				Type[] types = assembly.GetExportedTypes();
				for (int j = 0; j < (int)types.Length; j++)
				{
					Type type = types[j];
					if (typeof(PropertyDrawer).IsAssignableFrom(type) && type.IsClass && !type.IsAbstract)
					{
						Type inspectedType = AttributeUtility.GetCustomDrawerAttribute(type);
						if (inspectedType != null && !GUIDrawer.drawers.ContainsKey(inspectedType))
						{
							PropertyDrawer drawer=(PropertyDrawer)Activator.CreateInstance(type);
							GUIDrawer.drawers.Add(inspectedType, drawer);
							Type[] subTypes=TypeUtility.GetSubTypes(inspectedType);
							for(int s = 0; s < subTypes.Length; s++){
								Type subType=subTypes[s];
								if(!GUIDrawer.drawers.ContainsKey(subType)){
									GUIDrawer.drawers.Add(subType,drawer);
								}
							}
						}
					}
				}
			}		
		}
		
		public static PropertyDrawer GetDrawer(FieldInfo field){
			Type type = AttributeUtility.GetPropertyAttribute (field);
			return GetDrawer (type);
		}

		public static PropertyDrawer GetDrawer(Type type){
			if (type == null) {
				return  null;			
			}
			PropertyDrawer drawer;
			GUIDrawer.drawers.TryGetValue(type, out drawer);
			return drawer;
		}

		public static void OnGUI(UnityEngine.Object targetObject){
			EditorGUI.BeginChangeCheck ();
			SerializedObject serializedObject = new SerializedObject (targetObject);
			serializedObject.Update ();
			FieldInfo[] fields;
			if(!fieldsLookup.TryGetValue (targetObject.GetType (),out fields)){
				fields=targetObject.GetPublicFields().OrderBy(field => field.MetadataToken).ToArray();

				fieldsLookup.Add(targetObject.GetType(),fields);
			}
			if(PreferencesEditor.GetBool(Preference.ShowActionTooltips) && !string.IsNullOrEmpty(targetObject.GetTooltip())){
				GUILayout.BeginVertical((GUIStyle)"hostview");

				GUILayout.Label(targetObject.GetTooltip(),FsmEditorStyles.wrappedLabelLeft);
				GUILayout.EndVertical();
			}


			for (int i=0; i< fields.Length; i++) {
				FieldInfo field=fields[i];
				if(field.HasAttribute(typeof(HideInInspector))){
					continue;
				}
				/*HeaderAttribute header=field.GetAttribute<HeaderAttribute>();
				if(header!= null){
					GUILayout.Label(header.header,EditorStyles.boldLabel);
				}*/

				PropertyDrawer drawer=GUIDrawer.GetDrawer(field);
				GUIContent content = field.GetInspectorGUIContent ();
				SerializedProperty property=serializedObject.FindProperty(field.Name);
				if(PreferencesEditor.GetBool(Preference.ShowVariableTooltips) && !string.IsNullOrEmpty(field.GetTooltip())){
					GUILayout.BeginVertical("box");
					GUILayout.Label(field.GetTooltip(),FsmEditorStyles.wrappedLabelLeft);
					GUILayout.EndVertical();
				}

				if(drawer != null){
					drawer.fieldInfo=field;
					drawer.OnGUI(property,content);
				}else{
					int indentLevel=EditorGUI.indentLevel;
					EditorGUI.indentLevel=	typeof(IList).IsAssignableFrom(field.FieldType)?indentLevel+1:indentLevel;
					EditorGUILayout.PropertyField (property, content,true);
					EditorGUI.indentLevel=indentLevel;
				}
			}


			if (EditorGUI.EndChangeCheck()) {
				serializedObject.ApplyModifiedProperties();
				ErrorChecker.CheckForErrors();
			}
		}

		public static bool ObjectTitlebar(UnityEngine.Object targetObject, bool foldout ,ref bool enabled, GenericMenu settings){
			int controlID = EditorGUIUtility.GetControlID (FocusType.Passive);
			GUIContent content = new GUIContent (targetObject.name.Replace("/","."), targetObject.GetTooltip());
			
			Rect position= GUILayoutUtility.GetRect(GUIContent.none, FsmEditorStyles.inspectorTitle);
			Rect rect = new Rect(position.x + (float)FsmEditorStyles.inspectorTitle.padding.left, position.y + (float)FsmEditorStyles.inspectorTitle.padding.top, 16f, 16f);
			Rect rect1 = new Rect(position.xMax - (float)FsmEditorStyles.inspectorTitle.padding.right - 2f - 16f, rect.y, 16f, 16f);
			Rect rect4 = rect1;
			rect4.x = rect4.x - 18f;
			
			Rect rect2 = new Rect(position.x + 2f + 2f + 16f*2, rect.y, 100f, rect.height)
			{
				xMax = rect4.xMin - 2f
			};
			Rect rect3 = new Rect(position.x + 16f, rect.y, 16f, 16f);
			
			enabled=GUI.Toggle (rect3, enabled,GUIContent.none);
			string url=targetObject.GetHelpUrl();
			
			if (ErrorChecker.HasErrors (targetObject)) {
				Rect rect5 = rect4;
				rect5.y += 1.0f;
				if(!string.IsNullOrEmpty(url)){
					rect5.x = rect5.x - 18f;
					rect2.xMax=rect5.x;
				}
				
				GUI.Label (rect5, FsmEditorStyles.errorIcon, FsmEditorStyles.inspectorTitleText);
			}
			
			if (GUI.Button(rect1, FsmEditorStyles.popupIcon,FsmEditorStyles.inspectorTitleText))
			{
				settings.ShowAsContext();
			}
			
			if (!string.IsNullOrEmpty(url) && GUI.Button(rect4, FsmEditorStyles.helpIcon,FsmEditorStyles.inspectorTitleText))
			{
				Application.OpenURL(url);
			}
			
			EventType eventType = Event.current.type;
			if (eventType != EventType.MouseDown) {
				if (eventType == EventType.Repaint)
				{
					FsmEditorStyles.inspectorTitle.Draw (position, GUIContent.none, controlID, foldout);
					Color color = GUI.contentColor;
					if (FsmEditor.Active != null && FsmEditor.Active.Owner != null) {
						
						ICodeBehaviour behaviour=FsmEditor.Active.Owner;
						if(behaviour.ActiveNode is State && (behaviour.ActiveNode as State).ActiveAction==targetObject){
							GUI.contentColor = Color.green;
						}
					}
					FsmEditorStyles.inspectorTitleText.Draw (rect2, content, controlID, foldout);	
					GUI.contentColor = color;
				}
			}
			position.width = 15;

			bool flag = FsmGUIUtility.DoToggleForward(position,controlID, foldout,GUIContent.none,GUIStyle.none);

			return flag;
		}
	}
}