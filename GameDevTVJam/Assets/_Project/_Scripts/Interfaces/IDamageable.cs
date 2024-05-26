using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable
{
    int health { get; }
    public void TakeDamage(int damage);
}
