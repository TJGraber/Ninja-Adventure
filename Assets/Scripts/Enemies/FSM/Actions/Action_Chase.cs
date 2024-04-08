using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action_Chase : FSM_Action
{
    [SerializeField] float chaseSpeed;
    [SerializeField] float stoppingDistance;

    EnemyBrain enemyBrain;

    public override void Act()
    {
        if (enemyBrain.Player == null)
        {
            return;
        }

        Vector3 direction = enemyBrain.Player.position - transform.position;

        print(direction.magnitude);
        print("testing1");

        if (direction.magnitude >= stoppingDistance)
        {
            print("testing2");
            transform.Translate(direction.normalized * (chaseSpeed * Time.deltaTime));
        }
    }

    private void Awake()
    {
        enemyBrain = GetComponent<EnemyBrain>();
    }

    void ChasePlayer()
    {
        /*if (enemyBrain.Player == null)
        {
            return;
        }

        Vector3 direction = enemyBrain.Player.position - transform.position;

        print(direction.magnitude);
        print("testi");

        if (direction.magnitude >= stoppingDistance)
        {
            print("testing");
            transform.Translate(direction.normalized * (chaseSpeed * Time.deltaTime));
        } */
    }
}
