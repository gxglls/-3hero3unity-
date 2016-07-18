using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace ICode.Actions.UnityGUI{
	[Category(Category.GUI)]    
	[Tooltip("Sets the image properties of an Image component.")]
	[System.Serializable]
	public class SetImageProperties : StateAction {
		[SharedPersistent]
		[Tooltip("GameObject to use.")]
		public FsmGameObject gameObject;
		[NotRequired]
		[Tooltip("Image to set.")]
		public FsmObject sprite;
		[NotRequired]
		[Tooltip("Color to set.")]
		public FsmColor color;
		[NotRequired]
		[Tooltip("Material to set.")]
		public FsmObject material;
		[Tooltip("Image Type")]
		public Image.Type type;
		public Image.FillMethod fillMethod;
		[NotRequired]
		public FsmFloat fillAmount;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;
		
		private Image component;
		
		public override void OnEnter ()
		{
			component = gameObject.Value.GetComponent<Image>();
			DoSetImageProperties ();
			if (!everyFrame) {
				Finish ();
			}
		}
		
		public override void OnUpdate ()
		{
			DoSetImageProperties ();
		}
		
		private void DoSetImageProperties(){
			if(!sprite.IsNone)
				component.sprite=sprite.Value!= null? (Sprite)sprite.Value:null;
			if(!color.IsNone)
				component.color = color.Value;
			if(!material.IsNone)
				component.material =material.Value!= null? (Material)material.Value:null;
			component.type = type;
			if(!fillAmount.IsNone && type== Image.Type.Filled)
				component.fillAmount=Mathf.Clamp01(fillAmount.Value);
			
		}
	}
}