using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hatcher : Enemy
{
    [SerializeField] private GameObject wigglerPrefab;
    [SerializeField] private int wigglersSpawnedOnDeath;
    [SerializeField] private float scatterRange = 5;

    protected override void Awake()
    {
        base.Awake();
        stateMachine.Initialize(states["Idle"]);
    }

    public void Death()
    {
        for(int i = 0; i < wigglersSpawnedOnDeath; i++)
        {
            GameObject wiggler = Instantiate(wigglerPrefab, transform.position, wigglerPrefab.transform.rotation);                                          //test if need normalized
            wiggler.GetComponent<Rigidbody2D>().AddForce((new Vector2(Random.Range(-scatterRange, scatterRange), Random.Range(-scatterRange, scatterRange))).normalized, ForceMode2D.Impulse);
        }

        Destroy(this.gameObject);
    }
}
