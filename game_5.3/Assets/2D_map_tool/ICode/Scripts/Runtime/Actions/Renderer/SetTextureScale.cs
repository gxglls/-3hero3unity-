using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityRenderer{
	[Category(Category.Renderer)]
	[Tooltip("Sets the placement offset of texture propertyName.")]
	[HelpUrl("http://docs.unity3d.com/ScriptReference/Material.SetTextureOffset.html")]
	[System.Serializable]
	public class SetTextureScale : RendererAction {
		[Tooltip("Property name defined in shader")]
		[DefaultValueAttribute("_MainTex")]
		public FsmString propertyName;
		[Tooltip("Scale to set.")]
		public FsmVector2 scale;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;
		
		public override void OnEnter ()
		{
			base.OnEnter ();
			DoSet ();
			if (!everyFrame) {
				Finish ();
			}
		}
		
		public override void OnUpdate ()
		{
			DoSet();
		}
		
		private void DoSet(){
			if (index.Value == 0)
			{
				renderer.material.SetTextureScale(propertyName.Value,scale.Value);
			}
			else if (renderer.materials.Length > index.Value)
			{
				var materials = renderer.materials;
				materials[index.Value].SetTextureScale(propertyName.Value,scale.Value);
				renderer.materials = materials;			
			}		
		}
	}
}