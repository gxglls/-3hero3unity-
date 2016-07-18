using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityRenderer{
	[Category(Category.Renderer)]
	[Tooltip("Set a new texture to the material.")]
	[HelpUrl("http://docs.unity3d.com/ScriptReference/Material.SetTexture.html")]
	[System.Serializable]
	public class SetTexture : RendererAction {
		[Tooltip("Texture to set.")]
		public FsmObject texture;
		[Tooltip("Property name defined in shader")]
		[DefaultValueAttribute("_MainTex")]
		public FsmString propertyName;
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
			DoSet ();
		}
		
		private void DoSet(){
			if (index.Value == 0)
			{
				renderer.material.SetTexture(propertyName.Value,(Texture)texture.Value);
			}
			else if (renderer.materials.Length > index.Value)
			{
				var materials = renderer.materials;
				materials[index.Value].SetTexture(propertyName.Value,(Texture)texture.Value);
				renderer.materials = materials;			
			}		
		}
	}
}