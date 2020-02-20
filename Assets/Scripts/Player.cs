using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.Interactables;

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
        Interactable interactable;
        PuzzleZone puzzle;
        RiddleZone riddle;
        Door door;

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

        public void Interact()
        {
            if(puzzle)
            {
                puzzle.Interact();
            }
            else if(riddle)
            {
                riddle.Interact();
            }
            else if(door)
            {
                door.Interact();
            }
        }

        private void AnimateSprite(float horizontal, float vertical)
        {
            // handle animation triggers
            
            //animator.ResetTrigger("Idle");
            if(currentAnimationTrigger != null) animator.ResetTrigger(currentAnimationTrigger);

            if (horizontal > 0)
            {
                //Debug.Log("East sprite");

                animator.SetTrigger("East");

                currentAnimationTrigger = "East";           
            }
            else if (horizontal < 0)
            {
                //Debug.Log("West sprite");

                animator.SetTrigger("West");

                currentAnimationTrigger = "West";
            }
            else if (vertical > 0)
            {
               //Debug.Log("North sprite");

                animator.SetTrigger("North");

                currentAnimationTrigger = "North";
            }
            else if (vertical < 0)
            {
                //Debug.Log("South sprite");

                animator.SetTrigger("South");

                currentAnimationTrigger = "South";
            }
            else
            {
                //Debug.Log("idle sprite");

                animator.SetTrigger("Idle");

                currentAnimationTrigger = "Idle";
            }
        }

        public void SetInteractable(PuzzleZone puzzleObject = null, RiddleZone riddleObject = null, Door doorObject = null)
        {
            if(puzzleObject != null)
            {
                puzzle = puzzleObject;
            }
            else if(riddleObject != null)
            {
                riddle = riddleObject;
            }
            else if(doorObject != null)
            {
                door = doorObject;
            }
        }

        public void ClearInteractable()
        {
            puzzle = null;
            riddle = null;
            door = null;
        }

        public void FadePlayerOut()
        {
            // animator.ResetTrigger(currentAnimationTrigger);
            // animator.SetTrigger("FadeOut");
            // currentAnimationTrigger = "FadeOut";
        }

        public void FadePlayerIn()
        {
            // animator.ResetTrigger(currentAnimationTrigger);
            // animator.SetTrigger("FadeIn");
            // currentAnimationTrigger = "FadeIn";
        }

        public void TeleportPlayer(Vector3 targetPosition)
        {
            gameObject.transform.position = targetPosition;
        }
    }
}



