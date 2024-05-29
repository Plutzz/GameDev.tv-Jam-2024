using AYellowpaper.SerializedCollections;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StateMachineCore : MonoBehaviour
{
    /// <summary>
    /// Dictonary used to hold states that are NOT a part of a heirarchical state machine.
    /// </summary>
    [SerializedDictionary("State Type", "Scriptable Object")]
    [Tooltip("Holds references to CORE states (states accessable from the root of the state machine heirarchy")]
    [field: SerializeField] public SerializedDictionary<string, State> states { get; private set; }
    public Rigidbody2D rb;
    public Animator animator;
    [Tooltip("Check this box if sprite is initially facing right")]
    [field:SerializeField] public bool isFacingRight { get; private set; }
    public StateMachine stateMachine { get; private set; }

    /// <summary>
    /// Passes the core to all the states in the states dictionary
    /// </summary>
    public void SetupInstances()
    {
        stateMachine = new StateMachine();

        foreach (State _state in states.Values)
        {
            _state.SetCore(this);
        }
    }

    private void Update()
    {
        stateMachine.currentState.DoUpdateBranch();
    }

    private void FixedUpdate()
    {
        stateMachine.currentState.DoFixedUpdateBranch();
    }

    /// <summary>
    /// Flips the direction of the sprite.
    /// </summary>
    /// <param name="direction"></param>
    public void FlipSprite()
    {
        if(transform.eulerAngles.y == 180)   // Facing right
        {
            transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x, 0, transform.rotation.z));
        }
        else
        {
            transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x, 180, transform.rotation.z));
        }

        isFacingRight = !isFacingRight;

    }
}
