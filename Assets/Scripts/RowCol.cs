using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace Core.UI
{
    public class RowCol : MonoBehaviour
    {
        [Header("x=1 , y=2")]
        [SerializeField] int movementDirection;

        [SerializeField] CrosswordChar[] charSlots;

        int selectedCharacterSlotIndex;

        CrosswordChar currentHoverCharacter;

        int currentHoverIndex;

        CrosswordPuzzle crosswordPuzzle;

        private void OnEnable()
        {
            crosswordPuzzle = FindObjectOfType<CrosswordPuzzle>();

            currentHoverIndex = 0;

            currentHoverCharacter = charSlots[currentHoverIndex];
        }

        /// <summary>
        /// This is for setting the actual text character in the slot.
        /// </summary>
        public void SetCharacterSlot()
        {

        }

        public void SetCurrentHoverCharacter(int currentIndex)
        {
            if(currentHoverCharacter)
            {
                if(currentHoverCharacter.GetFinger().activeSelf)
                    currentHoverCharacter.ToggleFinger(false);
            }

            currentHoverIndex = currentIndex;

            crosswordPuzzle.SetControlRowColCurrentHoverIndex(currentIndex);

            currentHoverCharacter = charSlots[currentHoverIndex];

            currentHoverCharacter.ToggleFinger(true);
        }

        public int GetCurrentHoverIndex()
        {
            return currentHoverIndex;
        }

        public int GetMovementDirection()
        {
            return movementDirection;
        }

        public int GetNumCharSlots()
        {
            return charSlots.Length;
        }

        public CrosswordChar[] GetCrosswordChars()
        {
            return charSlots;
        }

        public CrosswordChar GetCurrentHoverCharacter()
        {
            return currentHoverCharacter;
        }
    }
}

