using UnityEngine;

[CreateAssetMenu(menuName = "Data/EnemySkill/EnemyEffectAttack")]
public class EnemyEffectAttack : EnemySkillData
{
    [SerializeField]
    public int attackCoefficient;
    public int attackCount;
    public string effectName;
    public int stack;
    public bool isTargetingPlayer;
    public override void OnActivate(CombatManager combatManager)
    {
        int damage = (int)(combatManager.enemy.stats.attack * (attackCoefficient / 100f));
        for(int i = 0; i < attackCount; i++)
            combatManager.player.damages.Add(damage);

        if(isTargetingPlayer)
            combatManager.player.statusEffects[effectName].stack = stack;
        else
            combatManager.enemy.statusEffects[effectName].stack = stack;
    }
}