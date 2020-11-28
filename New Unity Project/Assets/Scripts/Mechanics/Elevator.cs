using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer.Mechanics
{

    public class Elevator : MonoBehaviour
    {
    
        GameObject player;
        GameObject elevatorUI;
        public float targetY = -3.77f;
        private Transform target;
        public float speed = 1.0f;
        public bool arrived = false;
        private Animator anim;
        public bool doorOpened = false;
        public bool doorClosed = true;
        private bool animEnded = true;
        private string currentAnim = "DoorClose";
        GameObject currentElevatorFrontPanel;
        private int currentLevel=0;
        public bool levelSelected = false;
        bool playingElevatorMusic = false;
        bool playingScene2Music = true;
        
        
        
        // Start is called before the first frame update
        void Start()
        {
            player = GameObject.Find("Player");
            elevatorUI = GameObject.Find("Elevator UI Canvas");
            target = GameObject.Find("LevelTarget").transform;
            //anim = GetComponent<Animator>();      
            currentElevatorFrontPanel = GameObject.Find("Elevator Front Panel " + currentLevel.ToString());
            anim = currentElevatorFrontPanel.GetComponent<Animator>();       
            speed = GameObject.Find("Preferences").GetComponent<Preferences>().elevatorSpeed;
            anim.SetFloat("speedMultiplier", GameObject.Find("Preferences").GetComponent<Preferences>().animSpeed);
        }
        
        
        void OnEnable(){
          Preferences.changeElevatorEvent += ElevatorSpeedChanged; // subscribing to the event. 
          Preferences.changeAnimEvent += AnimSpeedChanged; // subscribing to the event. 

       }

       void OnDisable(){
          Preferences.changeElevatorEvent -= ElevatorSpeedChanged; // subscribing to the event. 
          Preferences.changeAnimEvent -= AnimSpeedChanged; // subscribing to the event. 
       }


       void ElevatorSpeedChanged(float newElevatorSpeed){
          speed = newElevatorSpeed;
       }
       



       void AnimSpeedChanged(float newAnimSpeed){
          anim.SetFloat("speedMultiplier", newAnimSpeed);
       }
        
        public void _GoToLevel(int level) {
        
        /*
            arrived = false;
            animEnded = false;
            anim.enabled=true;
            */
            
            if(!doorClosed) {
                if(anim.GetCurrentAnimatorStateInfo(0).IsName("DoorOpen")) {
                    anim.Play("Base Layer.DoorClose", 0, 1.0f-anim.GetCurrentAnimatorStateInfo(0).normalizedTime);
                }
                else {
                    anim.Play("Base Layer.DoorClose", 0, 0.0f);
                }
                currentAnim = "DoorClose";
            }
            
            
            
            arrived = false;
            animEnded = false;
            anim.enabled=true;
            levelSelected = true;
            player.GetComponent<PlayerController>().atElevator = false;
            currentLevel = level;
            
            if(level == 0) {
                targetY = -3.77f;
                //this.transform.Translate(0, (float)(1.2-this.transform.position.y),0);
            }
            if(level == 1) {
                targetY = -0.291f;
                //this.transform.Translate(0, (float)(3.2-this.transform.position.y),0);
            }
            if(level == 2) {
                targetY = 8.17f;

                //this.transform.Translate(0, (float)(5.2-this.transform.position.y),0);
            }
            if(level == 3) {
                targetY = 11.616f;

                //this.transform.Translate(0, (float)(5.2-this.transform.position.y),0);
            }
        
        }
        
        void _ToggleElevatorMenu(bool show)
            {
                if (show)
                {
                    elevatorUI.gameObject.SetActive(true);
                    if(GameObject.Find("TutorialManager").GetComponent<TutorialManager>().page == 2){
                        GameObject.Find("TutorialManager").GetComponent<TutorialManager>().ManagePage(3);
                    }
                }
                else
                {
                    elevatorUI.gameObject.SetActive(false);
                }
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
                player.GetComponent<PlayerController>().inElevator = true;
                player.transform.parent = transform;

                //getChild("Elevator Front Panel " + currentLevel.ToString(), "elevator_front").GetComponent<IsometricStaticObject>().floorHeight = -0.1f;

             }
        }
        
        void OnTriggerExit2D(Collider2D col)
        {
             if(col.name=="Player") {
                // Call Elevator to this level
                player.GetComponent<PlayerController>().inElevator = false;
                player.transform.parent = null;
                DontDestroyOnLoad(Transition.instance);

                //getChild("Elevator Front Panel " + currentLevel.ToString(), "elevator_front").GetComponent<IsometricStaticObject>().floorHeight = 0.6f;

             }
        }
        
        // Update is called once per frame
        void Update()
        {
        
            if(player.GetComponent<Platformer.Mechanics.PlayerController>().inElevator == true) {
                _ToggleElevatorMenu(show: true);
                if(!playingElevatorMusic) {
                    GameObject.Find("SceneLoader").GetComponent<AudioSource>().clip = GameObject.Find("SceneLoader").GetComponent<SpawnManager>().Elevator_Music;
                    GameObject.Find("SceneLoader").GetComponent<AudioSource>().Play();
                    playingElevatorMusic = true;
                    playingScene2Music = false;
                }
            }
            else {
                _ToggleElevatorMenu(show: false);
                if(!playingScene2Music) {
                    GameObject.Find("SceneLoader").GetComponent<AudioSource>().clip = GameObject.Find("SceneLoader").GetComponent<SpawnManager>().Scene2_Music;
                    GameObject.Find("SceneLoader").GetComponent<AudioSource>().Play();
                    playingScene2Music = true;
                    playingElevatorMusic = false;
                }
            }    
        
            if(doorClosed) {

                if(player.GetComponent<Platformer.Mechanics.PlayerController>().inElevator) {
                    player.GetComponent<Platformer.Mechanics.PlayerController>().controlEnabled = false;
                    player.GetComponent<CapsuleCollider2D>().isTrigger = true;
                }
                currentElevatorFrontPanel = GameObject.Find("Elevator Front Panel " + currentLevel.ToString());
                anim = currentElevatorFrontPanel.GetComponent<Animator>();
                anim.SetFloat("speedMultiplier", GameObject.Find("Preferences").GetComponent<Preferences>().animSpeed);
                player.GetComponent<PlayerController>().canLeave = false;
                float step =  speed * Time.deltaTime; // calculate distance to move
                target.position = new Vector2(transform.position.x, targetY);
                transform.position = Vector2.MoveTowards(transform.position, target.position, step);
                // Check if the position of the cube and sphere are approximately equal.
                if (Vector3.Distance(this.transform.position, target.position) < 0.001f)
                {
                    // Swap the position of the cylinder.
                    this.transform.position = target.position;
                    arrived = true;
                    player.GetComponent<CapsuleCollider2D>().isTrigger = false;

                    player.GetComponent<Platformer.Mechanics.PlayerController>().controlEnabled = true;
                    if(player.GetComponent<PlayerController>().inElevator) {
                        player.GetComponent<PlayerController>().atElevator = true;
                    }
                    levelSelected = false;
                    getChild("Elevator Front Panel " + currentLevel.ToString(), "elevator_front").GetComponent<IsometricStaticObject>().floorHeight = -0.1f;
                    //if (player.GetComponent<Platformer.Mechanics.PlayerController>().inElevator) {
                        //animEnded = false;
                        //anim.enabled=true;
                        //anim.Play("Base Layer.DoorOpen", 0, 0.0f);
                        //currentAnim = "DoorOpen";
                    //}
                }
            }
            
            
            if(arrived) {
                if (anim != null)
                {
                
                    if(!levelSelected && player.GetComponent<PlayerController>().atElevator && currentAnim != "DoorOpen") {
                        animEnded = false;
                        anim.enabled=true;

                        //anim.enabled= true;
                        if(anim.GetCurrentAnimatorStateInfo(0).IsName("DoorClose")) {
                            anim.Play("Base Layer.DoorOpen", 0, 1.0f-anim.GetCurrentAnimatorStateInfo(0).normalizedTime);
                        }
                        else {
                            anim.Play("Base Layer.DoorOpen", 0, 0.0f);
                        }
                        currentAnim = "DoorOpen";
                    }
                    if(!player.GetComponent<PlayerController>().atElevator && currentAnim != "DoorClose") {
                        animEnded = false;
                        anim.enabled=true;

                        //anim.enabled= true;
                        if(anim.GetCurrentAnimatorStateInfo(0).IsName("DoorOpen")) {
                            anim.Play("Base Layer.DoorClose", 0, 1.0f-anim.GetCurrentAnimatorStateInfo(0).normalizedTime);
                        }
                        else {
                            anim.Play("Base Layer.DoorClose", 0, 0.0f);
                        }
                        currentAnim = "DoorClose";
                    }
                }
            }
        
        
            if(currentAnim == "DoorOpen" && anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && anim.GetCurrentAnimatorStateInfo(0).IsName("DoorOpen")) {
                doorOpened = true;
                player.GetComponent<PlayerController>().canLeave = true;
                anim.enabled = false;
                animEnded = true;
                getChild("Elevator Front Panel " + currentLevel.ToString(), "elevator_front").GetComponent<IsometricStaticObject>().floorHeight = -0.1f;
            }
            
            if(currentAnim == "DoorClose" && !animEnded && anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && anim.GetCurrentAnimatorStateInfo(0).IsName("DoorClose")) {
                doorClosed   = true;
                anim.enabled = false;
                animEnded = true;
                
                getChild("Elevator Front Panel " + currentLevel.ToString(), "elevator_front").GetComponent<IsometricStaticObject>().floorHeight = 0.6f;

                //Debug.Log(anim.GetCurrentAnimatorStateInfo(0).normalizedTime);
            }
               
        
        /*
            if(currentAnim == "DoorOpen" && anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && anim.GetCurrentAnimatorStateInfo(0).IsName("DoorOpen")) {
                doorOpened = true;
                player.GetComponent<Platformer.Mechanics.PlayerController>().canLeave = true;
                anim.enabled = false;
                animEnded = true;
            }
            
            if(currentAnim == "DoorClose" && !animEnded && anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && anim.GetCurrentAnimatorStateInfo(0).IsName("DoorClose")) {
                doorClosed   = true;
                anim.enabled = false;
                animEnded = true;
                //Debug.Log(anim.GetCurrentAnimatorStateInfo(0).normalizedTime);
            }
                
        
            if(player.GetComponent<Platformer.Mechanics.PlayerController>().inElevator == true) {
                _ToggleElevatorMenu(show: true);
            }
            else {
                _ToggleElevatorMenu(show: false);
            }
            
            if(doorClosed) {
                player.GetComponent<Platformer.Mechanics.PlayerController>().canLeave = false;
                float step =  speed * Time.deltaTime; // calculate distance to move
                target.position = new Vector2(transform.position.x, targetY);
                transform.position = Vector2.MoveTowards(transform.position, target.position, step);

                // Check if the position of the cube and sphere are approximately equal.
                if (Vector3.Distance(this.transform.position, target.position) < 0.001f)
                {
                    // Swap the position of the cylinder.
                    this.transform.position = target.position;
                    arrived = true;
                    if (player.GetComponent<Platformer.Mechanics.PlayerController>().inElevator) {
                        animEnded = false;
                        anim.enabled=true;
                        anim.Play("Base Layer.DoorOpen", 0, 0.0f);
                        currentAnim = "DoorOpen";
                    }
                }
            }*/
        }
    }

}