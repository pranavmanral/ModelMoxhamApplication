using UnityEngine;
using System.Runtime.InteropServices;
using UnityEngine.UI;

public class Link : MonoBehaviour 
{

	public string URL;
    public string AltURL;

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
		openWindow(AltURL);
		#endif
        if(GameObject.Find("TutorialManager").GetComponent<TutorialManager>().page == 3){
            GameObject.Find("TutorialManager").GetComponent<TutorialManager>().ManagePage(4);
        }
	}

	[DllImport("__Internal")]
	private static extern void openWindow(string url);

}