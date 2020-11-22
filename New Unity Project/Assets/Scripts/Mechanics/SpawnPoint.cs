using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Platformer.Mechanics
{

    public class SpawnPoint : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            GameObject.Find("Player").transform.position = transform.position;

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}