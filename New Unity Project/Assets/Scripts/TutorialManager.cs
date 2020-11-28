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
    GameObject moxhamIntro1Page;
    GameObject moxhamIntro2Page;
    GameObject redArrowLifts;
    GameObject redArrowEntrance;
    GameObject helpButton;
    GameObject skipTutorialButton;
    GameObject player;
    public int page = 0;
    private static bool createdTutManager = false;

    // Start is called before the first frame update
    void Start()
    {
        welcomePage = GameObject.Find("WelcomePage");
        movingPage = GameObject.Find("MovingPage");
        liftsPage = GameObject.Find("LiftsPage");
        enteringStorePage = GameObject.Find("EnteringStorePage");
        endPage = GameObject.Find("EndPage");
        moxhamIntro1Page = GameObject.Find("WhatIsMoxhamPage1");
        moxhamIntro2Page = GameObject.Find("WhatIsMoxhamPage2");
        redArrowLifts = GameObject.Find("red_arrow (Lifts)");
        redArrowEntrance = GameObject.Find("red_arrow (Entrance)");
        helpButton = GameObject.Find("HelpButton");
        skipTutorialButton = GameObject.Find("SkipTutorialButton");
        liftsPage.SetActive(false);
        enteringStorePage.SetActive(false);
        endPage.SetActive(false);
        redArrowLifts.SetActive(false);
        redArrowEntrance.SetActive(false);
        player = GameObject.Find("Player");
        welcomePage.SetActive(false);
        movingPage.SetActive(false);
        helpButton.SetActive(false);
        skipTutorialButton.SetActive(false);
        moxhamIntro1Page.SetActive(false);
        moxhamIntro2Page.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void Awake()
    {
        if (!createdTutManager)
        {
            DontDestroyOnLoad(this.gameObject);
            createdTutManager = true;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    
    public void SkipTutorial() {
        skipTutorialButton.SetActive(false);
        player.GetComponent<Platformer.Mechanics.PlayerController>().controlEnabled = true;
        while(page < 5) {
            ManagePage(page + 1);
        }
    }
    
    public void LetsDoIt() {
        player.GetComponent<Platformer.Mechanics.PlayerController>().controlEnabled = true;
        ManagePage(1);
    }
    
    public void EndTutorial() {
        ManagePage(5);
    }
    
    public void GoToMMIntro1() {
        ManagePage(-2);
    }
    
    public void GoToMMIntro2() {
        ManagePage(-1);
    }
    
    public void GoToStart() {
        ManagePage(0);
    }
    
    public void ManagePage(int num) {
        page = num;
        switch (num) {
            case 0:
                moxhamIntro2Page.SetActive(false);
                welcomePage.SetActive(true);
                skipTutorialButton.SetActive(true);
                break;
            case 1:
                welcomePage.SetActive(false);
                movingPage.SetActive(true);
                redArrowEntrance.SetActive(true);
                break;
            case 2:
                movingPage.SetActive(false);
                redArrowEntrance.SetActive(false);
                liftsPage.SetActive(true);
                redArrowLifts.SetActive(true);
                break;
            case 3:
                liftsPage.SetActive(false);
                redArrowLifts.SetActive(false);
                enteringStorePage.SetActive(true);
                break;
            case 4:
                enteringStorePage.SetActive(false);
                endPage.SetActive(true);
                break;
            case 5:
                endPage.SetActive(false);
                helpButton.SetActive(true);
                skipTutorialButton.SetActive(false);
                break;
            case -2:
                //Moxham Intro  1
                welcomePage.SetActive(false);
                moxhamIntro1Page.SetActive(true);
                break;
            case -1:
                moxhamIntro1Page.SetActive(false);
                moxhamIntro2Page.SetActive(true);
                break;
            default:
                break;
        }
    
    }
    
}
