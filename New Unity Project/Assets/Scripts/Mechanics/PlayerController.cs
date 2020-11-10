using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Platformer.Mechanics
{
    public class PlayerController : DynamicObject
    {
        public float maxSpeed = 7;
        
        private readonly float m_tan30 = Mathf.Tan(Mathf.PI/3);

        public bool controlEnabled = true;
        public bool inElevator = false;
        
        private bool canEnter = false;
        public bool atElevator = false;
        public bool canLeave = true;


        Vector2 move;

        // Start is called before the first frame update
        protected override void Start()
        {

        }

        // Update is called once per frame
        protected override void Update()
        {
            move.x = Input.GetAxis("Horizontal");
            move.y = Input.GetAxis("Vertical");
            base.Update();
        }
        
        protected override void ComputeVelocity()
        {
            
            
            targetVelocity.x = move.y==0?move.x:move.x+move.y*m_tan30;
            targetVelocity.y = move.y;
            targetVelocity = targetVelocity * maxSpeed;
        }

    }

}