using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace Core.UI
{
    public class RiddleInventoryImage : MonoBehaviour
    {
        Image riddleImage;

        private void Start()
        {
            riddleImage = gameObject.GetComponent<Image>();
        }

        public void SetRiddleImage()
        {

        }

    }
}


