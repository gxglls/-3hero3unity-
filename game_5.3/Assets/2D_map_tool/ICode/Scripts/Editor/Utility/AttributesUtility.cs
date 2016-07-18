using ICode;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEditor;

namespace ICode.FSMEditor{
	public static class AttributeUtility  {
		private readonly static Dictionary<Type, object[]> typeAttributeCache;
		private readonly static Dictionary<FieldInfo, object[]> fieldAttributeCache;
		private readonly static Dictionary<FieldInfo,GUIContent> inspectorContentCache;

		static AttributeUtility(){
			AttributeUtility.typeAttributeCache = new Dictionary<Type, object[]>();
			AttributeUtility.fieldAttributeCache = new Dictionary<FieldInfo, object[]>();
			AttributeUtility.inspectorContentCache = new Dictionary<FieldInfo, GUIContent> ();
		}

		public static object[] GetCustomAttributes(Type type)
		{
			object[] customAttributes;
			if (!AttributeUtility.typeAttributeCache.TryGetValue(type, out customAttributes))
			{
				customAttributes = type.GetCustomAttributes(true);
				AttributeUtility.typeAttributeCache.Add(type, customAttributes);
			}
			return customAttributes;
		}
		
		public static object[] GetCustomAttributes(FieldInfo field)
		{
			object[] customAttributes;
			if (!AttributeUtility.fieldAttributeCache.TryGetValue(field, out customAttributes))
			{
				customAttributes = field.GetCustomAttributes(true);
				AttributeUtility.fieldAttributeCache.Add(field, customAttributes);
			}
			return customAttributes;
		}

		
		public static Type GetCustomDrawerAttribute(object[] attributes)
		{
			object[] objArray = attributes;
			for (int i = 0; i < (int)objArray.Length; i++)
			{
				CustomDrawerAttribute drawerAttribute = objArray[i] as CustomDrawerAttribute;
				if (drawerAttribute != null)
				{
					return drawerAttribute.Type;
				}
			}
			return null;
		}

		public static Type GetCustomDrawerAttribute(Type type){
			return AttributeUtility.GetCustomDrawerAttribute(AttributeUtility.GetCustomAttributes(type));	
		}

		public static Type GetPropertyAttribute(FieldInfo field){
			return AttributeUtility.GetPropertyAttribute(AttributeUtility.GetCustomAttributes(field)) ?? field.FieldType;	
		}

		public static Type GetPropertyAttribute(object[] attributes)
		{
			object[] objArray = attributes;
			for (int i = 0; i < (int)objArray.Length; i++)
			{
				PropertyAttribute propertyAttribute = objArray[i] as PropertyAttribute;
				if (propertyAttribute != null)
				{
					return propertyAttribute.GetType();
				}
			}
			return null;
		}

		public static bool IsSerialized(this FieldInfo field){
			object[] objArray=AttributeUtility.GetCustomAttributes(field);
			for (int i = 0; i < (int)objArray.Length; i++)
			{
				if (objArray[i] is SerializeField)
				{
					return true;
				}
			}
			return field.IsPublic && !field.IsNotSerialized;
		}

		public static T GetAttribute<T>(this FieldInfo field){
			object[] objArray=AttributeUtility.GetCustomAttributes(field);
			for (int i = 0; i < (int)objArray.Length; i++)
			{
				if (objArray[i].GetType() == typeof(T) || objArray[i].GetType().IsSubclassOf(typeof(T)))
				{
					return (T)objArray[i];
				}
			}
			return default(T);		
		}

		public static bool HasAttribute(this FieldInfo field, Type attributeType){
			object[] objArray=AttributeUtility.GetCustomAttributes(field);
			for (int i = 0; i < (int)objArray.Length; i++)
			{
				if (objArray[i].GetType() == attributeType || objArray[i].GetType().IsSubclassOf(attributeType))
				{
					return true;
				}
			}
			return false;
		}

		public static string GetInspectorLabel(this FieldInfo field)
		{
			string label = AttributeUtility.GetInspectorLabel (AttributeUtility.GetCustomAttributes (field));
			if(string.IsNullOrEmpty(label)){
				label=System.Text.RegularExpressions.Regex.Replace(char.ToUpper(field.Name[0]) + field.Name.Substring(1), "(?<!^)_?([A-Z])", " $1");
			}
			return label;
		}
		
		public static string GetInspectorLabel(object[] attributes)
		{
			object[] objArray = attributes;
			for (int i = 0; i < (int)objArray.Length; i++)
			{
				InspectorLabelAttribute inspectorLabelAttribute = objArray[i] as InspectorLabelAttribute;
				if (inspectorLabelAttribute != null)
				{
					return inspectorLabelAttribute.Label;
				}
			}
			return string.Empty;
		}
		
		public static GUIContent GetInspectorGUIContent(this FieldInfo field)
		{
			GUIContent inspectorGUIContent;
			if (!AttributeUtility.inspectorContentCache.TryGetValue(field, out inspectorGUIContent))
			{
				inspectorGUIContent =new GUIContent(field.GetInspectorLabel(),field.GetTooltip());
				AttributeUtility.inspectorContentCache.Add(field, inspectorGUIContent);
			}
			return inspectorGUIContent;
		}

		public static string GetCategory(this object obj){
			return GetCategory (obj.GetType ());
		}
		
		public static string GetCategory(this Type type){
			object[] objArray=AttributeUtility.GetCustomAttributes(type);
			for (int i = 0; i < (int)objArray.Length; i++)
			{
				CategoryAttribute categoryAttribute = objArray[i] as CategoryAttribute;
				if (categoryAttribute != null)
				{
					return categoryAttribute.Category;
				}
			}
			return string.Empty;
		}

		public static string GetTooltip(this object obj)
		{
			return AttributeUtility.GetTooltip(obj.GetType());
		}
		
		public static string GetTooltip(this Type type)
		{
			return AttributeUtility.GetTooltip(AttributeUtility.GetCustomAttributes(type));
		}
		
		public static string GetTooltip(this FieldInfo field)
		{
			return AttributeUtility.GetTooltip(AttributeUtility.GetCustomAttributes(field));
		}

		public static string GetTooltip(object[] attributes)
		{
			object[] objArray = attributes;
			for (int i = 0; i < (int)objArray.Length; i++)
			{
				TooltipAttribute tooltipAttribute = objArray[i] as TooltipAttribute;
				if (tooltipAttribute != null)
				{
					return tooltipAttribute.Text;
				}
			}
			return string.Empty;
		}

		public static string GetHelpUrl(this object obj){
			return GetHelpUrl (obj.GetType ());
		}
		
		public static string GetHelpUrl(this Type type){
			object[] objArray=AttributeUtility.GetCustomAttributes(type);
			for (int i = 0; i < (int)objArray.Length; i++)
			{
				HelpUrlAttribute infoAttribute = objArray[i] as HelpUrlAttribute;
				if (infoAttribute != null)
				{
					return infoAttribute.Url;
				}
			}
			return string.Empty;
		}
	}
}