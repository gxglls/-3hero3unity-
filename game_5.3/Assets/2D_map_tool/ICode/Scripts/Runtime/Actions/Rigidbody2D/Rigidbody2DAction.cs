using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityRigidbody2D{
	[System.Serializable]
	public abstract class Rigidbody2DAction : StateAction {
		[SharedPersistent]
		[Tooltip("GamgeObject to use.")]
		public FsmGameObject gameObject;
		protected FixedUpdateProxy proxy;
		protected Rigidbody2D rigidbody;
		
		public override void OnEnter ()
		{
			rigidbody = gameObject.Value.GetComponent<Rigidbody2D> ();
			proxy = gameObject.Value.GetComponent<FixedUpdateProxy> ();
			if (proxy == null) {
				proxy = gameObject.Value.AddComponent<FixedUpdateProxy>();			
			}
			proxy.onFixedUpdate += OnFixedUpdate;
		}
		
		public override void OnExit ()
		{
			base.OnExit ();
			proxy.onFixedUpdate -= OnFixedUpdate;
		}
		
		public virtual void OnFixedUpdate(){}
	}
}