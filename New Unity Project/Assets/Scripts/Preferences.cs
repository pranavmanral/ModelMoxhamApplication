using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Linq;

public class Preferences : MonoBehaviour
{    

    public Slider elevatorSlider;
    public Slider walkSlider;
    public Slider animSlider;
    private static bool created = false;
    GameObject cautionText;
    GameObject cautionBg;
    GameObject audioButton;
    GameObject mutedButton;

    public delegate void ChangeElevatorEvent (float elevatorSpeed); //I do declare!
    public static event ChangeElevatorEvent changeElevatorEvent;  // create an event variable 
    public float elevatorSpeed = 1;
    
    public delegate void ChangeWalkEvent (float walkSpeed); //I do declare!
    public static event ChangeWalkEvent changeWalkEvent;  // create an event variable 
    public float walkSpeed = 2;
    
    public delegate void ChangeAnimEvent (float animSpeed); //I do declare!
    public static event ChangeAnimEvent changeAnimEvent;  // create an event variable 
    public float animSpeed = 1;
     // trigger some change and call the event for all subscribers
     public void changeElevatorSpeed(){
        elevatorSpeed = elevatorSlider.value + 0.0f;
       if(changeElevatorEvent!=null) // checking if anyone is on the other line.
             changeElevatorEvent(elevatorSlider.value + 0.0f);
        EventSystem.current.SetSelectedGameObject(null);
     }
 
    public void changeWalkSpeed(){
        if(walkSlider.value > 3) {
            cautionText.SetActive(true);
            cautionBg.SetActive(true);
            var colors = walkSlider.colors;
            colors.normalColor = Color.red;
            colors.highlightedColor = Color.red;
            colors.pressedColor = Color.red;
            colors.selectedColor = Color.red;
            walkSlider.colors = colors;   
            var fill = (walkSlider as UnityEngine.UI.Slider).GetComponentsInChildren<UnityEngine.UI.Image>().FirstOrDefault(t => t.name == "Fill");
            var background = (walkSlider as UnityEngine.UI.Slider).GetComponentsInChildren<UnityEngine.UI.Image>().FirstOrDefault(t => t.name == "Background");
            if (fill != null)
            {
                fill.color = Color.red;
            }
            if (background != null) {
                background.color = Color.red;
            }
        }
        else {
            cautionText.SetActive(false);
            cautionBg.SetActive(false);
            var colors = walkSlider.colors;
            colors.normalColor = Color.white;
            colors.highlightedColor = Color.white;
            colors.pressedColor = Color.white;
            colors.selectedColor = Color.white;
            walkSlider.colors = colors;
            var fill = (walkSlider as UnityEngine.UI.Slider).GetComponentsInChildren<UnityEngine.UI.Image>().FirstOrDefault(t => t.name == "Fill");
            var background = (walkSlider as UnityEngine.UI.Slider).GetComponentsInChildren<UnityEngine.UI.Image>().FirstOrDefault(t => t.name == "Background");
            if (fill != null)
            {
                fill.color = Color.white;
            }
            if (background != null) {
                background.color = Color.white;
            }
        }
    
        walkSpeed = walkSlider.value + 0.0f;
       if(changeWalkEvent!=null) // checking if anyone is on the other line.
             changeWalkEvent(walkSlider.value + 0.0f);
        EventSystem.current.SetSelectedGameObject(null);
     }
     
     public void changeAnimSpeed(){
        animSpeed = animSlider.value + 0.0f;
        if(changeAnimEvent!=null) // checking if anyone is on the other line.
             changeAnimEvent(animSlider.value + 0.0f);
        EventSystem.current.SetSelectedGameObject(null);
     }
 
 
 
 // Then you subscribe to the even from any class. and if the event is triggered (changed) then your other class will be notified.
 
 
   public void haveSound(bool yes) {

        audioButton.SetActive(yes);
        mutedButton.SetActive(!yes);
        GameObject.Find("SceneLoader").GetComponent<AudioSource>().mute = !yes;
   }
   
    void Awake()
    {
        if (!created)
        {
            DontDestroyOnLoad(this.gameObject);
            created = true;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        cautionText = GameObject.Find("cautionText");
        cautionBg = GameObject.Find("cautionBG");
        
        cautionText.SetActive(false);
        cautionBg.SetActive(false);
        
        
        audioButton = GameObject.Find("AudioButton");
        mutedButton = GameObject.Find("MutedButton");
        
        audioButton.SetActive(true);
        mutedButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
