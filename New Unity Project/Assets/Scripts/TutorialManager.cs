using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class TutorialManager : MonoBehaviour
{
    GameObject welcomePage;
    GameObject movingPage;
    GameObject liftsPage;
    GameObject enteringStorePage;
    GameObject endPage;
    GameObject redArrowLifts;
    GameObject redArrowEntrance;
    GameObject helpButton;
    GameObject player;
    public int page = 0;
    private static bool created = false;

    // Start is called before the first frame update
    void Start()
    {
        welcomePage = GameObject.Find("WelcomePage");
        movingPage = GameObject.Find("MovingPage");
        liftsPage = GameObject.Find("LiftsPage");
        enteringStorePage = GameObject.Find("EnteringStorePage");
        endPage = GameObject.Find("EndPage");
        redArrowLifts = GameObject.Find("red_arrow (Lifts)");
        redArrowEntrance = GameObject.Find("red_arrow (Entrance)");
        helpButton = GameObject.Find("HelpButton");
        liftsPage.active = false;
        enteringStorePage.active = false;
        endPage.active = false;
        redArrowLifts.active = false;
        redArrowEntrance.active = false;
        player = GameObject.Find("Player");
        welcomePage.active = false;
        movingPage.active = false;
        helpButton.active = false;
    }

    // Update is called once per frame
    void Update()
    {
        
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
    
    public  void LetsDoIt() {
        player.GetComponent<Platformer.Mechanics.PlayerController>().controlEnabled = true;
        ManagePage(1);
    }
    
    public void EndTutorial() {
        ManagePage(5);
    }
    
    public void ManagePage(int num) {
        page = num;
        switch (num) {
            case 0:
                welcomePage.active = true;
                break;
            case 1:
                welcomePage.active = false;
                movingPage.active = true;
                redArrowEntrance.active = true;
                break;
            case 2:
                movingPage.active = false;
                redArrowEntrance.active = false;
                liftsPage.active = true;
                redArrowLifts.active = true;
                break;
            case 3:
                liftsPage.active = false;
                redArrowLifts.active = false;
                enteringStorePage.active = true;
                break;
            case 4:
                enteringStorePage.active = false;
                endPage.active = true;
                break;
            case 5:
                endPage.active = false;
                helpButton.active = true;
                break;
            default:
                break;
        }
    
    }
    
}
