using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
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
        /*if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(1f);
        } */

        if (playerStats.CurrentHealth <= 0f) {
            Die();
        }
    }

    public void TakeDamage(float damageAmount)
    {
        if (playerStats.CurrentHealth <= 0f)
        {
            return;
        }

        playerStats.CurrentHealth -= damageAmount;

        DamageManager.i.ShowDamageText(damageAmount, this.transform);

        if (playerStats.CurrentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        animations.HandleDeadAnimation();
    }
}
