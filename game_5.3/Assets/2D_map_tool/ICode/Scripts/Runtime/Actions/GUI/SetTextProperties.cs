using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace ICode.Actions.UnityGUI{
	[Category(Category.GUI)]    
	[Tooltip("Sets the properties of a Text component")]
	[System.Serializable]
	public class SetTextProperties : StateAction {
		[SharedPersistent]
		[Tooltip("GameObject to use.")]
		public FsmGameObject gameObject;
		[Tooltip("The string value this text will display.")]
		public FsmString text;
		[Tooltip("The font to use.")]
		public FsmObject font;
		[Tooltip("FontStyle used by the text.")]
		public FontStyle fontStyle;
		[Tooltip("The size that the Font should render at.")]
		[DefaultValue(14)]
		public FsmInt fontSize;
		[Tooltip("Whether this Text will support rich text.")]
		[DefaultValue(true)]
		public FsmBool richText;
		[Tooltip("The positioning of the text reliative to its RectTransform.")]
		[DefaultValue(TextAnchor.MiddleCenter)]
		public TextAnchor alignment;
		[Tooltip("Base color of the Graphic.")]
		public FsmColor color;
		[Tooltip("The static Material used to draw all default Text.")]
		public FsmObject material;

		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;
		
		private Text component;
		
		public override void OnEnter ()
		{
			component = gameObject.Value.GetComponent<Text>();
			DoSetProperties ();
			if (!everyFrame) {
				Finish ();
			}
		}
		
		public override void OnUpdate ()
		{
			DoSetProperties ();
		}

		private void DoSetProperties(){
			component.text = text.Value;
			if(!font.IsNone && font.Value != null)
				component.font = (Font)font.Value;
			component.fontStyle = fontStyle;
			if(!fontSize.IsNone)
				component.fontSize = fontSize.Value;
			if(!richText.IsNone)
				component.supportRichText = richText.Value;
			component.alignment = alignment;
			if(!color.IsNone)
				component.color = color.Value;
			if(!material.IsNone)
				component.material = material.Value!= null? (Material)material.Value:null;
		}
		
	}
}