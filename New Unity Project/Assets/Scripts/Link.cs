using UnityEngine;
using System.Runtime.InteropServices;
using UnityEngine.UI;

public class Link : MonoBehaviour 
{

	public string URL;

	/*public void OpenLink()
	{
		Application.OpenURL(Field.text);
	}

	public void OpenLinkJS()
	{
		Application.ExternalEval("window.open('"+Field.text+"');");
	}*/

	public void OpenLinkJSPlugin()
	{
		#if !UNITY_EDITOR
		openWindow(URL);
		#endif
	}

	[DllImport("__Internal")]
	private static extern void openWindow(string url);

}