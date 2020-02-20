using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.Interactables
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(CircleCollider2D))]
    public class Interactable : MonoBehaviour
    {
        
        float colliderRadius = .25f;

        private void Awake()
        {
            ConfigureRigidBodyAndCollider();
        }

        private void ConfigureRigidBodyAndCollider()
        {
            gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
            gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            gameObject.GetComponent<CircleCollider2D>().isTrigger = true;
            gameObject.GetComponent<CircleCollider2D>().radius = colliderRadius;
        }
        public void FadeOut()
        {
            gameObject.GetComponent<Animator>().SetTrigger("fadeOut");

        }
    }
}
