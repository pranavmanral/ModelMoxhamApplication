using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AgeManager : MonoBehaviour
{
    private static bool created = false;
    public bool isUnderAge = true;
    public Slider ageSlider;

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
    
    public void ChangeAgeRestriction() {
        if(ageSlider.value < 18) {
            isUnderAge = true;
        }
        else {
            isUnderAge = false;
        }
    }
    
   
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
