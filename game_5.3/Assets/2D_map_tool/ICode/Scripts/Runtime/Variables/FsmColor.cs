using UnityEngine;
using System.Collections;

namespace ICode{
	[System.Serializable]
	public class FsmColor : FsmVariable {
		[SerializeField]
		private Color value;
		public Color Value {
			get {
				return this.value;
			}
			set {
				SetValue(value);
			}
		}
		
		public override System.Type VariableType {
			get {
				return typeof(Color);
			}
		}
		
		public override void SetValue (object value)
		{
			this.value = (Color)value;
			if(onVariableChange == null){
				onVariableChange= new VariableChangedEvent();
			}
			onVariableChange.Invoke(this.value);
		}
		
		public override object GetValue ()
		{
			return this.value;
		}
		
		public static implicit operator Color(FsmColor value)
		{
			return value.Value;
		}
		
		public static implicit operator FsmColor(Color value) { 
			var variable = ScriptableObject.CreateInstance<FsmColor>();
			variable.SetValue(value);
			return variable; 
		}
	}
}

