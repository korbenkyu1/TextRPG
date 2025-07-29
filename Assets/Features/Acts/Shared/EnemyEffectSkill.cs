using UnityEngine;

[CreateAssetMenu(menuName = "Data/EnemySkill/EnemyEffectSkill")]
public class EnemyEffectSkill : EnemySkillData
{
    [SerializeField]
    public string effectName;
    public int stack;
    public bool isTargetingPlayer;
    public override void OnActivate(CombatManager combatManager)
    {
        if (isTargetingPlayer)
            combatManager.player.statusEffects[effectName].stack += stack;
        else if(!isTargetingPlayer)
            combatManager.enemy.statusEffects[effectName].stack += stack;
    }

}