using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityBehaviour{
	[Category(Category.Behaviour)]
	[Tooltip("Enabled Behaviours are Updated, disabled Behaviours are not.")]
	[HelpUrl("http://docs.unity3d.com/ScriptReference/Behaviour-enabled.html")]
	[System.Serializable]
	public class SetEnabled : StateAction {
		[SharedPersistent]
		[Tooltip("GameObject to use.")]
		public FsmGameObject gameObject;
		[Component(typeof(Behaviour))]
		[Tooltip("The name of the component.")]
		public FsmString component;
		[InspectorLabel("Enabled")]
		public FsmBool _enabled;
		
		public override void OnEnter ()
		{
			Component mComponent = gameObject.Value.GetComponent (TypeUtility.GetType(component.Value));
			if (mComponent is Behaviour) {
				(mComponent as Behaviour).enabled=_enabled.Value;
			}
			Finish ();
		}
	}
}