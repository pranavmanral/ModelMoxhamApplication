using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangingColour : MonoBehaviour
{
    public SpriteRenderer hair;
    public Color[] colors;

    public Color[] mainColors;

    public int hairColor = 0;

    public SpriteRenderer main;
    public SpriteRenderer mainRight;
    public SpriteRenderer mainLeft;
    public int mainColor = 0;

    public Color[] lowerColors;
    public SpriteRenderer lowerLeftUp;
    public SpriteRenderer lowerLeftDown;
    public SpriteRenderer lowerRightUp;
    public SpriteRenderer lowerRightDown;
    public int lowerColor = 0;

    // public SpriteRenderer main;
    //public int mainColor = 1;

    void Start()
    {
        //colors.a = 0.42f;
    }

    // Update is called once per frame
    void Update()
    {
        //displayCopy = hair.color;

        for (int i = 0; i < colors.Length; i++)
        {
            if (i == hairColor)
            {
                hair.color = colors[i];
            }
        }         
        ///////Main
        for (int i = 0; i < colors.Length; i++)
        {
            if (i == mainColor)
            {
                main.color = mainColors[i];
                mainRight.color = mainColors[i];
                mainLeft.color = mainColors[i];
            }
        }
        for (int i = 0; i < colors.Length; i++)
        {
            if (i == lowerColor)
            {
                lowerLeftUp.color = lowerColors[i];
                lowerLeftDown.color = lowerColors[i];
                lowerRightUp.color = lowerColors[i];
                lowerRightDown.color = lowerColors[i];
            }
        }

    }

    public void ChangeHairColor(int index)
    {
        hairColor = index;
    }

    public void ChangeMainColor(int index)
    {
        mainColor = index;
    }

    public void ChangeLowerColor(int index)
    {
        lowerColor = index;
    }

}
