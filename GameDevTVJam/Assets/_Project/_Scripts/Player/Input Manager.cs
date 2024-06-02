using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

// Custom input handler class to be able to have rebindable inputs
public class InputManager : Singleton<InputManager>
{
    // Move Input
    public float MoveInput { get; private set; }


    // Interact input
    public bool InteractPressedThisFrame { get; private set; }
    public bool InteractReleasedThisFrame { get; private set; }
    public bool InteractIsPressed { get; private set; }   
    
    // Interact input
    public bool AttackPressedThisFrame { get; private set; }
    public bool AttackReleasedThisFrame { get; private set; }
    public bool AttackIsPressed { get; private set; }   
    
    // Interact input
    public bool RollPressedThisFrame { get; private set; }
    public bool RollReleasedThisFrame { get; private set; }
    public bool RollIsPressed { get; private set; }



    public PlayerInput playerInput;
    private InputAction moveAction;
    private InputAction interactAction;
    private InputAction attackAction;
    private InputAction rollAction;
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
        interactAction = playerInput.actions["Interact"];
        attackAction = playerInput.actions["Attack"];
        rollAction = playerInput.actions["Roll"];
        nextDialogueAction = playerInput.actions["Next Dialogue"];
    }

    private void UpdateInputs()
    {
        // Move Input Variables
        MoveInput = moveAction.ReadValue<float>();

        // Interact Input Variables
        InteractPressedThisFrame = interactAction.WasPressedThisFrame();
        InteractIsPressed = interactAction.IsPressed();
        InteractReleasedThisFrame = interactAction.WasReleasedThisFrame();

        // Attack Action
        AttackPressedThisFrame = attackAction.WasPressedThisFrame();
        AttackIsPressed = attackAction.IsPressed();
        AttackReleasedThisFrame = attackAction.WasReleasedThisFrame();

        // Roll Action
        RollPressedThisFrame = rollAction.WasPressedThisFrame();
        RollIsPressed = rollAction.IsPressed();
        RollReleasedThisFrame = rollAction.WasReleasedThisFrame();

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

    public void EnablePlayerInput(bool _allowInput)
    {
        if(_allowInput)
            playerInput.currentActionMap.Enable();
        else
            playerInput.currentActionMap.Disable();

    }
}
