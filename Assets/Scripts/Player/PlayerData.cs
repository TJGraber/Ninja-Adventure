using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    [SerializeField] PlayerStats playerStats;

    public PlayerStats PlayerStats => playerStats;
}
