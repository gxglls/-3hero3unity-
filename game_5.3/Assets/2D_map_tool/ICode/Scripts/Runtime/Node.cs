using UnityEngine;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace ICode{
	[System.Serializable]
	public class Node : ScriptableObject,INameable {
		public Rect position;
		public int color;
		public string comment;

		[SerializeField]
		private new string name;
		public string Name{
			get{
				return this.name;
			}
			set{
				this.name=value;
				base.name=value;
			}
		}

		[SerializeField]
		private bool isStartNode;
		public bool IsStartNode{
			get{
				return isStartNode;
			}
			set{
				isStartNode=value;
			}
		}

		private bool isFinished;
		public bool IsFinished
		{
			get{
				return this.isFinished;
			}
			set{
				this.isFinished=value;
			}
		}

		[Reference]
		[SerializeField]
		private StateMachine parent;
		public StateMachine Parent{
			get{
				return	this.parent;
			}
			set{
				this.parent = value;
			}
		}
		
		public StateMachine Root {
			get {
				return Parent == null && GetType()== typeof(StateMachine) ? (StateMachine)this : Parent.Root;
			}
		}

		[SerializeField]
		private Transition[] transitions= new Transition[0];
		public Transition[] Transitions{
			get{
				return transitions;
			}
			set{
				transitions=value;
			}
		}

		public Transition[] InTransitions{
			get{
				List<Transition> mTransitions= new List<Transition>();
				foreach(Node node in Parent.Nodes){
					mTransitions.AddRange(node.Transitions.Where(x=> x.ToNode == this));
				}
				return mTransitions.ToArray();
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

		private ICodeBehaviour owner;
		public ICodeBehaviour Owner{
			get{
				return this.Root.owner;
			}
		}

		private bool isInitialized;
		public bool IsInitialized{
			get{
				return this.isInitialized;
			}
		}

		public Node ValidateTransitions(){
			if (this.Parent != null) {
				Node parentNode=this.Parent.ValidateTransitions();
				if(parentNode != null){
					return parentNode;
				}
			}
			for(int i=0; i < Transitions.Length; i++) {
				Node node = transitions[i].Validate();
				if(node != null){
					return node;
				}
			}
			return null;
		}


		public void Init(ICodeBehaviour component){
			this.owner = component;
			this.Root.SetVariable ("Owner", this.owner.gameObject);
			this.isInitialized = true;
		}

		public virtual void OnUpdate(){
			//Debug.Log ("OnUpdate: "+this.Name);
		}

		public virtual void OnEnter(){
			this.IsEntered = true;
			for (int i=0; i < Transitions.Length; i++) {
				Transition transition= Transitions[i];
				transition.OnEnter();		
			}
			//Debug.Log ("OnEnter: "+this.Name);
		}

		public virtual void OnExit(){
			this.IsEntered = false;
			for (int i=0; i < Transitions.Length; i++) {
				Transition transition= Transitions[i];
				transition.OnExit();		
			}
			//Debug.Log ("OnExit: " + this.Name);
		}
	}
}