using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace Core
{
    public class DialogSystem : MonoBehaviour
    {
        [SerializeField] GameObject dialogBox;

        [SerializeField] Text namePlate;

        [SerializeField] Text dialogDisplay;

        private readonly string mysteryName = "???";

        private readonly string badGuyName = "Charles Ravenburger";

        private string playerName;

        private int currentLineOfDialog = 0;

        string currentAnimationTrigger;

        bool exitingDialog;

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

            dialogBox.GetComponent<Animator>().SetTrigger("dialogBoxFadeIn"); // will call FadeInNamePlate when animation completes

            namePlate.text = mysteryName;
        }

        private void UpdateDialogDisplay()
        {
            if(currentAnimationTrigger != "dialogFadeIn") dialogDisplay.gameObject.GetComponent<Animator>().ResetTrigger(currentAnimationTrigger);

            switch (currentLineOfDialog)
            {
                case 1:
                    dialogDisplay.text = dialogMessages[currentLineOfDialog];
                    dialogDisplay.gameObject.GetComponent<Animator>().SetTrigger("dialogFadeIn");
                    gameObject.GetComponent<UIManager>().ToggleTimer(true);
                    break;
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
            currentAnimationTrigger = "dialogFadeIn";
            currentLineOfDialog++;
        }

        public void FadeInNamePlate()
        {
            namePlate.gameObject.GetComponent<Animator>().SetTrigger("dialogFadeIn");
            currentAnimationTrigger = "dialogFadeIn";
            if (currentLineOfDialog == 0)
            {
                UpdateDialogDisplay();
            }
        }

        public void UserAdvanceDialog()
        {
            if (exitingDialog) return;

            dialogDisplay.gameObject.GetComponent<Animator>().ResetTrigger(currentAnimationTrigger);

            dialogDisplay.gameObject.GetComponent<Animator>().SetTrigger("dialogFadeOut");

            currentAnimationTrigger = "dialogFadeOut";

        }

        public void CallNextDialogMessage()
        {
            if (exitingDialog) return;

            if (currentLineOfDialog > 0 && currentLineOfDialog < dialogMessages.Length)
            {
                UpdateDialogDisplay();
            }
            else
            {
                ExitDialogState();
            }
        }

        public void SkipDialog()
        {
            ExitDialogState();
        }

        public void ExitDialogState()
        {
            exitingDialog = true;
            namePlate.gameObject.GetComponent<Animator>().SetTrigger("dialogFadeOut");
            dialogBox.GetComponent<Animator>().SetTrigger("dialogBoxFadeOut");
        }

        public void DisableDialogBox()
        {
            dialogBox.SetActive(false);
            GameManager.instance.EnterPlayMode();
        }
    }
}