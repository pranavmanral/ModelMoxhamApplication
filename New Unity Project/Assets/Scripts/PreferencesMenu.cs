using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PreferencesMenu : MonoBehaviour
{
    GameObject prefButton;
    GameObject avatarButton;
    GameObject prefMenu;
    public Slider ageSlider;

    // Start is called before the first frame update
    void Start()
    {
        prefButton = GameObject.Find("Preferences");
        avatarButton = GameObject.Find("Avatar");
        prefMenu = GameObject.Find("PreferencesMenu");
        showPreferencesPage(false);
    }

    public void showProfileButtons (bool show) {
        prefButton.SetActive(show);
        avatarButton.SetActive(show);
    
    }
    
    public void changeVisitedPrefs() {
        GameObject.Find("SceneChange").GetComponent<SceneManagement2>().visitedPreferences = true;
    }
    
    public void showAge() {
        GameObject.Find("AgeText").GetComponent<Text>().text = ageSlider.value.ToString();
    }
    
    public void showPreferencesPage (bool show) {
        prefMenu.SetActive(show);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
