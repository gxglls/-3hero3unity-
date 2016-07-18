using UnityEngine;
using System.Collections;
using UnityEngine.Events;
using System;

namespace ICode{
	[System.Serializable]
	public abstract class FsmVariable:ScriptableObject, INameable {
		public VariableChangedEvent onVariableChange;

		[SerializeField]
		private bool isHidden=false;
		public bool IsHidden{
			get{
				return this.isHidden;
			}
			set{
				this.isHidden=value;
			}
		}

		[SerializeField]
		private bool isShared=false;
		public bool IsShared{
			get{
				return this.isShared;
			}
			set{
				this.isShared=value;
			}
		}

		public bool IsNone{
			get{
				return IsShared && Name=="None";
			}
		}

		[SerializeField]
		private new string name="None";
		public string Name
		{
			get{
				return this.name;
			}
			set{
				this.name=value;
				base.name=name;
			}
		}

		[SerializeField]
		private string group="Default";
		public string Group
		{
			get{
				return this.group;
			}
			set{
				this.group=value;
			}
		}

		public abstract Type VariableType { get;}
		public abstract void SetValue(object value);
		public abstract object GetValue();

		[System.Serializable]
		public class VariableChangedEvent:UnityEvent<object>{

		}
	}
}
