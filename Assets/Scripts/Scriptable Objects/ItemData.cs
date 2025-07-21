using UnityEngine;

[CreateAssetMenu(menuName = "Data/Item")]
public class ItemData : ScriptableObject
{
    public string itemName;
    public Sprite image;
    public string description;
    public string flavorText;
    public AbilityData[] abilityData;
}
