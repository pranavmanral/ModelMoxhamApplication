using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Platformer.Mechanics
{


    public class IsometricStaticObject : MonoBehaviour
    {
    
        public float floorHeight=0;
        private float m_spriteLowerBound;
        private float m_spriteHalfWidth;
        private readonly float m_tan30 = Mathf.Tan(Mathf.PI/3);
        public bool isStatic= true;

        // Start is called before the first frame update
        void Start()
        {
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
            m_spriteLowerBound = spriteRenderer.bounds.size.y * 0.5f;
            m_spriteHalfWidth = spriteRenderer.bounds.size.x * 0.5f;
            if(isStatic) {
                transform.position = new Vector3(transform.position.x, transform.position.y, (transform.position.y - m_spriteLowerBound + floorHeight) * m_tan30);
            }
        }

/*
        #if UNITY_EDITOR
        void LateUpdate() {
            //Use this condition for objects that don't move in the scene.
            if(!Application.isPlaying) {
                transform.position = new Vector3(transform.position.x, transform.position.y, (transform.position.y - m_spriteLowerBound + floorHeight) * m_tan30);
            }
        }
        #endif
        
        */
        
        

        void OnDrawGizmos() {
            Vector3 floorHeightPos = new Vector3(transform.position.x, transform.position.y - m_spriteLowerBound + floorHeight, transform.position.z);
            
            Gizmos.color = Color.magenta;
            Gizmos.DrawLine(floorHeightPos + Vector3.left * m_spriteHalfWidth, floorHeightPos + Vector3.right * m_spriteHalfWidth);
        }

        // Update is called once per frame
        void Update()
        {
            if(!isStatic) {
                transform.position = new Vector3(transform.position.x, transform.position.y, (transform.position.y - m_spriteLowerBound + floorHeight) * m_tan30);
            }
        }
    }

}
