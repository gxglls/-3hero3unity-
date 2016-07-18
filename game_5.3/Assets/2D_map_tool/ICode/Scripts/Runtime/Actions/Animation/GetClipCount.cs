using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityAnimation{
	[Category(Category.Animation)]   
	[Tooltip("Get the number of clips currently assigned to this animation.")]
	[HelpUrl("http://docs.unity3d.com/ScriptReference/Animation.GetClipCount.html")]
	[System.Serializable]
	public class GetClipCount : AnimationAction {
		[Shared]
		[Tooltip("Store the result.")]
		public FsmInt store;
	
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;
		
		public override void OnEnter ()
		{
			base.OnEnter ();
			store.Value = animation.GetClipCount ();
			if (!everyFrame) {
				Finish();			
			}
		}
		
		public override void OnUpdate ()
		{
			store.Value = animation.GetClipCount ();
		}
	}
}