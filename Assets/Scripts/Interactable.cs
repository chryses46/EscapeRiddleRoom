using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.Interactables
{
    [RequireComponent(typeof(CircleCollider2D))]
    public class Interactable : MonoBehaviour
    {
        private void Awake()
        {
            ConfigureRigidBodyAndCollider();
        }

        private void ConfigureRigidBodyAndCollider()
        {
            gameObject.GetComponent<CircleCollider2D>().isTrigger = true;
        }
    }
}
