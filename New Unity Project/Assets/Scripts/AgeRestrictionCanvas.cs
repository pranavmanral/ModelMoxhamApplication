﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgeRestrictionCanvas : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
     public void CloseAgeRestrictionCanvas() {
        GetComponent<Canvas>().enabled = false;    
    }
}
