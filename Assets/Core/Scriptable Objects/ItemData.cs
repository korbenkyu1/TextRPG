using System;
using UnityEngine;

[Serializable]
public class AbilityModifier
{
    public int modifier;
    public AbilityData abilityData;
}

[CreateAssetMenu(menuName = "Data/Item")]
public class ItemData : ScriptableObject
{
    public string itemName;
    public Sprite icon;
    public Sprite image;
    public string description;
    public AbilityModifier[] abilityModifiers;
    public AbilityData requiredAbilityA, requiredAbilityB;
}
