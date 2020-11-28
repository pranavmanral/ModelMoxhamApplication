using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TipText : MonoBehaviour
{
    string[] tipArray = new string[]{"... you can press spacebar to activate a portal and go to the shop's website?", "... Model Moxham was founded by Grace Bros in 1885? That's over 100 years old!", "... you can explore Model Moxham in the game through some of the exits in Broadway?", "... the globe above Model Moxham used to say 'GRACE' on it?", "... you can press WASD or the arrow keys to move about in the game?"};

    // Start is called before the first frame update
    void Start()
    {
        GetNextTip();   
    }

    public void GetNextTip() {
        GetComponent<Text>().text = tipArray[Random.Range(0, tipArray.Length)];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
