using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MovingState-Ben", menuName = "PlayerStates/MovingState")]
public class PlayerMoving : PlayerState
{
    [SerializeField] private float speed = 1f;
    [SerializeField] private FMODEvents.NetworkSFXName footstepSfx;
    private StudioEventEmitter eventEmitter;

    public override void DoEnterLogic()
    {
        base.DoEnterLogic();
        core.animator.Play("PlayerWalk");
        eventEmitter = AudioManager.Instance?.InitializeEventEmitter(footstepSfx, core.gameObject);
        eventEmitter.Play();
    }
    public override void DoUpdateState()
    {
        base.DoUpdateState();

        rb.velocity = new Vector2(inputManager.MoveInput * speed, rb.velocity.y);


        if(inputManager.MoveInput > 0 && !core.isFacingRight) // Flip Right
        {
            core.FlipSprite();
        }
        else if(inputManager.MoveInput < 0 && core.isFacingRight) // Flip Left
        {
            core.FlipSprite();
        }
    }

    public override void CheckTransitions()
    {
        base.CheckTransitions();
        if (inputManager.MoveInput == 0)
        {
            core.stateMachine.ChangeState(core.states["Idle"]);
        }

    }

    public override void DoExitLogic()
    {
        base.DoExitLogic();
        eventEmitter.Stop();
    }
}
