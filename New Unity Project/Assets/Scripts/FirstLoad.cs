using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;


public class FirstLoad : MonoBehaviour
{
    public bool isFirstLoad = true;
    private Animator anim;
   GameObject TeleportButton;
    
    // Start is called before the first frame update
    void Start()
    {
        
        if(isFirstLoad) {
            GameObject.Find("SceneLoader").GetComponent<SpawnManager>().ShowTeleportButton(false);
            anim = GameObject.Find("Main Camera").GetComponent<Animator>();    
            anim.SetFloat("speedMultiplier", GameObject.Find("Preferences").GetComponent<Preferences>().animSpeed);
            anim.Play("Base Layer.CameraDolly", 0, 0.0f);
        }
        else {
            GameObject.Find("SceneLoader").GetComponent<SpawnManager>().ShowTeleportButton(true);
            GameObject.Find("CM vcam1").GetComponent<CinemachineVirtualCamera>().enabled = true; 
            GameObject.Find("Player").GetComponent<Platformer.Mechanics.PlayerController>().controlEnabled = true;

        }
    }

    
    // Update is called once per frame
    void Update()
    {
        
    }
    
    void OnEnable(){
          Preferences.changeAnimEvent += AnimSpeedChanged; // subscribing to the event. 

       }

    void OnDisable(){
          Preferences.changeAnimEvent -= AnimSpeedChanged; // subscribing to the event. 
    }


   void AnimSpeedChanged(float newAnimSpeed){
      anim.SetFloat("speedMultiplier", newAnimSpeed);
   }
}
