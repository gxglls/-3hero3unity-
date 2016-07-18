using UnityEngine;
using System.Collections;

namespace ICode{
	[System.Serializable]
	public class FsmString : FsmVariable {
		[SerializeField]
		private string value;
		public string Value {
			get {
				return this.value;
			}
			set {
				SetValue(value);
			}
		}

		public override System.Type VariableType {
			get {
				return typeof(string);
			}
		}

		public override void SetValue (object value)
		{
			this.value = (string)value;
			if(onVariableChange == null){
				onVariableChange= new VariableChangedEvent();
			}
			onVariableChange.Invoke(this.value);
		}
		
		public override object GetValue ()
		{
			return this.value;
		}

		public static implicit operator string(FsmString value)
		{
			return value.Value;
		}
		
		public static implicit operator FsmString(string value) { 
			var variable = ScriptableObject.CreateInstance<FsmString>();
			variable.SetValue(value);
			return variable; 
		}
	}
}

