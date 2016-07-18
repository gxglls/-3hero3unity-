using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityRenderer{
	[Category(Category.Renderer)]
	[Tooltip("Set a new material.")]
	[HelpUrl("http://docs.unity3d.com/ScriptReference/Renderer-material.html")]
	[System.Serializable]
	public class SetMaterial : RendererAction {
		[Tooltip("Material to set.")]
		public FsmObject material;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;
		
		public override void OnEnter ()
		{
			base.OnEnter ();
			DoSetMaterial ();
			if (!everyFrame) {
				Finish ();
			}
		}
		
		public override void OnUpdate ()
		{
			DoSetMaterial ();
		}
		
		private void DoSetMaterial(){
			if (index.Value == 0)
			{
				renderer.material=(Material)material.Value;
			}
			else if (renderer.materials.Length > index.Value)
			{
				var materials = renderer.materials;
				materials[index.Value]=(Material)material.Value;
				renderer.materials = materials;			
			}		
		}
	}
}