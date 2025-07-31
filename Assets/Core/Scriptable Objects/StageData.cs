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
    public Sprite[] images;
    [TextArea] public string[] messages;
    public int coin;
    public int maxHealth;
    public int health;
    public int attack;
    public int defense;
    public int critChance;
    public int dodgeChance;
    public RewardType type;
    public bool gameOver;
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

[CreateAssetMenu(menuName = "Data/Stage")]
public class StageData : ScriptableObject
{
    public Sprite[] images;
    [TextArea] public string[] descriptions;
    public OptionData[] options;
    public ResultData deadEnding;
}
