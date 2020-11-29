using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Platformer.Mechanics
{
    public class PlayerController : DynamicObject
    {
        public float maxSpeed = 7;
        
        private readonly float m_tan30 = Mathf.Tan(Mathf.PI/3);

        public bool controlEnabled = false;
        public bool inElevator = false;
        
        public bool atElevator = false;
        public bool canLeave = true;

        internal Animator animator;


        Vector2 move;

        // Start is called before the first frame update
        protected override void Start()
        {
            animator = GetComponent<Animator>();
        }

        // Update is called once per frame
        protected override void Update()
        {
            if(controlEnabled){
                move.x = Input.GetAxis("Horizontal");
                move.y = Input.GetAxis("Vertical");
                if((move.x < 0 && transform.localScale.x > 0) ||  (move.x > 0 && transform.localScale.x < 0)) {
                    transform.localScale = new Vector3(-1 * transform.localScale.x, transform.localScale.y,transform.localScale.z);
                }
            }
            else {
            
                move.x = 0;
                move.y = 0;
            }
            base.Update();
        }
        
        protected override void OnEnable(){
          Preferences.changeWalkEvent += WalkSpeedChanged; // subscribing to the event. 
          base.OnEnable();
       }

       protected override void OnDisable(){
          Preferences.changeWalkEvent -= WalkSpeedChanged; // subscribing to the event.
            base.OnEnable();
       }


       void WalkSpeedChanged(float newWalkSpeed){
          maxSpeed = newWalkSpeed;
       }
        
        protected override void ComputeVelocity()
        {
            
            
            //targetVelocity.x = move.y==0?move.x:move.x+move.y*m_tan30;
            targetVelocity.x = move.x;
            targetVelocity.y = move.y;
            targetVelocity = targetVelocity * maxSpeed;
            animator.SetFloat("velocityX", Mathf.Abs(targetVelocity.x) / maxSpeed);
            animator.SetFloat("velocityY", Mathf.Abs(targetVelocity.y) / maxSpeed);
            animator.SetFloat("velocityOverall", (Mathf.Abs(targetVelocity.x) / maxSpeed) + (Mathf.Abs(targetVelocity.y) / maxSpeed));
        }

    }

}