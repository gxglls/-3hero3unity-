using UnityEngine;
using System.Collections;
using System.Reflection;
using System;

namespace ICode.Actions{
	[Category(Category.Reflection)]
	[Tooltip("")]
	[HelpUrl("")]
	[System.Serializable]
	public class Invoke : StateAction {
		[SharedPersistent]
		[Tooltip("GameObject to use.")]
		public FsmGameObject gameObject;
		[HideInInspector]
		[Tooltip("The name of the component.")]
		public string component;
		[Method]
		[Tooltip("The name of the method to call.")]
		public string methodName;
		[Tooltip("Invokes the method after delay in seconds.")]
		public FsmFloat delay;
		[Tooltip("Repeat invoking the method. If set to 0, the method will be invoked once,")]
		public FsmFloat repeatRate;

		public override void OnEnter ()
		{
			base.OnEnter ();
			Component mComponent = ((GameObject)gameObject.Value).GetComponent (component);
			if (mComponent is MonoBehaviour) {
				MonoBehaviour behaviour=mComponent as MonoBehaviour;
				if (repeatRate.Value == 0) {
					behaviour.Invoke (methodName, delay.Value);
				} else {
					behaviour.InvokeRepeating (methodName, delay.Value, repeatRate.Value);
				}
			} else {
				GameObject instance= new GameObject("RoutineHandler");
				CoroutineInstance routineHandler= instance.AddComponent<CoroutineInstance>();
				if (repeatRate.Value == 0) {
					routineHandler.ProcessWork(InvokeMethod(mComponent));
				} else {
					routineHandler.StartCoroutine(InvokeRepeatingMethod(mComponent));
				}
			}
			Finish ();
		}

		private IEnumerator InvokeMethod(Component component){
			yield return new WaitForSeconds(delay.Value);
			MethodInfo methodInfo=component.GetType().GetMethod(methodName);
			if (methodInfo != null) {
				methodInfo.Invoke (component, new object[]{});
			} 
		}

		
		private IEnumerator InvokeRepeatingMethod(Component component){
			yield return new WaitForSeconds(delay.Value);

			MethodInfo methodInfo=component.GetType().GetMethod(methodName);
			if (methodInfo != null) {
				while(true){
					methodInfo.Invoke (component, new object[]{});
					yield return new WaitForSeconds(repeatRate.Value);
				}
			} 
		}
	}
}