using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragVolume : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{

    [SerializeField] 
     Vector2 startPoint;
     
     [SerializeField]
     Vector2 endPoint;
 
    [SerializeField]
    Vector2 lastPoint;
 
    public bool hasDragged = false;

     public float sensitivity = 0.001f;
 
     void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
     {
        hasDragged = false;
         startPoint = eventData.pressPosition;
         lastPoint = startPoint;
     }
 
     public void OnDrag(PointerEventData eventData)
     {
         endPoint = eventData.position;
         
        GameObject.Find("SceneLoader").GetComponent<AudioSource>().volume += (endPoint.x - lastPoint.x) * sensitivity;
        GameObject.Find("AudioVolume").GetComponent<Text>().text = Mathf.Round(GameObject.Find("SceneLoader").GetComponent<AudioSource>().volume * 100).ToString();
         lastPoint = endPoint;
         hasDragged= true;
         
     }
 
     public void OnEndDrag(PointerEventData eventData)
     {
        GameObject.Find("AudioVolume").GetComponent<Text>().text = "";
        Debug.Log(lastPoint.x - startPoint.x);
        hasDragged = false;
     }
}
