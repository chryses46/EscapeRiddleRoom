using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.Interactables;
using System;

namespace Core
{
    public class Player : MonoBehaviour
    {
        Animator animator;
        SpriteRenderer sprite;

        [SerializeField] float movementSpeed;
        [SerializeField] Sprite northIdle;
        [SerializeField] Sprite southIdle;
        [SerializeField] Sprite eastIdle;
        [SerializeField] Sprite westIdle;

        string currentAnimationTrigger;



        Interactable interactable;
        PuzzleZone puzzle;
        RiddleZone riddle;
        Door door;
        BookShelfZone bookShelf;

        private void Start()
        {
            animator = GetComponent<Animator>();
            sprite = GetComponent<SpriteRenderer>();

            SetIdleSprite();
        }

        enum Direction {North, South, East, West };

        Direction currentDirection = Direction.North;

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
            else if (bookShelf)
            {
                bookShelf.Interact();
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
                currentDirection = Direction.East;
            }
            else if (horizontal < 0)
            {
                //Debug.Log("West sprite");

                animator.SetTrigger("West");

                currentAnimationTrigger = "West";
                currentDirection = Direction.West;
            }
            else if (vertical > 0)
            {
               //Debug.Log("North sprite");

                animator.SetTrigger("North");

                currentAnimationTrigger = "North";
                currentDirection = Direction.North;
            }
            else if (vertical < 0)
            {
                //Debug.Log("South sprite");

                animator.SetTrigger("South");

                currentAnimationTrigger = "South";
                currentDirection = Direction.South;
            }
            else
            {
                //Debug.Log("idle sprite");

                animator.SetTrigger("Idle");

                currentAnimationTrigger = "Idle";

                SetIdleSprite();
            }
        }

        private void SetIdleSprite()
        {
            switch (currentDirection)
            {
                case Direction.North:
                    sprite.sprite = northIdle;
                    break;
                case Direction.South:
                    sprite.sprite = southIdle;
                    break;
                case Direction.East:
                    sprite.sprite = eastIdle;
                    break;
                case Direction.West:
                    sprite.sprite = westIdle;
                    break;
                default:
                    break;
            }
        }

        public void SetInteractable(PuzzleZone puzzleObject = null, RiddleZone riddleObject = null, Door doorObject = null, BookShelfZone bookshelfObject = null)
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
            else if (bookshelfObject != null)
            {
                bookShelf = bookshelfObject;
            }
        }

        public void ClearInteractable()
        {
            puzzle = null;
            riddle = null;
            door = null;
            bookShelf = null;
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



