using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Preferences : MonoBehaviour
{    

    public Slider elevatorSlider;
    public Slider walkSlider;
    public Slider animSlider;
    private static bool created = false;

    public delegate void ChangeElevatorEvent (float elevatorSpeed); //I do declare!
    public static event ChangeElevatorEvent changeElevatorEvent;  // create an event variable 
    public float elevatorSpeed = 0;
    
    public delegate void ChangeWalkEvent (float walkSpeed); //I do declare!
    public static event ChangeWalkEvent changeWalkEvent;  // create an event variable 
    public float walkSpeed = 0;
    
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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
