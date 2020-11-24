using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace Platformer.Mechanics {
    public class Portal : MonoBehaviour
    {
        public Sprite normalSprite;
        public Sprite hoverSprite;
        public string portal_name;
        bool canShowCanvas = false;
        
        // Start is called before the first frame update
        void Start()
        {
            GameObject canvas = getChild(transform.gameObject, "Canvas");
            GameObject text = getChild(canvas, "Text");
            text.GetComponent<Text>().text = "Go to the website of " + portal_name + "?"; 
            canvas.GetComponent<Canvas>().enabled = false;
            
        }
        
        GameObject getChild(GameObject gameObject, string name) {
            foreach(Transform child in gameObject.transform) {
                if(child.name==name) {
                    return child.gameObject;
                }
            }
            return null;
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKey("space") && canShowCanvas) {
                GameObject canvas = getChild(transform.gameObject, "Canvas");
                canvas.GetComponent<Canvas>().enabled = true;
            }
        }

        void OnTriggerEnter2D(Collider2D col)
        {
             if(col.name=="Player") {
                GetComponent<SpriteRenderer>().sprite = hoverSprite;
                canShowCanvas = true;

             }
        }

        void OnTriggerExit2D(Collider2D col)
        {
             if(col.name=="Player") {
                GetComponent<SpriteRenderer>().sprite = normalSprite;
                canShowCanvas = false;
                GameObject canvas = getChild(transform.gameObject, "Canvas");
                canvas.GetComponent<Canvas>().enabled = false;
             }
        }
    }
}