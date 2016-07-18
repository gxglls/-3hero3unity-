using UnityEngine;
using System;
using System.Linq;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;

namespace ICode{
	public static class TypeUtility {
		private static Assembly[] assembliesLookup;
		private static Dictionary<string, Type> typeLookup;
		static TypeUtility(){
			assembliesLookup = AppDomain.CurrentDomain.GetAssemblies();
			// Remove Editor assemblies
			var runtimeAsms = new List<Assembly>();
			foreach (Assembly asm in assembliesLookup) {
				if (!asm.GetName().Name.Contains("Editor"))
					runtimeAsms.Add(asm);
			}
			assembliesLookup = runtimeAsms.ToArray();
			typeLookup = new Dictionary<string, Type> ();

		}

		public static string[] GetSubTypeNames(Type baseType){
			return GetSubTypes (baseType).Select (x => x.Name).ToArray();
		}

		public static Type[] GetSubTypes(Type baseType){
			IEnumerable<Type> types= AppDomain.CurrentDomain.GetAssemblies().SelectMany(assembly => assembly.GetTypes()) .Where(type => type.IsSubclassOf(baseType));
			return types.ToArray();
		}

		public static Type GetMemberType(Type type, string name){
			FieldInfo fieldInfo = type.GetField (name);
			if (fieldInfo != null) {
				return fieldInfo.FieldType;			
			}
			PropertyInfo propertyInfo=type.GetProperty(name);
			if(propertyInfo != null){
				return propertyInfo.PropertyType;
			}
			return null;
		}

		public static Type GetType (string name) {
		/*	Type type = null;
			if (typeLookup.TryGetValue (name, out type)) {
				return type;
			}
			type =Type.GetType(name) ?? Type.GetType("UnityEngine."+name+",UnityEngine") ?? Type.GetType (name + ",Assembly-CSharp-firstpass") ?? Type.GetType (name + ",Assembly-CSharp");
			if (type == null) {
				foreach (Assembly asm in TypeUtility.assembliesLookup) {
					type = asm.GetType (name);
					if (type != null)
						break;
				}
			}

			typeLookup.Add(name, type);
			return type;*/

			Type type = null;
			if (typeLookup.TryGetValue (name, out type)) {
				return type;
			}
			
			foreach (Assembly a in assembliesLookup)
			{
				Type[] assemblyTypes = a.GetTypes();
				for (int j = 0; j < assemblyTypes.Length; j++)
				{
					if (assemblyTypes[j].Name == name)
					{
						typeLookup.Add(name, assemblyTypes[j]);
						return assemblyTypes[j];
					}
				}
			}

			return null;

		}

		public static Type[] GetTypeByName(string className)
		{
			List<Type> returnVal = new List<Type>();
			
			foreach (Assembly a in AppDomain.CurrentDomain.GetAssemblies())
			{
				Type[] assemblyTypes = a.GetTypes();
				for (int j = 0; j < assemblyTypes.Length; j++)
				{
					if (assemblyTypes[j].Name == className)
					{
						returnVal.Add(assemblyTypes[j]);
					}
				}
			}
			
			return returnVal.ToArray();
		}
	}
}