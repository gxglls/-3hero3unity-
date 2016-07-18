using UnityEngine;
using System.Collections;

namespace ICode{
	[System.Serializable]
	public class FsmObject : FsmVariable {
		[SerializeField]
		private Object value;
		public Object Value {
			get {
				return this.value;
			}
			set {
				SetValue(value);
			}
		}
		
		public override System.Type VariableType {
			get {
				return typeof(Object);
			}
		}
		
		public override void SetValue (object value)
		{
			this.value = (Object)value;
			if(onVariableChange == null){
				onVariableChange= new VariableChangedEvent();
			}
			onVariableChange.Invoke(this.value);
		}
		
		public override object GetValue ()
		{
			return this.value;
		}
	}
}

