using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneManagement2 : MonoBehaviour
{

    GameObject preferencesWarning;
    public bool visitedPreferences = false;
    
    void Start() {
        preferencesWarning = GameObject.Find("PreferencesWarning");
        preferencesWarning.SetActive(false);
    
    }

    // Start is called before the first frame update
    public void SceneTransition()
    {
        if(visitedPreferences) {
            SceneManager.LoadScene("Scene1");
        }
        else {
            preferencesWarning.SetActive(true);
            GameObject.Find("Avatar").GetComponent<Button>().interactable = false;
            GameObject.Find("Preferences").GetComponent<Button>().interactable = false;
        }
        
    }
    
    public void ClosePreferencesWarning() {
        preferencesWarning.SetActive(false);
        GameObject.Find("Avatar").GetComponent<Button>().interactable = true;
        GameObject.Find("Preferences").GetComponent<Button>().interactable = true;
    }
}
