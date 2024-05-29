using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy States/Attack/Hatcher")]
public class EnemyAttackHatcher : EnemyState
{
    [SerializeField] private GameObject wigglerPrefab;
    [SerializeField] private float wigglerSpawnInterval = 2f;
    private float timer;
    public override void DoEnterLogic()
    {
        base.DoEnterLogic();
        timer = wigglerSpawnInterval;
    }

    public override void DoExitLogic()
    {
        base.DoExitLogic();

    }

    public override void DoUpdateState()
    {
        base.DoUpdateState();

        timer -= Time.deltaTime;
        Debug.Log("attack charging");

        if (timer < 0f)
        {
            Debug.Log("spawn the wiggles");
            Instantiate(wigglerPrefab, enemy.transform.position, wigglerPrefab.transform.rotation);
            timer = wigglerSpawnInterval;
            core.stateMachine.ChangeState(core.states["Idle"]);
        }
    }
}