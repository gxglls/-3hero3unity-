using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace ICode{
	[AddComponentMenu("ICode/ICodeTrigger")]
	public class ICodeTrigger : MonoBehaviour {
		public string triggerTag="Player";
		public float radius = 5f;
		public Color color=new Color(1,0,0,0.1f);
		public List<ComponentModel> components;
		public bool parent;

		private void Start(){
			if (!parent) {
				GameObject go = new GameObject ("Trigger");
				go.transform.SetParent (transform);
				go.transform.localPosition=Vector3.zero;
				SphereCollider mCollider= go.AddComponent<SphereCollider>();
				mCollider.radius=radius;
				mCollider.isTrigger=true;
				go.layer = 2;
				Rigidbody mRigidbody= go.AddComponent<Rigidbody>();
				mRigidbody.isKinematic=true;

				ICodeTrigger trigger = go.AddComponent<ICodeTrigger> ();
				trigger.radius = radius;
				trigger.color = color;
				trigger.components = components;
				trigger.parent=true;
				Destroy (this);
			}                          
		}

		private void OnTriggerEnter(Collider other) {
			if (other.tag.Equals(triggerTag)) {
				for (int i = 0; i < components.Count; i++) {
					components [i].Process (true);
				}
			}
		}

		private void OnTriggerExit(Collider other) {
			if (other.tag.Equals(triggerTag)) {
				for (int i = 0; i < components.Count; i++) {
					components [i].Process (false);
				}
			}
		}

		[System.Serializable]
		public class ComponentModel{
			public Object mObject;
			public bool enable=true;
			
			public void Process(bool forward){
				bool state = forward ? enable : !enable;

				if (mObject is Behaviour) {
					(mObject as Behaviour).enabled = state;
				} else if (mObject is GameObject) {
					(mObject as GameObject).SetActive(state);
				}
			}
		}
	}
}