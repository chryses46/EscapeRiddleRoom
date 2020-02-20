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

        UIManager uiManager;
        DialogSystem dialogSystem;

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

        public void ExitPuzzle(bool puzzleWasSolved = false)
        {
            if (puzzleWasSolved) currentPuzzleZone.SetLinkedPuzzleSolved();

            currentPuzzleUI.SetActive(false);
            currentPuzzleUI = null;
            gameBoard.ToggleCurrentRoom(true);
            player.gameObject.SetActive(true);
            StateMachineController.instance.gameState = StateMachineController.State.Play;
        }

        public void TransitionRooms(Interactables.Room targetRoom, Interactables.Door targetDoor)
        {
            player.FadePlayerOut();
            gameBoard.MoveRooms(targetRoom);
            player.TeleportPlayer(targetDoor.GetPlayerPortZonePosition());
            //consider facing direction sprite for player
            player.FadePlayerIn();
        }
    }
}

