using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy States/Maenstrosity/Attacks/Tendril")]
public class MaenstrosityTendril : EnemyState
{
    [SerializeField] private float windupTime;

    [SerializeField] private GameObject tendrilPrefab;
    [SerializeField] private GameObject tendrilIndicatorPrefab;
    [SerializeField] private int numberOfTendrils;
    [SerializeField] private float distanceBetweenTendrils;
    private bool hasAttacked;



    public override void DoEnterLogic()
    {
        base.DoEnterLogic();
        rb.velocity = Vector3.zero;
        animator.Play(stateAnimation.name);
        hasAttacked = false;
    }

    public override void DoUpdateState()
    {
        base.DoUpdateState();

        if (stateUptime > windupTime && !hasAttacked)
        {
            // Attack
            Attack();
            hasAttacked = true;
        }


        if (hasAttacked && animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.95f)
        {
            core.stateMachine.ChangeState(core.states["Idle"]);
        }

    }

    private void Attack()
    {
        for (int i = 1; i <= numberOfTendrils; i++)
        {
            Instantiate(tendrilIndicatorPrefab, new Vector2(enemy.transform.position.x + distanceBetweenTendrils * i, 0), Quaternion.identity);
            Instantiate(tendrilIndicatorPrefab, new Vector2(enemy.transform.position.x - distanceBetweenTendrils * i, 0), Quaternion.identity);
        }
    }
}
