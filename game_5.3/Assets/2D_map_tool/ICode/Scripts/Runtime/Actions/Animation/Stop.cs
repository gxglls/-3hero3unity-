using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityAnimation{
	[Category(Category.Animation)]   
	[Tooltip("Stops all playing animations that were started with this Animation.")]
	[HelpUrl("http://docs.unity3d.com/ScriptReference/Animation.Stop.html")]
	[System.Serializable]
	public class Stop : AnimationAction {

		public override void OnEnter ()
		{
			base.OnEnter ();
			animation.Stop ();

		}

	}
}