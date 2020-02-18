using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.Interactables
{
    public class Room : MonoBehaviour
    {
        [SerializeField] Sprite roomImage;
        [SerializeField] GameObject riddle;
        [SerializeField] GameObject puzzle;

        private void Start()
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = roomImage;
        }


    }
}

