using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using ICode;

namespace ICode.FSMEditor{
	public static class FsmEditorStyles {
		public const float StateWidth = 150f;
		public const float StateHeight = 30f;
		public const float StateMachineWidth = 150f;
		public const float StateMachineHeight = 45f;

		public static GUIStyle canvasBackground;
		public static GUIStyle selectionRect;
		public static GUIStyle elementBackground;
		public static GUIStyle breadcrumbLeft;
		public static GUIStyle breadcrumbMiddle;
		public static GUIStyle wrappedLabel;
		public static GUIStyle wrappedLabelLeft;
		public static GUIStyle variableHeader;
		public static GUIStyle label;
		public static GUIStyle centeredLabel;
		public static GUIStyle inspectorTitle;
		public static GUIStyle inspectorTitleText;
		public static GUIStyle stateLabelGizmo;
		public static GUIStyle instructionLabel;
		public static GUIStyle shortcutLabel;
		public static GUIStyle browserPopup;

		public static Texture2D popupIcon; 
		public static Texture2D helpIcon;
		public static Texture2D errorIcon;
		public static Texture2D warnIcon;
		public static Texture2D infoIcon;
		public static Texture2D toolbarPlus;
		public static Texture2D toolbarMinus;
		public static Texture2D iCodeLogo;

		public static Color gridMinorColor;
		public static Color gridMajorColor;

		public static int fsmColor;
		public static int startNodeColor;
		public static int anyStateColor;
		public static int defaultNodeColor;

		static FsmEditorStyles(){
			FsmEditorStyles.nodeStyleCache = new Dictionary<string, GUIStyle> ();
			FsmEditorStyles.gridMinorColor = EditorGUIUtility.isProSkin? new Color(0f, 0f, 0f, 0.18f):new Color(0f, 0f, 0f, 0.1f);
			FsmEditorStyles.gridMajorColor = EditorGUIUtility.isProSkin? new Color(0f, 0f, 0f, 0.28f):new Color(0f, 0f, 0f, 0.15f);

			FsmEditorStyles.popupIcon = EditorGUIUtility.FindTexture ("_popup");
			FsmEditorStyles.helpIcon = EditorGUIUtility.FindTexture ("_help");
			FsmEditorStyles.errorIcon = EditorGUIUtility.FindTexture ("d_console.erroricon.sml");
			FsmEditorStyles.warnIcon = EditorGUIUtility.FindTexture ("console.warnicon");
			FsmEditorStyles.infoIcon = EditorGUIUtility.FindTexture ("console.infoicon");
			FsmEditorStyles.toolbarPlus = EditorGUIUtility.FindTexture ("Toolbar Plus");
			FsmEditorStyles.toolbarMinus = EditorGUIUtility.FindTexture ("Toolbar Minus");

			FsmEditorStyles.canvasBackground = "flow background";
			FsmEditorStyles.selectionRect = "SelectionRect";
			FsmEditorStyles.elementBackground = new GUIStyle ("PopupCurveSwatchBackground"){
				padding=new RectOffset()
			};
			FsmEditorStyles.breadcrumbLeft = "GUIEditor.BreadcrumbLeft";
			FsmEditorStyles.breadcrumbMiddle = "GUIEditor.BreadcrumbMid";
			FsmEditorStyles.wrappedLabel = new GUIStyle ("label"){
				fixedHeight=0,
				wordWrap=true
			};
			FsmEditorStyles.wrappedLabelLeft = new GUIStyle ("label"){
				fixedHeight=0,
				wordWrap=true,
				alignment= TextAnchor.UpperLeft
			};
			FsmEditorStyles.variableHeader = "flow overlay header lower left";
			FsmEditorStyles.label="label";
			FsmEditorStyles.inspectorTitle="IN Title";
			FsmEditorStyles.inspectorTitleText = "IN TitleText";
			FsmEditorStyles.iCodeLogo =  (Texture2D)Resources.Load( "ICodeLogo");
			FsmEditorStyles.stateLabelGizmo=new GUIStyle("HelpBox"){
				alignment = TextAnchor.UpperCenter,
				fontSize=21
			};
			FsmEditorStyles.centeredLabel=new GUIStyle("Label"){
				alignment = TextAnchor.UpperCenter,
			};
			FsmEditorStyles.instructionLabel = new GUIStyle ("TL Selection H2"){
				padding = new RectOffset (3, 3, 3, 3),
				contentOffset=FsmEditorStyles.wrappedLabel.contentOffset,
				alignment = TextAnchor.UpperLeft,
				fixedHeight=0,
				wordWrap=true
			};
			FsmEditorStyles.shortcutLabel=new GUIStyle("ObjectPickerLargeStatus"){
				padding = new RectOffset (3, 3, 3, 3),
				alignment = TextAnchor.UpperLeft
			};
			FsmEditorStyles.browserPopup = new GUIStyle ("label"){
				contentOffset= new Vector2(0,2)
			};

			FsmEditorStyles.fsmColor = (int)NodeColor.Blue;
			FsmEditorStyles.startNodeColor = (int)NodeColor.Orange;
			FsmEditorStyles.anyStateColor = (int)NodeColor.Aqua;
			FsmEditorStyles.defaultNodeColor = (int)NodeColor.Grey;
		}

		private static Dictionary<string, GUIStyle> nodeStyleCache;

		private static string[] styleCache =
		{
			"flow node 0",
			"flow node 1",
			"flow node 2",
			"flow node 3",
			"flow node 4",
			"flow node 5",
			"flow node 6"
		};

		private static string[] styleCacheHex =
		{
			"flow node hex 0",
			"flow node hex 1",
			"flow node hex 2",
			"flow node hex 3",
			"flow node hex 4",
			"flow node hex 5",
			"flow node hex 6"
		};

		public static GUIStyle GetNodeStyle(int color, bool on, bool hex)
		{
			return GetNodeStyle (hex?styleCacheHex[color]:styleCache[color], on,hex?8f:2f);
		}

		private static GUIStyle GetNodeStyle(string styleName, bool on, float offset)
		{
			string str = on?string.Concat(styleName," on"):  styleName;
			if (!FsmEditorStyles.nodeStyleCache.ContainsKey(str))
			{
				GUIStyle style= new GUIStyle(str);
				style.contentOffset=new Vector2(0,style.contentOffset.y - offset);
				if(on){
					style.fontStyle=FontStyle.Bold;
				}
				nodeStyleCache[str] = style;
			}
			return nodeStyleCache[str];
		}
	}

	public enum NodeColor{
		Grey = 0,
		Blue = 1,
		Aqua = 2,
		Green = 3,
		Yellow = 4,
		Orange = 5,
		Red = 6
	}
}