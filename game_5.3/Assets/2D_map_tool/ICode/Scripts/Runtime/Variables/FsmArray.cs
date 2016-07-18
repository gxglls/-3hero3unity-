using UnityEngine;
using System.Collections;
using System.Linq;

namespace ICode{
	[System.Serializable]
	public class FsmArray : FsmVariable{
		[SerializeField]
		private object[] value;
		public object[] Value {
			get {
				return this.value;
			}
			set {
				SetValue(value);
			}
		}
		
		public override System.Type VariableType {
			get {
				return typeof(object[]);
			}
		}
		
		public override void SetValue (object value)
		{
			this.value = (value as IList).Cast<object>().ToArray();
			if(onVariableChange == null){
				onVariableChange= new VariableChangedEvent();
			}
			onVariableChange.Invoke(this.value);
		}
		
		public override object GetValue ()
		{
			return this.value;
		}
		
		public static implicit operator object[](FsmArray value)
		{
			return value.Value;
		}
		
		public static implicit operator FsmArray(object[] value) { 
			var variable = ScriptableObject.CreateInstance<FsmArray>();
			variable.SetValue(value);
			return variable; 
		}
	}
}

