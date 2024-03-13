using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    [SerializeField] PlayerStats playerStats;

    PlayerAnimations playerAnimations;
    public PlayerStats PlayerStats => playerStats;

    private void Awake()
    {
        playerAnimations = GetComponent<PlayerAnimations>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            PlayerRevive();
        }
    }

    public void PlayerRevive()
    {
        playerStats.RevivePlayer();
        playerAnimations.ResetPlayerAnimation();
    }
}
