using UnityEngine;

[System.Serializable]
public class RandomSkill
{
    public float weight;
    public EnemySkillData skill;
}

[CreateAssetMenu(menuName = "Data/Enemy")]
public class EnemyData : UnitData
{
    public RandomSkill[] skills;
    public AbilityData[] abilities;
}
