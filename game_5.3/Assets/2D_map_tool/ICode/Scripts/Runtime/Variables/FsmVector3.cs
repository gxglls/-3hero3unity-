using UnityEngine;
using System.Collections;

namespace ICode{
	[System.Serializable]
	public class FsmVector3 : FsmVariable {
		[SerializeField]
		private Vector3 value;
		public Vector3 Value {
			get {
				return this.value;
			}
			set {
				SetValue(value);
			}
		}
		
		public override System.Type VariableType {
			get {
				return typeof(Vector3);
			}
		}
		
		public override void SetValue (object value)
		{
			this.value = (Vector3)value;
			if(onVariableChange == null){
				onVariableChange= new VariableChangedEvent();
			}
			onVariableChange.Invoke(this.value);
		}
		
		public override object GetValue ()
		{
			return this.value;
		}
		
		public static implicit operator Vector3(FsmVector3 value)
		{
			return value.Value;
		}
		
		public static implicit operator FsmVector3(Vector3 value) { 
			var variable = ScriptableObject.CreateInstance<FsmVector3>();
			variable.SetValue(value);
			return variable; 
		}
	}
}

