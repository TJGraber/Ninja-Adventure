using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, IDamagable
{
    [SerializeField] PlayerStats playerStats;

    PlayerAnimations animations;

    private void Awake()
    {
        animations = GetComponent<PlayerAnimations>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(1f);
        }
    }

    public void TakeDamage(float damageAmount)
    {
        playerStats.CurrentHealth -= damageAmount;

        if(playerStats.CurrentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        animations.HandleDeadAnimation();
    }
}
