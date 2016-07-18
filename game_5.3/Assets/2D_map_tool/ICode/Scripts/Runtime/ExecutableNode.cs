using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

namespace ICode{
	[System.Serializable]
	public class ExecutableNode : ScriptableObject {

		[SerializeField]
		private bool enabled=true;
		public bool IsEnabled{
			get{
				return this.enabled;
			}
			set{
				this.enabled = value;
			}
		}
		[SerializeField]
		private bool isOpen=true;
		public bool IsOpen{
			get{
				return this.isOpen;
			}
			set{
				this.isOpen = value;
			}
		}

		private bool isEntered;
		public bool IsEntered{
			get{
				return this.isEntered;
			}
			set{
				this.isEntered = value;
			}
		}

		private StateMachine root;
		public StateMachine Root{
			get{
				return root;
			}
		}

		private bool initialized;

		public void Init(Node node){
			if (!initialized) {
				initialized=true;
				root=node.Root;
				FieldInfo[] fields = this.GetType().GetPublicFields();
				for (int k=0; k< fields.Length; k++) {
					if (typeof(FsmVariable).IsAssignableFrom(fields [k].FieldType)) {
						FsmVariable variable = (FsmVariable)fields [k].GetValue (this);
						if (variable != null && variable.IsShared) {
							FsmVariable fsmVariable=node.Root.GetVariable (variable.Name)??GlobalVariables.GetVariable(variable.Name);
							if(fsmVariable != null){
								fields [k].SetValue (this, fsmVariable);
							//	Debug.Log(this.GetType()+" "+variable.Name);
							}
						}
					}		
				}
			}
		}

		public FsmVariable[] GetSharedVariables(Node node){
			List<FsmVariable> sharedVariables = new List<FsmVariable> ();
			FieldInfo[] fields = this.GetType().GetPublicFields();
			for (int k=0; k< fields.Length; k++) {
				if (typeof(FsmVariable).IsAssignableFrom (fields [k].FieldType)) {
					FsmVariable variable = (FsmVariable)fields [k].GetValue (this);
					if (variable != null && variable.IsShared) {
						FsmVariable fsmVariable=node.Root.GetVariable (variable.Name);
						if(fsmVariable != null){
							sharedVariables.Add(fsmVariable);
						}
					}
				}
			}
			return sharedVariables.ToArray();
		}

		/// <summary>
		/// Checks for components.
		/// </summary>
		/// <returns>The type if missing component.</returns>
		/// <param name="gameObject">Game object.</param>
		public System.Type CheckForComponents(GameObject gameObject){
			object[] objArray = this.GetType().GetCustomAttributes(true);
		
			for (int i = 0; i < (int)objArray.Length; i++)
			{
				RequireComponent requireComponent = objArray[i] as RequireComponent;
				if (requireComponent != null)
				{
					System.Type type0= (requireComponent.m_Type0 != null && gameObject.GetComponent(requireComponent.m_Type0) == null)?requireComponent.m_Type0:null;
					if(type0 != null){
						return type0;
					}
					System.Type type1= (requireComponent.m_Type1 != null && gameObject.GetComponent(requireComponent.m_Type1) == null)?requireComponent.m_Type1:null;
					if(type1 != null){
						return type1;
					}
					System.Type type2= (requireComponent.m_Type2 != null && gameObject.GetComponent(requireComponent.m_Type2) == null)?requireComponent.m_Type2:null;
					if(type2 != null){
						return type2;
					}
				}
			}
			return null;
		}

		public virtual void OnEnterState(){}

		public virtual void OnEnter(){}
		
		public virtual void OnExit(){}

	}
}