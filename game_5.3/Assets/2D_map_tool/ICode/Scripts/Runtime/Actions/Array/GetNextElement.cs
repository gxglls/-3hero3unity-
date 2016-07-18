using UnityEngine;
using System.Collections;

namespace ICode.Actions.Array{
	[Category(Category.Array)]  
	[Tooltip("Gets the array element at index.")]
	[System.Serializable]
	public class GetNextElement : ArrayAction {
		[NotRequired]
		[Shared]
		[Tooltip("Reset Value. Should be started with true.")]
		public FsmBool reset;
		[Tooltip("Sends this event when getting next item.")]
		[DefaultValueAttribute("Loop")]
		public FsmString loopEvent;
		[Tooltip("Sends this event when looping the list is finished.")]
		[DefaultValueAttribute("Finished")]
		public FsmString finishedEvent;

		[Tooltip("Start Index.")]
		public FsmInt startIndex;
		[Tooltip("End Index, if 0 loops to the end.")]
		public FsmInt endIndex;
		[Shared]
		[NotRequired]
		[Tooltip("Store current Index.")]
		public FsmInt currentIndex;
		[Shared]
		[ParameterType]
		public FsmVariable element;

		private int realEndIndex;
		private bool startedLoop;

		public override void OnEnter ()
		{
			base.OnEnter ();
			if (!reset.IsNone) {
				startedLoop=!reset.Value;
			}
			if (!startedLoop) {
				currentIndex.Value = startIndex.Value - 1;
				realEndIndex = endIndex.Value == 0 ? array.Value.Length - 1 : endIndex.Value;
				reset.Value=false;
				startedLoop=true;
			}
		}

		public override void OnUpdate ()
		{
			GetNext ();
		}

		private void GetNext(){
			if (currentIndex.Value >= realEndIndex) {
				Finish();
				Root.Owner.SendEvent (finishedEvent.Value,null);
				return;
			}
			currentIndex.Value += 1;
			element.SetValue (array.Value [currentIndex.Value]);
			Root.Owner.SendEvent (loopEvent.Value,null);
		}
	}
}