using UnityEngine;
using UnityEditor;
using System.Collections;

namespace ICode.FSMEditor{
	public class WelcomeWindow : EditorWindow {
		[MenuItem("Window/Zerano Assets/ICode/Welcome Screen", false, 1)]
		public static void ShowWindow()
		{
			WelcomeWindow window = EditorWindow.GetWindow<WelcomeWindow>(true, "Welcome to ICode");
			Vector2 size = new Vector2(340f, 310f);
			window.minSize = size;
			window.maxSize = size;
			Object.DontDestroyOnLoad(window);
		}
		private Rect contactIconRect=new Rect(15f, 8f, 50, 38);
		private Rect contactHeaderRect = new Rect(70f, 7f, 250f, 20f);
		private Rect contactTextRect= new Rect(70f, 27f, 250f, 30f);
		private Texture2D contactIcon;

		private Rect downloadIconRect=new Rect(15f, 60f, 50, 40);
		private Rect downloadHeaderRect = new Rect(70f, 59f, 250f, 20f);
		private Rect downloadTextRect= new Rect(70f, 79f, 250f, 30f);
		private Texture2D downloadIcon;

		private Rect documentationIconRect=new Rect(15f, 120f, 50, 50);
		private Rect documentationHeaderRect = new Rect(70f, 119f, 250f, 20f);
		private Rect documenationTextRect= new Rect(70f, 139f, 250f, 30f);
		private Texture2D documentationIcon;

		private Rect forumIconRect=new Rect(15f, 182f, 50, 50);
		private Rect forumHeaderRect = new Rect(70f, 181f, 250f, 20f);
		private Rect forumTextRect= new Rect(70f, 201f, 250f, 30f);
		private Texture2D forumIcon;
	
		private Rect addonIconRect=new Rect(15f, 244f, 50, 50);
		private Rect addonHeaderRect = new Rect(70f, 243f, 250f, 20f);
		private Rect addonTextRect= new Rect(70f, 261f, 250f, 30f);
		private Texture2D addonIcon;

		private Rect showOnStartRect = new Rect(220f, 285f, 125f, 20f);

		private GUIStyle TextStyle{
			get{
				GUIStyle style=new GUIStyle("label");
				style.fixedHeight=0;
				style.wordWrap=true;
				return style;
			}
		}

		private GUIStyle HeaderStyle{
			get{
				GUIStyle style=new GUIStyle("label");
				style.fontSize=14;
				style.fontStyle=FontStyle.Bold;
				return style;
			}
		}

		private void OnEnable(){
			contactIcon=(Texture2D)Resources.Load("Contact",typeof(Texture2D));
			downloadIcon=(Texture2D)Resources.Load("Download",typeof(Texture2D));
			documentationIcon=(Texture2D)Resources.Load("Documentation",typeof(Texture2D));
			forumIcon=(Texture2D)Resources.Load("Forum",typeof(Texture2D));
			addonIcon=(Texture2D)Resources.Load("Addon",typeof(Texture2D));
		}

		private void OnGUI(){
			GUI.DrawTexture(this.contactIconRect, this.contactIcon);
			GUI.Label(this.contactHeaderRect, "Contact",HeaderStyle);
			GUI.Label(this.contactTextRect, "Contact us in private, we are here to help.",TextStyle);

			GUI.DrawTexture(this.downloadIconRect, this.downloadIcon);
			GUI.Label(this.downloadHeaderRect, "Examples",HeaderStyle);
			GUI.Label(this.downloadTextRect, "Download sample projects and presets.",TextStyle);

			GUI.DrawTexture(this.documentationIconRect, this.documentationIcon);
			GUI.Label(this.documentationHeaderRect, "Documentation",HeaderStyle);
			GUI.Label(this.documenationTextRect, "Checkout our written and video documentation.",TextStyle);

			GUI.DrawTexture(this.forumIconRect, this.forumIcon);
			GUI.Label(this.forumHeaderRect, "Forums",HeaderStyle);
			GUI.Label(this.forumTextRect, "Join our forums to get support and make suggestions.",TextStyle);

			GUI.DrawTexture(this.addonIconRect, this.addonIcon);
			GUI.Label(this.addonHeaderRect, "Add-ons",HeaderStyle);
			GUI.Label(this.addonTextRect, "Download assets that extend the core functionality.",TextStyle);

			bool state = PreferencesEditor.GetBool (Preference.ShowWelcomeWindow, true);
			state = GUI.Toggle(this.showOnStartRect,state , "Show at Startup");
			PreferencesEditor.SetBool (Preference.ShowWelcomeWindow, state);

			EditorGUIUtility.AddCursorRect(this.contactIconRect, MouseCursor.Link);
			EditorGUIUtility.AddCursorRect(this.contactHeaderRect, MouseCursor.Link);
			EditorGUIUtility.AddCursorRect(this.contactTextRect, MouseCursor.Link);
			EditorGUIUtility.AddCursorRect(this.downloadIconRect, MouseCursor.Link);
			EditorGUIUtility.AddCursorRect(this.downloadHeaderRect, MouseCursor.Link);
			EditorGUIUtility.AddCursorRect(this.downloadTextRect, MouseCursor.Link);
			EditorGUIUtility.AddCursorRect(this.documentationIconRect, MouseCursor.Link);
			EditorGUIUtility.AddCursorRect(this.documentationHeaderRect, MouseCursor.Link);
			EditorGUIUtility.AddCursorRect(this.documenationTextRect, MouseCursor.Link);
			EditorGUIUtility.AddCursorRect(this.forumIconRect, MouseCursor.Link);
			EditorGUIUtility.AddCursorRect(this.forumHeaderRect, MouseCursor.Link);
			EditorGUIUtility.AddCursorRect(this.forumTextRect, MouseCursor.Link);
			EditorGUIUtility.AddCursorRect(this.addonIconRect, MouseCursor.Link);
			EditorGUIUtility.AddCursorRect(this.addonHeaderRect, MouseCursor.Link);
			EditorGUIUtility.AddCursorRect(this.addonTextRect, MouseCursor.Link);

			if (Event.current.type == EventType.mouseDown)
			{
				Vector2 mousePosition = Event.current.mousePosition;
				if (this.contactIconRect.Contains(mousePosition) || this.contactHeaderRect.Contains(mousePosition) || this.contactTextRect.Contains(mousePosition))
				{
					Application.OpenURL("http://zerano-unity3d.com/AIDocumentation/contact/");
					return;
				}
				if (this.downloadIconRect.Contains(mousePosition) || this.downloadHeaderRect.Contains(mousePosition) || this.downloadTextRect.Contains(mousePosition))
				{
					Application.OpenURL("http://zerano-unity3d.com/AIDocumentation/navigation/examples/");
					return;
				}
				if (this.documentationIconRect.Contains(mousePosition) || this.documentationHeaderRect.Contains(mousePosition) || this.documenationTextRect.Contains(mousePosition))
				{
					Application.OpenURL("http://zerano-unity3d.com/AIDocumentation/");
					return;
				}
				if (this.forumIconRect.Contains(mousePosition) || this.forumHeaderRect.Contains(mousePosition) || this.forumTextRect.Contains(mousePosition))
				{
					Application.OpenURL("http://zerano-unity3d.com/Forums/forum-1.html");
					return;
				}
				if (this.addonIconRect.Contains(mousePosition) || this.addonHeaderRect.Contains(mousePosition) || this.addonTextRect.Contains(mousePosition))
				{
					Application.OpenURL("http://zerano-unity3d.com/AIDocumentation/navigation/add-ons/");
					return;
				}
			}
		}
	}
}