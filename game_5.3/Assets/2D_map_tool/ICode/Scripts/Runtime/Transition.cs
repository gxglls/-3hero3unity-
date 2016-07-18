using UnityEngine;
using System.Collections;
using ICode.Conditions;

namespace ICode{
	[System.Serializable]
	public class Transition:ScriptableObject {
		[Reference]
		[SerializeField]
		private Node toNode;
		public Node ToNode
		{
			get
			{
				return this.toNode;
			}
			set
			{
				this.toNode = value;
			}
		}

		[Reference]
		[SerializeField]
		private Node fromNode;
		public Node FromNode
		{
			get
			{
				return this.fromNode;
			}
			set
			{
				this.fromNode = value;
			}
		}

		[SerializeField]
		private bool mute;
		public bool Mute{
			get{
				return this.mute;
			}
			set{
				this.mute=value;
			}
		}

		[SerializeField]
		private Condition[] conditions= new Condition[0];
		public Condition[] Conditions{
			get{
				return this.conditions;
			}
			set{
				this.conditions=value;
			}
		}

        public void Init(Node toNode,Node fromNode) {
            this.toNode = toNode;
			this.fromNode = fromNode;
        }

		public Node Validate(){
			if (mute) {
				return null;		
			}
			for(int i=0;i< conditions.Length;i++) {
				/*Condition condition = conditions[i];
			if(!condition.IsEntered){
					condition.IsEntered=true;
					condition.Init(FromNode);
					condition.OnEnter();
				}*/
				if(conditions[i].IsEnabled && !conditions[i].Validate()){
					return null;
				}
			}
			return ToNode;
		}

		public virtual void OnEnter(){
			for(int i=0;i< conditions.Length;i++) {
				Condition condition = conditions[i];
				if(!condition.IsEntered){
					condition.IsEntered=true;
					condition.Init(FromNode);
					condition.OnEnter();
				}
			}
		}

		public virtual void OnExit(){
			for (int i=0; i< conditions.Length; i++) {
				Condition condition = conditions[i];
				condition.IsEntered=false;
				condition.OnExit();
			}
		}
	}
}