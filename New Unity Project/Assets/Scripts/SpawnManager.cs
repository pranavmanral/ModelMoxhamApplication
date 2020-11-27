using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SpawnManager : MonoBehaviour
{
    
    private static bool created = false;
    string point = null;
    float elevatorY;


    // Start is called before the first frame update
    void Start()
    {
            GameObject.Find("Player").transform.localScale = new Vector3(0.2f,0.2f,0.2f);

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

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void LoadScene(string sceneToLoad, string spawnPoint) {
        point = spawnPoint;
        if(SceneManager.GetActiveScene().name == "Scene2") {
            elevatorY = GameObject.Find("Elevator").transform.position.y;
        }
        SceneManager.LoadScene(sceneToLoad);
    }
    /*
    void OnLevelWasLoaded() {
        if(point != null) {
            GameObject.Find("Player").transform.position = GameObject.Find(point).transform.position; //Spawn player here
         }
     }*/
     void OnEnable()
     {
      //Tell our 'OnLevelFinishedLoading' function to start listening for a scene change as soon as this script is enabled.
         SceneManager.sceneLoaded += OnLevelFinishedLoading;
     }

     void OnDisable()
     {
     //Tell our 'OnLevelFinishedLoading' function to stop listening for a scene change as soon as this script is disabled. Remember to always have an unsubscription for every delegate you subscribe to!
         SceneManager.sceneLoaded -= OnLevelFinishedLoading;
     }

     void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
     {
         /*Debug.Log("Level Loaded");
         Debug.Log(scene.name);
         Debug.Log(mode);*/
         if(point != null) {
            GameObject.Find("Player").transform.position = GameObject.Find(point).transform.position; //Spawn player here
            if(scene.name == "Scene1A") {
                GameObject.Find("FirstLoad").GetComponent<FirstLoad>().isFirstLoad = false;
            }
            else if(scene.name == "Scene2") {
                GameObject.Find("Elevator").transform.position = new Vector3(GameObject.Find("Elevator").transform.position.x, elevatorY, GameObject.Find("Elevator").transform.position.z);
                GameObject.Find("Elevator").GetComponent<Platformer.Mechanics.Elevator>().targetY = elevatorY;
            }
         }
     }
}
