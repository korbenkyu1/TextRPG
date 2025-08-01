using UnityEngine;

[CreateAssetMenu(menuName = "Data/EnemySkill/Shared/EnemyEffect2")]
public class EnemyEffect2 : EnemySkillData
{
    [SerializeField]
    public string effectName1;
    public int stack1;
    public bool isTargetingPlayer1;
    public string effectName2;
    public int stack2;
    public bool isTargetingPlayer2;
    public override void OnActivate(CombatManager combatManager)
    {
        if (isTargetingPlayer1)
            combatManager.player.statusEffects[effectName1].stack += stack1;
        else if(!isTargetingPlayer1)
            combatManager.enemy.statusEffects[effectName1].stack += stack1;
        if (isTargetingPlayer2)
            combatManager.player.statusEffects[effectName2].stack += stack2;
        else if (!isTargetingPlayer2)
            combatManager.enemy.statusEffects[effectName2].stack += stack2;
    }

}