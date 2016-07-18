using UnityEngine;
using System.Collections;

namespace ICode{
	[System.Serializable]
	public class FsmBool : FsmVariable{
		[SerializeField]
		private bool value;
		public bool Value {
			get {
				return this.value;
			}
			set {
				SetValue(value);
			}
		}

		public override System.Type VariableType {
			get {
				return typeof(bool);
			}
		}

		public override void SetValue (object value)
		{
			this.value = (bool)value;
			if(onVariableChange == null){
				onVariableChange= new VariableChangedEvent();
			}
			onVariableChange.Invoke(this.value);
		}

		public override object GetValue ()
		{
			return this.value;
		}

		public static implicit operator bool(FsmBool value)
		{
			return value.Value;
		}
		
		public static implicit operator FsmBool(bool value) { 
			var variable = ScriptableObject.CreateInstance<FsmBool>();
			variable.SetValue(value);
			return variable; 
		}
	}
}

