using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable
{
    float maxHealth { get; set; }
    float currentHealth { get; set; }
    public void TakeDamage(int damage, float knockback, float xPos);
}
