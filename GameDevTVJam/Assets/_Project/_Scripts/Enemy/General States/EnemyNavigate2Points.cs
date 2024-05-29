using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[CreateAssetMenu(menuName = "Enemy States/General States/Navigate To Point")]
public class EnemyNavigateToPoint : EnemyState
{
    [SerializeField] private float walkSpeed = 10f;
    [HideInInspector] public NavigateSensor navigate;

    public override void DoEnterLogic()
    {
        base.DoEnterLogic();
        navigate = enemy.GetComponent<NavigateSensor>();
        MoveToPoint(navigate.points[navigate.currentPoint]);
        core.CheckSpriteDirection();

        // Animation clip
        if (animator != null && stateAnimation != null)
            animator.Play(stateAnimation.name);
    }


    public void MoveToPoint(Transform point)
    {
        float direction = point.transform.position.x - enemy.transform.position.x;
        rb.velocity = Vector3.right * walkSpeed * Mathf.Sign(direction);
    }

    public override void DoUpdateState()
    {
        base.DoUpdateState();

        if(navigate.IsAtPoint())
        {
            parent.stateMachine.ChangeState(parent.states["Idle"]);
        }
    }

    public override void DoExitLogic()
    {
        base.DoExitLogic(); 
        navigate.currentPoint = (navigate.currentPoint + 1) % navigate.points.Length;
    }


}
