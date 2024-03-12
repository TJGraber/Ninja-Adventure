using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMana : MonoBehaviour
{

    PlayerData playerData;

    private void Awake()
    {
        playerData = GetComponent<PlayerData>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            UseMana(1f);
        }
    }

    public void UseMana(float amount)
    {
        if(playerData.PlayerStats.CurrentMana >= amount)
        {
            playerData.PlayerStats.CurrentMana -= amount;
        }
    }

}
