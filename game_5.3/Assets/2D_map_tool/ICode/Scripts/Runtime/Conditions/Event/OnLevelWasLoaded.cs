using UnityEngine;
using System.Collections;

namespace ICode.Conditions.UnityEvent{
	[Category(Category.Event)]  
	[Tooltip("This event is called after a new level was loaded.")]
	[HelpUrl("http://docs.unity3d.com/ScriptReference/MonoBehaviour.OnLevelWasLoaded.html")]
	[System.Serializable]
	public class OnLevelWasLoaded : Condition {
		[Tooltip("Compare the level.")]
		public FloatComparer comparer;
		[Tooltip("Value to test with.")]
		public FsmInt level;
		private OnLevelWasLoadedHandler handler;
		private bool isTrigger;


		public override void OnEnter ()
		{
			handler = this.Root.Owner.GetComponent<OnLevelWasLoadedHandler> ();
			if (handler == null) {
				handler = this.Root.Owner.gameObject.AddComponent<OnLevelWasLoadedHandler>();	
			}
			handler.onLevelWasLoaded+=OnTrigger;
		}
		
		public override void OnExit ()
		{
			if (isTrigger) {
				handler.onLevelWasLoaded -= OnTrigger;
			}
			isTrigger = false;
		}
		
		private void OnTrigger(int levelIndex){
			if (FsmUtility.CompareFloat (levelIndex, level.Value, comparer)) {
				isTrigger = true;
			}
		}
		
		public override bool Validate ()
		{
			if (isTrigger) {
				isTrigger=false;	
				return true;
			}
			return isTrigger;
		}
	}
}