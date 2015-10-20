using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GUIConsole : MonoBehaviour
{

	public Dictionary<string, string> messages = new Dictionary<string, string> ();
	private static GUIConsole instance = null;

	public static GUIConsole Instance {
		get {
			if (object.ReferenceEquals (instance, null)) {
				instance = new GameObject ("Console", typeof(GUIConsole)).GetComponent<GUIConsole> ();
				DontDestroyOnLoad (instance);
			}
			return instance;
		}
	}

	void OnDestroy ()
	{
		instance = null;
	}

	void OnGUI ()
	{
		foreach (var message in messages) {
			GUILayout.Label (string.Format ("{0}:{1}", message.Key, message.Value));
		}
	}
}
