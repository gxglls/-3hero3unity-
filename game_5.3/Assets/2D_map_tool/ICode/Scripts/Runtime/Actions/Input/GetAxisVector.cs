using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityInput{
	[Category(Category.Input)]
	[Tooltip("Returns the value of the virtual axis identified by axisName.")]
	[HelpUrl("https://docs.unity3d.com/Documentation/ScriptReference/Input.GetAxis.html")]
	[System.Serializable]
	public class GetAxisVector : StateAction {
		[DefaultValue("Horizontal")]
		[Tooltip("Virtual horizontal axis name.")]
		public FsmString horizontal;
		[DefaultValue("Vertical")]
		[Tooltip("Virtual vertical axis name.")]
		public FsmString vertical;
		public AxisMap axisMap;
		[Shared]
		[NotRequired]
		[Tooltip("Store the result as Vector3.")]
		public FsmVector3 storeVector3;
		[Shared]
		[NotRequired]
		[Tooltip("Store the result as Vector2")]
		public FsmVector2 storeVector2;
		
		public override void OnUpdate ()
		{
			float horz = Input.GetAxis (horizontal.Value);
			float vert = Input.GetAxis (vertical.Value);	
			switch (axisMap) {
			case AxisMap.XZ:
				storeVector3.Value=new Vector3(horz,0,vert);
				break;
			case AxisMap.XY:
				storeVector3.Value=new Vector3(horz,vert,0);
				break;
			case AxisMap.YZ:
				storeVector3.Value=new Vector3(0,horz,vert);
				break;
			}
			storeVector2.Value = new Vector2 (horz, vert);
		}
	}
}