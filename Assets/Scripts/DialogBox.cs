using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.UI
{
    public class DialogBox : MonoBehaviour
    {
        DialogSystem dialogSystem;

        void Awake()
        {
            dialogSystem = FindObjectOfType<DialogSystem>();

        }

        public void CallFadeInNamePlateMethod()
        {
            dialogSystem.FadeInNamePlate();
        }

        public void CallDisableDialogBoxMethod()
        {
            dialogSystem.DisableDialogBox();
            
        }
    }
}


