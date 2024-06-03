using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableObject : Enemy
{
    [SerializeField] private GameObject dropPrefab;

    protected override void Awake()
    {
        base.Awake();
        stateMachine.Initialize(states["Object"]);
    }

    public override void TakeDamage(int damage, float knockback, float xPos)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Break();
        }
    }

    public void Break()
    {

        GameObject wiggler = Instantiate(dropPrefab, transform.position, dropPrefab.transform.rotation);


        Destroy(this.gameObject);
    }
}
