using UnityEngine;


public abstract class EnemySkillData : ScriptableObject
{
    public string naration;
    public bool dodgable;
    public abstract void OnActivate(CombatManager combatManager);
}
