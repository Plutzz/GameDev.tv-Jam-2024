using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

// Custom input handler class to be able to have rebindable inputs
public class InputManager : Singleton<InputManager>
{
    // Move Input
    public float MoveInput { get; private set; }


    //// Interact input
    //public bool InteractPressedThisFrame { get; private set; }
    //public bool InteractReleasedThisFrame { get; private set; }
    //public bool InteractIsPressed { get; private set; }

    //// Pause Input
    //public bool PausePressedThisFrame { get; private set; }
    //public bool PauseReleasedThisFrame { get; private set; }
    //public bool PauseIsPressed { get; private set; }

   


    public PlayerInput playerInput;
    private InputAction moveAction;
    //private InputAction interactAction;
    //private InputAction jumpAction;
    //private InputAction sprintAction;
    //private InputAction crouchAction;
    //private InputAction nextInventoryAction;
    //private InputAction previousInventoryAction;
    //private InputAction pauseAction;

    // DIALOGUE ACTION MAP

    // Next Dialogue
    public bool NextDialoguePressedThisFrame { get; private set; }
    public bool NextDialogueReleasedThisFrame { get; private set; }
    public bool NextDialogueIsPressed { get; private set; }


    private InputAction nextDialogueAction;

    private void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        SetupInputActions();
    }

    private void Update()
    {
        UpdateInputs();
    }

    private void SetupInputActions()
    {
        moveAction = playerInput.actions["Move"];
        //interactAction = playerInput.actions["Interact"];
        //pauseAction = playerInput.actions["Pause"];
        nextDialogueAction = playerInput.actions["Next Dialogue"];
    }

    private void UpdateInputs()
    {
        // Move Input Variables
        MoveInput = moveAction.ReadValue<float>();

        //// Interact Input Variables
        //InteractPressedThisFrame = interactAction.WasPressedThisFrame();
        //InteractIsPressed = interactAction.IsPressed();
        //InteractReleasedThisFrame = interactAction.WasReleasedThisFrame();

        //// Pause Action
        //PausePressedThisFrame = pauseAction.WasPressedThisFrame();
        //PauseIsPressed = pauseAction.IsPressed();
        //PauseReleasedThisFrame = pauseAction.WasReleasedThisFrame();

        // DIALOGUE ACTION MAP

       NextDialoguePressedThisFrame = nextDialogueAction.WasPressedThisFrame();
       NextDialogueIsPressed = nextDialogueAction.IsPressed();
       NextDialogueReleasedThisFrame = nextDialogueAction.WasReleasedThisFrame();
    }

    public void SwitchActionMap(string actionMapName)
    {
        playerInput.SwitchCurrentActionMap(actionMapName);
        SetupInputActions();
    }
}
