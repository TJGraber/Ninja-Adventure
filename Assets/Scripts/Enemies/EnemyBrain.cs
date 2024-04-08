using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public enum EnemyState
{
    NONE,
    WANDER,
    PATROL,
    CHASE,
    ATTACK
}

public class EnemyBrain : MonoBehaviour
{
    [SerializeField] EnemyState enemyState;
    [SerializeField] FSM_State[] states;

    public FSM_State CurrentState { get; set; }
    public Transform Player {  get; set; }


    void Update()
    {
        if(CurrentState == null)
        {
            return;
        }

        CurrentState.UpdateState(this);
    }

    void Start()
    {
        ChangeState(enemyState);
    }

    FSM_State GetState(EnemyState currentState)
    {
        for (int i = 0; i < states.Length; i++)
        {
            if (states[i].ID == currentState)
            {
                return states[i];
            }
        }

        return null;
    }

    public void ChangeState(EnemyState newState)
    {
        FSM_State state = GetState(newState);

        if (state == null)
        {
            return;
        }

        CurrentState = state;
    }
}
