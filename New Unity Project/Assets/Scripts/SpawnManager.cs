using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SpawnManager : MonoBehaviour
{
    
    private static bool created = false;
    string point = null;
    float elevatorY;
    public AudioClip Scene1A_Music;
    public AudioClip Scene2_Music;
    public AudioClip Scene3A_Music;
    public AudioClip Scene3B_Music;
    public AudioClip Scene3C_Music;
    public AudioClip Scene3D_Music;
    public AudioClip Scene3E_Music;
    public AudioClip Elevator_Music;
    public AudioSource audioSource;
    GameObject TeleportButton;

    
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
        TeleportButton = GameObject.Find("TeleportButton");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void ShowTeleportButton(bool show) {
        TeleportButton.SetActive(show);
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
                if(!GameObject.Find("FirstLoad").GetComponent<FirstLoad>().isFirstLoad) {
                    GameObject.Find("SceneLoader").GetComponent<SpawnManager>().ShowTeleportButton(true);
                }
                GameObject.Find("FirstLoad").GetComponent<FirstLoad>().isFirstLoad = false;
            }
            else if(scene.name == "Scene2") {
                GameObject.Find("SceneLoader").GetComponent<SpawnManager>().ShowTeleportButton(true);
                GameObject.Find("Elevator").transform.position = new Vector3(GameObject.Find("Elevator").transform.position.x, elevatorY, GameObject.Find("Elevator").transform.position.z);
                GameObject.Find("Elevator").GetComponent<Platformer.Mechanics.Elevator>().targetY = elevatorY;
            }
            else {
                GameObject.Find("SceneLoader").GetComponent<SpawnManager>().ShowTeleportButton(true);
            }
         }
         audioSource = GetComponent<AudioSource>();
         bool isMute = GameObject.Find("Preferences").GetComponent<Preferences>().isMute;
         switch(scene.name) {

            case "Scene1A":
                audioSource.clip = Scene1A_Music;
                break;
            case "Scene2":
                audioSource.clip = Scene2_Music;
                break;
            case "Scene3A":
                audioSource.clip = Scene3A_Music;
                break;
            case "Scene3B":
                audioSource.clip = Scene3B_Music;
                break;
            case "Scene3C":
                audioSource.clip = Scene3C_Music;
                break;
            case "Scene3D":
                audioSource.clip = Scene3D_Music;
                break;
            case "Scene3E":
                audioSource.clip = Scene3E_Music; 
                break;
         
         }
         if(!isMute) {
            audioSource.Play();
         }
         else {
            audioSource.Pause();
         }
        GameObject.Find("AudioVolume").GetComponent<Text>().text = "";

     }
}
