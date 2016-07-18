using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityRigidbody{
	[System.Serializable]
	public abstract class RigidbodyAction : StateAction {
		[SharedPersistent]
		[Tooltip("GamgeObject to use.")]
		public FsmGameObject gameObject;
	
		protected Rigidbody rigidbody;
		protected FixedUpdateProxy proxy;

		public override void OnEnter ()
		{
			rigidbody = gameObject.Value.GetComponent<Rigidbody> ();
			proxy = gameObject.Value.GetComponent<FixedUpdateProxy> ();
			if (proxy == null) {
				proxy = gameObject.Value.AddComponent<FixedUpdateProxy>();			
			}
			proxy.onFixedUpdate += OnFixedUpdate;
		}

		public override void OnExit ()
		{
			proxy.onFixedUpdate -= OnFixedUpdate;
		}

		public virtual void OnFixedUpdate(){}
	}
}