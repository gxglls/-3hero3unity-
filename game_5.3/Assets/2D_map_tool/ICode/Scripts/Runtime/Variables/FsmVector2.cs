using UnityEngine;
using System.Collections;

namespace ICode{
	[System.Serializable]
	public class FsmVector2 : FsmVariable {
		[SerializeField]
		private Vector2 value;
		public Vector2 Value {
			get {
				return this.value;
			}
			set {
				SetValue(value);
			}
		}

		public override System.Type VariableType {
			get {
				return typeof(Vector2);
			}
		}

		public override void SetValue (object value)
		{
			this.value = (Vector2)value;
			if(onVariableChange == null){
				onVariableChange= new VariableChangedEvent();
			}
			onVariableChange.Invoke(this.value);
		}
		
		public override object GetValue ()
		{
			return this.value;
		}

		public static implicit operator Vector2(FsmVector2 value)
		{
			return value.Value;
		}
		
		public static implicit operator FsmVector2(Vector2 value) { 
			var variable = ScriptableObject.CreateInstance<FsmVector2>();
			variable.SetValue(value);
			return variable; 
		}
	}
}

