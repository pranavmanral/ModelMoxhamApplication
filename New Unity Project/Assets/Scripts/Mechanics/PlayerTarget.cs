using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Platformer.Mechanics {

    public class PlayerTarget : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            transform.position = GameObject.Find("Player").transform.position;
        }
    }

}