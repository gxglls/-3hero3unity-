using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityCamera{
	[Category(Category.Camera)]   
	[Tooltip("Fade to a color.")]
	[System.Serializable]
	public  class FadeOut : StateAction {
		[Tooltip("Color to fade from.")]
		public FsmColor color;
		[Tooltip("Fade out time in seconds.")]
		public FsmFloat time;
		[Tooltip("Delay start.")]
		public FsmFloat delay;
		[Tooltip("Sends finish event.")]
		public FsmString finishEvent;

		private float currentTime;
		private Color colorLerp;
		private Texture2D texture;
		
		public override void OnEnter (){
			currentTime = 0f-delay.Value;
			colorLerp = color.Value;
			texture = new Texture2D (1, 1);
			texture.SetPixel (0, 0, Color.white);
			texture.Apply ();
			GameObject go = new GameObject ("OnGUIProxy");
			OnGUIProxy proxy = go.GetComponent<OnGUIProxy> ();
			if (proxy == null) {
				proxy = go.AddComponent<OnGUIProxy>();			
			}
			proxy.onGUI += OnGUI;
		}
		
		public override void OnUpdate ()
		{
			currentTime += Time.deltaTime;
			colorLerp = Color.Lerp(Color.clear, color.Value, currentTime/time.Value);
			
			if (currentTime > time.Value)
			{	
				this.Root.Owner.SendEvent(finishEvent.Value,null);
			}
		}
		
		private void OnGUI()
		{
			var guiColor = GUI.color;
			GUI.color = colorLerp;
			GUI.DrawTexture(new Rect(0,0,Screen.width, Screen.height),texture);
			GUI.color = guiColor;
		}
	}
}