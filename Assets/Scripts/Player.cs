using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Core
{
    public class Player : MonoBehaviour
    {
        public static Player instance;

        public float movementSpeed;


        private void Awake()
        {
            instance = this;
        }

        public void MovePlayer()
        {
            float horizontalInput = Input.GetAxisRaw("Horizontal");
            float verticalInput = Input.GetAxisRaw("Vertical");

            if (Mathf.Abs(verticalInput) > 0 && Mathf.Abs(horizontalInput) > 0)
            {
                if (Mathf.Abs(verticalInput) > Mathf.Abs(horizontalInput))
                {
                    Debug.Log("taking vertical action");
                    horizontalInput = 0;
                }
                else
                {
                    Debug.Log("taking horizontal action");
                    verticalInput = 0;
                }
            }

            Vector3 newDestination = new Vector3(horizontalInput * movementSpeed * Time.deltaTime, verticalInput * movementSpeed * Time.deltaTime, 0);

            transform.position = transform.position + newDestination;
        }
    }
}



