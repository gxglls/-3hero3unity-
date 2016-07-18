using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityRenderer{
	[Category(Category.Renderer)]
	[Tooltip("Set a named float value.")]
	[HelpUrl("http://docs.unity3d.com/ScriptReference/Material.SetFloat.html")]
	[System.Serializable]
	public class SetFloat : RendererAction {
		[Tooltip("Value to set.")]
		public FsmFloat value;
		[Tooltip("Property name defined in shader")]
		[DefaultValueAttribute("_Shininess")]
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
				renderer.material.SetFloat(propertyName.Value,value.Value);
			}
			else if (renderer.materials.Length > index.Value)
			{
				var materials = renderer.materials;
				materials[index.Value].SetFloat(propertyName.Value,value.Value);
				renderer.materials = materials;			
			}		
		}
	}
}