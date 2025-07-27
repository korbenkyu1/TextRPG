using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/Player")]
public class PlayerData : UnitData
{
    public Sprite icon;
    public PlayerSkillData[] skills = new PlayerSkillData[5];
    public List<AbilityData> abilities;
}
