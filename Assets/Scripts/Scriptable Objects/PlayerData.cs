using UnityEngine;

[CreateAssetMenu(menuName = "Data/Player")]
public class PlayerData : UnitData
{
    public string flavorText;
    public PlayerSkillData[] skills = new PlayerSkillData[5];
    public AbilityData[] abilities;
}
