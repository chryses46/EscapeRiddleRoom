using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Core.UI
{
    public class CrosswordChar : MonoBehaviour
    {
        [SerializeField] GameObject finger;

        [SerializeField] RowCol linkedRowCol;

        [SerializeField] bool isCrossingIndexChar;

        [SerializeField] CrosswordChar linkedCrosswordChar;

        public GameObject GetFinger()
        {
            return finger;
        }

        public void ToggleFinger(bool isActive)
        {
            finger.SetActive(isActive);
        }

        public bool IsCrossingIndexChar()
        {
            return isCrossingIndexChar;
        }

        public RowCol GetLinkedRowCol()
        {
            return linkedRowCol;
        }

        public RowCol GetParentRowCol()
        {
            return GetComponentInParent<RowCol>();
        }

        public CrosswordChar GetLinkedCrosswordChar()
        {
            return linkedCrosswordChar;
        }
    }
}

