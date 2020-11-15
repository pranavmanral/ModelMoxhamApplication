using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangingColour : MonoBehaviour
{
    public SpriteRenderer head;

    public Color pink;
    public Color blue;
    public Color green;
    //public Image displayCopy;
    public int whatColor = 1;



    public SpriteRenderer torso;
    public Color yellow;
    public Color lightPink;
    public Color skin;

    public int torsoColor = 1;




    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //displayCopy = head.color;

        if(whatColor == 1)
        {
            head.color = pink;
        }
        else if(whatColor == 2)
        {
            head.color = blue;
        }
        else if (whatColor == 3)
        {
            head.color = green;
        }



        if (torsoColor == 1)
        {
            torso.color = yellow;
        }
        else if (torsoColor == 2)
        {
            torso.color = lightPink;
        }
        else if (torsoColor == 3)
        {
            torso.color = skin;
        }
    }

    public void ChangeHeadPink()
    {
        whatColor = 1;
    }

    public void ChangeHeadBlue()
    {
        whatColor = 2;
    }

    public void ChangeHeadGreen()
    {
        whatColor = 3;
    }


    public void ChangeTorsoYellow()
    {
        torsoColor = 1;
    }

    public void ChangeTorsoLightPink()
    {
        torsoColor = 2;
    }

    public void ChangeTorsoSkin()
    {
        torsoColor = 3;
    }
}
