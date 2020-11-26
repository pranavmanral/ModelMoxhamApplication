using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawning : MonoBehaviour
{
    public string nextScene;
    public string spawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void OnTriggerEnter2D(Collider2D col) {
        if(col.name=="Player") {
            GameObject.Find("SceneLoader").GetComponent<SpawnManager>().LoadScene(nextScene, spawnPoint);
        }
    }
    
    
}
