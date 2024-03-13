using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStats", menuName = "PlayerStats/Create new stats")]
public class PlayerStats : ScriptableObject
{
    public int CurrentLevel;
    public float CurrentHealth;
    public float MaximumHealth;
    public float CurrentMana;
    public float MaximumMana;

    public void ResetPlayerStats()
    {
        CurrentHealth = MaximumHealth;
        CurrentMana = MaximumMana;
        CurrentLevel = 1;
    }

    public void RevivePlayer()
    {
        CurrentHealth = MaximumHealth / 2;
        CurrentMana = MaximumMana / 2;
    }
}
