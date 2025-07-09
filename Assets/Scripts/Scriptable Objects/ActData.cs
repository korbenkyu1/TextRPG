using System;
using UnityEngine;

public enum RewardType
{
    None,
    Skill,
    Item,
    Food,
}

[System.Serializable]
public class ResultData
{
    public string message;
    public int coin;
    public int maxHealth;
    public int health;
    public int attack;
    public int defense;
    public int critChance;
    public int dodgeChance;
    public RewardType type;
    // reward
}

[System.Serializable]
public class OptionData
{
    public string label;
    public int requiredCoin;
    public int requiredHealth;
    public EnemyData enemy;
    public ResultData result;
}

[CreateAssetMenu(menuName = "Data/Act")]
public class ActData : ScriptableObject
{
    public Sprite image;
    public string description;
    public OptionData[] options;
}
