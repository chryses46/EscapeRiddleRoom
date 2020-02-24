using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Core.UI
{
    public class JournalRiddleCounter : MonoBehaviour
    {
        // For logic, 0=1, 1=2, and so on
        private int currentNumRiddlesFound = -1;

        Text riddleCounterText;

        private void Start()
        {
            riddleCounterText = gameObject.GetComponent<Text>();
        }

        public void SetNumRiddlesFound(int num)
        {
            currentNumRiddlesFound = num;

            gameObject.GetComponent<Text>().text = currentNumRiddlesFound + "/4";
        }
    }
}
