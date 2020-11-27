using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;


public class ElevatorButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

    public GameObject buttonBG;
    public List<Action<PointerEventData>> OnMouseDownListeners = new List<Action<PointerEventData>>();
    public List<Action<PointerEventData>> OnMouseUpListeners = new List<Action<PointerEventData>>();

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    

    
    public void OnPointerDown(PointerEventData eventData)
     {
         foreach (var callback in OnMouseDownListeners)
         {
             callback(eventData);
         }
        buttonBG.GetComponent<ChangeButtonColour>().ChangeColour();

     }
     
     public void AddOnMouseDownListener(Action<PointerEventData> action)
     {
         OnMouseDownListeners.Add(action);
     }
     
     public void OnPointerUp(PointerEventData eventData)
     {
         foreach (var callback in OnMouseDownListeners)
         {
             callback(eventData);
         }
        buttonBG.GetComponent<ChangeButtonColour>().UnchangeColour();

     }
     
     public void AddOnMouseUpListener(Action<PointerEventData> action)
     {
         OnMouseDownListeners.Add(action);
     }
    
}
