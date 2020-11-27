using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExteriorEntrance : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
        {
             if(col.name=="Player") {
                if(GameObject.Find("TutorialManager").GetComponent<TutorialManager>().page < 5) {
                    GameObject.Find("TutorialManager").GetComponent<TutorialManager>().ManagePage(2);
                }
             }
        }

    // Update is called once per frame
    void Update()
    {
        
    }
}
