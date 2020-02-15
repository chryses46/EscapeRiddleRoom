using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace Core
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(CircleCollider2D))]
    public class DialogSystem : MonoBehaviour
    {
        [SerializeField] GameObject dialogBox;

        [SerializeField] Text namePlate;

        [SerializeField] Text dialogDisplay;

        private readonly string mysteryName = "???";

        private readonly string badGuyName = "Charles Ravenburger";

        private string playerName;

        private int currentLineOfDialog = 0;
        private string[] dialogMessages = {
            "Welcome! I see you have finally awoken. Do not worry about your friend."+
                " They are dead. What you should be concerned about is your own well-being.",
            "As you can see, your time here is limited. I’ll be quick."+
                " You will want to get out of this house as soon as possible."+
                " The catch is there are a number of quite clever - if I do say so myself - puzzles that you will need to solve."+
                " Though these are no ordinary puzzles! If you wish to solve these puzzles, I highly recommend you seek their accompanying riddles.",
            "The riddles will be quite useful, if not paramount, to your success here."+
                " And do not fret, I will not count off time as you analyze the riddles."+
                " Puzzles, on the other hand, I suggest you solve with haste. That is it.",
            "Oh! My name is Charles Ravensburger.",
            "A pleasure to meet you. Now go. And do not forget. Above all else: Have fun. Toodles!"
        };

        // Manages the dialog at the start of the game.
        // There is no other dialog, so this should be fine for what we need.
        public void InitiateDialog()
        {
            dialogBox.SetActive(true);

            dialogBox.GetComponent<Animator>().SetTrigger("popUpBoxFadeIn"); // will call FadeInNamePlate when animation completes

            namePlate.text = mysteryName;
        }

        private void UpdateDialogDisplay()
        {
            switch (currentLineOfDialog)
            {
                case 3:
                    dialogDisplay.text = dialogMessages[currentLineOfDialog];
                    dialogDisplay.gameObject.GetComponent<Animator>().SetTrigger("dialogFadeIn");
                    break;
                case 4:
                    namePlate.text = badGuyName;
                    dialogDisplay.text = dialogMessages[currentLineOfDialog];
                    dialogDisplay.gameObject.GetComponent<Animator>().SetTrigger("dialogFadeIn");
                    break;
                default:
                    dialogDisplay.text = dialogMessages[currentLineOfDialog];
                    dialogDisplay.gameObject.GetComponent<Animator>().SetTrigger("dialogFadeIn");
                    break;
            }
        }

        public void FadeInNamePlate()
        {
            namePlate.gameObject.GetComponent<Animator>().SetTrigger("dialogFadeIn");
            if(currentLineOfDialog == 0)
            {
                UpdateDialogDisplay();
            }
        }

        public void UserAdvanceDialog()
        {
            if (currentLineOfDialog >= 0)
                dialogDisplay.gameObject.GetComponent<Animator>().SetTrigger("dialogFadeOut");
            CallNextDialogMessage();
        }

        private void CallNextDialogMessage()
        {
            currentLineOfDialog++;
            UpdateDialogDisplay();
        }

        public void SkipDialog()
        {
            // end dialog and go to next step
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            
        }
    }
}

public class Interactable : MonoBehaviour
{
    //stuff
}

public class Puzzle : Interactable
{

}

public class Riddle : Interactable
{

}