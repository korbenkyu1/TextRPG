using System;
using UnityEngine;


[System.Serializable]
public class ResultData
{
    public string message;
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
