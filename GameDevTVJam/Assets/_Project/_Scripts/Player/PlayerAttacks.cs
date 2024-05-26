using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttacks : MonoBehaviour
{
    [SerializeField] private PlayerStateMachine stateMachine;
    [SerializeField] private float attackCooldown = 0.5f;
    public GameObject AttackPoint;
    private float attackTimer;


    
    public void Update()
    {

        attackTimer -= Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space) && attackTimer < 0f)
        {
            attackTimer = attackCooldown;
            stateMachine.ChangeState(stateMachine.AttackState);
        }
    }
}
