using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ICode.Actions;
using ICode.Conditions;

namespace ICode{
	[System.Serializable]
	public class StateMachine :Node{

		[SerializeField]
		private FsmVariable[] variables= new FsmVariable[0];
		public FsmVariable[] Variables{
			get{
				return this.Root.variables;
			}
			set{
				this.Root.variables=value;
			}
		}

		public FsmVariable[] VisibleVariables{
			get{
				return Root.Variables.Where(x=>!x.IsHidden).ToArray();
			}
		}

		[SerializeField]
		private Node[] nodes;
		public Node[] Nodes{
			get{
				if(this.nodes == null){
					this.nodes= new Node[0];
				}
				return this.nodes;
			}
			set{
				this.nodes=value;
			}
		}

		public Node[] NodesRecursive{
			get{
				List<Node> nodes= new List<Node>();
				if (Nodes.Length > 0) {
					nodes.AddRange(Nodes);			
				}
				
				foreach(StateMachine node in StateMachines)
				{
					nodes.AddRange(node.NodesRecursive);
				}
				return nodes.ToArray();
			}
		}

		public StateMachine[] StateMachines{
			get{
				
				return this.nodes.Where(node=>node.GetType()==typeof(StateMachine)).Cast<StateMachine>().ToArray();
			}
		}

		public StateMachine[] StateMachinesRecursive{
			get{
				
				return this.NodesRecursive.Where(node=>node.GetType()==typeof(StateMachine)).Cast<StateMachine>().ToArray();
			}
		}

		public State[] States{
			get{
				return this.nodes.Where(node=>typeof(State).IsAssignableFrom(node.GetType())).Cast<State>().ToArray();
			}
		}

		public State[] StatesRecursive{
			get{
				return this.NodesRecursive.Where(node=>typeof(State).IsAssignableFrom(node.GetType())).Cast<State>().ToArray();
			}
		}

		public StateAction[] ActionsRecursive{
			get{
				return this.NodesRecursive.Where(node=>typeof(State).IsAssignableFrom(node.GetType())).Cast<State>().SelectMany(x=>x.Actions).ToArray();
			}
		}

		public Transition[] TransitionsRecursive{
			get{
				return this.NodesRecursive.SelectMany(x=>x.Transitions).ToArray();
			}
		}

		public Condition[] ConditionsRecursive{
			get{
				return this.TransitionsRecursive.SelectMany(x=>x.Conditions).ToArray();
			}
		}

		public ExecutableNode[] ExecutableNodesRecursive{
			get{
				List<ExecutableNode> mNodes=new List<ExecutableNode>(this.ActionsRecursive);
				mNodes.AddRange(this.ConditionsRecursive);
				return mNodes.ToArray();
			}
		}


		public FsmVariable GetVariable(string name)
		{
			for (int i=0; i< Root.Variables.Length; i++) {
				FsmVariable variable= Root.Variables[i];
				if(variable.Name == name){
					return variable;
				}
			}
			return null;
		}

		public bool SetVariable(string name, object value){
			FsmVariable variable = GetVariable (name);
			if (variable != null && variable.VariableType.IsAssignableFrom(value.GetType())) {
				variable.SetValue(value);
				return true;
			}
			if (value != null) {
				variable = (FsmVariable)ScriptableObject.CreateInstance (FsmUtility.GetVariableType (value.GetType ()));
				variable.hideFlags = HideFlags.HideInHierarchy;
				variable.Name = name;
				variable.SetValue (value);
				Variables = ArrayUtility.Add<FsmVariable> (Variables, variable);
			}
			return false;
		}
		
		public State GetState(string stateName)
		{
			for (int i = 0; i < this.States.Length; i++)
			{
				State state = this.States[i];
				if (state.Name == stateName)
				{
					return state;
				}
			}
			return null;
		}

		public Node GetNode(string nodeName)
		{
			Node[] nodes = this.NodesRecursive;
			for (int i = 0; i < nodes.Length; i++)
			{
				Node node = this.nodes[i];
				if (node.Name == nodeName)
				{
					return node;
				}
			}
			return null;
		}

		public Node GetStartNode ()
		{
			for (int i = 0; i < this.Nodes.Length; i++)
			{
				Node node = this.Nodes[i];
				if (node.IsStartNode)
				{
					return node;
				}
			}
			return null;
		}

		public AnyState GetAnyState(){
			
			for (int i = 0; i < this.States.Length; i++)
			{
				State state = this.States[i];
				if (state is AnyState)
				{
					return state as AnyState;
				}
			}
			return null;
		}

		public override void OnEnter ()
		{
			base.OnEnter ();
			this.Owner.ActiveNode = GetStartNode ();
			this.Owner.AnyState = GetAnyState ();
		}
	}
}