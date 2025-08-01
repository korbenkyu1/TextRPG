using UnityEngine;

[CreateAssetMenu(menuName = "Data/EnemySkill/Shared/EnemyEffect2Attack")]
public class EnemyEffect2Attack : EnemySkillData
{
    [SerializeField]
    public string effectName1;
    public int stack1;
    public bool isTargetingPlayer1;
    public string effectName2;
    public int stack2;
    public bool isTargetingPlayer2;
    public int AttackCoefficient;
    public int AttackCount;

    public override void OnActivate(CombatManager combatManager)
    {
        int damage = (int)(combatManager.enemy.stats.attack * AttackCoefficient / 100f);
        for(int i = 0;  i < AttackCount; i++)
            combatManager.player.damages.Add(damage);
        if (isTargetingPlayer1)
            combatManager.player.statusEffects[effectName1].stack += stack1;
        else
            combatManager.enemy.statusEffects[effectName1].stack += stack1;
        if (isTargetingPlayer2)
            combatManager.player.statusEffects[effectName2].stack += stack2;
        else
            combatManager.enemy.statusEffects[effectName2].stack += stack2;
    }

}