using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Core.UI
{
    public class CrosswordChar : MonoBehaviour
    {
        [SerializeField] GameObject finger;

        public GameObject GetFinger()
        {
            return finger;
        }


    }
}

