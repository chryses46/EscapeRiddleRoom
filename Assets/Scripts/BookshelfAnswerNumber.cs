using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Core.Interactables
{
    public class BookshelfAnswerNumber : MonoBehaviour
    {
        [SerializeField] int answerNumber;

        private void Start()
        {
            if(!GameManager.instance.IsBookshelfNumbersFilled())
            {
                SetUpAnswer();
            }
            else
            {
                gameObject.GetComponent<Text>().text = GameManager.instance.GetKeyPadAnswer(answerNumber);
            }
                
        }

        private void SetUpAnswer()
        {
            int randomNumber = UnityEngine.Random.Range(0,9);

            string answerAsString = randomNumber.ToString();

            gameObject.GetComponent<Text>().text = answerAsString;

            GameManager.instance.SetKeypadAnswer(answerNumber, answerAsString);
        }
    }
}

