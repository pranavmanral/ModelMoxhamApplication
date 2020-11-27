using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeButtonColour : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void ChangeColour() {
        GetComponent<Image>().color = new Color(0.3f, 0.65f, 0.3f);
    }
    
    public void UnchangeColour() {
        GetComponent<Image>().color = Color.white;
    }
}
