using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action_Attack : FSM_Action
{
    [SerializeField] float damage;
    [SerializeField] float timeBetweenAttacks;

    float timer;
    EnemyBrain brain;

    private void Awake()
    {
        brain = GetComponent<EnemyBrain>();
    }

    public override void Act()
    {
        AttackPlayer();
    }

    public void AttackPlayer()
    {
        if (brain.Player == null)
        {
            return;
        }

        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            IDamagable player = brain.Player.GetComponent<IDamagable>();
            player.TakeDamage(damage);
            timer = timeBetweenAttacks;
        }
    }
}
