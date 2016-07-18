using UnityEngine;
using System.Collections;

namespace ICode.Conditions.UnityAnimatin{
	[Category(Category.Animation)]    
	[Tooltip("Is the animation named name playing?")]
	[HelpUrl("http://docs.unity3d.com/ScriptReference/Animation.IsPlaying.html")]
	[System.Serializable]
	public class IsPlaying : Condition {
		[SharedPersistent]
		[Tooltip("GameObject to test.")]
		public FsmGameObject gameObject;
		[InspectorLabel("Name")]
		[Tooltip("Name of the animation.")]
		public FsmString _name;
		[Tooltip("Does the result equals this condition.")]
		public FsmBool equals;
		
		private Animation animation;
		public override void OnEnter ()
		{
			animation = gameObject.Value.GetComponent<Animation> ();
		}
		
		public override bool Validate ()
		{
			if(animation != null){
				return (animation.IsPlaying(_name.Value) == equals.Value);
			}
			return false;
		}
	}
}