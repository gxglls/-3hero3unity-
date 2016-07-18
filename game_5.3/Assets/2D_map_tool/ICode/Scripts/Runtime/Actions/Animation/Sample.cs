using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityAnimation{
	[Category(Category.Animation)]   
	[Tooltip("Samples animations at the current state.")]
	[HelpUrl("http://docs.unity3d.com/ScriptReference/Animation.Sample.html")]
	[System.Serializable]
	public class Sample : AnimationAction {
		public override void OnEnter ()
		{
			base.OnEnter ();
			animation.Sample ();
			
		}
		
	}
}