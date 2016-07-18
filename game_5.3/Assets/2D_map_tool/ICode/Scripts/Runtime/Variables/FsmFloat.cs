using UnityEngine;
using System.Collections;

namespace ICode{
	[System.Serializable]
	public class FsmFloat : FsmVariable {
		[SerializeField]
		private float value;
		public float Value {
			get {
				return this.value;
			}
			set {
				SetValue(value);
			}
		}
		
		public override System.Type VariableType {
			get {
				return typeof(float);
			}
		}
		
		public override void SetValue (object value)
		{
			this.value = (float)value;
			if(onVariableChange == null){
				onVariableChange= new VariableChangedEvent();
			}
			onVariableChange.Invoke(this.value);
		}
		
		public override object GetValue ()
		{
			return this.value;
		}
		
		public static implicit operator float(FsmFloat value)
		{
			return value.Value;
		}
		
		public static implicit operator FsmFloat(float value) { 
			var variable = ScriptableObject.CreateInstance<FsmFloat>();
			variable.SetValue(value);
			return variable; 
		}
	}
}

