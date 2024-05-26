using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

// Custom input handler class to be able to have rebindable inputs
public class InputManager : MonoBehaviour
{
    // Move Input
    public float MoveInput { get; private set; }


    //// Interact input
    //public bool InteractPressedThisFrame { get; private set; }
    //public bool InteractReleasedThisFrame { get; private set; }
    //public bool InteractIsPressed { get; private set; }

    //// Jump Input
    //public bool JumpPressedThisFrame { get; private set; }
    //public bool JumpReleasedThisFrame { get; private set; }
    //public bool JumpIsPressed { get; private set; }

    //// Sprint Input
    //public bool SprintPressedThisFrame { get; private set; }
    //public bool SprintReleasedThisFrame { get; private set; }
    //public bool SprintIsPressed { get; private set; }

    //// Crouch Input
    //public bool CrouchPressedThisFrame { get; private set; }
    //public bool CrouchReleasedThisFrame { get; private set; }
    //public bool CrouchIsPressed { get; private set; }

    //// Inventory Slot Inputs
    //public bool NextInventoryPressedThisFrame { get; private set; }
    //public bool NextInventoryReleasedThisFrame { get; private set; }
    //public bool NextInventoryIsPressed { get; private set; }
    //public bool PreviousInventoryPressedThisFrame { get; private set; }
    //public bool PreviousInventoryReleasedThisFrame { get; private set; }
    //public bool PreviousInventoryIsPressed { get; private set; }

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
        //lookAction = playerInput.actions["Look"];
        //jumpAction = playerInput.actions["Jump"];
        //sprintAction = playerInput.actions["Sprint"];
        //crouchAction = playerInput.actions["Crouch"];
        //interactAction = playerInput.actions["Interact"];
        //nextInventoryAction = playerInput.actions["Next Inventory Slot"];
        //previousInventoryAction = playerInput.actions["Previous Inventory Slot"];
        //pauseAction = playerInput.actions["Pause"];
    }

    private void UpdateInputs()
    {
        // Move Input Variables
        MoveInput = moveAction.ReadValue<float>();

        //// Interact Input Variables
        //InteractPressedThisFrame = interactAction.WasPressedThisFrame();
        //InteractIsPressed = interactAction.IsPressed();
        //InteractReleasedThisFrame = interactAction.WasReleasedThisFrame();

        //// Jump Input Variables
        //JumpPressedThisFrame = jumpAction.WasPressedThisFrame();
        //JumpIsPressed = jumpAction.IsPressed();
        //JumpReleasedThisFrame = jumpAction.WasReleasedThisFrame();

        //// Sprint Input Variables
        //SprintPressedThisFrame = sprintAction.WasPressedThisFrame();
        //SprintIsPressed = sprintAction.IsPressed();
        //SprintReleasedThisFrame = sprintAction.WasReleasedThisFrame();

        //// Crouch Input Variables
        //CrouchPressedThisFrame = crouchAction.WasPressedThisFrame();
        //CrouchIsPressed = crouchAction.IsPressed();
        //CrouchReleasedThisFrame = crouchAction.WasReleasedThisFrame();

        //// Next Inventory Action
        //NextInventoryPressedThisFrame = nextInventoryAction.WasPressedThisFrame();
        //NextInventoryIsPressed = nextInventoryAction.IsPressed();
        //NextInventoryReleasedThisFrame = nextInventoryAction.WasReleasedThisFrame();

        //// Previous Inventory Action
        //PreviousInventoryPressedThisFrame = previousInventoryAction.WasPressedThisFrame();
        //PreviousInventoryIsPressed = previousInventoryAction.IsPressed();
        //PreviousInventoryReleasedThisFrame = previousInventoryAction.WasReleasedThisFrame();

        //// Pause Action
        //PausePressedThisFrame = pauseAction.WasPressedThisFrame();
        //PauseIsPressed = pauseAction.IsPressed();
        //PauseReleasedThisFrame = pauseAction.WasReleasedThisFrame();
    }

    public void SwitchActionMap(string actionMapName)
    {
        playerInput.SwitchCurrentActionMap(actionMapName);
        SetupInputActions();
    }
}
