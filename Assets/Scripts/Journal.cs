using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    public class Journal : MonoBehaviour
    {
        [SerializeField] GameObject journalGameObject;


        [SerializeField] Core.UI.JournalRiddleCounter journalRiddleCounter;

        [SerializeField] Core.UI.JournalRiddleImage[] journalRiddleImages;

        private bool[] riddlesActive =
        {
            false, // 0 for foyer
            false, // 1 for den
            false, // 2 for dining
            false, // 3 for kitchen
            false  // 4 for escape
        };

        private int numRiddlesFound = 0;

        public void IterateNumRiddlesFound(int index)
        {
            numRiddlesFound++;

            SetRiddleIndexActive(index);
        }

        public void EnableJournal()
        {
            StateMachineController.instance.gameState = StateMachineController.State.Pause;
            // should also pause timer
            journalGameObject.SetActive(true);
            journalRiddleCounter.SetNumRiddlesFound(numRiddlesFound);
            SetRiddleImages();
        }

        private void SetRiddleImages()
        {
            for (int i = 0; i < journalRiddleImages.Length; i++)
            {
                journalRiddleImages[i].SetRiddleImageActive(riddlesActive[i]);
            }
        }

        public void DisableJournal()
        {
            journalGameObject.SetActive(false);
            StateMachineController.instance.gameState = StateMachineController.State.Play;
        }

        public void SetRiddleIndexActive(int index)
        {
            riddlesActive[index] = true;
        }

        public bool[] GetActiveRiddles()
        {
            return riddlesActive;
        }
    }
}

