using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XInputDotNetPure;

namespace Core
{
    public class GameManager : MonoBehaviour {

        public static GameManager instance;

        // Controller detection variables
        public bool playerIndexSet = false;

        PlayerIndex playerIndex;

        GamePadState state;

        GamePadState prevState;

        [SerializeField] Player player;

        [SerializeField] Interactables.GameBoardHandler gameBoard;

        [SerializeField] Interactables.Room foyer;

        [SerializeField] Interactables.Room currentDevelopmentRoom;

        private GameObject currentPuzzleUI; // passed from PuzzleZone

        private Interactables.PuzzleZone currentPuzzleZone;

        private string keypadAnswer1 = "", keypadAnswer2 = "";

        bool bookShelfNumbersGiven;

        UIManager uiManager;

        DialogSystem dialogSystem;

        AudioController audioController;

        void Awake ()
        {
            instance = this;
        }

        private void Start()
        {
            CheckForControllers();
            gameBoard = gameBoard.gameObject.GetComponent<Core.Interactables.GameBoardHandler>();
            dialogSystem = gameObject.GetComponent<DialogSystem>();
            uiManager = gameObject.GetComponent<UIManager>();
            audioController = gameObject.GetComponent<AudioController>();
            
            // DISABLE BEFORE SHIP
            gameBoard.SetCurrentRoom(currentDevelopmentRoom);
            gameBoard.ToggleCurrentRoom(true);
        }

        void Update ()
        {
            CheckForControllers();
        }

        // checks whether or not a controller is connected to the computer
        private void CheckForControllers()
        {
            // Find a PlayerIndex, for a single player game
            // Will find the first controller that is connected ans use it
            if (!playerIndexSet || !prevState.IsConnected)
            {
                for (int i = 0; i < 4; ++i)
                {
                    PlayerIndex testPlayerIndex = (PlayerIndex)i;
                    GamePadState testState = GamePad.GetState(testPlayerIndex);
                    if (testState.IsConnected)
                    {
                        playerIndex = testPlayerIndex;
                        playerIndexSet = true;
                    }
                }
            }

            prevState = state;
            state = GamePad.GetState(playerIndex);
        }

        public void StartGame()
        {
            uiManager.ToggleMainMenuUI(false);
            uiManager.TogglePlayUI(true);
            player.gameObject.SetActive(true);
            gameBoard.SetCurrentRoom(foyer);
            gameBoard.gameObject.SetActive(true);
            gameBoard.ToggleCurrentRoom(true);
            audioController.PlayDialogMusic();
            StateMachineController.instance.gameState = StateMachineController.State.Dialog;
            dialogSystem.InitiateDialog();
        }

        public void EnterPlayMode()
        {
            StateMachineController.instance.gameState = StateMachineController.State.Play;
            gameObject.GetComponent<AudioController>().PlayGameMusic();
            uiManager.StartTimer();
            gameBoard.SetCurrentRoom(foyer);
        }
        public void EnterPuzzle(GameObject currentPuzzleUIObject, Interactables.PuzzleZone messagingPuzzleZone)
        {
            currentPuzzleZone = messagingPuzzleZone;
            currentPuzzleUI = currentPuzzleUIObject;
            gameBoard.ToggleCurrentRoom(false);
            player.gameObject.SetActive(false);
            currentPuzzleUI.SetActive(true);
            StateMachineController.instance.gameState = StateMachineController.State.Puzzle;
        }

        public void ExitPuzzle(bool puzzleWasSolved = false, bool finalPuzzle = false)
        {
            if (puzzleWasSolved)
            {
                currentPuzzleZone.SetLinkedPuzzleSolved();

                audioController.DoorUnlocking();
            }

            if (finalPuzzle) uiManager.EnableRiddlePopUp(null, true);


            currentPuzzleUI.SetActive(false);
            currentPuzzleUI = null;
            gameBoard.ToggleCurrentRoom(true);
            player.gameObject.SetActive(true);
            StateMachineController.instance.gameState = StateMachineController.State.Play;
        }

        public void TransitionRooms(Interactables.Room targetRoom, Interactables.Door targetDoor)
        {
            gameObject.GetComponent<AudioController>().DoorOpenig();
            player.FadePlayerOut();
            gameBoard.MoveRooms(targetRoom);
            player.TeleportPlayer(targetDoor.GetPlayerPortZonePosition());
            //consider facing direction sprite for player
            player.FadePlayerIn();
        }

        public void SetKeypadAnswer(int keypadNum, string keypadAnswer)
        {
            switch (keypadNum)
            {
                case 1:
                    keypadAnswer1 = keypadAnswer;
                    break;
                case 2:
                    keypadAnswer2 = keypadAnswer;
                    break;

            }

        }

        public string GetKeyPadAnswer(int requestdAnswer)
        {
            if(requestdAnswer == 1)
            {
                return keypadAnswer1;
            }
            else if(requestdAnswer == 2)
            {
                return keypadAnswer2;
            }

            return null;
        }

        public bool IsBookshelfNumbersFilled()
        {
            if (keypadAnswer1 != "" && keypadAnswer2 != "")
            {
                return true;
            }

            return false;  
        }
    }
}

