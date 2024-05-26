using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAttacks : MonoBehaviour
{

    [Header("Combo")]
    [SerializeField] private List<PlayerAttackSO> combo;
    [SerializeField] private float continueComboTimer = 0.2f;
    [SerializeField] private float timeBetweenCombos = 1f;
    private float lastAttackTime;
    private float lastComboEnd;
    private int comboCounter;

    [SerializeField] private PlayerStateMachine stateMachine;
    [SerializeField] private float attackCooldown = 0.5f;
    public GameObject AttackPoint;
    private Animator anim;


    private void Start()
    {
        anim = GetComponentInChildren<Animator>();
    }

    public void Update()
    {



        if (Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
        }

        ExitAttack();
    }


    void Attack()
    {
        if(Time.time - lastComboEnd > timeBetweenCombos && comboCounter <= combo.Count)
        {
            CancelInvoke("EndCombo");

            if (Time.time - lastAttackTime >= attackCooldown)
            {
                
                stateMachine.ChangeState(stateMachine.AttackState);
                anim.runtimeAnimatorController = combo[comboCounter].animatorOV;
                // Add damage changing
                anim.Play("Attack", 0, 0);
                comboCounter++;
                if(comboCounter >= combo.Count)
                {
                    EndCombo();
                }
                lastAttackTime = Time.time;
            }
        }
    }

    void ExitAttack()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.9f && anim.GetCurrentAnimatorStateInfo(0).IsTag("Attack"))
        {
            Invoke("EndCombo", continueComboTimer);

            if (stateMachine.inputManager.MoveInput == 0)
            {
                stateMachine.ChangeState(stateMachine.IdleState);
            }
            else
            {
                stateMachine.ChangeState(stateMachine.MovingState);
            }
        }
    }

    void EndCombo()
    {
        comboCounter = 0;
        lastComboEnd = lastAttackTime;
    }
}
