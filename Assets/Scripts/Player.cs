using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Core
{
    public class Player : MonoBehaviour
    {
        Animator animator;
        SpriteRenderer sprite;


        [SerializeField] float movementSpeed;
        [SerializeField] Material red;
        [SerializeField] Material blue;
        [SerializeField] Material pink;
        [SerializeField] Material yellow;
        [SerializeField] Material green;


        string currentAnimationTrigger;

        private void Start()
        {
            animator = GetComponent<Animator>();
            sprite = GetComponent<SpriteRenderer>();
        }

        public void MovePlayer()
        {
            float horizontalInput = Input.GetAxisRaw("Horizontal");
            float verticalInput = Input.GetAxisRaw("Vertical");

            

            if (Mathf.Abs(verticalInput) > 0 && Mathf.Abs(horizontalInput) > 0)
            {
                if (Mathf.Abs(verticalInput) > Mathf.Abs(horizontalInput))
                {
                    horizontalInput = 0;
                }
                else
                {
                    verticalInput = 0;
                }
                
                AnimateSprite(horizontalInput, verticalInput);

            }
            else
            {
                AnimateSprite(horizontalInput, verticalInput);

            }

            Vector3 newDestination = new Vector3(horizontalInput * movementSpeed * Time.deltaTime, verticalInput * movementSpeed * Time.deltaTime, 0);

            transform.position = transform.position + newDestination;
        }

        private void AnimateSprite(float horizontal, float vertical)
        {
            // handle animation triggers
            
            //animator.ResetTrigger("Idle");
            if (horizontal > 0)
            {
                Debug.Log("East sprite");
                animator.ResetTrigger(currentAnimationTrigger);
                animator.SetTrigger("East");
                    sprite.material = yellow;
                currentAnimationTrigger = "East";           
            }
            else if (horizontal < 0)
            {
                Debug.Log("West sprite");
                animator.ResetTrigger(currentAnimationTrigger);
                animator.SetTrigger("West");
                    sprite.material = green;
                currentAnimationTrigger = "West";
            }
            else if (vertical > 0)
            {
                Debug.Log("North sprite");
                animator.ResetTrigger(currentAnimationTrigger);
                animator.SetTrigger("North");
                    sprite.material = pink;
                currentAnimationTrigger = "North";
            }
            else if (vertical < 0)
            {
                Debug.Log("South sprite");
                animator.ResetTrigger(currentAnimationTrigger);
                animator.SetTrigger("South");
                    sprite.material = blue;
                currentAnimationTrigger = "South";
            }
            else
            {
                Debug.Log("idle sprite");
                animator.ResetTrigger(currentAnimationTrigger);
                animator.SetTrigger("Idle");
                    sprite.material = red;
                currentAnimationTrigger = "Idle";
                //animator.ResetTrigger("Idle");
            }
            //animator.ResetTrigger("Idle");

            
        }
    }
}



