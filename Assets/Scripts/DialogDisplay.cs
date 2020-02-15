using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Core.UI
{
    public class DialogDisplay : MonoBehaviour
    {
        DialogSystem dialogSystem;

        void Awake()
        {
            dialogSystem = FindObjectOfType<DialogSystem>();

        }

        public void CallNextDialogMessageMethod()
        {
            dialogSystem.CallNextDialogMessage();
        }
    }
}

