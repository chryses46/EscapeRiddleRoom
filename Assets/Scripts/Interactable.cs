using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//namespace Core
//{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(CircleCollider2D))]
    public class Interactable : MonoBehaviour
    {

        private void Start()
        { 

        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
           // Highlight object
           //object becomes interactable
        }
        private void OnTriggerExit2D(Collider2D collision)
        {

        }
        void Update()
        {

        }
    }
//}
