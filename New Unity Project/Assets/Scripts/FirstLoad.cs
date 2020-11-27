using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;


public class FirstLoad : MonoBehaviour
{
    public bool isFirstLoad = true;
    private Animator anim;
    
    // Start is called before the first frame update
    void Start()
    {
        
        if(isFirstLoad) {
            anim = GameObject.Find("Main Camera").GetComponent<Animator>();    
            anim.Play("Base Layer.CameraDolly", 0, 0.0f);
        }
        else {
            GameObject.Find("CM vcam1").GetComponent<CinemachineVirtualCamera>().enabled = true; 
            GameObject.Find("Player").GetComponent<Platformer.Mechanics.PlayerController>().controlEnabled = true;

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
