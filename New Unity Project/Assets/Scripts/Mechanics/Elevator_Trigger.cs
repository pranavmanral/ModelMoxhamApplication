using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Platformer.Mechanics
{

    public class Elevator_Trigger : MonoBehaviour
    {
        public int level = 0;
        GameObject elevator;
        GameObject player;

        
        // Start is called before the first frame update
        void Start()
        {
            elevator = GameObject.Find("Elevator");
            player = GameObject.Find("Player");
        }

        // Update is called once per frame
        void Update()
        {
        
        }
        
        GameObject getChild(string parent, string name) {
            foreach(Transform child in GameObject.Find(parent).transform) {
                if(child.name==name) {
                    return child.gameObject;
                }
            }
            return null;
        }
        
        void OnTriggerEnter2D(Collider2D col)
        {
             if(col.name=="Player") {
                // Call Elevator to this level
                elevator.GetComponent<Elevator>()._GoToLevel(level);
                player.GetComponent<PlayerController>().atElevator = true;
                getChild("Elevator Front Panel " + level.ToString(), "elevator_front").GetComponent<IsometricStaticObject>().floorHeight = 0.6f;
                
             }
        }
        
        void OnTriggerExit2D(Collider2D col)
        {
             if(col.name=="Player") {
                // Call Elevator to this level
                player.GetComponent<PlayerController>().atElevator = false;
                
                getChild("Elevator Front Panel " + level.ToString(), "elevator_front").GetComponent<IsometricStaticObject>().floorHeight = -0.1f;

             }
        }
        
    }
}
