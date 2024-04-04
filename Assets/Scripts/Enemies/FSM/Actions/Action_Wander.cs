using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action_Wander : FSM_Action
{
    [SerializeField] float moveSpeed;
    [SerializeField] float wanderTime;
    [SerializeField] Vector2 moveRange;

    Vector3 moveDestination;
    float timer;

    public override void Act()
    {
        timer -= Time.deltaTime;
        Vector3 moveDirection = (moveDestination - transform.position).normalized;
        Vector3 movement = moveDirection * (moveSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, moveDestination) >= 0.5f)
        {
            transform.Translate(movement);
        }

        if (timer <= 0)
        {
            GetNewDestination();
            timer = wanderTime;
        }
    }

    private void Start()
    {
        GetNewDestination();
    }

    private void OnDrawGizmosSelected()
    {
        if (moveRange != Vector2.zero)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireCube(transform.position, moveRange * 2f);
            Gizmos.DrawLine(transform.position, moveDestination);
        }
    }

    void GetNewDestination()
    {
        float randomX = Random.Range(-moveRange.x, moveRange.x);
        float randomY = Random.Range(-moveRange.y, moveRange.y);

        moveDestination = transform.position + new Vector3(randomX, randomY);
        print(moveDestination);
    }
}
