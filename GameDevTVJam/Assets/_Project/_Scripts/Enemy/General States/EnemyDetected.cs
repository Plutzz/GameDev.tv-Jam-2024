using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy States/General States/Detected")]
public class EnemyDetected : EnemyState
{
    [SerializeField] private GameObject detectedPrefab;
    private GameObject detected;
    [SerializeField] private Vector3 localOffset;


    public override void DoEnterLogic()
    {
        base.DoEnterLogic();

        detected = Instantiate(detectedPrefab, core.transform);
        detected.transform.localPosition = localOffset;
        rb.velocity = Vector3.zero;

        // If the enemy is not facing the player, flip the enemy's sprite
        bool playerDirection = (enemy.player.transform.position.x - enemy.transform.position.x) > 0;

        if(isFacingRight != playerDirection)
        {
            enemy.FlipSprite();
        }


        // Animation clip
        if (animator != null && stateAnimation != null)
            animator.Play(stateAnimation.name);
    }

    public override void DoExitLogic()
    {
        base.DoExitLogic();
        Destroy(detected);
    }
}
