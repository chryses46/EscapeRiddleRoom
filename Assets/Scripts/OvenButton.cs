using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace Core.Interactables
{
    public class OvenButton : MonoBehaviour
    {
        RectTransform rectTransform;

        [SerializeField] OvenButton[] connectedButtons;

        private void Start()
        {
            rectTransform = gameObject.GetComponent<RectTransform>();
        }

        public void FlipButton(bool isExternalCall)
        {
            float currentButtonDegreeofRotation = rectTransform.eulerAngles.z;

            if (currentButtonDegreeofRotation >= 180)
            {
                Vector3 currentRotation = rectTransform.eulerAngles;
                currentRotation.z = 0;
                rectTransform.eulerAngles = currentRotation;

            }
            else if(currentButtonDegreeofRotation <= 180)
            {
                Vector3 currentRotation = rectTransform.eulerAngles;
                currentRotation.z = 180;
                rectTransform.eulerAngles = currentRotation;
            }

            if(!isExternalCall) // meaning not being called by aonther button
            {
                foreach (var button in connectedButtons)
                {
                    button.FlipButton(true);
                }
            }
        }

        public bool IsSwitchUp()
        {
            if(rectTransform.eulerAngles.z < 1 && rectTransform.eulerAngles.z >= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
