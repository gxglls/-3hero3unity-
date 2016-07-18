using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

namespace ICode{
	[System.Serializable]
	public class SerializedVariable  {
		public string name;
		[SerializeField]
		private string type;
		public Type SerializedType{
			get{
				return TypeUtility.GetType(type);
			}
			set{
				type=value.ToString();
			}
		}

		public int intValue;
		public float floatValue;
		public UnityEngine.Object objectReferenceValue;
		public string stringValue;
		public Color colorValue;
		public Vector2 vector2Value;
		public Vector3 vector3Value;
		public bool boolValue;
		public GameObject gameObjectValue;

		public object GetValue(){
			Type mType = SerializedType;

			if (mType == null) {
				return null;			
			}else if (mType == typeof(string)) {
				return stringValue;		
			}else if (mType == typeof(bool)) {
				return boolValue;
			} else if (mType == typeof(Color)) {
				return colorValue;
			} else if (mType == typeof(float)) {
				return floatValue;
			}else if(mType == typeof(GameObject)){
				return gameObjectValue;
			} else if (typeof(UnityEngine.Object).IsAssignableFrom(mType)) {
				return objectReferenceValue;
			} else if (mType == typeof(int)) {
				return intValue;
			} else if (mType == typeof(Vector2)) {
				return vector2Value;
			} else if (mType == typeof(Vector3)) {
				return vector3Value;
			} else {
				return null;
			}
		}

		public void SetValue(object value){
			Type mType = value.GetType();
			if (mType == typeof(string)) {
				stringValue=(string)value;		
			}else if (mType == typeof(bool)) {
				boolValue=(bool)value;
			} else if (mType == typeof(Color)) {
				colorValue=(Color)value;
			} else if (mType == typeof(float)) {
				floatValue=(float)value;
			} else if(mType == typeof(GameObject)){
				gameObjectValue=(GameObject)value;
			}else if (typeof(UnityEngine.Object).IsAssignableFrom(mType)) {
				objectReferenceValue=(UnityEngine.Object)value;
			} else if (mType == typeof(int)) {
				intValue=(int)value;
			} else if (mType == typeof(Vector2)) {
				vector2Value=(Vector2)value;
			} else if (mType == typeof(Vector3)) {
				vector3Value=(Vector3)value;
			} 
		}

		public static string GetPropertyName(Type mType){
			if (mType == typeof(string)) {
				return "stringValue";		
			} else if (mType == typeof(bool)) {
				return "boolValue";
			} else if (mType==typeof(Color)) {
				return "colorValue";
			} else if (mType == typeof(float)) {
				return "floatValue";
			}else if(mType == typeof(GameObject)){
				return "gameObjectValue";
			}else if (typeof(UnityEngine.Object).IsAssignableFrom (mType)) {
				return "objectReferenceValue";
			} else if (mType == typeof(int)) {
				return "intValue";
			} else if (mType == typeof(Vector2)) {
				return "vector2Value";
			} else if (mType == typeof(Vector3)) {
				return "vector3Value";
			}	
			return string.Empty;
		}

		public static Type[] SupportedTypes{
			get{
				return new Type[9]{
					typeof(string),
					typeof(bool),
					typeof(Color),
					typeof(float),
					typeof(GameObject),
					typeof(UnityEngine.Object),
					typeof(int),
					typeof(Vector2),
					typeof(Vector3)
				};
			}
		}

		public static string[] DisplayNames{
			get{
				return new string[10]{
					"None",
					"FsmString",
					"FsmBool",
					"FsmColor",
					"FsmFloat",
					"FsmGameObject",
					"FsmObject",
					"FsmInt",
					"FsmVector2",
					"FsmVector3"
				};
			}
		}
	}
}