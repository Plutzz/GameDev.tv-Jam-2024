using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackHitbox : MonoBehaviour
{
    private List<Collider2D> previousHits;
    private Collider2D hitbox;
    [HideInInspector] public int damage;
    [HideInInspector] public float knockback;
    [HideInInspector] public FMODEvents.NetworkSFXName sfxName;

    private void Awake()
    {
        previousHits = new List<Collider2D>();
        hitbox = GetComponent<Collider2D>();
        sfxName = FMODEvents.NetworkSFXName.BladeSwing1;
    }
    private void OnEnable()
    {
        previousHits.Clear();
        hitbox.enabled = true;
        AudioManager.Instance.PlayOneShot(sfxName, transform.position);
    }
    private void OnDisable()
    {
        hitbox.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<IDamageable>() != null && !previousHits.Contains(collision))
        {
            previousHits.Add(collision);
            collision.GetComponent<IDamageable>().TakeDamage(damage, knockback, transform.parent.position.x);
        }
    }

}
