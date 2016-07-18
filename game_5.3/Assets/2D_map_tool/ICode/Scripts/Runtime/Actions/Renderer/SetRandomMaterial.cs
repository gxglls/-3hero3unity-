using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace ICode.Actions.UnityRenderer{
	[Category(Category.Renderer)]
	[Tooltip("Set a random material from a list.")]
	[HelpUrl("http://docs.unity3d.com/ScriptReference/Renderer-material.html")]
	[System.Serializable]
	public class SetRandomMaterial : RendererAction {
		[Tooltip("Materials to use.")]
		public List<Material> materials;
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
				renderer.material=materials[Random.Range(0,materials.Count)];
			}
			else if (renderer.materials.Length > index.Value)
			{
				var _materials = renderer.materials;
				_materials[index.Value]= materials[Random.Range(0,materials.Count)];
				renderer.materials = _materials;			
			}		
		}
	}
}