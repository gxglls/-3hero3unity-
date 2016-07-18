using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityTransform{
	[Category(Category.Transform)]    
	[Tooltip("Parents the GameObject to target.")]
	[HelpUrl("")]
	[System.Serializable]
	public class Parent : TransformAction {
		[SharedPersistent]
		public FsmGameObject target;
		public FsmBool worldPositionSaves;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;

		private Transform mTarget;

		public override void OnEnter ()
		{
			base.OnEnter ();
			mTarget =target.Value != null? ((GameObject)target.Value).transform:null;
			DoParent ();
			if (!everyFrame) {
				Finish ();
			}
		}

		public override void OnUpdate ()
		{
			DoParent ();
		}

		private void DoParent(){
			transform.SetParent(mTarget,worldPositionSaves.Value);
		}
	}
}