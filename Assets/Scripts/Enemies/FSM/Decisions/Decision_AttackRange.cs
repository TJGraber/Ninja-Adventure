using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Decision_AttackRange : FSM_Decision
{
    [SerializeField] float attackRange;
    [SerializeField] LayerMask playerMask;

    EnemyBrain enemy;

    private void Awake()
    {
        enemy = GetComponent<EnemyBrain>();
    }

    public override bool Decide()
    {
        return InAttackRange();
    }

    bool InAttackRange()
    {
        if (enemy.Player == null)
            return false;

        Collider2D playerCollider = Physics2D.OverlapCircle(enemy.transform.position, attackRange, playerMask);

        if (playerCollider != null)
            return true;

        return false;

    }



    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
