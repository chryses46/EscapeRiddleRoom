using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace Core.UI
{
    public class RowCol : MonoBehaviour
    {
        [Header("0=x , 1=y")]
        [SerializeField] int movementDirection;

        [SerializeField] CrosswordChar[] charSlots;

        [SerializeField] RowCol[] linkedRowCols;

        [SerializeField] int[] charCrossingIndexies;

        int selectedCharacterSlotIndex;

        CrosswordChar currentHoverCharacter;

        /// <summary>
        /// This is for setting the actual text character in the slot.
        /// </summary>
        public void SetCharacterSlot()
        {

        }

        public void SetCurrentHoverCharacter(int currentIndex)
        {
            currentHoverCharacter = charSlots[currentIndex];
            currentHoverCharacter.GetFinger().SetActive(true);

        }

        public int GetMovementDirection()
        {
            return 0;
        }

        public int GetNumCharSlots()
        {
            return charSlots.Length;
        }

        public RowCol[] GetLinkedRowCol()
        {
            return linkedRowCols;
        }

        public bool IsOnCrossingIndex()
        {
            return false;
        }
    }
}

