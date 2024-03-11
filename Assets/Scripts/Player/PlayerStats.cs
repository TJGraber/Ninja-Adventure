using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStats", menuName = "PlayerStats/Create new stats")]
public class PlayerStats : ScriptableObject
{
    public int CurrentLevel;
    public float CurrentHealth;
    public float MaximumHealth;


}